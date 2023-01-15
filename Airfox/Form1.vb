Imports Gecko
Imports System.Drawing.Text
Public Class Form1
    'Airfox Browser - www.airfox.sourceforge.net
    'By Charis Papadakis and Mike Gounelas.
    Dim int As Integer = 1
    Dim geckoFX As Gecko.GeckoWebBrowser = New Gecko.GeckoWebBrowser()
    Dim xrPath As String = System.Reflection.Assembly.GetExecutingAssembly.Location
    Private Sub Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click 'Menu Button 
        If StartMenuPanel.Visible = False Then
            StartMenuPanel.Show()
        Else
            StartMenuPanel.Hide()
        End If
    End Sub
    Private Sub About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click 'About Button
        Form2.Show()
        StartMenuPanel.Hide()
    End Sub
    Private Sub AddTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click 'Add Tab Button
        Try
            Dim tab As New TabPage
            Dim brws As New Gecko.GeckoWebBrowser
            brws.Dock = DockStyle.Fill
            tab.Text = "New Tab"
            tab.Controls.Add(brws)
            Me.TabControl1.TabPages.Add(tab)
            Me.TabControl1.SelectedTab = tab
            brws.Navigate("")
        Catch ex As Exception
        End Try
        StartMenuPanel.Hide()
    End Sub
    Private Sub RemoveTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click 'Remove Tab Button
        If Not TabControl1.TabPages.Count = 1 Then
            TabControl1.TabPages.Remove(TabControl1.SelectedTab)
        End If
        StartMenuPanel.Hide()
    End Sub
    Private Sub Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click 'Go Back Button
        If CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).CanGoBack = True Then
            CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).GoBack()
        Else
        End If
        StartMenuPanel.Hide()
    End Sub
    Private Sub Forward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click 'Go Forward Button
        If CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).CanGoForward = True Then
            CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).GoForward()
        Else
        End If
        StartMenuPanel.Hide()
    End Sub
    Private Sub Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click 'Refresh Button
        CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Reload()
        StartMenuPanel.Hide()
    End Sub
    Private Sub Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click 'Stop Button
        CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Stop()
        StartMenuPanel.Hide()
    End Sub
    Private Sub NewWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click 'New Window Button
        Dim NwWindow As New Form1
        NwWindow.Show()
        StartMenuPanel.Hide()
    End Sub
    Private Sub Forward_Back_Enable_Disable(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick 'Back/forward enable/disable
        If CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).CanGoBack = True Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
        If CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).CanGoForward = True Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If
        If CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).IsBusy = True Then
            Button4.Enabled = True
        Else
            Button4.Enabled = False
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim tab As New TabPage
            Dim brws As New Gecko.GeckoWebBrowser
            brws.Dock = DockStyle.Fill
            tab.Text = "New Tab"
            tab.Controls.Add(brws)
            Me.TabControl1.TabPages.Add(tab)
            Me.TabControl1.SelectedTab = tab
            brws.Navigate("")
        Catch ex As Exception
        End Try
        CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Navigate(My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\User\homepage.txt"))
        xrPath = xrPath.Substring(0, xrPath.LastIndexOf("\") + 1) & "xulrunner"
        Gecko.Xpcom.Initialize(xrPath)
        Gecko.GeckoPreferences.Default("extensions.blocklist.enabled") = False
        Dim Web As New System.Net.WebClient
        Dim News As String = Web.DownloadString("http://airfox.sourceforge.net/af_web/afv.txt")
        If (My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\User\cache.txt")) = "1" Then
            Gecko.GeckoPreferences.Default("browser.cache.disk.enable") = True
        Else
            Gecko.GeckoPreferences.Default("browser.cache.disk.enable") = False
        End If
        If (My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\User\first_use.txt")) = "1" Then
            welcome.Show()
            Form4.Show()
        Else
            'Does nothing, becuase the browser starts.
        End If
        If Label2.Text = News Then
            'Does nothing, because the browser is up-to-date.
        Else
            updatenotify.show()
        End If
        Dim stream2 As New System.IO.StreamWriter(Application.StartupPath & "\User\first_use.txt", False)
        stream2.WriteLine("")
        stream2.Close()
        My.Computer.FileSystem.WriteAllText(Application.StartupPath & "\User\first_use.txt", "0", True)
    End Sub
    Private Sub Bookmarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click 'Bookmarks Button
        Form3.Show()
        StartMenuPanel.Hide()
    End Sub
    Private Sub Addressbar_Enter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown  'Goes to an address when ENTER key is pressed
        If e.KeyData = Keys.Enter Then
            If TextBox1.Text.Contains(".") Then
                CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Navigate(TextBox1.Text)
                e.SuppressKeyPress = True
            End If
        End If
    End Sub
    Private Sub NewTab_Ctrl_T(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'CTRL+T new tab
        If e.KeyCode = Keys.T AndAlso e.Control = True Then
            Try
                Dim tab As New TabPage
                Dim brws As New Gecko.GeckoWebBrowser
                brws.Dock = DockStyle.Fill
                tab.Text = "New Tab"
                tab.Controls.Add(brws)
                Me.TabControl1.TabPages.Add(tab)
                Me.TabControl1.SelectedTab = tab
                brws.Navigate("")
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub CloseTab_Ctrl_F4(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'CTRL+F4 close tab
        If e.KeyCode = Keys.F4 AndAlso e.Control = True Then
            TabControl1.Controls.Remove(TabControl1.SelectedTab)
        End If
    End Sub
    Private Sub NewWindow_Ctrl_N(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'CTRL+N new window
        If e.KeyCode = Keys.N AndAlso e.Control = True Then
            Dim NwWindow As New Form1
            NwWindow.Show()
            StartMenuPanel.Hide()
        End If
    End Sub
    Const gsearch As String = "http://www.google.com/search?q="
    Private Sub GoogleSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click 'Search web button
        CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Navigate("http://www.google.com/search?q=" + TextBox2.Text)
        StartMenuPanel.Hide()
    End Sub
    Private Sub Hide_addressbar_text(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseClick 'Hide address bar help text
        TextBox1.Clear()
        StartMenuPanel.Hide()
    End Sub
    Private Sub Hide_searchbar_text(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox2.MouseClick 'Hide search bar help text
        TextBox2.Clear()
        StartMenuPanel.Hide()
    End Sub
    Private Sub Searchbar_enter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown  'Searches websites using Google when the ENTER key is pressed
        If e.KeyData = Keys.Enter Then
            CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Navigate("http://www.google.com/search?q=" + TextBox2.Text)
            e.SuppressKeyPress = True
        End If
        StartMenuPanel.Hide()
    End Sub
    Private Sub Reload_F5(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'F5 page reload
        If e.KeyCode = Keys.F5 = True Then
            CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Refresh()
        End If
        StartMenuPanel.Hide()
    End Sub
    Private Sub AboutWindow_Ctrl_L(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'CTRL+L About Window
        If e.KeyCode = Keys.L AndAlso e.Control = True Then
            Form2.Show()
            StartMenuPanel.Hide()
        End If
    End Sub
    Private Sub Bookmarks_Ctrl_B(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'CTRL+B Bookmarks Window
        If e.KeyCode = Keys.B AndAlso e.Control = True Then
            Form3.Show()
            StartMenuPanel.Hide()
        End If
    End Sub
    Private Sub Help_F1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'F1 help
        If e.KeyCode = Keys.F1 = True Then
            Form5.Show()
            StartMenuPanel.Hide()
        End If
    End Sub
    Private Sub Help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click 'Help Button from menu
        Form5.Show()
        StartMenuPanel.Hide()
    End Sub
    Private Sub Hidemenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Click 'Hides the menu when the users click on the browser
        StartMenuPanel.Hide()
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Clear_Browsing_Data.Show()
        StartMenuPanel.Hide()
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        ' If e.KeyCode = Keys.Back = True Then
        Timer2.Stop()
        ' End If
    End Sub
    Private Sub Timer_startup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.MouseLeave 'Starts the timer
        Timer2.Start()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click 'Homepage
        CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Navigate(My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\user\homepage.txt"))
    End Sub
    Private Sub UrlBar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick 'Shows the URL in the address bar
        TextBox1.Text = (CType(((TabControl1.SelectedTab.Controls.Item(0))), Gecko.GeckoWebBrowser).Url).ToString
    End Sub
    Private Sub Button13_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Downloader.Show()
        StartMenuPanel.Hide()
    End Sub
    Private Sub Downloads_Ctrl_J(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'CTRL+J Downloads
        If e.KeyCode = Keys.J AndAlso e.Control = True Then
            Downloader.Show()
            StartMenuPanel.Hide()
        End If
    End Sub
    Private Sub GoToUrlButton(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Navigate(TextBox1.Text)
        StartMenuPanel.Hide()
    End Sub
    Private Sub Options_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Settings.Show()
        StartMenuPanel.Hide()
    End Sub
    Private Sub Options_Ctrl_M(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'CTRL+M Settings
        If e.KeyCode = Keys.M AndAlso e.Control = True Then
            Settings.Show()
            StartMenuPanel.Hide()
        End If
    End Sub
    Private Sub Reload_Ctrl_R(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'CTRL+J Downloads
        If e.KeyCode = Keys.R AndAlso e.Control = True Then
            CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).Refresh()
            StartMenuPanel.Hide()
        End If
    End Sub
    Private Sub Menu_Ctrl_I(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'CTRL+T new tab
        If e.KeyCode = Keys.I AndAlso e.Control = True Then
            StartMenuPanel.Show()
        End If
    End Sub
    Private Sub File_Downloads(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged 'File Downloads
        If InStr(TextBox1.Text, ".pdf") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".doc") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".docx") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".xls") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".xlsx") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".ppt") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".pptx") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".accdb") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".exe") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".zip") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".rar") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".7z") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".tar") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".iso") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".mp3") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".mp4") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".wav") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".wmv") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".msi") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".dll") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".mkv") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".flac") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".torrent") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".vdi") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".bat") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".txt") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".psd") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".jpg") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".jpeg") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".png") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".bmp") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".avi") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
        If InStr(TextBox1.Text, ".flv") Then
            Downloader.Show()
            Downloader.txtFileName.Text = Me.TextBox1.Text.ToString
            Downloader.Label8.Show()
        End If
    End Sub
    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        TabControl1.SelectedTab.Text = CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).DocumentTitle
        If TextBox2.Text = "" Then
            TextBox2.Text = "Search the web using Google"
        End If
    End Sub
    Private Sub Esc_Close_Menu(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'Esc Closes Menu
        If e.KeyCode = Keys.Escape = True Then
            StartMenuPanel.Hide()
        End If
    End Sub
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Mail.Show()
        StartMenuPanel.Hide()
    End Sub
    Private Sub Email_Client_Ctrl_E(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'CTRL+B Bookmarks Window
        If e.KeyCode = Keys.E AndAlso e.Control = True Then
            Mail.Show()
            StartMenuPanel.Hide()
        End If
    End Sub
    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        HTML_Editor.Show()
        StartMenuPanel.Hide()
    End Sub
    Private Sub HTLM_Editor_Ctrl_H(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'CTRL+B Bookmarks Window
        If e.KeyCode = Keys.H AndAlso e.Control = True Then
            HTML_Editor.Show()
            StartMenuPanel.Hide()
        End If
    End Sub
    Private Sub News_Feed_Ctrl_Q(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'CTRL+B Bookmarks Window
        If e.KeyCode = Keys.Q AndAlso e.Control = True Then
            newsfeed.Show()
            StartMenuPanel.Hide()
        End If
    End Sub
    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        If (CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).IsBusy) Then
            TabControl1.SelectedTab.Text = "Loading... " & CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).DocumentTitle
        End If
        Me.Text = "Airfox - " & CType(TabControl1.SelectedTab.Controls.Item(0), GeckoWebBrowser).DocumentTitle
        If Me.Text = "Airfox - " Then
            Me.Text = "Airfox"
        End If
    End Sub
End Class