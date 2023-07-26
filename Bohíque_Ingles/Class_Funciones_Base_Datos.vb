Imports System.Data.SqlClient
Imports System.IO
Public Class Class_Funciones_Base_Datos
    Public Const Valor_Max_Tabla = 1000000
    Public Shared Coneccion_Usuarios As New SqlConnection(My.Settings.Base_Datos_ECGConnectionString)
    Public Shared Direccion_Base_Datos As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\frank\Dropbox\Dropbox\Bohíque_FMS\Bohíque_FMS\Base_Datos_ECG.mdf;Integrated Security=true"
    Public Shared Function Modificar_TamanoMax_Base_Datos(Coneccion As SqlConnection, MAXSIZE_Unit As String)
        'Modifica el tamaño maximo que puede tner la base de datos
        'MAXSIZE_Unit Ejemplo:[ KB | MB | GB | TB ] | UNLIMITED 
        Dim sql_Modificar_Tamano As String = "ALTER DATABASE CURRENT MODIFY FILE (NAME='Base_Datos_ECG' , MAXSIZE = " + MAXSIZE_Unit + ")"

        Dim cmd_Modificar_Tamano As New SqlCommand(sql_Modificar_Tamano, Coneccion)

        If Coneccion.State <> 0 Then

            Try
                cmd_Modificar_Tamano.ExecuteNonQuery()
            Catch ex As Exception
                'Verificacion de si la tabla ya existe 1 
                MsgBox(ex.Message)
                cmd_Modificar_Tamano.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()

            Try
                cmd_Modificar_Tamano.ExecuteNonQuery()
            Catch ex As Exception
                'Verificacion de si la tabla ya existe 1 
                MsgBox(ex.Message)
                cmd_Modificar_Tamano.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Modificar_Tamano.Dispose()

        Return True
    End Function
    Public Shared Function Actualizar_Direccion_Base_Datos(Direccion As String)
        'Actualiza dirrecion la base de datos
        Direccion_Base_Datos = Direccion
        Dim Direccion_Acceso As String

        Direccion_Acceso = Application.UserAppDataPath + "\Direccion_Base_Datos.txt"
        If My.Computer.FileSystem.FileExists(Application.UserAppDataPath + "\Direccion_Base_Datos.txt") = False Then
            Dim Archivo_Escritura As TextWriter
            My.Computer.FileSystem.CopyFile(Application.StartupPath + "\Config\Direccion_Base_Datos.txt", Application.UserAppDataPath + "\Direccion_Base_Datos.txt", overwrite:=True)
            Archivo_Escritura = New StreamWriter(Application.UserAppDataPath + "\Direccion_Base_Datos.txt")
            Archivo_Escritura.WriteLine(Direccion_Base_Datos)
            Archivo_Escritura.Close()
        Else
            Dim Archivo_Escritura As TextWriter
            Archivo_Escritura = New StreamWriter(Application.UserAppDataPath + "\Direccion_Base_Datos.txt")
            Archivo_Escritura.WriteLine(Direccion_Base_Datos)
            Archivo_Escritura.Close()
        End If
        'Direccion_Base_Datos = "C:\Users\frank\OneDrive\Documentos\Base_Datos"
        'Direccion_Base_Datos = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= " + Direccion + ";Integrated Security=True"
        'Direccion_Base_Datos = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= " + Direccion + ";Integrated Security=True"

    End Function
    Public Shared Function Coneccion_Base_Datos()
        'Devuelve el SqlConnection de la Base da Datos

        If Coneccion_Usuarios.State <> 0 Then
            Coneccion_Usuarios.Close()
            Coneccion_Usuarios.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= " + Class_Funciones_Base_Datos.Direccion_Base_Datos + "\Base_Datos_ECG.mdf ;Integrated Security=True"
            Coneccion_Usuarios.Open()
        Else
            Coneccion_Usuarios.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= " + Class_Funciones_Base_Datos.Direccion_Base_Datos + "\Base_Datos_ECG.mdf ;Integrated Security=True"
        End If

        Return Coneccion_Usuarios
    End Function

    Public Shared Function Coneccion_Base_Datos(Usuario As String, Paciente As String, Fecha As String, Derivacion As String)
        'Devuelve el SqlConnection de la Base da Datos

        If Coneccion_Usuarios.State <> 0 Then
            Coneccion_Usuarios.Close()
            Coneccion_Usuarios.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= " + Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Usuario + "___" + Paciente + "___" + Fecha + "___" + Derivacion + ".mdf ;Integrated Security=True"
            Coneccion_Usuarios.Open()
        Else
            Coneccion_Usuarios.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= " + Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Usuario + "___" + Paciente + "___" + Fecha + "___" + Derivacion + ".mdf ;Integrated Security=True"
        End If

        Return Coneccion_Usuarios
    End Function
    Public Shared Function Coneccion_Base_Datos_ConnectionString()
        'Devuelve el SqlConnection de la Base da Datos
        Return "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= " + Class_Funciones_Base_Datos.Direccion_Base_Datos + "\Base_Datos_ECG.mdf ;Integrated Security=True"
    End Function
    Public Shared Function Coneccion_Base_Datos_ConnectionString(Usuario As String, Paciente As String, Fecha As String, Derivacion As String)
        'Devuelve el SqlConnection de la Base da Datos
        Return "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Usuario + "___" + Paciente + "___" + Fecha + "___" + Derivacion + ".mdf; ;Integrated Security=True"
    End Function
    Public Shared Function Coneccion_Base_Datos_ConnectionString(Nombre_Base_Datos As String)
        'Devuelve el SqlConnection de la Base da Datos
        Return "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Nombre_Base_Datos + ".mdf; ;Integrated Security=True"
    End Function
    Public Shared Function Eliminar_Base_Datos(Nombre_Base_Datos As String)
        Dim Bandera_Necesario_Reiniciar As Boolean = False
        'Eliminar la bases de datos o la pone penidente a eliminar
        Dim Direccion_Archivo_mdf As String
        Dim Direccion_Archivo_ldf As String

        Direccion_Archivo_mdf = Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Nombre_Base_Datos + ".mdf"
        Direccion_Archivo_ldf = Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Nombre_Base_Datos + "_log.ldf"
        If My.Computer.FileSystem.FileExists(Direccion_Archivo_mdf) Then
                Try
                    System.IO.File.Delete(Direccion_Archivo_mdf)
                Catch ex As Exception
                    Bandera_Necesario_Reiniciar = True
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
                    Bandera_Necesario_Reiniciar = True
                    Dim Archivo_Pendiente = Direccion_Archivo_ldf
                    Dim Archivo_Eliminar As System.IO.StreamWriter
                    Archivo_Eliminar = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Eliminar.txt", True)
                    Archivo_Eliminar.WriteLine(Archivo_Pendiente)
                    Archivo_Eliminar.Close()
                End Try
            End If

        Return Bandera_Necesario_Reiniciar
    End Function

    Public Shared Function Estado_Base_Datos(Coneccion As SqlConnection)
        'Devuelve  true si no ahy problemas con la tabla Base Datos
        'Devuelve  False si ahy problemas con la tabla Base Datos
        Try
            'Compruebo que puedo abrir la base de datos 
            Coneccion.Open()
            'Compruebo que tiene las tablas basicas 
            If Tabla_Existe(Coneccion, "Usuarios") = False Then
                Coneccion.Close()
                Return False
            ElseIf Tabla_Existe(Coneccion, "Datos_Pacientes") = False Then
                Coneccion.Close()
                Return False
            ElseIf Tabla_Existe(Coneccion, "Relacion_Registro_Derivacion_Procesada") = False Then
                Coneccion.Close()
                Return False
            ElseIf Tabla_Existe(Coneccion, "Relacion_Registro_Paciente_Usuario") = False Then
                Coneccion.Close()
                Return False
            End If
            Coneccion.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Shared Function Reiniciar_Base_Datos(Coneccion As SqlConnection)
        Try
            Dim Nombre_Tablas_Existentes As New DataSet
            Nombre_Tablas_Existentes = Class_Funciones_Base_Datos.Tabla_Todas_Existentes(Coneccion)
            'Borrar tablas existentes
            For Index = Nombre_Tablas_Existentes.Tables(0).Rows.Count - 1 To 0 Step -1
                Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Nombre_Tablas_Existentes.Tables(0).Rows(Index)(0))
            Next Index
            'Crear tabla Datos_Pacientes
            Class_Funciones_Base_Datos.Crear_Tabla(Coneccion, "Datos_Pacientes", "Usuario", " NVARCHAR (MAX)  NOT NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Datos_Pacientes", "Nombre_Paciente_Apellidos", "NVARCHAR(MAX) Not NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Datos_Pacientes", "Peso_kg", "Int Not NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Datos_Pacientes", "Estatura_cm", "Int Not NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Datos_Pacientes", "Sexo", "NVARCHAR(MAX) Not NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Datos_Pacientes", "Raza", "NVARCHAR(MAX) Not NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Datos_Pacientes", "Fecha_Nacimiento", "NVARCHAR(MAX) Not NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Datos_Pacientes", "Marca_Paso", "NVARCHAR(MAX) Not NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Datos_Pacientes", "Detalles_Paciente", "NVARCHAR(MAX)  NULL")

            'Crear tabla Usuarios
            Class_Funciones_Base_Datos.Crear_Tabla(Coneccion, "Usuarios", "Tipo_de_Usuario", "Int Not NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Usuarios", "Usuario", "NVARCHAR(MAX) Not NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Usuarios", "Contraseña", "NVARCHAR(MAX) Not NULL")
            Class_Funciones_Base_Datos.Tabla_Usuarios_Agregar_Usuario(Coneccion, "2", "FrankMS", "1")
            Class_Funciones_Base_Datos.Tabla_Usuarios_Agregar_Usuario(Coneccion, "1", "FrankMS", "1")

            'Crear tabla Relacion_Registro_Paciente_Usuario
            Class_Funciones_Base_Datos.Crear_Tabla(Coneccion, "Relacion_Registro_Paciente_Usuario", "Usuario", "NVARCHAR(MAX) Not NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Paciente_Usuario", "Nombre_Paciente", "NVARCHAR(MAX) Not NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Paciente_Usuario", "Fecha_Registro", "NVARCHAR(MAX) Not NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Paciente_Usuario", "Frecuencia", "FLOAT(53) NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Paciente_Usuario", "Derivaciones", "NVARCHAR(MAX)")

            'Crear tabla Relacion_Registro_Paciente_Usuario
            'Class_Funciones_Base_Datos.Eliminar_Tabla(Coneccion, "Relacion_Registro_Derivacion_Procesada")
            Class_Funciones_Base_Datos.Crear_Tabla(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Registro", "NVARCHAR(MAX) Not NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Derivacion", "NVARCHAR(MAX) Not NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Derivacion_Filtrada", "BIT NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Complejo_QRS", "BIT NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Onda_T", "BIT NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Onda_P", "BIT NULL")


            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Intervalo_R_R", "BIT NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Intervalo_R_Ti", "BIT NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Intervalo_R_T", "BIT NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Intervalo_R_Tf", "BIT NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Intervalo_Pi_R", "BIT NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Intervalo_P_R", "BIT NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Intervalo_Pf_R", "BIT NULL")

            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Intervalo_Q_Ti", "BIT NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Intervalo_Q_T", "BIT NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Intervalo_Q_Tf", "BIT NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Intervalo_Pi_Q", "BIT NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Intervalo_P_Q", "BIT NULL")
            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, "Relacion_Registro_Derivacion_Procesada", "Intervalo_Pf_Q", "BIT NULL")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Crear_Base_Datos_Principal(Coneccion As SqlConnection)
        Dim Archivo_Reporte As System.IO.StreamWriter
        Dim Prueba As New SqlConnection(My.Settings.Base_Datos_ECGConnectionString)
        Try
            'Si el archivo tiene de la base de datos problemas resetea la base de datos  
            'Si el archivo de la base de datos no existe copia el respalado 
            'Reescrobri el archivpo Direccion_Base_Datos.txt y guardo la direcion de la base de datos
            Dim Archivo_Escritura As TextWriter
            My.Computer.FileSystem.CopyFile(Application.StartupPath + "\Config\Direccion_Base_Datos.txt", Application.UserAppDataPath + "\Direccion_Base_Datos.txt", overwrite:=True)
            My.Computer.FileSystem.CopyFile(Application.StartupPath + "\Config\Direccion_Base_Datos.txt", Application.UserAppDataPath + "\Reporte.txt", overwrite:=True)
            Archivo_Escritura = New StreamWriter(Application.UserAppDataPath + "\Direccion_Base_Datos.txt")

            Archivo_Escritura.WriteLine(Direccion_Base_Datos)
            Archivo_Escritura.Close()
            '----------------------------------------------------------------------------
            'Reporte
            Archivo_Reporte = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Reporte.txt", True)
            Archivo_Reporte.WriteLine("Copiar archivo Direccion_Base_Datos.txt finalizado\n")
            Archivo_Reporte.Close()
            '----------------------------------------------------------------------------

            'Pregunto si existe el la base de datos y copio los archivos 
            If My.Computer.FileSystem.FileExists(Class_Funciones_Base_Datos.Direccion_Base_Datos + "\Base_Datos_ECG.mdf") = False Then
                My.Computer.FileSystem.CopyFile(Application.StartupPath + "\Config\Base_Datos_ECG_log.txt", Class_Funciones_Base_Datos.Direccion_Base_Datos + "\Base_Datos_ECG_log.ldf", overwrite:=True)
                My.Computer.FileSystem.CopyFile(Application.StartupPath + "\Config\Base_Datos_ECG.txt", Class_Funciones_Base_Datos.Direccion_Base_Datos + "\Base_Datos_ECG.mdf", overwrite:=True)
                'Crear_Base_Datos_Principal("Base_Datos_ECG")
                'Trata de leer el archivo para confirmar la finalizacion de la copia y esta disponible parar trabajar con la base de datos 
                '----------------------------------------------------------------------------
                'Reporte
                Archivo_Reporte = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Reporte.txt", True)
                Archivo_Reporte.WriteLine("Copiar base de datos finalizado")
                Archivo_Reporte.Close()
                '----------------------------------------------------------------------------

                Dim Bandera_Archivo_Listo As Boolean = False
                While Bandera_Archivo_Listo = False
                    Try
                        '----------------------------------------------------------------------------
                        'Reporte
                        Archivo_Reporte = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Reporte.txt", True)
                        Archivo_Reporte.WriteLine("Probar conexcion con Base de datos:")
                        Archivo_Reporte.WriteLine("ConnectionString:" + Coneccion.ConnectionString)
                        Archivo_Reporte.Close()
                        '----------------------------------------------------------------------------

                        Coneccion.Open()
                        Bandera_Archivo_Listo = True
                        Coneccion.Close()
                    Catch ex As Exception
                        '----------------------------------------------------------------------------
                        'Reporte
                        Archivo_Reporte = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Reporte.txt", True)
                        Archivo_Reporte.WriteLine("Error Conectando")
                        Archivo_Reporte.Close()
                        '----------------------------------------------------------------------------
                        Bandera_Archivo_Listo = False
                    End Try
                End While

                'Reinicio la base de datos, optimiso el espacio y los indices de busqueda
                If Reiniciar_Base_Datos(Coneccion) = False Then
                    '----------------------------------------------------------------------------
                    'Reporte
                    Archivo_Reporte = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Reporte.txt", True)
                    Archivo_Reporte.WriteLine("Error reiniciando Base de datos")
                    Archivo_Reporte.Close()
                    '----------------------------------------------------------------------------
                    Return False

                ElseIf Optimizar_Espacio_Base_Datos(Coneccion) = False Then
                    '----------------------------------------------------------------------------
                    'Reporte
                    Archivo_Reporte = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Reporte.txt", True)
                    Archivo_Reporte.WriteLine("Error optimizando espacio Base de datos")
                    Archivo_Reporte.Close()
                    '----------------------------------------------------------------------------
                    Return False
                ElseIf Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion) = False Then
                    '----------------------------------------------------------------------------
                    'Reporte
                    Archivo_Reporte = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Reporte.txt", True)
                    Archivo_Reporte.WriteLine("Error optimizando espacio index Base de datos")
                    Archivo_Reporte.Close()
                    '----------------------------------------------------------------------------
                    Return False
                End If

                '----------------------------------------------------------------------------
                'Reporte
                Archivo_Reporte = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Reporte.txt", True)
                Archivo_Reporte.WriteLine("inicializacion completada")
                Archivo_Reporte.WriteLine("****************************************************************")
                Archivo_Reporte.Close()
                '----------------------------------------------------------------------------

                Return True
            End If
        Catch ex As Exception

            MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function
    Public Shared Function Crear_Base_Datos(Coneccion As SqlConnection, Nombre_Base_Datos As String)
        Try
            'Si el archivo tiene de la base de datos problemas resetea la base de datos  
            'Si el archivo de la base de datos no existe copia el respalado 
            'Reescribir el archivpo Direccion_Base_Datos.txt y guardo la direcion de la base de datos
            'Pregunto si existe el la base de datos y copio los archivos 
            If My.Computer.FileSystem.FileExists(Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Nombre_Base_Datos + ".mdf") = False Then
                My.Computer.FileSystem.CopyFile(Application.StartupPath + "\Config\Base_Datos_ECG_log.txt", Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Nombre_Base_Datos + "_log.ldf", overwrite:=True)
                My.Computer.FileSystem.CopyFile(Application.StartupPath + "\Config\Base_Datos_ECG.txt", Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Nombre_Base_Datos + ".mdf", overwrite:=True)
                'Trata de leer el archivo para confirmar la finalizacion de la copia y esta disponible parar trabajar con la base de datos 
                Dim Bandera_Archivo_Listo As Boolean = False
                While Bandera_Archivo_Listo = False
                    Try
                        Coneccion.Open()
                        Bandera_Archivo_Listo = True
                        Coneccion.Close()
                    Catch ex As Exception
                        Bandera_Archivo_Listo = False
                    End Try
                End While
                'Optimiso el espacio y los indices de busqueda
                If Optimizar_Espacio_Base_Datos(Coneccion) = False Then
                    Return False
                ElseIf Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion) = False Then
                    Return False
                End If
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Public Shared Function Optimizar_Espacio_Base_Datos(Coneccion As SqlConnection)
        'Elimina el espacio no utilizado por  de la bases de datos y deja 20% de espacio libre para su funcionamiento 

        Dim sql_Reducir_Tabla As String = "DBCC SHRINKDATABASE (0, 20);"
        Dim cmd_Reducir_Tabla As New SqlCommand(sql_Reducir_Tabla, Coneccion)

        If Coneccion.State <> 0 Then
            Try
                cmd_Reducir_Tabla.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Reducir_Tabla.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                cmd_Reducir_Tabla.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Reducir_Tabla.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If
        cmd_Reducir_Tabla.Dispose()
        Return True

    End Function
    Public Shared Function Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion As SqlConnection)
        'Reconstruye los Indices Acceso a las Tabla en Base_Datos
        Dim Nombre_Tablas_Existentes As DataSet = Tabla_Todas_Existentes(Coneccion)
        If Coneccion.State <> 0 Then
            Try
                For Index = Nombre_Tablas_Existentes.Tables(0).Rows.Count - 1 To 0 Step -1
                    Dim sql_Reducir_Tabla As String = "ALTER INDEX ALL ON " + Nombre_Tablas_Existentes.Tables(0).Rows(Index)(0) + " REBUILD;"
                    Dim cmd_Reducir_Tabla As New SqlCommand(sql_Reducir_Tabla, Coneccion)
                    cmd_Reducir_Tabla.ExecuteNonQuery()
                    cmd_Reducir_Tabla.Dispose()
                Next Index
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                For Index = Nombre_Tablas_Existentes.Tables(0).Rows.Count - 1 To 0 Step -1
                    Dim sql_Reducir_Tabla As String = "ALTER INDEX ALL ON " + Nombre_Tablas_Existentes.Tables(0).Rows(Index)(0) + " REBUILD;"
                    Dim cmd_Reducir_Tabla As New SqlCommand(sql_Reducir_Tabla, Coneccion)
                    cmd_Reducir_Tabla.ExecuteNonQuery()
                    cmd_Reducir_Tabla.Dispose()
                Next Index
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
            Coneccion.Close()
        End If
        Return True
    End Function

    '----------------------------------------------------------------------------------------------------------------------------------------------------
    'Operaciones Generales con Tablas
    Public Shared Function Tabla_Existe(Coneccion As SqlConnection, Nombre_Tabla As String)
        Dim Bandera As Boolean
        'Determinar si existentees la tabla 
        Dim sql_Columnas_Existentes As String = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + Nombre_Tabla + "'"
        Dim cmd_Columnas_Existentes As New SqlCommand(sql_Columnas_Existentes, Coneccion)
        Dim Adaptador_Columnas_Existentes As New SqlDataAdapter(cmd_Columnas_Existentes)
        Dim Datos_Columnas_Existentes As New DataSet

        If Coneccion.State <> 0 Then
            Try
                Adaptador_Columnas_Existentes.Fill(Datos_Columnas_Existentes, Nombre_Tabla)
                If Datos_Columnas_Existentes.Tables(Nombre_Tabla).Rows.Count <> 0 Then
                    Bandera = True
                Else
                    Bandera = False
                End If
            Catch ex As Exception
                Bandera = False
                MsgBox(ex.Message)
            End Try

        Else
            Coneccion.Open()
            Try
                Adaptador_Columnas_Existentes.Fill(Datos_Columnas_Existentes, Nombre_Tabla)
                If Datos_Columnas_Existentes.Tables(Nombre_Tabla).Rows.Count <> 0 Then
                    Bandera = True
                Else
                    Bandera = False
                End If
            Catch ex As Exception
                Bandera = False
                MsgBox(ex.Message)
            End Try
            Coneccion.Close()
        End If

        cmd_Columnas_Existentes.Dispose()
        Adaptador_Columnas_Existentes.Dispose()

        Datos_Columnas_Existentes.Clear()
        Datos_Columnas_Existentes.Dispose()
        Datos_Columnas_Existentes.AcceptChanges()

        Return Bandera
    End Function
    Public Shared Function Tabla_Todas_Existentes(ByRef Coneccion As SqlConnection)
        'Obtiene todas las tablas de la base de datos
        Dim sql_Tablas_Existentes As String = "select name from sysobjects where type='U'"
        Dim cmd_Tablas_Existentes As New SqlCommand(sql_Tablas_Existentes, Coneccion)
        Dim Adaptador_Tablas_Existentes As New SqlDataAdapter(cmd_Tablas_Existentes)
        Dim Nombre_Tablas_Existentes As New DataSet
        If Coneccion.State <> 0 Then
            'Obtiene todas las tablas de la base de datos
            Try
                Adaptador_Tablas_Existentes.Fill(Nombre_Tablas_Existentes, "Tablas")
            Catch ex As Exception

                MsgBox(ex.Message)
            End Try
        Else
            Coneccion.Open()
            'Obtiene todas las tablas de la base de datos
            Try
                Adaptador_Tablas_Existentes.Fill(Nombre_Tablas_Existentes, "Tablas")
            Catch ex As Exception

                MsgBox(ex.Message)
            End Try
            Coneccion.Close()
        End If
        cmd_Tablas_Existentes.Dispose()
        Adaptador_Tablas_Existentes.Dispose()

        Return Nombre_Tablas_Existentes
    End Function
    Public Shared Function Tabla_Renombrar(Coneccion As SqlConnection, Nombre_Tabla_Actual As String, Nombre_Tabla_Nuevo As String)
        'Renombrar tabla 
        Dim sql_Renombrar_Tabla As String = "EXEC sp_rename " + Nombre_Tabla_Actual + " , " + Nombre_Tabla_Nuevo
        Dim cmd_Renombrar_Tabla As New SqlCommand(sql_Renombrar_Tabla, Coneccion)

        If Coneccion.State <> 0 Then
            Try
                cmd_Renombrar_Tabla.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Renombrar_Tabla.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                cmd_Renombrar_Tabla.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Renombrar_Tabla.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If
        cmd_Renombrar_Tabla.Dispose()

        Return True

    End Function
    Public Shared Function Tabla_Eliminar(Coneccion As SqlConnection, Tabla As String)
        'Eliminar tabla 
        Dim sql_Eliminar_Tabla As String = " DROP TABLE IF EXISTS " + Tabla
        Dim cmd_Eliminar_Tabla As New SqlCommand(sql_Eliminar_Tabla, Coneccion)

        If Coneccion.State <> 0 Then

            Try
                cmd_Eliminar_Tabla.ExecuteNonQuery()
            Catch ex As Exception
                'Verificacion de si la tabla ya existe 1 
                MsgBox(ex.Message)
                cmd_Eliminar_Tabla.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()

            Try
                cmd_Eliminar_Tabla.ExecuteNonQuery()
            Catch ex As Exception
                'Verificacion de si la tabla ya existe 1 
                MsgBox(ex.Message)
                cmd_Eliminar_Tabla.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Eliminar_Tabla.Dispose()

        Return True
    End Function

    Public Shared Function Tabla_Consultar(Coneccion As SqlConnection, Nombre_Tabla As String)
        'Consultar todos los datos de la tabla 
        Dim sql_Tabla_Consultar As String = "SELECT * FROM " + Nombre_Tabla
        Dim cmd_Tabla_Consultar As New SqlCommand(sql_Tabla_Consultar, Coneccion)
        Dim Adaptador As New SqlDataAdapter(cmd_Tabla_Consultar)
        Dim Datos_Registro_Consulta As New DataSet

        If Coneccion.State <> 0 Then
            Try
                Adaptador.Fill(Datos_Registro_Consulta, Nombre_Tabla)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Coneccion.Open()
            Try
                Adaptador.Fill(Datos_Registro_Consulta, Nombre_Tabla)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Coneccion.Close()
        End If
        cmd_Tabla_Consultar.Dispose()
        Adaptador.Dispose()

        Return Datos_Registro_Consulta
    End Function

    Public Shared Function Crear_Tabla(Coneccion As SqlConnection, Nombre_Tabla As String, Nombre_Columnas As String, Tipo_Dato As String)
        'Creando la tabla
        Dim sql_Crear_Tabla As String = " CREATE TABLE  " + Nombre_Tabla + " ( [" + Nombre_Columnas + "]  " + Tipo_Dato + " )"
        Dim cmd_Crear_Tabla As New SqlCommand(sql_Crear_Tabla, Coneccion)

        If Coneccion.State <> 0 Then
            Try
                Dim Adapter_Crear_Tabla As New SqlDataAdapter(cmd_Crear_Tabla)
                cmd_Crear_Tabla.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Crear_Tabla.Dispose()
                Return False

            End Try
        Else
            Coneccion.Open()
            Try
                Dim Adapter_Crear_Tabla As New SqlDataAdapter(cmd_Crear_Tabla)
                cmd_Crear_Tabla.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Crear_Tabla.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Crear_Tabla.Dispose()

        Return True

    End Function

    '----------------------------------------------------------------------------------------------------------------------------------------------------
    'Operaciones con Columnas
    Public Shared Function Adicionar_Columna(Coneccion As SqlConnection, Nombre_Tabla As String, Nombre_Columnas As String, Tipo_Dato As String)
        'Crear la columna en la tabla 
        Dim sql_Crear_Columna As String = "ALTER TABLE " + Nombre_Tabla + " ADD " + Nombre_Columnas + " " + Tipo_Dato
        Dim cmd_Crear_Columna As New SqlCommand(sql_Crear_Columna, Coneccion)

        If Coneccion.State <> 0 Then
            Try
                Dim Crear_Columna As New SqlDataAdapter(cmd_Crear_Columna)
                cmd_Crear_Columna.ExecuteNonQuery()
            Catch ex As Exception
                'Verificacion de si la tabla ya existe
                MsgBox(ex.Message)
                cmd_Crear_Columna.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                Dim Crear_Columna As New SqlDataAdapter(cmd_Crear_Columna)
                cmd_Crear_Columna.ExecuteNonQuery()
            Catch ex As Exception
                'Verificacion de si la tabla ya existe
                MsgBox(ex.Message)
                cmd_Crear_Columna.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Crear_Columna.Dispose()

        Return True

    End Function
    Public Shared Function Eliminar_Columna(Coneccion As SqlConnection, Nombre_Tabla As String, Nombre_Columnas As String)
        'Crear la columna en la tabla 
        Dim sql_Crear_Columna As String = "ALTER TABLE " + Nombre_Tabla + " DROP COLUMN IF EXISTS " + Nombre_Columnas
        Dim cmd_Crear_Columna As New SqlCommand(sql_Crear_Columna, Coneccion)
        Dim Crear_Columna As New SqlDataAdapter(cmd_Crear_Columna)

        If Coneccion.State <> 0 Then
            Try
                cmd_Crear_Columna.ExecuteNonQuery()
            Catch ex As Exception
                'Verificacion de si la tabla ya existe
                MsgBox(ex.Message)
                cmd_Crear_Columna.Dispose()
                Crear_Columna.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                cmd_Crear_Columna.ExecuteNonQuery()
            Catch ex As Exception
                'Verificacion de si la tabla ya existe
                MsgBox(ex.Message)
                cmd_Crear_Columna.Dispose()
                Crear_Columna.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Crear_Columna.Dispose()
        Crear_Columna.Dispose()

        Return True

    End Function
    Public Shared Function Copiar_Columna(Coneccion As SqlConnection, Tabla_Origen As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String)
        'Importante Ambas tablas tienen que tener el campo Puntero y de preferencias que tengan la misma cantidad de datos
        'Actualizar la columna en la tabla final de la trasnformada Wavelet
        Const Aumento_Puntero = 200000 'Cantidad Maxima de datios prosesada de forma simultanea

        Dim Max_Puntero As Int64 = 0
        Dim Puntero As Int64 = 0

        Dim sql_Actualizaar As String = "UPDATE " + Tabla_Almacenamiento_Resultados + " SET " + Tabla_Almacenamiento_Resultados + "." + Nombre_Columna + "=Tabla_Origen." + Nombre_Columna + " FROM " + Tabla_Almacenamiento_Resultados + " Tabla_Destino INNER JOIN " + Tabla_Origen + " Tabla_Origen  ON Tabla_Destino.Puntero=Tabla_Origen.Puntero WHERE Tabla_Destino.Puntero>=" + "0" + " and Tabla_Destino.Puntero<=" + "100000" + ""
        Dim cmd_Actualizar As New SqlCommand(sql_Actualizaar, Coneccion)


        If Coneccion.State <> 0 Then
            Try
                Max_Puntero = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados)
                While Puntero <= Max_Puntero
                    sql_Actualizaar = "UPDATE " + Tabla_Almacenamiento_Resultados + " SET " + Tabla_Almacenamiento_Resultados + "." + Nombre_Columna + "=Tabla_Origen." + Nombre_Columna + " FROM " + Tabla_Almacenamiento_Resultados + " Tabla_Destino INNER JOIN " + Tabla_Origen + " Tabla_Origen  ON Tabla_Destino.Puntero=Tabla_Origen.Puntero WHERE Tabla_Destino.Puntero>=" + Convert.ToString(Puntero) + " and Tabla_Destino.Puntero<" + Convert.ToString(Puntero + Aumento_Puntero) + ""
                    cmd_Actualizar.Dispose()
                    cmd_Actualizar = New SqlCommand(sql_Actualizaar, Coneccion)
                    cmd_Actualizar.ExecuteNonQuery()
                    Puntero = Puntero + Aumento_Puntero
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Actualizar.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                Max_Puntero = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion, Tabla_Almacenamiento_Resultados)
                While Puntero <= Max_Puntero
                    sql_Actualizaar = "UPDATE " + Tabla_Almacenamiento_Resultados + " SET " + Tabla_Almacenamiento_Resultados + "." + Nombre_Columna + "=Tabla_Origen." + Nombre_Columna + " FROM " + Tabla_Almacenamiento_Resultados + " Tabla_Destino INNER JOIN " + Tabla_Origen + " Tabla_Origen  ON Tabla_Destino.Puntero=Tabla_Origen.Puntero WHERE Tabla_Destino.Puntero>=" + Convert.ToString(Puntero) + " and Tabla_Destino.Puntero<" + Convert.ToString(Puntero + Aumento_Puntero) + ""
                    cmd_Actualizar.Dispose()
                    cmd_Actualizar = New SqlCommand(sql_Actualizaar, Coneccion)
                    cmd_Actualizar.ExecuteNonQuery()
                    Puntero = Puntero + Aumento_Puntero
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Actualizar.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If
        cmd_Actualizar.Dispose()

        Return True

    End Function
    Public Shared Function Tipo_Dato_Columna(Coneccion As SqlConnection, Nombre_Tabla As String, Nombre_Columna As String)
        Dim Tipo_dato As String = ""
        'Devuelve el tipo de dato de una columna en la tabla
        Dim sql_Tipo_Dato_Columna As String = "Select DATA_TYPE From information_schema.columns Where TABLE_NAME = '" + Nombre_Tabla + "' AND COLUMN_NAME='" + Nombre_Columna + "'"
        Dim cmd_Tipo_Dato_Columna As New SqlCommand(sql_Tipo_Dato_Columna, Coneccion)
        Dim Adaptador_Tipo_Dato_Columna As New SqlDataAdapter(cmd_Tipo_Dato_Columna)
        Dim Datos_Tipo_Dato_Columna As New DataSet

        If Coneccion.State <> 0 Then
            Try
                Adaptador_Tipo_Dato_Columna.Fill(Datos_Tipo_Dato_Columna, Nombre_Tabla)
                Tipo_dato = Datos_Tipo_Dato_Columna.Tables(0).Rows(0)(0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Coneccion.Open()
            Try
                Adaptador_Tipo_Dato_Columna.Fill(Datos_Tipo_Dato_Columna, Nombre_Tabla)
                Tipo_dato = Datos_Tipo_Dato_Columna.Tables(0).Rows(0)(0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        cmd_Tipo_Dato_Columna.Dispose()

        Adaptador_Tipo_Dato_Columna.Dispose()

        Datos_Tipo_Dato_Columna.Clear()
        Datos_Tipo_Dato_Columna.Dispose()
        Datos_Tipo_Dato_Columna.AcceptChanges()

        Return Tipo_dato
    End Function
    Public Shared Function Sobre_Escribir_Columna(Coneccion As SqlConnection, Tabla_Origen As String, Tabla_Almacenamiento_Resultados As String, Nombre_Columna As String)
        'Importante Ambas tablas tienen que tener el campo Puntero y de preferencias que tengan la misma cantidad de datos
        'Actualiza Sobre escribe una columna en la tabla de destino
        Class_Funciones_Base_Datos.Eliminar_Columna(Coneccion, Tabla_Almacenamiento_Resultados, Nombre_Columna)
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Tabla_Almacenamiento_Resultados, Nombre_Columna, Class_Funciones_Base_Datos.Tipo_Dato_Columna(Coneccion, Tabla_Origen, Nombre_Columna))
        Class_Funciones_Base_Datos.Copiar_Columna(Coneccion, Tabla_Origen, Tabla_Almacenamiento_Resultados, Nombre_Columna)
        Return Nothing
    End Function

    Public Shared Function Columnas_Existentes_Tabla(Coneccion As SqlConnection, Nombre_Tabla As String)
        'Determinar las clomunas existentees de la tabla 
        Dim sql_Columnas_Existentes As String = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + Nombre_Tabla + "'"
        Dim cmd_Columnas_Existentes As New SqlCommand(sql_Columnas_Existentes, Coneccion)
        Dim Adaptador_Columnas_Existentes As New SqlDataAdapter(cmd_Columnas_Existentes)
        Dim Datos_Columnas_Existentes As New DataSet

        Dim Columnas_Existentes As New List(Of String)
        If Coneccion.State <> 0 Then
            Try
                Adaptador_Columnas_Existentes.Fill(Datos_Columnas_Existentes, Nombre_Tabla)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            For i = 0 To Datos_Columnas_Existentes.Tables(Nombre_Tabla).Rows.Count - 1
                Columnas_Existentes.Add(Datos_Columnas_Existentes.Tables(Nombre_Tabla).Rows(i)(0))
            Next i
        Else
            Coneccion.Open()
            Try
                Adaptador_Columnas_Existentes.Fill(Datos_Columnas_Existentes, Nombre_Tabla)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            For i = 0 To Datos_Columnas_Existentes.Tables(Nombre_Tabla).Rows.Count - 1
                Columnas_Existentes.Add(Datos_Columnas_Existentes.Tables(Nombre_Tabla).Rows(i)(0))
            Next i
            Coneccion.Close()
        End If

        cmd_Columnas_Existentes.Dispose()
        Adaptador_Columnas_Existentes.Dispose()

        Datos_Columnas_Existentes.Clear()
        Datos_Columnas_Existentes.Dispose()
        Datos_Columnas_Existentes.AcceptChanges()

        Return Columnas_Existentes
    End Function
    '----------------------------------------------------------------------------------------------------------------------------------------------------
    'Funciones relacionadas con los registros 

    'Public Shared Function Consultar_Registro_Proces(Coneccion As SqlConnection, Nombre_Tabla As String, Columna As String, Intervalo_Entre_Dato As String, Puntero_inicio As String, Puntero_final As String)

    '    Dim Columnas_Existentes As New List(Of String)
    '    Dim sql_Registro_Consulta As String = "dbo.Consulta_Registro_Grafica"
    '    Dim cmd_Registro_Consulta As New SqlCommand(sql_Registro_Consulta, Coneccion)
    '    Dim Adaptador_Registro_Consulta As New SqlDataAdapter(cmd_Registro_Consulta)
    '    Dim Datos_Registro_Consulta As New DataSet
    '    If Coneccion.State <> 0 Then
    '        'Establezca el tipo de comando como StoredProcedure.
    '        Adaptador_Registro_Consulta.SelectCommand.CommandType = CommandType.StoredProcedure
    '        'Cree y agregue un parámetro a la colección Parameters del procedimiento almacenado.
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters.Add(New SqlParameter("@Tabla_Registro", SqlDbType.VarChar, 200))
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters.Add(New SqlParameter("@Columna_Registro", SqlDbType.VarChar, 200))
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters.Add(New SqlParameter("@Intervalo_Entre_Dato", SqlDbType.VarChar, 200))
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters.Add(New SqlParameter("@Puntero_inicio", SqlDbType.VarChar, 200))
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters.Add(New SqlParameter("@Puntero_final", SqlDbType.VarChar, 200))
    '        'Asigne el valor de búsqueda al parámetro.
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters("@Tabla_Registro").Value = Nombre_Tabla
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters("@Columna_Registro").Value = Columna
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters("@Intervalo_Entre_Dato").Value = Intervalo_Entre_Dato
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters("@Puntero_inicio").Value = Puntero_inicio
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters("@Puntero_final").Value = Puntero_final

    '        'Realizar la lectura 
    '        Adaptador_Registro_Consulta.Fill(Datos_Registro_Consulta, Nombre_Tabla)
    '    Else
    '        Coneccion.Open()

    '        'Establezca el tipo de comando como StoredProcedure.
    '        Adaptador_Registro_Consulta.SelectCommand.CommandType = CommandType.StoredProcedure
    '        'Cree y agregue un parámetro a la colección Parameters del procedimiento almacenado.
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters.Add(New SqlParameter("@Tabla_Registro", SqlDbType.VarChar, 200))
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters.Add(New SqlParameter("@Columna_Registro", SqlDbType.VarChar, 200))
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters.Add(New SqlParameter("@Intervalo_Entre_Dato", SqlDbType.VarChar, 200))
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters.Add(New SqlParameter("@Puntero_inicio", SqlDbType.VarChar, 200))
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters.Add(New SqlParameter("@Puntero_final", SqlDbType.VarChar, 200))
    '        'Asigne el valor de búsqueda al parámetro.
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters("@Tabla_Registro").Value = Nombre_Tabla
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters("@Columna_Registro").Value = Columna
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters("@Intervalo_Entre_Dato").Value = Intervalo_Entre_Dato
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters("@Puntero_inicio").Value = Puntero_inicio
    '        Adaptador_Registro_Consulta.SelectCommand.Parameters("@Puntero_final").Value = Puntero_final

    '        'Realizar la lectura 
    '        Adaptador_Registro_Consulta.Fill(Datos_Registro_Consulta, Nombre_Tabla)
    '        Coneccion.Close()
    '    End If

    '    Return Datos_Registro_Consulta
    'End Function
    Public Shared Function Registro_Consultar_Tabla_Puntero(Coneccion As SqlConnection, Nombre_Tabla As String, Intervalo_Entre_Punteros As String, Puntero_inicio As String, Puntero_final As String)
        'Funcion para consultar una tabla un intervalo en especifico, es impresindible que la tabla  tenga el campo Puntero(Puntero_inicio,Puntero_final,Intervalo_Entre_Punteros->siempre es 1)
        'se revisan las tablas que coinciden con el intervalo de Puntero
        'Funcion para consultar una tabla un intervalo en especifico, es impresindible que la tabla  tenga el campo Puntero(Puntero_inicio,Puntero_final,Intervalo_Entre_Punteros)
        Const Cantidad_Tabla_Consultadas = 10

        Dim sql_Registro As String = ""


        Dim Datos_Registro_Consulta As New DataSet
        Dim Datos_Registro_Consulta_final As New DataSet

        Dim Registro_Inic_Part As Int32 = Math.Floor(Convert.ToInt32(Puntero_inicio) / Valor_Max_Tabla)
        Dim Registro_Fin_Part As Int32 = Math.Floor(Convert.ToInt32(Puntero_final) / Valor_Max_Tabla)
        Dim Registro_Cont_Part As Int32 = 0
        Dim Tabla_Consultar As String
        Dim Tabla_Consultar_1 As String
        Dim Tablas_Consultar As String = "("
        While Registro_Cont_Part <= Registro_Fin_Part - Registro_Inic_Part
            'Obtengo el nombre de las tablas actual y  siquiente 
            Tabla_Consultar = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part) + " "
            Tabla_Consultar_1 = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part + 1) + " "
            'Pregunto se la tabla actual existe
            If Tabla_Existe(Coneccion, Tabla_Consultar) Then
                'Pregunto si es la 10 la tabla
                If Registro_Cont_Part < Registro_Fin_Part - Registro_Inic_Part And Registro_Cont_Part Mod Cantidad_Tabla_Consultadas <> Cantidad_Tabla_Consultadas - 1 Then
                    'Pregunto se la tabla siguiente existe o si es la 10 tabla 
                    If Tabla_Existe(Coneccion, Tabla_Consultar_1) Then
                        'Si la tabla siguinte existe espero para adicionarla a la consulta
                        Tablas_Consultar = Tablas_Consultar + "SELECT * FROM " + Tabla_Consultar + " WHERE Puntero>=" + Puntero_inicio + " and Puntero<=" + Puntero_final + " and (Puntero %" + Intervalo_Entre_Punteros + ")=0" + " UNION "
                    Else
                        'Si la tabla siguinte no existe finalizo la adicion de tablas para a la consulta
                        Tablas_Consultar = Tablas_Consultar + "SELECT * FROM " + Tabla_Consultar + " WHERE Puntero>=" + Puntero_inicio + " and Puntero<=" + Puntero_final + " and (Puntero %" + Intervalo_Entre_Punteros + ")=0" + ") ORDER BY Puntero ASC"
                        Registro_Cont_Part = Registro_Cont_Part + Registro_Fin_Part - Registro_Inic_Part
                    End If
                Else
                    'Si es la 10 tabla hago la consulta
                    If Tabla_Existe(Coneccion, Tabla_Consultar_1) Then
                        Tablas_Consultar = Tablas_Consultar + "SELECT * FROM " + Tabla_Consultar + " WHERE Puntero>=" + Puntero_inicio + " and Puntero<=" + Puntero_final + " and (Puntero %" + Intervalo_Entre_Punteros + ")=0" + ") ORDER BY Puntero ASC"
                    Else
                        'Si la tabla siguinte no existe finalizo la adicion de tablas para a la consulta
                        Tablas_Consultar = Tablas_Consultar + "SELECT * FROM " + Tabla_Consultar + " WHERE Puntero>=" + Puntero_inicio + " and Puntero<=" + Puntero_final + " and (Puntero %" + Intervalo_Entre_Punteros + ")=0" + ") ORDER BY Puntero ASC"
                        Registro_Cont_Part = Registro_Cont_Part + Registro_Fin_Part - Registro_Inic_Part
                    End If
                End If
            End If
            'Hago la consulta a cuatro tablas de datos
            If Tablas_Consultar <> "(" And ((Registro_Cont_Part Mod Cantidad_Tabla_Consultadas = Cantidad_Tabla_Consultadas - 1) Or (Tabla_Existe(Coneccion, Tabla_Consultar_1) = False) Or (Registro_Cont_Part >= Registro_Fin_Part - Registro_Inic_Part)) Then
                sql_Registro = Tablas_Consultar
                Dim cmd_Registro As New SqlCommand(sql_Registro, Coneccion)
                Dim Adaptador As New SqlDataAdapter(cmd_Registro)

                If Coneccion.State <> 0 Then
                    Try
                        Adaptador.Fill(Datos_Registro_Consulta, Nombre_Tabla)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    Coneccion.Open()
                    Try
                        Adaptador.Fill(Datos_Registro_Consulta, Nombre_Tabla)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    Coneccion.Close()
                End If
                Tablas_Consultar = "("
                cmd_Registro.Dispose()
                Adaptador.Dispose()
            End If
            Registro_Cont_Part = Registro_Cont_Part + 1
        End While

        Return Datos_Registro_Consulta
    End Function

    Public Shared Function Registro_Consultar(Coneccion As SqlConnection, Nombre_Tabla As String, Columna As String, Intervalo_Entre_Punteros As String, Puntero_inicio As String, Puntero_final As String)
        'Funcion para consultar una tabla un intervalo en especifico, es impresindible que la tabla  tenga el campo Puntero(Puntero_inicio,Puntero_final,Intervalo_Entre_Punteros->siempre es 1)
        'se revisan las tablas que coinciden con el intervalo de Puntero
        'Funcion para consultar una tabla un intervalo en especifico, es impresindible que la tabla  tenga el campo Puntero(Puntero_inicio,Puntero_final,Intervalo_Entre_Punteros)
        Const Cantidad_Tabla_Consultadas = 10

        Dim sql_Registro As String = ""


        Dim Datos_Registro_Consulta As New DataSet
        Dim Datos_Registro_Consulta_final As New DataSet

        Dim Registro_Inic_Part As Int32 = Math.Floor(Convert.ToInt32(Puntero_inicio) / Valor_Max_Tabla)
        Dim Registro_Fin_Part As Int32 = Math.Floor(Convert.ToInt32(Puntero_final) / Valor_Max_Tabla)
        Dim Registro_Cont_Part As Int32 = 0
        Dim Tabla_Consultar As String
        Dim Tabla_Consultar_1 As String
        Dim Tablas_Consultar As String = "("
        While Registro_Cont_Part <= Registro_Fin_Part - Registro_Inic_Part
            'Obtengo el nombre de las tablas actual y  siquiente 
            Tabla_Consultar = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part) + " "
            Tabla_Consultar_1 = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part + 1) + " "
            'Pregunto se la tabla actual existe
            If Tabla_Existe(Coneccion, Tabla_Consultar) Then
                'Pregunto si es la 10 la tabla
                If Registro_Cont_Part < Registro_Fin_Part - Registro_Inic_Part And Registro_Cont_Part Mod Cantidad_Tabla_Consultadas <> Cantidad_Tabla_Consultadas - 1 Then
                    'Pregunto se la tabla siguiente existe o si es la 10 tabla 
                    If Tabla_Existe(Coneccion, Tabla_Consultar_1) Then
                        'Si la tabla siguinte existe espero para adicionarla a la consulta
                        Tablas_Consultar = Tablas_Consultar + "SELECT Puntero, " + Columna + " FROM " + Tabla_Consultar + " WHERE Puntero>=" + Puntero_inicio + " and Puntero<=" + Puntero_final + " and (Puntero %" + Intervalo_Entre_Punteros + ")=0" + " UNION "
                    Else
                        'Si la tabla siguinte no existe finalizo la adicion de tablas para a la consulta
                        Tablas_Consultar = Tablas_Consultar + "SELECT Puntero, " + Columna + " FROM " + Tabla_Consultar + " WHERE Puntero>=" + Puntero_inicio + " and Puntero<=" + Puntero_final + " and (Puntero %" + Intervalo_Entre_Punteros + ")=0" + ") ORDER BY Puntero ASC"
                        Registro_Cont_Part = Registro_Cont_Part + Registro_Fin_Part - Registro_Inic_Part
                    End If
                Else
                    'Si es la 10 tabla hago la consulta
                    If Tabla_Existe(Coneccion, Tabla_Consultar_1) Then
                        Tablas_Consultar = Tablas_Consultar + "SELECT Puntero, " + Columna + " FROM " + Tabla_Consultar + " WHERE Puntero>=" + Puntero_inicio + " and Puntero<=" + Puntero_final + " and (Puntero %" + Intervalo_Entre_Punteros + ")=0" + ") ORDER BY Puntero ASC"
                    Else
                        'Si la tabla siguinte no existe finalizo la adicion de tablas para a la consulta
                        Tablas_Consultar = Tablas_Consultar + "SELECT Puntero, " + Columna + " FROM " + Tabla_Consultar + " WHERE Puntero>=" + Puntero_inicio + " and Puntero<=" + Puntero_final + " and (Puntero %" + Intervalo_Entre_Punteros + ")=0" + ") ORDER BY Puntero ASC"
                        Registro_Cont_Part = Registro_Cont_Part + Registro_Fin_Part - Registro_Inic_Part
                    End If
                End If
            End If
            'Hago la consulta a cuatro tablas de datos
            If Tablas_Consultar <> "(" And ((Registro_Cont_Part Mod Cantidad_Tabla_Consultadas = Cantidad_Tabla_Consultadas - 1) Or (Tabla_Existe(Coneccion, Tabla_Consultar_1) = False) Or (Registro_Cont_Part >= Registro_Fin_Part - Registro_Inic_Part)) Then
                sql_Registro = Tablas_Consultar
                Dim cmd_Registro As New SqlCommand(sql_Registro, Coneccion)
                Dim Adaptador As New SqlDataAdapter(cmd_Registro)

                If Coneccion.State <> 0 Then
                    Try
                        Adaptador.Fill(Datos_Registro_Consulta, Nombre_Tabla)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    Coneccion.Open()
                    Try
                        Adaptador.Fill(Datos_Registro_Consulta, Nombre_Tabla)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    Coneccion.Close()
                End If
                Tablas_Consultar = "("
                cmd_Registro.Dispose()
                Adaptador.Dispose()
            End If
            Registro_Cont_Part = Registro_Cont_Part + 1
        End While

        Return Datos_Registro_Consulta
    End Function
    Public Shared Function Registro_Consultar(Coneccion As SqlConnection, Nombre_Tabla As String, Columna As String, Puntero_inicio As String, Puntero_final As String)
        'Funcion para consultar una tabla un intervalo en especifico, es impresindible que la tabla  tenga el campo Puntero(Puntero_inicio,Puntero_final,Intervalo_Entre_Punteros->siempre es 1)
        'se revisan las tablas que coinciden con el intervalo de Puntero
        Dim Puntero_inicio_temp As String
        If Convert.ToInt32(Puntero_inicio) < 0 Then
            Puntero_inicio_temp = "0"
        Else
            Puntero_inicio_temp = Puntero_inicio
        End If

        Dim Registro_Inic_Part As Int32 = Math.Floor(Convert.ToInt32(Puntero_inicio_temp) / Valor_Max_Tabla)
        Dim Registro_Fin_Part As Int32 = Math.Floor(Convert.ToInt32(Puntero_final) / Valor_Max_Tabla)
        Dim Registro_Cont_Part As Int32 = 0
        Dim Tabla_Consultar As String
        Dim Tabla_Consultar_1 As String
        Dim Tablas_Consultar As String = "("
        While Registro_Cont_Part <= Registro_Fin_Part - Registro_Inic_Part
            'Obtengo el nombre de las tablas actual y  siquiente 
            Tabla_Consultar = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part) + " "
            Tabla_Consultar_1 = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part + 1) + " "
            'Pregunto se la tabla actual existe
            If Tabla_Existe(Coneccion, Tabla_Consultar) Then
                'Pregunto se la tabla siguinte existe
                If Tabla_Existe(Coneccion, Tabla_Consultar_1) And Registro_Cont_Part < Registro_Fin_Part - Registro_Inic_Part Then
                    'Si la tabla siguinte existe espero para adicionarla a la consulta
                    Tablas_Consultar = Tablas_Consultar + "SELECT Puntero, " + Columna + " FROM " + Tabla_Consultar + " WHERE Puntero>=" + Puntero_inicio_temp + " and Puntero<=" + Puntero_final + " UNION "
                Else
                    'Si la tabla siguinte no existe finalizo la adicion de tablas para a la consulta
                    Tablas_Consultar = Tablas_Consultar + "SELECT Puntero, " + Columna + " FROM " + Tabla_Consultar + " WHERE Puntero>=" + Puntero_inicio_temp + " and Puntero<=" + Puntero_final + ") ORDER BY Puntero ASC"
                    Registro_Cont_Part = Registro_Cont_Part + Registro_Fin_Part - Registro_Inic_Part

                End If
            End If
            Registro_Cont_Part = Registro_Cont_Part + 1
        End While
        If Tablas_Consultar = "(" Then
            Tabla_Consultar = Nombre_Tabla + "_Part_0"
            Tablas_Consultar = Tablas_Consultar + "SELECT Puntero, " + Columna + " FROM " + Tabla_Consultar + " WHERE Puntero>=-2 and Puntero<=-1) ORDER BY Puntero ASC"
        End If

        Dim sql_Registro As String
        sql_Registro = Tablas_Consultar
        Dim cmd_Registro As New SqlCommand(sql_Registro, Coneccion)
        Dim Adaptador As New SqlDataAdapter(cmd_Registro)
        Dim Datos_Registro_Consulta As New DataSet

        If Coneccion.State <> 0 Then
            Try
                Adaptador.Fill(Datos_Registro_Consulta, Nombre_Tabla)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Coneccion.Open()
            Try
                Adaptador.Fill(Datos_Registro_Consulta, Nombre_Tabla)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Coneccion.Close()


            cmd_Registro.Dispose()
            Adaptador.Dispose()
        End If

        Return Datos_Registro_Consulta
    End Function
    Public Shared Function Registros_Consultar_P_QRS_T(Coneccion As SqlConnection, Nombre_Tabla As String, Columna As String, Puntero_inicio As String, Puntero_final As String)
        'Funcion para consultar en un registro del compeljo "QRS" o Onda "T" o "P" un intervalo en especifico de una sola columna que no sea Puntero
        'se revisan todas las tablas sin distincion
        Dim Registro_Cont_Part As Int32 = 0
        Dim Bandera_Parada As Boolean = False

        Dim Tabla_Consultar As String
        Dim Tabla_Consultar_1 As String
        Dim Tablas_Consultar As String = "("
        While Bandera_Parada = False
            'Obtengo el nombre de las tablas actual y  siquiente 
            Tabla_Consultar = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Cont_Part) + " "
            Tabla_Consultar_1 = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Cont_Part + 1) + " "
            If Tabla_Existe(Coneccion, Tabla_Consultar) Then
                'Pregunto se la tabla siguinte existe
                If Tabla_Existe(Coneccion, Tabla_Consultar_1) Then
                    'Si la tabla siguinte existe espero para adicionarla a la consulta
                    Tablas_Consultar = Tablas_Consultar + "SELECT Puntero," + Columna + " FROM " + Tabla_Consultar + " WHERE " + Columna + ">=" + Puntero_inicio + " and " + Columna + "<=" + Puntero_final + " UNION "
                Else
                    'Si la tabla siguinte no existe finalizo la adicion de tablas para a la consulta
                    Tablas_Consultar = Tablas_Consultar + "SELECT Puntero," + Columna + " FROM " + Tabla_Consultar + " WHERE " + Columna + ">=" + Puntero_inicio + " and " + Columna + "<=" + Puntero_final + ") ORDER BY Puntero ASC"
                    Bandera_Parada = True
                End If
            End If
            Registro_Cont_Part = Registro_Cont_Part + 1
        End While
        If Tablas_Consultar = "(" Then
            Tabla_Consultar = Nombre_Tabla + "_Part_0"
            Tablas_Consultar = Tablas_Consultar + "SELECT Puntero, " + Columna + " FROM " + Tabla_Consultar + " WHERE Puntero>=-2 and Puntero<=-1) ORDER BY Puntero ASC"
        End If

        Dim sql_Registro As String
        sql_Registro = Tablas_Consultar
        Dim cmd_Registro As New SqlCommand(sql_Registro, Coneccion)
        Dim Adaptador As New SqlDataAdapter(cmd_Registro)
        Dim Datos_Registro_Consulta As New DataSet

        If Coneccion.State <> 0 Then
            Try
                Adaptador.Fill(Datos_Registro_Consulta, Nombre_Tabla)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Coneccion.Open()
            Try
                Adaptador.Fill(Datos_Registro_Consulta, Nombre_Tabla)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Coneccion.Close()


            cmd_Registro.Dispose()
            Adaptador.Dispose()
        End If

        Return Datos_Registro_Consulta
    End Function
    Public Shared Function Registros_Consultar_Intervalos(Coneccion As SqlConnection, Nombre_Tabla As String, Columna_Inicio As String, Columna_Final As String, Puntero_inicio As String, Puntero_final As String)
        'Funcion para consultar Columna_Inicio y Columna_Final un Intervalo (RR,QT,PR) en especifico, devuel ve Columna_Inicio y Columna_Final, de un intervalo de tiempo 
        'se revisan todas las tablas sin distincion  

        Dim Registro_Cont_Part As Int32 = 0
        Dim Bandera_Parada As Boolean = False

        Dim Tabla_Consultar As String
        Dim Tabla_Consultar_1 As String
        Dim Tablas_Consultar As String = "("
        While Bandera_Parada = False
            'Obtengo el nombre de las tablas actual y  siquiente 
            Tabla_Consultar = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Cont_Part) + " "
            Tabla_Consultar_1 = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Cont_Part + 1) + " "
            'Pregunto se la tabla actual existe
            If Tabla_Existe(Coneccion, Tabla_Consultar) Then
                'Pregunto se la tabla siguinte existe
                If Tabla_Existe(Coneccion, Tabla_Consultar_1) Then
                    'Si la tabla siguinte existe espero para adicionarla a la consulta
                    Tablas_Consultar = Tablas_Consultar + "SELECT Puntero," + Columna_Inicio + ", " + Columna_Final + " FROM " + Tabla_Consultar + " WHERE " + Columna_Inicio + ">=" + Puntero_inicio + " and " + Columna_Final + "<=" + Puntero_final + " UNION "
                Else
                    'Si la tabla siguinte no existe finalizo la adicion de tablas para a la consulta
                    Tablas_Consultar = Tablas_Consultar + "SELECT Puntero," + Columna_Inicio + ", " + Columna_Final + " FROM " + Tabla_Consultar + " WHERE " + Columna_Inicio + ">=" + Puntero_inicio + " and " + Columna_Final + "<=" + Puntero_final + ") ORDER BY Puntero ASC"
                    Bandera_Parada = True
                End If
            End If
            Registro_Cont_Part = Registro_Cont_Part + 1
        End While
        If Tablas_Consultar = "(" Then
            Tabla_Consultar = Nombre_Tabla + "_Part_0"
            Tablas_Consultar = Tablas_Consultar + "SELECT Puntero, " + Columna_Inicio + ", " + Columna_Final + " FROM " + Tabla_Consultar + "  WHERE Puntero>=-2 and Puntero<=-1) ORDER BY Puntero ASC"
        End If

        Dim sql_Registro As String
        sql_Registro = Tablas_Consultar
        Dim cmd_Registro As New SqlCommand(sql_Registro, Coneccion)
        Dim Adaptador As New SqlDataAdapter(cmd_Registro)
        Dim Datos_Registro_Consulta As New DataSet

        If Coneccion.State <> 0 Then
            Try
                Adaptador.Fill(Datos_Registro_Consulta, Nombre_Tabla)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Coneccion.Open()
            Try
                Adaptador.Fill(Datos_Registro_Consulta, Nombre_Tabla)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Coneccion.Close()


            cmd_Registro.Dispose()
            Adaptador.Dispose()
        End If

        Return Datos_Registro_Consulta

    End Function
    Public Shared Function Registros_Consultar_Tabla_Completa(Coneccion As SqlConnection, Nombre_Tabla As String, Columna_Inicio As String, Columna_Final As String, Puntero_inicio As String, Puntero_final As String)
        'Funcion para consultar todas las columnas del Registro apartir un interdavalo de dos columnas especificas(Columna_Inicio,Columna_Final)
        'se revisan todas las tablas sin distincion  

        Dim Registro_Cont_Part As Int32 = 0
        Dim Bandera_Parada As Boolean = False

        Dim Tabla_Consultar As String
        Dim Tabla_Consultar_1 As String
        Dim Tablas_Consultar As String = "("
        While Bandera_Parada = False
            'Obtengo el nombre de las tablas actual y  siquiente 
            Tabla_Consultar = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Cont_Part) + " "
            Tabla_Consultar_1 = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Cont_Part + 1) + " "
            'Pregunto se la tabla actual existe
            If Tabla_Existe(Coneccion, Tabla_Consultar) Then
                'Pregunto se la tabla siguinte existe
                If Tabla_Existe(Coneccion, Tabla_Consultar_1) Then
                    'Si la tabla siguinte existe espero para adicionarla a la consulta
                    Tablas_Consultar = Tablas_Consultar + "SELECT * FROM " + Tabla_Consultar + " WHERE " + Columna_Inicio + ">=" + Puntero_inicio + " and " + Columna_Final + "<=" + Puntero_final + " UNION "
                Else
                    'Si la tabla siguinte no existe finalizo la adicion de tablas para a la consulta
                    Tablas_Consultar = Tablas_Consultar + "SELECT * FROM " + Tabla_Consultar + " WHERE " + Columna_Inicio + ">=" + Puntero_inicio + " and " + Columna_Final + "<=" + Puntero_final + ") ORDER BY Puntero ASC"
                    Bandera_Parada = True
                End If
            End If
            Registro_Cont_Part = Registro_Cont_Part + 1
        End While
        If Tablas_Consultar = "(" Then
            Tabla_Consultar = Nombre_Tabla + "_Part_0"
            Tablas_Consultar = Tablas_Consultar + "SELECT * FROM " + Tabla_Consultar + "  WHERE Puntero>=-2 and Puntero<=-1) ORDER BY Puntero ASC"
        End If

        Dim sql_Registro As String
        sql_Registro = Tablas_Consultar
        Dim cmd_Registro As New SqlCommand(sql_Registro, Coneccion)
        Dim Adaptador As New SqlDataAdapter(cmd_Registro)
        Dim Datos_Registro_Consulta As New DataSet

        If Coneccion.State <> 0 Then
            Try
                Adaptador.Fill(Datos_Registro_Consulta, Nombre_Tabla)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Coneccion.Open()
            Try
                Adaptador.Fill(Datos_Registro_Consulta, Nombre_Tabla)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Coneccion.Close()


            cmd_Registro.Dispose()
            Adaptador.Dispose()
        End If

        Return Datos_Registro_Consulta
    End Function
    Public Shared Function Registros_Crear_Registro(Coneccion As SqlConnection, Nombre_Tabla As String, Columna As String)
        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Nombre_Tabla)
        Class_Funciones_Base_Datos.Crear_Tabla(Coneccion, Nombre_Tabla + "_Part_0", "Puntero", "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", Columna, "float NOT NULL")
    End Function
    Public Shared Function Registros_Crear_Tabla_QRS(Coneccion As SqlConnection, Nombre_Tabla As String)
        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Nombre_Tabla)
        Class_Funciones_Base_Datos.Crear_Tabla(Coneccion, Nombre_Tabla + "_Part_0", "Puntero", "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", "Q_i", "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", "Q", "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", "R", "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", "S", "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", "J", "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", "Tipo_QRS", "int NOT NULL")
    End Function
    Public Shared Function Registros_Crear_Tabla_Onda_T(Coneccion As SqlConnection, Nombre_Tabla As String)
        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Nombre_Tabla)
        Class_Funciones_Base_Datos.Crear_Tabla(Coneccion, Nombre_Tabla + "_Part_0", "Puntero", "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", "T_i", "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", "T", "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", "T_f", "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", "Tipo_Onda_T", "int NOT NULL")
    End Function
    Public Shared Function Registros_Crear_Tabla_Onda_P(Coneccion As SqlConnection, Nombre_Tabla As String)
        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Nombre_Tabla)
        Class_Funciones_Base_Datos.Crear_Tabla(Coneccion, Nombre_Tabla + "_Part_0", "Puntero", "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", "P_i", "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", "P", "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", "P_f", "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", "Tipo_Onda_P", "int NOT NULL")
    End Function
    Public Shared Function Registros_Crear_Tabla_Intervalo(Coneccion As SqlConnection, Nombre_Tabla As String, Columna_Inicio As String, Columna_Final As String)
        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion, Nombre_Tabla)
        Class_Funciones_Base_Datos.Crear_Tabla(Coneccion, Nombre_Tabla + "_Part_0", "Puntero", "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", "Inicio_" + Columna_Inicio + "_" + Columna_Final, "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", "Final_" + Columna_Inicio + "_" + Columna_Final, "int NOT NULL")
        Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_0", Columna_Inicio + "_" + Columna_Final, "int NOT NULL")
    End Function
    Public Shared Function Registro_Tabla_Existe(Coneccion As SqlConnection, Nombre_Tabla As String)
        Dim Bandera As Boolean
        'Determinar si existentees la tabla 
        Dim sql_Columnas_Existentes As String = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + Nombre_Tabla + "_Part_0'"
        Dim cmd_Columnas_Existentes As New SqlCommand(sql_Columnas_Existentes, Coneccion)
        Dim Adaptador_Columnas_Existentes As New SqlDataAdapter(cmd_Columnas_Existentes)
        Dim Datos_Columnas_Existentes As New DataSet

        If Coneccion.State <> 0 Then
            Try
                Adaptador_Columnas_Existentes.Fill(Datos_Columnas_Existentes, Nombre_Tabla)
                If Datos_Columnas_Existentes.Tables(Nombre_Tabla).Rows.Count <> 0 Then
                    Bandera = True
                Else
                    Bandera = False
                End If
            Catch ex As Exception
                Bandera = False
                MsgBox(ex.Message)
            End Try

        Else
            Coneccion.Open()
            Try
                Adaptador_Columnas_Existentes.Fill(Datos_Columnas_Existentes, Nombre_Tabla)
                If Datos_Columnas_Existentes.Tables(Nombre_Tabla).Rows.Count <> 0 Then
                    Bandera = True
                Else
                    Bandera = False
                End If
            Catch ex As Exception
                Bandera = False
                MsgBox(ex.Message)
            End Try
            Coneccion.Close()
        End If

        cmd_Columnas_Existentes.Dispose()
        Adaptador_Columnas_Existentes.Dispose()

        Datos_Columnas_Existentes.Clear()
        Datos_Columnas_Existentes.Dispose()
        Datos_Columnas_Existentes.AcceptChanges()

        Return Bandera
    End Function
    Public Shared Function Registro_Copiar_Registro(Coneccion_Entrada As SqlConnection, Coneccion_Salida As SqlConnection, Nombre_Tabla As String)
        Dim Columnas_Existentes As List(Of String) = Columnas_Existentes_Tabla(Coneccion_Entrada, Nombre_Tabla + "_Part_0")
        If Columnas_Existentes.Count > 1 Then
            Registros_Eliminar_Registro(Coneccion_Salida, Nombre_Tabla)
            Registros_Crear_Registro(Coneccion_Salida, Nombre_Tabla, Columnas_Existentes.Item(1))
            Dim Puntero_inicio, Puntero_final As Int64
            Puntero_inicio = 0
            Puntero_final = Valor_Max_Tabla - 1
            Dim Datos_Registro_Consulta As New DataSet
            Datos_Registro_Consulta = Registro_Consultar(Coneccion_Entrada, Nombre_Tabla, Columnas_Existentes.Item(1), 1, Puntero_inicio, Puntero_final)
            While Datos_Registro_Consulta.Tables.Count > 0
                Registro_Almacenar_Datos(Coneccion_Salida, Nombre_Tabla, Datos_Registro_Consulta.Tables(0))
                Puntero_inicio = Puntero_inicio + Valor_Max_Tabla
                Puntero_final = Puntero_final + Valor_Max_Tabla
                Datos_Registro_Consulta = Registro_Consultar(Coneccion_Entrada, Nombre_Tabla, Columnas_Existentes.Item(1), 1, Puntero_inicio, Puntero_final)
            End While
            Return True
        End If
        Return False
    End Function

    Public Shared Function Registros_Eliminar_Registro(Coneccion As SqlConnection, Nombre_Tabla As String)
        'Funcion para eliminar los fracmentos de una tabala de un registro
        Dim Nombre_Tablas_Existentes As New DataSet
        Nombre_Tablas_Existentes = Class_Funciones_Base_Datos.Tabla_Todas_Existentes(Coneccion)
        For Index = Nombre_Tablas_Existentes.Tables(0).Rows.Count - 1 To 0 Step -1
            If InStr(Nombre_Tablas_Existentes.Tables(0).Rows(Index)(0), Nombre_Tabla + "_Part_") <> 0 Then
                Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Nombre_Tablas_Existentes.Tables(0).Rows(Index)(0))
            End If
        Next Index
        Return True
    End Function


    Public Shared Function Registros_Renombrar_Registro(Coneccion As SqlConnection, Nombre_Tabla_Actual As String, Nombre_Tabla_Nuevo As String)
        'Funcion para eliminar los fracmentos de una tabala de un registro

        'Busco las tablas que son Part del registro
        Dim Registro_Part As Int32 = 0
        Dim Bandera_Registro_Part_Ultimo As Boolean = False
        Dim Tabla_Consultar As String = ""
        Dim Tablas_Part As New List(Of String)

        While Bandera_Registro_Part_Ultimo = False
            'Obtengo el nombre de las tablas actual y  siquiente 
            Tabla_Consultar = Nombre_Tabla_Actual + "_Part_" + Convert.ToString(Registro_Part)
            'Pregunto se la tabla actual existe
            If Tabla_Existe(Coneccion, Tabla_Consultar) Then
                Tablas_Part.Add(Nombre_Tabla_Actual + "_Part_" + Convert.ToString(Registro_Part))
                Registro_Part = Registro_Part + 1
            Else
                Bandera_Registro_Part_Ultimo = True
            End If
        End While
        'Renombro todas las tablas 
        For Index_Part = Tablas_Part.Count - 1 To 0 Step -1
            Tabla_Eliminar(Coneccion, Nombre_Tabla_Nuevo + "_Part_" + Convert.ToString(Index_Part))
            Tabla_Renombrar(Coneccion, Nombre_Tabla_Actual + "_Part_" + Convert.ToString(Index_Part), Nombre_Tabla_Nuevo + "_Part_" + Convert.ToString(Index_Part))
        Next Index_Part
    End Function
    Public Shared Function Registro_Almacenar_Datos(Coneccion As SqlConnection, Nombre_Tabla As String, ByRef Tabla_Datos As DataTable)
        If Tabla_Datos.Rows.Count <> Nothing And Tabla_Datos.Rows.Count > 0 Then

            Dim Puntero_Inicio As Int32 = Tabla_Datos.Rows(0)(0)
            Dim Puntero_Final As Int32 = Tabla_Datos.Rows(Tabla_Datos.Rows.Count - 1)(0)
            Dim Tabla_Datos_Temp As New DataTable()
            Tabla_Datos_Temp = Tabla_Datos.Clone

            Dim Cmd_Copiar As New SqlBulkCopy(Coneccion)
            Dim Registro_Inic_Part As Int32 = Math.Floor(Convert.ToInt32(Puntero_Inicio) / Valor_Max_Tabla)
            Dim Registro_Fin_Part As Int32 = Math.Floor(Convert.ToInt32(Puntero_Final) / Valor_Max_Tabla)
            Dim Registro_Cont_Part As Int32 = 0
            Try
                If Coneccion.State = 0 Then
                    Coneccion.Open()
                    Dim Columnas As List(Of String) = Class_Funciones_Base_Datos.Columnas_Existentes_Tabla(Coneccion, Nombre_Tabla + "_Part_0")
                    Dim Index_Cont As Int64 = 0
                    While Registro_Cont_Part <= Registro_Fin_Part - Registro_Inic_Part
                        For index = Index_Cont To Tabla_Datos.Rows.Count - 1
                            If Tabla_Datos.Rows(Index_Cont)(0) >= ((Registro_Inic_Part + Registro_Cont_Part) * Valor_Max_Tabla) And Tabla_Datos.Rows(Index_Cont)(0) <= ((Registro_Inic_Part + Registro_Cont_Part) * Valor_Max_Tabla + Valor_Max_Tabla - 1) Then
                                'Tabla_Datos_Temp.Rows.Add(Tabla_Datos.Rows(Index_Cont)(0), Tabla_Datos.Rows(Index_Cont)(1))
                                Tabla_Datos_Temp.ImportRow(Tabla_Datos.Rows(Index_Cont))
                            ElseIf Tabla_Datos.Rows(Index_Cont)(0) > ((Registro_Inic_Part + Registro_Cont_Part) * Valor_Max_Tabla + Valor_Max_Tabla - 1) Then
                                Exit For
                            End If
                            Index_Cont = Index_Cont + 1
                        Next index
                        'Comprueba que exista la tabla en la voy a almacenar 
                        If Tabla_Existe(Coneccion, Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part)) = False Then
                            Class_Funciones_Base_Datos.Crear_Tabla(Coneccion, Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part), "Puntero", "int NOT NULL")
                            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part), Columnas.Item(1), "float NOT NULL")
                        End If

                        Cmd_Copiar.DestinationTableName = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part)
                        Cmd_Copiar.WriteToServer(Tabla_Datos_Temp)
                        Tabla_Datos_Temp.Clear()
                        Tabla_Datos_Temp.AcceptChanges()
                        Registro_Cont_Part = Registro_Cont_Part + 1
                        If Registro_Cont_Part <= Registro_Fin_Part - Registro_Inic_Part Then
                            Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part))
                            Class_Funciones_Base_Datos.Crear_Tabla(Coneccion, Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part), "Puntero", "int NOT NULL")
                            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part), Columnas.Item(1), "float NOT NULL")
                        End If
                    End While
                    Coneccion.Close()
                Else
                    Dim Columnas As List(Of String) = Class_Funciones_Base_Datos.Columnas_Existentes_Tabla(Coneccion, Nombre_Tabla + "_Part_0")
                    Dim Index_Cont As Int64 = 0
                    While Registro_Cont_Part <= Registro_Fin_Part - Registro_Inic_Part
                        For index = Index_Cont To Tabla_Datos.Rows.Count - 1
                            If Tabla_Datos.Rows(Index_Cont)(0) >= ((Registro_Inic_Part + Registro_Cont_Part) * Valor_Max_Tabla) And Tabla_Datos.Rows(Index_Cont)(0) <= ((Registro_Inic_Part + Registro_Cont_Part) * Valor_Max_Tabla + Valor_Max_Tabla - 1) Then
                                'Tabla_Datos_Temp.Rows.Add(Tabla_Datos.Rows(Index_Cont)(0), Tabla_Datos.Rows(Index_Cont)(1))
                                Tabla_Datos_Temp.ImportRow(Tabla_Datos.Rows(Index_Cont))
                            ElseIf Tabla_Datos.Rows(Index_Cont)(0) > ((Registro_Inic_Part + Registro_Cont_Part) * Valor_Max_Tabla + Valor_Max_Tabla - 1) Then
                                Exit For
                            End If
                            Index_Cont = Index_Cont + 1
                        Next index
                        'Comprueba que exista la tabla en la voy a almacenar 
                        If Tabla_Existe(Coneccion, Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part)) = False Then
                            Class_Funciones_Base_Datos.Crear_Tabla(Coneccion, Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part), "Puntero", "int NOT NULL")
                            Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part), Columnas.Item(1), "float NOT NULL")
                        End If

                        Cmd_Copiar.DestinationTableName = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part)
                        Cmd_Copiar.WriteToServer(Tabla_Datos_Temp)
                        Tabla_Datos_Temp.Clear()
                        Tabla_Datos_Temp.AcceptChanges()
                        Registro_Cont_Part = Registro_Cont_Part + 1
                        'If Registro_Cont_Part <= Registro_Fin_Part - Registro_Inic_Part Then
                        '    Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion, Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part))
                        '    Class_Funciones_Base_Datos.Crear_Tabla(Coneccion, Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part), "Puntero", "int NOT NULL")
                        '    Class_Funciones_Base_Datos.Adicionar_Columna(Coneccion, Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part), Columnas.Item(1), "float NOT NULL")
                        'End If
                    End While
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
            Return True

        End If
        Return True
    End Function
    Public Shared Function Consultar_Registro_QRS(Coneccion As SqlConnection, Nombre_Tabla As String, Columna As String, Puntero As DataSet)

        Dim sql_Registro_Consulta As String = "dbo.Consulta_Un_Valor_Registro"
        Dim cmd_Registro_Consulta As New SqlCommand(sql_Registro_Consulta, Coneccion)
        Dim Adaptador_Registro_Consulta As New SqlDataAdapter(cmd_Registro_Consulta)
        Dim Datos_Registro_Consulta As New DataSet
        Dim Datos_Registro As New DataSet
        Datos_Registro.Tables.Add("Tabla")
        Datos_Registro.Tables(0).Columns.Add("Valores", GetType(System.Double))

        If Coneccion.State <> 0 Then
            'Establezca el tipo de comando como StoredProcedure.
            Adaptador_Registro_Consulta.SelectCommand.CommandType = CommandType.StoredProcedure
            'Cree y agregue un parámetro a la colección Parameters del procedimiento almacenado.
            Adaptador_Registro_Consulta.SelectCommand.Parameters.Add(New SqlParameter("@Tabla_Registro", SqlDbType.VarChar, 200))
            Adaptador_Registro_Consulta.SelectCommand.Parameters.Add(New SqlParameter("@Columna_Registro", SqlDbType.VarChar, 200))
            Adaptador_Registro_Consulta.SelectCommand.Parameters.Add(New SqlParameter("@Puntero", SqlDbType.VarChar, 200))
            'Asigne el valor de búsqueda al parámetro.
            Adaptador_Registro_Consulta.SelectCommand.Parameters("@Tabla_Registro").Value = Nombre_Tabla
            Adaptador_Registro_Consulta.SelectCommand.Parameters("@Columna_Registro").Value = Columna
            'Adaptador_Registro_Consulta.SelectCommand.Parameters("@Puntero").Value = Puntero.Tables(0).Rows(0)(0)
            'Realizar la lectura 
            'Adaptador_Registro_Consulta.Fill(Datos_Registro_Consulta, Nombre_Tabla)
            'Datos_Registro = Datos_Registro_Consulta
            For Index = 0 To Puntero.Tables(0).Rows.Count - 1
                Adaptador_Registro_Consulta.SelectCommand.Parameters("@Puntero").Value = Puntero.Tables(0).Rows(Index)(0)
                'Realizar la lectura 
                Adaptador_Registro_Consulta.Fill(Datos_Registro_Consulta, Nombre_Tabla)
                Datos_Registro.Tables(0).Rows.Add(Datos_Registro_Consulta.Tables(0).Rows(0)(0))

            Next Index
        Else
            Coneccion.Open()

            'Establezca el tipo de comando como StoredProcedure.
            Adaptador_Registro_Consulta.SelectCommand.CommandType = CommandType.StoredProcedure
            'Cree y agregue un parámetro a la colección Parameters del procedimiento almacenado.
            Adaptador_Registro_Consulta.SelectCommand.Parameters.Add(New SqlParameter("@Tabla_Registro", SqlDbType.VarChar, 200))
            Adaptador_Registro_Consulta.SelectCommand.Parameters.Add(New SqlParameter("@Columna_Registro", SqlDbType.VarChar, 200))
            Adaptador_Registro_Consulta.SelectCommand.Parameters.Add(New SqlParameter("@Puntero", SqlDbType.VarChar, 200))
            'Asigne el valor de búsqueda al parámetro.
            Adaptador_Registro_Consulta.SelectCommand.Parameters("@Tabla_Registro").Value = Nombre_Tabla
            Adaptador_Registro_Consulta.SelectCommand.Parameters("@Columna_Registro").Value = Columna
            'Adaptador_Registro_Consulta.SelectCommand.Parameters("@Puntero").Value = Puntero.Tables(0).Rows(0)(0)
            'Realizar la lectura 
            'Adaptador_Registro_Consulta.Fill(Datos_Registro_Consulta, Nombre_Tabla)
            'Datos_Registro = Datos_Registro_Consulta
            For Index = 0 To Puntero.Tables(0).Rows.Count - 1
                Adaptador_Registro_Consulta.SelectCommand.Parameters("@Puntero").Value = Puntero.Tables(0).Rows(Index)(0)
                'Realizar la lectura 
                Adaptador_Registro_Consulta.Fill(Datos_Registro_Consulta, Nombre_Tabla)
                Datos_Registro.Tables(0).Rows.Add(Datos_Registro_Consulta.Tables(0).Rows(0)(0))
            Next Index
            Coneccion.Close()
        End If

        cmd_Registro_Consulta.Dispose()
        Adaptador_Registro_Consulta.Dispose()
        Datos_Registro_Consulta.Clear()
        Datos_Registro_Consulta.Dispose()
        Datos_Registro_Consulta.AcceptChanges()

        Return Datos_Registro
    End Function
    Public Shared Function Registro_Maximo_Valor_Puntero(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente As String, Fecha_Registro As String)
        'Funcion para consultar una tabla un intervalo en especifico, es impresindible que la tabla  tenga el campo Puntero(Puntero_inicio,Puntero_final,Intervalo_Entre_Punteros->siempre es 1)
        Dim Nombre_Tabla As String = (Usuario).Replace(" ", "_") + "___" + (Nombre_Paciente).Replace(" ", "_") + "___" + (Fecha_Registro).Replace(" ", "_")

        Dim Registro_Part As Int32 = -1
        Dim Bandera_Registro_Part_Ultimo As Boolean = False
        Dim Tabla_Consultar As String = ""
        While Bandera_Registro_Part_Ultimo = False
            'Obtengo el nombre de las tablas actual y  siquiente 
            Tabla_Consultar = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Part + 1) + " "
            'Pregunto se la tabla actual existe
            If Tabla_Existe(Coneccion, Tabla_Consultar) Then
                Registro_Part = Registro_Part + 1
            Else
                Bandera_Registro_Part_Ultimo = True
                Tabla_Consultar = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Part) + " "
            End If
        End While


        Dim Max_Puntero As Int64
        'Obter maximo valor de Puntero en un Registro
        Dim sql_Max_Registro As String = "Select MAX(Puntero) From " + Tabla_Consultar
        Dim cmd_Max_Registro As New SqlCommand(sql_Max_Registro, Coneccion)
        Dim Adaptador_Max_Registro As New SqlDataAdapter(cmd_Max_Registro)
        Dim Datos_Max_Registro As New DataSet

        If Coneccion.State <> 0 Then

            Try
                Adaptador_Max_Registro.Fill(Datos_Max_Registro, Tabla_Consultar)
                If Datos_Max_Registro.Tables(Nombre_Tabla).Rows(0)(0) = Nothing Then
                    Max_Puntero = 0

                Else
                    Max_Puntero = Datos_Max_Registro.Tables(Tabla_Consultar).Rows(0)(0)
                End If
            Catch ex As Exception
                Max_Puntero = 0
                'MsgBox(ex.Message)
            End Try
        Else
            Coneccion.Open()
            Try
                Adaptador_Max_Registro.Fill(Datos_Max_Registro, Tabla_Consultar)
                If Datos_Max_Registro.Tables(Tabla_Consultar).Rows(0)(0) = Nothing Then
                    Max_Puntero = 0
                Else
                    Max_Puntero = Datos_Max_Registro.Tables(Tabla_Consultar).Rows(0)(0)
                End If
            Catch ex As Exception
                Max_Puntero = 0
                'MsgBox(ex.Message)
            End Try
            Coneccion.Close()
        End If

        cmd_Max_Registro.Dispose()
        Adaptador_Max_Registro.Dispose()

        Datos_Max_Registro.Clear()
        Datos_Max_Registro.Dispose()
        Datos_Max_Registro.AcceptChanges()

        Return Max_Puntero
    End Function
    Public Shared Function Registro_Maximo_Valor_Puntero(Coneccion As SqlConnection, ByRef Tabla As String)
        'Funcion para consultar una tabla un intervalo en especifico, es impresindible que la tabla  tenga el campo Puntero(Puntero_inicio,Puntero_final,Intervalo_Entre_Punteros->siempre es 1)
        Dim Registro_Part As Int32 = -1
        Dim Bandera_Registro_Part_Ultimo As Boolean = False
        Dim Tabla_Consultar As String = ""
        While Bandera_Registro_Part_Ultimo = False
            'Obtengo el nombre de las tablas actual y  siquiente 
            Tabla_Consultar = Tabla + "_Part_" + Convert.ToString(Registro_Part + 1) + " "
            'Pregunto se la tabla actual existe
            If Tabla_Existe(Coneccion, Tabla_Consultar) Then
                Registro_Part = Registro_Part + 1
            Else
                Bandera_Registro_Part_Ultimo = True
                Tabla_Consultar = Tabla + "_Part_" + Convert.ToString(Registro_Part) + " "
            End If
        End While

        If Registro_Part = -1 Then
            Return 0
        Else
            Dim Max_Puntero As Int64
            'Obter maximo valor de Puntero en un Registro
            Dim Nombre_Tabla As String = ""
            Nombre_Tabla = Tabla_Consultar
            Dim sql_Max_Registro As String = "Select MAX(Puntero) From " + Nombre_Tabla
            'Actualizar la Funcion de arriba
            Dim cmd_Max_Registro As New SqlCommand(sql_Max_Registro, Coneccion)
            Dim Adaptador_Max_Registro As New SqlDataAdapter(cmd_Max_Registro)
            Dim Datos_Max_Registro As New DataSet

            If Coneccion.State <> 0 Then

                Try
                    Adaptador_Max_Registro.Fill(Datos_Max_Registro, Nombre_Tabla)
                    If Datos_Max_Registro.Tables(Nombre_Tabla).Rows(0)(0) = Nothing Then
                        Max_Puntero = 0
                    Else
                        Max_Puntero = Datos_Max_Registro.Tables(Nombre_Tabla).Rows(0)(0)
                    End If

                Catch ex As Exception
                    Max_Puntero = 0
                    'MsgBox(ex.Message)
                End Try
            Else
                Coneccion.Open()

                Try
                    Adaptador_Max_Registro.Fill(Datos_Max_Registro, Nombre_Tabla)
                    If Datos_Max_Registro.Tables(Nombre_Tabla).Rows(0)(0) = Nothing Then
                        Max_Puntero = 0
                    Else
                        Max_Puntero = Datos_Max_Registro.Tables(Nombre_Tabla).Rows(0)(0)
                    End If

                Catch ex As Exception
                    Max_Puntero = 0
                    'MsgBox(ex.Message)
                End Try
                Coneccion.Close()
            End If

            cmd_Max_Registro.Dispose()
            Adaptador_Max_Registro.Dispose()
            Datos_Max_Registro.Clear()
            Datos_Max_Registro.Dispose()
            Datos_Max_Registro.AcceptChanges()

            Return Max_Puntero
        End If

    End Function
    Public Shared Function Registro_Maximo_Valor(Coneccion As SqlConnection, Nombre_Tabla As String, Columna As String, Puntero_inicio As String, Puntero_final As String)
        'Funcion para consultar una tabla un intervalo en especifico, es impresindible que la tabla  tenga el campo Puntero(Puntero_inicio,Puntero_final,Intervalo_Entre_Punteros->siempre es 1)
        Dim Puntero_inicio_temp As String
        If Convert.ToInt32(Puntero_inicio) < 0 Then
            Puntero_inicio_temp = "0"
        Else
            Puntero_inicio_temp = Puntero_inicio
        End If

        Dim Registro_Inic_Part As Int32 = Math.Floor(Convert.ToInt32(Puntero_inicio_temp) / 1000000)
        Dim Registro_Fin_Part As Int32 = Math.Floor(Convert.ToInt32(Puntero_final) / 1000000)
        Dim Registro_Cont_Part As Int32 = 0
        Dim Tabla_Consultar As String
        Dim Tabla_Consultar_1 As String
        Dim Tablas_Consultar As String = "("
        While Registro_Cont_Part <= Registro_Fin_Part - Registro_Inic_Part
            'Obtengo el nombre de las tablas actual y  siquiente 
            Tabla_Consultar = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part) + " "
            Tabla_Consultar_1 = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part + 1) + " "
            'Pregunto se la tabla actual existe
            If Tabla_Existe(Coneccion, Tabla_Consultar) Then
                'Pregunto se la tabla siguinte existe
                If Tabla_Existe(Coneccion, Tabla_Consultar_1) And Registro_Cont_Part < Registro_Fin_Part - Registro_Inic_Part Then
                    'Si la tabla siguinte existe espero para adicionarla a la consulta
                    Tablas_Consultar = Tablas_Consultar + "Select MAX(" + Columna + ") From " + Tabla_Consultar + " WHERE Puntero>=" + Puntero_inicio_temp + " and Puntero<=" + Puntero_final + " UNION "
                Else
                    'Si la tabla siguinte no existe finalizo la adicion de tablas para a la consulta
                    Tablas_Consultar = Tablas_Consultar + "Select MAX(" + Columna + ") From " + Tabla_Consultar + " WHERE Puntero>=" + Puntero_inicio_temp + " And Puntero<=" + Puntero_final + ")"
                    Registro_Cont_Part = Registro_Cont_Part + Registro_Fin_Part - Registro_Inic_Part

                End If
            End If
            Registro_Cont_Part = Registro_Cont_Part + 1
        End While
        If Tablas_Consultar = "(" Then
            Tabla_Consultar = Nombre_Tabla + "_Part_0"
            Tablas_Consultar = Tablas_Consultar + "Select MAX(" + Columna + ") From " + Tabla_Consultar + " WHERE Puntero>=-2 And Puntero<=-1) ORDER BY Puntero ASC"
        End If


        'Funcion para consultar una tabla un intervalo en especifico, es impresindible que la tabla  tenga el campo Puntero(Puntero_inicio,Puntero_final,Intervalo_Entre_Punteros)

        Dim Max_Valor As Double
        'Obter maximo valor de una Columna en un intervalo de registro  Registro
        'Dim Nombre_Tabla As String = Tabla
        Dim sql_Max_Registro As String = Tablas_Consultar
        Dim cmd_Max_Registro As New SqlCommand(sql_Max_Registro, Coneccion)
        Dim Adaptador_Max_Registro As New SqlDataAdapter(cmd_Max_Registro)
        Dim Datos_Max_Registro As New DataSet

        If Coneccion.State <> 0 Then

            Try
                Adaptador_Max_Registro.Fill(Datos_Max_Registro, Nombre_Tabla)
                If Datos_Max_Registro.Tables(Nombre_Tabla).Rows(0)(0) = Nothing Then
                    Max_Valor = -99999999
                Else
                    Max_Valor = Datos_Max_Registro.Tables(Nombre_Tabla).Rows(0)(0)
                End If

            Catch ex As Exception
                Max_Valor = -99999999
                'MsgBox(ex.Message)
            End Try
        Else
            Coneccion.Open()

            Try
                Adaptador_Max_Registro.Fill(Datos_Max_Registro, Nombre_Tabla)
                If Datos_Max_Registro.Tables(Nombre_Tabla).Rows(0)(0) = Nothing Then
                    Max_Valor = -99999999
                Else
                    Max_Valor = Datos_Max_Registro.Tables(Nombre_Tabla).Rows(0)(0)
                End If

            Catch ex As Exception
                Max_Valor = -99999999
                'MsgBox(ex.Message)
            End Try
            Coneccion.Close()
        End If

        cmd_Max_Registro.Dispose()
        Adaptador_Max_Registro.Dispose()
        Datos_Max_Registro.Clear()
        Datos_Max_Registro.Dispose()
        Datos_Max_Registro.AcceptChanges()

        Return Max_Valor
    End Function
    Public Shared Function Registro_Minimo_Valor(Coneccion As SqlConnection, Nombre_Tabla As String, Columna As String, Puntero_inicio As String, Puntero_final As String)
        'Funcion para consultar una tabla un intervalo en especifico, es impresindible que la tabla  tenga el campo Puntero(Puntero_inicio,Puntero_final,Intervalo_Entre_Punteros->siempre es 1)
        Dim Puntero_inicio_temp As String
        If Convert.ToInt32(Puntero_inicio) < 0 Then
            Puntero_inicio_temp = "0"
        Else
            Puntero_inicio_temp = Puntero_inicio
        End If

        Dim Registro_Inic_Part As Int32 = Math.Floor(Convert.ToInt32(Puntero_inicio_temp) / 1000000)
        Dim Registro_Fin_Part As Int32 = Math.Floor(Convert.ToInt32(Puntero_final) / 1000000)
        Dim Registro_Cont_Part As Int32 = 0
        Dim Tabla_Consultar As String
        Dim Tabla_Consultar_1 As String
        Dim Tablas_Consultar As String = "("
        While Registro_Cont_Part <= Registro_Fin_Part - Registro_Inic_Part
            'Obtengo el nombre de las tablas actual y  siquiente 
            Tabla_Consultar = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part) + " "
            Tabla_Consultar_1 = Nombre_Tabla + "_Part_" + Convert.ToString(Registro_Inic_Part + Registro_Cont_Part + 1) + " "
            'Pregunto se la tabla actual existe
            If Tabla_Existe(Coneccion, Tabla_Consultar) Then
                'Pregunto se la tabla siguinte existe
                If Tabla_Existe(Coneccion, Tabla_Consultar_1) And Registro_Cont_Part < Registro_Fin_Part - Registro_Inic_Part Then
                    'Si la tabla siguinte existe espero para adicionarla a la consulta
                    Tablas_Consultar = Tablas_Consultar + "Select MIN(" + Columna + ") From " + Tabla_Consultar + " WHERE Puntero>=" + Puntero_inicio_temp + " and Puntero<=" + Puntero_final + " UNION "
                Else
                    'Si la tabla siguinte no existe finalizo la adicion de tablas para a la consulta
                    Tablas_Consultar = Tablas_Consultar + "Select MIN(" + Columna + ") From " + Tabla_Consultar + " WHERE Puntero>=" + Puntero_inicio_temp + " And Puntero<=" + Puntero_final + ")"
                    Registro_Cont_Part = Registro_Cont_Part + Registro_Fin_Part - Registro_Inic_Part

                End If
            End If
            Registro_Cont_Part = Registro_Cont_Part + 1
        End While
        If Tablas_Consultar = "(" Then
            Tabla_Consultar = Nombre_Tabla + "_Part_0"
            Tablas_Consultar = Tablas_Consultar + "Select MIN(" + Columna + ") From " + Tabla_Consultar + " WHERE Puntero>=-2 And Puntero<=-1) ORDER BY Puntero ASC"
        End If





        Dim Min_Valor As Double
        'Obter maximo valor de una Columna en un intervalo de registro  Registro
        Dim sql_Max_Registro As String = Tablas_Consultar
        Dim cmd_Max_Registro As New SqlCommand(sql_Max_Registro, Coneccion)
        Dim Adaptador_Max_Registro As New SqlDataAdapter(cmd_Max_Registro)
        Dim Datos_Max_Registro As New DataSet

        If Coneccion.State <> 0 Then

            Try
                Adaptador_Max_Registro.Fill(Datos_Max_Registro, Nombre_Tabla)
                If Datos_Max_Registro.Tables(Nombre_Tabla).Rows(0)(0) = Nothing Then
                    Min_Valor = 99999999
                Else
                    Min_Valor = Datos_Max_Registro.Tables(Nombre_Tabla).Rows(0)(0)
                End If

            Catch ex As Exception
                Min_Valor = 99999999
                'MsgBox(ex.Message)
            End Try
        Else
            Coneccion.Open()

            Try
                Adaptador_Max_Registro.Fill(Datos_Max_Registro, Nombre_Tabla)
                If Datos_Max_Registro.Tables(Nombre_Tabla).Rows(0)(0) = Nothing Then
                    Min_Valor = 99999999
                Else
                    Min_Valor = Datos_Max_Registro.Tables(Nombre_Tabla).Rows(0)(0)
                End If

            Catch ex As Exception
                Min_Valor = 99999999
                'MsgBox(ex.Message)
            End Try
            Coneccion.Close()
        End If

        cmd_Max_Registro.Dispose()
        Adaptador_Max_Registro.Dispose()
        Datos_Max_Registro.Clear()
        Datos_Max_Registro.Dispose()
        Datos_Max_Registro.AcceptChanges()

        Return Min_Valor
    End Function
    Public Shared Function Registro_Frecuencia(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente As String, Fecha_Registro As String)
        Dim Frecuencia As Double
        'Obtener valor de la Frecuancia en un Registro
        Dim sql_Max_Registro As String = "Select Frecuencia From Relacion_Registro_Paciente_Usuario WHERE Usuario='" + (Usuario).Replace(" ", "_") + "' AND Nombre_Paciente='" + (Nombre_Paciente).Replace(" ", "_") + "' AND Fecha_Registro='" + (Fecha_Registro).Replace(" ", "_") + "'"
        Dim cmd_Max_Registro As New SqlCommand(sql_Max_Registro, Coneccion)
        Dim Adaptador_Max_Registro As New SqlDataAdapter(cmd_Max_Registro)
        Dim Datos_Max_Registro As New DataSet

        If Coneccion.State <> 0 Then

            Try
                Adaptador_Max_Registro.Fill(Datos_Max_Registro, "Relacion_Registro_Paciente_Usuario")
                Frecuencia = Datos_Max_Registro.Tables("Relacion_Registro_Paciente_Usuario").Rows(0)(0)
            Catch ex As Exception
                MsgBox(ex.Message)
                Frecuencia = 0
            End Try
        Else
            Coneccion.Open()

            Try
                Adaptador_Max_Registro.Fill(Datos_Max_Registro, "Relacion_Registro_Paciente_Usuario")
                Frecuencia = Datos_Max_Registro.Tables("Relacion_Registro_Paciente_Usuario").Rows(0)(0)
            Catch ex As Exception
                MsgBox(ex.Message)
                Frecuencia = 0
            End Try
            Coneccion.Close()
        End If

        cmd_Max_Registro.Dispose()
        Adaptador_Max_Registro.Dispose()
        Datos_Max_Registro.Clear()
        Datos_Max_Registro.Dispose()
        Datos_Max_Registro.AcceptChanges()

        Return Frecuencia
    End Function
    Public Shared Function Registro_Existe(Coneccion As SqlConnection, Nombre_Tabla As String)
        Dim Bandera As Boolean
        'Determinar si existentees la tabla 
        Dim sql_Columnas_Existentes As String = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + Nombre_Tabla + "_Part_0'"
        Dim cmd_Columnas_Existentes As New SqlCommand(sql_Columnas_Existentes, Coneccion)
        Dim Adaptador_Columnas_Existentes As New SqlDataAdapter(cmd_Columnas_Existentes)
        Dim Datos_Columnas_Existentes As New DataSet

        If Coneccion.State <> 0 Then
            Try
                Adaptador_Columnas_Existentes.Fill(Datos_Columnas_Existentes, Nombre_Tabla)
                If Datos_Columnas_Existentes.Tables(Nombre_Tabla).Rows.Count <> 0 Then
                    Bandera = True
                Else
                    Bandera = False
                End If
            Catch ex As Exception
                Bandera = False
                MsgBox(ex.Message)
            End Try

        Else
            Coneccion.Open()
            Try
                Adaptador_Columnas_Existentes.Fill(Datos_Columnas_Existentes, Nombre_Tabla)
                If Datos_Columnas_Existentes.Tables(Nombre_Tabla).Rows.Count <> 0 Then
                    Bandera = True
                Else
                    Bandera = False
                End If
            Catch ex As Exception
                Bandera = False
                MsgBox(ex.Message)
            End Try
            Coneccion.Close()
        End If

        cmd_Columnas_Existentes.Dispose()
        Adaptador_Columnas_Existentes.Dispose()

        Datos_Columnas_Existentes.Clear()
        Datos_Columnas_Existentes.Dispose()
        Datos_Columnas_Existentes.AcceptChanges()

        Return Bandera
    End Function




    Public Shared Function Tabla_Relacion_Registro_Derivada_Procesada_Agregar_Dato(Coneccion As SqlConnection, Registro As String, Derivada As String, Campo As String, Valor_Campo As String)
        'Introduce un Un registro en la Tabla con un campo
        Dim sql_Incertar_Usuario As String = "INSERT INTO Relacion_Registro_Derivacion_Procesada (Registro,Derivacion," + Campo + ") VALUES ('" + Registro + "','" + Derivada + "'," + Valor_Campo + " )"
        Dim cmd_Incertar As New SqlCommand(sql_Incertar_Usuario, Coneccion)

        If Coneccion.State <> 0 Then

            Try
                cmd_Incertar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Incertar.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()

            Try
                cmd_Incertar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Incertar.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Incertar.Dispose()

        Return True
    End Function
    Public Shared Function Tabla_Relacion_Registro_Derivada_Procesada_Eliminar_Dato(Coneccion As SqlConnection, Registro As String, Derivada As String)
        'Elimina un un registro en la Tabla elacion_Registro_Derivacion_Procesada
        Dim sql_Eliminar As String = "DELETE FROM Relacion_Registro_Derivacion_Procesada  WHERE Registro='" + Registro + "' and Derivacion='" + Derivada + "'"
        Dim cmd_Eliminar As New SqlCommand(sql_Eliminar, Coneccion)

        If Coneccion.State <> 0 Then
            Try
                cmd_Eliminar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Eliminar.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                cmd_Eliminar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Eliminar.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If
        cmd_Eliminar.Dispose()

        Return True
    End Function
    Public Shared Function Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion As SqlConnection, Registro As String, Derivada As String, Campo As String, Valor_Campo As String)
        'Actualiza el valor de un campo en la tabla Relacion_Registro_Derivacion_Procesada
        Dim sql_Actualizar As String = "UPDATE Relacion_Registro_Derivacion_Procesada SET " + Campo + " =" + Valor_Campo + " WHERE Registro='" + Registro + "' and Derivacion='" + Derivada + "'"
        Dim cmd_Actualizar As New SqlCommand(sql_Actualizar, Coneccion)
        Dim Incert_Adaptador As New SqlDataAdapter(cmd_Actualizar)

        If Coneccion.State <> 0 Then

            Try
                cmd_Actualizar.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Actualizar.Dispose()
                Incert_Adaptador.Dispose()

                Return False
            End Try
        Else
            Coneccion.Open()

            Try
                cmd_Actualizar.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Actualizar.Dispose()
                Incert_Adaptador.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Actualizar.Dispose()
        Incert_Adaptador.Dispose()

        Return True
    End Function
    Public Shared Function Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion As SqlConnection, Registro As String, Derivada As String, Campo As String)
        'Devuelve el valor de un campo en la tabla Relacion_Registro_Derivacion_Procesada
        '0 si el valor es falso o Nulo
        '1 si el valor es verdadero
        '2 si el registro no existe

        Dim sql_Registro As String = "SELECT " + Campo + " FROM Relacion_Registro_Derivacion_Procesada WHERE Registro='" + Registro + "' and Derivacion='" + Derivada + "'"
        Dim cmd_Registro As New SqlCommand(sql_Registro, Coneccion)
        Dim Adaptador As New SqlDataAdapter(cmd_Registro)
        Dim Datos_Registro_Consulta As New DataSet

        If Coneccion.State <> 0 Then

            Try
                Adaptador.Fill(Datos_Registro_Consulta, "Relacion_Registro_Derivacion_Procesada")
                If Datos_Registro_Consulta.Tables(0).Rows.Count = 0 Then
                    Return 2
                Else
                    If IsDBNull(Datos_Registro_Consulta.Tables(0).Rows(0)(0)) = False Then
                        If Datos_Registro_Consulta.Tables(0).Rows(0)(0) Then
                            Return 1
                        Else
                            Return 0
                        End If
                    Else
                        Return 0
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Coneccion.Open()

            Try
                Adaptador.Fill(Datos_Registro_Consulta, "Relacion_Registro_Derivacion_Procesada")
                If Datos_Registro_Consulta.Tables(0).Rows.Count = 0 Then
                    Coneccion.Close()
                    Return 2
                Else
                    If IsDBNull(Datos_Registro_Consulta.Tables(0).Rows(0)(0)) = False Then
                        If Datos_Registro_Consulta.Tables(0).Rows(0)(0) Then
                            Coneccion.Close()
                            Return 1
                        Else
                            Coneccion.Close()
                            Return 0
                        End If

                    Else
                        Coneccion.Close()
                        Return 0
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Coneccion.Close()
        End If

        cmd_Registro.Dispose()
        Adaptador.Dispose()
        Datos_Registro_Consulta.Clear()
        Datos_Registro_Consulta.Dispose()
        Datos_Registro_Consulta.AcceptChanges()

        'Return True
        Return 0

    End Function

    Public Shared Function Tabla_Datos_Pacientes_Agregar_Paciente(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente_Apellidos As String, Peso_kg As String, Estatura_cm As String, Sexo As String, Raza As String, ByRef Fecha_Nacimiento_Dia As String, ByRef Fecha_Nacimiento_Mes As String, ByRef Fecha_Nacimiento_Año As String, Detalles_Paciente As String, Marca_Paso As String)
        'Incertar un nuevo paciente en la Tabla Tabla_Datos_Pacientes
        Dim sql_Incertar_Registro_Paciente As String = " INSERT INTO Datos_Pacientes (Usuario,Nombre_Paciente_Apellidos,Peso_kg,Estatura_cm,Sexo,Raza,Fecha_Nacimiento,Detalles_Paciente,Marca_Paso) VALUES ('" + Usuario + "','" + Nombre_Paciente_Apellidos + "'," + Peso_kg + "," + Estatura_cm + ",'" + Sexo + "','" + Raza + "','" + Fecha_Nacimiento_Dia + "/" + Fecha_Nacimiento_Mes + "/" + Fecha_Nacimiento_Año + "','" + Detalles_Paciente + "','" + Marca_Paso + "')"
        Dim cmd_Incertar As New SqlCommand(sql_Incertar_Registro_Paciente, Coneccion)
        Dim Incert_Adaptador As New SqlDataAdapter(cmd_Incertar)

        If Coneccion.State <> 0 Then
            Try
                cmd_Incertar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Incertar.Dispose()
                Incert_Adaptador.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                cmd_Incertar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Incertar.Dispose()
                Incert_Adaptador.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Incertar.Dispose()
        Incert_Adaptador.Dispose()

        Return True
    End Function
    Public Shared Function Tabla_Datos_Pacientes_Eliminar_Paciente(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente As String)
        'Elimina una entrada en la tabla Datos_Pacientes
        Dim sql_Eliminar_Datos_Paciente As String = "DELETE FROM Datos_Pacientes WHERE Usuario='" + Usuario + "' AND Nombre_Paciente_Apellidos='" + Nombre_Paciente.Replace("_", " ") + "'"
        Dim cmd_Eliminar_Datos_Paciente As New SqlCommand(sql_Eliminar_Datos_Paciente, Coneccion)

        'Elimina una entrada en la tabla Datos_Pacientes Temporal
        Dim sql_Eliminar_Datos_Paciente_Temp As String = "DELETE FROM Datos_Pacientes WHERE Usuario='" + Usuario + "' AND Nombre_Paciente_Apellidos='" + Nombre_Paciente + "'"
        Dim cmd_Eliminar_Datos_Paciente_Temp As New SqlCommand(sql_Eliminar_Datos_Paciente_Temp, Coneccion)

        If Coneccion.State <> 0 Then
            Try
                cmd_Eliminar_Datos_Paciente.ExecuteNonQuery()
                cmd_Eliminar_Datos_Paciente_Temp.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Eliminar_Datos_Paciente.Dispose()
                cmd_Eliminar_Datos_Paciente_Temp.Dispose()

                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                cmd_Eliminar_Datos_Paciente.ExecuteNonQuery()
                cmd_Eliminar_Datos_Paciente_Temp.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Eliminar_Datos_Paciente.Dispose()
                cmd_Eliminar_Datos_Paciente_Temp.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Eliminar_Datos_Paciente.Dispose()
        cmd_Eliminar_Datos_Paciente_Temp.Dispose()

        Return True
    End Function
    Public Shared Function Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion As SqlConnection, Usuario As String)
        'Leer los pacientes de un Usuario en la tabla Tabla_Datos_Pacientes
        Dim sql_Paciente As String = "SELECT Nombre_Paciente_Apellidos  FROM Datos_Pacientes WHERE Usuario='" + Usuario + "' ORDER BY Nombre_Paciente_Apellidos"
        Dim cmd_Paciente As New SqlCommand(sql_Paciente, Coneccion)
        Dim Adaptador As New SqlDataAdapter(cmd_Paciente)
        Dim Datos As New DataSet

        If Coneccion.State <> 0 Then
            Try
                Adaptador.Fill(Datos, "Datos_Pacientes")
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Paciente.Dispose()
                Adaptador.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                Adaptador.Fill(Datos, "Datos_Pacientes")
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Paciente.Dispose()
                Adaptador.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Paciente.Dispose()
        Adaptador.Dispose()

        Return Datos

    End Function
    Public Shared Function Tabla_Datos_Pacientes_Buscar_Datos_Paciente(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente As String, ByRef Peso_kg As String, ByRef Estatura_cm As String, ByRef Sexo As String, ByRef Raza As String, ByRef Fecha_Nacimiento_Dia As String, ByRef Fecha_Nacimiento_Mes As String, ByRef Fecha_Nacimiento_Año As String, ByRef Detalles_Paciente As String, ByRef Marca_Paso As String)
        'Leer los datos  de un paciente de un Usuario en la tabla Tabla_Datos_Pacientes
        'Dim sql_Tipo_Usuario As String = "SELECT Peso_kg,Estatura_cm,Sexo,Raza,Fecha_Nacimiento,Detalles_Paciente,Marca_Paso FROM Datos_Pacientes WHERE  Usuario='" + Usuario + "' AND Nombre_Paciente_Apellidos='" + Nombre_Paciente.Replace("", " ") + "'"
        Dim sql_Tipo_Usuario As String = "SELECT Peso_kg,Estatura_cm,Sexo,Raza,Fecha_Nacimiento,Detalles_Paciente,Marca_Paso FROM Datos_Pacientes WHERE  Usuario='" + Usuario + "' AND Nombre_Paciente_Apellidos='" + Nombre_Paciente.Replace(" ", "_") + "'"

        Dim cmd As New SqlCommand(sql_Tipo_Usuario, Coneccion)
        Dim fecha As String
        Dim Adaptador As New SqlDataAdapter(cmd)
        Dim Datos As New DataSet

        If Coneccion.State <> 0 Then
            Try
                Adaptador.Fill(Datos, "Datos_Pacientes")

                Peso_kg = Convert.ToString(Convert.ToString(Datos.Tables("Datos_Pacientes").Rows(0)(0)))
                Estatura_cm = Convert.ToString(Convert.ToString(Datos.Tables("Datos_Pacientes").Rows(0)(1)))
                Sexo = Datos.Tables("Datos_Pacientes").Rows(0)(2)
                Raza = Datos.Tables("Datos_Pacientes").Rows(0)(3)
                fecha = Datos.Tables("Datos_Pacientes").Rows(0)(4)
                Fecha_Nacimiento_Dia = fecha.Substring(0, 2)
                Fecha_Nacimiento_Mes = fecha.Substring(3, 2)
                Fecha_Nacimiento_Año = fecha.Substring(6, 4)
                Detalles_Paciente = Datos.Tables("Datos_Pacientes").Rows(0)(5)
                Marca_Paso = Datos.Tables("Datos_Pacientes").Rows(0)(6)

            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd.Dispose()
                Adaptador.Dispose()

                Datos.Clear()
                Datos.Dispose()
                Datos.AcceptChanges()
                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                Adaptador.Fill(Datos, "Datos_Pacientes")

                Peso_kg = Convert.ToString(Datos.Tables("Datos_Pacientes").Rows(0)(0))
                Estatura_cm = Convert.ToString(Datos.Tables("Datos_Pacientes").Rows(0)(1))
                Sexo = Datos.Tables("Datos_Pacientes").Rows(0)(2)
                Raza = Datos.Tables("Datos_Pacientes").Rows(0)(3)
                fecha = Datos.Tables("Datos_Pacientes").Rows(0)(4)
                Fecha_Nacimiento_Dia = fecha.Substring(0, 2)
                Fecha_Nacimiento_Mes = fecha.Substring(3, 2)
                Fecha_Nacimiento_Año = fecha.Substring(6, 4)
                Detalles_Paciente = Datos.Tables("Datos_Pacientes").Rows(0)(5)
                Marca_Paso = Datos.Tables("Datos_Pacientes").Rows(0)(6)

            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd.Dispose()
                Adaptador.Dispose()

                Datos.Clear()
                Datos.Dispose()
                Datos.AcceptChanges()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd.Dispose()
        Adaptador.Dispose()

        Datos.Clear()
        Datos.Dispose()
        Datos.AcceptChanges()

        Return True
    End Function
    Public Shared Function Tabla_Datos_Pacientes_Validar_Existencia_Paciente(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente_Apellidos As String)
        'Comprobar si un paciente existe en la tabla Tabla_Datos_Pacientes
        Dim sql_Identificar_Paciente As String = "SELECT Nombre_Paciente_Apellidos  FROM Datos_Pacientes WHERE Usuario='" + Usuario + "' AND Nombre_Paciente_Apellidos='" + Nombre_Paciente_Apellidos + "'"
        Dim cmd As New SqlCommand(sql_Identificar_Paciente, Coneccion)
        Dim Adaptador As New SqlDataAdapter(cmd)
        Dim Datos As New DataSet
        Dim Existencia_Paciente As Boolean

        If Coneccion.State <> 0 Then
            Try
                Adaptador.Fill(Datos, "Datos_Pacientes")
                If Datos.Tables("Datos_Pacientes").Rows.Count = 0 Then
                    Existencia_Paciente = False
                Else
                    Existencia_Paciente = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()

                cmd.Dispose()
                Adaptador.Dispose()
                Datos.Clear()
                Datos.Dispose()
                Datos.AcceptChanges()
                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                Adaptador.Fill(Datos, "Datos_Pacientes")
                If Datos.Tables("Datos_Pacientes").Rows.Count = 0 Then
                    Existencia_Paciente = False
                Else
                    Existencia_Paciente = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()

                cmd.Dispose()
                Adaptador.Dispose()
                Datos.Clear()
                Datos.Dispose()
                Datos.AcceptChanges()

                Return False
            End Try
            Coneccion.Close()
        End If

        cmd.Dispose()
        Adaptador.Dispose()
        Datos.Clear()
        Datos.Dispose()
        Datos.AcceptChanges()

        Return Existencia_Paciente
    End Function












    Public Shared Function Tabla_Datos_Pacientes_Actualizar_Datos_Paciente(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente_Apellidos As String, Peso_kg As String, Estatura_cm As String, Sexo As String, Raza As String, Fecha_Nacimiento_Dia As String, Fecha_Nacimiento_Mes As String, Fecha_Nacimiento_Año As String, Detalles_Paciente As String, Marca_Paso As String)
        'Actualisar los datos del paceinte en la tabla  Tabla_Datos_Pacientes
        Dim sql_Actualizar As String = "UPDATE Datos_Pacientes SET Peso_kg='" + Peso_kg + "', Estatura_cm=" + Estatura_cm + ", Sexo='" + Sexo + "', Raza='" + Raza + "', Fecha_Nacimiento='" + Fecha_Nacimiento_Dia + "/" + Fecha_Nacimiento_Mes + "/" + Fecha_Nacimiento_Año + "', Detalles_Paciente='" + Detalles_Paciente + "', Marca_Paso='" + Marca_Paso + "'  WHERE Usuario='" + Usuario + "' AND Nombre_Paciente_Apellidos='" + Nombre_Paciente_Apellidos + "'"
        Dim cmd_Actualizar As New SqlCommand(sql_Actualizar, Coneccion)
        Dim Incert_Adaptador As New SqlDataAdapter(cmd_Actualizar)

        If Coneccion.State <> 0 Then
            Try
                cmd_Actualizar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Actualizar.Dispose()
                Incert_Adaptador.Dispose()

                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                cmd_Actualizar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Actualizar.Dispose()
                Incert_Adaptador.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If
        cmd_Actualizar.Dispose()
        Incert_Adaptador.Dispose()

        Return True
    End Function


    Public Shared Function Tabla_Relacion_Registro_Paciente_Usuario_Agregar_Dato(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente As String, Fecha_Registro As String, Frecuencia As String, Derivaciones As String)
        'Introduce un Relacion_Registro_Paciente_Usuario en la Tabla
        Dim sql_Incertar_Usuario As String = "INSERT INTO Relacion_Registro_Paciente_Usuario (Usuario,Nombre_Paciente,Fecha_Registro,Frecuencia,Derivaciones) VALUES ('" + Usuario + "','" + Nombre_Paciente + "','" + Fecha_Registro + "','" + Frecuencia + "','" + Derivaciones + "')"
        Dim cmd_Incertar As New SqlCommand(sql_Incertar_Usuario, Coneccion)
        'Dim Incert_Adaptador As New SqlDataAdapter(cmd_Incertar)

        If Coneccion.State <> 0 Then

            Try
                cmd_Incertar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Incertar.Dispose()

                Return False
            End Try
        Else
            Coneccion.Open()

            Try
                cmd_Incertar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Incertar.Dispose()

                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Incertar.Dispose()

        Return True
    End Function
    Public Shared Function Tabla_Relacion_Registro_Paciente_Usuario_Eliminar_Paciente(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente As String)
        'Elimina una entrada en la tabla Tabla_Relacion_Registro_Paciente_Usuario
        Dim sql_Eliminar_Relacion_Registro_Paciente_Usuario As String = "DELETE FROM Relacion_Registro_Paciente_Usuario WHERE Usuario='" + Usuario + "' AND Nombre_Paciente='" + Nombre_Paciente + "'"
        Dim cmd_Eliminar_Relacion_Registro_Paciente_Usuario As New SqlCommand(sql_Eliminar_Relacion_Registro_Paciente_Usuario, Coneccion)

        If Coneccion.State <> 0 Then
            Try
                cmd_Eliminar_Relacion_Registro_Paciente_Usuario.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Eliminar_Relacion_Registro_Paciente_Usuario.Dispose()

                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                cmd_Eliminar_Relacion_Registro_Paciente_Usuario.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Eliminar_Relacion_Registro_Paciente_Usuario.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Eliminar_Relacion_Registro_Paciente_Usuario.Dispose()

        Return True
    End Function
    Public Shared Function Tabla_Relacion_Registro_Paciente_Usuario_Eliminar_Registro(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente As String, Fecha_Registro As String)
        'Elimina una entrada en la tabla Tabla_Relacion_Registro_Paciente_Usuario
        Dim sql_Eliminar_Relacion_Registro_Paciente_Usuario As String = "DELETE FROM Relacion_Registro_Paciente_Usuario WHERE Usuario='" + Usuario + "' AND Nombre_Paciente='" + Nombre_Paciente + "' AND Fecha_Registro='" + Fecha_Registro + "'"
        Dim cmd_Eliminar_Relacion_Registro_Paciente_Usuario As New SqlCommand(sql_Eliminar_Relacion_Registro_Paciente_Usuario, Coneccion)

        If Coneccion.State <> 0 Then
            Try
                cmd_Eliminar_Relacion_Registro_Paciente_Usuario.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Eliminar_Relacion_Registro_Paciente_Usuario.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                cmd_Eliminar_Relacion_Registro_Paciente_Usuario.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                cmd_Eliminar_Relacion_Registro_Paciente_Usuario.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Eliminar_Relacion_Registro_Paciente_Usuario.Dispose()
        Return True
    End Function
    Public Shared Function Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente As String)
        'Buscar todos los regsitros del pacientes en  la tabla Relacion_Registro_Paciente_Usuario en la Tabla
        Dim sql_Tipo_Usuario As String = "SELECT Fecha_Registro  FROM Relacion_Registro_Paciente_Usuario WHERE  Usuario='" + Usuario + "' AND Nombre_Paciente='" + Nombre_Paciente + "' ORDER BY Fecha_Registro"
        Dim cmd As New SqlCommand(sql_Tipo_Usuario, Coneccion)
        Dim Adaptador As New SqlDataAdapter(cmd)
        Dim Datos As New DataSet

        If Coneccion.State <> 0 Then

            Try
                Adaptador.Fill(Datos, "Nombre_Paciente")
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd.Dispose()
                Adaptador.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()

            Try
                Adaptador.Fill(Datos, "Nombre_Paciente")
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd.Dispose()
                Adaptador.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd.Dispose()
        Adaptador.Dispose()

        Return Datos
    End Function
    Public Shared Function Tabla_Relacion_Registro_Paciente_Usuario_Validar_Registro(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente As String, Fecha_Registro As String)
        'Buscar si el registros del pacientes  ya existe en  la tabla Relacion_Registro_Paciente_Usuario
        Dim sql_Identificar_Registro As String = "SELECT Fecha_Registro  FROM Relacion_Registro_Paciente_Usuario WHERE Usuario='" + Usuario + "' AND Nombre_Paciente='" + Nombre_Paciente + "' AND Fecha_Registro='" + Fecha_Registro + "'"
        Dim cmd_Registro As New SqlCommand(sql_Identificar_Registro, Coneccion)
        Dim Adaptador_Registro As New SqlDataAdapter(cmd_Registro)
        Dim Datos_Registro As New DataSet
        Dim Validar_Registro As Boolean

        If Coneccion.State <> 0 Then

            Try
                Adaptador_Registro.Fill(Datos_Registro, "Relacion_Registro_Paciente_Usuario")
                If Datos_Registro.Tables("Relacion_Registro_Paciente_Usuario").Rows.Count = 0 Then
                    Validar_Registro = False
                Else
                    Validar_Registro = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Registro.Dispose()
                Adaptador_Registro.Dispose()
                Datos_Registro.Clear()
                Datos_Registro.Dispose()
                Datos_Registro.AcceptChanges()

                Return False
            End Try
        Else
            Coneccion.Open()
            'Buscar si el registros del pacientes  ya existe en  la tabla Relacion_Registro_Paciente_Usuario
            Try
                Adaptador_Registro.Fill(Datos_Registro, "Relacion_Registro_Paciente_Usuario")
                If Datos_Registro.Tables("Relacion_Registro_Paciente_Usuario").Rows.Count = 0 Then
                    Validar_Registro = False
                Else
                    Validar_Registro = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Registro.Dispose()
                Adaptador_Registro.Dispose()
                Datos_Registro.Clear()
                Datos_Registro.Dispose()
                Datos_Registro.AcceptChanges()

                Return False
            End Try
            Coneccion.Close()
        End If
        cmd_Registro.Dispose()
        Adaptador_Registro.Dispose()
        Datos_Registro.Clear()
        Datos_Registro.Dispose()
        Datos_Registro.AcceptChanges()


        Return Validar_Registro
    End Function
    Public Shared Function Tabla_Relacion_Registro_Paciente_Usuario_Actualizar_Registro(Coneccion As SqlConnection, Usuario_Actual As String, Nombre_Paciente_Actual As String, Fecha_Registro_Actual As String, Usuario_Nuevo As String, Nombre_Paciente_Nuevo As String, Fecha_Registro_Nuevo As String)
        'Introduce un Relacion_Registro_Paciente_Usuario en la Tabla
        Dim sql_Actualizar As String = "UPDATE Relacion_Registro_Paciente_Usuario SET Usuario='" + Usuario_Nuevo + "',Nombre_Paciente='" + Nombre_Paciente_Nuevo + "', Fecha_Registro='" + Fecha_Registro_Nuevo + "'  WHERE Usuario='" + Usuario_Actual + "' AND Nombre_Paciente='" + Nombre_Paciente_Actual + "' AND Fecha_Registro='" + Fecha_Registro_Actual + "'"
        Dim cmd_Actualizar As New SqlCommand(sql_Actualizar, Coneccion)
        Dim Incert_Adaptador As New SqlDataAdapter(cmd_Actualizar)

        If Coneccion.State <> 0 Then

            Try
                cmd_Actualizar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Actualizar.Dispose()
                Incert_Adaptador.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()

            Try
                cmd_Actualizar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Actualizar.Dispose()
                Incert_Adaptador.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Actualizar.Dispose()
        Incert_Adaptador.Dispose()

        Return True
    End Function
    Public Shared Function Tabla_Relacion_Registro_Paciente_Usuario_Actualizar_Registro(Coneccion As SqlConnection, Usuario_Actual As String, Nombre_Paciente_Actual As String, Fecha_Registro_Actual As String, Usuario_Nuevo As String, Nombre_Paciente_Nuevo As String, Fecha_Registro_Nuevo As String, Frecuencia_Nuevo As String)
        'Introduce un Relacion_Registro_Paciente_Usuario en la Tabla
        Dim sql_Actualizar As String = "UPDATE Relacion_Registro_Paciente_Usuario SET Usuario='" + Usuario_Nuevo + "',Nombre_Paciente='" + Nombre_Paciente_Nuevo + "', Fecha_Registro='" + Fecha_Registro_Nuevo + "', Frecuencia='" + Frecuencia_Nuevo + "'  WHERE Usuario='" + Usuario_Actual + "' AND Nombre_Paciente='" + Nombre_Paciente_Actual + "' AND Fecha_Registro='" + Fecha_Registro_Actual + "'"
        Dim cmd_Actualizar As New SqlCommand(sql_Actualizar, Coneccion)
        Dim Incert_Adaptador As New SqlDataAdapter(cmd_Actualizar)

        If Coneccion.State <> 0 Then

            Try
                cmd_Actualizar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Actualizar.Dispose()
                Incert_Adaptador.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()

            Try
                cmd_Actualizar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Actualizar.Dispose()
                Incert_Adaptador.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Actualizar.Dispose()
        Incert_Adaptador.Dispose()

        Return True
    End Function
    Public Shared Function Tabla_Relacion_Registro_Paciente_Usuario_Actualizar_Registro(Coneccion As SqlConnection, Usuario_Actual As String, Nombre_Paciente_Actual As String, Fecha_Registro_Actual As String, Usuario_Nuevo As String, Nombre_Paciente_Nuevo As String, Fecha_Registro_Nuevo As String, Frecuencia_Nuevo As String, Derivaciones_Nuevo As String)
        'Introduce un Relacion_Registro_Paciente_Usuario en la Tabla
        Dim sql_Actualizar As String = "UPDATE Relacion_Registro_Paciente_Usuario SET Usuario='" + Usuario_Nuevo + "',Nombre_Paciente='" + Nombre_Paciente_Nuevo + "', Fecha_Registro='" + Fecha_Registro_Nuevo + "', Frecuencia='" + Frecuencia_Nuevo + "', Derivaciones='" + Derivaciones_Nuevo + "'  WHERE Usuario='" + Usuario_Actual + "' AND Nombre_Paciente='" + Nombre_Paciente_Actual + "' AND Fecha_Registro='" + Fecha_Registro_Actual + "'"
        Dim cmd_Actualizar As New SqlCommand(sql_Actualizar, Coneccion)
        Dim Incert_Adaptador As New SqlDataAdapter(cmd_Actualizar)

        If Coneccion.State <> 0 Then

            Try
                cmd_Actualizar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Actualizar.Dispose()
                Incert_Adaptador.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()

            Try
                cmd_Actualizar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Actualizar.Dispose()
                Incert_Adaptador.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Actualizar.Dispose()
        Incert_Adaptador.Dispose()

        Return True
    End Function
    Public Shared Function Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Frecuencia_Registro(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente As String, Fecha_Registro As String)
        'Buscar la frecuencia  de un regsitro
        Dim sql_Tipo_Usuario As String = "SELECT Frecuencia  FROM Relacion_Registro_Paciente_Usuario WHERE  Usuario='" + Usuario + "' AND Nombre_Paciente='" + Nombre_Paciente + "' AND Fecha_Registro='" + Fecha_Registro + "'"
        Dim cmd As New SqlCommand(sql_Tipo_Usuario, Coneccion)
        Dim Adaptador As New SqlDataAdapter(cmd)
        Dim Datos As New DataSet
        Dim frecuencia As Double

        If Coneccion.State <> 0 Then

            Try
                Adaptador.Fill(Datos, "Nombre_Paciente")
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd.Dispose()
                Adaptador.Dispose()
                Datos.Clear()
                Datos.Dispose()
                Datos.AcceptChanges()
                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                Adaptador.Fill(Datos, "Nombre_Paciente")
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd.Dispose()
                Adaptador.Dispose()
                Datos.Clear()
                Datos.Dispose()
                Datos.AcceptChanges()
                Return False
            End Try
            Coneccion.Close()
        End If

        frecuencia = Datos.Tables(0).Rows(0)(0)

        cmd.Dispose()
        Adaptador.Dispose()
        Datos.Clear()
        Datos.Dispose()
        Datos.AcceptChanges()

        Return frecuencia
    End Function

    Public Shared Function Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Derivaciones_Registro(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente As String, Fecha_Registro As String)
        'Buscar las derivaciones de un regsitro
        Dim sql_Tipo_Usuario As String = "SELECT Derivaciones  FROM Relacion_Registro_Paciente_Usuario WHERE  Usuario='" + Usuario + "' AND Nombre_Paciente='" + Nombre_Paciente + "' AND Fecha_Registro='" + Fecha_Registro + "'"
        Dim cmd As New SqlCommand(sql_Tipo_Usuario, Coneccion)
        Dim Adaptador As New SqlDataAdapter(cmd)
        Dim Datos As New DataSet
        Dim Derivaciones As New List(Of String)
        Dim Derivaciones_Temp As String

        If Coneccion.State <> 0 Then

            Try
                Adaptador.Fill(Datos, "Nombre_Paciente")
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd.Dispose()
                Adaptador.Dispose()
                Datos.Clear()
                Datos.Dispose()
                Datos.AcceptChanges()
                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                Adaptador.Fill(Datos, "Nombre_Paciente")
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd.Dispose()
                Adaptador.Dispose()
                Datos.Clear()
                Datos.Dispose()
                Datos.AcceptChanges()
                Return False
            End Try
            Coneccion.Close()
        End If
        'Copio el resultado
        Derivaciones_Temp = Datos.Tables(0).Rows(0)(0).ToString
        'Lo convierto en un DataSet
        Dim Index As Int16 = 0
        While Derivaciones_Temp.Contains(",") = True
            Derivaciones.Add(Derivaciones_Temp.Substring(0, Derivaciones_Temp.IndexOf(",")))
            Derivaciones_Temp = Derivaciones_Temp.Substring(Derivaciones_Temp.IndexOf(",") + 1)
            Index = Index + 1
        End While
        Derivaciones.Add(Derivaciones_Temp)

        'Dim Separador As Char =','
        'Derivaciones_Temp_1 = Derivaciones_Temp.Split(Separador)


        cmd.Dispose()
        Adaptador.Dispose()
        Datos.Clear()
        Datos.Dispose()
        Datos.AcceptChanges()

        Return Derivaciones
    End Function


    'Public Shared Function Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Pacientes(Coneccion As SqlConnection, Usuario As String)

    '    If Coneccion.State <> 0 Then
    '        'Buscar todos los pacientes del usuario en  la tabla Relacion_Registro_Paciente_Usuario en la Tabla
    '        Dim sql_Tipo_Usuario As String = "SELECT Nombre_Paciente  FROM Relacion_Registro_Paciente_Usuario WHERE  Usuario='" + Usuario + "'"
    '        Dim cmd As New SqlCommand(sql_Tipo_Usuario, Coneccion)

    '        Try
    '            Dim Adaptador As New SqlDataAdapter(cmd)
    '            Dim Datos As New DataSet
    '            Return Adaptador.Fill(Datos, "Nombre_Paciente")
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '            Coneccion.Close()
    '            Return False
    '        End Try
    '    Else
    '        Coneccion.Open()
    '        'Buscar todos los pacientes del usuario en  la tabla Relacion_Registro_Paciente_Usuario en la Tabla
    '        Dim sql_Tipo_Usuario As String = "SELECT Nombre_Paciente  FROM Relacion_Registro_Paciente_Usuario WHERE  Usuario='" + Usuario + "'"
    '        Dim cmd As New SqlCommand(sql_Tipo_Usuario, Coneccion)

    '        Try
    '            Dim Adaptador As New SqlDataAdapter(cmd)
    '            Dim Datos As New DataSet
    '            Return Adaptador.Fill(Datos, "Nombre_Paciente")
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '            Coneccion.Close()
    '            Return False
    '        End Try
    '        Coneccion.Close()
    '    End If

    '    Return True
    'End Function

    ''Public Shared Function Actualizar_Dato_Tabla_Relacion_Registro_Paciente_Usuario(Coneccion As SqlConnection, Registro As String, Derivada As String, Campo As String, Valor_Campo As String)

    ''    If Coneccion.State <> 0 Then
    ''        'Actualiza el valor de un campo en la tabla Relacion_Registro_Derivacion_Procesada
    ''        Dim sql_Actualizar As String = "UPDATE Relacion_Registro_Derivacion_Procesada SET " + Campo + " =" + Valor_Campo + " WHERE Registro='" + Registro + "' and Derivacion='" + Derivada + "'"
    ''        Dim cmd_Actualizar As New SqlCommand(sql_Actualizar, Coneccion)
    ''        Dim Incert_Adaptador As New SqlDataAdapter(cmd_Actualizar)

    ''        Try
    ''            cmd_Actualizar.ExecuteNonQuery()

    ''        Catch ex As Exception
    ''            MsgBox(ex.Message)

    ''            Return False
    ''        End Try
    ''    Else
    ''        Coneccion.Open()
    ''        'Actualiza el valor de un campo en la tabla Relacion_Registro_Derivacion_Procesada
    ''        Dim sql_Actualizar As String = "UPDATE Relacion_Registro_Derivacion_Procesada SET " + Campo + " =" + Valor_Campo + " WHERE Registro='" + Registro + "' and Derivacion='" + Derivada + "'"
    ''        Dim cmd_Actualizar As New SqlCommand(sql_Actualizar, Coneccion)
    ''        Dim Incert_Adaptador As New SqlDataAdapter(cmd_Actualizar)

    ''        Try
    ''            cmd_Actualizar.ExecuteNonQuery()

    ''        Catch ex As Exception
    ''            MsgBox(ex.Message)
    ''            Coneccion.Close()
    ''            Return False
    ''        End Try
    ''        Coneccion.Close()
    ''    End If

    ''    Return True
    ''End Function
    ''Public Shared Function Consultar_Dato_Campo_Tabla_Relacion_Registro_Paciente_Usuario(Coneccion As SqlConnection, Registro As String, Derivada As String, Campo As String)

    ''    If Coneccion.State <> 0 Then
    ''        'Devuelve el valor de un campo en la tabla Relacion_Registro_Derivacion_Procesada
    ''        '0 si el valor es falso o Nulo
    ''        '1 si el valor es verdadero
    ''        '2 si el registro no existe

    ''        Dim sql_Registro As String = "SELECT " + Campo + " FROM Relacion_Registro_Derivacion_Procesada WHERE Registro='" + Registro + "' and Derivacion='" + Derivada + "'"
    ''        Dim cmd_Registro As New SqlCommand(sql_Registro, Coneccion)
    ''        Dim Adaptador As New SqlDataAdapter(cmd_Registro)
    ''        Dim Datos_Registro_Consulta As New DataSet

    ''        Try
    ''            Adaptador.Fill(Datos_Registro_Consulta, "Relacion_Registro_Derivacion_Procesada")
    ''            If Datos_Registro_Consulta.Tables(0).Rows.Count = 0 Then

    ''                Return 2
    ''            Else
    ''                If IsDBNull(Datos_Registro_Consulta.Tables(0).Rows(0)(0)) = False Then
    ''                    If Datos_Registro_Consulta.Tables(0).Rows(0)(0) Then

    ''                        Return 1
    ''                    Else

    ''                        Return 0
    ''                    End If

    ''                Else

    ''                    Return 0
    ''                End If
    ''            End If
    ''        Catch ex As Exception
    ''            MsgBox(ex.Message)
    ''        End Try
    ''    Else
    ''        Coneccion.Open()
    ''        'Devuelve el valor de un campo en la tabla Relacion_Registro_Derivacion_Procesada
    ''        '0 si el valor es falso o Nulo
    ''        '1 si el valor es verdadero
    ''        '2 si el registro no existe
    ''        Dim sql_Registro As String = "SELECT " + Campo + " FROM Relacion_Registro_Derivacion_Procesada WHERE Registro='" + Registro + "' and Derivacion='" + Derivada + "'"
    ''        Dim cmd_Registro As New SqlCommand(sql_Registro, Coneccion)
    ''        Dim Adaptador As New SqlDataAdapter(cmd_Registro)
    ''        Dim Datos_Registro_Consulta As New DataSet

    ''        Try
    ''            Adaptador.Fill(Datos_Registro_Consulta, "Relacion_Registro_Derivacion_Procesada")
    ''            If Datos_Registro_Consulta.Tables(0).Rows.Count = 0 Then
    ''                Coneccion.Close()
    ''                Return 2
    ''            Else
    ''                If IsDBNull(Datos_Registro_Consulta.Tables(0).Rows(0)(0)) = False Then
    ''                    If Datos_Registro_Consulta.Tables(0).Rows(0)(0) Then
    ''                        Coneccion.Close()
    ''                        Return 1
    ''                    Else
    ''                        Coneccion.Close()
    ''                        Return 0
    ''                    End If

    ''                Else
    ''                    Coneccion.Close()
    ''                    Return 0
    ''                End If
    ''            End If
    ''        Catch ex As Exception
    ''            MsgBox(ex.Message)
    ''        End Try
    ''        Coneccion.Close()
    ''    End If

    ''    Return True
    ''End Function




    Public Shared Function Tabla_Usuarios_Agregar_Usuario(Coneccion As SqlConnection, Tipo_de_Usuario As String, Usuario As String, Contraseña As String)
        'Introduce un Usuartio en la tabla Tabla_Usuarios
        Dim sql_Incertar_Usuario As String = "INSERT INTO Usuarios (Tipo_de_Usuario,Usuario,Contraseña) VALUES (" + Tipo_de_Usuario + ",'" + Usuario + "','" + Contraseña + "')"
        Dim cmd_Incertar As New SqlCommand(sql_Incertar_Usuario, Coneccion)
        'Dim Incert_Adaptador As New SqlDataAdapter(cmd_Incertar)

        If Coneccion.State <> 0 Then

            Try
                cmd_Incertar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Incertar.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()

            Try
                cmd_Incertar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Incertar.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If
        cmd_Incertar.Dispose()
        Return True
    End Function
    Public Shared Function Tabla_Usuarios_Eliminar_Usuario(Coneccion As SqlConnection, Usuario As String)
        'Elimina un usuario en la tabla Eliminar_Usuario
        Dim sql_Eliminar_Usuario As String = "DELETE FROM Usuarios WHERE Usuario='" + Usuario + "'"
        Dim cmd_Eliminar_Usuario As New SqlCommand(sql_Eliminar_Usuario, Coneccion)

        If Coneccion.State <> 0 Then
            Try
                cmd_Eliminar_Usuario.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Eliminar_Usuario.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()

            Try
                cmd_Eliminar_Usuario.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Eliminar_Usuario.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If
        cmd_Eliminar_Usuario.Dispose()

        Return True
    End Function
    Public Shared Function Tabla_Usuarios_Validar_Existencia_Usuarios(Coneccion As SqlConnection, Tipo_de_Usuario As String, Usuario As String)
        'Confiram la existencia de un usario un Relacion_Registro_Paciente_Usuario en la Tabla
        Dim sql_Tipo_Usuario As String = "SELECT Usuario  FROM Usuarios WHERE Tipo_de_Usuario='" + Tipo_de_Usuario + "' AND Usuario='" + Usuario + "'"
        Dim cmd As New SqlCommand(sql_Tipo_Usuario, Coneccion)
        Dim Adaptador As New SqlDataAdapter(cmd)
        Dim Datos As New DataSet
        Dim Validar_Existencia As Boolean

        If Coneccion.State <> 0 Then

            Try
                Adaptador.Fill(Datos, "Usuarios")
                If Datos.Tables("Usuarios").Rows.Count = 0 Then
                    Validar_Existencia = False
                Else
                    Validar_Existencia = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd.Dispose()
                Adaptador.Dispose()
                Datos.Clear()
                Datos.Dispose()
                Datos.AcceptChanges()
                Return False
            End Try
        Else
            Coneccion.Open()

            Try
                Adaptador.Fill(Datos, "Usuarios")
                If Datos.Tables("Usuarios").Rows.Count = 0 Then
                    Validar_Existencia = False
                Else
                    Validar_Existencia = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd.Dispose()
                Adaptador.Dispose()
                Datos.Clear()
                Datos.Dispose()
                Datos.AcceptChanges()
                Return False
            End Try
            Coneccion.Close()
        End If
        cmd.Dispose()
        Adaptador.Dispose()
        Datos.Clear()
        Datos.Dispose()
        Datos.AcceptChanges()

        Return Validar_Existencia
    End Function
    Public Shared Function Tabla_Usuarios_Validar_Contraseña(Coneccion As SqlConnection, Tipo_de_Usuario As String, Usuario As String, Contraseña As String)
        'Comprobar si las contraseñas son iguales
        Dim sql_Comprobar_Contraseña As String = "SELECT Contraseña  FROM Usuarios WHERE Usuario='" + Usuario + "' AND Tipo_de_Usuario=" + Tipo_de_Usuario
        Dim cmd As New SqlCommand(sql_Comprobar_Contraseña, Coneccion)
        Dim Adaptador As New SqlDataAdapter(cmd)
        Dim Datos As New DataSet
        Dim Contraseña_Temp As String
        Dim Validar_Contraseña As Boolean

        If Coneccion.State <> 0 Then
            Try
                Adaptador.Fill(Datos, "Usuarios")
                If Datos.Tables("Usuarios").Rows.Count > 0 Then
                    Contraseña_Temp = Datos.Tables("Usuarios").Rows(0)(0)
                    Contraseña_Temp = Contraseña_Temp.Trim()
                    If Contraseña_Temp = Contraseña Then
                        Validar_Contraseña = True
                    Else
                        Validar_Contraseña = False
                    End If
                Else
                    Validar_Contraseña = False
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd.Dispose()
                Adaptador.Dispose()
                Datos.Clear()
                Datos.Dispose()
                Datos.AcceptChanges()
                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                Adaptador.Fill(Datos, "Usuarios")
                If Datos.Tables("Usuarios").Rows.Count > 0 Then
                    Contraseña_Temp = Datos.Tables("Usuarios").Rows(0)(0)
                    Contraseña_Temp = Contraseña_Temp.Trim()
                    If Contraseña_Temp = Contraseña Then
                        Validar_Contraseña = True
                    Else
                        Validar_Contraseña = False
                    End If
                Else
                    Validar_Contraseña = False
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd.Dispose()
                Adaptador.Dispose()
                Datos.Clear()
                Datos.Dispose()
                Datos.AcceptChanges()
                Return False
            End Try
            Coneccion.Close()
        End If
        cmd.Dispose()
        Adaptador.Dispose()
        Datos.Clear()
        Datos.Dispose()
        Datos.AcceptChanges()

        Return Validar_Contraseña

    End Function
    Public Shared Function Tabla_Usuarios_Actualizar_Contraseña(Coneccion As SqlConnection, Usuario As String, Contraseña_Nueva As String)
        'Actualizar la contraseña en la Tabla_Usuarios
        Dim sql_Actualizar As String = "UPDATE Usuarios SET Contraseña='" + Contraseña_Nueva + "'  WHERE Usuario='" + Usuario + "'"
        Dim cmd_Actualizar As New SqlCommand(sql_Actualizar, Coneccion)
        Dim Incert_Adaptador As New SqlDataAdapter(cmd_Actualizar)

        If Coneccion.State <> 0 Then
            cmd_Actualizar.ExecuteNonQuery()

            Try
                cmd_Actualizar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Actualizar.Dispose()
                Incert_Adaptador.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()
            cmd_Actualizar.ExecuteNonQuery()

            Try
                cmd_Actualizar.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd_Actualizar.Dispose()
                Incert_Adaptador.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If

        cmd_Actualizar.Dispose()
        Incert_Adaptador.Dispose()

        Return True
    End Function
    Public Shared Function Tabla_Usuarios_Buscar_Usuarios(Coneccion As SqlConnection, Tipo_de_Usuario As String)
        'Lee los Usuarios en la tabla Tabla_Usuarios
        Dim sql_Tipo_Usuario As String = "SELECT Usuario  FROM Usuarios WHERE Tipo_de_Usuario=" + Tipo_de_Usuario
        Dim cmd As New SqlCommand(sql_Tipo_Usuario, Coneccion)
        Dim Adaptador As New SqlDataAdapter(cmd)
        Dim Datos As New DataSet

        If Coneccion.State <> 0 Then
            Try
                Adaptador.Fill(Datos, "Usuarios")
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd.Dispose()
                Adaptador.Dispose()
                Return False
            End Try
        Else
            Coneccion.Open()
            Try
                Adaptador.Fill(Datos, "Usuarios")
            Catch ex As Exception
                MsgBox(ex.Message)
                Coneccion.Close()
                cmd.Dispose()
                Adaptador.Dispose()
                Return False
            End Try
            Coneccion.Close()
        End If
        cmd.Dispose()
        Adaptador.Dispose()

        Return Datos
    End Function


    Public Shared Function Eliminar_Usuario(Coneccion As SqlConnection, Usuario As String)
        Dim Bandera_Necesario_Reiniciar As Boolean = False
        'Eliminar_Columna Registros y analisi relacionados
        Dim Pacientes As DataSet
        Pacientes = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion, Usuario)

        For Index = Pacientes.Tables(0).Rows.Count - 1 To 0 Step -1
            If Eliminar_Paciente(Coneccion, Usuario, Pacientes.Tables(0).Rows(Index)(0)) Then
                Bandera_Necesario_Reiniciar = True
            End If
        Next Index
        'Elimina un usuario en la tabla Eliminar_Usuario
        Tabla_Usuarios_Eliminar_Usuario(Coneccion, Usuario)
        Pacientes.Clear()
        Pacientes.Dispose()
        Pacientes.AcceptChanges()
        'Devuelve false si se reliazo la bien la aliminacion
        'Devuelve ture si es necesario reiniciar l apliacin para finalizar la eliminacion del registro
        Return Bandera_Necesario_Reiniciar
    End Function
    Public Shared Function Eliminar_Paciente(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente As String)
        Dim Bandera_Necesario_Reiniciar As Boolean = False
        'Eliminar Registros y analisi relacionados al paceinte
        Dim Registro As DataSet
        Registro = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion, Usuario, Nombre_Paciente)

        For Index = Registro.Tables(0).Rows.Count - 1 To 0 Step -1
            If Eliminar_Registro(Coneccion, Usuario, Nombre_Paciente, Registro.Tables(0).Rows(Index)(0)) Then
                Bandera_Necesario_Reiniciar = True
            End If
        Next Index

        'Eliminar los datos del paciente
        Tabla_Datos_Pacientes_Eliminar_Paciente(Coneccion, Usuario, Nombre_Paciente)
        'falta eliminarla entrada en la tabla Relacion_Registro_Derivacion_Procesada

        Registro.Clear()
        Registro.Dispose()
        Registro.AcceptChanges()
        'Devuelve false si se reliazo la bien la aliminacion
        'Devuelve ture si es necesario reiniciar l apliacin para finalizar la eliminacion del registro
        Return Bandera_Necesario_Reiniciar
    End Function
    Public Shared Function Eliminar_Registro(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente As String, Fecha_Registro As String)
        Dim Bandera_Necesario_Reiniciar As Boolean = False
        'Eliminar el Registro y las bases de datos
        Dim Derivaciones As List(Of String) = Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Derivaciones_Registro(Coneccion, Usuario, Nombre_Paciente, Fecha_Registro)
        Dim Direccion_Archivo_mdf As String
        Dim Direccion_Archivo_ldf As String
        For Index = 0 To Derivaciones.Count - 1
            Direccion_Archivo_mdf = Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Usuario + "___" + Nombre_Paciente + "___" + Fecha_Registro + "___" + Derivaciones.Item(Index).ToString + ".mdf"
            Direccion_Archivo_ldf = Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Usuario + "___" + Nombre_Paciente + "___" + Fecha_Registro + "___" + Derivaciones.Item(Index).ToString + "_log.ldf"
            If My.Computer.FileSystem.FileExists(Direccion_Archivo_mdf) Then
                Try
                    System.IO.File.Delete(Direccion_Archivo_mdf)
                Catch ex As Exception
                    Bandera_Necesario_Reiniciar = True
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
                    Bandera_Necesario_Reiniciar = True
                    Dim Archivo_Pendiente = Direccion_Archivo_ldf
                    Dim Archivo_Eliminar As System.IO.StreamWriter
                    Archivo_Eliminar = My.Computer.FileSystem.OpenTextFileWriter(Application.UserAppDataPath + "\Eliminar.txt", True)
                    Archivo_Eliminar.WriteLine(Archivo_Pendiente)
                    Archivo_Eliminar.Close()
                End Try
            End If
        Next Index
        'Eliminar la entrada del Regsitro en la Tabla _Relacion_Registro_Paciente_Usuario
        Tabla_Relacion_Registro_Paciente_Usuario_Eliminar_Registro(Coneccion, Usuario, Nombre_Paciente, Fecha_Registro)
        'Devuelve false si se reliazo la bien la aliminacion
        'Devuelve ture si es necesario reiniciar l apliacin para finalizar la eliminacion del registro
        Return Bandera_Necesario_Reiniciar
    End Function
    Public Shared Function Actualizar_Nombre_Paciente(Coneccion As SqlConnection, Usuario As String, Nombre_Paciente_Apellidos_Actual As String, Nombre_Paciente_Apellidos_Nuevo As String)

        'Actualisar el nombre de un paciente 

        Dim Registro As DataSet
        Registro = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion, Usuario, Nombre_Paciente_Apellidos_Actual)

        Dim Nombre_Tablas_Existentes As DataSet
        Nombre_Tablas_Existentes = Class_Funciones_Base_Datos.Tabla_Todas_Existentes(Coneccion)

        For Index = Registro.Tables(0).Rows.Count - 1 To 0 Step -1
            'Dim Frecuencia As String
            'Modificar el nombre del paciente en la tabla Tabla_Relacion_Registro_Paciente_Usuario
            'Frecuencia = Convert.ToString(Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Frecuencia_Registro(Coneccion, Usuario, Nombre_Paciente_Apellidos_Actual, Registro.Tables(0).Rows(Index)(0)))
            Tabla_Relacion_Registro_Paciente_Usuario_Actualizar_Registro(Coneccion, Usuario, Nombre_Paciente_Apellidos_Actual, Registro.Tables(0).Rows(Index)(0), Usuario, Nombre_Paciente_Apellidos_Nuevo, Registro.Tables(0).Rows(Index)(0))


            'Modificar el nombre  de las tabals relacionas con el paciente 
            For Index1 = Nombre_Tablas_Existentes.Tables(0).Rows.Count - 1 To 0 Step -1
                Dim Tabla_Nombre_Nuevo As String
                If InStr(Nombre_Tablas_Existentes.Tables(0).Rows(Index1)(0), Usuario + "___" + Nombre_Paciente_Apellidos_Actual + "___" + Registro.Tables(0).Rows(Index)(0)) <> 0 Then
                    Tabla_Nombre_Nuevo = Nombre_Tablas_Existentes.Tables(0).Rows(Index1)(0).Replace(Usuario + "___" + Nombre_Paciente_Apellidos_Actual + "___" + Registro.Tables(0).Rows(Index)(0), Usuario + "___" + Nombre_Paciente_Apellidos_Nuevo + "___" + Registro.Tables(0).Rows(Index)(0))
                    Tabla_Renombrar(Coneccion, Nombre_Tablas_Existentes.Tables(0).Rows(Index1)(0), Tabla_Nombre_Nuevo)
                End If
            Next Index1
        Next Index

        Registro.Clear()
        Registro.Dispose()
        Registro.AcceptChanges()

        Nombre_Tablas_Existentes.Clear()
        Nombre_Tablas_Existentes.Dispose()
        Nombre_Tablas_Existentes.AcceptChanges()

        Return True
    End Function
    '------------------------------------------------------------------------------------------------

End Class
