Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Windows.Forms.DataVisualization.Charting
Public Class Form_Modificar_Puntos_Registro
    Public Form_Invocador As Form
    Public UserControl_Modulo_Graficar_Invocador As UserControl_Modulo_Graficar
    Const Onda_QRS = 1

    Public Structure Registro_Zoom
        Public X_Inicio As Double
        Public X_Final As Double
        Public Y_Inicio As Double
        Public Y_Final As Double
        Public Zoom_Activo As Double
    End Structure
    Public Structure Respaldo_Datos
        Public Dato_1, Dato_2, Dato_3, Dato_4, Dato_5 As Double
    End Structure

    Dim Tipo_Onda_QRS() As String = {"Sin_QRS", "Qr", "qR", "Qrs", "qRs", "R", "Rs", "QS", "Qr_E", "Qrs_E", "qRs_E", "RS_E"}
    Public Zoom As Registro_Zoom
    'Copia de los puntos iniciales
    Public Respaldo_Puntos As Respaldo_Datos
    'Modificar_Puntos demine que Pnto de ñla unda se va a modificar cuando se mueva el mause
    Public Modificar_Puntos As Int16 = 0
    'Modificar_Puntos=0 -> modificacion desactivada
    'Modificar_Puntos=1 -> modificacion NumericUpDown_Dato_1
    'Modificar_Puntos=2 -> modificacion NumericUpDown_Dato_2
    'Modificar_Puntos=3 -> modificacion NumericUpDown_Dato_3
    'Modificar_Puntos=4 -> modificacion NumericUpDown_Dato_4
    'Modificar_Puntos=5 -> modificacion NumericUpDown_Dato_5
    Public Structure Registro_Modificar
        'CONTINE datos para el funcionamiento de la ventana
        Public Nombre_Tabla As String
        Public Nombre_Columna As String
        Public Usuario As String
        Public Paciente As String
        Public Fecha_Registro As String
        Public Frecuencia As Double
        Public Color As Color
        Public Ubicacion_Tabla_Referencia As Int16
        Public Intervalo_Min_X As Double
        Public Intervalo_Max_X As Double
        Public Intervalo_Min_Y As Double
        Public Intervalo_Max_Y As Double
        Public Accion_Modificar As Boolean
        Public Tipo_Onda As Int16
    End Structure
    Public Registro_Modificar_1 As Registro_Modificar
    Public Sub Actualizar_Estado_NumericUpDown_Dato_X()
        If NumericUpDown_Dato_1.Value < NumericUpDown_Dato_2.Value Then
            NumericUpDown_Dato_1.BackColor = Color.White
        Else
            NumericUpDown_Dato_1.BackColor = Color.OrangeRed
        End If
        If NumericUpDown_Dato_2.Value > NumericUpDown_Dato_1.Value And NumericUpDown_Dato_2.Value < NumericUpDown_Dato_3.Value Then
            NumericUpDown_Dato_2.BackColor = Color.White
        Else
            NumericUpDown_Dato_2.BackColor = Color.OrangeRed
        End If
        If Registro_Modificar_1.Tipo_Onda = Onda_QRS Then
            If NumericUpDown_Dato_3.Value > NumericUpDown_Dato_2.Value And NumericUpDown_Dato_3.Value < NumericUpDown_Dato_4.Value Then
                NumericUpDown_Dato_3.BackColor = Color.White
            Else
                NumericUpDown_Dato_3.BackColor = Color.OrangeRed
            End If
            If NumericUpDown_Dato_4.Value > NumericUpDown_Dato_3.Value And NumericUpDown_Dato_4.Value < NumericUpDown_Dato_5.Value Then
                NumericUpDown_Dato_4.BackColor = Color.White
            Else
                NumericUpDown_Dato_4.BackColor = Color.OrangeRed
            End If
            If NumericUpDown_Dato_5.Value > NumericUpDown_Dato_4.Value Then
                NumericUpDown_Dato_5.BackColor = Color.White
            Else
                NumericUpDown_Dato_5.BackColor = Color.OrangeRed
            End If
        End If

    End Sub

    Public Sub Form_Registro_Parciales_Modificar(Form_Invocador_1 As Form, UserControl_Modulo_Graficar_Invocador_1 As UserControl_Modulo_Graficar, Accion_Modificar As Boolean, Tipo_Onda As Int16, Ubicacion_Tabla As Int16, Optional Dato_ComboBox As Int16 = 0, Optional Dato_1 As Double = 0, Optional Dato_2 As Double = 0, Optional Dato_3 As Double = 0, Optional Dato_4 As Double = 0, Optional Dato_5 As Double = 0)

        'Tipo_Onda = 1 es una Onda QRS
        Const Onda_QRS = 1

        'Establecer los limites maximos y minimos de la grafica eje X
        Zoom.X_Inicio = Registro_Modificar_1.Intervalo_Min_X
        Zoom.X_Final = Registro_Modificar_1.Intervalo_Max_X
        'Obtener los limites maximos y minimos de la grafica je Y
        Dim Datos As New DataSet
        Dim y() As Double
        Dim Coneccion_Registro As New SqlConnection
        Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Registro_Modificar_1.Usuario, Registro_Modificar_1.Paciente, Registro_Modificar_1.Fecha_Registro, Registro_Modificar_1.Nombre_Columna)

        Datos = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Registro_Modificar_1.Nombre_Tabla, Registro_Modificar_1.Nombre_Columna, 1, Convert.ToString(Math.Floor(Registro_Modificar_1.Intervalo_Min_X * Registro_Modificar_1.Frecuencia)), Convert.ToString(Math.Ceiling(Registro_Modificar_1.Intervalo_Max_X * Registro_Modificar_1.Frecuencia)))
        'Redimencionar las variables
        ReDim y(Datos.Tables(0).Rows.Count - 1)
        'Obtener los valores a graficar 
        For Index1 = 0 To Datos.Tables(0).Rows.Count - 1
            y(Index1) = Datos.Tables(0).Rows(Index1)(1)
        Next Index1
        Zoom.Y_Inicio = y.Min
        Zoom.Y_Final = y.Max
        Registro_Modificar_1.Intervalo_Min_Y = y.Min
        Registro_Modificar_1.Intervalo_Max_Y = y.Max
        'Almacenar  el tipo de Onda a modificar 
        Registro_Modificar_1.Tipo_Onda = Tipo_Onda
        'Establecr parametros iniciales de los NumericUpDown
        'Paso de aumento 1/frecuencia
        NumericUpDown_Dato_1.Increment = 1 / Registro_Modificar_1.Frecuencia
        NumericUpDown_Dato_2.Increment = 1 / Registro_Modificar_1.Frecuencia
        NumericUpDown_Dato_3.Increment = 1 / Registro_Modificar_1.Frecuencia
        NumericUpDown_Dato_4.Increment = 1 / Registro_Modificar_1.Frecuencia
        NumericUpDown_Dato_5.Increment = 1 / Registro_Modificar_1.Frecuencia
        'Valor minimo que pueden tenr los puntos 
        NumericUpDown_Dato_1.Minimum = Registro_Modificar_1.Intervalo_Min_X
        NumericUpDown_Dato_2.Minimum = Registro_Modificar_1.Intervalo_Min_X
        NumericUpDown_Dato_3.Minimum = Registro_Modificar_1.Intervalo_Min_X
        NumericUpDown_Dato_4.Minimum = Registro_Modificar_1.Intervalo_Min_X
        NumericUpDown_Dato_5.Minimum = Registro_Modificar_1.Intervalo_Min_X
        'Valor maximo que pueden tenr los puntos
        NumericUpDown_Dato_1.Maximum = Registro_Modificar_1.Intervalo_Max_X
        NumericUpDown_Dato_2.Maximum = Registro_Modificar_1.Intervalo_Max_X
        NumericUpDown_Dato_3.Maximum = Registro_Modificar_1.Intervalo_Max_X
        NumericUpDown_Dato_4.Maximum = Registro_Modificar_1.Intervalo_Max_X
        NumericUpDown_Dato_5.Maximum = Registro_Modificar_1.Intervalo_Max_X

        'Respaldo de los Datos de la Onda
        Respaldo_Puntos.Dato_1 = Dato_1
        Respaldo_Puntos.Dato_2 = Dato_2
        Respaldo_Puntos.Dato_3 = Dato_3
        Respaldo_Puntos.Dato_4 = Dato_4
        Respaldo_Puntos.Dato_5 = Dato_5


        'Modificar  la ventana en funcion del tipo de Onda y si es para Modificar o agregar datos
        If Accion_Modificar = True Then
            If Tipo_Onda = Onda_QRS Then

                NumericUpDown_Dato_1.Value = Dato_1
                NumericUpDown_Dato_2.Value = Dato_2
                NumericUpDown_Dato_3.Value = Dato_3
                NumericUpDown_Dato_4.Value = Dato_4
                NumericUpDown_Dato_5.Value = Dato_5
                Label_Dato_1.Text = "Q_i"
                Label_Dato_2.Text = "Q"
                Label_Dato_3.Text = "R"
                Label_Dato_4.Text = "S"
                Label_Dato_5.Text = "J"
                ComboBox_Tipo_Onda_Modificar.Items.Clear()
                ComboBox_Tipo_Onda_Modificar.Items.AddRange(Tipo_Onda_QRS)
                ComboBox_Tipo_Onda_Modificar.SelectedIndex = Dato_ComboBox

            End If

        Else
            If Tipo_Onda = Onda_QRS Then
                'Asignacion de valores iniciles
                If Registro_Modificar_1.Intervalo_Min_X = 0 Then
                    NumericUpDown_Dato_1.Value = Dato_1 / 2
                    NumericUpDown_Dato_2.Value = Dato_2 / 2
                    NumericUpDown_Dato_3.Value = Dato_3 / 2
                    NumericUpDown_Dato_4.Value = Dato_4 / 2
                    NumericUpDown_Dato_5.Value = Dato_5 / 2
                Else
                    NumericUpDown_Dato_1.Value = Dato_1 + (Registro_Modificar_1.Intervalo_Max_X - Registro_Modificar_1.Intervalo_Min_X) / 2
                    NumericUpDown_Dato_2.Value = Dato_2 + (Registro_Modificar_1.Intervalo_Max_X - Registro_Modificar_1.Intervalo_Min_X) / 2
                    NumericUpDown_Dato_3.Value = Dato_3 + (Registro_Modificar_1.Intervalo_Max_X - Registro_Modificar_1.Intervalo_Min_X) / 2
                    NumericUpDown_Dato_4.Value = Dato_4 + (Registro_Modificar_1.Intervalo_Max_X - Registro_Modificar_1.Intervalo_Min_X) / 2
                    NumericUpDown_Dato_5.Value = Dato_5 + (Registro_Modificar_1.Intervalo_Max_X - Registro_Modificar_1.Intervalo_Min_X) / 2
                End If
                Label_Dato_1.Text = "Q_i"
                Label_Dato_2.Text = "Q"
                Label_Dato_3.Text = "R"
                Label_Dato_4.Text = "S"
                Label_Dato_5.Text = "J"
                ComboBox_Tipo_Onda_Modificar.Items.Clear()
                ComboBox_Tipo_Onda_Modificar.Items.AddRange(Tipo_Onda_QRS)
                ComboBox_Tipo_Onda_Modificar.SelectedIndex = Dato_ComboBox
            End If
        End If


        'Ubicacion en la tabla del dato a modificar o inceetar
        Registro_Modificar_1.Ubicacion_Tabla_Referencia = Ubicacion_Tabla
        Registro_Modificar_1.Accion_Modificar = Accion_Modificar
        UserControl_Modulo_Graficar_Invocador = UserControl_Modulo_Graficar_Invocador_1
        Form_Invocador = Form_Invocador_1
        Form_Invocador.Enabled = False
        'Actalizar la grafica
        Actualizar_Char_Registro_Modificar()
        Me.Show()
    End Sub

    Private Sub Form_Modificar_Puntos_Registro_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            Form_Invocador.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Actualizar_Char_Registro_Modificar()

        'Determina si hay regsitros para graficar
        'Habre la conexion
        Dim Coneccion_Registro As New SqlConnection
        Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Registro_Modificar_1.Usuario, Registro_Modificar_1.Paciente, Registro_Modificar_1.Fecha_Registro, Registro_Modificar_1.Nombre_Columna)

        Dim Registro_Tabla As String
        Dim Registro_Columna As String
        Dim Registro_Frecuencia As Double
        Dim Color As Color

        'Variables para acotar la el interblalo del eje Y 
        Dim Max_Y As Double = -20000000
        Dim Min_Y As Double = 20000000

        'Establece la cantidad maxima de puntos en el eje X 
        Const Grafica_Cantida_Datos_Max As Int32 = 20999

        Dim x(), y() As Double
        'Variables para acotar la el intervalo del eje X 
        Dim Intervalo_Max_X As Double = Zoom.X_Final
        Dim Intervalo_Min_X As Double = Zoom.X_Inicio

        'Variables para establecer la distancia en el eje x entre dos puntos
        Dim Paso_Registro As Int64

        'Establece el registro que se esta garficando
        Dim Registros_Selecionados As String = ""

        'Elimina todos los Registros en le Chart_Registro_Parcial
        Chart_Registro_Parcial.Series.Clear()
        'Recorrer todos los Registros existentes 
        'Se comprueba si el registro esta bloqueado
        If Registro_Modificar_1.Nombre_Tabla <> Nothing Then

            If Form_Principal.Estado_Registros.Consultar_Registro_Bloqueado(Registro_Modificar_1.Nombre_Tabla) = False Then
                '-------------------------------------------------------------------------------------------------------
                'Graficar registro
                '-------------------------------------------------------------------------------------------------------
                Registro_Tabla = Registro_Modificar_1.Nombre_Tabla
                Registro_Columna = Registro_Modificar_1.Nombre_Columna
                Registro_Frecuencia = Registro_Modificar_1.Frecuencia
                Color = Registro_Modificar_1.Color
                'Establecer el valor de Paso_Registro (distancia en el eje x entre dos puntos)
                Paso_Registro = Math.Floor(Registro_Frecuencia * (Intervalo_Max_X - Intervalo_Min_X) / (Grafica_Cantida_Datos_Max + 1))
                If Paso_Registro < 1 Then
                    Paso_Registro = 1
                End If
                'Obtencion de los  valores de os Registros 
                Dim Datos As New DataSet
                Datos = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Registro_Tabla, Registro_Columna, Paso_Registro, Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                'Redimencionar las variables
                ReDim y(Datos.Tables(Registro_Tabla).Rows.Count - 1)
                ReDim x(Datos.Tables(Registro_Tabla).Rows.Count - 1)

                'Obtener los valores a graficar 
                For Index1 = 0 To Datos.Tables(0).Rows.Count - 1
                    y(Index1) = Datos.Tables(Registro_Tabla).Rows(Index1)(1)
                    x(Index1) = (Datos.Tables(Registro_Tabla).Rows(Index1)(0) * Paso_Registro) / Registro_Frecuencia
                Next Index1
                'Obtener los valores maximos y minimo del eje Y
                If y.Count = 0 Then
                    Max_Y = Chart_Registro_Parcial.ChartAreas(0).AxisY.Maximum
                    Min_Y = Chart_Registro_Parcial.ChartAreas(0).AxisY.Minimum
                Else
                    If Max_Y < y.Max Then
                        Max_Y = y.Max
                    End If

                    If Min_Y > y.Min Then
                        Min_Y = y.Min
                    End If
                End If
                'Agregar el nuevo registro(Una nueva serie) a la Grafica parcial 
                Registros_Selecionados = Registro_Tabla + "___" + Registro_Columna
                Chart_Registro_Parcial.Series.Add(Registros_Selecionados)
                'Especifica que es una serie lineal 
                If CheckBox_Estilo_Linea.Checked Then
                    Chart_Registro_Parcial.Series(Registros_Selecionados).ChartType = DataVisualization.Charting.SeriesChartType.Line
                Else
                    Chart_Registro_Parcial.Series(Registros_Selecionados).ChartType = DataVisualization.Charting.SeriesChartType.Point
                End If
                'Adiciona los nuevos datos a la serie
                Chart_Registro_Parcial.Series(Registros_Selecionados).Points.DataBindXY(x, y)
                Chart_Registro_Parcial.Series(Registros_Selecionados).Color = Color


                '-------------------------------------------------------------------------------------------------------
                'Graficar Puntos Onda-P, COmplejo-QRS y Onda-T  si esta activada y existe 
                '-------------------------------------------------------------------------------------------------------
                'Obtengo los valoes de las posiciones de los complejos QRS en el registro  
                Dim Datos_Registro As DataSet
                Datos_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Registro_Tabla, Registro_Columna, Paso_Registro, Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))

                If Registro_Modificar_1.Tipo_Onda = Onda_QRS Then
                    'Creo los dataset
                    Dim y_Q_i, y_Q, y_R, y_S, y_J As Double
                    Dim x_Q_i, x_Q, x_R, x_S, x_J As Double
                    'Obtengo las pociciones de los complejos QRS  
                    If NumericUpDown_Dato_1.Text <> "" And ((NumericUpDown_Dato_1.Value) > Zoom.X_Inicio And (NumericUpDown_Dato_1.Value) < Zoom.X_Final) Then
                        'Creo las series
                        x_Q_i = (NumericUpDown_Dato_1.Value)
                        y_Q_i = Datos_Registro.Tables(0).Rows(x_Q_i * Registro_Frecuencia - Datos_Registro.Tables(0).Rows(0)(0))(1)
                        'Adiciono las series a la grafica
                        'Actualiza Series_Max Para que se vea al frente
                        Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q_i")
                        Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q_i").ChartType = DataVisualization.Charting.SeriesChartType.Point
                        Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q_i").Points.AddXY(x_Q_i, y_Q_i)
                        '  Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q_i").MarkerImage = "C:\Users\Frank\Dropbox\Dropbox\Bohíque_FMS\Bohíque_FMS\Imagenes\" + TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).ImageKey
                        Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q_i").Color = Color.Red
                    End If
                    If NumericUpDown_Dato_2.Text <> "" And ((NumericUpDown_Dato_2.Value) > Zoom.X_Inicio And (NumericUpDown_Dato_2.Value) < Zoom.X_Final) Then
                        'Creo las series
                        x_Q = (NumericUpDown_Dato_2.Value)
                        y_Q = Datos_Registro.Tables(0).Rows(x_Q * Registro_Frecuencia - Datos_Registro.Tables(0).Rows(0)(0))(1)
                        'Adiciono las series a la grafica
                        'Actualiza Series_Max Para que se vea al frente
                        Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q")
                        Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q").ChartType = DataVisualization.Charting.SeriesChartType.Point
                        Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q").Points.AddXY(x_Q, y_Q)
                        'Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q").MarkerImage = "C:\Users\Frank\Dropbox\Dropbox\Bohíque_FMS\Bohíque_FMS\Imagenes\" + TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).ImageKey
                        Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q").Color = Color.Green
                    End If
                    If NumericUpDown_Dato_3.Text <> "" And ((NumericUpDown_Dato_3.Value) > Zoom.X_Inicio And (NumericUpDown_Dato_3.Value) < Zoom.X_Final) Then
                        'Creo las series
                        x_R = (NumericUpDown_Dato_3.Value)
                        y_R = Datos_Registro.Tables(0).Rows(x_R * Registro_Frecuencia - Datos_Registro.Tables(0).Rows(0)(0))(1)
                        'Adiciono las series a la grafica
                        'Actualiza Series_Max Para que se vea al frente
                        Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "R")
                        Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "R").ChartType = DataVisualization.Charting.SeriesChartType.Point
                        Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "R").Points.AddXY(x_R, y_R)
                        'Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "R").MarkerImage = "C:\Users\Frank\Dropbox\Dropbox\Bohíque_FMS\Bohíque_FMS\Imagenes\" + TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).ImageKey
                        Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "R").Color = Color.Black
                    End If
                    If NumericUpDown_Dato_4.Text <> "" And ((NumericUpDown_Dato_4.Value) > Zoom.X_Inicio And (NumericUpDown_Dato_4.Value) < Zoom.X_Final) Then
                        'Creo las series
                        x_J = (NumericUpDown_Dato_4.Value)
                        y_J = Datos_Registro.Tables(0).Rows(x_J * Registro_Frecuencia - Datos_Registro.Tables(0).Rows(0)(0))(1)
                        'Adiciono las series a la grafica
                        'Actualiza Series_Max Para que se vea al frente
                        Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "J")
                        Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "J").ChartType = DataVisualization.Charting.SeriesChartType.Point
                        Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "J").Points.AddXY(x_J, y_J)
                        'Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "J").MarkerImage = "C:\Users\Frank\Dropbox\Dropbox\Bohíque_FMS\Bohíque_FMS\Imagenes\" + TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).ImageKey
                        Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "J").Color = Color.Chocolate
                    End If
                    If NumericUpDown_Dato_5.Text <> "" And ((NumericUpDown_Dato_5.Value) > Zoom.X_Inicio And (NumericUpDown_Dato_5.Value) < Zoom.X_Final) Then
                        'Creo las series
                        x_S = (NumericUpDown_Dato_5.Value)
                        y_S = Datos_Registro.Tables(0).Rows(x_S * Registro_Frecuencia - Datos_Registro.Tables(0).Rows(0)(0))(1)
                        'Adiciono las series a la grafica
                        'Actualiza Series_Max Para que se vea al frente
                        Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "S")
                        Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "S").ChartType = DataVisualization.Charting.SeriesChartType.Point
                        Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "S").Points.AddXY(x_S, y_S)
                        'Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "S").MarkerImage = "C:\Users\Frank\Dropbox\Dropbox\Bohíque_FMS\Bohíque_FMS\Imagenes\" + TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).ImageKey
                        Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "S").Color = Color.Blue
                    End If

                End If

            Else
                Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "Record " + Registro_Modificar_1.Nombre_Tabla, "is in use", "Record Error", 0)
                'Registro_Parciales_Graficados.RemoveAt(Index)
            End If
            '-----------------------------------------------------------
            'Establece los margenes de la grafica 
            '-----------------------------------------------------------
            If (Zoom.Y_Inicio = Zoom.Y_Final) Or (Zoom.X_Inicio = Zoom.X_Final) Then
                Chart_Registro_Parcial.ChartAreas(0).AxisY.Minimum = Min_Y
                Chart_Registro_Parcial.ChartAreas(0).AxisY.Maximum = Max_Y
                Chart_Registro_Parcial.ChartAreas(0).AxisX.Minimum = Intervalo_Min_X
                Chart_Registro_Parcial.ChartAreas(0).AxisX.Maximum = Intervalo_Max_X

            Else
                Chart_Registro_Parcial.ChartAreas(0).AxisY.Minimum = Zoom.Y_Inicio
                Chart_Registro_Parcial.ChartAreas(0).AxisY.Maximum = Zoom.Y_Final
                Chart_Registro_Parcial.ChartAreas(0).AxisX.Minimum = Zoom.X_Inicio
                Chart_Registro_Parcial.ChartAreas(0).AxisX.Maximum = Zoom.X_Final
            End If
            '-----------------------------------------------------------
            'Crear la linea vase en cero
            '-----------------------------------------------------------
            Dim y_0() As Double = {0, 0}
            Dim x_0() As Double = {Intervalo_Min_X, Intervalo_Max_X}
            'Agregar el nuevo registro(Una nueva serie) 
            Chart_Registro_Parcial.Series.Add("Linea_Base")
            'Especifica que es una serie lineal 
            Chart_Registro_Parcial.Series("Linea_Base").ChartType = DataVisualization.Charting.SeriesChartType.Line
            'Adiciona los nuevos datos a la serie
            Chart_Registro_Parcial.Series("Linea_Base").Points.DataBindXY(x_0, y_0)
            Chart_Registro_Parcial.Series("Linea_Base").Color = Color.Black

        End If

    End Sub

    Private Sub CheckBox_Estilo_Linea_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBox_Estilo_Linea.CheckStateChanged
        Actualizar_Char_Registro_Modificar()
    End Sub

    Private Sub Chart_Registro_Parcial_MouseDown(sender As Object, e As MouseEventArgs) Handles Chart_Registro_Parcial.MouseDown
        If e.Button = MouseButtons.Left Then
            'Determina si se preciono el boton izquierdo del mause
            If CheckBox_ZOOM.CheckState Then
                Dim posX, posY As Double
                'Determina la posicion del mause en la grafica en pixeles
                posX = e.X
                posY = e.Y
                'Corige valores fuera de rango
                If posX <= 0 Then
                    posX = 0
                ElseIf posX >= Chart_Registro_Parcial.Width Then
                    posX = Chart_Registro_Parcial.Width - 1
                End If


                If posY <= 0 Then
                    posY = 0
                ElseIf posY >= Chart_Registro_Parcial.Height Then
                    posY = Chart_Registro_Parcial.Height - 1
                End If

                'Determina la posicion del mause en la grafica en respeto al eje X
                posX = Chart_Registro_Parcial.ChartAreas(0).AxisX.PixelPositionToValue(posX)

                If posX > NumericUpDown_Dato_1.Maximum Then
                    posX = NumericUpDown_Dato_1.Maximum - NumericUpDown_Dato_1.Increment
                End If
                If posX < NumericUpDown_Dato_1.Minimum Then
                    posX = NumericUpDown_Dato_1.Minimum + NumericUpDown_Dato_1.Increment
                End If
                'Determina la posicion del mause en la grafica en respeto al eje Y
                posY = Chart_Registro_Parcial.ChartAreas(0).AxisY.PixelPositionToValue(posY)

                Zoom.X_Inicio = posX
                Zoom.Y_Inicio = posY
                Zoom.Zoom_Activo = 1
                'Crear Cuadro de ampliacion  
                '             1 ->
                '    o-------------------o
                '  	 |                   | 
                ' ^ 4|                   |2 
                ' |	 |                   | 
                '    o-------------------o
                '            <-3
                Chart_Registro_Parcial.Series.Add("Cuadro_Ampliacion_1")
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_1").ChartType = DataVisualization.Charting.SeriesChartType.StepLine
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_1").Points.AddXY(posX, posY)
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_1").Points.AddXY(posX, posY)
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_1").Color = Color.Gray

                Chart_Registro_Parcial.Series.Add("Cuadro_Ampliacion_2")
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_2").ChartType = DataVisualization.Charting.SeriesChartType.StepLine
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_2").Points.AddXY(posX, posY)
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_2").Points.AddXY(posX, posY)
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_2").Color = Color.Gray

                Chart_Registro_Parcial.Series.Add("Cuadro_Ampliacion_3")
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_3").ChartType = DataVisualization.Charting.SeriesChartType.StepLine
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_3").Points.AddXY(posX, posY)
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_3").Points.AddXY(posX, posY)
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_3").Color = Color.Gray

                Chart_Registro_Parcial.Series.Add("Cuadro_Ampliacion_4")
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_4").ChartType = DataVisualization.Charting.SeriesChartType.StepLine
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_4").Points.AddXY(posX, posY)
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_4").Points.AddXY(posX, posY)
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_4").Color = Color.Gray
            Else
                Dim posX As Double
                Dim Resta_Num_1, Resta_Num_2, Resta_Num_3, Resta_Num_4, Resta_Num_5 As Double

                'Determina la posicion del mause en la grafica en pixeles
                posX = e.X
                'Corige valores fuera de rango
                If posX <= 0 Then
                    posX = 0
                ElseIf posX >= Chart_Registro_Parcial.Width Then
                    posX = Chart_Registro_Parcial.Width - 1
                End If
                'Determina la posicion del mause en la grafica en respeto al eje X
                posX = Chart_Registro_Parcial.ChartAreas(0).AxisX.PixelPositionToValue(posX)
                If posX > NumericUpDown_Dato_1.Maximum Then
                    posX = NumericUpDown_Dato_1.Maximum - NumericUpDown_Dato_1.Increment
                End If
                If posX < NumericUpDown_Dato_1.Minimum Then
                    posX = NumericUpDown_Dato_1.Minimum + NumericUpDown_Dato_1.Increment
                End If

                Resta_Num_1 = Math.Abs(NumericUpDown_Dato_1.Value - posX)
                Resta_Num_2 = Math.Abs(NumericUpDown_Dato_2.Value - posX)
                Resta_Num_3 = Math.Abs(NumericUpDown_Dato_3.Value - posX)
                Resta_Num_4 = Math.Abs(NumericUpDown_Dato_4.Value - posX)
                Resta_Num_5 = Math.Abs(NumericUpDown_Dato_5.Value - posX)
                'Determina el valor del NumericUpDown_Dato_x que se ba a modificar dependiento de tipo de Onda 
                If Registro_Modificar_1.Tipo_Onda = Onda_QRS Then
                    If Resta_Num_1 <= Resta_Num_2 And Resta_Num_1 <= Resta_Num_3 And Resta_Num_1 <= Resta_Num_4 And Resta_Num_1 <= Resta_Num_5 Then
                        Modificar_Puntos = 1
                    ElseIf Resta_Num_2 < Resta_Num_1 And Resta_Num_2 <= Resta_Num_3 And Resta_Num_2 <= Resta_Num_4 And Resta_Num_2 <= Resta_Num_5 Then
                        Modificar_Puntos = 2
                    ElseIf Resta_Num_3 < Resta_Num_1 And Resta_Num_3 < Resta_Num_2 And Resta_Num_3 <= Resta_Num_4 And Resta_Num_5 <= Resta_Num_5 Then
                        Modificar_Puntos = 3
                    ElseIf Resta_Num_4 < Resta_Num_1 And Resta_Num_4 < Resta_Num_2 And Resta_Num_4 < Resta_Num_3 And Resta_Num_4 <= Resta_Num_5 Then
                        Modificar_Puntos = 4
                    Else
                        Modificar_Puntos = 5
                    End If
                End If
            End If

        End If
    End Sub

    Private Sub Chart_Registro_Parcial_MouseMove(sender As Object, e As MouseEventArgs) Handles Chart_Registro_Parcial.MouseMove
        If CheckBox_ZOOM.CheckState Then
            If Zoom.Zoom_Activo = 1 Then
                Dim posX, posY As Double
                'Determina la posicion del mause en la grafica en pixeles
                posX = e.X
                posY = e.Y
                'Corige valores fuera de rango
                If posX <= 0 Then
                    posX = 0
                ElseIf posX >= Chart_Registro_Parcial.Width Then
                    posX = Chart_Registro_Parcial.Width - 2
                End If


                If posY <= 0 Then
                    posY = 0
                ElseIf posY >= Chart_Registro_Parcial.Height Then
                    posY = Chart_Registro_Parcial.Height - 2
                End If

                'Determina la posicion del mause en la grafica en respeto al eje X
                posX = Chart_Registro_Parcial.ChartAreas(0).AxisX.PixelPositionToValue(posX)
                If posX > NumericUpDown_Dato_1.Maximum Then
                    posX = NumericUpDown_Dato_1.Maximum - NumericUpDown_Dato_1.Increment
                End If
                If posX < NumericUpDown_Dato_1.Minimum Then
                    posX = NumericUpDown_Dato_1.Minimum + NumericUpDown_Dato_1.Increment
                End If
                'Determina la posicion del mause en la grafica en respeto al eje Y
                posY = Chart_Registro_Parcial.ChartAreas(0).AxisY.PixelPositionToValue(posY)

                'Modificar Cuadro de ampliacion  
                '             1 ->
                '    o-------------------o
                '  	 |                   | 
                ' ^ 4|                   |2 
                ' |	 |                   | 
                '    o-------------------o
                '            <-3
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_1").Points(1).XValue = posX

                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_2").Points(0).XValue = posX
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_2").Points(1).XValue = posX
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_2").Points(1).YValues(0) = posY

                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_3").Points(0).XValue = posX
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_3").Points(0).YValues(0) = posY
                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_3").Points(1).YValues(0) = posY

                Chart_Registro_Parcial.Series("Cuadro_Ampliacion_4").Points(0).YValues(0) = posY


            End If
        Else
            'Determina si se va a modificar un punto 
            If Modificar_Puntos <> 0 Then
                Dim posX As Double
                'Determina la posicion del mause en la grafica en pixeles
                posX = e.X
                If posX <= 0 Then
                    posX = 0
                ElseIf posX >= Chart_Registro_Parcial.Width Then
                    posX = Chart_Registro_Parcial.Width - 2
                End If
                'Determina la posicion del mause en la grafica en respeto al eje X
                posX = Chart_Registro_Parcial.ChartAreas(0).AxisX.PixelPositionToValue(posX)
                If posX > NumericUpDown_Dato_1.Maximum Then
                    posX = NumericUpDown_Dato_1.Maximum - NumericUpDown_Dato_1.Increment
                End If
                If posX < NumericUpDown_Dato_1.Minimum Then
                    posX = NumericUpDown_Dato_1.Minimum + NumericUpDown_Dato_1.Increment
                End If
                'Actualizo NumericUpDown_Dato_x ajustando la tasa de cambio a la frecuencia 
                If Modificar_Puntos = 1 Then
                    NumericUpDown_Dato_1.Value = Math.Round(posX * Registro_Modificar_1.Frecuencia) / Registro_Modificar_1.Frecuencia
                ElseIf Modificar_Puntos = 2 Then
                    NumericUpDown_Dato_2.Value = Math.Round(posX * Registro_Modificar_1.Frecuencia) / Registro_Modificar_1.Frecuencia
                ElseIf Modificar_Puntos = 3 Then
                    NumericUpDown_Dato_3.Value = Math.Round(posX * Registro_Modificar_1.Frecuencia) / Registro_Modificar_1.Frecuencia
                ElseIf Modificar_Puntos = 4 Then
                    NumericUpDown_Dato_4.Value = Math.Round(posX * Registro_Modificar_1.Frecuencia) / Registro_Modificar_1.Frecuencia
                ElseIf Modificar_Puntos = 5 Then
                    NumericUpDown_Dato_5.Value = Math.Round(posX * Registro_Modificar_1.Frecuencia) / Registro_Modificar_1.Frecuencia
                End If
                'Actualizar_Estado_NumericUpDown_Dato_X()
                'Actualizar_Char_Registro_Modificar()
            End If

        End If
    End Sub

    Private Sub Chart_Registro_Parcial_MouseUp(sender As Object, e As MouseEventArgs) Handles Chart_Registro_Parcial.MouseUp
        If e.Button = MouseButtons.Left Then

            If CheckBox_ZOOM.CheckState Then
                Dim posX, posY As Double
                'Determina la posicion del mause en la grafica en pixeles
                posX = e.X
                posY = e.Y
                'Corige valores fuera de rango
                If posX <= 0 Then
                    posX = 0
                ElseIf posX >= Chart_Registro_Parcial.Width Then
                    posX = Chart_Registro_Parcial.Width - 1
                End If


                If posY <= 0 Then
                    posY = 0
                ElseIf posY >= Chart_Registro_Parcial.Height Then
                    posY = Chart_Registro_Parcial.Height - 1
                End If

                'Determina la posicion del mause en la grafica en respeto al eje X
                posX = Chart_Registro_Parcial.ChartAreas(0).AxisX.PixelPositionToValue(posX)
                If posX > NumericUpDown_Dato_1.Maximum Then
                    posX = NumericUpDown_Dato_1.Maximum - NumericUpDown_Dato_1.Increment
                End If
                If posX < NumericUpDown_Dato_1.Minimum Then
                    posX = NumericUpDown_Dato_1.Minimum + NumericUpDown_Dato_1.Increment
                End If
                'Determina la posicion del mause en la grafica en respeto al eje Y
                posY = Chart_Registro_Parcial.ChartAreas(0).AxisY.PixelPositionToValue(posY)

                Zoom.X_Final = posX
                Zoom.Y_Final = posY
                Zoom.Zoom_Activo = 0
                If Zoom.X_Final < Zoom.X_Inicio Then
                    Dim temp As Double = Zoom.X_Inicio
                    Zoom.X_Inicio = Zoom.X_Final
                    Zoom.X_Final = temp
                End If
                If Zoom.Y_Final < Zoom.Y_Inicio Then
                    Dim temp As Double = Zoom.Y_Inicio
                    Zoom.Y_Inicio = Zoom.Y_Final
                    Zoom.Y_Final = temp
                End If

                'If CheckBox_Cuadricula.Checked Then
                '    Actualizar_Cuadricula()
                'Else

                'Eliminar Cuadro de ampliacion  
                '             1 ->
                '    o-------------------o
                '  	 |                   | 
                ' ^ 4|                   |2 
                ' |	 |                   | 
                '    o-------------------o
                '            <-3

                Chart_Registro_Parcial.Series.RemoveAt(Chart_Registro_Parcial.Series.IndexOf("Cuadro_Ampliacion_1"))
                Chart_Registro_Parcial.Series.RemoveAt(Chart_Registro_Parcial.Series.IndexOf("Cuadro_Ampliacion_2"))
                Chart_Registro_Parcial.Series.RemoveAt(Chart_Registro_Parcial.Series.IndexOf("Cuadro_Ampliacion_3"))
                Chart_Registro_Parcial.Series.RemoveAt(Chart_Registro_Parcial.Series.IndexOf("Cuadro_Ampliacion_4"))
                Actualizar_Char_Registro_Modificar()
            Else
                If Modificar_Puntos <> 0 Then
                    Dim posX As Double
                    'Determina la posicion del mause en la grafica en pixeles
                    posX = e.X
                    If posX <= 0 Then
                        posX = 0
                    ElseIf posX >= Chart_Registro_Parcial.Width Then
                        posX = Chart_Registro_Parcial.Width - 2
                    End If
                    'Determina la posicion del mause en la grafica en respeto al eje X
                    posX = Chart_Registro_Parcial.ChartAreas(0).AxisX.PixelPositionToValue(posX)
                    If posX > NumericUpDown_Dato_1.Maximum Then
                        posX = NumericUpDown_Dato_1.Maximum - NumericUpDown_Dato_1.Increment
                    End If
                    If posX < NumericUpDown_Dato_1.Minimum Then
                        posX = NumericUpDown_Dato_1.Minimum + NumericUpDown_Dato_1.Increment
                    End If
                    'Actualizo NumericUpDown_Dato_x ajustando la tasa de cambio a la frecuencia 
                    If Modificar_Puntos = 1 Then
                        NumericUpDown_Dato_1.Value = Math.Round(posX * Registro_Modificar_1.Frecuencia) / Registro_Modificar_1.Frecuencia
                    ElseIf Modificar_Puntos = 2 Then
                        NumericUpDown_Dato_2.Value = Math.Round(posX * Registro_Modificar_1.Frecuencia) / Registro_Modificar_1.Frecuencia
                    ElseIf Modificar_Puntos = 3 Then
                        NumericUpDown_Dato_3.Value = Math.Round(posX * Registro_Modificar_1.Frecuencia) / Registro_Modificar_1.Frecuencia
                    ElseIf Modificar_Puntos = 4 Then
                        NumericUpDown_Dato_4.Value = Math.Round(posX * Registro_Modificar_1.Frecuencia) / Registro_Modificar_1.Frecuencia
                    ElseIf Modificar_Puntos = 5 Then
                        NumericUpDown_Dato_5.Value = Math.Round(posX * Registro_Modificar_1.Frecuencia) / Registro_Modificar_1.Frecuencia
                    End If
                    'Actualizar_Char_Registro_Modificar()
                    'Actualizar_Estado_NumericUpDown_Dato_X()
                End If
                Modificar_Puntos = 0
            End If
        End If
    End Sub

    Private Sub Reset_Zoom_Click(sender As Object, e As EventArgs) Handles Button_Reset_Zoom.Click
        'Pone la grafica de busqueda con los valores iniciales
        Zoom.X_Inicio = Registro_Modificar_1.Intervalo_Min_X
        Zoom.X_Final = Registro_Modificar_1.Intervalo_Max_X
        Zoom.Y_Inicio = Registro_Modificar_1.Intervalo_Min_Y
        Zoom.Y_Final = Registro_Modificar_1.Intervalo_Max_Y
        Actualizar_Char_Registro_Modificar()
    End Sub

    Private Sub NumericUpDown_Dato_1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_Dato_1.ValueChanged
        Actualizar_Estado_NumericUpDown_Dato_X()
        Actualizar_Char_Registro_Modificar()
    End Sub

    Private Sub NumericUpDown_Dato_2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_Dato_2.ValueChanged
        Actualizar_Estado_NumericUpDown_Dato_X()
        Actualizar_Char_Registro_Modificar()
    End Sub

    Private Sub NumericUpDown_Dato_3_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_Dato_3.ValueChanged
        Actualizar_Estado_NumericUpDown_Dato_X()
        Actualizar_Char_Registro_Modificar()
    End Sub

    Private Sub NumericUpDown_Dato_4_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_Dato_4.ValueChanged
        Actualizar_Estado_NumericUpDown_Dato_X()
        Actualizar_Char_Registro_Modificar()
    End Sub

    Private Sub NumericUpDown_Dato_5_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_Dato_5.ValueChanged
        Actualizar_Estado_NumericUpDown_Dato_X()
        Actualizar_Char_Registro_Modificar()
    End Sub

    Private Sub Button_Actualizar_Click(sender As Object, e As EventArgs) Handles Button_Actualizar.Click
        'Verifico si se modifica una Onda o se agrega
        If Registro_Modificar_1.Accion_Modificar Then
            If Registro_Modificar_1.Tipo_Onda = Onda_QRS Then
                'Verifico que los puntos Q_i,Q,R,S,J siguna en ese orden
                If NumericUpDown_Dato_1.Value < NumericUpDown_Dato_2.Value Then
                    If NumericUpDown_Dato_2.Value < NumericUpDown_Dato_3.Value Then
                        If NumericUpDown_Dato_3.Value < NumericUpDown_Dato_4.Value Then
                            If NumericUpDown_Dato_4.Value < NumericUpDown_Dato_5.Value Then
                                'Mofico el dato
                                UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(1, Registro_Modificar_1.Ubicacion_Tabla_Referencia).Value = NumericUpDown_Dato_1.Value
                                UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(2, Registro_Modificar_1.Ubicacion_Tabla_Referencia).Value = NumericUpDown_Dato_2.Value
                                UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(3, Registro_Modificar_1.Ubicacion_Tabla_Referencia).Value = NumericUpDown_Dato_3.Value
                                UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(4, Registro_Modificar_1.Ubicacion_Tabla_Referencia).Value = NumericUpDown_Dato_4.Value
                                UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(5, Registro_Modificar_1.Ubicacion_Tabla_Referencia).Value = NumericUpDown_Dato_5.Value
                                UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(6, Registro_Modificar_1.Ubicacion_Tabla_Referencia).Value = ComboBox_Tipo_Onda_Modificar.Text
                                UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar.Rows(Registro_Modificar_1.Ubicacion_Tabla_Referencia).DefaultCellStyle.BackColor = Color.Yellow
                                Me.Close()
                            End If
                        End If
                    End If
                End If
            End If
        Else
            If Registro_Modificar_1.Tipo_Onda = Onda_QRS Then
                'Verifico que los puntos Q_i,Q,R,S,J siguna en ese orden
                If NumericUpDown_Dato_1.Value < NumericUpDown_Dato_2.Value Then
                    If NumericUpDown_Dato_2.Value < NumericUpDown_Dato_3.Value Then
                        If NumericUpDown_Dato_3.Value < NumericUpDown_Dato_4.Value Then
                            If NumericUpDown_Dato_4.Value < NumericUpDown_Dato_5.Value Then
                                'Agrego el nuevo el dato
                                Dim Temp_datos(5) As Double
                                Dim Tabla As DataTable = DirectCast(UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar.DataSource, DataTable)
                                Dim Temp_Row As DataRow = Tabla.NewRow()
                                Dim Pocision_DataGridView As Int32
                                If NumericUpDown_Dato_1.Value < UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(5, Registro_Modificar_1.Ubicacion_Tabla_Referencia).Value Then
                                    Tabla.Rows.InsertAt(Temp_Row, Registro_Modificar_1.Ubicacion_Tabla_Referencia)
                                    Pocision_DataGridView = Registro_Modificar_1.Ubicacion_Tabla_Referencia
                                Else
                                    Tabla.Rows.InsertAt(Temp_Row, Registro_Modificar_1.Ubicacion_Tabla_Referencia + 1)
                                    Pocision_DataGridView = Registro_Modificar_1.Ubicacion_Tabla_Referencia + 1
                                End If
                                'actualizo el nuevo dato
                                UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar.DataSource = Tabla
                                'Compruebo si se esta anlizando la primera pocicion della tbala temporal
                                If Pocision_DataGridView < 1 Then
                                    If UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(0, Pocision_DataGridView + 1).Value < 1 Then
                                        UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(0, Pocision_DataGridView).Value = 1
                                    Else
                                        UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(0, Pocision_DataGridView).Value = UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(0, Pocision_DataGridView + 1).Value
                                    End If
                                ElseIf Pocision_DataGridView >= UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar.Rows.Count - 2 Then
                                    'Compruebo si se esta anlizando la ultima pocicion della tbala temporal
                                    UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(0, Pocision_DataGridView).Value = UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(0, Pocision_DataGridView - 1).Value
                                Else
                                    UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(0, Pocision_DataGridView).Value = UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(0, Pocision_DataGridView + 1).Value
                                End If
                                UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(1, Pocision_DataGridView).Value = NumericUpDown_Dato_1.Value
                                UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(2, Pocision_DataGridView).Value = NumericUpDown_Dato_2.Value
                                UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(3, Pocision_DataGridView).Value = NumericUpDown_Dato_3.Value
                                UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(4, Pocision_DataGridView).Value = NumericUpDown_Dato_4.Value
                                UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(5, Pocision_DataGridView).Value = NumericUpDown_Dato_5.Value
                                UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(6, Pocision_DataGridView).Value = ComboBox_Tipo_Onda_Modificar.Text
                                'Modificao el color de la fila para remarcar que se agrega un nuevo dato 
                                UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar.Rows(Pocision_DataGridView).DefaultCellStyle.BackColor = Color.Green
                                'No se actaulizo el indice por que se demora mucho el procedimiento segun el seiguiente algoritmo
                                'For Index = 0 To UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar.Rows.Count - 1
                                '    UserControl_Modulo_Graficar_Invocador.DataGridView_Registro_Modificar(0, Index).Value = Index + 1
                                'Next
                                Me.Close()
                            End If
                        End If
                    End If
                End If
            End If

        End If


    End Sub
    Private Sub Button_Principal_MouseEnter(sender As Object, e As EventArgs) Handles Button_Actualizar.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde_Cambio
    End Sub

    Private Sub Button_Principal_MouseLeave(sender As Object, e As EventArgs) Handles Button_Actualizar.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Reinciar datos de los NumericUpDown_Dato_x
        NumericUpDown_Dato_1.Value = Respaldo_Puntos.Dato_1
        NumericUpDown_Dato_2.Value = Respaldo_Puntos.Dato_2
        NumericUpDown_Dato_3.Value = Respaldo_Puntos.Dato_3
        If Registro_Modificar_1.Tipo_Onda = Onda_QRS Then
            NumericUpDown_Dato_4.Value = Respaldo_Puntos.Dato_4
            NumericUpDown_Dato_5.Value = Respaldo_Puntos.Dato_5
        End If
        'Pone la grafica de busqueda con los valores iniciales
        Zoom.X_Inicio = Registro_Modificar_1.Intervalo_Min_X
        Zoom.X_Final = Registro_Modificar_1.Intervalo_Max_X
        Zoom.Y_Inicio = Registro_Modificar_1.Intervalo_Min_Y
        Zoom.Y_Final = Registro_Modificar_1.Intervalo_Max_Y
        Actualizar_Char_Registro_Modificar()
        Actualizar_Estado_NumericUpDown_Dato_X()
    End Sub


End Class