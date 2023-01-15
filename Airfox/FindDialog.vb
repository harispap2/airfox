Imports System.Windows.Forms
Public Class FindDialog
    Dim target_pos As Integer
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        HTML_Editor.doc.Text = fp.Text
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FindText(1)
    End Sub
    Private Sub FindText(ByVal start_pos As Integer)
        Dim pos As Integer
        Dim target As String
        target = fp.Text
        If CheckBox1.Checked = True Then
            pos = InStr(start_pos, target, ttf.Text)
            If pos > 0 Then
                target_pos = pos
                fp.SelectionStart = target_pos - 1
                fp.SelectionLength = Len(target) - (Len(target) - Len(ttf.Text))
            Else
                MsgBox("Text Not Found")
            End If
        Else
            pos = InStr(start_pos, target.ToLower, ttf.Text.ToLower)
            If pos > 0 Then
                target_pos = pos
                fp.SelectionStart = target_pos - 1
                fp.SelectionLength = Len(target) - (Len(target) - Len(ttf.Text))

            Else
                MsgBox("Text Not Found")
            End If
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FindText(target_pos + 1)
    End Sub

    Private Sub FindDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub
End Class
