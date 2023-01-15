Public Class Form2
    'Airfox Browser - www.airfoxbrowser.wordpress.com
    'By Charis Papadakis and Mike Gounelas.
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.StartMenuPanel.Hide()
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
        Dim Web As New System.Net.WebClient
        Dim News As String = Web.DownloadString("http://airfox.sourceforge.net/af_web/afv.txt")
        Label7.Text = News
        If Form1.Label2.Text = News Then
            Label5.Show()
        Else
            LinkLabel1.Show()
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Web As New System.Net.WebClient
        Dim News As String = Web.DownloadString("http://airfox.sourceforge.net/af_web/afv.txt")
        Label7.Text = News
        If Label2.Text = News Then
            Label5.Show()
        Else
            LinkLabel1.Show()
        End If
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Updater_Launch.Show()
    End Sub
End Class