Imports System.Data.SqlClient
Public Class Form_Eliminar_Usuario
    Private Bandera_Confirmar_Eliminar_Usuario As Int16 = 0


    Private Sub Button_Eliminar_Usuario_Click_1(sender As Object, e As EventArgs) Handles Button_Eliminar_Usuario.Click
        If Bandera_Confirmar_Eliminar_Usuario = 0 Then
            Button_Eliminar_Usuario.Text = "Confirm Delete"
            PictureBox_Contraseña.Visible = True
            Label_Contraseña_Confirmacion.Visible = True
            TextBox_Contraseña_Confirmacion.Visible = True

            Bandera_Confirmar_Eliminar_Usuario = 1
        ElseIf Bandera_Confirmar_Eliminar_Usuario = 1 Then
            Dim Coneccion_Base_Datos As New SqlConnection
            Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
            Coneccion_Base_Datos.Open()


            If Class_Funciones_Base_Datos.Tabla_Usuarios_Validar_Contraseña(Coneccion_Base_Datos, Convert.ToString(Form_Principal.Usuario_Activo.Tipo_Usuario), Form_Principal.Usuario_Activo.Usuario, TextBox_Contraseña_Confirmacion.Text) = True Then
                Dim Usuario_Eliminar As String = ComboBox_Selecion_Usuario.Text
                Usuario_Eliminar = Usuario_Eliminar.Replace("(Admin)", "")
                Usuario_Eliminar = Usuario_Eliminar.Replace("(User)", "")
                Usuario_Eliminar = Usuario_Eliminar.TrimEnd
                If Class_Funciones_Base_Datos.Eliminar_Usuario(Coneccion_Base_Datos, Usuario_Eliminar) Then
                    Const message As String = "It is necessary to restart the application to finish the delete." + Chr(13) + "Do you want to do it now?"
                    Const caption As String = "You want to restart the application"
                    Dim Result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (Result = DialogResult.Yes) Then
                        Application.Restart()
                    End If
                End If

                Button_Eliminar_Usuario.Text = "Select User"
                PictureBox_Contraseña.Visible = False
                Label_Contraseña_Confirmacion.Visible = False
                TextBox_Contraseña_Confirmacion.Visible = False
                TextBox_Contraseña_Confirmacion.Text = ""

                Bandera_Confirmar_Eliminar_Usuario = 0
                ComboBox_Selecion_Usuario.Items.Remove(ComboBox_Selecion_Usuario.SelectedItem)
                ComboBox_Selecion_Usuario.SelectedItem = -1

            Else
                Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                Contraseña_Incorrecta.Form_Mensaje(Me, "Incorrect Password", "", "Password Error", 0)
                TextBox_Contraseña_Confirmacion.Text = Nothing
                End If

            Coneccion_Base_Datos.Close()

        End If
    End Sub

    Private Sub Form_Eliminar_Usuario_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form_Principal.Enabled = True
    End Sub

    Private Sub Form_Eliminar_Usuario_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim Coneccion_Base_Datos As New SqlConnection

        Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
        Coneccion_Base_Datos.Open()
        Dim sql_Tipo_Usuario As String = "SELECT Usuario, Tipo_de_Usuario FROM Usuarios WHERE Tipo_de_Usuario=1 or Tipo_de_Usuario=2 ORDER BY Tipo_de_Usuario"
        Dim cmd As New SqlCommand(sql_Tipo_Usuario, Coneccion_Base_Datos)
        Try
            Dim Adaptador As New SqlDataAdapter(cmd)
            Dim Datos As New DataSet
            Adaptador.Fill(Datos, "Usuarios")
            For i = 0 To Datos.Tables("Usuarios").Rows.Count - 1
                Dim Usuarios As String
                If (Datos.Tables("Usuarios").Rows(i)(1) = 1) Then
                    Usuarios = "(User)" + Datos.Tables("Usuarios").Rows(i)(0)
                ElseIf (Datos.Tables("Usuarios").Rows(i)(1) = 2) Then
                    Usuarios = "(Admin)" + Datos.Tables("Usuarios").Rows(i)(0)
                End If
                ComboBox_Selecion_Usuario.Items.Add(Usuarios)
            Next i
            Coneccion_Base_Datos.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If ComboBox_Selecion_Usuario.Items.Count > 0 Then
            ComboBox_Selecion_Usuario.SelectedIndex = 0
        End If
    End Sub

    Private Sub ComboBox_Selecion_Usuario_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox_Selecion_Usuario.SelectedValueChanged
        Button_Eliminar_Usuario.Text = "Select User"
        PictureBox_Contraseña.Visible = False
        Label_Contraseña_Confirmacion.Visible = False
        TextBox_Contraseña_Confirmacion.Visible = False
        TextBox_Contraseña_Confirmacion.Text = ""

        Bandera_Confirmar_Eliminar_Usuario = 0
    End Sub


    Private Sub Button_Principal_MouseEnter(sender As Object, e As EventArgs) Handles Button_Eliminar_Usuario.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde_Cambio
    End Sub

    Private Sub Button_Principal_MouseLeave(sender As Object, e As EventArgs) Handles Button_Eliminar_Usuario.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde
    End Sub

End Class