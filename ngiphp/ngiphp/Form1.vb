Public Class Form1
    Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" (ByVal hWnd1 As Long, ByVal hWnd2 As Long, ByVal lpsz1 As String, ByVal lpsz2 As String) As Long
    Declare Function ShowWindow Lib "user32" Alias "ShowWindow" (ByVal hWnd1 As Long, ByVal nCmdShow As Long) As Long
    Declare Auto Function FindWindow Lib "user32" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer

    Dim n As Process = Nothing
    Dim p As Process = Nothing
    Dim m As Process = Nothing
    Dim c As Process = Nothing
    Dim a As Process = Nothing
    Dim h As Process = Nothing

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNothing(n) = True Then
            n = New Process
            n.StartInfo.FileName = "nginx.exe"
            n.StartInfo.WorkingDirectory = TextBox1.Text
            n.StartInfo.CreateNoWindow = True
            n.Start()
            'n.WaitForExit()
            Label1.Text = Label1.Text + n.Id.ToString
            Label1.ForeColor = Color.Green


        Else
            Label1.ForeColor = Color.Red
            Label1.Text = "Nginx: "
            Process.Start("taskkill.exe", "/im nginx.exe /f")
            n = Nothing
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If IsNothing(p) = True Then

                p = New Process
                p.StartInfo.FileName = "php-cgi.exe"
                p.StartInfo.WorkingDirectory = TextBox2.Text
                p.StartInfo.CreateNoWindow = True
                p.StartInfo.Arguments = "-b 127.0.0.1:9000"
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                p.Start()

                Label2.Text = Label2.Text + p.Id.ToString
                Label2.ForeColor = Color.Green
            Else

                Label2.ForeColor = Color.Red
                Label2.Text = "PHP: "
                Process.Start("taskkill.exe", "/pid " & p.Id & " /f")
                'p.Kill()
                p = Nothing
            End If
        Catch ex As ArgumentException
            p = Nothing
        Finally

        End Try
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If IsNothing(m) = True Then

            m = New Process
            m.StartInfo.FileName = "mysqld.exe"
            m.StartInfo.WorkingDirectory = TextBox3.Text
            m.StartInfo.CreateNoWindow = True
            m.StartInfo.Arguments = "--defaults-file=" + TextBox3.Text + "my.ini  --standalone --console" '--standalone
            m.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            m.Start()

            Label3.Text = Label3.Text + m.Id.ToString
            Label3.ForeColor = Color.Green
        Else
            Label3.ForeColor = Color.Red
            Label3.Text = "MySQL: "
            Process.Start("taskkill.exe", "/pid " & m.Id & " /f")
            'm.Kill()
            m = Nothing
        End If
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If IsNothing(c) = True Then
            c = New Process
            c.StartInfo.FileName = "memcached.exe"
            c.StartInfo.WorkingDirectory = TextBox4.Text
            'n.StartInfo.CreateNoWindow = True
            c.StartInfo.Arguments = ""
            c.Start()
            'n.WaitForExit()
            Label4.Text = Label4.Text + c.Id.ToString
            Label4.ForeColor = Color.Green
            Threading.Thread.Sleep(1000)
            Dim hWnd
            hWnd = FindWindow(vbNullString, TextBox4.Text + "memcached.exe")
            ShowWindow(hWnd, 0)
        Else
            Label4.ForeColor = Color.Red
            Label4.Text = "Memcached: "
            Process.Start("taskkill.exe", "/pid " & c.Id & " /f")
            c = Nothing
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If IsNothing(a) = True Then
            a = New Process
            a.StartInfo.FileName = "caddy.exe"
            a.StartInfo.WorkingDirectory = TextBox5.Text
            a.StartInfo.CreateNoWindow = True
            a.StartInfo.Arguments = ""
            a.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            a.Start()
            'n.WaitForExit()
            Label5.Text = Label5.Text + a.Id.ToString
            Label5.ForeColor = Color.Green

        Else
            Label5.ForeColor = Color.Red
            Label5.Text = "Caddy: "
            Process.Start("taskkill.exe", "/pid " & a.Id & " /f")
            a = Nothing
        End If
    End Sub



    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            If IsNothing(h) = True Then

                Dim h1 = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath() + "\h1.txt")
                Dim h2 = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath() + "\h2.txt")

                h = New Process
                h.StartInfo.FileName = "php.exe"
                h.StartInfo.WorkingDirectory = TextBox6.Text
                h.StartInfo.CreateNoWindow = True
                h.StartInfo.Arguments = "-S 127.0.0.1:" & h1 & " -t " & h2
                h.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                h.Start()

                Label6.Text = Label6.Text + h.Id.ToString
                Label6.ForeColor = Color.Green
            Else

                Label6.ForeColor = Color.Red
                Label6.Text = "PHP Server: "
                Process.Start("taskkill.exe", "/pid " & h.Id & " /f")
                'h.Kill()
                h = Nothing
            End If
        Catch ex As ArgumentException
            h = Nothing
        Finally

        End Try
    End Sub


    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        If IsNothing(n) = False Then Process.Start("taskkill.exe", "/im nginx.exe /f")
        If IsNothing(p) = False Then Process.Start("taskkill.exe", "/pid " & p.Id & " /f")
        If IsNothing(m) = False Then Process.Start("taskkill.exe", "/pid " & m.Id & " /f")
        If IsNothing(c) = False Then Process.Start("taskkill.exe", "/pid " & c.Id & " /f")
        If IsNothing(a) = False Then Process.Start("taskkill.exe", "/pid " & a.Id & " /f")
        If IsNothing(h) = False Then Process.Start("taskkill.exe", "/pid " & h.Id & " /f")

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then
            MessageBox.Show("程序已经运行了")
            End
        End If
        Me.NotifyIcon1.Visible = True


        Label1.Text = "Nginx: "
        Label2.Text = "PHP: "
        Label3.Text = "MySQL: "
        Label4.Text = "Memcached: "
        Label5.Text = "Caddy: "
        Label6.Text = "PHP Server: "
        'Select Case My.Settings.php
        '    Case 52
        '        RadioButton1.Select()
        '    Case 53
        '        RadioButton2.Select()
        '    Case 54
        '        RadioButton3.Select()
        '    Case 55
        '        RadioButton4.Select()
        '    Case 56
        '        RadioButton5.Select()
        'End Select

        Dim d = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath() + "\d.txt")

        Dim p = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath() + "\p.txt")

        Dim m = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath() + "\m.txt")

        Dim c = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath() + "\c.txt")

        Dim a = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath() + "\a.txt")

        Dim h = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath() + "\h.txt")

        Dim s = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath() + "\s.txt")
        s = LCase(s)

        TextBox1.Text = d
        TextBox2.Text = p
        TextBox3.Text = m
        TextBox4.Text = c
        TextBox5.Text = a
        TextBox6.Text = h

        If (p.Contains("php52") = True) Then RadioButton1.Select()
        If (p.Contains("php53") = True) Then RadioButton2.Select()
        If (p.Contains("php54") = True) Then RadioButton3.Select()
        If (p.Contains("php55") = True) Then RadioButton4.Select()
        If (p.Contains("php56") = True) Then RadioButton5.Select()
        If (p.Contains("php70") = True) Then RadioButton6.Select()

        If s = "nginx" Then
            TabControl1.SelectedTab = TabPage1
        End If
        If s = "caddy" Then
            TabControl1.SelectedTab = TabPage2
        End If
        If s = "php" Then
            TabControl1.SelectedTab = TabPage3
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        'TextBox2.Text = "d:\nginx\php52\"
        'My.Settings.php = 52
        'My.Settings.Save()

        Dim p = My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath).FullName
        p = p + "\php" + "52" + "\"
        TextBox2.Text = p
        My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath() + "\p.txt", p, False)
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        'TextBox2.Text = "d:\nginx\php53\"
        'My.Settings.php = 53
        'My.Settings.Save()
        Dim p = My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath).FullName
        p = p + "\php" + "53" + "\"
        TextBox2.Text = p
        My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath() + "\p.txt", p, False)
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        'TextBox2.Text = "d:\nginx\php54\"
        'My.Settings.php = 54
        'My.Settings.Save()
        Dim p = My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath).FullName
        p = p + "\php" + "54" + "\"
        TextBox2.Text = p
        My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath() + "\p.txt", p, False)
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        'TextBox2.Text = "d:\nginx\php55\"
        'My.Settings.php = 55
        'My.Settings.Save()
        Dim p = My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath).FullName
        p = p + "\php" + "55" + "\"
        TextBox2.Text = p
        My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath() + "\p.txt", p, False)
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        'TextBox2.Text = "d:\nginx\php56\"
        'My.Settings.php = 56
        'My.Settings.Save()
        Dim p = My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath).FullName
        p = p + "\php" + "56" + "\"
        TextBox2.Text = p
        My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath() + "\p.txt", p, False)
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        'TextBox2.Text = "d:\nginx\php54\"
        'My.Settings.php = 70
        'My.Settings.Save()
        Dim p = My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath).FullName
        p = p + "\php" + "70" + "\"
        TextBox2.Text = p
        My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath() + "\p.txt", p, False)
    End Sub

    Private Sub 退出ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出ToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If


    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.TopMost = True
        Me.TopMost = False
    End Sub

End Class