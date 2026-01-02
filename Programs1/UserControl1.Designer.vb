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
        Me.SuspendLayout()
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.AutoSize = True
        Me.MonthCalendar1.Location = New System.Drawing.Point(150, 41)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.Size = New System.Drawing.Size(299, 327)
        Me.MonthCalendar1.TabIndex = 0
        '
        'UserControl1
        '
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(1000, 500)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MonthCalendar1 As Wisej.Web.MonthCalendar
End Class
