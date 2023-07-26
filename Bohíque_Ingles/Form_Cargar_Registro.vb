Imports System.Data.SqlClient
Public Class Form_Cargar_Registro
    Dim filePath As String 'Nombre y direcion del archivo para obtener los registros
    Dim Referencia_Extencion As Int32
    Dim Desplazamiento_Inicial_Archivo As Int32 'Archivo Selecionado 
    Dim Desplazamiento_Final_Archivo As Int32   'Ultimo archivo
    Dim Puntero_Archivo As Int64
    Dim Tabla_registro As String 'Nombre de la tabal del Registro creado
    Dim Cargar_registro As Boolean = False 'Cofiram la cargar del registro 

    Public Structure Datos_Registro
        Public Usuario As String
        Public Paciente As String
        Public Fecha_Registro As String
        Public Frecuencia As String
    End Structure
    Public Incertar_Registro As Datos_Registro
    Private Sub Button_Buscar_Registro_Click(sender As Object, e As EventArgs) Handles Button_Buscar_Registro.Click
        Dim Bandera_Ultimo_Artchivo As Boolean = False
        Dim Temp_filePath As String
        If Cargar_registro = False Then
            If OpenFileDialog_Buscar_Registro.ShowDialog() = Windows.Forms.DialogResult.OK Then
                filePath = OpenFileDialog_Buscar_Registro.FileName
                Referencia_Extencion = filePath.IndexOf(".", 1)
                If filePath.Substring(Referencia_Extencion, 5) = ".ecga" Then
                    Try
                        If Convert.ToInt32(filePath.Substring(Referencia_Extencion - 3, 3)) = 0 Then
                            filePath = filePath.Remove(Referencia_Extencion - 1, 1)
                            filePath = filePath.Insert(Referencia_Extencion - 1, "1")
                            Desplazamiento_Inicial_Archivo = 1
                            Desplazamiento_Final_Archivo = 1
                        Else
                            Desplazamiento_Inicial_Archivo = Convert.ToInt32(filePath.Substring(Referencia_Extencion - 3, 3))
                            Desplazamiento_Final_Archivo = Desplazamiento_Inicial_Archivo
                        End If
                        'Identificar el ultimo archivo
                        Temp_filePath = filePath
                        Do
                            Desplazamiento_Final_Archivo = Desplazamiento_Final_Archivo + 1
                            If Desplazamiento_Final_Archivo < 10 Then
                                Temp_filePath = Temp_filePath.Remove(Referencia_Extencion - 1, 1)
                                Temp_filePath = Temp_filePath.Insert(Referencia_Extencion - 1, Convert.ToString(Desplazamiento_Final_Archivo))
                            ElseIf Desplazamiento_Final_Archivo > 9 And Desplazamiento_Final_Archivo < 100 Then
                                Temp_filePath = Temp_filePath.Remove(Referencia_Extencion - 2, 2)
                                Temp_filePath = Temp_filePath.Insert(Referencia_Extencion - 2, Convert.ToString(Desplazamiento_Final_Archivo))
                            ElseIf Desplazamiento_Final_Archivo > 99 And Desplazamiento_Final_Archivo < 1000 Then
                                Temp_filePath = Temp_filePath.Remove(Referencia_Extencion - 3, 3)
                                Temp_filePath = Temp_filePath.Insert(Referencia_Extencion - 3, Convert.ToString(Desplazamiento_Final_Archivo))
                            ElseIf Desplazamiento_Final_Archivo > 999 And Desplazamiento_Final_Archivo < 10000 Then
                                Temp_filePath = Temp_filePath.Remove(Referencia_Extencion - 4, 4)
                                Temp_filePath = Temp_filePath.Insert(Referencia_Extencion - 4, Convert.ToString(Desplazamiento_Final_Archivo))
                            End If
                            If System.IO.File.Exists(Temp_filePath) Then
                                Bandera_Ultimo_Artchivo = True
                            Else
                                Bandera_Ultimo_Artchivo = False
                                Desplazamiento_Final_Archivo = Desplazamiento_Final_Archivo - 1
                                'Maximo valor de la barra de progreso
                                ProgressBar_Cargar_Registro.Maximum = Desplazamiento_Final_Archivo
                            End If
                        Loop Until Bandera_Ultimo_Artchivo = False

                        'Dim inputFile = IO.File.Open(filePath, IO.FileMode.Open)
                        'Creo las conceciones para cada registro
                        Dim Coneccion_Registro_DI As New SqlConnection
                        Dim Coneccion_Registro_aVF As New SqlConnection
                        Dim Coneccion_Registro_V2 As New SqlConnection
                        Coneccion_Registro_DI.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Form_Principal.Incertar_Registro.Usuario, Form_Principal.Incertar_Registro.Paciente, Form_Principal.Incertar_Registro.Fecha_Registro, "DI")
                        Coneccion_Registro_aVF.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Form_Principal.Incertar_Registro.Usuario, Form_Principal.Incertar_Registro.Paciente, Form_Principal.Incertar_Registro.Fecha_Registro, "aVF")
                        Coneccion_Registro_V2.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Form_Principal.Incertar_Registro.Usuario, Form_Principal.Incertar_Registro.Paciente, Form_Principal.Incertar_Registro.Fecha_Registro, "V2")

                        'Creo el nombre de la Tabla
                        Tabla_registro = Form_Principal.Incertar_Registro.Usuario + "___" + Form_Principal.Incertar_Registro.Paciente + "___" + Form_Principal.Incertar_Registro.Fecha_Registro
                        Incertar_Registro.Usuario = Form_Principal.Incertar_Registro.Usuario
                        Incertar_Registro.Paciente = Form_Principal.Incertar_Registro.Paciente
                        Incertar_Registro.Fecha_Registro = Form_Principal.Incertar_Registro.Fecha_Registro
                        Incertar_Registro.Frecuencia = Form_Principal.Incertar_Registro.Frecuencia
                        'Crear Bases de datos para cada derivacion del registro
                        Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Registro_DI, Form_Principal.Incertar_Registro.Usuario + "___" + Form_Principal.Incertar_Registro.Paciente + "___" + Form_Principal.Incertar_Registro.Fecha_Registro + "___DI")
                        Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Registro_aVF, Form_Principal.Incertar_Registro.Usuario + "___" + Form_Principal.Incertar_Registro.Paciente + "___" + Form_Principal.Incertar_Registro.Fecha_Registro + "___aVF")
                        Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Registro_V2, Form_Principal.Incertar_Registro.Usuario + "___" + Form_Principal.Incertar_Registro.Paciente + "___" + Form_Principal.Incertar_Registro.Fecha_Registro + "___V2")
                        'Crear registros para cada derivacion en cada base de datos
                        Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Registro_DI, Tabla_registro, "DI")
                        Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Registro_aVF, Tabla_registro, "aVF")
                        Class_Funciones_Base_Datos.Registros_Crear_Registro(Coneccion_Registro_V2, Tabla_registro, "V2")

                        'Inicio del prosesamiento del registro   
                        Button_Buscar_Registro.Text = "Cancelar"
                        ProgressBar_Cargar_Registro.Value = 0
                        ProgressBar_Cargar_Registro.Visible = True
                        Puntero_Archivo = 0
                        Cargar_registro = True
                        Label_Estado_Carga_Registro.Text = "Cargando Registro: 0%"
                        BackgroundWorker_Cargar_Registro.RunWorkerAsync()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                ElseIf filePath.Substring(Referencia_Extencion, 5) = ".ecgb" Then
                    ''Creando la tabla
                    'IncertarProgramcion para este tipo de registro
                ElseIf filePath.Substring(Referencia_Extencion, 5) = ".ecgc" Then
                    ''Creando la tabla
                    'IncertarProgramcion para este tipo de registro
                End If
            End If
        Else
            Cargar_registro = False
            Button_Buscar_Registro.Enabled = False
            BackgroundWorker_Cargar_Registro.CancelAsync()
        End If
    End Sub

    Private Sub Button_Buscar_Registro_MouseEnter(sender As Object, e As EventArgs)
        Me.Button_Buscar_Registro.BackgroundImage = My.Resources.Boton_Verde_Cambio
    End Sub

    Private Sub Button_Buscar_Registro_MouseLeave(sender As Object, e As EventArgs)
        Me.Button_Buscar_Registro.BackgroundImage = My.Resources.Boton_Verde
    End Sub

    Private Sub Form_Cargar_Registro_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form_Principal.Enabled = True
    End Sub

    Private Sub Form_Cargar_Registro_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Form_Principal.Enabled = False
    End Sub

    Private Sub BackgroundWorker_Cargar_Registro_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Cargar_Registro.DoWork
        If filePath.Substring(Referencia_Extencion, 5) = ".ecga" Then
            While Desplazamiento_Inicial_Archivo <= Desplazamiento_Final_Archivo
                Dim Dato(1536000) As Byte '1.3 Mbytes de informacion aproximadamente

                Dim Dato1(5) As Double
                Dim Bandera_Lectura As Int32
                'Tablas temporales para almacenar los datos  de cada regsitro antes de enviarlos a la base de datos
                Dim Tabla_Datos_DI As New DataTable()
                Dim Tabla_Datos_aVF As New DataTable()
                Dim Tabla_Datos_V2 As New DataTable()
                Tabla_Datos_DI.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
                Tabla_Datos_DI.Columns.Add(New DataColumn("DI", GetType(System.Double)))
                Tabla_Datos_aVF.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
                Tabla_Datos_aVF.Columns.Add(New DataColumn("aVF", GetType(System.Double)))
                Tabla_Datos_V2.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
                Tabla_Datos_V2.Columns.Add(New DataColumn("V2", GetType(System.Double)))
                'Abre el archivo
                Dim inputFile = IO.File.Open(filePath, IO.FileMode.Open)
                'Creo las conecciones a las base de datos de cada registro
                Dim Coneccion_Registro_DI As New SqlConnection
                Dim Coneccion_Registro_aVF As New SqlConnection
                Dim Coneccion_Registro_V2 As New SqlConnection
                Coneccion_Registro_DI.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Incertar_Registro.Usuario, Incertar_Registro.Paciente, Incertar_Registro.Fecha_Registro, "DI")
                Coneccion_Registro_aVF.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Incertar_Registro.Usuario, Incertar_Registro.Paciente, Incertar_Registro.Fecha_Registro, "aVF")
                Coneccion_Registro_V2.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Incertar_Registro.Usuario, Incertar_Registro.Paciente, Incertar_Registro.Fecha_Registro, "V2")

                Bandera_Lectura = inputFile.Read(Dato, 0, 1536000) '1536000 bytes
                'Reconstrulle los datos del ecg apartir de los datos leeidos del archivo 
                While Bandera_Lectura > 0
                    For Index = 0 To ((Bandera_Lectura / 15) - 1)
                        'Dato de DI
                        Dato1(0) = ((Convert.ChangeType(Dato(15 * Index), TypeCode.Int64)) * 65536 + (Convert.ChangeType(Dato(1 + 15 * Index), TypeCode.Int64)) * 256 + (Convert.ChangeType(Dato(2 + 15 * Index), TypeCode.Int64))) - 8388608
                        Dato1(0) = Convert.ChangeType(Dato1(0), TypeCode.Double) * 0.1 / 1048576
                        'Intervalo RR de DI
                        Dato1(3) = (Convert.ChangeType(Dato(3 + 15 * Index), TypeCode.Int64)) + (Convert.ChangeType(Dato(4 + 15 * Index), TypeCode.Int64)) * 256

                        'Dato de aVF
                        Dato1(1) = ((Convert.ChangeType(Dato(15 * Index + 5), TypeCode.Int64)) * 65536 + (Convert.ChangeType(Dato(6 + 15 * Index), TypeCode.Int64)) * 256 + (Convert.ChangeType(Dato(7 + 15 * Index), TypeCode.Int64))) - 8388608
                        Dato1(1) = Dato1(1) * 0.1 / 1048576
                        'Intervalo RR de aVF
                        Dato1(4) = (Convert.ChangeType(Dato(8 + 15 * Index), TypeCode.Int64)) + (Convert.ChangeType(Dato(9 + 15 * Index), TypeCode.Int64)) * 256

                        'Dato de V2
                        Dato1(2) = ((Convert.ChangeType(Dato(15 * Index + 10), TypeCode.Int64)) * 65536 + (Convert.ChangeType(Dato(11 + 15 * Index), TypeCode.Int64)) * 256 + (Convert.ChangeType(Dato(12 + 15 * Index), TypeCode.Int64))) - 8388608
                        Dato1(2) = Dato1(2) * 0.1 / 1048576
                        'Intervalo RR de V2
                        Dato1(5) = (Convert.ChangeType(Dato(13 + 15 * Index), TypeCode.Int64)) + (Convert.ChangeType(Dato(14 + 15 * Index), TypeCode.Int64)) * 256
                        Tabla_Datos_DI.Rows.Add(Puntero_Archivo, Dato1(0))
                        Tabla_Datos_aVF.Rows.Add(Puntero_Archivo, Dato1(1))
                        Tabla_Datos_V2.Rows.Add(Puntero_Archivo, Dato1(2))
                        Puntero_Archivo = Puntero_Archivo + 1
                    Next Index
                    Try
                        'Derivacion DI
                        If Coneccion_Registro_DI.State = 0 Then
                            Coneccion_Registro_DI.Open()
                            Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Registro_DI, Tabla_registro, Tabla_Datos_DI)
                            Tabla_Datos_DI.Clear()
                            Coneccion_Registro_DI.Close()
                        Else
                            Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Registro_DI, Tabla_registro, Tabla_Datos_DI)
                            Tabla_Datos_DI.Clear()
                        End If
                        'Derivacion aVF
                        If Coneccion_Registro_aVF.State = 0 Then
                            Coneccion_Registro_aVF.Open()
                            Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Registro_aVF, Tabla_registro, Tabla_Datos_aVF)
                            Tabla_Datos_aVF.Clear()
                            Coneccion_Registro_aVF.Close()
                        Else
                            Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Registro_aVF, Tabla_registro, Tabla_Datos_aVF)
                            Tabla_Datos_aVF.Clear()
                        End If
                        'Derivacion V2
                        If Coneccion_Registro_V2.State = 0 Then
                            Coneccion_Registro_V2.Open()
                            Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Registro_V2, Tabla_registro, Tabla_Datos_V2)
                            Tabla_Datos_V2.Clear()
                            Coneccion_Registro_V2.Close()
                        Else
                            Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Registro_V2, Tabla_registro, Tabla_Datos_V2)
                            Tabla_Datos_V2.Clear()
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    'Indica la posicion de los datos leidos en el archivo
                    Bandera_Lectura = inputFile.Position
                    'Lee nuevos datos
                    Bandera_Lectura = inputFile.Read(Dato, 0, 1536000)
                End While
                'Cierra el archivo
                inputFile.Close()
                If BackgroundWorker_Cargar_Registro.CancellationPending = True Then
                    Coneccion_Registro_DI.Dispose()
                    Coneccion_Registro_aVF.Dispose()
                    Coneccion_Registro_V2.Dispose()
                    e.Cancel = True
                    Return
                End If
                BackgroundWorker_Cargar_Registro.ReportProgress(Desplazamiento_Inicial_Archivo)
                Desplazamiento_Inicial_Archivo = Desplazamiento_Inicial_Archivo + 1
                If Desplazamiento_Inicial_Archivo < Desplazamiento_Final_Archivo Then
                    'Prepara el siquiente archivo
                    If Desplazamiento_Inicial_Archivo < 10 Then
                        filePath = filePath.Remove(Referencia_Extencion - 1, 1)
                        filePath = filePath.Insert(Referencia_Extencion - 1, Convert.ToString(Desplazamiento_Inicial_Archivo))
                    ElseIf Desplazamiento_Inicial_Archivo > 9 And Desplazamiento_Inicial_Archivo < 100 Then
                        filePath = filePath.Remove(Referencia_Extencion - 2, 2)
                        filePath = filePath.Insert(Referencia_Extencion - 2, Convert.ToString(Desplazamiento_Inicial_Archivo))
                    ElseIf Desplazamiento_Inicial_Archivo > 99 And Desplazamiento_Inicial_Archivo < 1000 Then
                        filePath = filePath.Remove(Referencia_Extencion - 3, 3)
                        filePath = filePath.Insert(Referencia_Extencion - 3, Convert.ToString(Desplazamiento_Inicial_Archivo))
                    ElseIf Desplazamiento_Inicial_Archivo > 999 And Desplazamiento_Inicial_Archivo < 10000 Then
                        filePath = filePath.Remove(Referencia_Extencion - 4, 4)
                        filePath = filePath.Insert(Referencia_Extencion - 4, Convert.ToString(Desplazamiento_Inicial_Archivo))
                    End If
                End If
            End While
        ElseIf filePath.Substring(Referencia_Extencion, 5) = ".ecgb" Then
            'Por programar
        ElseIf filePath.Substring(Referencia_Extencion, 5) = ".ecgc" Then
            'Por programar
        End If

    End Sub

    Private Sub BackgroundWorker_Cargar_Registro_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_Cargar_Registro.RunWorkerCompleted

        Desplazamiento_Inicial_Archivo = 0
        Desplazamiento_Final_Archivo = 0

        Button_Buscar_Registro.Enabled = True
        ProgressBar_Cargar_Registro.Visible = False
        ProgressBar_Cargar_Registro.Value = 0

        Dim Contraseña_Incorrecta As New Form_Mensaje_Error

        If e.Cancelled = True Then
            'Hay que modificarlos por eso lo de je con errorCancelar  la carga del registro
            Dim Direccion_Archivo_mdf As String
            Dim Direccion_Archivo_ldf As String
            Direccion_Archivo_mdf = Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Form_Principal.Incertar_Registro.Usuario + "___" + Form_Principal.Incertar_Registro.Paciente + "___" + Form_Principal.Incertar_Registro.Fecha_Registro + "___DI" + ".mdf"
            Direccion_Archivo_ldf = Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Form_Principal.Incertar_Registro.Usuario + "___" + Form_Principal.Incertar_Registro.Paciente + "___" + Form_Principal.Incertar_Registro.Fecha_Registro + "___DI" + "_log.ldf"
            If My.Computer.FileSystem.FileExists(Direccion_Archivo_mdf) Then
                Try
                    System.IO.File.Delete(Direccion_Archivo_mdf)
                Catch ex As Exception
                    Dim Archivo_Pendiente = Direccion_Archivo_mdf
                    Dim Archivo_Eliminar As System.IO.StreamWriter
                    Archivo_Eliminar = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Eliminar.txt", True)
                    Archivo_Eliminar.WriteLine(Archivo_Pendiente)
                    Archivo_Eliminar.Close()
                End Try
            End If
            If My.Computer.FileSystem.FileExists(Direccion_Archivo_ldf) Then
                Try
                    System.IO.File.Delete(Direccion_Archivo_ldf)
                Catch ex As Exception
                    Dim Archivo_Pendiente = Direccion_Archivo_ldf
                    Dim Archivo_Eliminar As System.IO.StreamWriter
                    Archivo_Eliminar = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Eliminar.txt", True)
                    Archivo_Eliminar.WriteLine(Archivo_Pendiente)
                    Archivo_Eliminar.Close()
                End Try
            End If

            Direccion_Archivo_mdf = Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Form_Principal.Incertar_Registro.Usuario + "___" + Form_Principal.Incertar_Registro.Paciente + "___" + Form_Principal.Incertar_Registro.Fecha_Registro + "___aVF" + ".mdf"
            Direccion_Archivo_ldf = Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Form_Principal.Incertar_Registro.Usuario + "___" + Form_Principal.Incertar_Registro.Paciente + "___" + Form_Principal.Incertar_Registro.Fecha_Registro + "___aVF" + "_log.ldf"
            If My.Computer.FileSystem.FileExists(Direccion_Archivo_mdf) Then
                Try
                    System.IO.File.Delete(Direccion_Archivo_mdf)
                Catch ex As Exception
                    Dim Archivo_Pendiente = Direccion_Archivo_mdf
                    Dim Archivo_Eliminar As System.IO.StreamWriter
                    Archivo_Eliminar = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Eliminar.txt", True)
                    Archivo_Eliminar.WriteLine(Archivo_Pendiente)
                    Archivo_Eliminar.Close()
                End Try
            End If
            If My.Computer.FileSystem.FileExists(Direccion_Archivo_ldf) Then
                Try
                    System.IO.File.Delete(Direccion_Archivo_ldf)
                Catch ex As Exception
                    Dim Archivo_Pendiente = Direccion_Archivo_ldf
                    Dim Archivo_Eliminar As System.IO.StreamWriter
                    Archivo_Eliminar = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Eliminar.txt", True)
                    Archivo_Eliminar.WriteLine(Archivo_Pendiente)
                    Archivo_Eliminar.Close()
                End Try
            End If

            Direccion_Archivo_mdf = Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Form_Principal.Incertar_Registro.Usuario + "___" + Form_Principal.Incertar_Registro.Paciente + "___" + Form_Principal.Incertar_Registro.Fecha_Registro + "___V2" + ".mdf"
            Direccion_Archivo_ldf = Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Form_Principal.Incertar_Registro.Usuario + "___" + Form_Principal.Incertar_Registro.Paciente + "___" + Form_Principal.Incertar_Registro.Fecha_Registro + "___V2" + "_log.ldf"
            If My.Computer.FileSystem.FileExists(Direccion_Archivo_mdf) Then
                Try
                    System.IO.File.Delete(Direccion_Archivo_mdf)
                Catch ex As Exception
                    Dim Archivo_Pendiente = Direccion_Archivo_mdf
                    Dim Archivo_Eliminar As System.IO.StreamWriter
                    Archivo_Eliminar = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Eliminar.txt", True)
                    Archivo_Eliminar.WriteLine(Archivo_Pendiente)
                    Archivo_Eliminar.Close()
                End Try
            End If
            If My.Computer.FileSystem.FileExists(Direccion_Archivo_ldf) Then
                Try
                    System.IO.File.Delete(Direccion_Archivo_ldf)
                Catch ex As Exception
                    Dim Archivo_Pendiente = Direccion_Archivo_ldf
                    Dim Archivo_Eliminar As System.IO.StreamWriter
                    Archivo_Eliminar = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Eliminar.txt", True)
                    Archivo_Eliminar.WriteLine(Archivo_Pendiente)
                    Archivo_Eliminar.Close()
                End Try
            End If
            Me.Close()
        Else
            Dim Coneccion_Registro As New SqlConnection
            Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
            Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Agregar_Dato(Coneccion_Registro, Form_Principal.Incertar_Registro.Usuario, Form_Principal.Incertar_Registro.Paciente, Form_Principal.Incertar_Registro.Fecha_Registro, Form_Principal.Incertar_Registro.Frecuencia, "DI,aVF,V2")
            Me.Close()
        End If

    End Sub

    Private Sub BackgroundWorker_Cargar_Registro_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker_Cargar_Registro.ProgressChanged
        ProgressBar_Cargar_Registro.Value = e.ProgressPercentage
        Label_Estado_Carga_Registro.Text = "Cargando Registro: " + Convert.ToString(Math.Round(100 * (e.ProgressPercentage / Desplazamiento_Final_Archivo), 1)) + " %"
    End Sub

    Private Sub Button_Principal_MouseEnter(sender As Object, e As EventArgs) Handles Button_Buscar_Registro.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde_Cambio
    End Sub

    Private Sub Button_Principal_MouseLeave(sender As Object, e As EventArgs) Handles Button_Buscar_Registro.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde
    End Sub

End Class