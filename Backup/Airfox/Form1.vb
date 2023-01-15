Public Class Form1
    'Airfox Browser - www.airfoxbrowser.wordpress.com
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
        Dim Browser As New Gecko.GeckoWebBrowser
        TabControl1.TabPages.Add("New Tab")
        TabControl1.SelectTab(int)
        Browser.Name = "Airfox"
        Browser.Dock = DockStyle.Fill
        TabControl1.SelectedTab.Controls.Add(Browser)
        AddHandler Browser.DocumentCompleted, AddressOf HistoryPage
        StartMenuPanel.Hide()
    End Sub
    Private Sub HistoryPage(ByVal sender As Object, ByVal e As Windows.Forms.WebBrowserDocumentCompletedEventArgs) 'When a page has finished loading, it is being added to history.
        TextBox1.Text = CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Url.ToString
        TabControl1.SelectedTab.Text = CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).DocumentTitle
        Try
            History.ListBox1.Items.Add(TimeOfDay.TimeOfDay.ToString & "   " & CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).DocumentTitle & " - " & CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Document.Url.ToString)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RemoveTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click 'Remove Tab Button
        If Not TabControl1.TabPages.Count = 1 Then
            TabControl1.TabPages.Remove(TabControl1.SelectedTab)
        End If
        StartMenuPanel.Hide()
    End Sub
    Private Sub Homepage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)  'Show Homepage
        CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Navigate("www.duckduckgo.com")
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
        CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Refresh()
        StartMenuPanel.Hide()
    End Sub
    Private Sub Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click 'Stop Button
        If CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).IsBusy = True Then
            CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Stop()
        Else
        End If
        StartMenuPanel.Hide()
    End Sub
    Private Sub NewWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click 'New Window Button
        Dim NwWindow As New Form1
        NwWindow.Show()
        StartMenuPanel.Hide()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick 'Back/forward gray/black
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
        xrPath = xrPath.Substring(0, xrPath.LastIndexOf("\") + 1) & "xulrunner"
        Gecko.Xpcom.Initialize(xrPath)
        Gecko.GeckoPreferences.Default("extensions.blocklist.enabled") = False
        GeckoWebBrowser1.Navigate("www.duckduckgo.com")
    End Sub
    Private Sub Bookmarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click 'Bookmarks Button
        Form3.Show()
        StartMenuPanel.Hide()
    End Sub
    Private Sub History_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)  'History Button
        History.Show()
        StartMenuPanel.Hide()
    End Sub
    Private Sub TextBox11_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown  'Searches websites when the ENTER key is pressed
        If e.KeyData = Keys.Enter Then
            If TextBox1.Text.Contains(".") Then
                CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Navigate(TextBox1.Text)
                e.SuppressKeyPress = True
                TextBox1.Clear()
            End If
        End If
    End Sub
    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'CTRL+T Function
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
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown 'CTRL+F4 Function
        If e.KeyCode = Keys.F4 AndAlso e.Control = True Then
            TabControl1.Controls.Remove(TabControl1.SelectedTab)
        End If
    End Sub
    Private Sub TextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyClass.KeyDown 'CTRL+N Function
        If e.KeyCode = Keys.N AndAlso e.Control = True Then
            Dim NwWindow As New Form1
            NwWindow.Show()
            StartMenuPanel.Hide()
        End If
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click 'Homepage button
        CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Navigate("www.duckduckgo.com")
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Const gsearch As String = "http://www.google.com/search?q="
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Navigate(("http://www.google.com/search?q=" + TextBox1.Text))
    End Sub
    Private Sub TextBox11_KeyDow11n(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyData = Keys.Enter Then
            If TextBox2.Text.Contains(".") Then
                CType(TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Navigate(("http://www.google.comie/search?q=" + TextBox1.Text))
                e.SuppressKeyPress = True
            End If
        End If
        '  GeckoWebBrowser1.Navigate("http://www.google.com/search?q=" + TextBox1.Text)
    End Sub
    Const ggl As String = "http://www.google.com/search?q="
End Class