<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Program3
    Inherits Wisej.Web.UserControl

    'Program3 overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    'It can be modified using the Wisej.NET Designer.
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.TabControl1 = New Wisej.Web.TabControl()
        Me.TabPage1 = New Wisej.Web.TabPage()
        Me.TextBox2 = New Wisej.Web.TextBox()
        Me.TabPage2 = New Wisej.Web.TabPage()
        Me.TextBox3 = New Wisej.Web.TextBox()
        Me.TextBox1 = New Wisej.Web.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(15, 75)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.PageInsets = New Wisej.Web.Padding(1, 30, 1, 1)
        Me.TabControl1.Size = New System.Drawing.Size(1119, 436)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TextBox2)
        Me.TabPage1.Location = New System.Drawing.Point(0, 0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1117, 405)
        Me.TabPage1.Text = "TabPage1"
        '
        'TextBox2
        '
        Me.TextBox2.Label.Position = Wisej.Web.LabelPosition.Left
        Me.TextBox2.LabelText = "Data 1"
        Me.TextBox2.Location = New System.Drawing.Point(20, 26)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(231, 22)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Watermark = "Isi Data Page 1"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TextBox3)
        Me.TabPage2.Location = New System.Drawing.Point(0, 0)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1117, 405)
        Me.TabPage2.Text = "TabPage2"
        '
        'TextBox3
        '
        Me.TextBox3.Label.Position = Wisej.Web.LabelPosition.Left
        Me.TextBox3.LabelText = "Data 1"
        Me.TextBox3.Location = New System.Drawing.Point(21, 31)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(231, 22)
        Me.TextBox3.TabIndex = 2
        Me.TextBox3.Watermark = "Isi Data Page 2"
        '
        'TextBox1
        '
        Me.TextBox1.Label.Position = Wisej.Web.LabelPosition.Left
        Me.TextBox1.LabelText = "Data 1"
        Me.TextBox1.Location = New System.Drawing.Point(15, 13)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(231, 22)
        Me.TextBox1.TabIndex = 1
        '
        'Program3
        '
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Program3"
        Me.Size = New System.Drawing.Size(1167, 525)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As Wisej.Web.TabControl
    Friend WithEvents TabPage1 As Wisej.Web.TabPage
    Friend WithEvents TabPage2 As Wisej.Web.TabPage
    Friend WithEvents TextBox1 As Wisej.Web.TextBox
    Friend WithEvents TextBox2 As Wisej.Web.TextBox
    Friend WithEvents TextBox3 As Wisej.Web.TextBox
End Class
