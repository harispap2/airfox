Public Class Settings
    Dim homepath As String = System.Reflection.Assembly.GetExecutingAssembly.Location
    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
        TextBox1.Text = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\User\homepage.txt")
        If (My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\User\cache.txt")) = "0" Then
            CheckBox1.Checked = False
        Else
            CheckBox1.Checked = True
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim stream As New IO.StreamWriter(Application.StartupPath & "\User\homepage.txt", False)
        stream.WriteLine("")
        stream.Close()
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\User\homepage.txt", TextBox1.Text, True)
        Me.Hide()
        Form1.StartMenuPanel.Hide()
        If CheckBox1.Checked = True Then
            Gecko.GeckoPreferences.Default("browser.cache.disk.enable") = True
            Dim stream1 As New IO.StreamWriter(Application.StartupPath & "\User\cache.txt", False)
            stream1.WriteLine("")
            stream1.Close()
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\User\cache.txt", "1", True)
        Else
            Gecko.GeckoPreferences.Default("browser.cache.disk.enable") = False
            Dim stream2 As New IO.StreamWriter(Application.StartupPath & "\User\cache.txt", False)
            stream2.WriteLine("")
            stream2.Close()
            My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\User\cache.txt", "0", True)
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = "http://www.start.me/p/Vvj7qE/airfox-home"
        Form1.StartMenuPanel.Hide()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        Form1.StartMenuPanel.Hide()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        CType(Form1.TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Navigate("about:config")
        Form1.StartMenuPanel.Hide()
        Me.Hide()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox1.Text = (CType(((Form1.TabControl1.SelectedTab.Controls.Item(0))), Gecko.GeckoWebBrowser).Url).ToString
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TextBox1.Text = "about:blank"
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Form1.StartMenuPanel.Hide()
        Reset_Advanced_Settings.Show()
        Me.Hide()
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim stream As New IO.StreamWriter(Application.StartupPath & "\User\homepage.txt", False)
        stream.Write("")
        stream.Close()
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\User\homepage.txt", "http://www.start.me/p/Vvj7qE/airfox-home", True)
        TextBox1.Text = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\User\homepage.txt")
        Dim stream1 As New IO.StreamWriter(Application.StartupPath & "\User\cache.txt", False)
        stream1.Write("")
        stream1.Close()
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\User\cache.txt", "1", True)
        Dim stream2 As New IO.StreamWriter(Application.StartupPath & "\User\first_use.txt", False)
        stream2.Write("")
        stream2.Close()
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\User\first_use.txt", "1", True)
        Reset_All_Settings.Show()
        Form1.StartMenuPanel.Hide()
        Me.Hide()
    End Sub
End Class