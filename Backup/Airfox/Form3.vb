Public Class Form3
    'Airfox Browser - www.airfoxbrowser.wordpress.com
    'By Charis Papadakis and Mike Gounelas.
    Private Sub Bookmarks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each item In My.Settings.Bookmarks
            ListBox1.Items.Add(item)
        Next
        'Next Me.Visible = False
    End Sub
    Private Sub Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click 'Remove Selected Bookmark Button
        My.Settings.Bookmarks.Remove(ListBox1.SelectedItem)
        ListBox1.Items.Remove(ListBox1.SelectedItem)
        Form1.ComboBox1.Items.Remove(ListBox1.SelectedItem)
    End Sub
    Private Sub Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click 'Add Bookmark Button
        My.Settings.Bookmarks.Add(Form1.GeckoWebBrowser1.Url.ToString)
        Form1.ComboBox1.Items.Add(Form1.GeckoWebBrowser1.Url.ToString)
        Me.ListBox1.Items.Add(Form1.GeckoWebBrowser1.Url.ToString)
    End Sub
    Private Sub ListBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick 'Navigates to the bookmark when double Clicked
        CType(Form1.TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Navigate(Me.ListBox1.SelectedItem.ToString)
    End Sub
End Class
