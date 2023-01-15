Imports System
Imports System.Diagnostics
Imports System.Threading
Public Class Clear_Browsing_Data
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Process.Start(Application.StartupPath & "/tools/clear_browsing_data.bat")
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.StartMenuPanel.Hide()
    End Sub

    Private Sub Clear_Browsing_Data_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub
End Class