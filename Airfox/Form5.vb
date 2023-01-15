Public Class Form5
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form4.Show()
        Form1.StartMenuPanel.Hide()
        Me.Hide()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CType(Form1.TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Navigate("http://airfox.sourceforge.net/help/")
        Form1.StartMenuPanel.Hide()
        Me.Hide()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form1.StartMenuPanel.Hide()
        Me.Hide()
    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub
End Class