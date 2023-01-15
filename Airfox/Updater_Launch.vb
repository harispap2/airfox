Public Class Updater_Launch
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Process.Start(Application.StartupPath & "/tools/airfoxupd.exe")
        For Each prog As Process In Process.GetProcesses
            If prog.ProcessName = "Airfox" Then
                prog.Kill()
            End If
        Next
    End Sub

    Private Sub Updater_Launch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub
End Class