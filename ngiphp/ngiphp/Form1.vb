Public Class Form1


    Dim n As Process = Nothing

    Dim p As Process = Nothing

    Dim m As Process = Nothing

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
            Process.Start("taskkill", "/im nginx.exe /f")
            n = Nothing
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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
            Label2.Text = "PHP 5: "
            Process.Start("taskkill.exe", "/im php-cgi.exe /f")
            p.Kill()
            p = Nothing
        End If
    End Sub




    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If IsNothing(n) = False Then Process.Start("taskkill.exe", "/im nginx.exe /f")
        If IsNothing(p) = False Then Process.Start("taskkill.exe", "/im php-cgi.exe /f")
        If IsNothing(m) = False Then Process.Start("taskkill.exe", "/im mysqld.exe /f")
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then
            MessageBox.Show("程序已经运行了")
            End
        End If

        Label1.Text = "Nginx: "
        Label2.Text = "PHP 5: "
        Label3.Text = "MySQL: "
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

        TextBox1.Text = d
        TextBox2.Text = p
        TextBox3.Text = m

        If (p.Contains("php52") = True) Then RadioButton1.Select()
        If (p.Contains("php53") = True) Then RadioButton2.Select()
        If (p.Contains("php54") = True) Then RadioButton3.Select()
        If (p.Contains("php55") = True) Then RadioButton4.Select()
        If (p.Contains("php56") = True) Then RadioButton5.Select()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If IsNothing(m) = True Then

            m = New Process
            m.StartInfo.FileName = "mysqld.exe"
            m.StartInfo.WorkingDirectory = TextBox3.Text
            m.StartInfo.CreateNoWindow = True
            m.StartInfo.Arguments = "--defaults-file=" + TextBox3.Text + "my.ini --standalone"
            m.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            m.Start()

            Label3.Text = Label3.Text + m.Id.ToString
            Label3.ForeColor = Color.Green
        Else
            Label3.ForeColor = Color.Red
            Label3.Text = "MySQL: "
            Process.Start("taskkill.exe", "/im php-cgi.exe /f")
            m.Kill()
            m = Nothing
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
    End Sub
End Class