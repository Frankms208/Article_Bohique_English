Public Class Form_Mensaje_Error
    Public Form_Invocador As Form
    Public Sub Form_Mensaje(Form_Invocador_1 As Form, Label_Mensaje_1 As String, Label_Mensaje_2 As String, Label_Text As String, Tipo As Int16)
        Form_Invocador = Form_Invocador_1
        Form_Invocador.Enabled = False
        Me.Text = Label_Text
        Label_Mensaje1.Text = Label_Mensaje_1
        Label_Mensaje2.Text = Label_Mensaje_2
        If Tipo = 0 Then
            PictureBox1.BackgroundImage = My.Resources._Error
        ElseIf Tipo = 1 Then
            PictureBox1.BackgroundImage = My.Resources.Accept
        End If
        Me.Show()
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label_Mensaje1.Click, Label_Mensaje2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Form_Contraseña_Incorrecta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form_Mensaje_Error_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            Form_Invocador.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button_Principal_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde_Cambio
    End Sub

    Private Sub Button_Principal_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde
    End Sub
End Class