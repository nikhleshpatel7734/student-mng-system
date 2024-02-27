Public Class HOME

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GunaProgressBar1.Increment(1)
        If GunaProgressBar1.Value = 20 Then
            Me.Hide()
            Dim log = New LOGIN
            log.Show()
            Timer1.Enabled = True
        End If

    End Sub

    Private Sub HOME_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Application.Exit()

    End Sub
End Class
