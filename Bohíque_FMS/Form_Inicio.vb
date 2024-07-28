Public Class Form_Inicio
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox_Inicio.Click

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer_Inicio.Start()
        Form_Principal.Hide()

    End Sub

    Private Sub Timer_Inicio_Tick(sender As Object, e As EventArgs) Handles Timer_Inicio.Tick
        ProgressBar_Inicio.Increment(20)
        If ProgressBar_Inicio.Value = 100 Then
            Timer_Inicio.Stop()

            Form_Principal.Show()
            Form_Principal.WindowState = 0
            Me.Close()
        End If

    End Sub
End Class