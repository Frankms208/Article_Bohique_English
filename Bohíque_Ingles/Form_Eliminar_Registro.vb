Imports System.Data.SqlClient
Public Class Form_Eliminar_Registro

    Private Sub CheckBox_Mostrar_Contraseña_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Mostrar_Contraseña.CheckedChanged
        If CheckBox_Mostrar_Contraseña.Checked Then
            PictureBox_Contraseña.BackgroundImage = My.Resources.Show_password_48
            TextBox_Contraseña.PasswordChar = Nothing
        Else
            PictureBox_Contraseña.BackgroundImage = My.Resources.Hide_password_48
            TextBox_Contraseña.PasswordChar = "*"
        End If
    End Sub

    Private Sub Form_Eliminar_Registro_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
            PictureBox_Usuario.Visible = True
            Label_Usuario.Visible = True
            ComboBox_Selecion_Usuario.Visible = True
        ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 1 Then
            PictureBox_Usuario.Visible = False
            Label_Usuario.Visible = False
            ComboBox_Selecion_Usuario.Visible = False
        End If

        If Form_Principal.Usuario_Activo.Tipo_Usuario = 1 Then
            'Identificar los pacientes existentes relacionados con el usuario seleccionado
            Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
            Dim Pacientes As New DataSet
            Pacientes = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Usuarios, Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_"))

            ComboBox_Selecion_Paciente.Items.Clear()

            For i = 0 To Pacientes.Tables(0).Rows.Count - 1
                ComboBox_Selecion_Paciente.Items.Add(Pacientes.Tables(0).Rows(i)(0))
            Next i
            'Identificar los registors existentes relacionados con el paciente
            If ComboBox_Selecion_Paciente.Items.Count > 0 Then
                ComboBox_Selecion_Paciente.SelectedIndex = 0
                Dim Fecha_Registro As New DataSet
                Fecha_Registro = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Usuarios, Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"))

                ComboBox_Selecionar_Registro.Items.Clear()

                For i = 0 To Fecha_Registro.Tables(0).Rows.Count - 1
                    ComboBox_Selecionar_Registro.Items.Add(Fecha_Registro.Tables(0).Rows(i)(0))
                Next i
                Coneccion_Usuarios.Close()

            End If
            If ComboBox_Selecionar_Registro.Items.Count > 0 Then
                ComboBox_Selecionar_Registro.SelectedIndex = 0
            End If
        ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
            'Identificar los usuarios existentes
            Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
            Dim Usuario As New DataSet
            Usuario = Class_Funciones_Base_Datos.Tabla_Usuarios_Buscar_Usuarios(Coneccion_Usuarios, "1")
            ComboBox_Selecion_Usuario.Items.Clear()

            For i = 0 To Usuario.Tables(0).Rows.Count - 1
                ComboBox_Selecion_Usuario.Items.Add(Usuario.Tables(0).Rows(i)(0))
            Next i

            'Identificar los pacientes existentes relacionados con el usuario 
            If ComboBox_Selecion_Usuario.Items.Count > 0 Then
                ComboBox_Selecion_Usuario.SelectedIndex = 0

                Dim Pacientes As New DataSet
                Pacientes = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Usuarios, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"))

                ComboBox_Selecion_Paciente.Items.Clear()

                For i = 0 To Pacientes.Tables(0).Rows.Count - 1
                    ComboBox_Selecion_Paciente.Items.Add(Pacientes.Tables(0).Rows(i)(0))
                Next i
                'Identificar los registors existentes relacionados con el paciente
                If ComboBox_Selecion_Paciente.Items.Count > 0 Then
                    ComboBox_Selecion_Paciente.SelectedIndex = 0
                    Dim Fecha_Registro As New DataSet
                    Fecha_Registro = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Usuarios, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"))

                    ComboBox_Selecionar_Registro.Items.Clear()

                    For i = 0 To Fecha_Registro.Tables(0).Rows.Count - 1
                        ComboBox_Selecionar_Registro.Items.Add(Fecha_Registro.Tables(0).Rows(i)(0))
                    Next i

                End If
                If ComboBox_Selecionar_Registro.Items.Count > 0 Then
                    ComboBox_Selecionar_Registro.SelectedIndex = 0
                End If

                If ComboBox_Selecionar_Registro.Items.Count > 0 Then
                    ComboBox_Selecionar_Registro.SelectedIndex = 0
                End If
            End If

        End If

    End Sub

    Private Sub Form_Eliminar_Registro_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form_Principal.Enabled = True
    End Sub

    Private Sub ComboBox_Selecion_Usuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Selecion_Usuario.SelectedIndexChanged
        Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
        Dim Pacientes As New DataSet
        Pacientes = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Usuarios, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"))

        ComboBox_Selecion_Paciente.Items.Clear()

        For i = 0 To Pacientes.Tables(0).Rows.Count - 1
            ComboBox_Selecion_Paciente.Items.Add(Pacientes.Tables(0).Rows(i)(0))
        Next i

        'Identificar los registors existentes relacionados con el pacientes 
        If ComboBox_Selecion_Paciente.Items.Count > 0 Then
            ComboBox_Selecion_Paciente.SelectedIndex = 0
        End If
        'If ComboBox_Selecionar_Registro.Items.Count > 0 Then
        '    ComboBox_Selecionar_Registro.SelectedIndex = 0
        'End If
        Coneccion_Usuarios.Close()
    End Sub

    Private Sub ComboBox_Selecion_Paciente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Selecion_Paciente.SelectedIndexChanged
        If Form_Principal.Usuario_Activo.Tipo_Usuario = 1 Then
            Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
            Dim Fecha_Registro As New DataSet
            Fecha_Registro = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Usuarios, Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"))

            ComboBox_Selecionar_Registro.Items.Clear()

            For i = 0 To Fecha_Registro.Tables(0).Rows.Count - 1
                ComboBox_Selecionar_Registro.Items.Add(Fecha_Registro.Tables(0).Rows(i)(0))
            Next i

            If ComboBox_Selecionar_Registro.Items.Count > 0 Then
                ComboBox_Selecionar_Registro.SelectedIndex = 0
            End If
        ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
            Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
            Dim Fecha_Registro As New DataSet
            Fecha_Registro = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Usuarios, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"))

            ComboBox_Selecionar_Registro.Items.Clear()

            For i = 0 To Fecha_Registro.Tables(0).Rows.Count - 1
                ComboBox_Selecionar_Registro.Items.Add(Fecha_Registro.Tables(0).Rows(i)(0))
            Next i

            If ComboBox_Selecionar_Registro.Items.Count > 0 Then
                ComboBox_Selecionar_Registro.SelectedIndex = 0
            End If

        End If
    End Sub

    Private Sub Button_Eliminar_Registro_Click(sender As Object, e As EventArgs) Handles Button_Eliminar_Registro.Click
        Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
        'Comprobar que la contraseña es correcta

        If Class_Funciones_Base_Datos.Tabla_Usuarios_Validar_Contraseña(Coneccion_Usuarios, Convert.ToString(Form_Principal.Usuario_Activo.Tipo_Usuario), Form_Principal.Usuario_Activo.Usuario, TextBox_Contraseña.Text) = True Then
            'Obtener el registro  del paciente del usuario a eliminar
            Dim Fecha_Registro_Eliminar As String
            Fecha_Registro_Eliminar = ComboBox_Selecionar_Registro.Text
            Fecha_Registro_Eliminar = Fecha_Registro_Eliminar.Trim()

            Dim Paciente As String = ComboBox_Selecion_Paciente.Text
            Paciente = Paciente.Replace(" ", "_")
            Dim Usuario As String
            If Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
                Usuario = ComboBox_Selecion_Usuario.Text.Replace(" ", "_")
            Else
                Usuario = Form_Principal.Usuario_Activo.Usuario.Replace(" ", "_")
            End If

            If Class_Funciones_Base_Datos.Eliminar_Registro(Coneccion_Usuarios, Usuario, Paciente, Fecha_Registro_Eliminar) Then
                Const message As String = "Es necesario Reiniciar la Aplicación para Finalizar la Eliminación." + Chr(13) + "¿Desea hacerlo ahora?"
                Const caption As String = "Desea Reiniciar la Aplicación"
                Dim Result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (Result = DialogResult.Yes) Then
                    Application.Restart()
                End If
            End If
            ComboBox_Selecionar_Registro.Text = ""

            If Form_Principal.Usuario_Activo.Tipo_Usuario = 1 Then
                Dim Fecha_Registro As New DataSet
                Fecha_Registro = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Usuarios, Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"))

                ComboBox_Selecionar_Registro.Items.Clear()

                For i = 0 To Fecha_Registro.Tables(0).Rows.Count - 1
                    ComboBox_Selecionar_Registro.Items.Add(Fecha_Registro.Tables(0).Rows(i)(0))
                Next i

                If ComboBox_Selecionar_Registro.Items.Count > 0 Then
                    ComboBox_Selecionar_Registro.SelectedIndex = 0
                End If
            ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
                Dim Fecha_Registro As New DataSet
                Fecha_Registro = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Usuarios, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"))

                ComboBox_Selecionar_Registro.Items.Clear()

                For i = 0 To Fecha_Registro.Tables(0).Rows.Count - 1
                    ComboBox_Selecionar_Registro.Items.Add(Fecha_Registro.Tables(0).Rows(i)(0))
                Next i

                If ComboBox_Selecionar_Registro.Items.Count > 0 Then
                    ComboBox_Selecionar_Registro.SelectedIndex = 0
                End If

            End If

        Else
            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Me, "Contraseña Incorrecta", "", "Contraseña Incorrecta", 0)
            TextBox_Contraseña.Text = Nothing
        End If

        Coneccion_Usuarios.Close()

    End Sub



    Private Sub Button_Principal_MouseEnter(sender As Object, e As EventArgs) Handles Button_Eliminar_Registro.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde_Cambio
    End Sub

    Private Sub Button_Principal_MouseLeave(sender As Object, e As EventArgs) Handles Button_Eliminar_Registro.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde
    End Sub

End Class