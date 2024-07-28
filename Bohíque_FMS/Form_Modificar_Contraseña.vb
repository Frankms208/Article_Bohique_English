Imports System.Data.SqlClient
Public Class Form_Modificar_Contraseña
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Mostrar_Contraseña.CheckedChanged
        If CheckBox_Mostrar_Contraseña.Checked Then
            PictureBox_Contraseña.BackgroundImage = My.Resources.Show_password_48
            TextBox_Contraseña_Nueva_1.PasswordChar = Nothing
            TextBox_Contraseña_Nueva_2.PasswordChar = Nothing
            'TextBox_Contraseña_2.Visible = False
        Else
            PictureBox_Contraseña.BackgroundImage = My.Resources.Hide_password_48
            TextBox_Contraseña_Nueva_1.PasswordChar = "*"
            TextBox_Contraseña_Nueva_2.PasswordChar = "*"
            'TextBox_Contraseña_2.Visible = True
        End If
    End Sub

    Private Sub Form_Modificar_Contraseña_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Form_Principal.Usuario_Activo.Tipo_Usuario = 1 Then
            ComboBox_Selecion_Usuario.Visible = False
            PictureBox_Usuario.Visible = False
            Label_Usuario.Visible = False
        ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
            Dim Coneccion_Base_Datos As New SqlConnection
            Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
            ComboBox_Selecion_Usuario.Items.Clear()
            Dim Administrador As New DataSet
            Dim Usuario As New DataSet
            Administrador = Class_Funciones_Base_Datos.Tabla_Usuarios_Buscar_Usuarios(Coneccion_Base_Datos, "2")
            For i = 0 To Administrador.Tables(0).Rows.Count - 1
                ComboBox_Selecion_Usuario.Items.Add("(Admin)" + Administrador.Tables("Usuarios").Rows(i)(0))
            Next i

            Usuario = Class_Funciones_Base_Datos.Tabla_Usuarios_Buscar_Usuarios(Coneccion_Base_Datos, "1")
            For i = 0 To Usuario.Tables(0).Rows.Count - 1
                ComboBox_Selecion_Usuario.Items.Add("(User)" + Usuario.Tables("Usuarios").Rows(i)(0))
            Next i

            If ComboBox_Selecion_Usuario.Items.Count > 0 Then
                ComboBox_Selecion_Usuario.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub Button_Modificar_Contraseña_Click(sender As Object, e As EventArgs) Handles Button_Modificar_Contraseña.Click
        If Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
            Dim Usuario_Selecionado As String = ComboBox_Selecion_Usuario.Text
            Usuario_Selecionado = Usuario_Selecionado.Replace("(Admin)", "")
            Usuario_Selecionado = Usuario_Selecionado.Replace("(User)", "")
            If TextBox_Contraseña_Nueva_1.Text = TextBox_Contraseña_Nueva_2.Text Then
                If TextBox_Contraseña_Nueva_1.Text.Count > 3 Then
                    Dim Coneccion_Base_Datos As New SqlConnection
                    Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
                    Class_Funciones_Base_Datos.Tabla_Usuarios_Actualizar_Contraseña(Coneccion_Base_Datos, Usuario_Selecionado, TextBox_Contraseña_Nueva_1.Text)
                    Me.Close()

                Else
                    Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                    Contraseña_Incorrecta.Form_Mensaje(Me, "Password needs more than ", "3 characters (letters or numbers)", "Password Error", 0)
                End If
            Else
                Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                Contraseña_Incorrecta.Form_Mensaje(Me, "Passwords do not match", "", "Password Error", 0)
            End If
        Else
            If TextBox_Contraseña_Nueva_1.Text = TextBox_Contraseña_Nueva_2.Text Then
                If TextBox_Contraseña_Nueva_1.Text.Count > 3 Then
                    Dim Coneccion_Base_Datos As New SqlConnection
                    Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
                    Class_Funciones_Base_Datos.Tabla_Usuarios_Actualizar_Contraseña(Coneccion_Base_Datos, Form_Principal.Usuario_Activo.Usuario, TextBox_Contraseña_Nueva_1.Text)
                    Me.Close()
                Else
                    Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                    Contraseña_Incorrecta.Form_Mensaje(Me, "Password needs more than ", "3 characters (letters or numbers)", "Password Error", 0)
                End If
            Else
                Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                Contraseña_Incorrecta.Form_Mensaje(Me, "Passwords do not match", "", "Password Error", 0)
            End If

        End If
    End Sub


    Private Sub Form_Modificar_Contraseña_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form_Principal.Enabled = True
    End Sub
    Private Sub Button_Principal_MouseEnter(sender As Object, e As EventArgs) Handles Button_Modificar_Contraseña.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde_Cambio
    End Sub

    Private Sub Button_Principal_MouseLeave(sender As Object, e As EventArgs) Handles Button_Modificar_Contraseña.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde
    End Sub
End Class