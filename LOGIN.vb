Public Class LOGIN

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim us As String
        Dim pas As String
        us = user.Text
        pas = pass.Text
        If us = "admin" And pas = "pa" Then
            MsgBox("login successful......")
            STUDENT.Show()
            Me.Hide()
        ElseIf us = "" And pas = "" Then
            MsgBox("please enter username and password")
        Else
            us = " "
            pas = " "
            MsgBox("username or password incorrect")

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        user.Text = ""
        pass.Text = ""
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        HOME.Show()
        Me.Hide()

    End Sub

    Private Sub pass_TextChanged(sender As Object, e As EventArgs) Handles pass.TextChanged

    End Sub
End Class