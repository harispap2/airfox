Public Class History
    'Airfox Browser - www.airfoxbrowser.wordpress.com
    'By Charis Papadakis and Mike Gounelas.
    Private Sub Clear_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click 'Clear History Button
        ListBox1.Items.Clear()
    End Sub
    Private Sub Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click 'Remove Selected History Button
        ListBox1.Items.Remove(ListBox1.SelectedItem)
    End Sub
    Private Sub ListBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick 'Navigates to the bookmark when double Clicked
        CType(Form1.TabControl1.SelectedTab.Controls.Item(0), Gecko.GeckoWebBrowser).Navigate(Me.ListBox1.SelectedItem.ToString)
    End Sub
End Class