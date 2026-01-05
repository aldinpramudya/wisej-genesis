<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl1
    Inherits Wisej.Web.UserControl

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
    'It can be modified using the Wisej.NET Designer.
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.MonthCalendar1 = New Wisej.Web.MonthCalendar()
        Me.Label1 = New Wisej.Web.Label()
        Me.SuspendLayout()
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.AutoSize = True
        Me.MonthCalendar1.Location = New System.Drawing.Point(230, 86)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.Size = New System.Drawing.Size(299, 327)
        Me.MonthCalendar1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(581, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ini adalah halaman satu"
        '
        'UserControl1
        '
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(1127, 573)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MonthCalendar1 As Wisej.Web.MonthCalendar
    Friend WithEvents Label1 As Wisej.Web.Label
End Class
