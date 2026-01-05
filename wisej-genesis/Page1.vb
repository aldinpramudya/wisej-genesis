Imports System
Imports System.IO
Imports System.Net
Imports Wisej.Core
Imports Wisej.Web

Public Class Page1
    Inherits Page

    'Menyimpan Category Nodes
    Private CategoryNodes As New List(Of TreeNode)

    Public Sub Page1()
        InitializeComponent()
    End Sub

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
        Dim data = WisejSerializer.Parse(text)
        Me.TreeView1.Nodes.Clear()

        For Each category As DynamicObject.Member In CType(data, IEnumerable(Of DynamicObject.Member))
            Dim categoryName As String = category.Name
            Dim categoryData As Object = CType(category.Value, Object)

            ' Membuat Node Kategori
            Dim categoryNode As New TreeNode With {
            .Text = categoryName,
            .Name = categoryName
        }
            categoryNode.UserData("Type") = "Category"

            Dim hasRoutes As Boolean = False
            Try
                hasRoutes = (categoryData.routes IsNot Nothing)
            Catch
                hasRoutes = False
            End Try

            If hasRoutes Then
                For Each route As DynamicObject.Member In CType(categoryData.routes, IEnumerable(Of DynamicObject.Member))
                    Dim routeName As String = route.Name
                    Dim routeData As Object = CType(route.Value, Object)

                    ' Ambil description dengan aman
                    Dim routeDescription As String = ""
                    Try
                        routeDescription = routeData.description.ToString()
                    Catch
                        routeDescription = ""
                    End Try

                    ' Ambil assembly dengan aman
                    Dim routeAssembly As String = ""
                    Try
                        routeAssembly = routeData.assembly.ToString()
                    Catch
                        routeAssembly = ""
                    End Try

                    ' Buat Node Route
                    Dim routeNode As New TreeNode With {
                        .Text = routeName,
                        .Name = routeName
                    }
                    routeNode.UserData("Type") = "Route"

                    routeNode.Tag = New With {
                        .Title = routeName,
                        .Description = routeDescription,
                        .Category = categoryName,
                        .Control = routeName,
                        .Info = routeData,
                        .Hash = String.Format("{0}/{1}", categoryName, routeName).Replace(" ", "%20")
                    }

                    categoryNode.Nodes.Add(routeNode)
                Next
            Else

                Dim categoryDescription As String = ""
                Try
                    categoryDescription = categoryData.description.ToString()
                Catch
                    categoryDescription = ""
                End Try

                Dim categoryAssembly As String = ""
                Try
                    categoryAssembly = categoryData.assembly.ToString()
                Catch
                    categoryAssembly = ""
                End Try

                categoryNode.Tag = New With {
                    .Title = categoryName,
                    .Description = categoryDescription,
                    .Category = categoryName,
                    .Control = categoryName,
                    .Info = categoryData,
                    .Hash = String.Format("{0}", categoryName).Replace(" ", "%20")
                }
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

        If node.Tag Is Nothing Then
            Return
        End If

        Dim data As Object = CType(node.Tag, Object)
        Dim category As String = data.Category
        Dim control As String = If(data.Control IsNot Nothing, data.Control.ToString(), "")
        Dim title As String = data.Title
        Dim description As String = data.Description
        Dim info As Object = data.Info

        Dim culture As String = Application.CurrentCulture.TwoLetterISOLanguageName

        'ambil Fully Qualified Name dari assembly
        Dim fullyQualifiedName As String = Nothing
        Try
            fullyQualifiedName = If(info.assembly IsNot Nothing, info.assembly.ToString(), Nothing)
        Catch
            fullyQualifiedName = Nothing
        End Try

        If fullyQualifiedName IsNot Nothing Then
            Try
                If Not fullyQualifiedName.Contains(",") Then
                    Throw New Exception(String.Format("Invalid assembly format: '{0}'. Expected format: 'TypeName, AssemblyName.dll'", fullyQualifiedName))
                End If

                Dim components As String() = fullyQualifiedName.Split(","c)

                If components.Length < 2 Then
                    Throw New Exception(String.Format("Invalid assembly format: '{0}'. Expected format: 'TypeName, AssemblyName.dll'", fullyQualifiedName))
                End If

                Dim typeName As String = components(0).Trim()
                Dim assemblyName As String = components(1).Trim()


                Console.WriteLine("TypeName: " & typeName)
                Console.WriteLine("AssemblyName: " & assemblyName)

                If String.IsNullOrEmpty(assemblyName) Then
                    Throw New Exception("Assembly name is empty")
                End If

                Dim directory As String = Path.GetDirectoryName(Application.ExecutablePath)
                Dim pathFile As String = Path.Combine(directory, assemblyName)

                Console.WriteLine("Assembly Path: " & pathFile)

                If Not File.Exists(pathFile) Then
                    Throw New Exception(String.Format("Assembly file not found: {0}", pathFile))
                End If

                Dim assembly As System.Reflection.Assembly = Nothing

                Try
                    assembly = System.Reflection.Assembly.LoadFrom(pathFile)
                Catch ex As Exception
                    Dim nameWithoutExtension As String = Path.GetFileNameWithoutExtension(assemblyName)
                    assembly = System.Reflection.Assembly.Load(nameWithoutExtension)
                End Try

                If assembly Is Nothing Then
                    Throw New Exception("Failed to load assembly")
                End If

                Dim type As Type = assembly.GetTypes().Where(Function(t) t.Name = typeName).FirstOrDefault()

                If type Is Nothing Then
                    Dim availableTypes As String = String.Join(", ", assembly.GetTypes().Select(Function(t) t.Name))
                    Throw New Exception(String.Format("Type '{0}' not found in assembly. Available types: {1}", typeName, availableTypes))
                End If

                Dim demoInstance As Control = CType(Activator.CreateInstance(type), Control)

                If node.UserData("args") IsNot Nothing Then
                    demoInstance.UserData("args") = node.UserData("args")
                End If

                demoInstance.Dock = DockStyle.Fill
                container.Controls.Add(demoInstance)
                container.Text = title
                Application.Hash = data.Hash

                Me.Label1.Text = String.Format("{0}", control, If(title, demoInstance.Name))
                Me.Label2.Text = If(description, "")

            Catch ex As Exception
                MessageBox.Show(String.Format("Error loading demo:" & vbCrLf & vbCrLf &
                                        "Message: {0}" & vbCrLf & vbCrLf &
                                        "Assembly: {1}" & vbCrLf & vbCrLf &
                                        "StackTrace: {2}",
                                        ex.Message,
                                        fullyQualifiedName,
                                        ex.StackTrace),
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            UpdateUIWithoutDemo(category, control, title, description, data.Hash)
        End If
    End Sub

    'Debugging Only
    Private Sub UpdateUIWithoutDemo(category As String, control As String, title As String, description As String, hash As String)
        Application.Hash = hash
        Me.Label1.Text = String.Format("{0} - {1}", category, title)
        Me.Label2.Text = description

        Dim label As New Label With {
            .Text = String.Format("Content: {0}", title),
            .Dock = DockStyle.Fill
        }
        Me.PanelMain.Controls.Add(label)
    End Sub
End Class
