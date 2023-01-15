Imports System
Imports System.Diagnostics
Imports System.Threading
Public Class Reset_Advanced_Settings
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Process.Start(Application.StartupPath & "/tools/reset_advanced_settings.bat")
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.StartMenuPanel.Hide()
    End Sub
    Private Sub Reset_Advanced_Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub
End Class