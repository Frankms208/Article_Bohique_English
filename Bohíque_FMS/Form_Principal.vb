Imports System.Data.SqlClient
Imports System.IO
Public Class Form_Principal
    Public Estado_Registros As New Class_Estado_Registro
    Public Structure Usuario
        Public Tipo_Usuario As Integer
        Public Usuario As String
    End Structure

    Public Structure Respaldo_Temporal_Registro
        Public Usuario As String
        Public Paciente As String
        Public Fecha_Registro As String
        Public Frecuencia As String
    End Structure

    Public Structure Resgistro_Exportacion
        Public Usuario As String
        Public Paciente As String
        Public Fecha_Registro As String
        Public Derivacion As String
    End Structure
    Public Structure Exportacion_Resultados
        Dim Bandera_Sobreescribir_Archivos As Boolean
        Dim Directorio_Almacenamiento As String

        Dim Nombre_Tablas_Existentes_1 As List(Of Resgistro_Exportacion)
        Dim Nombre_Tablas_Existentes_2 As List(Of Resgistro_Exportacion)
        Dim Nombre_Tablas_Existentes_3 As List(Of Resgistro_Exportacion)
        Dim Nombre_Tablas_Existentes_4 As List(Of Resgistro_Exportacion)
        Dim Nombre_Tablas_Existentes_5 As List(Of Resgistro_Exportacion)
        Dim Nombre_Tablas_Existentes_6 As List(Of Resgistro_Exportacion)

        Dim Bandera_Finalizacion_1 As Boolean
        Dim Bandera_Finalizacion_2 As Boolean
        Dim Bandera_Finalizacion_3 As Boolean
        Dim Bandera_Finalizacion_4 As Boolean
        Dim Bandera_Finalizacion_5 As Boolean
        Dim Bandera_Finalizacion_6 As Boolean
    End Structure
    Public Exportacion_Resultados_Calculados As Exportacion_Resultados

    'Public Tablas_Exportar_Complejo_QRS As String = "DII___" + "Complejo_QRS"
    'Public Tablas_Exportar_Onda_T As String = "DII___" + "Onda_T"

    Public Tablas_Exportar_Complejo_QRS As String = "Complejo_QRS"
    Public Tablas_Exportar_Onda_T As String = "Onda_T"
    Public Tablas_Exportar_Onda_P As String = "Onda_P"
    Public Tablas_Exportar_Intervalo_R_R As String = "Intervalo_R_R"
    Public Tablas_Exportar_Intervalo_Q_T As String = "Intervalo_Q_T"
    Public Tablas_Exportar_Intervalo_P_R As String = "Intervalo_P_R"

    Public Tablas_No_Exportar As String = "Temp"
    Public Usuario_Activo As Usuario
    Public Incertar_Registro As Respaldo_Temporal_Registro
    'Cntrol Modulos para grafcar activos
    Public Modulo_Graficar As New List(Of UserControl_Modulo_Graficar)
    Public Sub Seleccion_Usuario_Activo(Tipo_Usuario As Integer, Usuario As String)
        Usuario_Activo.Tipo_Usuario = Tipo_Usuario
        Usuario_Activo.Usuario = Usuario
        If Usuario_Activo.Tipo_Usuario = 0 Then
            'Usuarios
            Button_Modificar_Contraseña.Visible = False
            Button_Crear_Usuario.Visible = False
            Button_Eliminar_Usuario.Visible = False
            'Registro
            Button_Incertar_Registro.Visible = False
            Button_Almacenar_Multiples_Registros.Visible = False
            Button_Eliminar_Registro.Visible = False
            Button_Modificar_Datos_Paciente.Visible = False
            Button_Eliminar_Paciente.Visible = False
            'Heramientas
            Button_Analizis_Registro.Visible = False
            Button_Agregar_Grafica.Visible = False
            Button_Limpiar_Temporales.Visible = False
            Button_Exportar_Resultados.Visible = False
            'Controles Especiales
            Button_Optimizar_Base_Datos.Visible = False
            Button_Crear_Base_Datos.Visible = False
            Button_Reiniciar_Base_Datos.Visible = False


            FlowLayoutPanel_Principal.Width = 70
            FlowLayoutPanel_Registro.Width = 0
            FlowLayoutPanel_Herramientas.Width = 0
            FlowLayoutPanel_Control_Especial.Width = 95

        ElseIf Usuario_Activo.Tipo_Usuario = 1 Then
            'Usuarios
            Button_Modificar_Contraseña.Visible = True
            Button_Crear_Usuario.Visible = False
            Button_Eliminar_Usuario.Visible = False
            'Registro
            Button_Incertar_Registro.Visible = True
            Button_Almacenar_Multiples_Registros.Visible = True
            Button_Eliminar_Registro.Visible = True
            Button_Modificar_Datos_Paciente.Visible = True
            Button_Eliminar_Paciente.Visible = True
            'Heramientas
            Button_Analizis_Registro.Visible = True
            Button_Agregar_Grafica.Visible = True
            Button_Limpiar_Temporales.Visible = True
            Button_Exportar_Resultados.Visible = True
            'Controles Especiales
            Button_Optimizar_Base_Datos.Visible = True
            Button_Crear_Base_Datos.Visible = False
            Button_Reiniciar_Base_Datos.Visible = False

            FlowLayoutPanel_Principal.Width = 163
            FlowLayoutPanel_Registro.Width = 450
            FlowLayoutPanel_Herramientas.Width = 360
            FlowLayoutPanel_Control_Especial.Width = 205
        ElseIf Usuario_Activo.Tipo_Usuario = 2 Then
            'Usuarios
            Button_Modificar_Contraseña.Visible = True
            Button_Crear_Usuario.Visible = True
            Button_Eliminar_Usuario.Visible = True
            'Registro
            Button_Incertar_Registro.Visible = True
            Button_Almacenar_Multiples_Registros.Visible = True
            Button_Eliminar_Registro.Visible = True
            Button_Modificar_Datos_Paciente.Visible = True
            Button_Eliminar_Paciente.Visible = True
            'Heramientas
            Button_Analizis_Registro.Visible = True
            Button_Agregar_Grafica.Visible = True
            Button_Limpiar_Temporales.Visible = True
            Button_Exportar_Resultados.Visible = True
            'Controles Especiales
            Button_Optimizar_Base_Datos.Visible = True
            Button_Crear_Base_Datos.Visible = True
            Button_Reiniciar_Base_Datos.Visible = True

            FlowLayoutPanel_Principal.Width = 303
            FlowLayoutPanel_Registro.Width = 450
            FlowLayoutPanel_Herramientas.Width = 360
            FlowLayoutPanel_Control_Especial.Width = 410
        End If
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Hide()
        Dim Pantalla_Inicio As New Form_Inicio
        Pantalla_Inicio.Show()
        Me.Enabled = False
        Dim Archivo_Lectura As StreamReader
        Dim Leer_Fila, Direccion_Base_Datos As String
        'Compruebo si ahy algun archivo pendiente a de eliminar
        If My.Computer.FileSystem.FileExists(Application.UserAppDataPath + "\Eliminar.txt") Then
            Dim Archivo As StreamReader
            Dim Leer_datos As New List(Of String)
            'Abro el archivo "Eliminar.txt" para buscar las direciones de las archivoas a eliminar
            Archivo = New StreamReader(Application.UserAppDataPath + "\Eliminar.txt")
            Leer_Fila = Archivo.ReadLine()
            While Leer_Fila <> Nothing
                Try
                    'Valido si existe el archivi y lo Elimino
                    If My.Computer.FileSystem.FileExists(Leer_Fila) Then
                        System.IO.File.Delete(Leer_Fila)
                    End If
                Catch ex As Exception
                    'si no se puede eliminar el archibo lo guardo para intentar eliminarlo posterior men te 
                    Leer_datos.Add(Leer_Fila)
                End Try
                Leer_Fila = Archivo.ReadLine()
            End While
            Archivo.Close()
            'Borro el archivo Eliminar.txt
            System.IO.File.Delete(Application.UserAppDataPath + "\Eliminar.txt")
            'Compruebo si ahy archivos pendientes a eliminar
            If Leer_datos.Count > 0 Then
                Dim Archivo_Eliminar As System.IO.StreamWriter
                Archivo_Eliminar = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Eliminar.txt", True)
                'Alamaceno la direcion de los archivos
                For index = 0 To Leer_datos.Count - 1
                    Archivo_Eliminar.WriteLine(Leer_datos.Item(index).ToString)
                Next
                Archivo_Eliminar.Close()
            End If
        End If
        'Pregunto si existe el archivo Direccion_Base_Datos.txt
        If My.Computer.FileSystem.FileExists(Application.UserAppDataPath + "\Direccion_Base_Datos.txt") = True Then
            Archivo_Lectura = New StreamReader(Application.UserAppDataPath + "\Direccion_Base_Datos.txt")
            'Si existe el archivo leo la direccion de la base de datos
            Leer_Fila = Archivo_Lectura.ReadLine()
            Archivo_Lectura.Close()
        Else
            Leer_Fila = Nothing
        End If
        'Si la direccion de la base de datos esta bacia pido qu se selcione una carpeta para almacenarla
        If Leer_Fila = Nothing Then
            While FolderBrowserDialog_Ubicacion_Base_Datos.ShowDialog() <> DialogResult.OK
                Const message As String = "Tiene que selecionar la Ubicacion de la Base de Datos"
                Const caption As String = "Error en la Base de Datos"
                Dim Result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End While
            Direccion_Base_Datos = FolderBrowserDialog_Ubicacion_Base_Datos.SelectedPath
            'Actualizo la direccion de la base de datos
            Class_Funciones_Base_Datos.Actualizar_Direccion_Base_Datos(Direccion_Base_Datos)
        Else
            'Actualizo la direccion de la base de datos
            Class_Funciones_Base_Datos.Actualizar_Direccion_Base_Datos(Leer_Fila)
        End If
        Dim Coneccion_Base_Datos As New SqlConnection
        Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
        'Pregunto si la base de datos tiene problemas, para reinicairla o no 
        If Class_Funciones_Base_Datos.Estado_Base_Datos(Coneccion_Base_Datos) = False Then
            'Reinicio la base de datos si tine problemas 
            Class_Funciones_Base_Datos.Crear_Base_Datos_Principal(Coneccion_Base_Datos)
        End If
        'Class_Funciones_Base_Datos.Modificar_TamanoMax_Base_Datos(Coneccion, "10TB")

        Seleccion_Usuario_Activo(0, "Invitado")
        Incertar_Registro.Usuario = "Invitado"
        Incertar_Registro.Paciente = "Prueba_Preuba"
        Incertar_Registro.Fecha_Registro = "21_02_2020"


        Me.Enabled = True


    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button_Cambiar_Usuario.Click
        Dim Cambiar_Usuario As New Form_Selecion_Usuario
        Cambiar_Usuario.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button_Crear_Usuario_Click(sender As Object, e As EventArgs) Handles Button_Crear_Usuario.Click
        Dim Crear_Usuario As New Form_Crear_Usuario
        Crear_Usuario.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button_Editar_Usuario_Click(sender As Object, e As EventArgs) Handles Button_Modificar_Contraseña.Click
        Dim Modificar_Contraseña As New Form_Modificar_Contraseña
        Modificar_Contraseña.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button_Eliminar_Usuario_Click(sender As Object, e As EventArgs) Handles Button_Eliminar_Usuario.Click
        Dim Eliminar_Usuario As New Form_Eliminar_Usuario
        Eliminar_Usuario.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button_Incertar_Registro_Click(sender As Object, e As EventArgs) Handles Button_Incertar_Registro.Click
        Dim Datos_Paciente As New Form_Datos_Paciente
        Datos_Paciente.Show()
        If Usuario_Activo.Tipo_Usuario = 1 Or Usuario_Activo.Tipo_Usuario = 0 Then
            Datos_Paciente.ComboBox_Usuario.Visible = False
            Datos_Paciente.Label_Usuario.Visible = False
        End If
        Datos_Paciente.Datos_Paciente_Crear_Actualisar = 0
        Me.Enabled = False
    End Sub

    Private Sub Button_Eliminar_Registro_Click(sender As Object, e As EventArgs) Handles Button_Eliminar_Registro.Click
        Dim Eliminar_Registro As New Form_Eliminar_Registro
        Eliminar_Registro.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button_Modificar_Datos_Paciente_Click_2(sender As Object, e As EventArgs) Handles Button_Modificar_Datos_Paciente.Click
        Dim Datos_Paciente As New Form_Datos_Paciente
        Datos_Paciente.Show()
        If Usuario_Activo.Tipo_Usuario = 1 Or Usuario_Activo.Tipo_Usuario = 0 Then
            Datos_Paciente.ComboBox_Usuario.Visible = False
            Datos_Paciente.Label_Usuario.Visible = False
        End If
        Datos_Paciente.Datos_Paciente_Crear_Actualisar = 1
        Me.Enabled = False
    End Sub


    Private Sub Button_Eliminar_Paciente_Click(sender As Object, e As EventArgs) Handles Button_Eliminar_Paciente.Click
        Dim Eliminar_Paciente As New Form_Eliminar_Paciente
        Eliminar_Paciente.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button_Agregar_Grafica_Click_2(sender As Object, e As EventArgs) Handles Button_Agregar_Grafica.Click
        Dim Modulo_Graficar_Temporal As New UserControl_Modulo_Graficar

        SplitContainer_Principal.Panel2.Controls.Add(Modulo_Graficar_Temporal)
        Modulo_Graficar_Temporal.Anchor = AnchorStyles.Left And AnchorStyles.Right
        Modulo_Graficar_Temporal.Dock = DockStyle.Top
        Modulo_Graficar_Temporal.Location = New Point(0, 400)
        Modulo_Graficar.Add(Modulo_Graficar_Temporal)
    End Sub

    Private Sub Button_Analizis_Registro_Click(sender As Object, e As EventArgs) Handles Button_Analizis_Registro.Click
        Dim Modulo_Analizis As New UserControl_Modulo_Analicis_Señal

        SplitContainer_Principal.Panel2.Controls.Add(Modulo_Analizis)
        Modulo_Analizis.Anchor = AnchorStyles.Left And AnchorStyles.Right
        Modulo_Analizis.Dock = DockStyle.Top
        Modulo_Analizis.Location = New Point(0, 400)
    End Sub
    Public Function Comparar(ByVal a As Double) As Boolean
        Return a = 9
        'Dim i As Boolean = False

        'If a > 0 Then

        '    i = True

        'End If

        'Return i

    End Function

    Private Sub Button_Limpiar_Temporales_Click(sender As Object, e As EventArgs) Handles Button_Limpiar_Temporales.Click
        Dim Coneccion_Base_Datos As New SqlConnection
        Me.Enabled = False
        Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
        If Usuario_Activo.Tipo_Usuario = 2 Then
            Dim Usuarios As New DataSet
            Usuarios = Class_Funciones_Base_Datos.Tabla_Usuarios_Buscar_Usuarios(Coneccion_Base_Datos, "1")
            For Index_Usuarios = 0 To Usuarios.Tables(0).Rows.Count - 1
                Dim Paciente As DataSet
                Paciente = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Base_Datos, Usuarios.Tables(0).Rows(Index_Usuarios)(0))
                For Index_Paciente = 0 To Paciente.Tables(0).Rows.Count - 1
                    Dim Registros As DataSet
                    Registros = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Base_Datos, Usuarios.Tables(0).Rows(Index_Usuarios)(0), Paciente.Tables(0).Rows(Index_Paciente)(0))
                    For Index_Registros = 0 To Registros.Tables(0).Rows.Count - 1
                        Dim Derivaciones As List(Of String)
                        Derivaciones = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Derivaciones_Registro(Coneccion_Base_Datos, Usuarios.Tables(0).Rows(Index_Usuarios)(0), Paciente.Tables(0).Rows(Index_Paciente)(0), Registros.Tables(0).Rows(Index_Registros)(0))
                        For Index_Derivaciones = 0 To Derivaciones.Count - 1
                            Dim Coneccion_Registro As New SqlConnection
                            Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuarios.Tables(0).Rows(Index_Usuarios)(0), Paciente.Tables(0).Rows(Index_Paciente)(0), Registros.Tables(0).Rows(Index_Registros)(0), Derivaciones.Item(Index_Derivaciones).ToString)
                            Dim Tablas_Existentes As New DataSet
                            Tablas_Existentes = Class_Funciones_Base_Datos.Tabla_Todas_Existentes(Coneccion_Registro)
                            For Index_Tablas = 0 To Tablas_Existentes.Tables(0).Rows.Count - 1
                                If InStr(Tablas_Existentes.Tables(0).Rows(Index_Tablas)(0), "Temp") <> 0 Then
                                    Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion_Registro, Tablas_Existentes.Tables(0).Rows(Index_Tablas)(0))
                                End If
                            Next Index_Tablas
                            Dim Base_Datos_Eliminar As String
                            Base_Datos_Eliminar = Usuarios.Tables(0).Rows(Index_Usuarios)(0) + "___" + Paciente.Tables(0).Rows(Index_Paciente)(0) + "___" + Registros.Tables(0).Rows(Index_Registros)(0) + "___" + Derivaciones.Item(Index_Derivaciones).ToString
                            Class_Funciones_Base_Datos.Eliminar_Base_Datos(Base_Datos_Eliminar + "___Filtrado_Temp")
                            Class_Funciones_Base_Datos.Eliminar_Base_Datos(Base_Datos_Eliminar + "___Transformada_Wavelet_Complejo_QRS_Temp")
                            Class_Funciones_Base_Datos.Eliminar_Base_Datos(Base_Datos_Eliminar + "___Transformada_Wavelet_Onda_PT_Busqueda_Temp")
                            Class_Funciones_Base_Datos.Eliminar_Base_Datos(Base_Datos_Eliminar + "___Transformada_Wavelet_Onda_PT_Correcion_Temp")
                            Class_Funciones_Base_Datos.Eliminar_Base_Datos("Base_Datos_Filtro_Temp")
                        Next Index_Derivaciones
                    Next Index_Registros
                Next Index_Paciente
            Next Index_Usuarios
        ElseIf Usuario_Activo.Tipo_Usuario = 1 Then
            Dim Usuarios As String = Usuario_Activo.Usuario
            Usuarios = Class_Funciones_Base_Datos.Tabla_Usuarios_Buscar_Usuarios(Coneccion_Base_Datos, "1")
            Dim Paciente As DataSet
            Paciente = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Base_Datos, Usuarios)
            For Index_Paciente = 0 To Paciente.Tables(0).Rows.Count - 1
                Dim Registros As DataSet
                Registros = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Base_Datos, Usuarios, Paciente.Tables(0).Rows(Index_Paciente)(0))
                For Index_Registros = 0 To Registros.Tables(0).Rows.Count - 1
                    Dim Derivaciones As List(Of String)
                    Derivaciones = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Derivaciones_Registro(Coneccion_Base_Datos, Usuarios, Paciente.Tables(0).Rows(Index_Paciente)(0), Registros.Tables(0).Rows(Index_Registros)(0))
                    For Index_Derivaciones = 0 To Derivaciones.Count - 1
                        Dim Coneccion_Registro As New SqlConnection
                        Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuarios, Paciente.Tables(0).Rows(Index_Paciente)(0), Registros.Tables(0).Rows(Index_Registros)(0), Derivaciones.Item(Index_Derivaciones).ToString)
                        Dim Tablas_Existentes As New DataSet
                        Tablas_Existentes = Class_Funciones_Base_Datos.Tabla_Todas_Existentes(Coneccion_Registro)
                        For Index_Tablas = 0 To Tablas_Existentes.Tables(0).Rows.Count - 1
                            If InStr(Tablas_Existentes.Tables(0).Rows(Index_Tablas)(0), "Temp") <> 0 Then
                                Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion_Registro, Tablas_Existentes.Tables(0).Rows(Index_Tablas)(0))
                            End If
                        Next Index_Tablas
                        Dim Base_Datos_Eliminar As String
                        Base_Datos_Eliminar = Usuarios + "___" + Paciente.Tables(0).Rows(Index_Paciente)(0) + "___" + Registros.Tables(0).Rows(Index_Registros)(0) + "___" + Derivaciones.Item(Index_Derivaciones).ToString
                        Class_Funciones_Base_Datos.Eliminar_Base_Datos(Base_Datos_Eliminar + "___Filtrado_Temp")
                        Class_Funciones_Base_Datos.Eliminar_Base_Datos(Base_Datos_Eliminar + "___Transformada_Wavelet_Complejo_QRS_Temp")
                        Class_Funciones_Base_Datos.Eliminar_Base_Datos(Base_Datos_Eliminar + "___Transformada_Wavelet_Onda_PT_Busqueda_Temp")
                        Class_Funciones_Base_Datos.Eliminar_Base_Datos(Base_Datos_Eliminar + "___Transformada_Wavelet_Onda_PT_Correcion_Temp")
                        Class_Funciones_Base_Datos.Eliminar_Base_Datos("Base_Datos_Filtro_Temp")

                    Next Index_Derivaciones
                Next Index_Registros

            Next Index_Paciente
        End If


        '    Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion_Base_Datos, "Registro_Filtrado")
        'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion_Base_Datos, "Tabla_QRS")
        'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion_Base_Datos, "Tabla_Onda_T")
        'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion_Base_Datos, "Transformada_Wavelet")
        'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion_Base_Datos, "Tabla_Transformada_Wavelet")

        Dim Contraseña_Incorrecta As New Form_Mensaje_Error
        Contraseña_Incorrecta.Form_Mensaje(Me, "Temporary Cleaning Completed", "", "Temporary Cleaning Completed", 1)
        Me.Enabled = True
    End Sub

    Private Sub Button_Exportar_Resultados_Click(sender As Object, e As EventArgs) Handles Button_Exportar_Resultados.Click
        'Busqueda de la uvicacion
        Me.Enabled = False
        If FolderBrowserDialog_Buscar_Carpeta_Registros.ShowDialog() = DialogResult.OK Then
            'filesListBox.Clear()
            Exportacion_Resultados_Calculados.Directorio_Almacenamiento = FolderBrowserDialog_Buscar_Carpeta_Registros.SelectedPath
            Dim Coneccion_Base_Datos As New SqlConnection
            Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
            Dim Bandera_Sobreescribir_Archivos As Boolean = True
            Dim Cont_Registros As Int32 = 0

            Dim Nombre_Tablas_Existentes_1 As New List(Of Resgistro_Exportacion)
            Dim Nombre_Tablas_Existentes_2 As New List(Of Resgistro_Exportacion)
            Dim Nombre_Tablas_Existentes_3 As New List(Of Resgistro_Exportacion)
            Dim Nombre_Tablas_Existentes_4 As New List(Of Resgistro_Exportacion)
            Dim Nombre_Tablas_Existentes_5 As New List(Of Resgistro_Exportacion)
            Dim Nombre_Tablas_Existentes_6 As New List(Of Resgistro_Exportacion)

            Dim Nombre_Tablas_Existentes As New DataSet
            Nombre_Tablas_Existentes = Class_Funciones_Base_Datos.Tabla_Todas_Existentes(Coneccion_Base_Datos)

            Const message As String = "Do you want to Overwrite the Files in the Folder"
            Const caption As String = "Overwrite Files"
            Dim Result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (Result = DialogResult.No) Then
                Bandera_Sobreescribir_Archivos = False
            End If
            Exportacion_Resultados_Calculados.Bandera_Finalizacion_1 = True
            Exportacion_Resultados_Calculados.Bandera_Finalizacion_2 = True
            Exportacion_Resultados_Calculados.Bandera_Finalizacion_3 = True
            Exportacion_Resultados_Calculados.Bandera_Finalizacion_4 = True
            Exportacion_Resultados_Calculados.Bandera_Finalizacion_5 = True
            Exportacion_Resultados_Calculados.Bandera_Finalizacion_6 = True

            If Usuario_Activo.Tipo_Usuario = 2 Then
                Dim Usuarios As New DataSet
                Usuarios = Class_Funciones_Base_Datos.Tabla_Usuarios_Buscar_Usuarios(Coneccion_Base_Datos, "1")
                For Index_Usuarios = 0 To Usuarios.Tables(0).Rows.Count - 1
                    Dim Paciente As DataSet
                    Paciente = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Base_Datos, Usuarios.Tables(0).Rows(Index_Usuarios)(0))
                    For Index_Paciente = 0 To Paciente.Tables(0).Rows.Count - 1
                        Dim Registros As DataSet
                        Registros = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Base_Datos, Usuarios.Tables(0).Rows(Index_Usuarios)(0), Paciente.Tables(0).Rows(Index_Paciente)(0))
                        For Index_Registros = 0 To Registros.Tables(0).Rows.Count - 1
                            Dim Derivaciones As List(Of String)
                            Derivaciones = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Derivaciones_Registro(Coneccion_Base_Datos, Usuarios.Tables(0).Rows(Index_Usuarios)(0), Paciente.Tables(0).Rows(Index_Paciente)(0), Registros.Tables(0).Rows(Index_Registros)(0))
                            For Index_Derivaciones = 0 To Derivaciones.Count - 1
                                Dim Registros_Existentes As New Resgistro_Exportacion
                                Registros_Existentes.Usuario = Usuarios.Tables(0).Rows(Index_Usuarios)(0)
                                Registros_Existentes.Paciente = Paciente.Tables(0).Rows(Index_Paciente)(0)
                                Registros_Existentes.Fecha_Registro = Registros.Tables(0).Rows(Index_Registros)(0)
                                Registros_Existentes.Derivacion = Derivaciones.Item(Index_Derivaciones).ToString
                                Cont_Registros = Cont_Registros + 1
                                If (Cont_Registros Mod 6) = 1 Then
                                    Nombre_Tablas_Existentes_1.Add(Registros_Existentes)
                                    Exportacion_Resultados_Calculados.Bandera_Finalizacion_1 = False
                                ElseIf (Cont_Registros Mod 6) = 2 Then
                                    Nombre_Tablas_Existentes_2.Add(Registros_Existentes)
                                    Exportacion_Resultados_Calculados.Bandera_Finalizacion_2 = False
                                ElseIf (Cont_Registros Mod 6) = 3 Then
                                    Nombre_Tablas_Existentes_3.Add(Registros_Existentes)
                                    Exportacion_Resultados_Calculados.Bandera_Finalizacion_3 = False
                                ElseIf (Cont_Registros Mod 6) = 4 Then
                                    Nombre_Tablas_Existentes_4.Add(Registros_Existentes)
                                    Exportacion_Resultados_Calculados.Bandera_Finalizacion_4 = False
                                ElseIf (Cont_Registros Mod 6) = 5 Then
                                    Nombre_Tablas_Existentes_5.Add(Registros_Existentes)
                                    Exportacion_Resultados_Calculados.Bandera_Finalizacion_5 = False
                                Else
                                    Nombre_Tablas_Existentes_6.Add(Registros_Existentes)
                                    Exportacion_Resultados_Calculados.Bandera_Finalizacion_6 = False
                                End If
                            Next Index_Derivaciones
                        Next Index_Registros
                    Next Index_Paciente
                Next Index_Usuarios
            ElseIf Usuario_Activo.Tipo_Usuario = 1 Then
                Dim Usuarios As String = Usuario_Activo.Usuario
                Usuarios = Class_Funciones_Base_Datos.Tabla_Usuarios_Buscar_Usuarios(Coneccion_Base_Datos, "1")
                Dim Paciente As DataSet
                Paciente = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Base_Datos, Usuarios)
                For Index_Paciente = 0 To Paciente.Tables(0).Rows.Count - 1
                    Dim Registros As DataSet
                    Registros = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Base_Datos, Usuarios, Paciente.Tables(0).Rows(Index_Paciente)(0))
                    For Index_Registros = 0 To Registros.Tables(0).Rows.Count - 1
                        Dim Derivaciones As List(Of String)
                        Derivaciones = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Derivaciones_Registro(Coneccion_Base_Datos, Usuarios, Paciente.Tables(0).Rows(Index_Paciente)(0), Registros.Tables(0).Rows(Index_Registros)(0))
                        For Index_Derivaciones = 0 To Derivaciones.Count - 1
                            Dim Registros_Existentes As New Resgistro_Exportacion
                            Registros_Existentes.Usuario = Usuarios
                            Registros_Existentes.Paciente = Paciente.Tables(0).Rows(Index_Paciente)(0)
                            Registros_Existentes.Fecha_Registro = Registros.Tables(0).Rows(Index_Registros)(0)
                            Registros_Existentes.Derivacion = Derivaciones.Item(Index_Derivaciones).ToString
                            Cont_Registros = Cont_Registros + 1
                            If (Cont_Registros Mod 6) = 1 Then
                                Nombre_Tablas_Existentes_1.Add(Registros_Existentes)
                                Exportacion_Resultados_Calculados.Bandera_Finalizacion_1 = False
                            ElseIf (Cont_Registros Mod 6) = 2 Then
                                Nombre_Tablas_Existentes_2.Add(Registros_Existentes)
                                Exportacion_Resultados_Calculados.Bandera_Finalizacion_2 = False
                            ElseIf (Cont_Registros Mod 6) = 3 Then
                                Nombre_Tablas_Existentes_3.Add(Registros_Existentes)
                                Exportacion_Resultados_Calculados.Bandera_Finalizacion_3 = False
                            ElseIf (Cont_Registros Mod 6) = 4 Then
                                Nombre_Tablas_Existentes_4.Add(Registros_Existentes)
                                Exportacion_Resultados_Calculados.Bandera_Finalizacion_4 = False
                            ElseIf (Cont_Registros Mod 6) = 5 Then
                                Nombre_Tablas_Existentes_5.Add(Registros_Existentes)
                                Exportacion_Resultados_Calculados.Bandera_Finalizacion_5 = False
                            Else
                                Nombre_Tablas_Existentes_6.Add(Registros_Existentes)
                                Exportacion_Resultados_Calculados.Bandera_Finalizacion_6 = False
                            End If

                        Next Index_Derivaciones
                    Next Index_Registros
                Next Index_Paciente
            End If
            Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1 = Nombre_Tablas_Existentes_1
            Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2 = Nombre_Tablas_Existentes_2
            Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3 = Nombre_Tablas_Existentes_3
            Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4 = Nombre_Tablas_Existentes_4
            Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5 = Nombre_Tablas_Existentes_5
            Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6 = Nombre_Tablas_Existentes_6

            Exportacion_Resultados_Calculados.Bandera_Sobreescribir_Archivos = Bandera_Sobreescribir_Archivos
            If Exportacion_Resultados_Calculados.Bandera_Finalizacion_1 = False Then
                BackgroundWorker_Exportar_Resultados_1.RunWorkerAsync()
            End If
            If Exportacion_Resultados_Calculados.Bandera_Finalizacion_2 = False Then
                BackgroundWorker_Exportar_Resultados_2.RunWorkerAsync()
            End If
            If Exportacion_Resultados_Calculados.Bandera_Finalizacion_3 = False Then
                BackgroundWorker_Exportar_Resultados_3.RunWorkerAsync()
            End If
            If Exportacion_Resultados_Calculados.Bandera_Finalizacion_4 = False Then
                BackgroundWorker_Exportar_Resultados_4.RunWorkerAsync()
            End If
            If Exportacion_Resultados_Calculados.Bandera_Finalizacion_5 = False Then
                BackgroundWorker_Exportar_Resultados_5.RunWorkerAsync()
            End If
            If Exportacion_Resultados_Calculados.Bandera_Finalizacion_6 = False Then
                BackgroundWorker_Exportar_Resultados_6.RunWorkerAsync()
            End If

        End If



    End Sub

    Private Sub Button_Almacenar_Multiples_Registros_Click(sender As Object, e As EventArgs) Handles Button_Almacenar_Multiples_Registros.Click
        Me.Enabled = False
        Const Max_Cantida_Datos_Cargados = 200000
        Dim filesListBox As New List(Of String)
        Dim Usuario, Paciente, Fecha_Registro, Frecuencia, Peso_kg, Estatura_cm, Sexo, Raza, Fecha_Nacimiento_Dia, Fecha_Nacimiento_Mes, Fecha_Nacimiento_Año, Detalles_Paciente, Marca_Paso As String
        Dim Coneccion_Base_Datos As New SqlConnection
        Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
        'Desactivo la ventana mientras cargo los registros
        Me.Enabled = False
        If Usuario_Activo.Tipo_Usuario = 1 Then
            Usuario = Usuario_Activo.Usuario
        Else
            Usuario = "FrankMS"
        End If
        'Busqueda de la uvicacion
        If FolderBrowserDialog_Buscar_Carpeta_Registros.ShowDialog() = DialogResult.OK Then
            filesListBox.Clear()
            Dim fileNames = My.Computer.FileSystem.GetFiles(FolderBrowserDialog_Buscar_Carpeta_Registros.SelectedPath, FileIO.SearchOption.SearchTopLevelOnly)
            For Each fileName As String In fileNames
                filesListBox.Add(fileName)
            Next
        End If
        If filesListBox.Count > 0 Then
            Dim Bandera_Ultimo_Dato As Boolean
            Dim Columnas() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            'Dim Dirreccion As String = "C:\Users\frank\Dropbox\Dropbox\Tesis Doctorado\Base_Datos_Inicio_QRS-Final_T\Archivo Salida.xlsx"
            'Dim Direccion As String = FolderBrowserDialog_Buscar_Carpeta_Registros.SelectedPath
            Dim oExcel As Object
            Dim xlLibro As Object
            Dim xlHoja_Datos_del_Paciente As Object
            Dim xlHoja_Registro As Object
            Dim varMatriz_Datos_del_Paciente
            Dim varMatriz_Registro
            Dim varMatriz_Registro_Derivacion
            Dim Primera_Fila, UltimaFila, PrimeraColumna, UltimaColumna As Int64
            Dim ListBox_Columnas As New List(Of String)
            'Tabla temporal para almacenar los datos antes de enviarlos a la base de datos

            Dim Tabla_registro As String = "Prueba"
            'Dim Coneccion_Base_Datos As New SqlConnection
            'Coneccion_Base_Datos = Class_Funciones_Base_Datos.Coneccion_Registro()


            For Index = 0 To filesListBox.Count - 1
                'Descarto los archivos temporales
                If filesListBox.Item(Index).ToString.Contains("~$") = False Then
                    Try
                        'abrir programa Excel
                        oExcel = CreateObject("Excel.Application")
                        ' oExcel.Visible = True
                        ' oExcel.UserControl = True
                        'abrir el archivo Excel
                        xlLibro = oExcel.Workbooks.Open(filesListBox.Item(Index).ToString)
                        '-----------------------------------------------------------------------------------------------------------
                        'Leer los datos del paciente
                        '-----------------------------------------------------------------------------------------------------------
                        xlHoja_Datos_del_Paciente = oExcel.Worksheets("Patient Data")
                        varMatriz_Datos_del_Paciente = xlHoja_Datos_del_Paciente.Range("A2:N2").Value

                        Paciente = varMatriz_Datos_del_Paciente(1, 1)
                        Paciente = Paciente.Replace(" ", "_")
                        If varMatriz_Datos_del_Paciente(1, 10) < 10 Then
                            Fecha_Registro = "0" + Convert.ToString(varMatriz_Datos_del_Paciente(1, 10)) + "_"
                        Else
                            Fecha_Registro = Convert.ToString(varMatriz_Datos_del_Paciente(1, 10)) + "_"
                        End If
                        If varMatriz_Datos_del_Paciente(1, 11) < 10 Then
                            Fecha_Registro = Fecha_Registro + "0" + Convert.ToString(varMatriz_Datos_del_Paciente(1, 11)) + "_"
                        Else
                            Fecha_Registro = Fecha_Registro + Convert.ToString(varMatriz_Datos_del_Paciente(1, 11)) + "_"
                        End If
                        Fecha_Registro = Fecha_Registro + Convert.ToString(varMatriz_Datos_del_Paciente(1, 12))

                        Tabla_registro = Usuario + "___" + Paciente + "___" + Fecha_Registro
                        Frecuencia = Convert.ToString(varMatriz_Datos_del_Paciente(1, 13))
                        Peso_kg = Convert.ToString(varMatriz_Datos_del_Paciente(1, 5))
                        Estatura_cm = Convert.ToString(varMatriz_Datos_del_Paciente(1, 6))
                        Sexo = Convert.ToString(varMatriz_Datos_del_Paciente(1, 7))
                        Raza = Convert.ToString(varMatriz_Datos_del_Paciente(1, 8))
                        Marca_Paso = Convert.ToString(varMatriz_Datos_del_Paciente(1, 9))
                        If varMatriz_Datos_del_Paciente(1, 14) <> Nothing Then
                            Detalles_Paciente = Convert.ToString(varMatriz_Datos_del_Paciente(1, 14))
                        Else
                            Detalles_Paciente = ""
                        End If

                        If varMatriz_Datos_del_Paciente(1, 2) < 10 Then
                            Fecha_Nacimiento_Dia = "0" + Convert.ToString(varMatriz_Datos_del_Paciente(1, 2))
                        Else
                            Fecha_Nacimiento_Dia = Convert.ToString(varMatriz_Datos_del_Paciente(1, 2))
                        End If
                        If varMatriz_Datos_del_Paciente(1, 3) < 10 Then
                            Fecha_Nacimiento_Mes = "0" + Convert.ToString(varMatriz_Datos_del_Paciente(1, 3))
                        Else
                            Fecha_Nacimiento_Mes = Convert.ToString(varMatriz_Datos_del_Paciente(1, 3))
                        End If
                        Fecha_Nacimiento_Año = Convert.ToString(varMatriz_Datos_del_Paciente(1, 4))
                        '-----------------------------------------------------------------------------------------------------------
                        'Idenfificar las derivaciones que existen)
                        xlHoja_Registro = oExcel.Worksheets("Record0")

                        varMatriz_Registro = xlHoja_Registro.Range("A1:Z1").Value

                        UltimaColumna = 1
                        While varMatriz_Registro(1, UltimaColumna) <> Nothing
                            ListBox_Columnas.Add(varMatriz_Registro(1, UltimaColumna).ToString)
                            UltimaColumna = UltimaColumna + 1
                        End While
                        UltimaColumna = UltimaColumna - 1
                        '-----------------------------------------------------------------------------------------------------------
                        'Copiar Derivacion
                        PrimeraColumna = 1
                        While PrimeraColumna < ListBox_Columnas.Count
                            xlHoja_Registro = oExcel.Worksheets("Record0")
                            Dim Tabla_Datos As New DataTable()
                            Dim Segmento_Registro As Int32 = 0
                            Dim Coneccion_Registro As New SqlConnection
                            Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuario, Paciente, Fecha_Registro, ListBox_Columnas.Item(PrimeraColumna).ToString)
                            Dim Cmd_Copiar As New SqlBulkCopy(Coneccion_Registro)
                            'Crear Bases de datos para cada derivacion del registro
                            Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Registro, Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + ListBox_Columnas.Item(PrimeraColumna).ToString)
                            'Conectarme a la base de Datos
                            If Coneccion_Registro.State = 0 Then
                                Coneccion_Registro.Open()
                            End If
                            'Crear las tablas para almacenar en la base de datos
                            Tabla_Datos.Columns.Add(New DataColumn(ListBox_Columnas.Item(0).ToString, GetType(System.Int32)))
                            'Creal la columna de la derivacion correspondiente
                            Tabla_Datos.Columns.Add(New DataColumn(ListBox_Columnas.Item(PrimeraColumna).ToString, GetType(System.Double)))
                            Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Registro, Tabla_registro + "_Temp", ListBox_Columnas.Item(PrimeraColumna).ToString)

                            'Copiar los datos del registro externo a la base de datos 
                            Primera_Fila = 1
                            varMatriz_Registro = xlHoja_Registro.Range("A" + Convert.ToString(Primera_Fila + 1) + ":" + "A" + Convert.ToString(Primera_Fila + Max_Cantida_Datos_Cargados)).Value
                            Dim prue As String = "A" + Convert.ToString(Primera_Fila + 1) + ":" + "A" + Convert.ToString(Primera_Fila + Max_Cantida_Datos_Cargados)
                            varMatriz_Registro_Derivacion = xlHoja_Registro.Range(Columnas(PrimeraColumna).ToString + Convert.ToString(Primera_Fila + 1) + ":" + Columnas(PrimeraColumna).ToString + Convert.ToString(Primera_Fila + Max_Cantida_Datos_Cargados)).Value
                            Dim prue1 As String = Columnas(PrimeraColumna).ToString + Convert.ToString(Primera_Fila + 1) + ":" + Columnas(PrimeraColumna).ToString + Convert.ToString(Primera_Fila + Max_Cantida_Datos_Cargados)
                            Bandera_Ultimo_Dato = False
                            While Bandera_Ultimo_Dato <> True
                                UltimaFila = 1
                                If varMatriz_Registro(Max_Cantida_Datos_Cargados, 1) = Nothing Then
                                    Bandera_Ultimo_Dato = True
                                End If
                                While Bandera_Ultimo_Dato <> True And UltimaFila <= Max_Cantida_Datos_Cargados
                                    Tabla_Datos.Rows.Add(Convert.ToInt32(varMatriz_Registro(UltimaFila, 1)), varMatriz_Registro_Derivacion(UltimaFila, 1))
                                    UltimaFila = UltimaFila + 1
                                End While
                                While Bandera_Ultimo_Dato = True And UltimaFila <= Max_Cantida_Datos_Cargados
                                    If varMatriz_Registro(UltimaFila, 1) <> Nothing Or (UltimaFila = 1 And varMatriz_Registro(2, 1) <> Nothing) Then
                                        Tabla_Datos.Rows.Add(Convert.ToInt32(varMatriz_Registro(UltimaFila, 1)), varMatriz_Registro_Derivacion(UltimaFila, 1))
                                        UltimaFila = UltimaFila + 1
                                    Else
                                        UltimaFila = Max_Cantida_Datos_Cargados + 1
                                    End If
                                End While
                                Try
                                    Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Registro, Tabla_registro + "_Temp", Tabla_Datos)
                                    Tabla_Datos.Clear()
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try

                                Primera_Fila = Primera_Fila + Max_Cantida_Datos_Cargados
                                If Primera_Fila + 1 > 1000000 Then
                                    Bandera_Ultimo_Dato = True
                                ElseIf Primera_Fila + 1 < 1000000 And Primera_Fila + Max_Cantida_Datos_Cargados >= 1000001 Then
                                    varMatriz_Registro = xlHoja_Registro.Range("A" + Convert.ToString(Primera_Fila + 1) + ":" + "A1000001").Value
                                    varMatriz_Registro_Derivacion = xlHoja_Registro.Range(Columnas(PrimeraColumna).ToString + Convert.ToString(Primera_Fila + 1) + ":" + Columnas(PrimeraColumna).ToString + "1000001").Value
                                ElseIf Primera_Fila + 1 < 1000000 And Primera_Fila + Max_Cantida_Datos_Cargados < 1000000 Then
                                    varMatriz_Registro = xlHoja_Registro.Range("A" + Convert.ToString(Primera_Fila + 1) + ":" + "A" + Convert.ToString(Primera_Fila + Max_Cantida_Datos_Cargados)).Value
                                    varMatriz_Registro_Derivacion = xlHoja_Registro.Range(Columnas(PrimeraColumna).ToString + Convert.ToString(Primera_Fila + 1) + ":" + Columnas(PrimeraColumna).ToString + Convert.ToString(Primera_Fila + Max_Cantida_Datos_Cargados)).Value
                                End If
                            End While
                            ''Renombrar tabla cuando se finaliza la carga del registro
                            'Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_registro)
                            'Class_Funciones_Base_Datos.Tabla_Renombrar(Coneccion_Registro, Tabla_registro + "_Temp", Tabla_registro + "_Part_" + Convert.ToString(Segmento_Registro))
                            'Copiar los datos si sel archivo tiene "Record0","Record1",..."RecordN" 
                            Dim Hojas_Disponibles As Int16 = 3
                            Dim Hoja_Exitente As Boolean = True
                            While Hojas_Disponibles <= oExcel.ActiveWorkbook.Sheets.Count And Hoja_Exitente = True
                                Hoja_Exitente = False
                                'Valido que existe la sieguiente hoja en el Excel
                                For i = 3 To oExcel.ActiveWorkbook.Sheets.Count
                                    If oExcel.ActiveWorkbook.Sheets(i).Name = "Record" + Convert.ToString(Hojas_Disponibles - 2) Then
                                        Hoja_Exitente = True
                                        Exit For
                                    End If
                                Next
                                If Hoja_Exitente = True Then
                                    'Creo una nueva tabla para el proximo fregmento del Registro de 1000 000 datos
                                    Segmento_Registro = Segmento_Registro + 1
                                    Bandera_Ultimo_Dato = False
                                    xlHoja_Registro = oExcel.Worksheets("Record" + Convert.ToString(Hojas_Disponibles - 2))
                                    Primera_Fila = 0
                                    varMatriz_Registro = xlHoja_Registro.Range("A" + Convert.ToString(Primera_Fila + 1) + ":" + "A" + Convert.ToString(Primera_Fila + Max_Cantida_Datos_Cargados)).Value
                                    varMatriz_Registro_Derivacion = xlHoja_Registro.Range(Columnas(PrimeraColumna).ToString + Convert.ToString(Primera_Fila + 1) + ":" + Columnas(PrimeraColumna).ToString + Convert.ToString(Primera_Fila + Max_Cantida_Datos_Cargados)).Value

                                    While Bandera_Ultimo_Dato <> True
                                        UltimaFila = 1
                                        If varMatriz_Registro(Max_Cantida_Datos_Cargados, 1) = Nothing Then
                                            Bandera_Ultimo_Dato = True
                                        End If
                                        While Bandera_Ultimo_Dato <> True And UltimaFila <= Max_Cantida_Datos_Cargados
                                            Tabla_Datos.Rows.Add(Convert.ToInt32(varMatriz_Registro(UltimaFila, 1)), varMatriz_Registro_Derivacion(UltimaFila, 1))
                                            UltimaFila = UltimaFila + 1
                                        End While
                                        While Bandera_Ultimo_Dato = True And UltimaFila <= Max_Cantida_Datos_Cargados
                                            If varMatriz_Registro(UltimaFila, 1) <> Nothing Or (UltimaFila = 1 And varMatriz_Registro(2, 1) <> Nothing) Then
                                                Tabla_Datos.Rows.Add(Convert.ToInt32(varMatriz_Registro(UltimaFila, 1)), varMatriz_Registro_Derivacion(UltimaFila, 1))
                                                UltimaFila = UltimaFila + 1
                                            Else
                                                UltimaFila = Max_Cantida_Datos_Cargados + 1
                                            End If
                                        End While
                                        Try
                                            Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Registro, Tabla_registro + "_Temp", Tabla_Datos)
                                            Tabla_Datos.Clear()
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        End Try
                                        Primera_Fila = Primera_Fila + Max_Cantida_Datos_Cargados
                                        If Primera_Fila + 1 > 1000000 Then
                                            Bandera_Ultimo_Dato = True
                                        ElseIf Primera_Fila + 1 < 1000000 And Primera_Fila + Max_Cantida_Datos_Cargados >= 1000000 Then
                                            varMatriz_Registro = xlHoja_Registro.Range("A" + Convert.ToString(Primera_Fila + 1) + ":" + "A1000000").Value
                                            varMatriz_Registro_Derivacion = xlHoja_Registro.Range(Columnas(PrimeraColumna).ToString + Convert.ToString(Primera_Fila + 1) + ":" + Columnas(PrimeraColumna).ToString + "1000000").Value
                                        ElseIf Primera_Fila + 1 < 1000000 And Primera_Fila + Max_Cantida_Datos_Cargados < 1000000 Then
                                            varMatriz_Registro = xlHoja_Registro.Range("A" + Convert.ToString(Primera_Fila + 1) + ":" + "A" + Convert.ToString(Primera_Fila + Max_Cantida_Datos_Cargados)).Value
                                            varMatriz_Registro_Derivacion = xlHoja_Registro.Range(Columnas(PrimeraColumna).ToString + Convert.ToString(Primera_Fila + 1) + ":" + Columnas(PrimeraColumna).ToString + Convert.ToString(Primera_Fila + Max_Cantida_Datos_Cargados)).Value
                                        End If
                                    End While
                                    ''Renombrar tabla cuando se finaliza la carga del registro
                                    'Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion_Registro, Tabla_registro + "_Part_" + Convert.ToString(Segmento_Registro))
                                    'Class_Funciones_Base_Datos.Tabla_Renombrar(Coneccion_Registro, Tabla_registro + "_Temp", Tabla_registro + "_Part_" + Convert.ToString(Segmento_Registro))
                                    'Me muevo a la siguiente Hoja del excel
                                    Hojas_Disponibles = Hojas_Disponibles + 1
                                End If
                            End While
                            Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_registro + "_Temp", Tabla_registro)
                            If Coneccion_Registro.State <> 0 Then
                                Coneccion_Registro.Close()
                            End If
                            PrimeraColumna = PrimeraColumna + 1
                            Tabla_Datos.Clear()
                            Tabla_Datos.Columns.Clear()
                            Tabla_Datos.AcceptChanges()
                            Try
                                Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Registro)
                            Catch ex As Exception

                            End Try

                        End While
                        'oExcel.Workbooks.Close(filesListBox.Item(Index).ToString)
                        'cerramos el archivo Excel

                        'reset variables de los objetos

                        xlHoja_Datos_del_Paciente = Nothing
                        xlHoja_Registro = Nothing
                        xlLibro.Close
                        xlLibro = Nothing
                        oExcel.Application.Quit
                        oExcel = Nothing

                        Dim Derivaciones As String = ""


                        For Index_Derivaciones = 1 To ListBox_Columnas.Count - 1
                            Derivaciones = Derivaciones + ListBox_Columnas.Item(Index_Derivaciones).ToString
                            If Index_Derivaciones < ListBox_Columnas.Count - 1 Then
                                Derivaciones = Derivaciones + ","
                            End If
                        Next
                        ListBox_Columnas.Clear()
                        'Dim Coneccion_Base_Datos As New SqlConnection
                        'Coneccion_Base_Datos = Class_Funciones_Base_Datos.Coneccion_Registro()
                        If Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Validar_Existencia_Paciente(Coneccion_Base_Datos, Usuario, Paciente) = False Then
                            'Incertar el nuevo paciente en la base de datos
                            Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Agregar_Paciente(Coneccion_Base_Datos, Usuario, Paciente, Peso_kg, Estatura_cm, Sexo, Raza, Fecha_Nacimiento_Dia, Fecha_Nacimiento_Mes, Fecha_Nacimiento_Año, Detalles_Paciente, Marca_Paso)
                        End If
                        If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Validar_Registro(Coneccion_Base_Datos, Usuario, Paciente, Fecha_Registro) = False Then
                            Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Agregar_Dato(Coneccion_Base_Datos, Usuario, Paciente, Fecha_Registro, Frecuencia, Derivaciones)
                        Else
                            Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Actualizar_Registro(Coneccion_Base_Datos, Usuario, Paciente, Fecha_Registro, Usuario, Paciente, Fecha_Registro, Frecuencia, Derivaciones)
                        End If
                        'Class_Funciones_Base_Datos.Eliminar_Tabla(Coneccion_Base_Datos, Tabla_registro)
                        'Class_Funciones_Base_Datos.Tabla_Renombrar(Coneccion_Base_Datos, Tabla_registro + "_Temp", Tabla_registro)
                        'oExcel.Workbooks.q(filesListBox.Item(Index).ToString)

                    Catch ex As Exception
                        MsgBox(ex.Message)
                        'cerramos el archivo Excel
                        'MsgBox(ex.Message)
                        If IsNothing(xlLibro) = True Then
                            xlLibro.Close
                            oExcel.Quit

                            'reset variables de los objetos
                            xlHoja_Datos_del_Paciente = Nothing
                            xlHoja_Registro = Nothing
                            xlLibro = Nothing
                            oExcel = Nothing

                            ListBox_Columnas.Clear()
                        End If

                    End Try
                End If
            Next


            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Me, "Import Finished", "", "Import Finished", 1)
        Else
            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Me, "No files were found in the folder", "", " No files were found in the folder", 0)
        End If
        Me.Enabled = True
    End Sub

    Private Sub Button_Reiniciar_Base_Datos_Click(sender As Object, e As EventArgs) Handles Button_Reiniciar_Base_Datos.Click

        Dim Coneccion_Base_Datos As New SqlConnection
        Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
        Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Base_Datos)
        Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Base_Datos)
        Dim Usuarios As New DataSet
        Usuarios = Class_Funciones_Base_Datos.Tabla_Usuarios_Buscar_Usuarios(Coneccion_Base_Datos, "1")
        For Index_Usuarios = 0 To Usuarios.Tables(0).Rows.Count - 1
            Dim Paciente As DataSet
            Paciente = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Base_Datos, Usuarios.Tables(0).Rows(Index_Usuarios)(0))
            For Index_Paciente = 0 To Paciente.Tables(0).Rows.Count - 1
                Dim Registros As DataSet
                Registros = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Base_Datos, Usuarios.Tables(0).Rows(Index_Usuarios)(0), Paciente.Tables(0).Rows(Index_Paciente)(0))
                For Index_Registros = 0 To Registros.Tables(0).Rows.Count - 1
                    Dim Derivaciones As List(Of String)
                    Derivaciones = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Derivaciones_Registro(Coneccion_Base_Datos, Usuarios.Tables(0).Rows(Index_Usuarios)(0), Paciente.Tables(0).Rows(Index_Paciente)(0), Registros.Tables(0).Rows(Index_Registros)(0))
                    For Index_Derivaciones = 0 To Derivaciones.Count - 1
                        Dim Direccion_Archivo_mdf As String
                        Dim Direccion_Archivo_ldf As String
                        Dim Base_Datos_Eliminar As String
                        Base_Datos_Eliminar = Usuarios.Tables(0).Rows(Index_Usuarios)(0) + "___" + Paciente.Tables(0).Rows(Index_Paciente)(0) + "___" + Registros.Tables(0).Rows(Index_Registros)(0) + "___" + Derivaciones.Item(Index_Derivaciones).ToString
                        Class_Funciones_Base_Datos.Eliminar_Base_Datos(Base_Datos_Eliminar)
                        Class_Funciones_Base_Datos.Eliminar_Base_Datos(Base_Datos_Eliminar + "___Filtrado_Temp")
                        Class_Funciones_Base_Datos.Eliminar_Base_Datos(Base_Datos_Eliminar + "___Transformada_Wavelet_Complejo_QRS_Temp")
                        Class_Funciones_Base_Datos.Eliminar_Base_Datos(Base_Datos_Eliminar + "___Transformada_Wavelet_Onda_PT_Busqueda_Temp")
                        Class_Funciones_Base_Datos.Eliminar_Base_Datos(Base_Datos_Eliminar + "___Transformada_Wavelet_Onda_PT_Correcion_Temp")
                        Class_Funciones_Base_Datos.Eliminar_Base_Datos("Base_Datos_Filtro_Temp")

                        'Direccion_Archivo_mdf = Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Usuarios.Tables(0).Rows(Index_Usuarios)(0) + "___" + Paciente.Tables(0).Rows(Index_Paciente)(0) + "___" + Registros.Tables(0).Rows(Index_Registros)(0) + "___" + Derivaciones.Item(Index_Derivaciones).ToString + ".mdf"
                        'Direccion_Archivo_ldf = Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Usuarios.Tables(0).Rows(Index_Usuarios)(0) + "___" + Paciente.Tables(0).Rows(Index_Paciente)(0) + "___" + Registros.Tables(0).Rows(Index_Registros)(0) + "___" + Derivaciones.Item(Index_Derivaciones).ToString + "_log.ldf"
                        'If My.Computer.FileSystem.FileExists(Direccion_Archivo_mdf) Then
                        '    Try
                        '        System.IO.File.Delete(Direccion_Archivo_mdf)
                        '    Catch ex As Exception
                        '        Dim Archivo_Pendiente = Direccion_Archivo_mdf
                        '        Dim Archivo_Eliminar As System.IO.StreamWriter
                        '        Archivo_Eliminar = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Eliminar.txt", True)
                        '        Archivo_Eliminar.WriteLine(Archivo_Pendiente)
                        '        Archivo_Eliminar.Close()
                        '    End Try
                        'End If
                        'If My.Computer.FileSystem.FileExists(Direccion_Archivo_ldf) Then
                        '    Try
                        '        System.IO.File.Delete(Direccion_Archivo_ldf)
                        '    Catch ex As Exception
                        '        Dim Archivo_Pendiente = Direccion_Archivo_ldf
                        '        Dim Archivo_Eliminar As System.IO.StreamWriter
                        '        Archivo_Eliminar = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Eliminar.txt", True)
                        '        Archivo_Eliminar.WriteLine(Archivo_Pendiente)
                        '        Archivo_Eliminar.Close()
                        '    End Try
                        'End If
                    Next Index_Derivaciones
                Next Index_Registros
            Next Index_Paciente
        Next Index_Usuarios

        Class_Funciones_Base_Datos.Reiniciar_Base_Datos(Coneccion_Base_Datos)
        Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Base_Datos)
        Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Base_Datos)
        Application.Restart()
    End Sub

    Private Sub BackgroundWorker_Exportar_Resultados_1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Exportar_Resultados_1.DoWork
        Dim Datos_Lectura_Registro_QRS As DataSet
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        If Exportacion_Resultados_Calculados.Bandera_Sobreescribir_Archivos Then
            For Index = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Count - 1 To 0 Step -1
                Dim Coneccion_Registro As New SqlConnection
                Dim Usuario, Paciente, Fecha_Registro, Derivacion As String
                Usuario = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Usuario
                Paciente = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Paciente
                Fecha_Registro = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Fecha_Registro
                Derivacion = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Derivacion
                Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuario, Paciente, Fecha_Registro, Derivacion)
                Dim Tabla_Existente As String
                Dim Registro As String
                'Ondas
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complejo_QRS"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complex_QRS" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Q_i"
                    oSheet.Range("B1").Value = "Q"
                    oSheet.Range("C1").Value = "R"
                    oSheet.Range("D1").Value = "S"
                    oSheet.Range("E1").Value = "J"
                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Q_i, Q, R, S, J", "1", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                        oSheet.Range("D" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(4)
                        oSheet.Range("E" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(5)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "T_i"
                    oSheet.Range("B1").Value = "T"
                    oSheet.Range("C1").Value = "T_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "T_i, T, T_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next
                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1
                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_P"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_P" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then

                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "P_i"
                    oSheet.Range("B1").Value = "P"
                    oSheet.Range("C1").Value = "P_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "P_i, P, P_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                'Intervalos
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_R_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_R_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_R_R"
                    oSheet.Range("B1").Value = "End_R_R"
                    oSheet.Range("C1").Value = "R_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_R_R, Final_R_R, R_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_Q_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_Q_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")

                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_Q_T"
                    oSheet.Range("B1").Value = "End_Q_T"
                    oSheet.Range("C1").Value = "Q_T"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_Q_T, Final_Q_T, Q_T", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_P_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_P_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")


                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Inicio_P_R"
                    oSheet.Range("B1").Value = "Final_P_R"
                    oSheet.Range("C1").Value = "P_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_P_R, Final_P_R, P_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If



            Next Index
        Else
            For Index = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Count - 1 To 0 Step -1
                Dim Coneccion_Registro As New SqlConnection
                Dim Usuario, Paciente, Fecha_Registro, Derivacion As String
                Usuario = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Usuario
                Paciente = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Paciente
                Fecha_Registro = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Fecha_Registro
                Derivacion = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Derivacion
                Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuario, Paciente, Fecha_Registro, Derivacion)
                Dim Tabla_Existente As String
                Dim Registro As String
                'Ondas
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complejo_QRS"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complex_QRS" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Q_i"
                    oSheet.Range("B1").Value = "Q"
                    oSheet.Range("C1").Value = "R"
                    oSheet.Range("D1").Value = "S"
                    oSheet.Range("E1").Value = "J"
                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Q_i, Q, R, S, J", "1", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                        oSheet.Range("D" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(4)
                        oSheet.Range("E" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(5)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "T_i"
                    oSheet.Range("B1").Value = "T"
                    oSheet.Range("C1").Value = "T_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "T_i, T, T_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next
                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1
                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_P"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_P" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then

                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "P_i"
                    oSheet.Range("B1").Value = "P"
                    oSheet.Range("C1").Value = "P_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "P_i, P, P_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                'Intervalos
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_R_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_R_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_R_R"
                    oSheet.Range("B1").Value = "End_R_R"
                    oSheet.Range("C1").Value = "R_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_R_R, Final_R_R, R_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_Q_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_Q_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")

                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_Q_T"
                    oSheet.Range("B1").Value = "End_Q_T"
                    oSheet.Range("C1").Value = "Q_T"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_Q_T, Final_Q_T, Q_T", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_P_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_P_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")


                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_P_R"
                    oSheet.Range("B1").Value = "End_P_R"
                    oSheet.Range("C1").Value = "P_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_P_R, Final_P_R, P_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If
            Next Index
        End If
        Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_1.Clear()
        Exportacion_Resultados_Calculados.Bandera_Finalizacion_1 = True
    End Sub

    Private Sub BackgroundWorker_Exportar_Resultados_2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Exportar_Resultados_2.DoWork
        Dim Datos_Lectura_Registro_QRS As DataSet
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        If Exportacion_Resultados_Calculados.Bandera_Sobreescribir_Archivos Then
            For Index = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Count - 1 To 0 Step -1
                Dim Coneccion_Registro As New SqlConnection
                Dim Usuario, Paciente, Fecha_Registro, Derivacion As String
                Usuario = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Usuario
                Paciente = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Paciente
                Fecha_Registro = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Fecha_Registro
                Derivacion = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Derivacion
                Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuario, Paciente, Fecha_Registro, Derivacion)
                Dim Tabla_Existente As String
                Dim Registro As String
                'Ondas
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complejo_QRS"

                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complex_QRS" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Q_i"
                    oSheet.Range("B1").Value = "Q"
                    oSheet.Range("C1").Value = "R"
                    oSheet.Range("D1").Value = "S"
                    oSheet.Range("E1").Value = "J"
                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Q_i, Q, R, S, J", "1", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                        oSheet.Range("D" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(4)
                        oSheet.Range("E" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(5)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "T_i"
                    oSheet.Range("B1").Value = "T"
                    oSheet.Range("C1").Value = "T_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "T_i, T, T_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next
                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1
                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_P"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_P" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then

                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "P_i"
                    oSheet.Range("B1").Value = "P"
                    oSheet.Range("C1").Value = "P_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "P_i, P, P_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                'Intervalos
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_R_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_R_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_R_R"
                    oSheet.Range("B1").Value = "End_R_R"
                    oSheet.Range("C1").Value = "R_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_R_R, Final_R_R, R_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_Q_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_Q_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")

                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_Q_T"
                    oSheet.Range("B1").Value = "End_Q_T"
                    oSheet.Range("C1").Value = "Q_T"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_Q_T, Final_Q_T, Q_T", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_P_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_P_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")


                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_P_R"
                    oSheet.Range("B1").Value = "End_P_R"
                    oSheet.Range("C1").Value = "P_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_P_R, Final_P_R, P_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If



            Next Index
        Else
            For Index = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Count - 1 To 0 Step -1
                Dim Coneccion_Registro As New SqlConnection
                Dim Usuario, Paciente, Fecha_Registro, Derivacion As String
                Usuario = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Usuario
                Paciente = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Paciente
                Fecha_Registro = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Fecha_Registro
                Derivacion = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Derivacion
                Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuario, Paciente, Fecha_Registro, Derivacion)
                Dim Tabla_Existente As String
                Dim Registro As String
                'Ondas
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complejo_QRS"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complex_QRS" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Q_i"
                    oSheet.Range("B1").Value = "Q"
                    oSheet.Range("C1").Value = "R"
                    oSheet.Range("D1").Value = "S"
                    oSheet.Range("E1").Value = "J"
                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Q_i, Q, R, S, J", "1", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                        oSheet.Range("D" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(4)
                        oSheet.Range("E" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(5)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "T_i"
                    oSheet.Range("B1").Value = "T"
                    oSheet.Range("C1").Value = "T_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "T_i, T, T_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next
                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1
                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_P"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_P" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then

                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "P_i"
                    oSheet.Range("B1").Value = "P"
                    oSheet.Range("C1").Value = "P_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "P_i, P, P_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                'Intervalos
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_R_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_R_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_R_R"
                    oSheet.Range("B1").Value = "End_R_R"
                    oSheet.Range("C1").Value = "R_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_R_R, Final_R_R, R_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_Q_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_Q_T" + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_Q_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")

                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_Q_T"
                    oSheet.Range("B1").Value = "End_Q_T"
                    oSheet.Range("C1").Value = "Q_T"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_Q_T, Final_Q_T, Q_T", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_P_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_P_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")


                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_P_R"
                    oSheet.Range("B1").Value = "End_P_R"
                    oSheet.Range("C1").Value = "P_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_P_R, Final_P_R, P_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If
            Next Index
        End If
        Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_2.Clear()
        Exportacion_Resultados_Calculados.Bandera_Finalizacion_2 = True

    End Sub
    Private Sub BackgroundWorker_Exportar_Resultados_3_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Exportar_Resultados_3.DoWork
        Dim Datos_Lectura_Registro_QRS As DataSet
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        If Exportacion_Resultados_Calculados.Bandera_Sobreescribir_Archivos Then
            For Index = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Count - 1 To 0 Step -1
                Dim Coneccion_Registro As New SqlConnection
                Dim Usuario, Paciente, Fecha_Registro, Derivacion As String
                Usuario = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Usuario
                Paciente = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Paciente
                Fecha_Registro = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Fecha_Registro
                Derivacion = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Derivacion
                Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuario, Paciente, Fecha_Registro, Derivacion)
                Dim Tabla_Existente As String
                Dim Registro As String
                'Ondas

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complejo_QRS"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complex_QRS" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Q_i"
                    oSheet.Range("B1").Value = "Q"
                    oSheet.Range("C1").Value = "R"
                    oSheet.Range("D1").Value = "S"
                    oSheet.Range("E1").Value = "J"
                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Q_i, Q, R, S, J", "1", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                        oSheet.Range("D" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(4)
                        oSheet.Range("E" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(5)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "T_i"
                    oSheet.Range("B1").Value = "T"
                    oSheet.Range("C1").Value = "T_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "T_i, T, T_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next
                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1
                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_P"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_P" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then

                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "P_i"
                    oSheet.Range("B1").Value = "P"
                    oSheet.Range("C1").Value = "P_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "P_i, P, P_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                'Intervalos
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_R_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_R_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_R_R"
                    oSheet.Range("B1").Value = "End_R_R"
                    oSheet.Range("C1").Value = "R_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_R_R, Final_R_R, R_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_Q_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_Q_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")

                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_Q_T"
                    oSheet.Range("B1").Value = "End_Q_T"
                    oSheet.Range("C1").Value = "Q_T"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_Q_T, Final_Q_T, Q_T", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_P_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_P_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")


                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_P_R"
                    oSheet.Range("B1").Value = "End_P_R"
                    oSheet.Range("C1").Value = "P_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_P_R, Final_P_R, P_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If



            Next Index
        Else
            For Index = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Count - 1 To 0 Step -1
                Dim Coneccion_Registro As New SqlConnection
                Dim Usuario, Paciente, Fecha_Registro, Derivacion As String
                Usuario = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Usuario
                Paciente = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Paciente
                Fecha_Registro = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Fecha_Registro
                Derivacion = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Derivacion
                Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuario, Paciente, Fecha_Registro, Derivacion)
                Dim Tabla_Existente As String
                Dim Registro As String
                'Ondas

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complejo_QRS"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complex_QRS" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Q_i"
                    oSheet.Range("B1").Value = "Q"
                    oSheet.Range("C1").Value = "R"
                    oSheet.Range("D1").Value = "S"
                    oSheet.Range("E1").Value = "J"
                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Q_i, Q, R, S, J", "1", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                        oSheet.Range("D" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(4)
                        oSheet.Range("E" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(5)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "T_i"
                    oSheet.Range("B1").Value = "T"
                    oSheet.Range("C1").Value = "T_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "T_i, T, T_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next
                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1
                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_P"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_P" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then

                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "P_i"
                    oSheet.Range("B1").Value = "P"
                    oSheet.Range("C1").Value = "P_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "P_i, P, P_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                'Intervalos
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_R_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_R_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_R_R"
                    oSheet.Range("B1").Value = "End_R_R"
                    oSheet.Range("C1").Value = "R_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_R_R, Final_R_R, R_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_Q_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_Q_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")

                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_Q_T"
                    oSheet.Range("B1").Value = "End_Q_T"
                    oSheet.Range("C1").Value = "Q_T"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_Q_T, Final_Q_T, Q_T", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_P_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_P_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")


                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_P_R"
                    oSheet.Range("B1").Value = "End_P_R"
                    oSheet.Range("C1").Value = "P_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_P_R, Final_P_R, P_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If
            Next Index
        End If
        Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_3.Clear()
        Exportacion_Resultados_Calculados.Bandera_Finalizacion_3 = True
    End Sub
    Private Sub BackgroundWorker_Exportar_Resultados_4_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Exportar_Resultados_4.DoWork
        Dim Datos_Lectura_Registro_QRS As DataSet
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        If Exportacion_Resultados_Calculados.Bandera_Sobreescribir_Archivos Then
            For Index = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Count - 1 To 0 Step -1
                Dim Coneccion_Registro As New SqlConnection
                Dim Usuario, Paciente, Fecha_Registro, Derivacion As String
                Usuario = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Usuario
                Paciente = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Paciente
                Fecha_Registro = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Fecha_Registro
                Derivacion = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Derivacion
                Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuario, Paciente, Fecha_Registro, Derivacion)
                Dim Tabla_Existente As String
                Dim Registro As String
                'Ondas
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complejo_QRS"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complex_QRS" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Q_i"
                    oSheet.Range("B1").Value = "Q"
                    oSheet.Range("C1").Value = "R"
                    oSheet.Range("D1").Value = "S"
                    oSheet.Range("E1").Value = "J"
                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Q_i, Q, R, S, J", "1", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                        oSheet.Range("D" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(4)
                        oSheet.Range("E" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(5)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "T_i"
                    oSheet.Range("B1").Value = "T"
                    oSheet.Range("C1").Value = "T_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "T_i, T, T_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next
                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1
                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_P"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_P" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then

                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "P_i"
                    oSheet.Range("B1").Value = "P"
                    oSheet.Range("C1").Value = "P_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "P_i, P, P_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                'Intervalos
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_R_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_R_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_R_R"
                    oSheet.Range("B1").Value = "End_R_R"
                    oSheet.Range("C1").Value = "R_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_R_R, Final_R_R, R_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_Q_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_Q_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")

                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_Q_T"
                    oSheet.Range("B1").Value = "End_Q_T"
                    oSheet.Range("C1").Value = "Q_T"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_Q_T, Final_Q_T, Q_T", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_P_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_P_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")


                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_P_R"
                    oSheet.Range("B1").Value = "End_P_R"
                    oSheet.Range("C1").Value = "P_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_P_R, Final_P_R, P_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If



            Next Index
        Else
            For Index = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Count - 1 To 0 Step -1
                Dim Coneccion_Registro As New SqlConnection
                Dim Usuario, Paciente, Fecha_Registro, Derivacion As String
                Usuario = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Usuario
                Paciente = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Paciente
                Fecha_Registro = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Fecha_Registro
                Derivacion = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Derivacion
                Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuario, Paciente, Fecha_Registro, Derivacion)
                Dim Tabla_Existente As String
                Dim Registro As String
                'Ondas
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complejo_QRS"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complex_QRS" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Q_i"
                    oSheet.Range("B1").Value = "Q"
                    oSheet.Range("C1").Value = "R"
                    oSheet.Range("D1").Value = "S"
                    oSheet.Range("E1").Value = "J"
                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Q_i, Q, R, S, J", "1", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                        oSheet.Range("D" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(4)
                        oSheet.Range("E" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(5)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "T_i"
                    oSheet.Range("B1").Value = "T"
                    oSheet.Range("C1").Value = "T_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "T_i, T, T_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next
                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1
                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_P"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_P" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then

                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "P_i"
                    oSheet.Range("B1").Value = "P"
                    oSheet.Range("C1").Value = "P_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "P_i, P, P_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                'Intervalos
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_R_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_R_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_R_R"
                    oSheet.Range("B1").Value = "End_R_R"
                    oSheet.Range("C1").Value = "R_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_R_R, Final_R_R, R_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_Q_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_Q_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")

                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_Q_T"
                    oSheet.Range("B1").Value = "End_Q_T"
                    oSheet.Range("C1").Value = "Q_T"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_Q_T, Final_Q_T, Q_T", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_P_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_P_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")


                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_P_R"
                    oSheet.Range("B1").Value = "End_P_R"
                    oSheet.Range("C1").Value = "P_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_P_R, Final_P_R, P_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If
            Next Index
        End If
        Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_4.Clear()
        Exportacion_Resultados_Calculados.Bandera_Finalizacion_4 = True
    End Sub
    Private Sub BackgroundWorker_Exportar_Resultados_5_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Exportar_Resultados_5.DoWork
        Dim Datos_Lectura_Registro_QRS As DataSet
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        If Exportacion_Resultados_Calculados.Bandera_Sobreescribir_Archivos Then
            For Index = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Count - 1 To 0 Step -1
                Dim Coneccion_Registro As New SqlConnection
                Dim Usuario, Paciente, Fecha_Registro, Derivacion As String
                Usuario = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Usuario
                Paciente = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Paciente
                Fecha_Registro = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Fecha_Registro
                Derivacion = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Derivacion
                Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuario, Paciente, Fecha_Registro, Derivacion)
                Dim Tabla_Existente As String
                Dim Registro As String
                'Ondas
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complejo_QRS"

                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complex_QRS" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Q_i"
                    oSheet.Range("B1").Value = "Q"
                    oSheet.Range("C1").Value = "R"
                    oSheet.Range("D1").Value = "S"
                    oSheet.Range("E1").Value = "J"
                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Q_i, Q, R, S, J", "1", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                        oSheet.Range("D" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(4)
                        oSheet.Range("E" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(5)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "T_i"
                    oSheet.Range("B1").Value = "T"
                    oSheet.Range("C1").Value = "T_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "T_i, T, T_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next
                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1
                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_P"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_P" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then

                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "P_i"
                    oSheet.Range("B1").Value = "P"
                    oSheet.Range("C1").Value = "P_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "P_i, P, P_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                'Intervalos
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_R_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_R_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_R_R"
                    oSheet.Range("B1").Value = "End_R_R"
                    oSheet.Range("C1").Value = "R_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_R_R, Final_R_R, R_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_Q_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_Q_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")

                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_Q_T"
                    oSheet.Range("B1").Value = "End_Q_T"
                    oSheet.Range("C1").Value = "Q_T"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_Q_T, Final_Q_T, Q_T", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_P_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_P_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")


                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_P_R"
                    oSheet.Range("B1").Value = "End_P_R"
                    oSheet.Range("C1").Value = "P_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_P_R, Final_P_R, P_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If



            Next Index
        Else
            For Index = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Count - 1 To 0 Step -1
                Dim Coneccion_Registro As New SqlConnection
                Dim Usuario, Paciente, Fecha_Registro, Derivacion As String
                Usuario = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Usuario
                Paciente = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Paciente
                Fecha_Registro = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Fecha_Registro
                Derivacion = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Derivacion
                Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuario, Paciente, Fecha_Registro, Derivacion)
                Dim Tabla_Existente As String
                Dim Registro As String
                'Ondas
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complejo_QRS"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complex_QRS" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Q_i"
                    oSheet.Range("B1").Value = "Q"
                    oSheet.Range("C1").Value = "R"
                    oSheet.Range("D1").Value = "S"
                    oSheet.Range("E1").Value = "J"
                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Q_i, Q, R, S, J", "1", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                        oSheet.Range("D" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(4)
                        oSheet.Range("E" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(5)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "T_i"
                    oSheet.Range("B1").Value = "T"
                    oSheet.Range("C1").Value = "T_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "T_i, T, T_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next
                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1
                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_P"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_P" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then

                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "P_i"
                    oSheet.Range("B1").Value = "P"
                    oSheet.Range("C1").Value = "P_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "P_i, P, P_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                'Intervalos
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_R_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_R_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_R_R"
                    oSheet.Range("B1").Value = "End_R_R"
                    oSheet.Range("C1").Value = "R_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_R_R, Final_R_R, R_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_Q_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_Q_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")

                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_Q_T"
                    oSheet.Range("B1").Value = "End_Q_T"
                    oSheet.Range("C1").Value = "Q_T"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_Q_T, Final_Q_T, Q_T", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_P_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_P_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")


                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_P_R"
                    oSheet.Range("B1").Value = "End_P_R"
                    oSheet.Range("C1").Value = "P_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_P_R, Final_P_R, P_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If
            Next Index
        End If
        Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_5.Clear()
        Exportacion_Resultados_Calculados.Bandera_Finalizacion_5 = True
    End Sub
    Private Sub BackgroundWorker_Exportar_Resultados_6_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Exportar_Resultados_6.DoWork
        Dim Datos_Lectura_Registro_QRS As DataSet
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object

        If Exportacion_Resultados_Calculados.Bandera_Sobreescribir_Archivos Then
            For Index = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Count - 1 To 0 Step -1
                Dim Coneccion_Registro As New SqlConnection
                Dim Usuario, Paciente, Fecha_Registro, Derivacion As String
                Usuario = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Usuario
                Paciente = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Paciente
                Fecha_Registro = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Fecha_Registro
                Derivacion = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Derivacion
                Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuario, Paciente, Fecha_Registro, Derivacion)
                Dim Tabla_Existente As String
                Dim Registro As String
                'Ondas
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complejo_QRS"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complex_QRS" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Q_i"
                    oSheet.Range("B1").Value = "Q"
                    oSheet.Range("C1").Value = "R"
                    oSheet.Range("D1").Value = "S"
                    oSheet.Range("E1").Value = "J"
                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Q_i, Q, R, S, J", "1", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                        oSheet.Range("D" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(4)
                        oSheet.Range("E" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(5)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "T_i"
                    oSheet.Range("B1").Value = "T"
                    oSheet.Range("C1").Value = "T_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "T_i, T, T_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next
                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1
                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_P"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_P" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then

                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "P_i"
                    oSheet.Range("B1").Value = "P"
                    oSheet.Range("C1").Value = "P_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "P_i, P, P_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                'Intervalos
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_R_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_R_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_R_R"
                    oSheet.Range("B1").Value = "End_R_R"
                    oSheet.Range("C1").Value = "R_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_R_R, Final_R_R, R_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_Q_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_Q_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")

                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_Q_T"
                    oSheet.Range("B1").Value = "End_Q_T"
                    oSheet.Range("C1").Value = "Q_T"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_Q_T, Final_Q_T, Q_T", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_P_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_P_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")


                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_P_R"
                    oSheet.Range("B1").Value = "End_P_R"
                    oSheet.Range("C1").Value = "P_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_P_R, Final_P_R, P_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If



            Next Index
        Else
            For Index = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Count - 1 To 0 Step -1
                Dim Coneccion_Registro As New SqlConnection
                Dim Usuario, Paciente, Fecha_Registro, Derivacion As String
                Usuario = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Usuario
                Paciente = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Paciente
                Fecha_Registro = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Fecha_Registro
                Derivacion = Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Derivacion
                Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuario, Paciente, Fecha_Registro, Derivacion)
                Dim Tabla_Existente As String
                Dim Registro As String
                'Ondas
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complejo_QRS"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Complex_QRS" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Q_i"
                    oSheet.Range("B1").Value = "Q"
                    oSheet.Range("C1").Value = "R"
                    oSheet.Range("D1").Value = "S"
                    oSheet.Range("E1").Value = "J"
                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Q_i, Q, R, S, J", "1", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                        oSheet.Range("D" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(4)
                        oSheet.Range("E" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(5)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "T_i"
                    oSheet.Range("B1").Value = "T"
                    oSheet.Range("C1").Value = "T_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "T_i, T, T_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next
                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If
                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1
                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Onda_P"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Wave_P" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then

                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add
                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "P_i"
                    oSheet.Range("B1").Value = "P"
                    oSheet.Range("C1").Value = "P_f"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "P_i, P, P_f", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()

                End If

                'Intervalos
                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_R_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_R_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_R_R"
                    oSheet.Range("B1").Value = "End_R_R"
                    oSheet.Range("C1").Value = "R_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_R_R, Final_R_R, R_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If
                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_Q_T"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_Q_T" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")

                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_Q_T"
                    oSheet.Range("B1").Value = "End_Q_T"
                    oSheet.Range("C1").Value = "Q_T"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_Q_T, Final_Q_T, Q_T", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If



                    'oBook.SaveAs(Registro, oExcel.XlFileFormat.xlOpenXMLWorkbook, , , , , , oExcel.XlSaveAsAccessMode.xlNoChange, , , ,)
                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If

                Tabla_Existente = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Intervalo_P_R"
                Registro = Usuario + "___" + Paciente + "___" + Fecha_Registro + "___" + "Interval_P_R" + "___" + Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Item(Index).Derivacion
                Registro = Exportacion_Resultados_Calculados.Directorio_Almacenamiento + "\" + Registro + ".xlsx"
                If Class_Funciones_Base_Datos.Registro_Tabla_Existe(Coneccion_Registro, Tabla_Existente) And Not (System.IO.File.Exists(Registro)) Then
                    'Start a new workbook in Excel    
                    oExcel = CreateObject("Excel.Application")


                    oBook = oExcel.Workbooks.Add

                    'Add data to cells of the first worksheet in the new workbook    
                    oSheet = oBook.Worksheets(1)
                    oSheet.Range("A1").Value = "Start_P_R"
                    oSheet.Range("B1").Value = "End_P_R"
                    oSheet.Range("C1").Value = "P_R"

                    oSheet.Range("A1:E1").Font.Bold = True
                    Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Tabla_Existente, "Inicio_P_R, Final_P_R, P_R", "0", Convert.ToString(Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Existente)))
                    For i = 1 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count
                        oSheet.Range("A" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(1)
                        oSheet.Range("B" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(2)
                        oSheet.Range("C" + Convert.ToString(i + 1)).Value = Datos_Lectura_Registro_QRS.Tables(0).Rows(i - 1)(3)
                    Next

                    If System.IO.File.Exists(Registro) Then
                        System.IO.File.Delete(Registro)
                    End If

                    Dim Bandera_Estado_Escritura As Boolean = False
                    Dim Intentos_Escritura As Int16 = 1

                    While Bandera_Estado_Escritura = False And Intentos_Escritura < 100
                        Try
                            oBook.SaveAs(Registro, 51, , , , , , 1, , , ,)
                            Bandera_Estado_Escritura = True
                        Catch ex As Exception
                            Bandera_Estado_Escritura = False
                            Intentos_Escritura = Intentos_Escritura + 1
                            System.Threading.Thread.Sleep(100)
                        End Try
                    End While
                    If Intentos_Escritura = 100 Then
                        Intentos_Escritura = 0
                    End If

                    oBook.Close()
                    oExcel.Quit()
                    oBook = Nothing
                    oExcel = Nothing
                    Datos_Lectura_Registro_QRS.Clear()
                    Datos_Lectura_Registro_QRS.Dispose()
                    Datos_Lectura_Registro_QRS.AcceptChanges()
                End If
            Next Index
        End If
        Exportacion_Resultados_Calculados.Nombre_Tablas_Existentes_6.Clear()
        Exportacion_Resultados_Calculados.Bandera_Finalizacion_6 = True
    End Sub

    Private Sub BackgroundWorker_Exportar_Resultados_1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_Exportar_Resultados_1.RunWorkerCompleted
        If Exportacion_Resultados_Calculados.Bandera_Finalizacion_1 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_2 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_3 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_4 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_5 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_6 = True Then
            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Me, "Data Export Completed", "", "Data Export Completed", 1)
            Me.Enabled = True
        End If

    End Sub

    Private Sub BackgroundWorker_Exportar_Resultados_2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_Exportar_Resultados_2.RunWorkerCompleted
        If Exportacion_Resultados_Calculados.Bandera_Finalizacion_1 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_2 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_3 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_4 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_5 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_6 = True Then
            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Me, "Data Export Completed", "", "Data Export Completed", 1)
            Me.Enabled = True
        End If
    End Sub

    Private Sub BackgroundWorker_Exportar_Resultados_4_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_Exportar_Resultados_4.RunWorkerCompleted
        If Exportacion_Resultados_Calculados.Bandera_Finalizacion_1 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_2 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_3 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_4 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_5 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_6 = True Then
            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Me, "Data Export Completed", "", "Data Export Completed", 1)
            Me.Enabled = True
        End If
    End Sub

    Private Sub BackgroundWorker_Exportar_Resultados_3_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_Exportar_Resultados_3.RunWorkerCompleted
        If Exportacion_Resultados_Calculados.Bandera_Finalizacion_1 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_2 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_3 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_4 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_5 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_6 = True Then
            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Me, "Data Export Completed", "", "Data Export Completed", 1)
            Me.Enabled = True
        End If
    End Sub

    Private Sub BackgroundWorker_Exportar_Resultados_5_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_Exportar_Resultados_5.RunWorkerCompleted
        If Exportacion_Resultados_Calculados.Bandera_Finalizacion_1 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_2 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_3 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_4 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_5 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_6 = True Then
            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Me, "Data Export Completed", "", "Data Export Completed", 1)
            Me.Enabled = True
        End If
    End Sub

    Private Sub BackgroundWorker_Exportar_Resultados_6_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_Exportar_Resultados_6.RunWorkerCompleted
        If Exportacion_Resultados_Calculados.Bandera_Finalizacion_1 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_2 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_3 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_4 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_5 = True And Exportacion_Resultados_Calculados.Bandera_Finalizacion_6 = True Then
            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Me, "Data Export Completed", "", "Data Export Completed", 1)
            Me.Enabled = True
        End If
    End Sub



    Private Sub Button_Principal_MouseEnter(sender As Object, e As EventArgs) Handles Button_Cambiar_Usuario.MouseEnter, Button_Modificar_Datos_Paciente.MouseEnter, Button_Modificar_Contraseña.MouseEnter, Button_Limpiar_Temporales.MouseEnter, Button_Exportar_Resultados.MouseEnter, Button_Eliminar_Usuario.MouseEnter, Button_Eliminar_Registro.MouseEnter, Button_Eliminar_Paciente.MouseEnter, Button_Crear_Usuario.MouseEnter, Button_Analizis_Registro.MouseEnter, Button_Almacenar_Multiples_Registros.MouseEnter, Button_Agregar_Grafica.MouseEnter, Button_Incertar_Registro.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Cambio_Boton
    End Sub

    Private Sub Button_Principal_MouseLeave(sender As Object, e As EventArgs) Handles Button_Cambiar_Usuario.MouseLeave, Button_Modificar_Datos_Paciente.MouseLeave, Button_Modificar_Contraseña.MouseLeave, Button_Limpiar_Temporales.MouseLeave, Button_Exportar_Resultados.MouseLeave, Button_Eliminar_Usuario.MouseLeave, Button_Eliminar_Registro.MouseLeave, Button_Eliminar_Paciente.MouseLeave, Button_Crear_Usuario.MouseLeave, Button_Analizis_Registro.MouseLeave, Button_Almacenar_Multiples_Registros.MouseLeave, Button_Agregar_Grafica.MouseLeave, Button_Incertar_Registro.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = Nothing
    End Sub

    Private Sub Button_Optimizar_Base_Datos_Click(sender As Object, e As EventArgs) Handles Button_Optimizar_Base_Datos.Click
        Me.Enabled = False
        Dim Coneccion_Base_Datos As New SqlConnection
        Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
        Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Base_Datos)
        Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Base_Datos)

        If Usuario_Activo.Tipo_Usuario = 2 Then
            Dim Usuarios As New DataSet
            Usuarios = Class_Funciones_Base_Datos.Tabla_Usuarios_Buscar_Usuarios(Coneccion_Base_Datos, "1")
            For Index_Usuarios = 0 To Usuarios.Tables(0).Rows.Count - 1
                Dim Paciente As DataSet
                Paciente = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Base_Datos, Usuarios.Tables(0).Rows(Index_Usuarios)(0))
                For Index_Paciente = 0 To Paciente.Tables(0).Rows.Count - 1
                    Dim Registros As DataSet
                    Registros = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Base_Datos, Usuarios.Tables(0).Rows(Index_Usuarios)(0), Paciente.Tables(0).Rows(Index_Paciente)(0))
                    For Index_Registros = 0 To Registros.Tables(0).Rows.Count - 1
                        Dim Derivaciones As List(Of String)
                        Derivaciones = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Derivaciones_Registro(Coneccion_Base_Datos, Usuarios.Tables(0).Rows(Index_Usuarios)(0), Paciente.Tables(0).Rows(Index_Paciente)(0), Registros.Tables(0).Rows(Index_Registros)(0))
                        For Index_Derivaciones = 0 To Derivaciones.Count - 1
                            Dim Coneccion_Registro As New SqlConnection
                            Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuarios.Tables(0).Rows(Index_Usuarios)(0), Paciente.Tables(0).Rows(Index_Paciente)(0), Registros.Tables(0).Rows(Index_Registros)(0), Derivaciones.Item(Index_Derivaciones).ToString)
                            Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Registro)
                            Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Registro)
                        Next Index_Derivaciones
                    Next Index_Registros
                Next Index_Paciente
            Next Index_Usuarios
        ElseIf Usuario_Activo.Tipo_Usuario = 1 Then
            Dim Usuarios As String = Usuario_Activo.Usuario
            Usuarios = Class_Funciones_Base_Datos.Tabla_Usuarios_Buscar_Usuarios(Coneccion_Base_Datos, "1")
            Dim Paciente As DataSet
            Paciente = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Base_Datos, Usuarios)
            For Index_Paciente = 0 To Paciente.Tables(0).Rows.Count - 1
                Dim Registros As DataSet
                Registros = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Base_Datos, Usuarios, Paciente.Tables(0).Rows(Index_Paciente)(0))
                For Index_Registros = 0 To Registros.Tables(0).Rows.Count - 1
                    Dim Derivaciones As List(Of String)
                    Derivaciones = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Derivaciones_Registro(Coneccion_Base_Datos, Usuarios, Paciente.Tables(0).Rows(Index_Paciente)(0), Registros.Tables(0).Rows(Index_Registros)(0))
                    For Index_Derivaciones = 0 To Derivaciones.Count - 1
                        Dim Coneccion_Registro As New SqlConnection
                        Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuarios, Paciente.Tables(0).Rows(Index_Paciente)(0), Registros.Tables(0).Rows(Index_Registros)(0), Derivaciones.Item(Index_Derivaciones).ToString)
                        Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Registro)
                        Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Registro)
                    Next Index_Derivaciones
                Next Index_Registros

            Next Index_Paciente
        End If
        Me.Enabled = True
        Dim Contraseña_Incorrecta As New Form_Mensaje_Error
        Contraseña_Incorrecta.Form_Mensaje(Me, " Database Optimization Completed ", "", " Database Optimization Completed ", 1)
    End Sub

    Private Sub Button_Buscar_Base_Datos_Click(sender As Object, e As EventArgs) Handles Button_Buscar_Base_Datos.Click
        If OpenFileDialog_Buscar_Base_Datos.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim Direccion_Base_Datos As String
            Direccion_Base_Datos = OpenFileDialog_Buscar_Base_Datos.FileName
            Direccion_Base_Datos = Direccion_Base_Datos.Substring(0, Direccion_Base_Datos.LastIndexOf("\"))
            Class_Funciones_Base_Datos.Actualizar_Direccion_Base_Datos(Direccion_Base_Datos)
            Application.Restart()
        End If
    End Sub

    Private Sub Button_Crear_Base_Datos_Click(sender As Object, e As EventArgs) Handles Button_Crear_Base_Datos.Click
        If FolderBrowserDialog_Ubicacion_Base_Datos.ShowDialog() = DialogResult.OK Then
            If My.Computer.FileSystem.FileExists(FolderBrowserDialog_Ubicacion_Base_Datos.SelectedPath + "\Base_Datos_ECG.mdf") = True Then
                Const message As String = "A database already exists. Do you want to rewrite it?"
                Const caption As String = "Database Error"
                Dim Result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                If Result.Yes = 6 Then
                    Class_Funciones_Base_Datos.Actualizar_Direccion_Base_Datos(FolderBrowserDialog_Ubicacion_Base_Datos.SelectedPath)
                    Dim Coneccion_Base_Datos As New SqlConnection
                    Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
                    Class_Funciones_Base_Datos.Crear_Base_Datos_Principal(Coneccion_Base_Datos)
                    Application.Restart()
                End If
            Else
                Class_Funciones_Base_Datos.Actualizar_Direccion_Base_Datos(FolderBrowserDialog_Ubicacion_Base_Datos.SelectedPath)
                Dim Coneccion_Base_Datos As New SqlConnection
                Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
                Class_Funciones_Base_Datos.Crear_Base_Datos_Principal(Coneccion_Base_Datos)
                Application.Restart()
            End If
        End If
    End Sub

    Private Sub Button_Administrar_Registro_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button_Buscar_Base_Datos_MouseEnter(sender As Object, e As EventArgs) Handles Button_Buscar_Base_Datos.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Cambio_Boton
    End Sub

    Private Sub Button_Optimizar_Base_Datos_MouseEnter(sender As Object, e As EventArgs) Handles Button_Optimizar_Base_Datos.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Cambio_Boton
    End Sub

    Private Sub Button_Crear_Base_Datos_MouseEnter(sender As Object, e As EventArgs) Handles Button_Crear_Base_Datos.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Cambio_Boton
    End Sub

    Private Sub Button_Crear_Base_Datos_Leave(sender As Object, e As EventArgs) Handles Button_Crear_Base_Datos.Leave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = Nothing
    End Sub

    Private Sub Button_Optimizar_Base_Datos_MouseLeave(sender As Object, e As EventArgs) Handles Button_Optimizar_Base_Datos.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = Nothing
    End Sub

    Private Sub Button_Buscar_Base_Datos_MouseLeave(sender As Object, e As EventArgs) Handles Button_Buscar_Base_Datos.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = Nothing
    End Sub

    Private Sub Button_Reiniciar_Base_Datos_MouseLeave(sender As Object, e As EventArgs) Handles Button_Reiniciar_Base_Datos.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = Nothing
    End Sub

    Private Sub Button_Reiniciar_Base_Datos_MouseEnter(sender As Object, e As EventArgs) Handles Button_Reiniciar_Base_Datos.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Cambio_Boton
    End Sub

    Private Sub Button_Crear_Base_Datos_MouseLeave(sender As Object, e As EventArgs) Handles Button_Crear_Base_Datos.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = Nothing
    End Sub
End Class
