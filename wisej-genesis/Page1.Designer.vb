<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Page1
    Inherits Wisej.Web.Page

    'Overrides dispose to clean up the component list.
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Wisej.NET Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Wisej.NET Designer
    'It can be modified using the Wisej Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim TreeNode3 As Wisej.Web.TreeNode = New Wisej.Web.TreeNode()
        Dim TreeNode4 As Wisej.Web.TreeNode = New Wisej.Web.TreeNode()
        Me.PanelComponents = New Wisej.Web.Panel()
        Me.TreeView1 = New Wisej.Web.TreeView()
        Me.PanelMain = New Wisej.Web.Panel()
        Me.Label1 = New Wisej.Web.Label()
        Me.Label2 = New Wisej.Web.Label()
        Me.PanelComponents.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelComponents
        '
        Me.PanelComponents.AutoShow = Wisej.Web.PanelAutoShowMode.OnPointerOver
        Me.PanelComponents.BackColor = System.Drawing.Color.FromName("@table-row-background-selected")
        Me.PanelComponents.Controls.Add(Me.TreeView1)
        Me.PanelComponents.Dock = Wisej.Web.DockStyle.Left
        Me.PanelComponents.Location = New System.Drawing.Point(0, 0)
        Me.PanelComponents.Name = "PanelComponents"
        Me.PanelComponents.Size = New System.Drawing.Size(239, 745)
        Me.PanelComponents.TabIndex = 0
        '
        'TreeView1
        '
        Me.TreeView1.Anchor = CType((((Wisej.Web.AnchorStyles.Top Or Wisej.Web.AnchorStyles.Bottom) _
            Or Wisej.Web.AnchorStyles.Left) _
            Or Wisej.Web.AnchorStyles.Right), Wisej.Web.AnchorStyles)
        Me.TreeView1.Location = New System.Drawing.Point(20, 72)
        Me.TreeView1.Name = "TreeView1"
        TreeNode3.Name = "Node0"
        TreeNode4.Name = "Node1"
        TreeNode4.Text = "Node1"
        TreeNode3.Nodes.AddRange(New Wisej.Web.TreeNode() {TreeNode4})
        TreeNode3.Text = "ComboBox"
        Me.TreeView1.Nodes.AddRange(New Wisej.Web.TreeNode() {TreeNode3})
        Me.TreeView1.Size = New System.Drawing.Size(201, 460)
        Me.TreeView1.TabIndex = 0
        '
        'PanelMain
        '
        Me.PanelMain.Anchor = CType(((Wisej.Web.AnchorStyles.Top Or Wisej.Web.AnchorStyles.Left) _
            Or Wisej.Web.AnchorStyles.Right), Wisej.Web.AnchorStyles)
        Me.PanelMain.Location = New System.Drawing.Point(255, 114)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(888, 631)
        Me.PanelMain.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("default", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.Label1.Location = New System.Drawing.Point(255, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 34)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label Title"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((Wisej.Web.AnchorStyles.Top Or Wisej.Web.AnchorStyles.Left) _
            Or Wisej.Web.AnchorStyles.Right), Wisej.Web.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(264, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(678, 35)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas gravida justo a" &
    "t mattis cursus. Pellentesque gravida quam ac ex rutrum porta."
        '
        'Page1
        '
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.PanelComponents)
        Me.Name = "Page1"
        Me.Size = New System.Drawing.Size(1160, 518)
        Me.Text = "Page1"
        Me.PanelComponents.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelComponents As Wisej.Web.Panel
    Friend WithEvents PanelMain As Wisej.Web.Panel
    Friend WithEvents Label1 As Wisej.Web.Label
    Friend WithEvents TreeView1 As Wisej.Web.TreeView
    Friend WithEvents Label2 As Wisej.Web.Label
End Class
