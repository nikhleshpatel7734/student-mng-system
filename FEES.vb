Imports System.Data.SqlClient
Public Class FEES
    Dim connectionstring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\documents\visual studio 2012\Projects\studemt management system\studemt management system\stmanage.mdf;Integrated Security=True;Connect Timeout=30"
    Dim connection As New SqlConnection(connectionstring)
    Sub view()
        connection.Open()
        Dim adp As New SqlDataAdapter("select * from fee", connection)
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

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        COURSE.Show()
        Me.Hide()

    End Sub

    Private Sub FEES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'StmanageDataSet3.FEE' table. You can move, or remove it, as needed.
        Me.FEETableAdapter.Fill(Me.StmanageDataSet3.FEE)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As Date
        a = Convert.ToDateTime(fed.Value)
        Dim connectionstring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\documents\visual studio 2012\Projects\studemt management system\studemt management system\stmanage.mdf;Integrated Security=True;Connect Timeout=30"
        Dim connection As New SqlConnection(connectionstring)
        Try


            connection.Open()
            Dim insertstatement As String = "insert into FEE (ST_ID,NAME,PAYMENT_TYPE,FEE_AMOUNT,FEE_DATE,COURSE) VALUES (@STID,@NAME,@PAYT,@FEEA,@FEED,@COURSE)"
            Dim insertcommand As New SqlCommand(insertstatement, connection)
            insertcommand.Parameters.AddWithValue("@STID", si.Text)
            insertcommand.Parameters.AddWithValue("@NAME", nam.Text)
            insertcommand.Parameters.AddWithValue("@PAYT", pt.Text)
            insertcommand.Parameters.AddWithValue("@FEEA", fea.Text)
            insertcommand.Parameters.AddWithValue("@FEED", a.Date)

            insertcommand.Parameters.AddWithValue("@COURSE", cor.Text)
            insertcommand.ExecuteNonQuery()
            DataGridView1.Refresh()



            MsgBox("FEES INFORMATION ADD SUCCESSFULLY")
            connection.Close()
            view()
            si.Text = ""
            nam.Text = ""
            pt.Text = ""
            fea.Text = ""
            fed.Text = ""
            cor.Text = ""

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim connectionstring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\documents\visual studio 2012\Projects\studemt management system\studemt management system\stmanage.mdf;Integrated Security=True;Connect Timeout=30"
        Dim connection As New SqlConnection(connectionstring)
        Dim a As Date
        a = Convert.ToDateTime(fed.Value)

        connection.Open()
        Try

            Dim stid As Integer
            stid = si.Text
            Dim sqlquery As String = "update FEE set NAME=@NEWNAME,PAYMENT_TYPE=@NEWPTYPE,FEE_AMOUNT=@NEWFEEA,FEE_DATE=@NEWFEED,COURSE=@NEWCOURSE where ST_ID=@NEWSTID"
            Dim command As New SqlCommand(sqlquery, connection)
            command.Parameters.AddWithValue("@NEWSTID", stid)
            command.Parameters.AddWithValue("@NEWNAME", nam.Text)
            command.Parameters.AddWithValue("@NEWPTYPE", pt.Text)
            command.Parameters.AddWithValue("@NEWFEEA", fea.Text)
            command.Parameters.AddWithValue("@NEWFEED", a.Date)
            command.Parameters.AddWithValue("@NEWCOURSE", cor.Text)
            Dim rowcount As Integer = command.ExecuteNonQuery()
            If rowcount > 0 Then
                Console.WriteLine(" STID " & stid & " WAS UPDATED IN DATABASE.")
                MsgBox("FEES INFORMATION UPDATED SUCCESSFULLY")
            Else
                Console.WriteLine(" STID " & stid & " WAS NOT FOUND IN DATABASE.")
                MsgBox(" FEE INFO NOT FOUND")
            End If

            connection.Close()
            view()

            si.Text = ""
            nam.Text = ""
            pt.Text = ""
            fea.Text = ""
            fed.Text = ""
            cor.Text = ""


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim connectionstring As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\documents\visual studio 2012\Projects\studemt management system\studemt management system\stmanage.mdf;Integrated Security=True;Connect Timeout=30"
        Dim connection As New SqlConnection(connectionstring)
        connection.Open()

        Dim stid As String
        stid = si.Text
        Dim ROWCOUNT As Integer
        ROWCOUNT = 0
        Dim sqlquery As String = "select count(*) from FEE where ST_ID = @STID"
        Dim command1 As New SqlCommand(sqlquery, connection)
        command1.Parameters.AddWithValue("@STID", stid)
        ROWCOUNT = CInt(command1.ExecuteScalar())

        Try

            If ROWCOUNT > 0 Then

                Dim deletestatement As String = "delete from FEE where ST_ID = @STID"
                Dim command As New SqlCommand(deletestatement, connection)
                command.Parameters.AddWithValue("@STID", stid)
                command.ExecuteNonQuery()
                MsgBox("FEE INFO IS REMOVED SUCCESSFULLY")
            Else
                MsgBox("FEE INFO NOT FOUND")
            End If
            connection.Close()
            view()



        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub

    Private Sub pt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pt.SelectedIndexChanged
      
    End Sub

    Private Sub cor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cor.SelectedIndexChanged
     
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim sti As String
        sti = si.Text

        Dim query As String = "SELECT ST_ID,NAME,PAYMENT_TYPE,FEE_AMOUNT,FEE_DATE,COURSE FROM FEE WHERE ST_ID= @STID"
        Dim command As New SqlCommand(query, connection)
        command.Parameters.AddWithValue("@STID", sti)

        connection.Open()
        Dim reader As SqlDataReader = command.ExecuteReader()
        Dim A As Date
        A = Convert.ToDateTime(fed.Value)
        If reader.HasRows Then
            reader.Read()
            si.Text = reader.GetInt32(0).ToString()
            nam.Text = reader.GetString(1).ToString()
            pt.Text = reader.GetString(2).ToString()
            fea.Text = reader.GetString(3).ToString()
            fed.Text = reader.GetDateTime(4).ToString()
            cor.Text = reader.GetString(5).ToString()
            MsgBox("fee record is found...")
            Button5.Visible = False
        Else
            MsgBox(" fee record is not in database...")
        End If
        reader.Close()
        connection.Close()
        view()
    End Sub
End Class