Imports System.Data.SqlClient
Public Class Form_Eliminar_Paciente

    Private Sub Form_Eliminar_Paciente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form_Principal.Enabled = True
    End Sub

    Private Sub Form_Eliminar_Paciente_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
            'Cargar los usuarios existentes

            Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()

            Dim Usuario As New DataSet
            Usuario = Class_Funciones_Base_Datos.Tabla_Usuarios_Buscar_Usuarios(Coneccion_Usuarios, "1")
            ComboBox_Selecion_Usuario.Items.Clear()

            For i = 0 To Usuario.Tables(0).Rows.Count - 1
                ComboBox_Selecion_Usuario.Items.Add(Usuario.Tables(0).Rows(i)(0))
            Next i

            If ComboBox_Selecion_Usuario.Items.Count > 0 Then
                ComboBox_Selecion_Usuario.SelectedIndex = 0
                'Cargar los registros del primer usuario existente
                Dim Pacientes As New DataSet
                Pacientes = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Usuarios, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"))

                ComboBox_Seleccion_Eliminar_Paciente.Items.Clear()

                For i = 0 To Pacientes.Tables(0).Rows.Count - 1
                    ComboBox_Seleccion_Eliminar_Paciente.Items.Add(Pacientes.Tables(0).Rows(i)(0))
                Next i

                If ComboBox_Seleccion_Eliminar_Paciente.Items.Count > 0 Then
                    ComboBox_Seleccion_Eliminar_Paciente.SelectedIndex = 0
                End If
            End If
        ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 1 Then
            ComboBox_Selecion_Usuario.Visible = False
            PictureBox_Seleccion_Usuario.Visible = False
            Label_Seleccion_Usuario.Visible = False

            Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
            Dim Pacientes As New DataSet
            Pacientes = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Usuarios, Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_"))

            ComboBox_Seleccion_Eliminar_Paciente.Items.Clear()

            For i = 0 To Pacientes.Tables(0).Rows.Count - 1
                ComboBox_Seleccion_Eliminar_Paciente.Items.Add(Pacientes.Tables(0).Rows(i)(0))
            Next i

            If ComboBox_Seleccion_Eliminar_Paciente.Items.Count > 0 Then
                ComboBox_Seleccion_Eliminar_Paciente.SelectedIndex = 0
            End If
        End If

    End Sub

    Private Sub ComboBox_Selecion_Usuario_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox_Selecion_Usuario.SelectedIndexChanged
        Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
        'Cargar los registros del primer usuario existente
        Dim Pacientes As New DataSet
        Pacientes = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Usuarios, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"))

        ComboBox_Seleccion_Eliminar_Paciente.Items.Clear()

        For i = 0 To Pacientes.Tables(0).Rows.Count - 1
            ComboBox_Seleccion_Eliminar_Paciente.Items.Add(Pacientes.Tables(0).Rows(i)(0))
        Next i

        If ComboBox_Seleccion_Eliminar_Paciente.Items.Count > 0 Then
            ComboBox_Seleccion_Eliminar_Paciente.SelectedIndex = 0
        End If
    End Sub

    Private Sub Button_Eliminar_Usuario_Click(sender As Object, e As EventArgs) Handles Button_Eliminar_Usuario.Click
        Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
        'Comprobar que la contraseña es correcta

        If Class_Funciones_Base_Datos.Tabla_Usuarios_Validar_Contraseña(Coneccion_Usuarios, Convert.ToString(Form_Principal.Usuario_Activo.Tipo_Usuario), Form_Principal.Usuario_Activo.Usuario, TextBox_Contraseña_Confirmacion.Text) = True Then
            'Obtener el paciente del usuario a eliminar
            Dim Paciente_Eliminar As String = ComboBox_Seleccion_Eliminar_Paciente.Text
            Paciente_Eliminar = Paciente_Eliminar.Replace(" ", "_")
            Dim Usuario As String
            If Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
                Usuario = ComboBox_Selecion_Usuario.Text.Replace(" ", "_")
            Else
                Usuario = Form_Principal.Usuario_Activo.Usuario.Replace(" ", "_")
            End If
            'Eliminar todos lo datos realcioandos con el paciente
            If Class_Funciones_Base_Datos.Eliminar_Paciente(Coneccion_Usuarios, Usuario, Paciente_Eliminar) Then
                Const message As String = "It is necessary to restart the application to finish the elimination." + Chr(13) + "Do you want to do it now?"
                Const caption As String = "You want to restart the application"
                Dim Result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (Result = DialogResult.Yes) Then
                    Application.Restart()
                End If
            End If

            Me.Close()
        Else
            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Me, "Incorrect Password", "", "Incorrect Password", 0)
            TextBox_Contraseña_Confirmacion.Text = Nothing
        End If



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