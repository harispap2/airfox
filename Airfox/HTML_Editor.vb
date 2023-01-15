Public Class HTML_Editor
    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        If doc.Modified = True Then
            Dim x As Integer = MsgBox("Do you want to save the modified document?", MsgBoxStyle.YesNo)
            If x = vbYes Then
                SaveToolStripMenuItem.PerformClick()
            Else
                Me.Text = "Untitled - Airfox HTML Editor"
                doc.Clear()
            End If
            Me.Text = "Untitled - Airfox HTML Editor"
            doc.Clear()
        End If
    End Sub
    Dim z As New Crypto.Algorithm
    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim y As New OpenFileDialog
        y.Multiselect = False
        If y.ShowDialog = Windows.Forms.DialogResult.Cancel Then
        Else
            doc.Text = My.Computer.FileSystem.ReadAllText(y.FileName)
            WebBrowser1.Navigate(y.FileName)
            Dim x As String
            Try
                z = Crypto.Algorithm.Rijndael
                x = My.Computer.FileSystem.ReadAllText(y.FileName)
                Crypto.EncryptionAlgorithm = z
                Crypto.Key = "Airfox HTML Editor"
                Crypto.Encoding = Crypto.Encoding = Crypto.EncodingType.HEX
                Crypto.Content = x
                If Crypto.DecryptString Then
                    doc.Text = Crypto.Content
                Else
                    '     MsgBox(Crypto.CryptoException.ToString())
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Me.Text = Replace(Me.Text, "Untitled", y.FileName)
        End If
    End Sub
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Dim sfd As New SaveFileDialog() ' this creates an instance of the SaveFileDialog called "sfd"
        sfd.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*"
        sfd.FilterIndex = 1
        sfd.RestoreDirectory = True
        If sfd.ShowDialog() = DialogResult.OK Then
            Dim FileName As String = sfd.FileName ' retrieve the full path to the file selected by the user
            Dim sw As New System.IO.StreamWriter(FileName, False) ' create a StreamWriter with the FileName selected by the User
            sw.WriteLine(doc.Text) ' Write the contents of TextBox to the file
            sw.Close() ' close the file
        End If
    End Sub
    Private Sub PageSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageSetupToolStripMenuItem.Click
        Dim x As New PageSetupDialog
        x.PageSettings = New Printing.PageSettings
        x.PrinterSettings = New System.Drawing.Printing.PrinterSettings
        x.ShowNetwork = False
        Dim listbox1 As New ListBox
        Dim result As DialogResult = x.ShowDialog
        If (result = DialogResult.OK) Then
            Dim results() As Object = New Object() _
                {x.PageSettings.Margins, _
                 x.PageSettings.PaperSize, _
                 x.PageSettings.Landscape, _
                 x.PrinterSettings.PrinterName, _
                 x.PrinterSettings.PrintRange}
            listbox1.Items.AddRange(results)
        End If
    End Sub
    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Dim x As New PrintDialog
        x.Document = New Printing.PrintDocument
        x.ShowDialog()
    End Sub
    Private WithEvents docToPrint As New Printing.PrintDocument
    Private Sub document_PrintPage(ByVal sender As Object, _
       ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
           Handles docToPrint.PrintPage
        Dim x As New FontDialog
        x.ShowDialog()
        Dim text As String = doc.Text
        Dim printFont As New System.Drawing.Font(x.Font, x.Font.Style)
        e.Graphics.DrawString(text, printFont, _
            System.Drawing.Brushes.Black, 10, 10)
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Hide()
    End Sub
    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        doc.Undo()
    End Sub
    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(doc.SelectedText)
        doc.SelectedText = ""
    End Sub
    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(doc.SelectedText)
    End Sub
    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        doc.SelectedText = My.Computer.Clipboard.GetText
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        doc.SelectedText = ""
    End Sub
    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        doc.SelectAll()
    End Sub
    Private Sub TimeDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeDateToolStripMenuItem.Click
        doc.SelectedText = Date.Now
    End Sub
    Private Sub WordWrapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordWrapToolStripMenuItem.Click
        doc.WordWrap = True
    End Sub
    Private Sub FontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripMenuItem.Click
        Dim x As New FontDialog
        x.ShowDialog()
        doc.Font = x.Font
    End Sub
    Private Sub ReplaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceToolStripMenuItem.Click
        doc.Text = Replace(doc.Text, InputBox("Text to find"), InputBox("Text to replace"))
    End Sub
    Private Sub doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles doc.TextChanged
        FindDialog.fp.Text = doc.Text
        cc.Text = Len(doc.Text)
        lc.Text = doc.Lines.Length
    End Sub
    Private Sub RichTegxtBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles doc.TextChanged
        WebBrowser1.DocumentText = doc.Text
    End Sub
    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'doc.Text = WebBrowser1.Document.Body.InnerHtml
    End Sub
    Private target_pos As Integer
    Dim target As String
    Private Sub FindText(ByVal start_pos As Integer)
        Dim pos As Integer
        pos = InStr(start_pos, doc.Text.ToLower, tf.Text.ToLower)
        If pos > 0 Then
            target_pos = pos
            doc.SelectionStart = target_pos - 1
            doc.SelectionLength = Len(target) - (Len(target) - Len(target))
        Else
            MsgBox("Text Not Found")
            target = ""
        End If
    End Sub
    Private Sub FindNextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindNextToolStripMenuItem.Click
        FindText(target_pos + 1)
    End Sub
    Dim x As String
    Private Sub ReplaceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceToolStripMenuItem1.Click
        target = InputBox("Enter Word to find")
        FindText(1)
        If doc.SelectedText <> target Then
        Else
            x = InputBox(String.Format("Selected text is : {0}. Enter text to replace", target))
            doc.SelectedText = x
        End If
    End Sub
    Private Sub ReplaceNextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceNextToolStripMenuItem.Click
        FindText(target_pos + 1)
        If doc.SelectedText = "" Then
        Else
            doc.SelectedText = x
        End If
    End Sub
    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveToolStripMenuItem.PerformClick()
    End Sub
    Private Sub FindToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem1.Click
        FindText(1)
        target = tf.Text
    End Sub
    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusBarToolStripMenuItem.Click
        StatusStrip1.Visible = Not (StatusStrip1.Visible)
    End Sub
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WebBrowser1.ScriptErrorsSuppressed = True
    End Sub
End Class
