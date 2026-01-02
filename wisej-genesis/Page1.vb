Imports System
Imports System.IO
Imports System.Net
Imports Wisej.Web

Public Class Page1
    Inherits Page

    'Menyimpan Category Nodes
    Private CategoryNodes As New List(Of TreeNode)

    Private Sub Page1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim hash As String = Application.Hash
        AddHandler Application.HashChanged, AddressOf Me.Application_HashChanged

        Me.TreeView1.Nodes.Clear()
        PopulateTreeList()

#If NETCOREAPP Then
        LoadUnreferencedWisejAssemblies()
#End If

        If Me.TreeView1.Nodes.Count > 0 Then
            Me.TreeView1.SelectedNode = Me.TreeView1.Nodes(0)
        End If

        If Not String.IsNullOrEmpty(hash) Then
            SelectNode(hash)
        End If

        If Not Me.PanelComponents.Collapsed Then
            Me.PanelComponents.ShowHeader = False
        End If

    End Sub

    Private Sub Application_HashChanged(sender As Object, e As EventArgs)
        Dim hash As String = Application.Hash
        If Not String.IsNullOrEmpty(hash) Then
            SelectNode(hash)
        End If
    End Sub

    Private Sub SelectNode(path As String)
        If String.IsNullOrEmpty(path) Then
            Me.TreeView1.SelectedNode = Me.TreeView1.Nodes(0)
            Return
        End If

        Try
            Dim nodePath As String() = WebUtility.UrlDecode(path).Split(Me.TreeView1.PathSeparator.ToCharArray())

            Dim categoryNode As TreeNode = Nothing
            For Each node As TreeNode In Me.CategoryNodes
                If node.Text = nodePath(0) Then
                    categoryNode = node
                    Exit For
                End If
            Next

            If categoryNode Is Nothing Then
                Throw New Exception("Category Not Found")
            End If

            If nodePath.Length = 1 Then
                Me.TreeView1.SelectedNode = categoryNode
                Return
            End If

            Dim routeNode As TreeNode = Nothing
            For Each node As TreeNode In categoryNode.Nodes
                If node.Text = nodePath(1) Then
                    routeNode = node
                    Exit For
                End If
            Next

            If routeNode IsNot Nothing Then
                Me.TreeView1.SelectedNode = routeNode
            Else
                Me.TreeView1.SelectedNode = categoryNode
            End If

        Catch ex As Exception
            Wisej.Web.AlertBox.Show("Unknown Route.", MessageBoxIcon.Error, showProgressBar:=True)
        End Try
    End Sub

    Private Sub LoadUnreferencedWisejAssemblies()
        Dim directory As String = Path.GetDirectoryName(Application.ExecutablePath)
        Dim assemblies As String() = System.IO.Directory.GetFiles(directory, "*.dll")

        For Each assemblyPath As String In assemblies
            Application.LoadAssembly(Path.Combine(directory, assemblyPath))
        Next
    End Sub

    Private Sub PopulateTreeList()
        Dim text As String = File.ReadAllText(Path.Combine(Application.MapPath("RoutingBrowser.json")))
        Dim data = Wisej.Core.WisejSerializer.Parse(text)

        Me.TreeView1.Nodes.Clear()

        For Each category As Wisej.Core.DynamicObject.Member In CType(data, IEnumerable(Of Wisej.Core.DynamicObject.Member))
            Dim categoryName As String = category.Name
            Dim categoryData As Object = CType(category.Value, Object)

            'Membuat Node Kategori
            Dim categoryNode As New TreeNode With {
                .Text = categoryName,
                .Name = categoryName
            }

            categoryNode.UserData.Type = "Category"

            If categoryData.routes IsNot Nothing Then
                For Each route As Wisej.Core.DynamicObject.Member In CType(categoryData.routes, IEnumerable(Of Wisej.Core.DynamicObject.Member))
                    Dim routeName As String = route.Name
                    Dim routeData As Object = CType(route.Value, Object)

                    'Buat Node Route
                    Dim routeNode As New TreeNode With {
                        .Text = routeName,
                        .Name = routeName
                    }
                    routeNode.UserData.Type = "Route"

                    routeNode.Tag = New With {
                        .Title = routeName,
                        .Description = routeData.description,
                        .Category = categoryName,
                        .Hash = String.Format("{0}/{1}", categoryName, routeName).Replace(" ", "%20")
                    }

                    categoryNode.Nodes.Add(routeNode)
                Next
            End If
            Me.TreeView1.Nodes.Add(categoryNode)
        Next
        If Me.TreeView1.Nodes.Count > 0 Then
            Me.TreeView1.SelectedNode = Me.TreeView1.Nodes(0)
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim selectedNode As TreeNode = Me.TreeView1.SelectedNode

        If selectedNode.Tag Is Nothing Then
            If selectedNode.Nodes.Count > 0 Then
                Me.TreeView1.SelectedNode = selectedNode.Nodes(0)
            End If
        Else
            ProcessNodeSelection(selectedNode)
        End If
    End Sub

    Private Sub ProcessNodeSelection(node As TreeNode)
        Dim container As Control = Me.PanelMain
        container.Controls.Clear(True)

        Dim data As Object = CType(node.Tag, Object)
        Dim category As String = data.Category
        Dim control As String = If(data.Control IsNot Nothing, data.Control.ToString(), "")
        Dim title As String = data.Title
        Dim info As Object = data.Info

        Dim culture As String = Application.CurrentCulture.TwoLetterISOLanguageName
        Dim description As String = ""

        'Ambil Deskripsi
        Try
            description = info("description")
        Catch
            description = "Data Description Masih Belum Dapat Diambil"
        End Try

        'ambil Fully Qualified Name dari assembly
        Dim fullyQualifiedName As String = Nothing
        Try
            fullyQualifiedName = If(info.assembly IsNot Nothing, info.assembly.ToString(), Nothing)
        Catch
            fullyQualifiedName = Nothing
        End Try

        If fullyQualifiedName IsNot Nothing Then
            Try
                Dim components As String() = fullyQualifiedName.Split(","c)
                Dim assemblyName As String = components(1).Trim()
                Dim typeName As String = components(0).Trim()

                Dim directory As String = Path.GetDirectoryName(Application.ExecutablePath)
                Dim pathFile As String = Path.Combine(directory, assemblyName)

                Dim assembly As System.Reflection.Assembly = Application.LoadAssembly(pathFile)

                Dim type As Type = assembly.GetTypes().Where(Function(t) t.Name = typeName).FirstOrDefault()

                If type IsNot Nothing Then
                    Dim demoInstance As Control = CType(Activator.CreateInstance(type), Control)

                    If node.UserData.args IsNot Nothing Then
                        demoInstance.UserData.args = node.UserData.args
                    End If

                    demoInstance.Dock = DockStyle.Fill
                    container.Controls.Add(demoInstance)

                    container.Text = title
                    Application.Hash = data.Hash

                    Me.Label1.Text = String.Format("{0} {1}", control, If(title, demoInstance.Name))
                    Me.Label2.Text = If(description, "")
                End If

            Catch ex As Exception
                MessageBox.Show(String.Format("Error loading demo: {0}", ex.Message),
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class
