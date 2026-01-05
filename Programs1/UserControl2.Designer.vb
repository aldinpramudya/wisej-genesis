<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl2
    Inherits Wisej.Web.UserControl

    'UserControl2 overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
        Me.TextBox1 = New Wisej.Web.TextBox()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = Wisej.Web.AnchorStyles.Left
        Me.TextBox1.Label.Position = Wisej.Web.LabelPosition.Left
        Me.TextBox1.LabelText = "Data User Control 2"
        Me.TextBox1.Location = New System.Drawing.Point(15, 15)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(466, 30)
        Me.TextBox1.TabIndex = 0
        '
        'UserControl2
        '
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "UserControl2"
        Me.Size = New System.Drawing.Size(1105, 525)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As Wisej.Web.TextBox
End Class
