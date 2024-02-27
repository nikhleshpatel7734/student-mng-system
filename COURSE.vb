Imports System.Data.SqlClient
Public Class COURSE
    Dim connectionstring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\documents\visual studio 2012\Projects\studemt management system\studemt management system\stmanage.mdf;Integrated Security=True;Connect Timeout=30"
    Dim connection As New SqlConnection(connectionstring)
    Sub view()
        connection.Open()
        Dim adp As New SqlDataAdapter("select * from course", connection)
        Dim ds As New DataSet
        adp.Fill(ds, "dd")
        DataGridView1.DataSource = ds.Tables("dd")
        connection.Close()



    End Sub
    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        LOGIN.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        LOGIN.Show()
        Me.Hide()

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        STUDENT.Show()
        Me.Hide()

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        FEES.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim connectionstring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\documents\visual studio 2012\Projects\studemt management system\studemt management system\stmanage.mdf;Integrated Security=True;Connect Timeout=30"
        Dim connection As New SqlConnection(connectionstring)
        Try


            connection.Open()
            Dim insertstatement As String = "insert into COURSE (COURSE_ID,COURSE_NAME,COURSE_DURATION,COURSE_FEES) VALUES (@CID,@CNA,@CDN,@CFS)"
            Dim insertcommand As New SqlCommand(insertstatement, connection)
            insertcommand.Parameters.AddWithValue("@CID", coc.Text)
            insertcommand.Parameters.AddWithValue("@CNA", cn.Text)
            insertcommand.Parameters.AddWithValue("@CDN", cd.Text)
            insertcommand.Parameters.AddWithValue("@CFS", cf.Text)

            insertcommand.ExecuteNonQuery()
            DataGridView1.Refresh()



            MsgBox("COURSE ADD SUCCESSFULLY")
            connection.Close()
            DataGridView1.Refresh()
            view()
            coc.Text = ""
            cn.Text = ""
            cd.Text = ""
            cf.Text = ""
          



        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub

    Private Sub COURSE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'StmanageDataSet2.COURSE' table. You can move, or remove it, as needed.
        Me.COURSETableAdapter1.Fill(Me.StmanageDataSet2.COURSE)


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim connectionstring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\documents\visual studio 2012\Projects\studemt management system\studemt management system\stmanage.mdf;Integrated Security=True;Connect Timeout=30"
        Dim connection As New SqlConnection(connectionstring)


        connection.Open()
        Try
            Dim CID As String
            CID = coc.Text

            Dim sqlquery As String = "update COURSE set COURSE_NAME=@NEWCNAME,COURSE_DURATION=@NEWCDURATION,COURSE_FEES=@NEWCFEES where COURSE_ID = @NEWCID "
            Dim command As New SqlCommand(sqlquery, connection)
            command.Parameters.AddWithValue("@NEWCID", CID)
            command.Parameters.AddWithValue("@NEWCNAME", cn.Text)
            command.Parameters.AddWithValue("@NEWCDURATION", cd.Text)
            command.Parameters.AddWithValue("@NEWCFEES", cf.Text)

            Dim rowcount As Integer = command.ExecuteNonQuery()
            view()
            coc.Text = ""
            cn.Text = ""
            cd.Text = ""
            cf.Text = ""


            If rowcount > 0 Then
                Console.WriteLine(" COURSE_ID " & CID & " WAS UPDATED IN DATABASE.")
                MsgBox("COURSE DETAILS UPDATED SUCCESSFULLY")
            Else
                Console.WriteLine(" COURSE_ID " & CID & " WAS NOT FOUND IN DATABASE.")
                MsgBox(" COURSE NOT FOUND")
            End If

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim connectionstring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\documents\visual studio 2012\Projects\studemt management system\studemt management system\stmanage.mdf;Integrated Security=True;Connect Timeout=30"
        Dim connection As New SqlConnection(connectionstring)
        connection.Open()

        Dim CID As String
        CID = coc.Text
        Dim ROWCOUNT As Integer
        ROWCOUNT = 0
        Dim sqlquery As String = "select count(*) from COURSE where COURSE_ID = @CID"
        Dim command1 As New SqlCommand(sqlquery, connection)
        command1.Parameters.AddWithValue("@CID", CID)
        ROWCOUNT = CInt(command1.ExecuteScalar())

        Try

            If ROWCOUNT > 0 Then

                Dim deletestatement As String = "delete from course where course_id = @cid"
                Dim command As New SqlCommand(deletestatement, connection)
                command.Parameters.AddWithValue("@CID", CID)
                command.ExecuteNonQuery()
                MsgBox("COURSE DETAIL IS REMOVED SUCCESSFULLY")
            Else
                MsgBox("COURSE NOT FOUND")
            End If
            connection.Close()
            view()



        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub

    Private Sub cd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cd.SelectedIndexChanged
      
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim cid As String
        cid = coc.Text

        Dim query As String = "SELECT COURSE_ID,COURSE_NAME,COURSE_DURATION,COURSE_FEES FROM COURSE WHERE COURSE_ID= @cid"
        Dim command As New SqlCommand(query, connection)
        command.Parameters.AddWithValue("@cid", cid)
     
        connection.Open()
        Dim reader As SqlDataReader = command.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            coc.Text = reader.GetString(0).ToString()
            cn.Text = reader.GetString(1).ToString()
            cd.Text = reader.GetString(2).ToString()
            cf.Text = reader.GetString(3).ToString()
            
            MsgBox("course is found...")
            Button5.Visible = False
        Else
            MsgBox(" course is not in database...")
        End If
        reader.Close()
        connection.Close()
        view()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
    

    End Sub
End Class