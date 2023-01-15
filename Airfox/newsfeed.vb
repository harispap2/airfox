Imports System.Net
Public Class newsfeed
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
        Dim Web As New WebClient
        Dim News As String = Web.DownloadString("http://airfoxhtml.t15.org/af.txt")
        RichTextBox1.Text = News
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.StartMenuPanel.Hide()
    End Sub
End Class
