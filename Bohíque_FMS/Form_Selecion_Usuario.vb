Imports System.Data.SqlClient
Public Class Form_Selecion_Usuario
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button_Cambio_Usuario.Click
        If ComboBox_Selecion_Tipo_Usuario.SelectedIndex > 0 Then
            Dim Coneccion_Base_Datos As New SqlConnection
            Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
            If Class_Funciones_Base_Datos.Tabla_Usuarios_Validar_Contraseña(Coneccion_Base_Datos, Convert.ToString(ComboBox_Selecion_Tipo_Usuario.SelectedIndex), ComboBox_Selecion_Usuario.Text.Trim, TextBox_Contraseña.Text) = True Then
                Form_Principal.Seleccion_Usuario_Activo(ComboBox_Selecion_Tipo_Usuario.SelectedIndex, ComboBox_Selecion_Usuario.Text.Trim)
                If ComboBox_Selecion_Tipo_Usuario.SelectedIndex = 1 Then
                    Form_Principal.Text = ComboBox_Selecion_Usuario.Text.Trim + "(User)"
                ElseIf ComboBox_Selecion_Tipo_Usuario.SelectedIndex = 2 Then
                    Form_Principal.Text = ComboBox_Selecion_Usuario.Text.Trim + "(Admin)"
                End If
                Form_Principal.Enabled = True
                'Eliminar todos los componentes Presentes   Form_Principal.SplitContainer_Principal.Panel2
                Form_Principal.SplitContainer_Principal.Panel2.Controls.Clear()
                Me.Close()

            Else
                Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                Contraseña_Incorrecta.Form_Mensaje(Me, "Incorrect Password", "", "Password Error", 0)
                TextBox_Contraseña.Text = Nothing
            End If

        Else
            Form_Principal.Seleccion_Usuario_Activo(ComboBox_Selecion_Tipo_Usuario.SelectedIndex, ComboBox_Selecion_Usuario.Text.Trim)
            Form_Principal.Text = "Guest"
            Me.Close()
        End If


    End Sub



    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Mostrar_Contraseña.CheckedChanged
        If CheckBox_Mostrar_Contraseña.Checked Then
            PictureBox_Contraseña.BackgroundImage = My.Resources.Show_password_48
            TextBox_Contraseña.PasswordChar = Nothing
        Else
            PictureBox_Contraseña.BackgroundImage = My.Resources.Hide_password_48
            TextBox_Contraseña.PasswordChar = "*"
        End If
    End Sub

    Private Sub Form_Selecion_Usuario_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'Dim Coneccion_Usuarios As New SqlConnection(My.Settings.BaseDatosConnectionString)
        'Dim sql_Tipo_Usuario As String = "SELECT Usuario  FROM Usuarios WHERE Tipo_de_Usuario=2"
        'Dim cmd As New SqlCommand(Sql_Tipo_Usuario, Coneccion_Usuarios)
        'ComboBox_Selecion_Tipo_Usuario.SelectedIndex = 0


        'Try
        '    Dim Adaptador As New SqlDataAdapter(cmd)
        '    Dim Datos As New DataSet
        '    Adaptador.Fill(Datos, "Usuarios")
        '    For i = 0 To Datos.Tables("Usuarios").Rows.Count - 1
        '        ComboBox_Selecion_Usuario.Items.Add(Datos.Tables("Usuarios").Rows(i)(0))
        '        'Para limpiar el ComboBox
        '        'ComboBox_Selecion_Usuario.Items.Clear() 
        '        'Para un elemento del ComboBox
        '        'ComboBox_Selecion_Usuario.Items.RemoveAt(0)
        '    Next i
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        'ComboBox_Selecion_Usuario.SelectedIndex = 0
        ComboBox_Selecion_Tipo_Usuario.SelectedIndex = 2
    End Sub

    Private Sub ComboBox_Selecion_Tipo_Usuario_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox_Selecion_Tipo_Usuario.SelectedValueChanged
        Dim Coneccion_Base_Datos As New SqlConnection
        Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()

        Dim Datos As New DataSet
        ComboBox_Selecion_Usuario.Items.Clear()
        Datos = Class_Funciones_Base_Datos.Tabla_Usuarios_Buscar_Usuarios(Coneccion_Base_Datos, Convert.ToString(ComboBox_Selecion_Tipo_Usuario.SelectedIndex))
        For i = 0 To Datos.Tables("Usuarios").Rows.Count - 1
            ComboBox_Selecion_Usuario.Items.Add(Datos.Tables("Usuarios").Rows(i)(0))
            'Para limpiar el ComboBox
            'ComboBox_Selecion_Usuario.Items.Clear() 
            'Para un elemento del ComboBox
            'ComboBox_Selecion_Usuario.Items.RemoveAt(0)
        Next i
        'Coneccion_Base_Datos.Close()
        If ComboBox_Selecion_Usuario.Items.Count > 0 Then
            ComboBox_Selecion_Usuario.SelectedIndex = 0
        End If
        If ComboBox_Selecion_Tipo_Usuario.SelectedIndex = 0 Then
            PictureBox_Contraseña.Visible = False
            Label_Contraseña.Visible = False
            TextBox_Contraseña.Visible = False

            PictureBox_Usuario.Visible = False
            Label_Usuario.Visible = False
            ComboBox_Selecion_Usuario.Visible = False

            CheckBox_Mostrar_Contraseña.Visible = False
        Else
            PictureBox_Contraseña.Visible = True
            Label_Contraseña.Visible = True
            TextBox_Contraseña.Visible = True

            PictureBox_Usuario.Visible = True
            Label_Usuario.Visible = True
            ComboBox_Selecion_Usuario.Visible = True

            CheckBox_Mostrar_Contraseña.Visible = True
        End If
    End Sub


    Private Sub Button_Principal_MouseEnter(sender As Object, e As EventArgs) Handles Button_Cambio_Usuario.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde_Cambio
    End Sub

    Private Sub Button_Principal_MouseLeave(sender As Object, e As EventArgs) Handles Button_Cambio_Usuario.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde
    End Sub

    Private Sub Form_Selecion_Usuario_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form_Principal.Enabled = True
    End Sub
End Class