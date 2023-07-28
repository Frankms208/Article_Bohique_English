Imports System.Data.SqlClient
Public Class Form_Crear_Usuario

    Private Sub Button_Crear_Usuario_Click(sender As Object, e As EventArgs) Handles Button_Crear_Usuario.Click
        If TextBox_Nombre_Usuario.Text <> "" Then
            Dim Coneccion_Base_Datos As New SqlConnection
            Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
            If Class_Funciones_Base_Datos.Tabla_Usuarios_Validar_Existencia_Usuarios(Coneccion_Base_Datos, Convert.ToString(ComboBox_Tipo_Usuario.SelectedIndex + 1), TextBox_Nombre_Usuario.Text) = False Then
                If TextBox_Contraseña_1.Text = TextBox_Contraseña_2.Text Then
                    If TextBox_Contraseña_1.Text.Count > 3 Then
                        Dim Usuario As String
                        'If == User Then
                        Class_Funciones_Base_Datos.Tabla_Usuarios_Agregar_Usuario(Coneccion_Base_Datos, Convert.ToString(ComboBox_Tipo_Usuario.SelectedIndex + 1), TextBox_Nombre_Usuario.Text, TextBox_Contraseña_1.Text)
                            Me.Close()
                        Else
                            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                        Contraseña_Incorrecta.Form_Mensaje(Me, "Password needs more than 3  ", "characters (letters or numbers)", "Password error", 0)
                    End If

                Else
                    Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                    Contraseña_Incorrecta.Form_Mensaje(Me, "Passwords do not match", "", "Password error", 0)
                End If
            Else
                Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                Contraseña_Incorrecta.Form_Mensaje(Me, "User already exists", "", "Password error", 0)
            End If
        Else
            'Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            'Contraseña_Incorrecta.Show()
            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Me, "Error in the User Field", "", "Error in the User Field", 0)
        End If
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Mostrar_Contraseña.CheckedChanged
        If CheckBox_Mostrar_Contraseña.Checked Then
            PictureBox_Contraseña.BackgroundImage = My.Resources.Show_password_48
            TextBox_Contraseña_1.PasswordChar = Nothing
            TextBox_Contraseña_2.PasswordChar = Nothing
            'TextBox_Contraseña_2.Visible = False
        Else
            PictureBox_Contraseña.BackgroundImage = My.Resources.Hide_password_48
            TextBox_Contraseña_1.PasswordChar = "*"
            TextBox_Contraseña_2.PasswordChar = "*"
            'TextBox_Contraseña_2.Visible = True
        End If
    End Sub

    Private Sub Form_Crear_Usuario_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ComboBox_Tipo_Usuario.SelectedIndex = 1
    End Sub

    Private Sub TextBox_Nombre_Usuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Nombre_Usuario.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsLetterOrDigit(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox_Contraseña_1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Contraseña_1.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsLetterOrDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox_Contraseña_2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Contraseña_2.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsLetterOrDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Show()
        End If
    End Sub

    Private Sub Form_Crear_Usuario_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form_Principal.Enabled = True
    End Sub


    Private Sub Button_Principal_MouseEnter(sender As Object, e As EventArgs) Handles Button_Crear_Usuario.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde_Cambio
    End Sub

    Private Sub Button_Principal_MouseLeave(sender As Object, e As EventArgs) Handles Button_Crear_Usuario.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde
    End Sub

End Class