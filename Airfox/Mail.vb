Imports System.Net.Mail
Public Class Mail
    Dim AppPath As String = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim a() As String = System.IO.File.ReadAllLines(AppPath & "\User\accounts.txt")
        Try
            Dim i As Integer = 0
            Do Until i = -1
                Dim b() As String = Split(a(i), "-")
                ListBox1.Items.Add(b(0) & "-" & b(1) & "-" & b(2))
                ListBox2.Items.Add(b(3))
                i = i + 1
            Loop
        Catch ex As Exception

        End Try
        Try
            Dim c() As String = System.IO.File.ReadAllLines(AppPath & "\friends.txt")
            Dim z As Integer = 0
            Do Until z = -1
                ListBox3.Items.Add(c(z))
                z = z + 1
            Loop
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            Dim a() As String = Split(ListBox1.Items(ListBox1.SelectedIndex), "-")
            ComboBox1.Text = a(0)
            TextBox1.Text = a(1)
            TextBox3.Text = a(2)
            TextBox2.Text = ListBox2.Items(ListBox1.SelectedIndex)

        Catch ex As Exception
            MsgBox("Please Select A Valid User Account", MsgBoxStyle.Exclamation, "ERROR")
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        ListBox3.Items.Add(TextBox8.Text)
        Try
            Dim text As String = ""
            Dim i As Integer = 0
            Do Until i = ListBox3.Items.Count()
                text = ListBox3.Items(i) & vbCrLf & text
                i = i + 1
            Loop
            IO.File.WriteAllText(AppPath & "\User\friends.txt", text)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ListBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListBox3.SelectedIndexChanged
        TextBox4.Text = ListBox3.Items(ListBox3.SelectedIndex)
    End Sub
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Try
            Dim line As String = ComboBox1.Text & "-" & TextBox1.Text & "-" & TextBox3.Text & TextBox2.Text & vbCrLf
            Dim text As String = ""
            ListBox1.Items.Add(ComboBox1.Text & "-" & TextBox1.Text & "-" & TextBox3.Text)
            ListBox2.Items.Add(TextBox2.Text)
            Dim i As Integer = 0
            Do Until i = ListBox1.Items.Count()
                text = ListBox1.Items(i) & "-" & ListBox2.Items(i) & vbCrLf & text
                i = i + 1
            Loop

            IO.File.WriteAllText(AppPath & "\accounts.txt", text)
        Catch ex As Exception
            MsgBox("Could not add Email Info", MsgBoxStyle.Information, "ERROR")
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        checkdetails()
        If ComboBox1.Text = "Gmail" Then
            Try
                Dim mail As New MailMessage
                mail.Subject = TextBox5.Text
                mail.Body = TextBox6.Text
                mail.To.Add(TextBox4.Text)
                mail.From = New MailAddress(TextBox3.Text)

                Dim SMTP As New SmtpClient("smtp.gmail.com")
                SMTP.EnableSsl = True
                SMTP.Credentials = New System.Net.NetworkCredential(TextBox1.Text, TextBox2.Text)
                SMTP.Port = "587"
                SMTP.Send(mail)
                MsgBox("Sent Message To : " & TextBox4.Text, MsgBoxStyle.Information, "Sent!")
            Catch ex As Exception
                MsgBox("Failed To Send Message", MsgBoxStyle.Exclamation, "ERROR")
            End Try
        End If


        If ComboBox1.Text = "Outlook.com" Then
            Try
                Dim mail As New MailMessage
                mail.Subject = TextBox5.Text
                mail.Body = TextBox6.Text
                mail.To.Add(TextBox4.Text)
                mail.From = New MailAddress(TextBox3.Text)

                Dim SMTP As New SmtpClient("smtp.live.com")
                SMTP.EnableSsl = True
                SMTP.Credentials = New System.Net.NetworkCredential(TextBox1.Text, TextBox2.Text)
                SMTP.Port = "587"
                SMTP.Send(mail)
                MsgBox("Sent Message To : " & TextBox4.Text, MsgBoxStyle.Information, "Sent!")
            Catch ex As Exception
                MsgBox("Failed To Send Message", MsgBoxStyle.Exclamation, "ERROR")
            End Try
        End If

        If ComboBox1.Text = "Yahoo" Then
            Try
                Dim mail As New MailMessage
                mail.Subject = TextBox5.Text
                mail.Body = TextBox6.Text
                mail.To.Add(TextBox4.Text)
                mail.From = New MailAddress(TextBox3.Text)

                Dim SMTP As New SmtpClient("smtp.mail.yahoo.com")
                SMTP.EnableSsl = True
                SMTP.Credentials = New System.Net.NetworkCredential(TextBox1.Text, TextBox2.Text)
                SMTP.Port = "587"
                SMTP.Send(mail)
                MsgBox("Sent Message To : " & TextBox4.Text, MsgBoxStyle.Information, "Sent")
            Catch ex As Exception
                MsgBox("Failed To Send Message", MsgBoxStyle.Exclamation, "Error")
            End Try
        End If

    End Sub
    Public Function checkdetails()
        Dim fail As String = False
        Dim errmsg As String = ""
        'checks email provider
        If ComboBox1.Text = "Gmail" Or ComboBox1.Text = "Yahoo" Or ComboBox1.Text = "Outlook.com" Then
        Else
            errmsg = "Select A Valid Email Service" & vbCrLf & errmsg
            fail = True
        End If
        'end check of provider

        'check Login Details
        If TextBox1.Text = "" Then
            errmsg = "Enter A Valid Email Account" & vbCrLf & errmsg
            fail = True
        End If
        If TextBox2.Text = "" Then
            errmsg = "Enter A Valid Email Account Password" & vbCrLf & errmsg
            fail = True
        End If
        'end check of login details

        'Check Email Stuff
        If TextBox3.Text = "" Then
            errmsg = "Enter A From Email Address" & vbCrLf & errmsg
            fail = True
        End If
        If TextBox4.Text = "" Then
            errmsg = "Enter A To Email Address" & vbCrLf & errmsg
            fail = True
        End If
        If TextBox5.Text = "" Then
            errmsg = "Enter A Subject" & vbCrLf & errmsg
            fail = True
        End If
        If TextBox6.Text = "" Then
            errmsg = "Enter A Message" & vbCrLf & errmsg
            fail = True
        End If
        'End Check of Email Stuff
        If fail = True Then
            MsgBox("Failed To Find Details" & vbCrLf & "Error :" & vbCrLf & errmsg, MsgBoxStyle.Critical, "ERROR")
        End If
    End Function
    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Form1.StartMenuPanel.Hide()
        Me.Hide()
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim stream As New IO.StreamWriter(Application.StartupPath & "\User\friends.txt", False)
        stream.WriteLine("")
        stream.Close()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim stream As New IO.StreamWriter(Application.StartupPath & "\User\accounts.txt", False)
        stream.WriteLine("")
        stream.Close()
    End Sub
End Class