Imports System.Data.SqlClient
Public Class Form_Datos_Paciente
    'Si Datos_Paciente__Crear_Actualisar el valor es 0 se lanza como Cargar_Registro
    'Si Datos_Paciente__Crear_Actualisar el valor es 1 se lanza como Alamcenar_Datos_Pacientes
    Public Datos_Paciente_Crear_Actualisar = 0



    Private Sub Form_Datos_Paciente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form_Principal.Enabled = True
    End Sub

    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub CheckBox_Nuevo_Paciente_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Nuevo_Paciente.CheckedChanged
        If Datos_Paciente_Crear_Actualisar = 0 Then
            'Si Datos_Paciente__Crear_Actualisar el valor es 0 se lanza como Cargar_Registro
            If CheckBox_Nuevo_Paciente.Checked Then
                ComboBox_Pacientes.Enabled = False

                ComboBox_Fecha_Nacimiento_Dia.Enabled = True
                ComboBox_Fecha_Nacimiento_Mes.Enabled = True
                ComboBox_Fecha_Nacimiento_Año.Enabled = True
                TextBox_Nombre.Enabled = True
                ComboBox_Marca_Paso.Enabled = True
                TextBox_Peso.Enabled = True
                TextBox_Estatura.Enabled = True
                ComboBox_Sexo.Enabled = True
                ComboBox_Raza.Enabled = True
                RichTextBox_Anotaciones_Paciente.Enabled = True

            Else
                ComboBox_Pacientes.Enabled = True

                ComboBox_Fecha_Nacimiento_Dia.Enabled = False
                ComboBox_Fecha_Nacimiento_Mes.Enabled = False
                ComboBox_Fecha_Nacimiento_Año.Enabled = False
                TextBox_Nombre.Enabled = False

                ComboBox_Marca_Paso.Enabled = False
                TextBox_Peso.Enabled = False
                TextBox_Estatura.Enabled = False
                ComboBox_Sexo.Enabled = False
                ComboBox_Raza.Enabled = False
                RichTextBox_Anotaciones_Paciente.Enabled = False
            End If
        ElseIf Datos_Paciente_Crear_Actualisar = 1 Then
            'Si Datos_Paciente__Crear_Actualisar el valor es 1 se lanza como Alamcenar_Datos_Pacientes
            ComboBox_Pacientes.Enabled = True

            ComboBox_Fecha_Nacimiento_Dia.Enabled = True
            ComboBox_Fecha_Nacimiento_Mes.Enabled = True
            ComboBox_Fecha_Nacimiento_Año.Enabled = True
            ComboBox_Marca_Paso.Enabled = True
            TextBox_Peso.Enabled = True
            TextBox_Estatura.Enabled = True
            ComboBox_Sexo.Enabled = True
            ComboBox_Raza.Enabled = True
            RichTextBox_Anotaciones_Paciente.Enabled = True
        End If



    End Sub

    Private Sub ComboBox_Fecha_Nacimiento_Año_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox_Fecha_Nacimiento_Año.SelectedValueChanged
        Dim Dia_Selecionado As Int16
        If ComboBox_Fecha_Nacimiento_Dia.SelectedItem = Nothing Then
            Dia_Selecionado = 0
        Else
            Dia_Selecionado = ComboBox_Fecha_Nacimiento_Dia.SelectedItem
        End If

        If (Convert.ToInt16(ComboBox_Fecha_Nacimiento_Año.Text) Mod 4) = 0 And ComboBox_Fecha_Nacimiento_Mes.SelectedItem = 2 Then
            ComboBox_Fecha_Nacimiento_Dia.Items.Clear()
            For i = 1 To 29
                If i < 10 Then
                    ComboBox_Fecha_Nacimiento_Dia.Items.Add("0" + Convert.ToString(i))
                Else
                    ComboBox_Fecha_Nacimiento_Dia.Items.Add(Convert.ToString(i))
                End If
            Next i
        ElseIf (Convert.ToInt16(ComboBox_Fecha_Nacimiento_Año.Text) Mod 4) <> 0 And ComboBox_Fecha_Nacimiento_Mes.SelectedItem = 2 Then
            ComboBox_Fecha_Nacimiento_Dia.Items.Clear()
            For i = 1 To 28
                If i < 10 Then
                    ComboBox_Fecha_Nacimiento_Dia.Items.Add("0" + Convert.ToString(i))
                Else
                    ComboBox_Fecha_Nacimiento_Dia.Items.Add(Convert.ToString(i))
                End If
            Next i
        End If

        If Dia_Selecionado > ComboBox_Fecha_Nacimiento_Dia.Items.Count Then
            ComboBox_Fecha_Nacimiento_Dia.SelectedIndex = ComboBox_Fecha_Nacimiento_Dia.Items.Count - 1
        Else
            ComboBox_Fecha_Nacimiento_Dia.SelectedIndex = Dia_Selecionado - 1
        End If

    End Sub

    Private Sub ComboBox_Fecha_Nacimiento_Mes_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox_Fecha_Nacimiento_Mes.SelectedValueChanged
        Dim Dia_Selecionado As Int16
        If ComboBox_Fecha_Nacimiento_Dia.SelectedItem = Nothing Then
            Dia_Selecionado = 0
        Else
            Dia_Selecionado = ComboBox_Fecha_Nacimiento_Dia.SelectedItem
        End If
        If ComboBox_Fecha_Nacimiento_Mes.SelectedItem = 1 Or ComboBox_Fecha_Nacimiento_Mes.SelectedItem = 3 Or ComboBox_Fecha_Nacimiento_Mes.SelectedItem = 5 Or ComboBox_Fecha_Nacimiento_Mes.SelectedItem = 7 Or ComboBox_Fecha_Nacimiento_Mes.SelectedItem = 8 Or ComboBox_Fecha_Nacimiento_Mes.SelectedItem = 10 Or ComboBox_Fecha_Nacimiento_Mes.SelectedItem = 12 Then
            ComboBox_Fecha_Nacimiento_Dia.Items.Clear()
            For i = 1 To 31
                If i < 10 Then
                    ComboBox_Fecha_Nacimiento_Dia.Items.Add("0" + Convert.ToString(i))
                Else
                    ComboBox_Fecha_Nacimiento_Dia.Items.Add(Convert.ToString(i))
                End If
            Next i
        ElseIf ComboBox_Fecha_Nacimiento_Mes.SelectedItem = 4 Or ComboBox_Fecha_Nacimiento_Mes.SelectedItem = 6 Or ComboBox_Fecha_Nacimiento_Mes.SelectedItem = 9 Or ComboBox_Fecha_Nacimiento_Mes.SelectedItem = 11 Then
            ComboBox_Fecha_Nacimiento_Dia.Items.Clear()
            For i = 1 To 30
                If i < 10 Then
                    ComboBox_Fecha_Nacimiento_Dia.Items.Add("0" + Convert.ToString(i))
                Else
                    ComboBox_Fecha_Nacimiento_Dia.Items.Add(Convert.ToString(i))
                End If
            Next i
        ElseIf ComboBox_Fecha_Nacimiento_Mes.SelectedItem = 2 Then
            ComboBox_Fecha_Nacimiento_Dia.Items.Clear()
            If ComboBox_Fecha_Nacimiento_Año.SelectedItem = Nothing Then
                For i = 1 To 29
                    If i < 10 Then
                        ComboBox_Fecha_Nacimiento_Dia.Items.Add("0" + Convert.ToString(i))
                    Else
                        ComboBox_Fecha_Nacimiento_Dia.Items.Add(Convert.ToString(i))
                    End If
                Next i
            Else
                If (Convert.ToInt16(ComboBox_Fecha_Nacimiento_Año.Text) Mod 4) = 0 Then
                    For i = 1 To 29
                        If i < 10 Then
                            ComboBox_Fecha_Nacimiento_Dia.Items.Add("0" + Convert.ToString(i))
                        Else
                            ComboBox_Fecha_Nacimiento_Dia.Items.Add(Convert.ToString(i))
                        End If
                    Next i
                End If
            End If

        End If
        If Dia_Selecionado > ComboBox_Fecha_Nacimiento_Dia.Items.Count Then
            ComboBox_Fecha_Nacimiento_Dia.SelectedIndex = ComboBox_Fecha_Nacimiento_Dia.Items.Count - 1
        Else
            ComboBox_Fecha_Nacimiento_Dia.SelectedIndex = Dia_Selecionado - 1
        End If
    End Sub

    Private Sub Form_Datos_Paciente_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Datos_Paciente_Crear_Actualisar = 0 Then 'Si Datos_Paciente__Crear_Actualisar el valor es 1 se lanza como Alamcenar_Datos_Pacientes

        ElseIf Datos_Paciente_Crear_Actualisar = 1 Then 'Si Datos_Paciente__Crear_Actualisar el valor es 1 se lanza como Alamcenar_Datos_Pacientes
            CheckBox_Nuevo_Paciente.Checked = False
            CheckBox_Nuevo_Paciente.Visible = False
            TextBox_Nombre.Enabled = False

            Label_Fecha_Registro.Visible = False
            Label_Fecha_Registro_Dia.Visible = False
            Label_Fecha_Registro_Mes.Visible = False
            Label_Fecha_Registro_Año.Visible = False
            ComboBox_Fecha_Registro_Dia.Visible = False
            ComboBox_Fecha_Registro_Mes.Visible = False
            ComboBox_Fecha_Registro_Año.Visible = False

            Label_Frecuencia.Visible = False
            TextBox_Frecuencia.Visible = False

            Button_Siguiente.Text = "Modify"
        End If

        ComboBox_Fecha_Nacimiento_Año.SelectedIndex = -1
        ComboBox_Fecha_Nacimiento_Mes.SelectedIndex = -1
        ComboBox_Fecha_Nacimiento_Dia.SelectedIndex = -1

        ComboBox_Fecha_Registro_Año.SelectedIndex = -1
        ComboBox_Fecha_Registro_Mes.SelectedIndex = -1
        ComboBox_Fecha_Registro_Dia.SelectedIndex = -1
        ComboBox_Tamaño_Letra.SelectedIndex = 8
        If Form_Principal.Usuario_Activo.Tipo_Usuario = 1 Then
            Dim Coneccion_Base_Datos As New SqlConnection
            Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
            Dim Pacientes As New DataSet
            Pacientes = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Base_Datos, Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_"))

            ComboBox_Pacientes.Items.Clear()

            For i = 0 To Pacientes.Tables(0).Rows.Count - 1
                ComboBox_Pacientes.Items.Add(Pacientes.Tables(0).Rows(i)(0))
            Next i

        ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
            Dim Coneccion_Base_Datos As New SqlConnection
            Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
            Dim Usuario As DataSet
            Usuario = Class_Funciones_Base_Datos.Tabla_Usuarios_Buscar_Usuarios(Coneccion_Base_Datos, "1")
            ComboBox_Usuario.Items.Clear()

            For i = 0 To Usuario.Tables(0).Rows.Count - 1
                ComboBox_Usuario.Items.Add(Usuario.Tables(0).Rows(i)(0))
            Next i

            If ComboBox_Usuario.Items.Count > 0 Then
                ComboBox_Usuario.SelectedIndex = 0
            End If

        End If

    End Sub

    Private Sub ComboBox_Fecha_Registro_Año_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox_Fecha_Registro_Año.SelectedValueChanged
        Dim Dia_Selecionado As Int16
        If ComboBox_Fecha_Registro_Dia.SelectedItem = Nothing Then
            Dia_Selecionado = 0
        Else
            Dia_Selecionado = ComboBox_Fecha_Registro_Dia.SelectedItem
        End If

        If (Convert.ToInt16(ComboBox_Fecha_Registro_Año.Text) Mod 4) = 0 And ComboBox_Fecha_Registro_Mes.SelectedItem = 2 Then
            ComboBox_Fecha_Registro_Dia.Items.Clear()
            For i = 1 To 29
                If i < 10 Then
                    ComboBox_Fecha_Registro_Dia.Items.Add("0" + Convert.ToString(i))
                Else
                    ComboBox_Fecha_Registro_Dia.Items.Add(Convert.ToString(i))
                End If
            Next i
        ElseIf (Convert.ToInt16(ComboBox_Fecha_Registro_Año.Text) Mod 4) <> 0 And ComboBox_Fecha_Registro_Mes.SelectedItem = 2 Then
            ComboBox_Fecha_Registro_Dia.Items.Clear()
            For i = 1 To 28
                If i < 10 Then
                    ComboBox_Fecha_Registro_Dia.Items.Add("0" + Convert.ToString(i))
                Else
                    ComboBox_Fecha_Registro_Dia.Items.Add(Convert.ToString(i))
                End If
            Next i
        End If

        If Dia_Selecionado > ComboBox_Fecha_Registro_Dia.Items.Count Then
            ComboBox_Fecha_Registro_Dia.SelectedIndex = ComboBox_Fecha_Registro_Dia.Items.Count - 1
        Else
            ComboBox_Fecha_Registro_Dia.SelectedIndex = Dia_Selecionado - 1
        End If
    End Sub

    Private Sub ComboBox_Fecha_Registro_Mes_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox_Fecha_Registro_Mes.SelectedValueChanged
        Dim Dia_Selecionado As Int16
        If ComboBox_Fecha_Registro_Dia.SelectedItem = Nothing Then
            Dia_Selecionado = 0
        Else
            Dia_Selecionado = ComboBox_Fecha_Registro_Dia.SelectedItem
        End If

        If ComboBox_Fecha_Registro_Mes.SelectedItem = 1 Or ComboBox_Fecha_Registro_Mes.SelectedItem = 3 Or ComboBox_Fecha_Registro_Mes.SelectedItem = 5 Or ComboBox_Fecha_Registro_Mes.SelectedItem = 7 Or ComboBox_Fecha_Registro_Mes.SelectedItem = 8 Or ComboBox_Fecha_Registro_Mes.SelectedItem = 10 Or ComboBox_Fecha_Registro_Mes.SelectedItem = 12 Then
            ComboBox_Fecha_Registro_Dia.Items.Clear()
            For i = 1 To 31
                If i < 10 Then
                    ComboBox_Fecha_Registro_Dia.Items.Add("0" + Convert.ToString(i))
                Else
                    ComboBox_Fecha_Registro_Dia.Items.Add(Convert.ToString(i))
                End If
            Next i
        ElseIf ComboBox_Fecha_Registro_Mes.SelectedItem = 4 Or ComboBox_Fecha_Registro_Mes.SelectedItem = 6 Or ComboBox_Fecha_Registro_Mes.SelectedItem = 9 Or ComboBox_Fecha_Registro_Mes.SelectedItem = 11 Then
            ComboBox_Fecha_Registro_Dia.Items.Clear()
            For i = 1 To 30
                If i < 10 Then
                    ComboBox_Fecha_Registro_Dia.Items.Add("0" + Convert.ToString(i))
                Else
                    ComboBox_Fecha_Registro_Dia.Items.Add(Convert.ToString(i))
                End If
            Next i
        ElseIf ComboBox_Fecha_Registro_Mes.SelectedItem = 2 Then
            ComboBox_Fecha_Registro_Dia.Items.Clear()
            If ComboBox_Fecha_Registro_Año.SelectedItem = Nothing Then
                For i = 1 To 29
                    If i < 10 Then
                        ComboBox_Fecha_Registro_Dia.Items.Add("0" + Convert.ToString(i))
                    Else
                        ComboBox_Fecha_Registro_Dia.Items.Add(Convert.ToString(i))
                    End If
                Next i
            Else
                If (Convert.ToInt16(ComboBox_Fecha_Registro_Año.Text) Mod 4) = 0 Then
                    For i = 1 To 29
                        If i < 10 Then
                            ComboBox_Fecha_Registro_Dia.Items.Add("0" + Convert.ToString(i))
                        Else
                            ComboBox_Fecha_Registro_Dia.Items.Add(Convert.ToString(i))
                        End If
                    Next i
                ElseIf (Convert.ToInt16(ComboBox_Fecha_Registro_Año.Text) Mod 4) <> 0 Then
                    ComboBox_Fecha_Registro_Dia.Items.Clear()
                    For i = 1 To 28
                        If i < 10 Then
                            ComboBox_Fecha_Registro_Dia.Items.Add("0" + Convert.ToString(i))
                        Else
                            ComboBox_Fecha_Registro_Dia.Items.Add(Convert.ToString(i))
                        End If
                    Next i
                End If

            End If
        End If
        If Dia_Selecionado > ComboBox_Fecha_Registro_Dia.Items.Count Then
            ComboBox_Fecha_Registro_Dia.SelectedIndex = ComboBox_Fecha_Registro_Dia.Items.Count - 1
        Else
            ComboBox_Fecha_Registro_Dia.SelectedIndex = Dia_Selecionado - 1
        End If
    End Sub

    Private Sub TextBox_Nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Nombre.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Or (e.KeyChar) <> "_" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


    Private Sub TextBox_Peso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Peso.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox_Estatura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Estatura.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox_Tamaño_Letra.SelectedValueChanged
        Dim Tamaño_Letra As New Font(Convert.ToString(ComboBox_Tamaño_Letra.Text), Convert.ToInt16(ComboBox_Tamaño_Letra.Text))
        RichTextBox_Anotaciones_Paciente.Font = Tamaño_Letra


    End Sub

    Private Sub Button_Siguiente_Click(sender As Object, e As EventArgs) Handles Button_Siguiente.Click
        'Si Datos_Paciente_Crear_Actualisar el valor es 0 se lanza como Alamcenar_Registro
        If Datos_Paciente_Crear_Actualisar = 0 Then
            'Validar que no hay campos en blanco
            If (Form_Principal.Usuario_Activo.Tipo_Usuario = 2 And ComboBox_Usuario.Text = "") Or TextBox_Nombre.Text.Trim = "" Or TextBox_Peso.Text = "" Or TextBox_Estatura.Text = "" Or ComboBox_Sexo.Text = "" Or ComboBox_Raza.Text = "" Or ComboBox_Fecha_Nacimiento_Dia.Text = "" Or ComboBox_Fecha_Nacimiento_Mes.Text = "" Or ComboBox_Fecha_Nacimiento_Año.Text = "" Or ComboBox_Fecha_Registro_Dia.Text = "" Or ComboBox_Fecha_Registro_Mes.Text = "" Or ComboBox_Fecha_Registro_Año.Text = "" Or ComboBox_Marca_Paso.Text = "" Or TextBox_Frecuencia.Text = "" Then
                Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                Contraseña_Incorrecta.Form_Mensaje(Me, "Cannot have", " blank fields", "Error in the fields", 0)
            Else
                Dim Usuario As String
                If Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
                    Usuario = ComboBox_Usuario.Text.TrimEnd.Replace(" ", "_")
                Else
                    Usuario = Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_")
                End If

                If CheckBox_Nuevo_Paciente.Checked Then
                    'Validar que el paciente no existe en la base de datos
                    Dim Coneccion_Base_Datos As New SqlConnection
                    Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
                    If Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Validar_Existencia_Paciente(Coneccion_Base_Datos, Usuario, TextBox_Nombre.Text.TrimEnd) = False Then
                        'Incertar el nuevo paciente en la base de datos
                        Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Agregar_Paciente(Coneccion_Base_Datos, Usuario, TextBox_Nombre.Text.TrimEnd, TextBox_Peso.Text.TrimEnd, TextBox_Estatura.Text.TrimEnd, ComboBox_Sexo.Text.TrimEnd, ComboBox_Raza.Text.TrimEnd, ComboBox_Fecha_Nacimiento_Dia.Text.TrimEnd, ComboBox_Fecha_Nacimiento_Mes.Text.TrimEnd, ComboBox_Fecha_Nacimiento_Año.Text.TrimEnd, RichTextBox_Anotaciones_Paciente.Text.TrimEnd, ComboBox_Marca_Paso.Text.TrimEnd)
                        'Datos de la de la tabla Relacion_Registro_Paciente_Usuario
                        Form_Principal.Incertar_Registro.Frecuencia = TextBox_Frecuencia.Text.Trim
                        Form_Principal.Incertar_Registro.Usuario = Usuario.Replace(" ", "_")
                        Form_Principal.Incertar_Registro.Paciente = TextBox_Nombre.Text.Trim
                        Form_Principal.Incertar_Registro.Paciente = Form_Principal.Incertar_Registro.Paciente.Replace(" ", "_")
                        Form_Principal.Incertar_Registro.Fecha_Registro = ComboBox_Fecha_Registro_Dia.Text + "_" + ComboBox_Fecha_Registro_Mes.Text + "_" + ComboBox_Fecha_Registro_Año.Text
                        'Abriendo el form para cargar el registro
                        Dim Cargar_Registro As New Form_Cargar_Registro
                        Cargar_Registro.Show()
                        Me.Close()
                    Else
                        Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                        Contraseña_Incorrecta.Form_Mensaje(Me, "The Patient already exists", "", "Error with the Patient", 0)
                    End If
                Else
                    'Datos de la de la tabla Relacion_Registro_Paciente_Usuario
                    Form_Principal.Incertar_Registro.Frecuencia = TextBox_Frecuencia.Text.Trim
                    Form_Principal.Incertar_Registro.Usuario = Usuario.Replace(" ", "_")
                    Form_Principal.Incertar_Registro.Paciente = TextBox_Nombre.Text.Trim
                    Form_Principal.Incertar_Registro.Paciente = Form_Principal.Incertar_Registro.Paciente.Replace(" ", "_")
                    Form_Principal.Incertar_Registro.Fecha_Registro = ComboBox_Fecha_Registro_Dia.Text + "_" + ComboBox_Fecha_Registro_Mes.Text + "_" + ComboBox_Fecha_Registro_Año.Text

                    'Validar no existe un registro previo del paciente con la misma fecha en la base de datos
                    Dim Coneccion_Base_Datos As New SqlConnection
                    Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
                    If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Validar_Registro(Coneccion_Base_Datos, Form_Principal.Incertar_Registro.Usuario.TrimEnd, Form_Principal.Incertar_Registro.Paciente.TrimEnd, Form_Principal.Incertar_Registro.Fecha_Registro.TrimEnd) = False Then
                        'Incertar el nuevo registro del paciente en la base de datos
                        'Abriendo el form para cargar el registro
                        Dim Cargar_Registro As New Form_Cargar_Registro
                        Cargar_Registro.Show()
                        Me.Close()
                    Else
                        Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                        Contraseña_Incorrecta.Form_Mensaje(Me, "The Record already exists", "", "Record Error", 0)

                    End If
                End If
            End If
        ElseIf Datos_Paciente_Crear_Actualisar = 1 Then     'Si Datos_Paciente__Crear_Actualisar el valor es 1 se lanza como Modificar_Datos_Pacientes

            If (Form_Principal.Usuario_Activo.Tipo_Usuario = 2 And ComboBox_Usuario.Text = "") Or TextBox_Nombre.Text.Trim = "" Or TextBox_Peso.Text = "" Or TextBox_Estatura.Text = "" Or ComboBox_Sexo.Text = "" Or ComboBox_Raza.Text = "" Or ComboBox_Fecha_Nacimiento_Dia.Text = "" Or ComboBox_Fecha_Nacimiento_Mes.Text = "" Or ComboBox_Fecha_Nacimiento_Año.Text = "" Or ComboBox_Marca_Paso.Text = "" Then
                Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Me, "Cannot have", " blank fields", "Error in the fields", 0)
                Else
                Dim Usuario As String
                If Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
                    Usuario = ComboBox_Usuario.Text.TrimEnd
                Else
                    Usuario = Form_Principal.Usuario_Activo.Usuario.TrimEnd
                End If
                Try
                    Dim Coneccion_Base_Datos As New SqlConnection
                    Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
                    Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Actualizar_Datos_Paciente(Coneccion_Base_Datos, Usuario, TextBox_Nombre.Text.TrimEnd, TextBox_Peso.Text.TrimEnd, TextBox_Estatura.Text.TrimEnd, ComboBox_Sexo.Text.TrimEnd, ComboBox_Raza.Text.TrimEnd, ComboBox_Fecha_Nacimiento_Dia.Text.TrimEnd, ComboBox_Fecha_Nacimiento_Mes.Text.TrimEnd, ComboBox_Fecha_Nacimiento_Año.Text, RichTextBox_Anotaciones_Paciente.Text.TrimEnd, ComboBox_Marca_Paso.Text.TrimEnd)
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End If

    End Sub

    Private Sub ComboBox_Usuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Usuario.SelectedIndexChanged
        If Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
            Dim Coneccion_Base_Datos As New SqlConnection
            Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
            Dim Pacientes As New DataSet
            Pacientes = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Base_Datos, ComboBox_Usuario.Text.TrimEnd.Replace(" ", "_"))

            ComboBox_Pacientes.Items.Clear()

            For i = 0 To Pacientes.Tables(0).Rows.Count - 1
                ComboBox_Pacientes.Items.Add(Pacientes.Tables(0).Rows(i)(0))
            Next i

            If ComboBox_Pacientes.Items.Count > 0 Then
                ComboBox_Pacientes.SelectedIndex = 0
            End If

        End If
    End Sub

    Private Sub ComboBox_Pacientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Pacientes.SelectedIndexChanged
        Dim Coneccion_Base_Datos As New SqlConnection
        Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
        Dim Peso_kg, Estatura_cm, Sexo, Raza, Fecha_Nacimiento_Dia, Fecha_Nacimiento_Mes, Fecha_Nacimiento_Año, Detalles_Paciente, Marca_Paso As String
        Dim Usuario As String
        If Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
            Usuario = ComboBox_Usuario.Text.TrimEnd
        Else
            Usuario = Form_Principal.Usuario_Activo.Usuario.TrimEnd
        End If

        Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Datos_Paciente(Coneccion_Base_Datos, Usuario, ComboBox_Pacientes.Text.TrimEnd.Replace(" ", "_"), Peso_kg, Estatura_cm, Sexo, Raza, Fecha_Nacimiento_Dia, Fecha_Nacimiento_Mes, Fecha_Nacimiento_Año, Detalles_Paciente, Marca_Paso)

        TextBox_Nombre.Text = ComboBox_Pacientes.Text.TrimEnd
        TextBox_Peso.Text = Peso_kg
        TextBox_Estatura.Text = Estatura_cm
        ComboBox_Sexo.Text = Sexo
        ComboBox_Raza.Text = Raza
        ComboBox_Fecha_Nacimiento_Dia.Text = Fecha_Nacimiento_Dia
        ComboBox_Fecha_Nacimiento_Mes.Text = Fecha_Nacimiento_Mes
        ComboBox_Fecha_Nacimiento_Año.Text = Fecha_Nacimiento_Año
        RichTextBox_Anotaciones_Paciente.Text = Detalles_Paciente
        ComboBox_Marca_Paso.Text = Marca_Paso
    End Sub

    Private Sub TextBox_Frecuencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Frecuencia.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub



    Private Sub Button_Principal_MouseEnter(sender As Object, e As EventArgs) Handles Button_Siguiente.MouseEnter, Button_Cancelar.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde_Cambio
    End Sub

    Private Sub Button_Principal_MouseLeave(sender As Object, e As EventArgs) Handles Button_Siguiente.MouseLeave, Button_Cancelar.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde
    End Sub

End Class