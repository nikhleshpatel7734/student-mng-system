Imports System.Data.SqlClient
Public Class STUDENT

    Dim connectionstring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\documents\visual studio 2012\Projects\studemt management system\studemt management system\stmanage.mdf;Integrated Security=True;Connect Timeout=30"
    Dim connection As New SqlConnection(connectionstring)
    Sub view()
        connection.Open()
        Dim adp As New SqlDataAdapter("select * from st", connection)
        Dim ds As New DataSet
        adp.Fill(ds, "dd")
        DataGridView1.DataSource = ds.Tables("dd")
        connection.Close()
    End Sub
    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Me.Hide()
        LOGIN.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As Date
        a = Convert.ToDateTime(DOB.Value)
        Dim connectionstring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\documents\visual studio 2012\Projects\studemt management system\studemt management system\stmanage.mdf;Integrated Security=True;Connect Timeout=30"
        Dim connection As New SqlConnection(connectionstring)
        Try

       
        connection.Open()
        Dim insertstatement As String = "insert into st (STID,NAME,MOBILENO,FATHERNAME,DOB,EMAIL,GENDER,COURSE) VALUES (@STID,@NAME,@MOBILENO,@FATHERNAME,@DOB,@EMAIL,@GENDER,@COURSE)"
        Dim insertcommand As New SqlCommand(insertstatement, connection)
        insertcommand.Parameters.AddWithValue("@STID", STI.Text)
            insertcommand.Parameters.AddWithValue("@NAME", na.Text)
        insertcommand.Parameters.AddWithValue("MOBILENO", MOB.Text)
            insertcommand.Parameters.AddWithValue("@FATHERNAME", fan.Text)
            insertcommand.Parameters.AddWithValue("@DOB", a.Date)
        insertcommand.Parameters.AddWithValue("@EMAIL", EM.Text)
        insertcommand.Parameters.AddWithValue("@GENDER", GEN.Text)
        insertcommand.Parameters.AddWithValue("@COURSE", CO.Text)
            insertcommand.ExecuteNonQuery()
            DataGridView1.Refresh()



            MsgBox("STUDENT ADD SUCCESSFULLY")
            connection.Close()
            view()
            STI.Text = ""
            na.Text = ""
            MOB.Text = ""
            fan.Text = ""
            DOB.Text = ""
            EM.Text = ""
            GEN.Text = ""
            CO.Text = ""

            DataGridView1.Refresh()



        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
       



    End Sub

    Private Sub STUDENT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'StmanageDataSet.ST' table. You can move, or remove it, as needed.
        Me.STTableAdapter.Fill(Me.StmanageDataSet.ST)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        COURSE.Show()
        Me.Hide()

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        FEES.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        LOGIN.Show()
        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim connectionstring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\documents\visual studio 2012\Projects\studemt management system\studemt management system\stmanage.mdf;Integrated Security=True;Connect Timeout=30"
        Dim connection As New SqlConnection(connectionstring)
        connection.Open()

        Dim stid As String
        stid = STI.Text
        Dim ROWCOUNT As Integer
        ROWCOUNT = 0
        Dim sqlquery As String = "select count(*) from st where STID = @STID"
        Dim command1 As New SqlCommand(sqlquery, connection)
        command1.Parameters.AddWithValue("@STID", stid)
        ROWCOUNT = CInt(command1.ExecuteScalar())

        Try

            If ROWCOUNT > 0 Then

                Dim deletestatement As String = "delete from st where STID = @STID"
                Dim command As New SqlCommand(deletestatement, connection)
                command.Parameters.AddWithValue("@STID", stid)
                command.ExecuteNonQuery()
                MsgBox("STUDENT IS REMOVED SUCCESSFULLY")
            Else
                MsgBox("STUDENT NOT FOUND")
            End If
            connection.Close()
            view()



        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim connectionstring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\documents\visual studio 2012\Projects\studemt management system\studemt management system\stmanage.mdf;Integrated Security=True;Connect Timeout=30"
        Dim connection As New SqlConnection(connectionstring)
        Dim a As Date
        a = Convert.ToDateTime(DOB.Value)

        connection.Open()
        Try

            Dim stid As Integer
            stid = STI.Text
            Dim sqlquery As String = "update st set NAME=@NEWNAME,MOBILENO=@NEWMOBILENO,FATHERNAME=@NEWFATHERNAME,DOB=@NEWDOB,EMAIL=@NEWEMAIL,GENDER=@NEWGENDER,COURSE=@NEWCOURSE where STID= @NEWSTID"
            Dim command As New SqlCommand(sqlquery, connection)
            command.Parameters.AddWithValue("@NEWSTID", stid)
            command.Parameters.AddWithValue("@NEWNAME", na.Text)
            command.Parameters.AddWithValue("@NEWMOBILENO", MOB.Text)
            command.Parameters.AddWithValue("@NEWFATHERNAME", fan.Text)
            command.Parameters.AddWithValue("@NEWDOB", a.Date)
            command.Parameters.AddWithValue("@NEWEMAIL", EM.Text)
            command.Parameters.AddWithValue("@NEWGENDER", GEN.Text)
            command.Parameters.AddWithValue("@NEWCOURSE", CO.Text)
            Dim rowcount As Integer = command.ExecuteNonQuery()
            If rowcount > 0 Then
                Console.WriteLine(" STID " & stid & " WAS UPDATED IN DATABASE.")
                MsgBox("STUDENT UPDATED SUCCESSFULLY")
            Else
                Console.WriteLine(" STID " & stid & " WAS NOT FOUND IN DATABASE.")
                MsgBox(" STUDENT NOT FOUND")
            End If

            connection.Close()
            view()
            STI.Text = ""
            na.Text = ""
            MOB.Text = ""
            fan.Text = ""
            DOB.Text = ""
            EM.Text = ""
            GEN.Text = ""
            CO.Text = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
      
    End Sub

    Private Sub GEN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GEN.SelectedIndexChanged
        GEN.Items.Add("MALE")
        GEN.Items.Add("FEMALE")
        GEN.Items.Add("OTHER")
    End Sub

    Private Sub CO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CO.SelectedIndexChanged
        CO.Items.Add("BCA")
        CO.Items.Add("MCA")
        CO.Items.Add("BBA")
        CO.Items.Add("MBA")
        CO.Items.Add("B.TECH")
        CO.Items.Add("M.TECH")
        CO.Items.Add("BA")
        CO.Items.Add("MA")
        CO.Items.Add("B.PHARMA")
        CO.Items.Add("D.PHARMA")
        CO.Items.Add("BSC")
        CO.Items.Add("MSC")

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim stid As String
        stid = STI.Text

        Dim query As String = "SELECT STID,NAME,MOBILENO,FATHERNAME,DOB,EMAIL,GENDER,COURSE FROM ST WHERE STID= @sid"
        Dim command As New SqlCommand(query, connection)
        command.Parameters.AddWithValue("@sid", stid)
        Dim A As Date
        A = Convert.ToDateTime(DOB.Value)
        connection.Open()
        Dim reader As SqlDataReader = command.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            STI.Text = reader.GetInt32(0).ToString()
            na.Text = reader.GetString(1).ToString()
            MOB.Text = reader.GetString(2).ToString()
            fan.Text = reader.GetString(3).ToString()
            DOB.Text = reader.GetDateTime(4).ToString()
            EM.Text = reader.GetString(5).ToString()
            GEN.Text = reader.GetString(6).ToString()
            CO.Text = reader.GetString(7).ToString()
            MsgBox("student is found...")
            Button5.Visible = False
        Else
            MsgBox("student is not in database...")
        End If
        reader.Close()
        connection.Close()
        view()

    End Sub

End Class