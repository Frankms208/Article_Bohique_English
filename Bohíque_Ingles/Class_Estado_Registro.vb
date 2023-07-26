Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class Class_Estado_Registro
    Public Structure Registro_Parcial
        Public Nombre_Tabla As String
        Public Nombre_Columna As String
        Public Usuario As String
        Public Paciente As String
        Public Fecha_Registro As String
        Public Frecuencia As Double
        Public Cantidad_Maxima_Datos As Double
        Public Color As Color
    End Structure

    Public Structure Datos_Registro
        Public Usuario As String
        Public Paciente As String
        Public Fecha_Registro As String
    End Structure
    Private Registros_Bloqueados As New List(Of Datos_Registro)



    Public Function Bloquear_Registro(Usuario As String, Paciente As String, Fecha_Registro As String)
        'Si el registo no esta bloquedo lo adiciona a la lista de registros bloqueados devuelve tre, de esta previamente bloqueado devuelve false
        Dim Bandera_Resgistro_Existente As Boolean
        Dim Nuevo_Registro As New Datos_Registro
        Bandera_Resgistro_Existente = 0
        For i = 0 To Registros_Bloqueados.Count - 1
            If Registros_Bloqueados.Item(i).Usuario = Usuario And Registros_Bloqueados.Item(i).Paciente = Paciente And Registros_Bloqueados.Item(i).Fecha_Registro = Fecha_Registro Then
                Bandera_Resgistro_Existente = 1
            End If
        Next
        If Bandera_Resgistro_Existente = 0 Then
            Nuevo_Registro.Usuario = Usuario
            Nuevo_Registro.Paciente = Paciente
            Nuevo_Registro.Fecha_Registro = Fecha_Registro
            Registros_Bloqueados.Add(Nuevo_Registro)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Desbloquear_Registro(Usuario As String, Paciente As String, Fecha_Registro As String)
        'Si el registo esta bloquedo lo elimina a la lista de registros bloqueados devuelve true, de si no esta devuelve false
        Dim Nuevo_Registro As New Datos_Registro

        For i = 0 To Registros_Bloqueados.Count - 1
            If Registros_Bloqueados.Item(i).Usuario = Usuario And Registros_Bloqueados.Item(i).Paciente = Paciente And Registros_Bloqueados.Item(i).Fecha_Registro = Fecha_Registro Then
                Registros_Bloqueados.RemoveAt(i)
                Return True
            End If
        Next
        Return False
    End Function
    Public Function Desbloquear_Registro(Registro As String)
        'Si el registo esta bloquedo lo elimina a la lista de registros bloqueados devuelve true, de si no esta devuelve false
        Dim Nuevo_Registro As New Datos_Registro

        For i = 0 To Registros_Bloqueados.Count - 1
            If Registro = Registros_Bloqueados.Item(i).Usuario + "___" + Registros_Bloqueados.Item(i).Paciente + "___" + Registros_Bloqueados.Item(i).Fecha_Registro Then
                Registros_Bloqueados.RemoveAt(i)
                Return True
            End If
        Next
        Return False
    End Function
    Public Function Consultar_Registro_Bloqueado(Usuario As String, Paciente As String, Fecha_Registro As String)
        'Si el registo esta en la lista de bloqueado devuelve trues si no devuelve false
        Dim Nuevo_Registro As New Datos_Registro
        For i = 0 To Registros_Bloqueados.Count - 1
            If Registros_Bloqueados.Item(i).Usuario = Usuario And Registros_Bloqueados.Item(i).Paciente = Paciente And Registros_Bloqueados.Item(i).Fecha_Registro = Fecha_Registro Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function Consultar_Registro_Bloqueado(Registro As String)
        'Si el registo esta en la lista de bloqueado devuelve trues si no devuelve false
        Dim Nuevo_Registro As New Datos_Registro
        For i = 0 To Registros_Bloqueados.Count - 1
            If Registro = Registros_Bloqueados.Item(i).Usuario + "___" + Registros_Bloqueados.Item(i).Paciente + "___" + Registros_Bloqueados.Item(i).Fecha_Registro Then
                Return True
            End If
        Next
        Return False
    End Function

End Class
