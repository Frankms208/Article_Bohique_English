Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Windows.Forms.DataVisualization.Charting

Public Class UserControl_Modulo_Graficar
    Public Bandera_Anclaje As Int16 = 0 'Establec a que for esta anclado el modulo 0-> Form_Principla, 1-> Form_Contenedor
    Public DataGridView_Registro_Valor_Min As Int64 = 0
    Public DataGridView_Registro_Valor_Max As Int64 = 0

    'Public Modulo_Grafico_General As UserControl_Modulo_Graficar = Me

    Public Structure Registro_Zoom
        Public X_Inicio As Double
        Public X_Final As Double
        Public Y_Inicio As Double
        Public Y_Final As Double

        Public Zoom_Activo As Double

        Public Y_Bloqueo_Ventana As Double
        Public X_Bloqueo_Ventana As Double
    End Structure
    Public Paleta_Colores(,,) As Integer = {
                                                {{249, 235, 234}, {253, 237, 236}, {245, 238, 248}, {244, 236, 247}, {234, 242, 248}, {235, 245, 251}, {232, 248, 245}, {232, 246, 243}, {233, 247, 239}, {234, 250, 241}, {254, 249, 231}, {254, 245, 231}, {253, 242, 233}, {251, 238, 230}, {253, 254, 254}, {248, 249, 249}, {244, 246, 246}, {242, 244, 244}, {235, 237, 239}, {234, 236, 238}},
                                                {{242, 215, 213}, {250, 219, 216}, {235, 222, 240}, {232, 218, 239}, {212, 230, 241}, {214, 234, 248}, {209, 242, 235}, {208, 236, 231}, {212, 239, 223}, {213, 245, 227}, {252, 243, 207}, {253, 235, 208}, {250, 229, 211}, {246, 221, 204}, {251, 252, 252}, {242, 243, 244}, {234, 237, 237}, {229, 232, 232}, {214, 219, 223}, {213, 216, 220}},
                                                {{230, 176, 170}, {245, 183, 177}, {215, 189, 226}, {210, 180, 222}, {169, 204, 227}, {174, 214, 241}, {163, 228, 215}, {162, 217, 206}, {169, 223, 191}, {171, 235, 198}, {249, 231, 159}, {250, 215, 160}, {245, 203, 167}, {237, 187, 153}, {247, 249, 249}, {229, 231, 233}, {213, 219, 219}, {204, 209, 209}, {174, 182, 191}, {171, 178, 185}},
                                                {{217, 136, 128}, {241, 148, 138}, {195, 155, 211}, {187, 143, 206}, {127, 179, 213}, {133, 193, 233}, {118, 215, 196}, {115, 198, 182}, {125, 206, 160}, {130, 224, 170}, {247, 220, 111}, {248, 196, 113}, {240, 178, 122}, {229, 152, 102}, {244, 246, 247}, {215, 219, 221}, {191, 201, 202}, {178, 186, 187}, {133, 146, 158}, {128, 139, 150}},
                                                {{205, 97, 85}, {236, 112, 99}, {175, 122, 197}, {165, 105, 189}, {84, 153, 199}, {93, 173, 226}, {72, 201, 176}, {69, 179, 157}, {82, 190, 128}, {88, 214, 141}, {244, 208, 63}, {245, 176, 65}, {235, 152, 78}, {220, 118, 51}, {240, 243, 244}, {202, 207, 210}, {170, 183, 184}, {153, 163, 164}, {93, 109, 126}, {86, 101, 115}},
                                                {{192, 57, 43}, {231, 76, 60}, {155, 89, 182}, {142, 68, 173}, {41, 128, 185}, {52, 152, 219}, {26, 188, 156}, {22, 160, 133}, {39, 174, 96}, {46, 204, 113}, {241, 196, 15}, {243, 156, 18}, {230, 126, 34}, {211, 84, 0}, {236, 240, 241}, {189, 195, 199}, {149, 165, 166}, {127, 140, 141}, {52, 73, 94}, {44, 62, 80}},
                                                {{169, 50, 38}, {203, 67, 53}, {136, 78, 160}, {125, 60, 152}, {36, 113, 163}, {46, 134, 193}, {23, 165, 137}, {19, 141, 117}, {34, 153, 84}, {40, 180, 99}, {212, 172, 13}, {214, 137, 16}, {202, 111, 30}, {186, 74, 0}, {208, 211, 212}, {166, 172, 175}, {131, 145, 146}, {112, 123, 124}, {46, 64, 83}, {39, 55, 70}},
                                                {{146, 43, 33}, {176, 58, 46}, {118, 68, 138}, {108, 52, 131}, {31, 97, 141}, {40, 116, 166}, {20, 143, 119}, {17, 122, 101}, {30, 132, 73}, {35, 155, 86}, {183, 149, 11}, {185, 119, 14}, {175, 96, 26}, {160, 64, 0}, {179, 182, 183}, {144, 148, 151}, {113, 125, 126}, {97, 106, 107}, {40, 55, 71}, {33, 47, 61}},
                                                {{123, 36, 28}, {148, 49, 38}, {99, 57, 116}, {91, 44, 111}, {26, 82, 118}, {33, 97, 140}, {17, 120, 100}, {14, 102, 85}, {25, 111, 61}, {29, 131, 72}, {154, 125, 10}, {156, 100, 12}, {147, 81, 22}, {135, 54, 0}, {151, 154, 154}, {121, 125, 127}, {95, 106, 106}, {81, 90, 90}, {33, 47, 60}, {28, 40, 51}},
                                                {{100, 30, 22}, {120, 40, 31}, {81, 46, 95}, {74, 35, 90}, {21, 67, 96}, {27, 79, 114}, {14, 98, 81}, {11, 83, 69}, {20, 90, 50}, {24, 106, 59}, {125, 102, 8}, {126, 81, 9}, {120, 66, 18}, {110, 44, 0}, {123, 125, 125}, {98, 101, 103}, {77, 86, 86}, {66, 73, 73}, {27, 38, 49}, {23, 32, 42}}}
    Public Function Color_Registro()
        Static Selecion_Color_Fila As Int16 = 1
        Static Selecion_Color_Columna As Int16 = 0

        Selecion_Color_Fila = Selecion_Color_Fila + 3
        Selecion_Color_Columna = Selecion_Color_Columna + 3
        If Selecion_Color_Fila > 13 Then
            Selecion_Color_Fila = 0
        End If
        If Selecion_Color_Columna > 9 Then
            Selecion_Color_Columna = 4
        End If


        Return Color.FromArgb(255, Paleta_Colores(Selecion_Color_Columna, Selecion_Color_Fila, 0), Paleta_Colores(Selecion_Color_Columna, Selecion_Color_Fila, 1), Paleta_Colores(Selecion_Color_Columna, Selecion_Color_Fila, 2))
    End Function

    Public Structure Datos_Grafica
        Public Max_Valor_X As Double
        Public Min_Valor_X As Double


        Public Max_Valor_Y As Double
        Public Min_Valor_Y As Double

    End Structure
    'Si Bandera_Cursores_Grafica_Parcial=0 no esta activo el movimiento de los cursores
    'Si Bandera_Cursores_Grafica_Parcial=1 esta activo el movimiento del minimo
    'Si Bandera_Cursores_Grafica_Parcial=2  esta activo el movimiento del max
    'Si Bandera_Cursores_Grafica_Parcial=3  esta activo el movimiento del max y el min simultaneo(Ventana bloqueda)
    Public Bandera_Cursores_Grafica_Parcial As Int16
    Public Series_Grafica As New Series
    Public Grafica_Total As Datos_Grafica
    'Control de los registros graficados 
    Public Registro_Parciales_Graficados As New List(Of Class_Estado_Registro.Registro_Parcial)

    Public Registro_Parciales_Graficados_Temporal As Class_Estado_Registro.Registro_Parcial
    'Estructura para controlar el Zomm
    Public Zoom As Registro_Zoom
    'Controla el despliegue de 
    Public Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1 As Boolean = False



    'Controla la cuadricula
    Public Sub Crear_Cuadricula()
        'Cuadricula vertical
        If Chart_Registro_Parcial.Series.Contains(Chart_Registro_Parcial.Series.FindByName("Cuadricula_Vertical")) Then
            'Si existe le limpia el registro(Una nueva serie) 
            Chart_Registro_Parcial.Series("Cuadricula_Vertical").Points.Clear()
        Else
            'Si  no existe gregar nuevo registro(Una nueva serie) 
            Chart_Registro_Parcial.Series.Add("Cuadricula_Vertical")
            'Especifica que es una serie lineal 
            Chart_Registro_Parcial.Series("Cuadricula_Vertical").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart_Registro_Parcial.Series("Cuadricula_Vertical").Color = Color.Maroon
            Chart_Registro_Parcial.Series("Cuadricula_Vertical").BorderWidth = 1
        End If

        If Chart_Registro_Parcial.Series.Contains(Chart_Registro_Parcial.Series.FindByName("Cuadricula_Vertical_Gruesa")) Then
            'Si existe le limpia el registro(Una nueva serie) 
            Chart_Registro_Parcial.Series("Cuadricula_Vertical_Gruesa").Points.Clear()


        Else
            'Si  no existe gregar nuevo registro(Una nueva serie) 
            Chart_Registro_Parcial.Series.Add("Cuadricula_Vertical_Gruesa")
            'Especifica que es una serie lineal 
            Chart_Registro_Parcial.Series("Cuadricula_Vertical_Gruesa").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart_Registro_Parcial.Series("Cuadricula_Vertical_Gruesa").Color = Color.Maroon
            Chart_Registro_Parcial.Series("Cuadricula_Vertical_Gruesa").BorderWidth = 2
        End If

        'Cuadricula Horizontal
        If Chart_Registro_Parcial.Series.Contains(Chart_Registro_Parcial.Series.FindByName("Cuadricula_Horizontal")) Then
            'Si existe le limpia el registro(Una nueva serie) 
            Chart_Registro_Parcial.Series("Cuadricula_Horizontal").Points.Clear()

        Else
            'Si  no existe gregar nuevo registro(Una nueva serie) 
            Chart_Registro_Parcial.Series.Add("Cuadricula_Horizontal")
            'Especifica que es una serie lineal 
            Chart_Registro_Parcial.Series("Cuadricula_Horizontal").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart_Registro_Parcial.Series("Cuadricula_Horizontal").Color = Color.Maroon
            Chart_Registro_Parcial.Series("Cuadricula_Horizontal").BorderWidth = 1
        End If

        If Chart_Registro_Parcial.Series.Contains(Chart_Registro_Parcial.Series.FindByName("Cuadricula_Horizontal_Gruesa")) Then
            'Si existe le limpia el registro(Una nueva serie) 
            Chart_Registro_Parcial.Series("Cuadricula_Horizontal_Gruesa").Points.Clear()
        Else
            'Si  no existe gregar nuevo registro(Una nueva serie) 
            Chart_Registro_Parcial.Series.Add("Cuadricula_Horizontal_Gruesa")
            'Especifica que es una serie lineal 
            Chart_Registro_Parcial.Series("Cuadricula_Horizontal_Gruesa").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart_Registro_Parcial.Series("Cuadricula_Horizontal_Gruesa").Color = Color.Maroon
            Chart_Registro_Parcial.Series("Cuadricula_Horizontal_Gruesa").BorderWidth = 2
        End If


    End Sub
    Public Sub Actualizar_Cuadricula()
        If (Chart_Registro_Parcial.ChartAreas(0).AxisX.Maximum - Chart_Registro_Parcial.ChartAreas(0).AxisX.Minimum) <= 10.1 Then

            Dim Intervalo_Vertical, Intervalo_Horizontal As Double
            Dim x(), y(), Intervalo_xy As Double
            'Identificar el interlineado de la cuadricula
            Select Case ComboBox_Cuadricula_ECG_Velocidad.SelectedIndex
                Case 0
                    Intervalo_Vertical = 0.02
                Case 1
                    Intervalo_Vertical = 0.04
                Case 2
                    Intervalo_Vertical = 0.06
                Case 3
                    Intervalo_Vertical = 0.08
                Case 4
                    Intervalo_Vertical = 0.16
                Case 5
                    Intervalo_Vertical = 0.32
                Case Else
                    Intervalo_Vertical = 0.04
            End Select
            Select Case ComboBox_Cuadricula_ECG_Ganancia.SelectedIndex
                Case 0
                    Intervalo_Horizontal = 0.4
                Case 1
                    Intervalo_Horizontal = 0.2
                Case 2
                    Intervalo_Horizontal = 0.1
                Case 3
                    Intervalo_Horizontal = 0.075
                Case 4
                    Intervalo_Horizontal = 0.05
                Case 5
                    Intervalo_Horizontal = 0.1 / 6
                Case Else
                    Intervalo_Horizontal = 0.1
            End Select
            Intervalo_xy = ((Chart_Registro_Parcial.ChartAreas(0).AxisY.Maximum - Chart_Registro_Parcial.ChartAreas(0).AxisY.Minimum) / Intervalo_Vertical) * 2
            If Intervalo_xy < 0 Then
                Intervalo_xy = 0
            End If
            Intervalo_xy = Math.Ceiling(Intervalo_xy)
            ReDim y(Intervalo_xy + 1)
            ReDim x(Intervalo_xy + 1)
            x(0) = Chart_Registro_Parcial.ChartAreas(0).AxisX.Minimum
            y(0) = Chart_Registro_Parcial.ChartAreas(0).AxisY.Minimum

            For Index = 1 To Intervalo_xy + 1
                If (Index Mod 4) = 1 Then
                    x(Index) = x(Index - 1)
                    y(Index) = y(Index - 1) + Intervalo_Vertical
                ElseIf (Index Mod 4) = 2 Then
                    x(Index) = Chart_Registro_Parcial.ChartAreas(0).AxisX.Maximum + 1
                    y(Index) = y(Index - 1)
                ElseIf (Index Mod 4) = 3 Then
                    x(Index) = x(Index - 1)
                    y(Index) = y(Index - 1) + Intervalo_Vertical
                Else
                    x(Index) = Chart_Registro_Parcial.ChartAreas(0).AxisX.Minimum - 1
                    y(Index) = y(Index - 1)
                End If
            Next Index
            'Adiciona los nuevos datos a la serie
            Chart_Registro_Parcial.Series("Cuadricula_Horizontal").Points.Clear()
            Chart_Registro_Parcial.Series("Cuadricula_Horizontal").Points.DataBindXY(x, y)


            Intervalo_xy = Intervalo_xy / 5
            Intervalo_Vertical = Intervalo_Vertical * 5
            If Intervalo_xy < 0 Then
                Intervalo_xy = 0
            End If
            Intervalo_xy = Math.Ceiling(Intervalo_xy)
            ReDim y(Intervalo_xy + 1)
            ReDim x(Intervalo_xy + 1)
            x(0) = Chart_Registro_Parcial.ChartAreas(0).AxisX.Minimum
            y(0) = Chart_Registro_Parcial.ChartAreas(0).AxisY.Minimum

            For Index = 1 To Intervalo_xy + 1
                If (Index Mod 4) = 1 Then
                    x(Index) = x(Index - 1)
                    y(Index) = y(Index - 1) + Intervalo_Vertical
                ElseIf (Index Mod 4) = 2 Then
                    x(Index) = Chart_Registro_Parcial.ChartAreas(0).AxisX.Maximum + 1
                    y(Index) = y(Index - 1)
                ElseIf (Index Mod 4) = 3 Then
                    x(Index) = x(Index - 1)
                    y(Index) = y(Index - 1) + Intervalo_Vertical
                Else
                    x(Index) = Chart_Registro_Parcial.ChartAreas(0).AxisX.Minimum - 1
                    y(Index) = y(Index - 1)
                End If
            Next Index
            'Adiciona los nuevos datos a la serie
            Chart_Registro_Parcial.Series("Cuadricula_Horizontal_Gruesa").Points.Clear()
            Chart_Registro_Parcial.Series("Cuadricula_Horizontal_Gruesa").Points.DataBindXY(x, y)


            Intervalo_xy = ((Chart_Registro_Parcial.ChartAreas(0).AxisX.Maximum - Chart_Registro_Parcial.ChartAreas(0).AxisX.Minimum) / Intervalo_Horizontal) * 2
            If Intervalo_xy < 0 Then
                Intervalo_xy = 0
            End If
            Intervalo_xy = Math.Ceiling(Intervalo_xy)
            ReDim y(Intervalo_xy + 1)
            ReDim x(Intervalo_xy + 1)
            x(0) = Chart_Registro_Parcial.ChartAreas(0).AxisX.Minimum
            y(0) = Chart_Registro_Parcial.ChartAreas(0).AxisY.Minimum

            For Index = 1 To Intervalo_xy + 1
                If (Index Mod 4) = 1 Then
                    y(Index) = y(Index - 1)
                    x(Index) = x(Index - 1) + Intervalo_Horizontal
                ElseIf (Index Mod 4) = 2 Then
                    y(Index) = Chart_Registro_Parcial.ChartAreas(0).AxisY.Maximum + 1
                    x(Index) = x(Index - 1)
                ElseIf (Index Mod 4) = 3 Then
                    y(Index) = y(Index - 1)
                    x(Index) = x(Index - 1) + Intervalo_Horizontal
                Else
                    y(Index) = Chart_Registro_Parcial.ChartAreas(0).AxisY.Minimum - 1
                    x(Index) = x(Index - 1)
                End If
            Next Index
            'Adiciona los nuevos datos a la serie
            Chart_Registro_Parcial.Series("Cuadricula_Vertical").Points.Clear()
            Chart_Registro_Parcial.Series("Cuadricula_Vertical").Points.DataBindXY(x, y)


            Intervalo_xy = Intervalo_xy / 5
            Intervalo_Horizontal = Intervalo_Horizontal * 5
            If Intervalo_xy < 0 Then
                Intervalo_xy = 0
            End If
            Intervalo_xy = Math.Ceiling(Intervalo_xy)
            ReDim y(Intervalo_xy + 1)
            ReDim x(Intervalo_xy + 1)
            x(0) = Chart_Registro_Parcial.ChartAreas(0).AxisX.Minimum
            y(0) = Chart_Registro_Parcial.ChartAreas(0).AxisY.Minimum
            For Index = 1 To Intervalo_xy + 1
                If (Index Mod 4) = 1 Then
                    y(Index) = y(Index - 1)
                    x(Index) = x(Index - 1) + Intervalo_Horizontal
                ElseIf (Index Mod 4) = 2 Then
                    y(Index) = Chart_Registro_Parcial.ChartAreas(0).AxisY.Maximum + 1
                    x(Index) = x(Index - 1)
                ElseIf (Index Mod 4) = 3 Then
                    y(Index) = y(Index - 1)
                    x(Index) = x(Index - 1) + Intervalo_Horizontal
                Else
                    y(Index) = Chart_Registro_Parcial.ChartAreas(0).AxisY.Minimum - 1
                    x(Index) = x(Index - 1)
                End If
            Next Index
            'Adiciona los nuevos datos a la serie
            Chart_Registro_Parcial.Series("Cuadricula_Vertical_Gruesa").Points.Clear()
            Chart_Registro_Parcial.Series("Cuadricula_Vertical_Gruesa").Points.DataBindXY(x, y)
        Else
            Chart_Registro_Parcial.Series("Cuadricula_Horizontal_Gruesa").Points.Clear()
            Chart_Registro_Parcial.Series("Cuadricula_Horizontal").Points.Clear()
            Chart_Registro_Parcial.Series("Cuadricula_Vertical_Gruesa").Points.Clear()
            Chart_Registro_Parcial.Series("Cuadricula_Vertical").Points.Clear()
        End If
    End Sub

    Public Sub Actualizar_Pocicion_DataGridView_Registro_Modificar()
        'Class_Funciones_Base_Datos encangar de selecionar los datos  que etsna en el intervalode TextBox_Registro_Parcial_Minimo y TextBox_Registro_Parcial_Maximo
        Dim Index_Primera_Fila As Int16 = DataGridView_Registro_Modificar.Rows.Count
        For Index1 = 0 To DataGridView_Registro_Modificar.Rows.Count - 2
            DataGridView_Registro_Modificar.Rows(Index1).Selected = False
        Next
        For Index1 = 0 To DataGridView_Registro_Modificar.Rows.Count - 2
            If DataGridView_Registro_Modificar(DataGridView_Registro_Modificar.Columns.Count - 2, Index1).Value > Convert.ToDouble(TextBox_Registro_Parcial_Minimo.Text) And DataGridView_Registro_Modificar(1, Index1).Value < Convert.ToDouble(TextBox_Registro_Parcial_Maximo.Text) And Index1 >= 0 Then
                Index_Primera_Fila = Index1
                Exit For
            End If
        Next
        If Index_Primera_Fila <> DataGridView_Registro_Modificar.Rows.Count Then
            For Index1 = Index_Primera_Fila To DataGridView_Registro_Modificar.Rows.Count - 2
                If DataGridView_Registro_Modificar(1, Index1).Value > Convert.ToDouble(TextBox_Registro_Parcial_Minimo.Text) And DataGridView_Registro_Modificar(DataGridView_Registro_Modificar.Columns.Count - 2, Index1).Value < Convert.ToDouble(TextBox_Registro_Parcial_Maximo.Text) Then
                    DataGridView_Registro_Modificar.Rows(Index1).Selected = True
                    'ElseIf DataGridView_Registro_Modificar(DataGridView_Registro_Modificar.Columns.Count - 2, Index1).Value > Convert.ToDouble(TextBox_Registro_Parcial_Maximo.Text) Then
                    '    Exit For
                End If
            Next
            If Index_Primera_Fila > 0 Then
                DataGridView_Registro_Modificar.FirstDisplayedScrollingRowIndex = Index_Primera_Fila - 1
            ElseIf Index_Primera_Fila = 0 Then
                DataGridView_Registro_Modificar.FirstDisplayedScrollingRowIndex = Index_Primera_Fila
            End If
        End If

    End Sub
    Public Sub Actualizar_Tabla_DataGridView_Registro_Modificar()
        '-------------------------------------------------------------------------------------------------------
        'Buscar Registro registro
        '-------------------------------------------------------------------------------------------------------
        'Registro_Tabla = Registro_Parciales_Graficados(Index).Nombre_Tabla
        'Registro_Columna = Registro_Parciales_Graficados(Index).Nombre_Columna
        'Registro_Frecuencia = Registro_Parciales_Graficados(Index).Frecuencia
        'Color = Registro_Parciales_Graficados(Index).Color
        Dim Coneccion_Base_Datos As New SqlConnection
        Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()

        For Index = 0 To (Registro_Parciales_Graficados.Count - 1)
            If Registro_Parciales_Graficados(Index).Nombre_Tabla + "___" + Registro_Parciales_Graficados(Index).Nombre_Columna = ComboBox_Registro_Modificar.Text Then

                Dim Registro_Tabla As String
                Dim Registro_Columna As String
                Dim Registro_Frecuencia As Double
                Dim Cantidad_Maxima_Datos As String = Convert.ToString(Registro_Parciales_Graficados(Index).Cantidad_Maxima_Datos)
                Registro_Tabla = Registro_Parciales_Graficados(Index).Nombre_Tabla
                Registro_Columna = Registro_Parciales_Graficados(Index).Nombre_Columna
                Registro_Frecuencia = Registro_Parciales_Graficados(Index).Frecuencia
                Dim Coneccion_Registro As New SqlConnection
                Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Registro_Parciales_Graficados(Index).Usuario, Registro_Parciales_Graficados(Index).Paciente, Registro_Parciales_Graficados(Index).Fecha_Registro, Registro_Parciales_Graficados(Index).Nombre_Columna)

                'DataGridView_Registro_Modificar.Rows.Clear()
                DataGridView_Registro_Modificar.DataSource = Nothing
                DataGridView_Registro_Modificar.Refresh()
                If (TabControlEX_Selecion_Ondas_Intervalos.TabPages(TabControlEX_Selecion_Ondas_Intervalos.SelectedIndex).Name = "TabPageEX_Ondas") Then
                    Dim Tabla_Valor_Min As Double = Convert.ToDouble(TextBox_Onda_Tabla_Min.Text)
                    Dim Tabla_Valor_Max As Double = Convert.ToDouble(TextBox_Onda_Tabla_Max.Text)

                    If RadioButton_QRS.Checked And Class_Funciones_Base_Datos.Registro_Existe(Coneccion_Registro, Registro_Tabla + "___Complejo_QRS") Then
                        Dim Datos_Lectura_Registro_QRS, Datos_Lectura_Puntero As DataSet
                        Dim Tabla_Datos As New DataTable()
                        Dim Puntero As Int64 = 1
                        Dim Puntero_Qi As Double
                        Dim Puntero_Q As Double
                        Dim Puntero_R As Double
                        Dim Puntero_S As Double
                        Dim Puntero_J As Double
                        Dim Tipo_QRS As String = "Sin_QRS"
                        Tabla_Datos.Columns.Add(New DataColumn("0", GetType(System.Int32)))
                        Tabla_Datos.Columns.Add(New DataColumn("Q_i", GetType(System.Double)))
                        Tabla_Datos.Columns.Add(New DataColumn("Q", GetType(System.Double)))
                        Tabla_Datos.Columns.Add(New DataColumn("R", GetType(System.Double)))
                        Tabla_Datos.Columns.Add(New DataColumn("S", GetType(System.Double)))
                        Tabla_Datos.Columns.Add(New DataColumn("J", GetType(System.Double)))
                        Tabla_Datos.Columns.Add(New DataColumn("Type_QRS", GetType(System.String)))

                        Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registros_Consultar_Tabla_Completa(Coneccion_Registro, Registro_Tabla + "___Complejo_QRS", "Q_i", "J", Convert.ToString(Tabla_Valor_Min * Registro_Frecuencia), Convert.ToString(Tabla_Valor_Max * Registro_Frecuencia))
                        For Index1 = 0 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count - 1
                            Puntero = Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(0)
                            Puntero_Qi = CType(Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(1) / Registro_Frecuencia, Double)
                            Puntero_Q = CType(Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(2) / Registro_Frecuencia, Double)
                            Puntero_R = CType(Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(3) / Registro_Frecuencia, Double)
                            Puntero_S = CType(Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(4) / Registro_Frecuencia, Double)
                            Puntero_J = CType(Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(5) / Registro_Frecuencia, Double)
                            If Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(6) = 0 Then
                                Tipo_QRS = "Sin_QRS"
                            ElseIf Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(6) = 1 Then
                                Tipo_QRS = "Qr"
                            ElseIf Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(6) = 2 Then
                                Tipo_QRS = "qR"
                            ElseIf Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(6) = 3 Then
                                Tipo_QRS = "Qrs"
                            ElseIf Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(6) = 4 Then
                                Tipo_QRS = "qRs"
                            ElseIf Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(6) = 5 Then
                                Tipo_QRS = "R"
                            ElseIf Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(6) = 6 Then
                                Tipo_QRS = "Rs"
                            ElseIf Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(6) = 7 Then
                                Tipo_QRS = "QS"
                            ElseIf Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(6) = 8 Then
                                Tipo_QRS = "Qr_E"
                            ElseIf Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(6) = 9 Then
                                Tipo_QRS = "Qrs_E"
                            ElseIf Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(6) = 10 Then
                                Tipo_QRS = "qRs_E"
                            ElseIf Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(6) = 11 Then
                                Tipo_QRS = "RS_E"
                            End If

                            Tabla_Datos.Rows.Add(Puntero, Puntero_Qi, Puntero_Q, Puntero_R, Puntero_S, Puntero_J, Tipo_QRS)
                        Next
                        DataGridView_Registro_Modificar.DataSource = Tabla_Datos

                        Actualizar_Pocicion_DataGridView_Registro_Modificar()
                        Panel_Color_Registro_Modificar.BackColor = Registro_Parciales_Graficados(Index).Color
                    End If
                ElseIf (TabControlEX_Selecion_Ondas_Intervalos.TabPages(TabControlEX_Selecion_Ondas_Intervalos.SelectedIndex).Name = "TabPageEX_Intervalos") Then
                    Dim Tabla_Valor_Min As Double = Convert.ToDouble(TextBox_Intervalo_Tabla_Min.Text)
                    Dim Tabla_Valor_Max As Double = Convert.ToDouble(TextBox_Intervalo_Tabla_Max.Text)

                    If RadioButton_R_R.Checked And Class_Funciones_Base_Datos.Registro_Existe(Coneccion_Registro, Registro_Tabla + "___Intervalo_R_R") Then
                        Dim Datos_Lectura_Registro_QRS, Datos_Lectura_Puntero As DataSet
                        Dim Tabla_Datos As New DataTable()
                        Dim Puntero As Int64 = 1
                        Dim Inicio_R_R As Double
                        Dim Final_R_R As Double
                        Dim Duracion_R_R As Double
                        Tabla_Datos.Columns.Add(New DataColumn("0", GetType(System.Int32)))
                        Tabla_Datos.Columns.Add(New DataColumn("Start R_R", GetType(System.Double)))
                        Tabla_Datos.Columns.Add(New DataColumn("End R_R", GetType(System.Double)))
                        Tabla_Datos.Columns.Add(New DataColumn("Duration R_R", GetType(System.Double)))

                        Datos_Lectura_Registro_QRS = Class_Funciones_Base_Datos.Registros_Consultar_Tabla_Completa(Coneccion_Registro, Registro_Tabla + "___Intervalo_R_R", "Inicio_R_R", "Final_R_R", Convert.ToString(Tabla_Valor_Min * Registro_Frecuencia), Convert.ToString(Tabla_Valor_Max * Registro_Frecuencia))
                        For Index1 = 0 To Datos_Lectura_Registro_QRS.Tables(0).Rows.Count - 1
                            Puntero = Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(0)
                            Inicio_R_R = CType(Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(1) / Registro_Frecuencia, Double)
                            Final_R_R = CType(Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(2) / Registro_Frecuencia, Double)
                            Duracion_R_R = CType(Datos_Lectura_Registro_QRS.Tables(0).Rows(Index1)(3) / Registro_Frecuencia, Double)
                            Tabla_Datos.Rows.Add(Puntero, Inicio_R_R, Final_R_R, Duracion_R_R)
                        Next
                        DataGridView_Registro_Modificar.DataSource = Tabla_Datos

                        Actualizar_Pocicion_DataGridView_Registro_Modificar()
                        Panel_Color_Registro_Modificar.BackColor = Registro_Parciales_Graficados(Index).Color
                    End If

                End If
            End If
        Next
        If DataGridView_Registro_Modificar.Columns.Count > 0 Then
            DataGridView_Registro_Valor_Min = DataGridView_Registro_Modificar(0, 0).Value
            DataGridView_Registro_Valor_Max = DataGridView_Registro_Modificar(0, DataGridView_Registro_Modificar.Rows.Count - 2).Value
        End If
    End Sub
    Public Sub Actualizar_Registro_Parcial()

        'Determina si hay regsitros para graficar
        If Registro_Parciales_Graficados.Count > 0 Then
            'Habre la conexion
            Dim Coneccion_Base_Datos As New SqlConnection
            Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()

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
            Dim Intervalo_Max_X As Double = Convert.ToDouble(TextBox_Registro_Parcial_Maximo.Text)
            Dim Intervalo_Min_X As Double = Convert.ToDouble(TextBox_Registro_Parcial_Minimo.Text)

            'Variables para establecer la distancia en el eje x entre dos puntos
            Dim Paso_Registro As Int64

            'Establece el registro que se esta garficando
            Dim Registros_Selecionados As String = ""

            'Elimina todos los Registros en le Chart_Registro_Parcial
            Chart_Registro_Parcial.Series.Clear()
            'Recorrer todos los Registros existentes 6
            For Index = 0 To (Registro_Parciales_Graficados.Count - 1)
                'Se comprueba si el registro esta bloqueado
                If Form_Principal.Estado_Registros.Consultar_Registro_Bloqueado(Registro_Parciales_Graficados(Index).Nombre_Tabla) = False Then
                    '-------------------------------------------------------------------------------------------------------
                    'Graficar registro
                    '-------------------------------------------------------------------------------------------------------
                    Registro_Tabla = Registro_Parciales_Graficados(Index).Nombre_Tabla
                    Registro_Columna = Registro_Parciales_Graficados(Index).Nombre_Columna
                    Registro_Frecuencia = Registro_Parciales_Graficados(Index).Frecuencia
                    Color = Registro_Parciales_Graficados(Index).Color
                    'Establecer el valor de Paso_Registro (distancia en el eje x entre dos puntos)
                    Paso_Registro = Math.Floor(Registro_Frecuencia * (Intervalo_Max_X - Intervalo_Min_X) / (Grafica_Cantida_Datos_Max + 1))
                    If Paso_Registro < 1 Then
                        Paso_Registro = 1
                    End If
                    'Obtencion de los  valores de os Registros 
                    Dim Coneccion_Registro As New SqlConnection
                    Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Registro_Parciales_Graficados(Index).Usuario, Registro_Parciales_Graficados(Index).Paciente, Registro_Parciales_Graficados(Index).Fecha_Registro, Registro_Parciales_Graficados(Index).Nombre_Columna)

                    Dim Datos As New DataSet
                    Datos = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Registro_Tabla, Registro_Columna, Paso_Registro, Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                    'Redimencionar las variables
                    ReDim y(Datos.Tables(Registro_Tabla).Rows.Count - 1)
                    ReDim x(Datos.Tables(Registro_Tabla).Rows.Count - 1)

                    'Obtener los valores a graficar 
                    For Index1 = 0 To Datos.Tables(0).Rows.Count - 1
                        y(Index1) = Datos.Tables(Registro_Tabla).Rows(Index1)(1)
                        x(Index1) = (Datos.Tables(Registro_Tabla).Rows(Index1)(0)) / Registro_Frecuencia
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
                    If Registros_Selecionados.Count > 0 Then
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
                        Chart_Registro_Parcial.Series(Registros_Selecionados).BorderWidth = 3
                    End If


                    '-------------------------------------------------------------------------------------------------------
                    'Graficar trasnsformada Wavelet si esta activada y existe del complejo QRS
                    '-------------------------------------------------------------------------------------------------------
                    If CheckBox_Habilitar_Trasformada_Wavelet_QRS.Checked And My.Computer.FileSystem.FileExists(Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Registro_Tabla + "___" + Registro_Columna + "___Transformada_Wavelet_Complejo_QRS_Temp.mdf") Then
                        Dim Coneccion_Base_Datos_Transformada_Wavelet_QRS As New SqlConnection
                        Dim Tabla_Transformada_Wavelet_QRS As String = Registro_Tabla + "___" + Registro_Columna + "___Transformada_Wavelet_Complejo_QRS_Temp"
                        If Coneccion_Base_Datos_Transformada_Wavelet_QRS.State <> 0 Then
                            Coneccion_Base_Datos_Transformada_Wavelet_QRS.Close()
                        End If
                        Coneccion_Base_Datos_Transformada_Wavelet_QRS.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Tabla_Transformada_Wavelet_QRS)
                        If Class_Funciones_Base_Datos.Registro_Existe(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Tabla + "___" + Registro_Columna + "___Transformada_Wavelet_Complejo_QRS_Temp") Then
                            Dim Rojo, Verde, Azul As Integer
                            Rojo = Chart_Registro_Parcial.Series(Registros_Selecionados).Color.R
                            Verde = Chart_Registro_Parcial.Series(Registros_Selecionados).Color.G
                            Azul = Chart_Registro_Parcial.Series(Registros_Selecionados).Color.B

                            Dim Datos_Transformada_Wavelet As New DataSet
                            Datos_Transformada_Wavelet = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Tabla_Transformada_Wavelet_QRS, Registro_Columna, Paso_Registro, Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                            For Index1 = 0 To Datos_Transformada_Wavelet.Tables(0).Rows.Count - 1
                                y(Index1) = Datos_Transformada_Wavelet.Tables(0).Rows(Index1)(1)
                                x(Index1) = (Datos_Transformada_Wavelet.Tables(0).Rows(Index1)(0) * Paso_Registro) / Registro_Frecuencia
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
                            Registros_Selecionados = Registro_Columna + "___" + Registro_Tabla + "___Transformada_Wavelet_Complejo_QRS_Temp"
                            If Registros_Selecionados.Count > 0 Then
                                Chart_Registro_Parcial.Series.Add(Registros_Selecionados)
                                'Especifica El color 
                                Chart_Registro_Parcial.Series(Registros_Selecionados).Color = Color.Black

                                'Especifica que es una serie lineal 
                                If CheckBox_Estilo_Linea.Checked Then
                                    Chart_Registro_Parcial.Series(Registros_Selecionados).ChartType = DataVisualization.Charting.SeriesChartType.Line
                                Else
                                    Chart_Registro_Parcial.Series(Registros_Selecionados).ChartType = DataVisualization.Charting.SeriesChartType.Point
                                End If
                                'Adiciona los nuevos datos a la serie
                                Chart_Registro_Parcial.Series(Registros_Selecionados).Points.DataBindXY(x, y)
                                Chart_Registro_Parcial.Series(Registros_Selecionados).BorderWidth = 2
                            End If
                        End If
                    End If
                    '-------------------------------------------------------------------------------------------------------
                    'Graficar Señal Filtrada si esta activada y existe 
                    '-------------------------------------------------------------------------------------------------------
                    If CheckBox_Habilitar_Señal_Temporal_Filtrada.Checked And My.Computer.FileSystem.FileExists(Class_Funciones_Base_Datos.Direccion_Base_Datos + "\" + Registro_Tabla + "___" + Registro_Columna + "___Filtrado_Temp.mdf") Then
                        Dim Coneccion_Base_Datos_Filtrado_Temp As New SqlConnection
                        Dim Tabla_Filtro_Registro As String = Registro_Tabla + "___" + Registro_Columna + "___Filtrado_Temp"
                        If Coneccion_Base_Datos_Filtrado_Temp.State <> 0 Then
                            Coneccion_Base_Datos_Filtrado_Temp.Close()
                        End If

                        Coneccion_Base_Datos_Filtrado_Temp.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Tabla_Filtro_Registro)

                        If Coneccion_Base_Datos_Filtrado_Temp.State <> 0 Then
                            Coneccion_Base_Datos_Filtrado_Temp.Close()
                        End If
                        Coneccion_Base_Datos_Filtrado_Temp.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Tabla_Filtro_Registro)
                        If Class_Funciones_Base_Datos.Registro_Existe(Coneccion_Base_Datos_Filtrado_Temp, Registro_Tabla + "___" + Registro_Columna + "___Filtrado_Temp") Then
                            Dim Rojo, Verde, Azul As Integer
                            Rojo = Chart_Registro_Parcial.Series(Registros_Selecionados).Color.R
                            Verde = Chart_Registro_Parcial.Series(Registros_Selecionados).Color.G
                            Azul = Chart_Registro_Parcial.Series(Registros_Selecionados).Color.B

                            Dim Datos_Transformada_Wavelet As New DataSet
                            Datos_Transformada_Wavelet = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Base_Datos_Filtrado_Temp, Tabla_Filtro_Registro, Registro_Columna, Paso_Registro, Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                            For Index1 = 0 To Datos_Transformada_Wavelet.Tables(0).Rows.Count - 1
                                y(Index1) = Datos_Transformada_Wavelet.Tables(0).Rows(Index1)(1)
                                x(Index1) = (Datos_Transformada_Wavelet.Tables(0).Rows(Index1)(0) * Paso_Registro) / Registro_Frecuencia
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
                            Registros_Selecionados = Registro_Columna + "___" + Registro_Tabla + "___Filtrado_Temp"
                            If Registros_Selecionados.Count > 0 Then
                                Chart_Registro_Parcial.Series.Add(Registros_Selecionados)
                                'Especifica El color 
                                Chart_Registro_Parcial.Series(Registros_Selecionados).Color = Color.Red

                                'Especifica que es una serie lineal 
                                If CheckBox_Estilo_Linea.Checked Then
                                    Chart_Registro_Parcial.Series(Registros_Selecionados).ChartType = DataVisualization.Charting.SeriesChartType.Line
                                Else
                                    Chart_Registro_Parcial.Series(Registros_Selecionados).ChartType = DataVisualization.Charting.SeriesChartType.Point
                                End If
                                'Adiciona los nuevos datos a la serie
                                Chart_Registro_Parcial.Series(Registros_Selecionados).Points.DataBindXY(x, y)
                                Chart_Registro_Parcial.Series(Registros_Selecionados).BorderWidth = 2
                            End If
                        End If
                    End If

                    '-------------------------------------------------------------------------------------------------------
                    'Graficar Puntos Onda-P, COmplejo-QRS y Onda-T  si esta activada y existe 
                    '-------------------------------------------------------------------------------------------------------
                    'Obtengo los valoes de las posiciones de los complejos QRS en el registro  
                    Dim Datos_Registro As DataSet
                    'Datos_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion, Registro_Tabla, "Puntero, " + Registro_Columna, Paso_Registro, Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                    If CheckBox_Habilitar_Trasformada_Wavelet_QRS.Checked And Class_Funciones_Base_Datos.Registro_Existe(Coneccion_Registro, Registro_Tabla + "___Transformada_Wavelet_Temp") Then
                        Datos_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Registro_Tabla + "___Transformada_Wavelet_Temp", Registro_Columna, Paso_Registro, Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                    Else
                        Datos_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Registro_Tabla, Registro_Columna, Paso_Registro, Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                    End If

                    If (Intervalo_Max_X - Intervalo_Min_X) < 1000 Then
                        For Index_TreeView_0 = 0 To TreeView_Graficar.Nodes.Count - 1
                            'Graficar Onda P
                            If TreeView_Graficar.Nodes(Index_TreeView_0).Text = "P Wave" And Class_Funciones_Base_Datos.Registro_Existe(Coneccion_Registro, Registro_Tabla + "___Onda_P") And Class_Funciones_Base_Datos.Registro_Existe(Coneccion_Registro, Registro_Tabla) Then
                                'Creo los dataset
                                Dim Datos_Lectura_Registro_P_i_X As DataSet
                                Dim Datos_Lectura_Registro_P_X As DataSet
                                Dim Datos_Lectura_Registro_P_f_X As DataSet

                                Dim y_P_i(), y_P(), y_P_f() As Double
                                Dim x_P_i(), x_P(), x_P_f() As Double
                                'Obtengo las pociciones de los complejos QRS  

                                For Index_TreeView_1 = 0 To TreeView_Graficar.Nodes(Index_TreeView_0).Nodes.Count - 1
                                    If TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "P_i" And TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked = True Then
                                        'Creo las series
                                        Datos_Lectura_Registro_P_i_X = Class_Funciones_Base_Datos.Registros_Consultar_P_QRS_T(Coneccion_Registro, Registro_Tabla + "___Onda_P", "P_i", Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                                        ReDim y_P_i(Datos_Lectura_Registro_P_i_X.Tables(0).Rows.Count - 1)
                                        ReDim x_P_i(Datos_Lectura_Registro_P_i_X.Tables(0).Rows.Count - 1)
                                        Dim Rows_Index As Int32
                                        For i = 0 To Datos_Lectura_Registro_P_i_X.Tables(0).Rows.Count - 1
                                            Rows_Index = (Datos_Lectura_Registro_P_i_X.Tables(0).Rows(i)(1) - Datos_Registro.Tables(0).Rows(0)(0)) / Paso_Registro
                                            If Rows_Index > 0 And Rows_Index < Datos_Registro.Tables(0).Rows.Count Then
                                                y_P_i(i) = Datos_Registro.Tables(0).Rows(Rows_Index)(1)
                                                x_P_i(i) = Datos_Lectura_Registro_P_i_X.Tables(0).Rows(i)(1) / Registro_Frecuencia
                                            End If
                                        Next

                                        If x_P_i.Count > 0 Then
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Onda_P" + "P_i")
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_P" + "P_i").ChartType = DataVisualization.Charting.SeriesChartType.Point
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_P" + "P_i").Points.DataBindXY(x_P_i, y_P_i)
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_P" + "P_i").MarkerImage = Application.StartupPath + "\Imagenes\" + TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).SelectedImageKey
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_P" + "P_i").Color = Color.Red
                                        End If

                                    ElseIf TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "P" And TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked = True Then
                                        Datos_Lectura_Registro_P_X = Class_Funciones_Base_Datos.Registros_Consultar_P_QRS_T(Coneccion_Registro, Registro_Tabla + "___Onda_P", "P", Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                                        ReDim y_P(Datos_Lectura_Registro_P_X.Tables(0).Rows.Count - 1)
                                        ReDim x_P(Datos_Lectura_Registro_P_X.Tables(0).Rows.Count - 1)
                                        Dim Rows_Index As Int32
                                        For i = 0 To Datos_Lectura_Registro_P_X.Tables(0).Rows.Count - 1
                                            Rows_Index = (Datos_Lectura_Registro_P_X.Tables(0).Rows(i)(1) - Datos_Registro.Tables(0).Rows(0)(0)) / Paso_Registro
                                            If Rows_Index > 0 And Rows_Index < Datos_Registro.Tables(0).Rows.Count Then
                                                y_P(i) = Datos_Registro.Tables(0).Rows(Rows_Index)(1)
                                                x_P(i) = Datos_Lectura_Registro_P_X.Tables(0).Rows(i)(1) / Registro_Frecuencia
                                            End If
                                        Next
                                        If x_P.Count > 0 Then
                                            'Actualiza Series_Max Para que se vea al frente
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Onda_P" + "P")
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_P" + "P").ChartType = DataVisualization.Charting.SeriesChartType.Point
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_P" + "P").Points.DataBindXY(x_P, y_P)
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_P" + "P").MarkerImage = Application.StartupPath + "\Imagenes\" + TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).SelectedImageKey
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_P" + "P").Color = Color.Green
                                        End If

                                    ElseIf TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "P_f" And TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked = True Then
                                        Datos_Lectura_Registro_P_f_X = Class_Funciones_Base_Datos.Registros_Consultar_P_QRS_T(Coneccion_Registro, Registro_Tabla + "___Onda_P", "P_f", Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))

                                        ReDim y_P_f(Datos_Lectura_Registro_P_f_X.Tables(0).Rows.Count - 1)

                                        ReDim x_P_f(Datos_Lectura_Registro_P_f_X.Tables(0).Rows.Count - 1)
                                        Dim Rows_Index As Int32
                                        For i = 0 To Datos_Lectura_Registro_P_f_X.Tables(0).Rows.Count - 1
                                            Rows_Index = (Datos_Lectura_Registro_P_f_X.Tables(0).Rows(i)(1) - Datos_Registro.Tables(0).Rows(0)(0)) / Paso_Registro
                                            If Rows_Index > 0 And Rows_Index < Datos_Registro.Tables(0).Rows.Count Then
                                                y_P_f(i) = Datos_Registro.Tables(0).Rows(Rows_Index)(1)
                                                x_P_f(i) = Datos_Lectura_Registro_P_f_X.Tables(0).Rows(i)(1) / Registro_Frecuencia
                                            End If
                                        Next
                                        'Adiciono las series a la grafica
                                        'Actualiza Series_Max Para que se vea al frente
                                        If x_P_f.Count > 0 Then
                                            'Actualiza Series_Max Para que se vea al frente
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Onda_P" + "P_f")
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_P" + "P_f").ChartType = DataVisualization.Charting.SeriesChartType.Point
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_P" + "P_f").Points.DataBindXY(x_P_f, y_P_f)
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_P" + "P_f").MarkerImage = Application.StartupPath + "\Imagenes\" + TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).SelectedImageKey
                                            'Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_P" + "P").Color = Color.DarkRed
                                        End If

                                    End If
                                Next


                            End If

                            'Graficar Complejo QRS
                            If TreeView_Graficar.Nodes(Index_TreeView_0).Text = "QRS Complex" And Class_Funciones_Base_Datos.Registro_Existe(Coneccion_Registro, Registro_Tabla + "___Complejo_QRS") And Class_Funciones_Base_Datos.Registro_Existe(Coneccion_Registro, Registro_Tabla) Then
                                'Creo los dataset
                                Dim y_Q_i(), y_Q(), y_R(), y_S(), y_J() As Double
                                Dim x_Q_i(), x_Q(), x_R(), x_S(), x_J() As Double
                                'Obtengo las pociciones de los complejos QRS  

                                For Index_TreeView_1 = 0 To TreeView_Graficar.Nodes(Index_TreeView_0).Nodes.Count - 1
                                    If TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "Q_i" And TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked = True Then
                                        'Obtengo las pociciones de los complejos QRS  
                                        Dim Datos_Lectura_Registro_Q_i_X As DataSet
                                        Datos_Lectura_Registro_Q_i_X = Class_Funciones_Base_Datos.Registros_Consultar_P_QRS_T(Coneccion_Registro, Registro_Tabla + "___Complejo_QRS", "Q_i", Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                                        'Creo las series
                                        ReDim y_Q_i(Datos_Lectura_Registro_Q_i_X.Tables(0).Rows.Count - 1)

                                        ReDim x_Q_i(Datos_Lectura_Registro_Q_i_X.Tables(0).Rows.Count - 1)

                                        Dim Rows_Index As Int32
                                        For i = 0 To Datos_Lectura_Registro_Q_i_X.Tables(0).Rows.Count - 1
                                            Rows_Index = (Datos_Lectura_Registro_Q_i_X.Tables(0).Rows(i)(1) - Datos_Registro.Tables(0).Rows(0)(0)) / Paso_Registro
                                            If Rows_Index > 0 And Rows_Index < Datos_Registro.Tables(0).Rows.Count Then
                                                y_Q_i(i) = Datos_Registro.Tables(0).Rows(Rows_Index)(1)
                                                x_Q_i(i) = Datos_Lectura_Registro_Q_i_X.Tables(0).Rows(i)(1) / Registro_Frecuencia
                                            End If
                                        Next
                                        'Adiciono las series a la grafica
                                        'Actualiza Series_Max Para que se vea al frente
                                        If x_Q_i.Count > 0 Then
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q_i")
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q_i").ChartType = DataVisualization.Charting.SeriesChartType.Point
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q_i").Points.DataBindXY(x_Q_i, y_Q_i)
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q_i").MarkerImage = Application.StartupPath + "\Imagenes\" + TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).SelectedImageKey
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q_i").Color = Color.Blue
                                        End If
                                    ElseIf TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "Q" And TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked = True Then
                                        'Obtengo las pociciones de los complejos QRS  
                                        Dim Datos_Lectura_Registro_Q_X As DataSet
                                        Datos_Lectura_Registro_Q_X = Class_Funciones_Base_Datos.Registros_Consultar_P_QRS_T(Coneccion_Registro, Registro_Tabla + "___Complejo_QRS", "Q", Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                                        'Creo las series
                                        ReDim y_Q(Datos_Lectura_Registro_Q_X.Tables(0).Rows.Count - 1)

                                        ReDim x_Q(Datos_Lectura_Registro_Q_X.Tables(0).Rows.Count - 1)

                                        Dim Rows_Index As Int32
                                        For i = 0 To Datos_Lectura_Registro_Q_X.Tables(0).Rows.Count - 1
                                            Rows_Index = (Datos_Lectura_Registro_Q_X.Tables(0).Rows(i)(1) - Datos_Registro.Tables(0).Rows(0)(0)) / Paso_Registro
                                            If Rows_Index > 0 And Rows_Index < Datos_Registro.Tables(0).Rows.Count Then
                                                y_Q(i) = Datos_Registro.Tables(0).Rows(Rows_Index)(1)
                                                x_Q(i) = Datos_Lectura_Registro_Q_X.Tables(0).Rows(i)(1) / Registro_Frecuencia
                                            End If
                                        Next
                                        'Adiciono las series a la grafica
                                        'Actualiza Series_Max Para que se vea al frente
                                        If x_Q.Count > 0 Then
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q")
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q").ChartType = DataVisualization.Charting.SeriesChartType.Point
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q").Points.DataBindXY(x_Q, y_Q)
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q").MarkerImage = Application.StartupPath + "\Imagenes\" + TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).SelectedImageKey
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "Q").Color = Color.Blue
                                        End If
                                    ElseIf TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "R" And TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked = True Then
                                        'Obtengo las pociciones de los complejos QRS  
                                        Dim Datos_Lectura_Registro_R_X As DataSet
                                        Datos_Lectura_Registro_R_X = Class_Funciones_Base_Datos.Registros_Consultar_P_QRS_T(Coneccion_Registro, Registro_Tabla + "___Complejo_QRS", "R", Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                                        'Creo las series
                                        ReDim y_R(Datos_Lectura_Registro_R_X.Tables(0).Rows.Count - 1)

                                        ReDim x_R(Datos_Lectura_Registro_R_X.Tables(0).Rows.Count - 1)
                                        Dim Rows_Index As Int32
                                        For i = 0 To Datos_Lectura_Registro_R_X.Tables(0).Rows.Count - 1
                                            Rows_Index = (Datos_Lectura_Registro_R_X.Tables(0).Rows(i)(1) - Datos_Registro.Tables(0).Rows(0)(0)) / Paso_Registro
                                            If Rows_Index > 0 And Rows_Index < Datos_Registro.Tables(0).Rows.Count Then
                                                y_R(i) = Datos_Registro.Tables(0).Rows(Rows_Index)(1)
                                                x_R(i) = Datos_Lectura_Registro_R_X.Tables(0).Rows(i)(1) / Registro_Frecuencia
                                            End If
                                        Next
                                        'Adiciono las series a la grafica
                                        'Actualiza Series_Max Para que se vea al frente
                                        If x_R.Count > 0 Then
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "R")
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "R").ChartType = DataVisualization.Charting.SeriesChartType.Point
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "R").Points.DataBindXY(x_R, y_R)
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "R").MarkerImage = Application.StartupPath + "\Imagenes\" + TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).SelectedImageKey
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "R").Color = Color.Blue
                                        End If
                                    ElseIf TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "S" And TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked = True Then
                                        'Obtengo las pociciones de los complejos QRS  
                                        Dim Datos_Lectura_Registro_S_X As DataSet
                                        Datos_Lectura_Registro_S_X = Class_Funciones_Base_Datos.Registros_Consultar_P_QRS_T(Coneccion_Registro, Registro_Tabla + "___Complejo_QRS", "S", Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                                        'Creo las series
                                        ReDim y_S(Datos_Lectura_Registro_S_X.Tables(0).Rows.Count - 1)

                                        ReDim x_S(Datos_Lectura_Registro_S_X.Tables(0).Rows.Count - 1)

                                        Dim Rows_Index As Int32
                                        For i = 0 To Datos_Lectura_Registro_S_X.Tables(0).Rows.Count - 1
                                            Rows_Index = (Datos_Lectura_Registro_S_X.Tables(0).Rows(i)(1) - Datos_Registro.Tables(0).Rows(0)(0)) / Paso_Registro
                                            If Rows_Index > 0 And Rows_Index < Datos_Registro.Tables(0).Rows.Count Then
                                                y_S(i) = Datos_Registro.Tables(0).Rows(Rows_Index)(1)
                                                x_S(i) = Datos_Lectura_Registro_S_X.Tables(0).Rows(i)(1) / Registro_Frecuencia
                                            End If
                                        Next
                                        'Adiciono las series a la grafica
                                        'Actualiza Series_Max Para que se vea al frente
                                        If x_S.Count > 0 Then
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "S")
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "S").ChartType = DataVisualization.Charting.SeriesChartType.Point
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "S").Points.DataBindXY(x_S, y_S)
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "S").MarkerImage = Application.StartupPath + "\Imagenes\" + TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).SelectedImageKey
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "S").Color = Color.Blue
                                        End If
                                    ElseIf TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "J" And TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked = True Then
                                        'Obtengo las pociciones de los complejos QRS  
                                        Dim Datos_Lectura_Registro_J_X As DataSet
                                        Datos_Lectura_Registro_J_X = Class_Funciones_Base_Datos.Registros_Consultar_P_QRS_T(Coneccion_Registro, Registro_Tabla + "___Complejo_QRS", "J", Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                                        'Creo las series
                                        ReDim y_J(Datos_Lectura_Registro_J_X.Tables(0).Rows.Count - 1)

                                        ReDim x_J(Datos_Lectura_Registro_J_X.Tables(0).Rows.Count - 1)

                                        Dim Rows_Index As Int32
                                        For i = 0 To Datos_Lectura_Registro_J_X.Tables(0).Rows.Count - 1
                                            Rows_Index = (Datos_Lectura_Registro_J_X.Tables(0).Rows(i)(1) - Datos_Registro.Tables(0).Rows(0)(0)) / Paso_Registro
                                            If Rows_Index > 0 And Rows_Index < Datos_Registro.Tables(0).Rows.Count Then
                                                y_J(i) = Datos_Registro.Tables(0).Rows(Rows_Index)(1)
                                                x_J(i) = Datos_Lectura_Registro_J_X.Tables(0).Rows(i)(1) / Registro_Frecuencia
                                            End If
                                        Next
                                        'Adiciono las series a la grafica
                                        'Actualiza Series_Max Para que se vea al frente
                                        If x_J.Count > 0 Then
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "J")
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "J").ChartType = DataVisualization.Charting.SeriesChartType.Point
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "J").Points.DataBindXY(x_J, y_J)
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "J").MarkerImage = Application.StartupPath + "\Imagenes\" + TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).SelectedImageKey
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Complejo_QRS" + "J").Color = Color.Blue
                                        End If
                                    End If
                                Next


                            End If

                            'Graficar Onda T
                            If TreeView_Graficar.Nodes(Index_TreeView_0).Text = "T Wave" And Class_Funciones_Base_Datos.Registro_Existe(Coneccion_Registro, Registro_Tabla + "___Onda_T") And Class_Funciones_Base_Datos.Registro_Existe(Coneccion_Registro, Registro_Tabla) Then
                                'Creo los dataset

                                Dim Datos_Lectura_Registro_T_i_X As DataSet
                                Dim Datos_Lectura_Registro_T_X As DataSet
                                Dim Datos_Lectura_Registro_T_f_X As DataSet

                                Dim y_T_i(), y_T(), y_T_f() As Double
                                Dim x_T_i(), x_T(), x_T_f() As Double
                                'Obtengo las pociciones de los complejos QRS  

                                For Index_TreeView_1 = 0 To TreeView_Graficar.Nodes(Index_TreeView_0).Nodes.Count - 1
                                    If TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "T_i" And TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked = True Then
                                        'Creo las series
                                        Datos_Lectura_Registro_T_i_X = Class_Funciones_Base_Datos.Registros_Consultar_P_QRS_T(Coneccion_Registro, Registro_Tabla + "___Onda_T", "T_i", Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                                        ReDim y_T_i(Datos_Lectura_Registro_T_i_X.Tables(0).Rows.Count - 1)
                                        ReDim x_T_i(Datos_Lectura_Registro_T_i_X.Tables(0).Rows.Count - 1)

                                        Dim Rows_Index As Int32
                                        For i = 0 To Datos_Lectura_Registro_T_i_X.Tables(0).Rows.Count - 1
                                            Rows_Index = (Datos_Lectura_Registro_T_i_X.Tables(0).Rows(i)(1) - Datos_Registro.Tables(0).Rows(0)(0)) / Paso_Registro
                                            If Rows_Index > 0 And Rows_Index < Datos_Registro.Tables(0).Rows.Count Then
                                                y_T_i(i) = Datos_Registro.Tables(0).Rows(Rows_Index)(1)
                                                x_T_i(i) = Datos_Lectura_Registro_T_i_X.Tables(0).Rows(i)(1) / Registro_Frecuencia
                                            End If
                                        Next
                                        If x_T_i.Count > 0 Then
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Onda_T" + "T_i")
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_T" + "T_i").ChartType = DataVisualization.Charting.SeriesChartType.Point
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_T" + "T_i").Points.DataBindXY(x_T_i, y_T_i)
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_T" + "T_i").MarkerImage = Application.StartupPath + "\Imagenes\" + TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).SelectedImageKey
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_T" + "T_i").Color = Color.Red
                                        End If
                                    ElseIf TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "T" And TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked = True Then
                                        Datos_Lectura_Registro_T_X = Class_Funciones_Base_Datos.Registros_Consultar_P_QRS_T(Coneccion_Registro, Registro_Tabla + "___Onda_T", "T", Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                                        ReDim y_T(Datos_Lectura_Registro_T_X.Tables(0).Rows.Count - 1)
                                        ReDim x_T(Datos_Lectura_Registro_T_X.Tables(0).Rows.Count - 1)

                                        Dim Rows_Index As Int32
                                        For i = 0 To Datos_Lectura_Registro_T_X.Tables(0).Rows.Count - 1
                                            Rows_Index = (Datos_Lectura_Registro_T_X.Tables(0).Rows(i)(1) - Datos_Registro.Tables(0).Rows(0)(0)) / Paso_Registro
                                            If Rows_Index > 0 And Rows_Index < Datos_Registro.Tables(0).Rows.Count Then
                                                y_T(i) = Datos_Registro.Tables(0).Rows(Rows_Index)(1)
                                                x_T(i) = Datos_Lectura_Registro_T_X.Tables(0).Rows(i)(1) / Registro_Frecuencia
                                            End If
                                        Next
                                        If x_T.Count > 0 Then
                                            'Actualiza Series_Max Para que se vea al frente
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Onda_T" + "T")
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_T" + "T").ChartType = DataVisualization.Charting.SeriesChartType.Point
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_T" + "T").Points.DataBindXY(x_T, y_T)
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_T" + "T").MarkerImage = Application.StartupPath + "\Imagenes\" + TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).SelectedImageKey
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_T" + "T").Color = Color.Green
                                        End If
                                    ElseIf TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "T_f" And TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked = True Then
                                        Datos_Lectura_Registro_T_f_X = Class_Funciones_Base_Datos.Registros_Consultar_P_QRS_T(Coneccion_Registro, Registro_Tabla + "___Onda_T", "T_f", Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))

                                        ReDim y_T_f(Datos_Lectura_Registro_T_f_X.Tables(0).Rows.Count - 1)

                                        ReDim x_T_f(Datos_Lectura_Registro_T_f_X.Tables(0).Rows.Count - 1)
                                        Dim Rows_Index As Int32
                                        For i = 0 To Datos_Lectura_Registro_T_f_X.Tables(0).Rows.Count - 1
                                            Rows_Index = (Datos_Lectura_Registro_T_f_X.Tables(0).Rows(i)(1) - Datos_Registro.Tables(0).Rows(0)(0)) / Paso_Registro
                                            'Rows_Index = (Datos_Lectura_Registro_T_f_X.Tables(0).Rows(i)(1) - Datos_Registro.Tables(0).Rows(0)(1)) / Paso_Registro
                                            If Rows_Index > 0 And Rows_Index < Datos_Registro.Tables(0).Rows.Count Then
                                                y_T_f(i) = Datos_Registro.Tables(0).Rows(Rows_Index)(1)
                                                x_T_f(i) = Datos_Lectura_Registro_T_f_X.Tables(0).Rows(i)(1) / Registro_Frecuencia
                                            End If
                                        Next
                                        'Adiciono las series a la grafica
                                        'Actualiza Series_Max Para que se vea al frente

                                        'Actualiza Series_Max Para que se vea al frente
                                        If x_T_f.Count > 0 Then
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Onda_T" + "T_f")
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_T" + "T_f").ChartType = DataVisualization.Charting.SeriesChartType.Point
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_T" + "T_f").Points.DataBindXY(x_T_f, y_T_f)
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_T" + "T_f").MarkerImage = Application.StartupPath + "\Imagenes\" + TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).SelectedImageKey

                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Onda_T" + "T_f").Color = Color.DarkRed
                                        End If
                                    End If
                                Next


                            End If
                            'Graficar Intervalos
                            If TreeView_Graficar.Nodes(Index_TreeView_0).Text = "Intervals" Then
                                'If TreeView_Graficar.Nodes(Index_TreeView_0).Text = "Intervalos" And Class_Funciones_Base_Datos.Tabla_Existe(Coneccion, Registro_Tabla + "___" + Registro_Columna + "___Onda_T") And Class_Funciones_Base_Datos.Tabla_Existe(Coneccion, Registro_Tabla) Then

                                For Index_TreeView_1 = 0 To TreeView_Graficar.Nodes(Index_TreeView_0).Nodes.Count - 1
                                    'Intervalo R_R
                                    If TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "Intervalo R-R" And TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked = True And Class_Funciones_Base_Datos.Registro_Existe(Coneccion_Registro, Registro_Tabla + "___Intervalo_R_R") = True Then
                                        'Creo los dataset
                                        Dim Datos_Intervalos As DataSet
                                        Dim Index_Datos_Intervalos As Integer = 0
                                        Dim Rojo, Verde, Azul As Integer

                                        Datos_Intervalos = Class_Funciones_Base_Datos.Registros_Consultar_Intervalos(Coneccion_Registro, Registro_Tabla + "___Intervalo_R_R", "Inicio_R_R", " Final_R_R", Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                                        If Datos_Intervalos.Tables(0).Rows.Count > 0 Then
                                            'Edito laa series de los intervalos
                                            Rojo = Chart_Registro_Parcial.Series(Registros_Selecionados).Color.R
                                            Verde = Chart_Registro_Parcial.Series(Registros_Selecionados).Color.G
                                            Azul = Chart_Registro_Parcial.Series(Registros_Selecionados).Color.B
                                            'Crear las series
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_R_R_Inicio")
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_R_R_Final")

                                            For Index_Point = 0 To Chart_Registro_Parcial.Series(Registros_Selecionados).Points.Count - 1
                                                'Recorro la serie para obtner los puntos del intervalo
                                                If Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).XValue = Datos_Intervalos.Tables(0).Rows(Index_Datos_Intervalos)(1) / Registro_Frecuencia Then
                                                    Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_R_R_Inicio").Points.Add(Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point))
                                                End If
                                                If Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).XValue = Datos_Intervalos.Tables(0).Rows(Index_Datos_Intervalos)(2) / Registro_Frecuencia Then
                                                    Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_R_R_Final").Points.Add(Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point))
                                                End If

                                                If Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).XValue > Datos_Intervalos.Tables(0).Rows(Index_Datos_Intervalos)(1) / Registro_Frecuencia And Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).XValue < Datos_Intervalos.Tables(0).Rows(Index_Datos_Intervalos)(2) / Registro_Frecuencia Then
                                                    Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).BorderWidth = Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).BorderWidth + 2
                                                    Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).BorderWidth = Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).BorderWidth + 2
                                                    Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).Color = Color.FromArgb(100, Rojo, Verde, Azul)
                                                ElseIf Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).XValue >= Datos_Intervalos.Tables(0).Rows(Index_Datos_Intervalos)(2) / Registro_Frecuencia Then
                                                    Index_Datos_Intervalos = Index_Datos_Intervalos + 1
                                                End If


                                                If Index_Datos_Intervalos >= Datos_Intervalos.Tables(0).Rows.Count Then
                                                    Exit For
                                                End If
                                            Next


                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_R_R_Inicio").MarkerStyle = MarkerStyle.Star5
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_R_R_Inicio").MarkerSize = 15
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_R_R_Inicio").Color = Color.Black
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_R_R_Inicio").ChartType = DataVisualization.Charting.SeriesChartType.Point

                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_R_R_Final").MarkerStyle = MarkerStyle.Star5
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_R_R_Final").MarkerSize = 15
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_R_R_Final").Color = Color.Red
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_R_R_Final").ChartType = DataVisualization.Charting.SeriesChartType.Point
                                        End If

                                    End If

                                    'Intervalo P_R
                                    If TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "Intervalo P-R" And TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked = True And Class_Funciones_Base_Datos.Registro_Existe(Coneccion_Registro, Registro_Tabla + "___Intervalo_P_R") = True Then
                                        'Creo los dataset
                                        Dim Datos_Intervalos As DataSet
                                        Dim Index_Datos_Intervalos As Integer = 0
                                        Dim Rojo, Verde, Azul As Integer
                                        Datos_Intervalos = Class_Funciones_Base_Datos.Registros_Consultar_Intervalos(Coneccion_Registro, Registro_Tabla + "___Intervalo_P_R", "Inicio_P_R", " Final_P_R", Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                                        If Datos_Intervalos.Tables(0).Rows.Count > 0 Then
                                            'Edito laa series de los intervalos
                                            Rojo = Chart_Registro_Parcial.Series(Registros_Selecionados).Color.R
                                            Verde = Chart_Registro_Parcial.Series(Registros_Selecionados).Color.G
                                            Azul = Chart_Registro_Parcial.Series(Registros_Selecionados).Color.B
                                            'Crear las series
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_P_R_Inicio")
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_P_R_Final")

                                            For Index_Point = 0 To Chart_Registro_Parcial.Series(Registros_Selecionados).Points.Count - 1
                                                'Recorro la serie para obtner los puntos del intervalo
                                                If Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).XValue = Datos_Intervalos.Tables(0).Rows(Index_Datos_Intervalos)(1) / Registro_Frecuencia Then
                                                    Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_P_R_Inicio").Points.Add(Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point))
                                                End If
                                                If Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).XValue = Datos_Intervalos.Tables(0).Rows(Index_Datos_Intervalos)(2) / Registro_Frecuencia Then
                                                    Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_P_R_Final").Points.Add(Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point))
                                                End If

                                                If Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).XValue > Datos_Intervalos.Tables(0).Rows(Index_Datos_Intervalos)(1) / Registro_Frecuencia And Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).XValue < Datos_Intervalos.Tables(0).Rows(Index_Datos_Intervalos)(2) / Registro_Frecuencia Then
                                                    Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).BorderWidth = Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).BorderWidth + 2
                                                    Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).BorderWidth = Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).BorderWidth + 2
                                                    Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).Color = Color.FromArgb(100, Rojo, Verde, Azul)
                                                ElseIf Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).XValue >= Datos_Intervalos.Tables(0).Rows(Index_Datos_Intervalos)(2) / Registro_Frecuencia Then
                                                    Index_Datos_Intervalos = Index_Datos_Intervalos + 1
                                                End If


                                                If Index_Datos_Intervalos >= Datos_Intervalos.Tables(0).Rows.Count Then
                                                    Exit For
                                                End If
                                            Next

                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_P_R_Inicio").MarkerStyle = MarkerStyle.Star5
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_P_R_Inicio").MarkerSize = 15
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_P_R_Inicio").Color = Color.Black
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_P_R_Inicio").ChartType = DataVisualization.Charting.SeriesChartType.Point

                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_P_R_Final").MarkerStyle = MarkerStyle.Star5
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_P_R_Final").MarkerSize = 15
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_P_R_Final").Color = Color.Red
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_P_R_Final").ChartType = DataVisualization.Charting.SeriesChartType.Point
                                        End If

                                    End If
                                    'Intervalo Q_T
                                    If TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "Intervalo Q-T" And TreeView_Graficar.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked = True And Class_Funciones_Base_Datos.Registro_Existe(Coneccion_Registro, Registro_Tabla + "___Intervalo_Q_T") = True Then
                                        'Creo los dataset
                                        Dim Datos_Intervalos As DataSet
                                        Dim Index_Datos_Intervalos As Integer = 0
                                        Dim Rojo, Verde, Azul As Integer
                                        Datos_Intervalos = Class_Funciones_Base_Datos.Registros_Consultar_Intervalos(Coneccion_Registro, Registro_Tabla + "___Intervalo_Q_T", "Inicio_Q_T", " Final_Q_T", Convert.ToString(Math.Floor(Intervalo_Min_X * Registro_Frecuencia)), Convert.ToString(Math.Ceiling(Intervalo_Max_X * Registro_Frecuencia)))
                                        If Datos_Intervalos.Tables(0).Rows.Count > 0 Then
                                            'Edito laa series de los intervalos
                                            Rojo = Chart_Registro_Parcial.Series(Registros_Selecionados).Color.R
                                            Verde = Chart_Registro_Parcial.Series(Registros_Selecionados).Color.G
                                            Azul = Chart_Registro_Parcial.Series(Registros_Selecionados).Color.B
                                            'Crear las series
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_Q_T_Inicio")
                                            Chart_Registro_Parcial.Series.Add(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_Q_T_Final")

                                            For Index_Point = 0 To Chart_Registro_Parcial.Series(Registros_Selecionados).Points.Count - 1
                                                'Recorro la serie para obtner los puntos del intervalo
                                                If Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).XValue = Datos_Intervalos.Tables(0).Rows(Index_Datos_Intervalos)(1) / Registro_Frecuencia Then
                                                    Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_Q_T_Inicio").Points.Add(Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point))
                                                End If
                                                If Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).XValue = Datos_Intervalos.Tables(0).Rows(Index_Datos_Intervalos)(2) / Registro_Frecuencia Then
                                                    Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_Q_T_Final").Points.Add(Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point))
                                                End If

                                                If Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).XValue > Datos_Intervalos.Tables(0).Rows(Index_Datos_Intervalos)(1) / Registro_Frecuencia And Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).XValue < Datos_Intervalos.Tables(0).Rows(Index_Datos_Intervalos)(2) / Registro_Frecuencia Then
                                                    Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).BorderWidth = Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).BorderWidth + 2
                                                    Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).BorderWidth = Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).BorderWidth + 2
                                                    Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).Color = Color.FromArgb(100, Rojo, Verde, Azul)
                                                ElseIf Chart_Registro_Parcial.Series(Registros_Selecionados).Points(Index_Point).XValue >= Datos_Intervalos.Tables(0).Rows(Index_Datos_Intervalos)(2) / Registro_Frecuencia Then
                                                    Index_Datos_Intervalos = Index_Datos_Intervalos + 1
                                                End If


                                                If Index_Datos_Intervalos >= Datos_Intervalos.Tables(0).Rows.Count Then
                                                    Exit For
                                                End If
                                            Next


                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_Q_T_Inicio").MarkerStyle = MarkerStyle.Star5
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_Q_T_Inicio").MarkerSize = 15
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_Q_T_Inicio").Color = Color.Black
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_Q_T_Inicio").ChartType = DataVisualization.Charting.SeriesChartType.Point

                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_Q_T_Final").MarkerStyle = MarkerStyle.Star5
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_Q_T_Final").MarkerSize = 15
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_Q_T_Final").Color = Color.Red
                                            Chart_Registro_Parcial.Series(Registro_Tabla + "___" + Registro_Columna + "___Intervalo_Q_T_Final").ChartType = DataVisualization.Charting.SeriesChartType.Point
                                        End If

                                    End If

                                Next


                            End If

                        Next
                    End If
                Else
                    Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                    Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "Record " + Registro_Parciales_Graficados(Index).Nombre_Tabla, "is in use", "Record Error", 0)
                    'Registro_Parciales_Graficados.RemoveAt(Index)
                End If
            Next Index
            '-----------------------------------------------------------
            'Establecer los limites de la grafica
            '-----------------------------------------------------------
            If Min_Y >= Max_Y Then
                Max_Y = 1
                Min_Y = 0
            End If
            If Intervalo_Min_X >= Intervalo_Max_X Then
                Intervalo_Max_X = 1
                Intervalo_Min_X = 0
            End If
            'Establece los margenes de la grafica 
            If CheckBox_Bloquear_Ventana.Checked Then
                'If (Zoom.Y_Inicio = Zoom.Y_Final) Or (Zoom.X_Inicio = Zoom.X_Final) Then
                If (Zoom.X_Inicio = Zoom.X_Final) Then
                    Chart_Registro_Parcial.ChartAreas(0).AxisY.Minimum = Min_Y
                    Chart_Registro_Parcial.ChartAreas(0).AxisY.Maximum = Max_Y
                    Chart_Registro_Parcial.ChartAreas(0).AxisX.Minimum = Intervalo_Min_X
                    Chart_Registro_Parcial.ChartAreas(0).AxisX.Maximum = Intervalo_Max_X

                Else
                    Chart_Registro_Parcial.ChartAreas(0).AxisY.Minimum = Min_Y
                    Chart_Registro_Parcial.ChartAreas(0).AxisY.Maximum = Max_Y
                    Chart_Registro_Parcial.ChartAreas(0).AxisX.Minimum = Zoom.X_Inicio
                    Chart_Registro_Parcial.ChartAreas(0).AxisX.Maximum = Zoom.X_Final
                End If
            Else
                Chart_Registro_Parcial.ChartAreas(0).AxisY.Minimum = Min_Y
                Chart_Registro_Parcial.ChartAreas(0).AxisY.Maximum = Max_Y
                Chart_Registro_Parcial.ChartAreas(0).AxisX.Minimum = Intervalo_Min_X
                Chart_Registro_Parcial.ChartAreas(0).AxisX.Maximum = Intervalo_Max_X
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

    Private Sub Button_Graficar_Registro_Click(sender As Object, e As EventArgs) Handles Button_Graficar_Registro.Click

        If ComboBox_Selecionar_Derivacion.Text.Trim = "" Or ComboBox_Selecionar_Registro.Text.Trim = "" Or ComboBox_Selecion_Paciente.Text.Trim = "" Then
            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "You have to select", "a Record", "Record Error", 0)
        Else
            Dim Coneccion_Base_Datos As New SqlConnection
            Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()

            Dim Registros_Selecionados As String = ""
            Dim Usuario As String = ""
            'Obtener el Usuario
            If Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
                Usuario = ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_")
            ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 1 Then
                Usuario = Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_")
            End If
            Dim Nombre_Paciente As String = ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_")
            Dim Fecha_Registro As String = ComboBox_Selecionar_Registro.Text.TrimEnd.Replace(" ", "_")
            Dim Derivacion As String = ComboBox_Selecionar_Derivacion.Text.TrimEnd.Replace(" ", "_")
            Dim Frecuencia_Registro As Double = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Frecuencia_Registro(Coneccion_Base_Datos, Usuario, Nombre_Paciente, Fecha_Registro)
            Dim Nombre_Tabla As String = Usuario + "___" + Nombre_Paciente + "___" + Fecha_Registro

            'Determinar si se esta relizando un analiciz al registro
            If Form_Principal.Estado_Registros.Consultar_Registro_Bloqueado(Nombre_Tabla) = False Then
                'Determinar si no se ha selecionnado la serie 
                Dim Bandera_registro_Selecionado As Boolean = False
                For Index = Registro_Parciales_Graficados.Count - 1 To 0 Step -1
                    If Registro_Parciales_Graficados(Index).Usuario = Usuario And Registro_Parciales_Graficados(Index).Paciente = Nombre_Paciente And Registro_Parciales_Graficados(Index).Fecha_Registro = Fecha_Registro And Registro_Parciales_Graficados(Index).Nombre_Columna = Derivacion Then
                        Bandera_registro_Selecionado = True
                        Exit For
                    End If
                Next
                If Bandera_registro_Selecionado = False Then


                    TabControlEX_Modulo_Grafico_Control.TabPages(1).Enabled = True
                    TabControlEX_Modulo_Grafico_Control.TabPages(2).Enabled = True
                    TabControlEX_Modulo_Grafico_Control.TabPages(3).Enabled = True

                    ' Obtner la cantida de datos del registro

                    'Variables para obtner el valor de los registros(Cantidad de valors a graficar en la grafica total; Catidad maxima de registros, intervalo entre los registros)
                    Dim Coneccion_Registro As New SqlConnection
                    Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuario, Nombre_Paciente, Fecha_Registro, Derivacion)

                    Dim Grafica_Cantida_Datos As Int32 = 7999
                    Dim Contador_Max_Registro As Int64 = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Nombre_Tabla)
                    Dim Contador_Index_Temp As Int16 = 0

                    Dim x, y As Double()
                    While Contador_Max_Registro = 0 And Contador_Index_Temp < 20
                        Contador_Index_Temp = Contador_Index_Temp + 1
                        Contador_Max_Registro = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Nombre_Tabla)
                    End While
                    If Contador_Max_Registro > 0 Then
                        If Contador_Max_Registro < 2000000 Then
                            'Si el registro tiene menos de 2 000 000 de datos lo leo y lo publico
                            If (Grafica_Cantida_Datos >= Contador_Max_Registro) Then
                                Grafica_Cantida_Datos = Contador_Max_Registro - 1
                            End If

                            'Calculo del paso entre datos
                            Dim Paso_Registro As Int32
                            Paso_Registro = Math.Floor(Contador_Max_Registro / (Grafica_Cantida_Datos + 1))
                            If Paso_Registro < 1 Then
                                Paso_Registro = 1
                            End If

                            'Determinar si tengo que ampliar el margen maximo del eje X de la grafica total
                            If Contador_Max_Registro / Frecuencia_Registro > Grafica_Total.Max_Valor_X Then
                                Grafica_Total.Max_Valor_X = Contador_Max_Registro / Frecuencia_Registro
                            End If

                            'Obtener datos del Registro
                            Dim Datos_Registro As New DataSet
                            Datos_Registro = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Nombre_Tabla, Derivacion, Paso_Registro, "0", Convert.ToString(Contador_Max_Registro))

                            ReDim y(Datos_Registro.Tables(0).Rows.Count - 1)
                            ReDim x(Datos_Registro.Tables(0).Rows.Count - 1)
                            If Datos_Registro.Tables(0).Rows.Count - 1 > Grafica_Cantida_Datos Then
                                'Obtener los valores a graficar 
                                For Index = 0 To Datos_Registro.Tables(0).Rows.Count - 1
                                    y(Index) = Datos_Registro.Tables(0).Rows(Index)(1)
                                    x(Index) = (Index * Paso_Registro) / Frecuencia_Registro
                                Next Index

                                If Grafica_Total.Max_Valor_Y < y.Max Then
                                    Grafica_Total.Max_Valor_Y = y.Max
                                End If
                                If Grafica_Total.Min_Valor_Y > y.Min Then
                                    Grafica_Total.Min_Valor_Y = y.Min
                                End If
                            End If
                        Else
                            'Si el registro tiene menos de 2 000 000 de datos lo leo y lo publico sino greo una seria fantasma

                            'Calculo del paso entre datos
                            Dim Paso_Registro As Int32
                            Paso_Registro = Math.Floor(Contador_Max_Registro / (Grafica_Cantida_Datos + 1))
                            If Paso_Registro < 1 Then
                                Paso_Registro = 1
                            End If

                            'Determinar si tengo que ampliar el margen maximo del eje X de la grafica total
                            If Contador_Max_Registro / Frecuencia_Registro > Grafica_Total.Max_Valor_X Then
                                Grafica_Total.Max_Valor_X = Contador_Max_Registro / Frecuencia_Registro
                            End If

                            ReDim y(Grafica_Cantida_Datos)
                            ReDim x(Grafica_Cantida_Datos)
                            'Obtener los valores a graficar 
                            For Index = 0 To Grafica_Cantida_Datos
                                If Index Mod 32 = 0 Then
                                    y(Index) = 0
                                ElseIf Index Mod 32 = 1 Then
                                    y(Index) = 0
                                ElseIf Index Mod 32 = 2 Then
                                    y(Index) = 0.05
                                ElseIf Index Mod 32 = 3 Then
                                    y(Index) = 0.1
                                ElseIf Index Mod 32 = 4 Then
                                    y(Index) = 0.05
                                ElseIf Index Mod 32 = 5 Then
                                    y(Index) = 0
                                ElseIf Index Mod 32 = 6 Then
                                    y(Index) = 0
                                ElseIf Index Mod 32 = 7 Then
                                    y(Index) = -0.1
                                ElseIf Index Mod 32 = 8 Then
                                    y(Index) = -0.2
                                ElseIf Index Mod 32 = 9 Then
                                    y(Index) = -0.1
                                ElseIf Index Mod 32 = 10 Then
                                    y(Index) = 0
                                ElseIf Index Mod 32 = 11 Then
                                    y(Index) = 0.1
                                ElseIf Index Mod 32 = 12 Then
                                    y(Index) = 0.2
                                ElseIf Index Mod 32 = 13 Then
                                    y(Index) = 0.3
                                ElseIf Index Mod 32 = 14 Then
                                    y(Index) = 0.2
                                ElseIf Index Mod 32 = 15 Then
                                    y(Index) = 0.1
                                ElseIf Index Mod 32 = 16 Then
                                    y(Index) = 0
                                ElseIf Index Mod 32 = 17 Then
                                    y(Index) = -0.1
                                ElseIf Index Mod 32 = 18 Then
                                    y(Index) = -0.2
                                ElseIf Index Mod 32 = 19 Then
                                    y(Index) = -0.1
                                ElseIf Index Mod 32 = 20 Then
                                    y(Index) = 0
                                ElseIf Index Mod 32 = 21 Then
                                    y(Index) = 0
                                ElseIf Index Mod 32 = 22 Then
                                    y(Index) = 0
                                ElseIf Index Mod 32 = 23 Then
                                    y(Index) = 0.1
                                ElseIf Index Mod 32 = 24 Then
                                    y(Index) = 0.2
                                ElseIf Index Mod 32 = 25 Then
                                    y(Index) = 0.1
                                ElseIf Index Mod 32 = 26 Then
                                    y(Index) = 0
                                ElseIf Index Mod 32 = 27 Then
                                    y(Index) = 0
                                ElseIf Index Mod 32 = 28 Then
                                    y(Index) = 0
                                ElseIf Index Mod 32 = 29 Then
                                    y(Index) = 0
                                ElseIf Index Mod 32 = 30 Then
                                    y(Index) = 0
                                ElseIf Index Mod 32 = 31 Then
                                    y(Index) = 0
                                End If
                                x(Index) = (Index * Paso_Registro) / Frecuencia_Registro
                            Next Index

                            If Grafica_Total.Max_Valor_Y < y.Max Then
                                    Grafica_Total.Max_Valor_Y = y.Max
                                End If
                                If Grafica_Total.Min_Valor_Y > y.Min Then
                                    Grafica_Total.Min_Valor_Y = y.Min
                                End If
                            End If

                        'Agregar una nueva serie 
                        Registros_Selecionados = Usuario + "___" + Nombre_Paciente + "___" + Fecha_Registro + "___" + Derivacion
                            Chart_Registro_Total.Series.Add(Registros_Selecionados)

                            'Especifica que es una serie lineal 
                            Chart_Registro_Total.Series(Registros_Selecionados).ChartType = DataVisualization.Charting.SeriesChartType.Line
                            'Adiciona los datos a la grafica total
                            Chart_Registro_Total.Series(Registros_Selecionados).Points.DataBindXY(x, y)

                            'Adiciona los datos del registro parcial
                            Registro_Parciales_Graficados_Temporal.Nombre_Tabla = Nombre_Tabla
                            Registro_Parciales_Graficados_Temporal.Usuario = Usuario
                            Registro_Parciales_Graficados_Temporal.Paciente = Nombre_Paciente
                            Registro_Parciales_Graficados_Temporal.Fecha_Registro = Fecha_Registro
                            Registro_Parciales_Graficados_Temporal.Nombre_Columna = Derivacion
                            Registro_Parciales_Graficados_Temporal.Frecuencia = Frecuencia_Registro
                            Registro_Parciales_Graficados_Temporal.Cantidad_Maxima_Datos = Contador_Max_Registro
                            Registro_Parciales_Graficados_Temporal.Color = Color_Registro()

                            Chart_Registro_Total.Series(Registros_Selecionados).Color = Registro_Parciales_Graficados_Temporal.Color

                            Registro_Parciales_Graficados.Add(Registro_Parciales_Graficados_Temporal)


                            'Actualiza Series_Min Para que se vea al frente 
                            Chart_Registro_Total.Series.Remove(Chart_Registro_Total.Series.FindByName("Series_Min"))
                            Chart_Registro_Total.Series.Add("Series_Min")
                            Chart_Registro_Total.Series("Series_Min").ChartType = DataVisualization.Charting.SeriesChartType.Point
                            Chart_Registro_Total.Series("Series_Min").Points.AddXY(Convert.ToDouble(TextBox_Registro_Parcial_Minimo.Text), 0)
                        Chart_Registro_Total.Series("Series_Min").MarkerImage = Application.StartupPath + "\Imagenes\Marcador_Verde.png"
                        'Actualiza Series_Max Para que se vea al frente
                        Chart_Registro_Total.Series.Remove(Chart_Registro_Total.Series.FindByName("Series_Max"))
                        Chart_Registro_Total.Series.Add("Series_Max")
                        Chart_Registro_Total.Series("Series_Max").ChartType = DataVisualization.Charting.SeriesChartType.Point

                        Chart_Registro_Total.Series("Series_Max").Points.AddXY(Convert.ToDouble(TextBox_Registro_Parcial_Maximo.Text), 0)
                        Chart_Registro_Total.Series("Series_Max").MarkerImage = Application.StartupPath + "\Imagenes\Marcador_Verde.png"

                        'Actualiza el valor de los cursores en el eje Y 

                        Chart_Registro_Total.Series("Series_Min").Points(0).YValues(0) = Grafica_Total.Min_Valor_Y
                        Chart_Registro_Total.Series("Series_Max").Points(0).YValues(0) = Grafica_Total.Min_Valor_Y

                        'Actualiza los valores maximos y minimos de grafica total el valor del eje X  y Y 
                        If Grafica_Total.Min_Valor_Y = Grafica_Total.Max_Valor_Y Then
                            Chart_Registro_Total.ChartAreas(0).AxisY.Minimum = Grafica_Total.Min_Valor_Y - 0.5
                            Chart_Registro_Total.ChartAreas(0).AxisY.Maximum = Grafica_Total.Max_Valor_Y + 0.5
                        Else
                            Chart_Registro_Total.ChartAreas(0).AxisY.Minimum = Grafica_Total.Min_Valor_Y
                            Chart_Registro_Total.ChartAreas(0).AxisY.Maximum = Grafica_Total.Max_Valor_Y
                        End If
                        Chart_Registro_Total.ChartAreas(0).AxisX.Maximum = Grafica_Total.Max_Valor_X


                        'Actualiza la grafica parcial de los registros
                        'Actualizar_Registro_Parcial()
                        'Actualizo el ComboBox_Registro_Graficado
                        ComboBox_Registro_Graficado.Items.Add(Registros_Selecionados)
                        ComboBox_Registro_Graficado.SelectedIndex = ComboBox_Registro_Graficado.Items.Count - 1
                        Panel_Color_Registro_Graficado.BackColor = Registro_Parciales_Graficados_Temporal.Color

                        ComboBox_Registro_Modificar.Items.Add(Registros_Selecionados)
                        ComboBox_Registro_Modificar.SelectedIndex = ComboBox_Registro_Modificar.Items.Count - 1
                        Panel_Color_Registro_Modificar.BackColor = Registro_Parciales_Graficados_Temporal.Color
                    Else
                        Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                        Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "Record  " + Nombre_Tabla, " could not load", "Record Error", 0)
                    End If
                End If

            Else
                Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "Record " + Nombre_Tabla, "is in use", "Record Error", 0)
            End If

        End If
    End Sub

    Private Sub TabPageEX_Nuevo_Registro_Load(sender As Object, e As EventArgs)
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
            Dim Paciente As DataSet
            Paciente = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Usuarios, Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_"))

            ComboBox_Selecion_Paciente.Items.Clear()
            For i = 0 To Paciente.Tables("Datos_Pacientes").Rows.Count - 1
                ComboBox_Selecion_Paciente.Items.Add(Paciente.Tables("Datos_Pacientes").Rows(i)(0))
            Next i
            'Identificar los registors existentes relacionados con el pacientes 
            If ComboBox_Selecion_Paciente.Items.Count > 0 Then
                ComboBox_Selecion_Paciente.SelectedIndex = 0
                Dim Registros As DataSet
                Registros = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Usuarios, Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"))

                ComboBox_Selecionar_Registro.Items.Clear()
                For i = 0 To Registros.Tables(0).Rows.Count - 1
                    ComboBox_Selecionar_Registro.Items.Add(Registros.Tables(0).Rows(i)(0))
                Next i
            End If
            If ComboBox_Selecionar_Registro.Items.Count > 0 Then
                ComboBox_Selecionar_Registro.SelectedIndex = 0
            End If
            Coneccion_Usuarios.Close()
        ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
            'Identificar los usuarios existentes
            Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
            Dim Usuarios As DataSet
            Usuarios = Class_Funciones_Base_Datos.Tabla_Usuarios_Buscar_Usuarios(Coneccion_Usuarios, "1")

            ComboBox_Selecion_Usuario.Items.Clear()
            For i = 0 To Usuarios.Tables("Usuarios").Rows.Count - 1
                ComboBox_Selecion_Usuario.Items.Add(Usuarios.Tables("Usuarios").Rows(i)(0))
            Next i
            'Identificar los pacientes existentes relacionados con el usuario 
            If ComboBox_Selecion_Usuario.Items.Count > 0 Then
                ComboBox_Selecion_Usuario.SelectedIndex = 0
                Dim Paciente As DataSet
                Paciente = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Usuarios, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"))

                ComboBox_Selecion_Paciente.Items.Clear()

                For i = 0 To Paciente.Tables("Datos_Pacientes").Rows.Count - 1
                    ComboBox_Selecion_Paciente.Items.Add(Paciente.Tables("Datos_Pacientes").Rows(i)(0))
                Next i

                'Identificar los registors existentes relacionados con el pacientes 
                If ComboBox_Selecion_Paciente.Items.Count > 0 Then
                    ComboBox_Selecion_Paciente.SelectedIndex = 0
                    Dim Registros As DataSet
                    Registros = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Usuarios, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"))
                    ComboBox_Selecionar_Registro.Items.Clear()
                    For i = 0 To Registros.Tables(0).Rows.Count - 1
                        ComboBox_Selecionar_Registro.Items.Add(Registros.Tables(0).Rows(i)(0))
                    Next i
                End If
                If ComboBox_Selecionar_Registro.Items.Count > 0 Then
                    ComboBox_Selecionar_Registro.SelectedIndex = 0
                End If
                Coneccion_Usuarios.Close()
            End If
        End If
    End Sub

    Private Sub ComboBox_Selecion_Usuario_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox_Selecion_Usuario.SelectedIndexChanged
        'Identificar los pacientes existentes relacionados con el usuario seleccionado
        Dim Coneccion_Base_Datos As New SqlConnection
        Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
        Dim Paciente As DataSet
        Paciente = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Base_Datos, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"))

        ComboBox_Selecion_Paciente.Items.Clear()
        ComboBox_Selecionar_Registro.Items.Clear()

        For i = 0 To Paciente.Tables(0).Rows.Count - 1
            ComboBox_Selecion_Paciente.Items.Add(Paciente.Tables(0).Rows(i)(0))
        Next i
        'Identificar los registors existentes relacionados con el pacientes 
        If ComboBox_Selecion_Paciente.Items.Count > 0 Then
            ComboBox_Selecion_Paciente.SelectedIndex = 0
        End If
    End Sub

    Private Sub ComboBox_Selecion_Paciente_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox_Selecion_Paciente.SelectedIndexChanged
        Dim Coneccion_Base_Datos As New SqlConnection
        Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()

        If Form_Principal.Usuario_Activo.Tipo_Usuario = 1 Then
            Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
            Dim Registros As DataSet
            Registros = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Base_Datos, Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"))

            ComboBox_Selecionar_Registro.Items.Clear()
            For i = 0 To Registros.Tables(0).Rows.Count - 1
                ComboBox_Selecionar_Registro.Items.Add(Registros.Tables(0).Rows(i)(0))
            Next i
            If ComboBox_Selecionar_Registro.Items.Count > 0 Then
                ComboBox_Selecionar_Registro.SelectedIndex = 0
            End If
        ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
            Dim Registros As New DataSet
            Registros = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Base_Datos, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"))

            ComboBox_Selecionar_Registro.Items.Clear()
            For i = 0 To Registros.Tables(0).Rows.Count - 1
                ComboBox_Selecionar_Registro.Items.Add(Registros.Tables(0).Rows(i)(0))
            Next i
            If ComboBox_Selecionar_Registro.Items.Count > 0 Then
                ComboBox_Selecionar_Registro.SelectedIndex = 0
            End If

        End If
    End Sub





    Private Sub Chart_Registro_Total_MouseDown(sender As Object, e As MouseEventArgs) Handles Chart_Registro_Total.MouseDown

        'Determina si se preciono el boton izquierdo del mause
        If e.Button = MouseButtons.Left Then
            If CheckBox_Bloquear_Ventana.Checked Then
                Dim posX, pos_X_Min, pos_X_Max As Double
                'Determina la posicion del mause en la grafica en pixeles
                posX = e.X
                'Corige valores fuera de rango
                If posX <= 0 Then
                    posX = 0
                ElseIf posX >= Chart_Registro_Total.Width Then
                    posX = Chart_Registro_Total.Width - 1
                End If

                'Determina la posicion del mause en la grafica en respeto al eje X
                posX = Chart_Registro_Total.ChartAreas(0).AxisX.PixelPositionToValue(posX)
                'Calcula la nueva pocicion de los cursores
                pos_X_Min = posX - Zoom.X_Bloqueo_Ventana
                pos_X_Max = posX + Zoom.X_Bloqueo_Ventana
                If pos_X_Min < Grafica_Total.Min_Valor_X Then
                    pos_X_Min = Grafica_Total.Min_Valor_X
                    pos_X_Max = Grafica_Total.Min_Valor_X + 2 * Zoom.X_Bloqueo_Ventana
                ElseIf pos_X_Max > Grafica_Total.Max_Valor_X Then
                    pos_X_Min = Grafica_Total.Max_Valor_X - 2 * Zoom.X_Bloqueo_Ventana
                    pos_X_Max = Grafica_Total.Max_Valor_X
                End If
                'Actualiza el Zoom
                Zoom.X_Inicio = pos_X_Min
                Zoom.X_Final = pos_X_Max

                'Ubica los cursores
                Chart_Registro_Total.Series("Series_Min").Points(0).XValue = pos_X_Min
                Chart_Registro_Total.Series("Series_Max").Points(0).XValue = pos_X_Max
                TextBox_Registro_Parcial_Minimo.Text = Convert.ToString(pos_X_Min)
                TextBox_Registro_Parcial_Maximo.Text = Convert.ToString(pos_X_Max)
                Bandera_Cursores_Grafica_Parcial = 3

            Else

                Dim posX, pos_X_Min, pos_X_Max As Double
                'Determina la posicion del mause en la grafica en pixeles
                posX = e.X
                'Corige valores fuera de rango
                If posX <= 0 Then
                    posX = 0
                ElseIf posX >= Chart_Registro_Total.Width Then
                    posX = Chart_Registro_Total.Width - 1
                End If

                'Determina la posicion del mause en la grafica en respeto al eje X
                posX = Chart_Registro_Total.ChartAreas(0).AxisX.PixelPositionToValue(posX)
                'posX = Chart_Registro_Parcial.ChartAreas(0).AxisX.PixelPositionToValue(posX)
                'Determina la posicion del los cursores Maximo y Minimo en la grafica en respeto al eje X
                pos_X_Min = (Chart_Registro_Total.Series("Series_Min").Points(0).XValue)
                pos_X_Max = (Chart_Registro_Total.Series("Series_Max").Points(0).XValue)

                'Determina el cursor que se va a mover
                If Math.Abs(posX - pos_X_Min) < Math.Abs(posX - pos_X_Max) Then
                    If posX <= 0 Then
                        posX = 0
                    ElseIf posX > pos_X_Max Then
                        posX = pos_X_Max
                    End If
                    'Cambia la imagen del cursor
                    Chart_Registro_Total.Series("Series_Min").MarkerImage = Application.StartupPath + "\Imagenes\Marcador_Azul.png"
                    'Actualisa el cursor y al valor en el textbox
                    Chart_Registro_Total.Series("Series_Min").Points(0).XValue = posX
                    TextBox_Registro_Parcial_Minimo.Text = Convert.ToString(posX)
                    'Avilita la bandera Bandera_Cursores_Grafica_Parcial para cuando se mueva el mause
                    Bandera_Cursores_Grafica_Parcial = 1

                ElseIf Math.Abs(posX - pos_X_Min) > Math.Abs(posX - pos_X_Max) Then

                    If posX >= Grafica_Total.Max_Valor_X Then
                        posX = Grafica_Total.Max_Valor_X
                    ElseIf posX < pos_X_Min Then
                        posX = pos_X_Min
                    End If
                    'Cambia la imagen del cursor
                    Chart_Registro_Total.Series("Series_Max").MarkerImage = Application.StartupPath + "\Imagenes\Marcador_Azul.png"
                    'Actualisa el cursor y al valor en el textbox
                    Chart_Registro_Total.Series("Series_Max").Points(0).XValue = posX
                    TextBox_Registro_Parcial_Maximo.Text = Convert.ToString(posX)
                    'Avilita la bandera Bandera_Cursores_Grafica_Parcial para cuando se mueva el mause
                    Bandera_Cursores_Grafica_Parcial = 2
                ElseIf Math.Abs(posX - pos_X_Min) = Math.Abs(posX - pos_X_Max) Then
                    If posX <= pos_X_Min Then
                        If posX <= 0 Then
                            posX = 0
                        ElseIf posX > pos_X_Max Then
                            posX = pos_X_Max
                        End If
                        'Cambia la imagen del cursor
                        Chart_Registro_Total.Series("Series_Min").MarkerImage = Application.StartupPath + "\Imagenes\Marcador_Azul.png"
                        'Actualisa el cursor y al valor en el textbox
                        Chart_Registro_Total.Series("Series_Min").Points(0).XValue = posX
                        TextBox_Registro_Parcial_Minimo.Text = Convert.ToString(posX)
                        'Avilita la bandera Bandera_Cursores_Grafica_Parcial para cuando se mueva el mause
                        Bandera_Cursores_Grafica_Parcial = 1
                    ElseIf posX > pos_X_Min Then
                        If posX >= Grafica_Total.Max_Valor_X Then
                            posX = Grafica_Total.Max_Valor_X
                        ElseIf posX < pos_X_Min Then
                            posX = pos_X_Min
                        End If
                        'Cambia la imagen del cursor
                        Chart_Registro_Total.Series("Series_Max").MarkerImage = Application.StartupPath + "\Imagenes\Marcador_Azul.png"
                        'Actualisa el cursor y al valor en el textbox
                        Chart_Registro_Total.Series("Series_Max").Points(0).XValue = posX
                        TextBox_Registro_Parcial_Maximo.Text = Convert.ToString(posX)
                        'Avilita la bandera Bandera_Cursores_Grafica_Parcial para cuando se mueva el mause
                        Bandera_Cursores_Grafica_Parcial = 2
                    End If
                End If

            End If



        End If
    End Sub

    Private Sub UserControl_Modulo_Graficar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chart_Registro_Total.Series("Series_Min").MarkerImage = Application.StartupPath + "\Imagenes\Marcador_Verde.png"
        Chart_Registro_Total.Series("Series_Max").MarkerImage = Application.StartupPath + "\Imagenes\Marcador_Verde.png"

        Grafica_Total.Max_Valor_X = 1
        Grafica_Total.Min_Valor_X = 0

        Grafica_Total.Min_Valor_Y = 20000000
        Grafica_Total.Max_Valor_Y = -20000000




        ComboBox_Cuadricula_ECG_Ganancia.SelectedIndex = 2
        ComboBox_Cuadricula_ECG_Velocidad.SelectedIndex = 1

        'El Zoom no esta activo 
        Zoom.Zoom_Activo = 0
        SplitContainer_Modulo_Grafico.SplitterDistance = 0
        ComboBox_Tamaño_Letra.Text = "9"
        Call Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1_Click(sender, Nothing)
    End Sub

    Private Sub Chart_Registro_Total_MouseMove(sender As Object, e As MouseEventArgs) Handles Chart_Registro_Total.MouseMove
        If CheckBox_Bloquear_Ventana.Checked And Bandera_Cursores_Grafica_Parcial = 3 Then
            Dim posX, pos_X_Min, pos_X_Max As Double
            'Determina la posicion del mause en la grafica en pixeles
            posX = e.X
            'Corige valores fuera de rango
            If posX <= 0 Then
                posX = 0
            ElseIf posX >= Chart_Registro_Total.Width Then
                posX = Chart_Registro_Total.Width - 1
            End If

            'Determina la posicion del mause en la grafica en respeto al eje X
            'Detecta cando se la sa una execion por salir del rango de la ventana
            Try
                posX = Chart_Registro_Total.ChartAreas(0).AxisX.PixelPositionToValue(posX)
                'Calcula la nueva pocicion de los cursores
                pos_X_Min = posX - Zoom.X_Bloqueo_Ventana
                pos_X_Max = posX + Zoom.X_Bloqueo_Ventana
                If pos_X_Min < Grafica_Total.Min_Valor_X Then
                    pos_X_Min = Grafica_Total.Min_Valor_X
                    pos_X_Max = Grafica_Total.Min_Valor_X + 2 * Zoom.X_Bloqueo_Ventana
                ElseIf pos_X_Max > Grafica_Total.Max_Valor_X Then
                    pos_X_Min = Grafica_Total.Max_Valor_X - 2 * Zoom.X_Bloqueo_Ventana
                    pos_X_Max = Grafica_Total.Max_Valor_X
                End If
                'Actualiza el Zoom
                Zoom.X_Inicio = pos_X_Min
                Zoom.X_Final = pos_X_Max
                'Ubica los cursores
                Chart_Registro_Total.Series("Series_Min").Points(0).XValue = pos_X_Min
                Chart_Registro_Total.Series("Series_Max").Points(0).XValue = pos_X_Max
                TextBox_Registro_Parcial_Minimo.Text = Convert.ToString(pos_X_Min)
                TextBox_Registro_Parcial_Maximo.Text = Convert.ToString(pos_X_Max)
            Catch ex As Exception
            End Try

        Else
            'Determina el cursor a mover 
            'Cursor minimo ->Bandera_Cursores_Grafica_Parcial = 1 
            'Cursor maximo ->Bandera_Cursores_Grafica_Parcial = 1 
            If Bandera_Cursores_Grafica_Parcial = 1 Then
                Dim posX As Double
                'Corige valores fuera de rango
                posX = e.X
                If posX <= 0 Then
                    posX = 0
                ElseIf posX >= Chart_Registro_Total.Width Then
                    posX = Chart_Registro_Total.Width - 1
                End If
                'Detecta cando se la sa una execion por salir del rango de la ventana
                Try
                    posX = Chart_Registro_Total.ChartAreas(0).AxisX.PixelPositionToValue(posX)
                    'Corige valores fuera de rango
                    If posX <= 0 Then
                        posX = 0
                    ElseIf posX >= Chart_Registro_Total.Series("Series_Max").Points(0).XValue Then
                        posX = Chart_Registro_Total.Series("Series_Max").Points(0).XValue
                    End If
                    'Actualisa el cursor y al valor en el textbox
                    Chart_Registro_Total.Series("Series_Min").Points(0).XValue = posX
                    TextBox_Registro_Parcial_Minimo.Text = Convert.ToString(posX)
                Catch ex As Exception
                End Try

            End If

            If Bandera_Cursores_Grafica_Parcial = 2 Then
                Dim posX As Double
                posX = e.X

                'Corige valores fuera de rango
                If posX <= 0 Then
                    posX = 0
                ElseIf posX >= Chart_Registro_Total.Width - 10 Then
                    posX = Chart_Registro_Total.Width - 10
                End If

                posX = Chart_Registro_Total.ChartAreas(0).AxisX.PixelPositionToValue(posX)


                'Corige valores fuera de rango
                If posX >= Grafica_Total.Max_Valor_X Then
                    posX = Grafica_Total.Max_Valor_X
                ElseIf posX <= Chart_Registro_Total.Series("Series_Min").Points(0).XValue Then
                    posX = Chart_Registro_Total.Series("Series_Min").Points(0).XValue
                End If
                'Actualisa el cursor y al valor en el textbox
                Chart_Registro_Total.Series("Series_Max").Points(0).XValue = posX
                TextBox_Registro_Parcial_Maximo.Text = Convert.ToString(posX)
            End If
        End If

    End Sub

    Private Sub Chart_Registro_Total_MouseUp(sender As Object, e As MouseEventArgs) Handles Chart_Registro_Total.MouseUp
        'Actualiza los cursores y la grafica Parcial
        If Bandera_Cursores_Grafica_Parcial = 1 Then
            Bandera_Cursores_Grafica_Parcial = 0
            Chart_Registro_Total.Series("Series_Min").MarkerImage = Application.StartupPath + "\Imagenes\Marcador_Verde.png"
            Actualizar_Registro_Parcial()
        ElseIf Bandera_Cursores_Grafica_Parcial = 2 Then
            Bandera_Cursores_Grafica_Parcial = 0
            Chart_Registro_Total.Series("Series_Max").MarkerImage = Application.StartupPath + "\Imagenes\Marcador_Verde.png"
            Actualizar_Registro_Parcial()
        ElseIf Bandera_Cursores_Grafica_Parcial = 3 Then
            Bandera_Cursores_Grafica_Parcial = 0

            Actualizar_Registro_Parcial()
        End If
    End Sub

    Private Sub TextBox_Registro_Parcial_Minimo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Registro_Parcial_Minimo.KeyPress
        Try
            If e.KeyChar = "." Or Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
                'Actualiza la grafica solo caundo se preciona enter
                If Asc(e.KeyChar) = 13 Then
                    Zoom.X_Inicio = Convert.ToDouble(TextBox_Registro_Parcial_Minimo.Text)
                    Zoom.X_Final = Convert.ToDouble(TextBox_Registro_Parcial_Maximo.Text)
                    Zoom.X_Bloqueo_Ventana = (Convert.ToDouble(TextBox_Registro_Parcial_Maximo.Text) - Convert.ToDouble(TextBox_Registro_Parcial_Minimo.Text)) / 2
                    Actualizar_Registro_Parcial()
                    Actualizar_Pocicion_DataGridView_Registro_Modificar()
                End If
            Else
                e.Handled = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox_Registro_Parcial_Maximo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Registro_Parcial_Maximo.KeyPress
        Try
            If e.KeyChar = "." Or Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
                'Actualiza la grafica solo caundo se preciona enter
                If Asc(e.KeyChar) = 13 Then
                    Zoom.X_Inicio = Convert.ToDouble(TextBox_Registro_Parcial_Minimo.Text)
                    Zoom.X_Final = Convert.ToDouble(TextBox_Registro_Parcial_Maximo.Text)
                    Zoom.X_Bloqueo_Ventana = (Convert.ToDouble(TextBox_Registro_Parcial_Maximo.Text) - Convert.ToDouble(TextBox_Registro_Parcial_Minimo.Text)) / 2
                    Actualizar_Registro_Parcial()
                    Actualizar_Pocicion_DataGridView_Registro_Modificar()
                End If
            Else
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub TextBox_Registro_Parcial_Minimo_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox_Registro_Parcial_Minimo.KeyUp
        'Actualiza los cursores y la grafica Parcial
        Try
            If TextBox_Registro_Parcial_Maximo.Text <> "" And TextBox_Registro_Parcial_Minimo.Text <> "" Then
                Dim Texto As String = TextBox_Registro_Parcial_Minimo.Text
                If Texto = "." Then
                    Texto = "0."
                    TextBox_Registro_Parcial_Minimo.Text = Texto
                End If
                Dim Valor As Double = Convert.ToDouble(TextBox_Registro_Parcial_Minimo.Text)
                If Valor <= 0 Then
                    Chart_Registro_Total.Series("Series_Min").Points(0).XValue = 0

                ElseIf Valor >= Chart_Registro_Total.Series("Series_Max").Points(0).XValue Then
                    Chart_Registro_Total.Series("Series_Min").Points(0).XValue = Chart_Registro_Total.Series("Series_Max").Points(0).XValue
                Else
                    Chart_Registro_Total.Series("Series_Min").Points(0).XValue = Valor
                    Chart_Registro_Total.Series("Series_Max").Points(0).XValue = Convert.ToDouble(TextBox_Registro_Parcial_Maximo.Text)
                    ' Actualizar_Registro_Parcial()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox_Registro_Parcial_Maximo_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox_Registro_Parcial_Maximo.KeyUp
        'Actualiza los cursores y la grafica Parcial
        Try
            If TextBox_Registro_Parcial_Maximo.Text <> "" And TextBox_Registro_Parcial_Minimo.Text <> "" Then
                Dim Texto As String = TextBox_Registro_Parcial_Maximo.Text
                If Texto = "." Then
                    Texto = "0."
                    TextBox_Registro_Parcial_Maximo.Text = Texto
                End If
                Dim Valor As Double = Convert.ToDouble(TextBox_Registro_Parcial_Maximo.Text)
                If Valor <= Chart_Registro_Total.Series("Series_Min").Points(0).XValue Then
                    Chart_Registro_Total.Series("Series_Max").Points(0).XValue = Chart_Registro_Total.Series("Series_Min").Points(0).XValue

                ElseIf Valor >= Grafica_Total.Max_Valor_X Then
                    Chart_Registro_Total.Series("Series_Max").Points(0).XValue = Grafica_Total.Max_Valor_X
                Else
                    Chart_Registro_Total.Series("Series_Min").Points(0).XValue = Convert.ToDouble(TextBox_Registro_Parcial_Minimo.Text)
                    Chart_Registro_Total.Series("Series_Max").Points(0).XValue = Valor
                    'Actualizar_Registro_Parcial()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button_Borar_Registros_Click(sender As Object, e As EventArgs) Handles Button_Borar_Registros.Click
        Chart_Registro_Parcial.Series.Clear()
        Chart_Registro_Total.Series.Clear()
        Registro_Parciales_Graficados.Clear()
        ComboBox_Registro_Graficado.Items.Clear()
        Panel_Color_Registro_Graficado.BackColor = Color.Transparent

        RichTextBox_Datos_Paciente.Text = ""

        ComboBox_Registro_Modificar.Items.Clear()
        Panel_Color_Registro_Modificar.BackColor = Color.Transparent



        'Actualiza Series_Min Para que se vea al frente 
        Chart_Registro_Total.Series.Add("Series_Min")
        Chart_Registro_Total.Series("Series_Min").ChartType = DataVisualization.Charting.SeriesChartType.Point
        Chart_Registro_Total.Series("Series_Min").Points.AddXY(0, 0)
        Chart_Registro_Total.Series("Series_Min").MarkerImage = Application.StartupPath + "\Imagenes\Marcador_Verde.png"

        'Actualiza Series_Max Para que se vea al frente
        Chart_Registro_Total.Series.Add("Series_Max")
        Chart_Registro_Total.Series("Series_Max").ChartType = DataVisualization.Charting.SeriesChartType.Point
        Chart_Registro_Total.Series("Series_Max").Points.AddXY(1, 0)
        Chart_Registro_Total.Series("Series_Max").MarkerImage = Application.StartupPath + "\Imagenes\Marcador_Verde.png"

        'Actualiza los valores maximos y minimos de grafica total el valor del eje X  y Y 
        Chart_Registro_Total.ChartAreas(0).AxisY.Minimum = 0
        Chart_Registro_Total.ChartAreas(0).AxisY.Maximum = 10
        Chart_Registro_Total.ChartAreas(0).AxisX.Minimum = 0
        Chart_Registro_Total.ChartAreas(0).AxisX.Maximum = 1

        'Restablece los valors maximos y minimos de respaldo
        Grafica_Total.Max_Valor_X = 1
        Grafica_Total.Min_Valor_X = 0

        Grafica_Total.Min_Valor_Y = 20000000
        Grafica_Total.Max_Valor_Y = -20000000



    End Sub

    Private Sub Button_Cerrar_MouseEnter(sender As Object, e As EventArgs) Handles Button_Cerrar.MouseEnter
        Button_Cerrar.BackgroundImage = My.Resources.Cambio_Boton
    End Sub

    Private Sub Button_Cerrar_MouseLeave(sender As Object, e As EventArgs) Handles Button_Cerrar.MouseLeave
        Button_Cerrar.BackgroundImage = Nothing
    End Sub

    Private Sub Button_Cerrar_Click(sender As Object, e As EventArgs) Handles Button_Cerrar.Click
        Form_Principal.SplitContainer_Principal.Panel2.Controls.Remove(Me)
        Me.Dispose()
    End Sub

    Private Sub Chart_Registro_Parcial_MouseDown(sender As Object, e As MouseEventArgs) Handles Chart_Registro_Parcial.MouseDown
        'Determina si se preciono el boton izquierdo del mause
        If e.Button = MouseButtons.Left Then
            If CheckBox_Bloquear_Ventana.Checked Then
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

                'Determina la posicion del mause en la grafica en respeto al eje Y
                posY = Chart_Registro_Parcial.ChartAreas(0).AxisY.PixelPositionToValue(posY)

                Zoom.X_Inicio = posX - Zoom.X_Bloqueo_Ventana
                'Zoom.Y_Inicio = posY - Zoom.Y_Bloqueo_Ventana

                Zoom.X_Final = posX + Zoom.X_Bloqueo_Ventana
                'Zoom.Y_Final = posY + Zoom.Y_Bloqueo_Ventana

                If Zoom.X_Inicio < Grafica_Total.Min_Valor_X Then
                    Zoom.X_Inicio = Grafica_Total.Min_Valor_X
                    Zoom.X_Final = Grafica_Total.Min_Valor_X + 2 * Zoom.X_Bloqueo_Ventana
                ElseIf Zoom.X_Final > Grafica_Total.Max_Valor_X Then
                    Zoom.X_Inicio = Grafica_Total.Max_Valor_X - 2 * Zoom.X_Bloqueo_Ventana
                    Zoom.X_Final = Grafica_Total.Max_Valor_X
                End If

                'If Zoom.Y_Inicio < Grafica_Total.Min_Valor_Y Then
                '    Zoom.Y_Inicio = Grafica_Total.Min_Valor_Y
                '    Zoom.Y_Final = Grafica_Total.Min_Valor_Y + 2 * Zoom.Y_Bloqueo_Ventana
                'ElseIf Zoom.Y_Final > Grafica_Total.Max_Valor_Y Then
                '    Zoom.Y_Inicio = Grafica_Total.Max_Valor_Y - 2 * Zoom.Y_Bloqueo_Ventana
                '    Zoom.Y_Final = Grafica_Total.Max_Valor_Y

                'End If



                'Actualisa el cursor y al valor en el textbox
                TextBox_Registro_Parcial_Maximo.Text = Convert.ToString(Zoom.X_Final)
                TextBox_Registro_Parcial_Minimo.Text = Convert.ToString(Zoom.X_Inicio)
                Bandera_Cursores_Grafica_Parcial = 3

                Chart_Registro_Total.Series("Series_Min").Points(0).XValue = Zoom.X_Inicio
                Chart_Registro_Total.Series("Series_Max").Points(0).XValue = Zoom.X_Final


                Actualizar_Registro_Parcial()

            Else
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


            End If
        End If
    End Sub

    Private Sub Chart_Registro_Parcial_MouseUp(sender As Object, e As MouseEventArgs) Handles Chart_Registro_Parcial.MouseUp
        If e.Button = MouseButtons.Left Then
            If Bandera_Cursores_Grafica_Parcial = 3 Then
                Bandera_Cursores_Grafica_Parcial = 0
            Else

                Dim posX, posY As Double
                'Determina la posicion del mause en la grafica en pixeles
                posX = e.X
                posY = e.Y
                'Corige valores fuera de rango
                If posX <= 0 Then
                    posX = 0
                ElseIf posX >= Chart_Registro_Parcial.Width - 10 Then
                    posX = Chart_Registro_Parcial.Width - 10
                End If


                If posY <= 0 Then
                    posY = 0
                ElseIf posY >= Chart_Registro_Parcial.Height Then
                    posY = Chart_Registro_Parcial.Height - 1
                End If

                'Determina la posicion del mause en la grafica en respeto al eje X
                posX = Chart_Registro_Parcial.ChartAreas(0).AxisX.PixelPositionToValue(posX)

                'Determina la posicion del mause en la grafica en respeto al eje Y
                posY = Chart_Registro_Parcial.ChartAreas(0).AxisY.PixelPositionToValue(posY)

                Zoom.X_Final = posX
                Zoom.Y_Final = posY
                Zoom.Zoom_Activo = 0
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


                If Zoom.X_Final <> Zoom.X_Inicio And Zoom.Y_Final <> Zoom.Y_Inicio Then
                    If Zoom.X_Final > Zoom.X_Inicio Then
                        'Actualisa el cursor y al valor en el textbox
                        TextBox_Registro_Parcial_Maximo.Text = Convert.ToString(Zoom.X_Final)
                        TextBox_Registro_Parcial_Minimo.Text = Convert.ToString(Zoom.X_Inicio)

                        Chart_Registro_Total.Series("Series_Max").Points(0).XValue = Zoom.X_Final
                        Chart_Registro_Total.Series("Series_Min").Points(0).XValue = Zoom.X_Inicio
                    Else
                        TextBox_Registro_Parcial_Maximo.Text = Convert.ToString(Zoom.X_Inicio)
                        TextBox_Registro_Parcial_Minimo.Text = Convert.ToString(Zoom.X_Final)
                        'Actualisa el cursor y al valor en el textbox
                        Chart_Registro_Total.Series("Series_Max").Points(0).XValue = Zoom.X_Inicio
                        Chart_Registro_Total.Series("Series_Min").Points(0).XValue = Zoom.X_Final

                    End If
                    Actualizar_Registro_Parcial()
                    If Zoom.Y_Final > Zoom.Y_Inicio Then
                        Chart_Registro_Parcial.ChartAreas(0).AxisY.Minimum = Zoom.Y_Inicio
                        Chart_Registro_Parcial.ChartAreas(0).AxisY.Maximum = Zoom.Y_Final
                    Else
                        Chart_Registro_Parcial.ChartAreas(0).AxisY.Minimum = Zoom.Y_Final
                        Chart_Registro_Parcial.ChartAreas(0).AxisY.Maximum = Zoom.Y_Inicio
                    End If
                End If


                'End If
            End If
        End If


    End Sub

    Private Sub CheckBox_Bloquear_Ventana_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Bloquear_Ventana.CheckedChanged
        If CheckBox_Bloquear_Ventana.Checked Then
            Zoom.X_Bloqueo_Ventana = (Convert.ToDouble(TextBox_Registro_Parcial_Maximo.Text) - Convert.ToDouble(TextBox_Registro_Parcial_Minimo.Text)) / 2
            Zoom.Y_Bloqueo_Ventana = (Chart_Registro_Parcial.ChartAreas(0).AxisY.Maximum - Chart_Registro_Parcial.ChartAreas(0).AxisY.Minimum) / 2

        End If
    End Sub

    Private Sub Chart_Registro_Parcial_MouseMove(sender As Object, e As MouseEventArgs) Handles Chart_Registro_Parcial.MouseMove
        If CheckBox_Bloquear_Ventana.Checked And Bandera_Cursores_Grafica_Parcial = 3 Then
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
            'Detecta cando se la sa una execion por salir del rango de la ventana
            Try
                posX = Chart_Registro_Parcial.ChartAreas(0).AxisX.PixelPositionToValue(posX)

                'Determina la posicion del mause en la grafica en respeto al eje Y
                'posY = Chart_Registro_Parcial.ChartAreas(0).AxisY.PixelPositionToValue(posY)

                Zoom.X_Inicio = posX - Zoom.X_Bloqueo_Ventana
                'Zoom.Y_Inicio = posY - Zoom.Y_Bloqueo_Ventana

                Zoom.X_Final = posX + Zoom.X_Bloqueo_Ventana
                'Zoom.Y_Final = posY + Zoom.Y_Bloqueo_Ventana

                If Zoom.X_Inicio < Grafica_Total.Min_Valor_X Then
                    Zoom.X_Inicio = Grafica_Total.Min_Valor_X
                    Zoom.X_Final = Grafica_Total.Min_Valor_X + 2 * Zoom.X_Bloqueo_Ventana
                ElseIf Zoom.X_Final > Grafica_Total.Max_Valor_X Then
                    Zoom.X_Inicio = Grafica_Total.Max_Valor_X - 2 * Zoom.X_Bloqueo_Ventana
                    Zoom.X_Final = Grafica_Total.Max_Valor_X
                End If

                'If Zoom.Y_Inicio < Grafica_Total.Min_Valor_Y Then
                '    Zoom.Y_Inicio = Grafica_Total.Min_Valor_Y
                '    Zoom.Y_Final = Grafica_Total.Min_Valor_Y + 2 * Zoom.Y_Bloqueo_Ventana
                'ElseIf Zoom.Y_Final > Grafica_Total.Max_Valor_Y Then
                '    Zoom.Y_Inicio = Grafica_Total.Max_Valor_Y - 2 * Zoom.Y_Bloqueo_Ventana
                '    Zoom.Y_Final = Grafica_Total.Max_Valor_Y
                'End If
                'Actualisa el cursor y al valor en el textbox
                TextBox_Registro_Parcial_Maximo.Text = Convert.ToString(Zoom.X_Final)
                TextBox_Registro_Parcial_Minimo.Text = Convert.ToString(Zoom.X_Inicio)

                Chart_Registro_Total.Series("Series_Min").Points(0).XValue = Zoom.X_Inicio
                Chart_Registro_Total.Series("Series_Max").Points(0).XValue = Zoom.X_Final
            Catch ex As Exception

            End Try

        ElseIf Zoom.Zoom_Activo = 1 Then
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
            Dim prueba = Chart_Registro_Parcial.ChartAreas(0).BorderWidth
            'Determina la posicion del mause en la grafica en respeto al eje X
            posX = Chart_Registro_Parcial.ChartAreas(0).AxisX.PixelPositionToValue(posX)

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


    End Sub

    Private Sub CheckBox_Cuadricula_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Cuadricula.CheckedChanged

        Dim Escala_X As Double
        Dim Escala_Y As Double


        If CheckBox_Cuadricula.Checked Then
            Select Case ComboBox_Cuadricula_ECG_Velocidad.SelectedIndex
                Case 0
                    Escala_X = 1 / 2
                Case 1
                    Escala_X = 1
                Case 2
                    Escala_X = 3 / 2
                Case 3
                    Escala_X = 2
                Case 4
                    Escala_X = 3
                Case 5
                    Escala_X = 4
                Case Else
                    Escala_X = 5
            End Select
            Chart_Registro_Parcial.ChartAreas(0).AxisX.MajorGrid.Interval = 0.2 * Escala_X
            Chart_Registro_Parcial.ChartAreas(0).AxisX.MinorGrid.Interval = 0.04 * Escala_X

            Chart_Registro_Parcial.ChartAreas(0).AxisX.MajorGrid.LineColor = Color.Silver
            Chart_Registro_Parcial.ChartAreas(0).AxisX.MinorGrid.LineColor = Color.LightGray

            Select Case ComboBox_Cuadricula_ECG_Ganancia.SelectedIndex
                Case 0
                    Escala_Y = 1 / 2
                Case 1
                    Escala_Y = 1
                Case 2
                    Escala_Y = 2
                Case 3
                    Escala_Y = 3
                Case 4
                    Escala_Y = 4
                Case Else
                    Escala_Y = 6
            End Select
            Chart_Registro_Parcial.ChartAreas(0).AxisY.MajorGrid.Interval = 0.5 * Escala_Y
            Chart_Registro_Parcial.ChartAreas(0).AxisY.MinorGrid.Interval = 0.1 * Escala_Y

            Chart_Registro_Parcial.ChartAreas(0).AxisY.MajorGrid.LineColor = Color.Silver
            Chart_Registro_Parcial.ChartAreas(0).AxisY.MinorGrid.LineColor = Color.LightGray



            Chart_Registro_Parcial.ChartAreas(0).AxisX.MajorGrid.Enabled = True
            Chart_Registro_Parcial.ChartAreas(0).AxisX.MinorGrid.Enabled = True
            Chart_Registro_Parcial.ChartAreas(0).AxisX.MinorTickMark.Enabled = True

            Chart_Registro_Parcial.ChartAreas(0).AxisY.MajorGrid.Enabled = True
            Chart_Registro_Parcial.ChartAreas(0).AxisY.MinorGrid.Enabled = True
            Chart_Registro_Parcial.ChartAreas(0).AxisY.MinorTickMark.Enabled = True

        Else
            Chart_Registro_Parcial.ChartAreas(0).AxisX.MajorGrid.Enabled = False
            Chart_Registro_Parcial.ChartAreas(0).AxisX.MinorGrid.Enabled = False
            Chart_Registro_Parcial.ChartAreas(0).AxisX.MinorTickMark.Enabled = False


            Chart_Registro_Parcial.ChartAreas(0).AxisY.MajorGrid.Enabled = False
            Chart_Registro_Parcial.ChartAreas(0).AxisY.MinorGrid.Enabled = False
            Chart_Registro_Parcial.ChartAreas(0).AxisY.MinorTickMark.Enabled = False


            'Chart_Registro_Parcial.Series("Cuadricula_Horizontal_Gruesa").Points.Clear()
            'Chart_Registro_Parcial.Series("Cuadricula_Horizontal").Points.Clear()
            'Chart_Registro_Parcial.Series("Cuadricula_Vertical_Gruesa").Points.Clear()
            'Chart_Registro_Parcial.Series("Cuadricula_Vertical").Points.Clear()
        End If

    End Sub

    Private Sub ComboBox_Cuadricula_ECG_Velocidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Cuadricula_ECG_Velocidad.SelectedIndexChanged
        If CheckBox_Cuadricula.Checked Then
            Dim Escala_X As Double

            Select Case ComboBox_Cuadricula_ECG_Velocidad.SelectedIndex
                Case 0
                    Escala_X = 1 / 2
                Case 1
                    Escala_X = 1
                Case 2
                    Escala_X = 3 / 2
                Case 3
                    Escala_X = 2
                Case 4
                    Escala_X = 3
                Case Else
                    Escala_X = 4
            End Select
            Chart_Registro_Parcial.ChartAreas(0).AxisX.MajorGrid.Interval = 0.2 * Escala_X
            Chart_Registro_Parcial.ChartAreas(0).AxisX.MinorGrid.Interval = 0.04 * Escala_X

        End If
    End Sub

    Private Sub ComboBox_Cuadricula_ECG_Ganancia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Cuadricula_ECG_Ganancia.SelectedIndexChanged
        If CheckBox_Cuadricula.Checked Then
            Dim Escala_Y As Double

            Select Case ComboBox_Cuadricula_ECG_Ganancia.SelectedIndex
                Case 0
                    Escala_Y = 1 / 2
                Case 1
                    Escala_Y = 1
                Case 2
                    Escala_Y = 2
                Case 3
                    Escala_Y = 3
                Case 4
                    Escala_Y = 4
                Case Else
                    Escala_Y = 6
            End Select
            Chart_Registro_Parcial.ChartAreas(0).AxisY.MajorGrid.Interval = 0.5 * Escala_Y
            Chart_Registro_Parcial.ChartAreas(0).AxisY.MinorGrid.Interval = 0.1 * Escala_Y
        End If

    End Sub

    Private Sub Button_Independizar_Ventana_Click(sender As Object, e As EventArgs) Handles Button_Independizar_Ventana.Click
        If Bandera_Anclaje = 0 Then
            Dim Modulo_Contenedor As New Form_Contenedor
            Modulo_Contenedor.Controls.Add(Me)
            'Me.Anchor = AnchorStyles.Left And AnchorStyles.Right And AnchorStyles.Top And AnchorStyles.Bottom
            Me.Anchor = AnchorStyles.Left And AnchorStyles.Right
            Me.Dock = DockStyle.Fill
            Me.Location = New Point(0, 0)
            'Modulo_Contenedor.MinimumSize = Modulo_Contenedor.Size

            Modulo_Contenedor.Show()
            Button_Cerrar.Visible = False

            Bandera_Anclaje = 1
        Else
            Dim Modulo_Contenedor As Form_Contenedor = Me.FindForm

            Form_Principal.SplitContainer_Principal.Panel2.Controls.Add(Me)
            Me.Anchor = AnchorStyles.Left And AnchorStyles.Right
            Me.Dock = DockStyle.Top
            Me.Location = New Point(0, 400)
            Modulo_Contenedor.Close()
            Button_Cerrar.Visible = True
            Bandera_Anclaje = 0
        End If
    End Sub


    Private Sub Button_Independizar_Ventana_MouseEnter(sender As Object, e As EventArgs) Handles Button_Independizar_Ventana.MouseEnter
        Button_Independizar_Ventana.BackgroundImage = My.Resources.Cambio_Boton
    End Sub

    Private Sub Button_Independizar_Ventana_MouseLeave(sender As Object, e As EventArgs) Handles Button_Independizar_Ventana.MouseLeave
        Button_Independizar_Ventana.BackgroundImage = Nothing
    End Sub

    Private Sub CheckBox_Estilo_Linea_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Estilo_Linea.CheckedChanged
        Actualizar_Registro_Parcial()
    End Sub


    Private Sub Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1_Click(sender As Object, e As EventArgs) Handles Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.Click
        'Bloquea la ventana de SplitContainer_Modulo_Grafico_Panel1 y le cambia la imagen del boton 
        If Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1 = True Then
            Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1 = False
            Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.BackgroundImage = My.Resources.Boton_Estrella_Vacia
            SplitContainer_Modulo_Grafico.SplitterDistance = 0
        Else
            Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1 = True
            Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.BackgroundImage = My.Resources.Boton_Estrella_Llena
            SplitContainer_Modulo_Grafico.SplitterDistance = SplitContainer_Modulo_Grafico.Width * 0.3
        End If
    End Sub

    Private Sub TabPageEX_Registros_Load(sender As Object, e As EventArgs) Handles TabPageEX_Registros.Load
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
            Dim Coneccion_Base_Datos As New SqlConnection
            Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
            Dim Paciente As DataSet
            Paciente = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Base_Datos, Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_"))

            ComboBox_Selecion_Paciente.Items.Clear()
            For i = 0 To Paciente.Tables("Datos_Pacientes").Rows.Count - 1
                ComboBox_Selecion_Paciente.Items.Add(Paciente.Tables("Datos_Pacientes").Rows(i)(0))
            Next i
            ''Identificar los registors existentes relacionados con el pacientes 
            'If ComboBox_Selecion_Paciente.Items.Count > 0 Then
            '    ComboBox_Selecion_Paciente.SelectedIndex = 0
            '    Dim Registros As DataSet
            '    Registros = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Usuarios, Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"))

            '    ComboBox_Selecionar_Registro.Items.Clear()
            '    For i = 0 To Registros.Tables(0).Rows.Count - 1
            '        ComboBox_Selecionar_Registro.Items.Add(Registros.Tables(0).Rows(i)(0))
            '    Next i
            'End If
            ''Identificar las derivaciones existentes relacionados con el Registro del pasiente
            'If ComboBox_Selecionar_Registro.Items.Count > 0 Then
            '    ComboBox_Selecionar_Registro.SelectedIndex = 0
            '    Dim Columnas_Existentes As List(Of String)
            '    Columnas_Existentes = Class_Funciones_Base_Datos.Columnas_Existentes_Tabla(Coneccion_Usuarios, Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_") + "___" + ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_") + "___" + ComboBox_Selecionar_Registro.Text.TrimEnd.Replace(" ", "_"))
            '    ComboBox_Selecionar_Derivacion.Items.Clear()

            '    For i = 0 To Columnas_Existentes.Count - 1
            '        If Columnas_Existentes.Item(i) <> "Puntero" Then
            '            ComboBox_Selecionar_Derivacion.Items.Add(Columnas_Existentes.Item(i))
            '        End If
            '    Next i
            'End If

            'If ComboBox_Selecionar_Derivacion.Items.Count > 0 Then
            '    ComboBox_Selecionar_Derivacion.SelectedIndex = 0
            'End If

            'Coneccion_Usuarios.Close()
        ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
            'Identificar los usuarios existentes
            Dim Coneccion_Base_Datos As New SqlConnection
            Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
            Dim Usuarios As DataSet
            Usuarios = Class_Funciones_Base_Datos.Tabla_Usuarios_Buscar_Usuarios(Coneccion_Base_Datos, "1")

            ComboBox_Selecion_Usuario.Items.Clear()
            For i = 0 To Usuarios.Tables("Usuarios").Rows.Count - 1
                ComboBox_Selecion_Usuario.Items.Add(Usuarios.Tables("Usuarios").Rows(i)(0))
            Next i
            'Identificar los pacientes existentes relacionados con el usuario 
            If ComboBox_Selecion_Usuario.Items.Count > 0 Then
                ComboBox_Selecion_Usuario.SelectedIndex = 0
                'Dim Paciente As DataSet
                'Paciente = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Usuarios, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"))

                'ComboBox_Selecion_Paciente.Items.Clear()

                'For i = 0 To Paciente.Tables("Datos_Pacientes").Rows.Count - 1
                '    ComboBox_Selecion_Paciente.Items.Add(Paciente.Tables("Datos_Pacientes").Rows(i)(0))
                'Next i

                ''Identificar los registors existentes relacionados con el pacientes 
                'If ComboBox_Selecion_Paciente.Items.Count > 0 Then
                '    ComboBox_Selecion_Paciente.SelectedIndex = 0
                '    Dim Registros As DataSet
                '    Registros = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Usuarios, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"))
                '    ComboBox_Selecionar_Registro.Items.Clear()
                '    For i = 0 To Registros.Tables(0).Rows.Count - 1
                '        ComboBox_Selecionar_Registro.Items.Add(Registros.Tables(0).Rows(i)(0))
                '    Next i
                'End If

                ''Identificar las derivaciones existentes relacionados con el Registro del pasiente
                'If ComboBox_Selecionar_Registro.Items.Count > 0 Then
                '    ComboBox_Selecionar_Registro.SelectedIndex = 0
                '    Dim Columnas_Existentes As List(Of String)
                '    Columnas_Existentes = Class_Funciones_Base_Datos.Columnas_Existentes_Tabla(Coneccion_Usuarios, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_") + "___" + ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_") + "___" + ComboBox_Selecionar_Registro.Text.TrimEnd.Replace(" ", "_"))
                '    ComboBox_Selecionar_Derivacion.Items.Clear()

                '    For i = 0 To Columnas_Existentes.Count - 1
                '        If Columnas_Existentes.Item(i) <> "Puntero" Then
                '            ComboBox_Selecionar_Derivacion.Items.Add(Columnas_Existentes.Item(i))
                '        End If
                '    Next i
                'End If

                'If ComboBox_Selecionar_Derivacion.Items.Count > 0 Then
                '    ComboBox_Selecionar_Derivacion.SelectedIndex = 0
                'End If
                'Coneccion_Usuarios.Close()
            End If
        End If

    End Sub

    Private Sub ComboBox_Selecionar_Registro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Selecionar_Registro.SelectedIndexChanged
        Dim Coneccion_Base_Datos As New SqlConnection
        Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
        If Form_Principal.Usuario_Activo.Tipo_Usuario = 1 Then

            Dim Columnas_Existentes As List(Of String)
            Columnas_Existentes = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Derivaciones_Registro(Coneccion_Base_Datos, Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"), ComboBox_Selecionar_Registro.Text.TrimEnd.Replace(" ", "_"))
            ComboBox_Selecionar_Derivacion.Items.Clear()

            For i = 0 To Columnas_Existentes.Count - 1
                If Columnas_Existentes.Item(i) <> "Puntero" Then
                    ComboBox_Selecionar_Derivacion.Items.Add(Columnas_Existentes.Item(i))
                End If
            Next i

            If ComboBox_Selecionar_Derivacion.Items.Count > 0 Then
                ComboBox_Selecionar_Derivacion.SelectedIndex = 0
            End If
        ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
            Dim Columnas_Existentes As List(Of String)
            Columnas_Existentes = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Derivaciones_Registro(Coneccion_Base_Datos, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"), ComboBox_Selecionar_Registro.Text.TrimEnd.Replace(" ", "_"))
            ComboBox_Selecionar_Derivacion.Items.Clear()

            For i = 0 To Columnas_Existentes.Count - 1
                If Columnas_Existentes.Item(i) <> "Puntero" Then
                    ComboBox_Selecionar_Derivacion.Items.Add(Columnas_Existentes.Item(i))
                End If
            Next i

            If ComboBox_Selecionar_Derivacion.Items.Count > 0 Then
                ComboBox_Selecionar_Derivacion.SelectedIndex = 0
            End If

        End If
    End Sub

    Private Sub ComboBox_Registro_Graficado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Registro_Graficado.SelectedIndexChanged
        '-------------------------------------------------------------------------------------------------------
        'Buscar Registro registro
        '-------------------------------------------------------------------------------------------------------
        'Registro_Tabla = Registro_Parciales_Graficados(Index).Nombre_Tabla
        'Registro_Columna = Registro_Parciales_Graficados(Index).Nombre_Columna
        'Registro_Frecuencia = Registro_Parciales_Graficados(Index).Frecuencia
        'Color = Registro_Parciales_Graficados(Index).Color
        For Index = 0 To (Registro_Parciales_Graficados.Count - 1)
            If Registro_Parciales_Graficados(Index).Nombre_Tabla + "___" + Registro_Parciales_Graficados(Index).Nombre_Columna = ComboBox_Registro_Graficado.Text Then
                Dim Coneccion_Base_Datos As New SqlConnection
                Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
                Dim Datos_Paciente As String = ""
                Panel_Color_Registro_Graficado.BackColor = Registro_Parciales_Graficados(Index).Color
                Dim Peso_kg, Estatura_cm, Sexo, Raza, Fecha_Nacimiento_Dia, Fecha_Nacimiento_Mes, Fecha_Nacimiento_Año, Detalles_Paciente, Marca_Paso As String
                Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Datos_Paciente(Coneccion_Base_Datos, Registro_Parciales_Graficados(Index).Usuario, Registro_Parciales_Graficados(Index).Paciente, Peso_kg, Estatura_cm, Sexo, Raza, Fecha_Nacimiento_Dia, Fecha_Nacimiento_Mes, Fecha_Nacimiento_Año, Detalles_Paciente, Marca_Paso)
                Datos_Paciente = Datos_Paciente + "Name:" + Chr(13) + Registro_Parciales_Graficados(Index).Paciente + Chr(13)
                Datos_Paciente = Datos_Paciente + "Birthdate:" + Chr(13) + Fecha_Nacimiento_Dia + "/" + Fecha_Nacimiento_Mes + "/" + Fecha_Nacimiento_Año + Chr(13)
                Datos_Paciente = Datos_Paciente + "Weight(Kg):" + Chr(13) + Peso_kg + Chr(13)
                Datos_Paciente = Datos_Paciente + "Height(cm):" + Chr(13) + Estatura_cm + Chr(13)
                Datos_Paciente = Datos_Paciente + "Gender:" + Chr(13) + Sexo + Chr(13)
                Datos_Paciente = Datos_Paciente + "Race:" + Chr(13) + Raza + Chr(13)
                Datos_Paciente = Datos_Paciente + "Pacemaker:" + Chr(13) + Marca_Paso + Chr(13)
                Datos_Paciente = Datos_Paciente + "Patient Details:" + Chr(13) + Detalles_Paciente + Chr(13)
                RichTextBox_Datos_Paciente.Text = Datos_Paciente
            End If
        Next
    End Sub

    Private Sub Panel_Registro_Graficado_DoubleClick(sender As Object, e As EventArgs) Handles Panel_Color_Registro_Graficado.DoubleClick
        Dim Moficar_Color As New Form_Paleta_Colores
        Moficar_Color.Form_Activar_Paleta(Me)
    End Sub
    Private Sub Panel_Color_Registro_Graficado_MouseEnter(sender As Object, e As EventArgs) Handles Panel_Color_Registro_Graficado.MouseEnter
        Panel_Color_Registro_Graficado_Fondo.BackColor = Color.DarkSlateBlue
    End Sub

    Private Sub Panel_Color_Registro_Graficado_MouseLeave(sender As Object, e As EventArgs) Handles Panel_Color_Registro_Graficado.MouseLeave
        Panel_Color_Registro_Graficado_Fondo.BackColor = Color.Transparent
    End Sub

    Private Sub Button_Borrar_Un_Registro_Click(sender As Object, e As EventArgs) Handles Button_Borrar_Un_Registro.Click
        If Registro_Parciales_Graficados.Count > 0 Then
            For Index = Registro_Parciales_Graficados.Count - 1 To 0 Step -1
                If Registro_Parciales_Graficados(Index).Nombre_Tabla + "___" + Registro_Parciales_Graficados(Index).Nombre_Columna = ComboBox_Registro_Graficado.Text Then
                    Chart_Registro_Parcial.Series.Remove(Chart_Registro_Parcial.Series(Registro_Parciales_Graficados(Index).Nombre_Tabla + "___" + Registro_Parciales_Graficados(Index).Nombre_Columna))
                    Chart_Registro_Total.Series.Remove(Chart_Registro_Total.Series(Registro_Parciales_Graficados(Index).Nombre_Tabla + "___" + Registro_Parciales_Graficados(Index).Nombre_Columna))

                    Registro_Parciales_Graficados.RemoveAt(Index)
                    ComboBox_Registro_Modificar.Items.RemoveAt(ComboBox_Registro_Graficado.SelectedIndex)
                    Panel_Color_Registro_Modificar.BackColor = Color.Transparent

                    ComboBox_Registro_Graficado.Items.RemoveAt(ComboBox_Registro_Graficado.SelectedIndex)
                    Panel_Color_Registro_Graficado.BackColor = Color.Transparent


                    RichTextBox_Datos_Paciente.Text = ""
                    If Registro_Parciales_Graficados.Count = 0 Then
                        Chart_Registro_Parcial.Series.Clear()
                        ComboBox_Registro_Graficado.Items.Clear()
                        ComboBox_Registro_Modificar.Items.Clear()
                    Else
                        ComboBox_Registro_Graficado.SelectedIndex = ComboBox_Registro_Graficado.Items.Count - 1
                        ComboBox_Registro_Modificar.SelectedIndex = ComboBox_Registro_Modificar.Items.Count - 1
                    End If
                    Actualizar_Registro_Parcial()
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub ComboBox_Tamaño_Letra_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Tamaño_Letra.SelectedIndexChanged
        Dim Tamaño_Letra As New Font(Convert.ToString(ComboBox_Tamaño_Letra.Text), Convert.ToInt16(ComboBox_Tamaño_Letra.Text))
        RichTextBox_Datos_Paciente.Font = Tamaño_Letra
    End Sub
    Private Sub CheckAllChildNodes(treeNode As TreeNode, nodeChecked As Boolean)

        ' Actualiza de forma recursiva todos los nodos hijos.
        '
        For Each node As TreeNode In treeNode.Nodes
            node.Checked = nodeChecked
            If (node.Nodes.Count > 0) Then
                ' Si el node actual tiene nodos hijos, llamar
                ' recursivamente al método CheckAllChildNodes.
                Me.CheckAllChildNodes(node, nodeChecked)
            End If
        Next

    End Sub
    Private Sub TreeView1_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView_Graficar.AfterCheck
        ' El código sólo se ejecutará si el usuario causó
        ' el cambio del estado de verificación del nodo.
        If (e.Action = TreeViewAction.Unknown) Then Return
        If (e.Node.Nodes.Count > 0) Then
            ' Llama al método CheckAllChildNodes, pasando el valor actual
            ' Chequeado del TreeNode cuyo estado marcado ha cambiado.
            Me.CheckAllChildNodes(e.Node, e.Node.Checked)

        Else
            ' Nodo padre del nodo hijo actual.
            Dim parent As TreeNode = e.Node.Parent
            If (Not parent Is Nothing) Then
                ' El nodo tiene un nodo padre válido.
                '
                If (Not e.Node.Checked) Then
                    ' El nodo hijo no está marcado; eliminamos la marca de
                    ' de verificación de su nodo padre.
                    parent.Checked = Nothing

                Else
                    ' El nodo hijo está marcado; comprobamos si los restantes
                    ' nodos hijos están marcados para marcar también el
                    ' nodo padre.
                    '
                    Dim items As TreeNode() = (From item As TreeNode In parent.Nodes.OfType(Of TreeNode)()
                                               Where item.Checked
                                               Select item).ToArray()

                    parent.Checked = (items.Count = parent.Nodes.Count)

                End If
            End If

        End If
        Actualizar_Registro_Parcial()
    End Sub

    Private Sub ComboBox_Registro_Modificar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Registro_Modificar.SelectedIndexChanged
        Actualizar_Tabla_DataGridView_Registro_Modificar()
    End Sub

    Private Sub Button_Buscar_Ondas_Click(sender As Object, e As EventArgs) Handles Button_Buscar_Ondas.Click
        Dim Filas_Selecionadas = DataGridView_Registro_Modificar.SelectedRows
        Dim RowIndex = Filas_Selecionadas(0).Index
        'Dim RowIndex = Filas_Selecionadas(0).RowIndex
        'Filas_Selecionadas.Count
        If Filas_Selecionadas.Count = 1 Then
            If RowIndex = 0 Then
                If DataGridView_Registro_Modificar(1, RowIndex).Value - 0.4 < 0 Then
                    TextBox_Registro_Parcial_Minimo.Text = Convert.ToString("0")
                Else
                    TextBox_Registro_Parcial_Minimo.Text = Convert.ToString(DataGridView_Registro_Modificar(1, RowIndex).Value - 0.4)
                End If
                'TextBox_Registro_Parcial_Minimo.Text = Convert.ToString("0")
                TextBox_Registro_Parcial_Maximo.Text = Convert.ToString(DataGridView_Registro_Modificar(DataGridView_Registro_Modificar.Columns.Count - 2, RowIndex).Value + 0.75)
                'ElseIf RowIndex = DataGridView_Registro_Modificar.Rows.Count - 2 Then
                '    TextBox_Registro_Parcial_Minimo.Text = Convert.ToString(DataGridView_Registro_Modificar(1, RowIndex).Value - 0.1)
                '    TextBox_Registro_Parcial_Maximo.Text = Convert.ToString(DataGridView_Registro_Modificar(DataGridView_Registro_Modificar.Columns.Count - 2, RowIndex).Value + 0.1)
            Else
                TextBox_Registro_Parcial_Minimo.Text = Convert.ToString(DataGridView_Registro_Modificar(1, RowIndex).Value - 0.4)
                TextBox_Registro_Parcial_Maximo.Text = Convert.ToString(DataGridView_Registro_Modificar(DataGridView_Registro_Modificar.Columns.Count - 2, RowIndex).Value + 0.4)
            End If
        ElseIf Filas_Selecionadas.Count > 1 Then
            Dim Min_temp As Double = 999999999999
            Dim Max_temp As Double = 0
            For Index = 0 To Filas_Selecionadas.Count - 1
                If DataGridView_Registro_Modificar(1, Filas_Selecionadas(Index).Index).Value < Min_temp Then
                    Min_temp = DataGridView_Registro_Modificar(1, Filas_Selecionadas(Index).Index).Value
                End If
                If DataGridView_Registro_Modificar(1, Filas_Selecionadas(Index).Index).Value > Max_temp Then
                    Max_temp = DataGridView_Registro_Modificar(DataGridView_Registro_Modificar.Columns.Count - 2, Filas_Selecionadas(Index).Index).Value
                End If

            Next
            '    TextBox_Registro_Parcial_Minimo.Text = Convert.ToString(DataGridView_Registro_Modificar(1, RowIndex - Filas_Selecionadas.Count + 1).Value - 0.2)
            '    TextBox_Registro_Parcial_Maximo.Text = Convert.ToString(DataGridView_Registro_Modificar(DataGridView_Registro_Modificar.Columns.Count - 2, RowIndex).Value + 0.2)
            TextBox_Registro_Parcial_Minimo.Text = Convert.ToString(Min_temp - 0.4)
            TextBox_Registro_Parcial_Maximo.Text = Convert.ToString(Max_temp + 0.4)
        End If

        Call TextBox_Registro_Parcial_Maximo_KeyUp(sender, Nothing)
        Call TextBox_Registro_Parcial_Minimo_KeyUp(sender, Nothing)
        Dim kea As New KeyPressEventArgs(Convert.ToChar(13))
        Call TextBox_Registro_Parcial_Maximo_KeyPress(sender, kea)
        ' Filas_Selecionadas.rows.co
        'If Filas_Selecionadas.Item.co Then
    End Sub
    Private Sub Button_Eliminar_Ondas_Click(sender As Object, e As EventArgs) Handles Button_Eliminar_Ondas.Click
        Dim Filas_Selecionadas = DataGridView_Registro_Modificar.SelectedRows
        Dim Minimo_Index = Filas_Selecionadas(0).Index
        'Se eliminan las filas selecionadas 
        For Index = Filas_Selecionadas.Count - 1 To 0 Step -1
            If Minimo_Index > Filas_Selecionadas(Index).Index Then
                'Se obtine la pocicion menor celda eliminada
                Minimo_Index = Filas_Selecionadas(Index).Index
            End If
            DataGridView_Registro_Modificar.Rows.RemoveAt(Filas_Selecionadas(Index).Index)
        Next

        'Se marca la poscion de la menor celda eliminada
        If Minimo_Index = 0 Then
            DataGridView_Registro_Modificar.Rows(0).DefaultCellStyle.BackColor = Color.Red
        ElseIf Minimo_Index < DataGridView_Registro_Modificar.Rows.Count - 2 Then
            DataGridView_Registro_Modificar.Rows(Minimo_Index).DefaultCellStyle.BackColor = Color.Red
            DataGridView_Registro_Modificar.Rows(Minimo_Index - 1).DefaultCellStyle.BackColor = Color.Red
        Else
            DataGridView_Registro_Modificar.Rows(DataGridView_Registro_Modificar.Rows.Count - 2).DefaultCellStyle.BackColor = Color.Red
        End If
        'No se actaulizo el indice por que se demora mucho el procedimiento segun el seiguiente algoritmo
        'DataGridView_Registro_Modificar.BeginEdit(True)
        'For Index = Minimo_Index To DataGridView_Registro_Modificar.Rows.Count - 2
        '    DataGridView_Registro_Modificar.Rows(Index).Cells(0).Value = Index + 1
        'Next
        'DataGridView_Registro_Modificar.EndEdit(True)

    End Sub

    Private Sub RadioButton_QRS_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_QRS.CheckedChanged
        If RadioButton_QRS.Checked Then
            Actualizar_Tabla_DataGridView_Registro_Modificar()
        End If
    End Sub


    Private Sub Button_Modificar_Datos_Click(sender As Object, e As EventArgs) Handles Button_Modificar_Datos.Click
        Dim Filas_Selecionadas = DataGridView_Registro_Modificar.SelectedRows
        If Filas_Selecionadas.Count = 1 Then
            Dim RowIndex = Filas_Selecionadas(0).Index
            Dim Datos_Tabla As DataSet
            Dim Tabla_Consulta As String
            Dim Max_Puntero As Int64
            Dim Modificar_Uvicacion_Onda As New Form_Modificar_Puntos_Registro
            '-------------------------------------------------------------------------------------------------------
            'Buscar Registro registro
            '-------------------------------------------------------------------------------------------------------
            'Registro_Tabla = Registro_Parciales_Graficados(Index).Nombre_Tabla
            'Registro_Columna = Registro_Parciales_Graficados(Index).Nombre_Columna
            'Registro_Frecuencia = Registro_Parciales_Graficados(Index).Frecuencia
            'Color = Registro_Parciales_Graficados(Index).Color
            For Index = 0 To (Registro_Parciales_Graficados.Count - 1)
                If Registro_Parciales_Graficados(Index).Nombre_Tabla + "___" + Registro_Parciales_Graficados(Index).Nombre_Columna = ComboBox_Registro_Modificar.Text Then
                    'Crear una conexcion
                    Dim Coneccion_Registro As New SqlConnection
                    Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Registro_Parciales_Graficados(Index).Usuario, Registro_Parciales_Graficados(Index).Paciente, Registro_Parciales_Graficados(Index).Fecha_Registro, Registro_Parciales_Graficados(Index).Nombre_Columna)
                    'Obtener la tabla a consultar

                    If RadioButton_QRS.Checked Then
                        Tabla_Consulta = Registro_Parciales_Graficados(Index).Nombre_Tabla + "___Complejo_QRS"
                    End If

                    'Obtener al valor maximo de Puntero de la tabla 
                    Max_Puntero = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Consulta)

                    'Obtner los datos del registro  modificar
                    Modificar_Uvicacion_Onda.Registro_Modificar_1.Nombre_Tabla = Registro_Parciales_Graficados(Index).Nombre_Tabla
                    Modificar_Uvicacion_Onda.Registro_Modificar_1.Nombre_Columna = Registro_Parciales_Graficados(Index).Nombre_Columna
                    Modificar_Uvicacion_Onda.Registro_Modificar_1.Usuario = Registro_Parciales_Graficados(Index).Usuario
                    Modificar_Uvicacion_Onda.Registro_Modificar_1.Paciente = Registro_Parciales_Graficados(Index).Paciente
                    Modificar_Uvicacion_Onda.Registro_Modificar_1.Fecha_Registro = Registro_Parciales_Graficados(Index).Fecha_Registro
                    Modificar_Uvicacion_Onda.Registro_Modificar_1.Frecuencia = Registro_Parciales_Graficados(Index).Frecuencia
                    Modificar_Uvicacion_Onda.Registro_Modificar_1.Color = Registro_Parciales_Graficados(Index).Color
                    'Obtner los margenes minimo y maximo segun la pocion del punto Inicio, FInla y intermedio
                    If DataGridView_Registro_Modificar(0, RowIndex).Value = 1 Then
                        'Caso de que se agrega un dato antes de la primera detecion
                        Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X = DataGridView_Registro_Modificar(1, RowIndex).Value - 2
                        Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Max_X = DataGridView_Registro_Modificar(DataGridView_Registro_Modificar.Columns.Count - 2, RowIndex).Value + 0.2
                        If Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X < 0 Then
                            Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X = 0
                        End If

                    ElseIf DataGridView_Registro_Modificar(0, RowIndex).Value = Max_Puntero Then
                        'Caso de que se agrega un dato despues de la ultima detecion
                        Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X = DataGridView_Registro_Modificar(1, RowIndex).Value - 0.2
                        Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Max_X = DataGridView_Registro_Modificar(DataGridView_Registro_Modificar.Columns.Count - 2, RowIndex).Value + 2
                        If Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Max_X > Registro_Parciales_Graficados(Index).Cantidad_Maxima_Datos / Registro_Parciales_Graficados(Index).Frecuencia Then
                            Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Max_X = Registro_Parciales_Graficados(Index).Cantidad_Maxima_Datos / Registro_Parciales_Graficados(Index).Frecuencia
                        End If
                    Else
                        Datos_Tabla = Class_Funciones_Base_Datos.Registro_Consultar_Tabla_Puntero(Coneccion_Registro, Tabla_Consulta, 1, DataGridView_Registro_Modificar(0, RowIndex).Value - 1, DataGridView_Registro_Modificar(0, RowIndex).Value + 1)
                        Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X = Datos_Tabla.Tables(0).Rows(0)(Datos_Tabla.Tables(0).Columns.Count - 2) / Registro_Parciales_Graficados(Index).Frecuencia
                        Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Max_X = Datos_Tabla.Tables(0).Rows(2)(1) / Registro_Parciales_Graficados(Index).Frecuencia
                    End If
                    Exit For
                End If
            Next
            'LLamar el for modificar segun el tioppo de onda  que se ba a modificar
            If RadioButton_QRS.Checked Then
                Modificar_Uvicacion_Onda.Form_Registro_Parciales_Modificar(Me.ParentForm, Me, True, 1, RowIndex, Class_Analisis_Registro.Tipo_Onda_P_QRS_T_To_int(DataGridView_Registro_Modificar(DataGridView_Registro_Modificar.Columns.Count - 1, RowIndex).Value), DataGridView_Registro_Modificar(1, RowIndex).Value, DataGridView_Registro_Modificar(2, RowIndex).Value, DataGridView_Registro_Modificar(3, RowIndex).Value, DataGridView_Registro_Modificar(4, RowIndex).Value, DataGridView_Registro_Modificar(5, RowIndex).Value)
            End If
        End If

    End Sub

    Private Sub Agregar_Punto_Click(sender As Object, e As EventArgs) Handles Button_Agregar_Punto.Click
        Dim Filas_Selecionadas = DataGridView_Registro_Modificar.SelectedRows
        Dim RowIndex = Filas_Selecionadas(0).Index
        Dim Tabla_Consulta As String
        Dim Max_Puntero As Int64
        Dim Datos_Tabla As DataSet

        If Filas_Selecionadas.Count = 2 Or Filas_Selecionadas.Count = 1 Then
            Dim Modificar_Uvicacion_Onda As New Form_Modificar_Puntos_Registro
            If Filas_Selecionadas.Count = 2 Then

                If DataGridView_Registro_Modificar(0, Filas_Selecionadas(0).Index).Value > DataGridView_Registro_Modificar(0, Filas_Selecionadas(1).Index).Value Then
                    RowIndex = Filas_Selecionadas(0).Index
                Else
                    RowIndex = Filas_Selecionadas(1).Index
                End If
                'If Filas_Selecionadas(0).Index > Filas_Selecionadas(1).Index Then
                '    RowIndex = Filas_Selecionadas(0).Index
                'Else
                '    RowIndex = Filas_Selecionadas(1).Index
                'End If
            End If
            '-------------------------------------------------------------------------------------------------------
            'Buscar Registro registro
            '-------------------------------------------------------------------------------------------------------
            'Registro_Tabla = Registro_Parciales_Graficados(Index).Nombre_Tabla
            'Registro_Columna = Registro_Parciales_Graficados(Index).Nombre_Columna
            'Registro_Frecuencia = Registro_Parciales_Graficados(Index).Frecuencia
            'Color = Registro_Parciales_Graficados(Index).Color
            For Index = 0 To (Registro_Parciales_Graficados.Count - 1)
                If Registro_Parciales_Graficados(Index).Nombre_Tabla + "___" + Registro_Parciales_Graficados(Index).Nombre_Columna = ComboBox_Registro_Modificar.Text Then
                    'Obtner la conexcion al registro
                    Dim Coneccion_Registro As New SqlConnection
                    Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Registro_Parciales_Graficados(Index).Usuario, Registro_Parciales_Graficados(Index).Paciente, Registro_Parciales_Graficados(Index).Fecha_Registro, Registro_Parciales_Graficados(Index).Nombre_Columna)

                    'Obtner los datos del registro  modificar
                    Modificar_Uvicacion_Onda.Registro_Modificar_1.Nombre_Tabla = Registro_Parciales_Graficados(Index).Nombre_Tabla
                    Modificar_Uvicacion_Onda.Registro_Modificar_1.Nombre_Columna = Registro_Parciales_Graficados(Index).Nombre_Columna
                    Modificar_Uvicacion_Onda.Registro_Modificar_1.Usuario = Registro_Parciales_Graficados(Index).Usuario
                    Modificar_Uvicacion_Onda.Registro_Modificar_1.Paciente = Registro_Parciales_Graficados(Index).Paciente
                    Modificar_Uvicacion_Onda.Registro_Modificar_1.Fecha_Registro = Registro_Parciales_Graficados(Index).Fecha_Registro
                    Modificar_Uvicacion_Onda.Registro_Modificar_1.Frecuencia = Registro_Parciales_Graficados(Index).Frecuencia
                    Modificar_Uvicacion_Onda.Registro_Modificar_1.Color = Registro_Parciales_Graficados(Index).Color

                    'Obtener la tabla a consultar

                    If RadioButton_QRS.Checked Then
                        Tabla_Consulta = Registro_Parciales_Graficados(Index).Nombre_Tabla + "___Complejo_QRS"
                    End If

                    'Obtener al valor maximo de Puntero de la tabla 
                    Max_Puntero = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Tabla_Consulta)

                    'Obtner los margenes minimo y maximo segun la pocion del punto Inicio, FInla y intermedio

                    If DataGridView_Registro_Modificar(0, RowIndex).Value = 1 Then
                        'Caso de que se agrega un dato antes de la primera detecion
                        Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X = DataGridView_Registro_Modificar(1, RowIndex).Value - 2
                        Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Max_X = DataGridView_Registro_Modificar(1, RowIndex).Value
                        If Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X < 0 Then
                            Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X = 0
                        End If
                    ElseIf DataGridView_Registro_Modificar(0, RowIndex).Value = Max_Puntero Then
                        'Caso de que se agrega un dato despues de la ultima detecion
                        Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X = DataGridView_Registro_Modificar(DataGridView_Registro_Modificar.Columns.Count - 2, RowIndex).Value
                        Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Max_X = DataGridView_Registro_Modificar(DataGridView_Registro_Modificar.Columns.Count - 2, RowIndex).Value + 2
                        If Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Max_X > Registro_Parciales_Graficados(Index).Cantidad_Maxima_Datos / Registro_Parciales_Graficados(Index).Frecuencia Then
                            Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Max_X = Registro_Parciales_Graficados(Index).Cantidad_Maxima_Datos / Registro_Parciales_Graficados(Index).Frecuencia
                        End If
                    Else
                        Datos_Tabla = Class_Funciones_Base_Datos.Registro_Consultar_Tabla_Puntero(Coneccion_Registro, Tabla_Consulta, 1, DataGridView_Registro_Modificar(0, RowIndex).Value - 1, DataGridView_Registro_Modificar(0, RowIndex).Value)
                        Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X = Datos_Tabla.Tables(0).Rows(0)(Datos_Tabla.Tables(0).Columns.Count - 2) / Registro_Parciales_Graficados(Index).Frecuencia
                        Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Max_X = Datos_Tabla.Tables(0).Rows(1)(1) / Registro_Parciales_Graficados(Index).Frecuencia


                        'If RowIndex = 0 And DataGridView_Registro_Modificar(0, RowIndex).Value > 2 Then
                        '    'Caso de que se agrega un dato en los limites del DataGridView
                        'Else
                        '    'Caso de que se agrega un entre dos deteciones ubicadas fuera del  DataGridView
                        '    Datos_Tabla = Class_Funciones_Base_Datos.Registro_Consultar_Tabla_Puntero(Coneccion_Registro, Tabla_Consulta, 1, DataGridView_Registro_Modificar(0, RowIndex).Value, DataGridView_Registro_Modificar(0, RowIndex).Value + 1)
                        '    Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X = Datos_Tabla.Tables(0).Rows(0)(Datos_Tabla.Tables(0).Columns.Count - 2) / Registro_Parciales_Graficados(Index).Frecuencia
                        '    Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Max_X = Datos_Tabla.Tables(0).Rows(1)(1) / Registro_Parciales_Graficados(Index).Frecuencia
                        'End If
                    End If
                End If
            Next
            'LLamar el for modificar segun el tioppo de onda  que se ba a modificar

            If RadioButton_QRS.Checked Then
                Modificar_Uvicacion_Onda.Form_Registro_Parciales_Modificar(Me.ParentForm, Me, False, 1, RowIndex,, Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X + 0.9 * (Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Max_X - Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X) / 2, Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X + 0.7 * (Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Max_X - Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X) / 2, Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X + 0.5 * (Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Max_X - Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X) / 2, Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X + 0.3 * (Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Max_X - Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X) / 2, Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X + 0.1 * (Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Max_X - Modificar_Uvicacion_Onda.Registro_Modificar_1.Intervalo_Min_X) / 2)
            End If


        End If
    End Sub

    Private Sub Button_Actualizar_Cambios_Click(sender As Object, e As EventArgs) Handles Button_Actualizar_Cambios.Click

        For Index = 0 To (Registro_Parciales_Graficados.Count - 1)
            If Registro_Parciales_Graficados(Index).Nombre_Tabla + "___" + Registro_Parciales_Graficados(Index).Nombre_Columna = ComboBox_Registro_Modificar.Text Then
                Dim Puntero As Int64 = 1
                Const Max_Datos_Almacenar = 10000
                Dim Coneccion_Registro As New SqlConnection
                Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Registro_Parciales_Graficados(Index).Usuario, Registro_Parciales_Graficados(Index).Paciente, Registro_Parciales_Graficados(Index).Fecha_Registro, Registro_Parciales_Graficados(Index).Nombre_Columna)
                Dim Datos_Tabla As DataSet


                If RadioButton_QRS.Checked Then
                    Dim frecuencia As Int64 = Registro_Parciales_Graficados(Index).Frecuencia
                    Dim Tabla_Datos As New DataTable()
                    Tabla_Datos.Columns.Add(New DataColumn("Puntero", GetType(System.Int32)))
                    Tabla_Datos.Columns.Add(New DataColumn("Q_i", GetType(System.Int32)))
                    Tabla_Datos.Columns.Add(New DataColumn("Q", GetType(System.Int32)))
                    Tabla_Datos.Columns.Add(New DataColumn("R", GetType(System.Int32)))
                    Tabla_Datos.Columns.Add(New DataColumn("S", GetType(System.Int32)))
                    Tabla_Datos.Columns.Add(New DataColumn("J", GetType(System.Int32)))
                    Tabla_Datos.Columns.Add(New DataColumn("Tipo_QRS", GetType(System.Int32)))

                    Dim Tabla_Almacenamiento_Resultados As String = Registro_Parciales_Graficados(Index).Nombre_Tabla + "___Complejo_QRS_Temp"
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_Almacenamiento_Resultados)
                    '------------------------------------------------
                    'Ordeno el DataGridView por la primera columna diferente de Puntero
                    '------------------------------------------------
                    DataGridView_Registro_Modificar.Sort(DataGridView_Registro_Modificar.Columns(1), 0)

                    '------------------------------------------------
                    'Creacion de Tabla de almacenamiento
                    '------------------------------------------------
                    Class_Funciones_Base_Datos.Registros_Crear_Tabla_QRS(Coneccion_Registro, Tabla_Almacenamiento_Resultados)
                    '------------------------------------------------
                    'Guardar dese el inicio del registro asta llegar al inicio del la tabla temp
                    '------------------------------------------------
                    Datos_Tabla = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Registro_Parciales_Graficados(Index).Nombre_Tabla + "___Complejo_QRS", "Q_i, Q, R, S, J,Tipo_QRS", Convert.ToString(0), Convert.ToString(DataGridView_Registro_Valor_Min - 1))
                    For Index1 = 0 To Datos_Tabla.Tables(0).Rows.Count - 1
                        Tabla_Datos.Rows.Add(Puntero, Datos_Tabla.Tables(0).Rows(Index1)(1), Datos_Tabla.Tables(0).Rows(Index1)(2), Datos_Tabla.Tables(0).Rows(Index1)(3), Datos_Tabla.Tables(0).Rows(Index1)(4), Datos_Tabla.Tables(0).Rows(Index1)(5), Datos_Tabla.Tables(0).Rows(Index1)(6))
                        If Puntero Mod Max_Datos_Almacenar = 0 Then
                            Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Registro, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                            Tabla_Datos.Rows.Clear()
                            Tabla_Datos.AcceptChanges()
                        End If
                        Puntero = Puntero + 1
                    Next
                    '------------------------------------------------
                    'Guardar los datos en la tabla temporal
                    '------------------------------------------------

                    For Index1 = 0 To DataGridView_Registro_Modificar.Rows.Count - 2
                        Tabla_Datos.Rows.Add(Puntero, DataGridView_Registro_Modificar(1, Index1).Value * frecuencia, DataGridView_Registro_Modificar(2, Index1).Value * frecuencia, DataGridView_Registro_Modificar(3, Index1).Value * frecuencia, DataGridView_Registro_Modificar(4, Index1).Value * frecuencia, DataGridView_Registro_Modificar(5, Index1).Value * frecuencia, Class_Analisis_Registro.Tipo_Onda_P_QRS_T_To_int(DataGridView_Registro_Modificar(6, Index1).Value))
                        '------------------------------------------------
                        'Guardar los datos en la tabla  de la base de datos
                        '------------------------------------------------
                        If Puntero Mod Max_Datos_Almacenar = 0 Then
                            Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Registro, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                            Tabla_Datos.Rows.Clear()
                            Tabla_Datos.AcceptChanges()
                        End If
                        Puntero = Puntero + 1
                    Next

                    '------------------------------------------------
                    'Guardar del final de la tabla al final de registro
                    '------------------------------------------------
                    Datos_Tabla = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Registro_Parciales_Graficados(Index).Nombre_Tabla + "___Complejo_QRS", "Q_i, Q, R, S, J,Tipo_QRS", Convert.ToString(DataGridView_Registro_Valor_Max + 1), Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Registro_Parciales_Graficados(Index).Nombre_Tabla + "___Complejo_QRS"))

                    'Datos_Tabla = Class_Funciones_Base_Datos.Registro_Consultar(Coneccion_Registro, Registro_Parciales_Graficados(Index).Nombre_Tabla + "___Complejo_QRS", "Q_i, Q, R, S, J,Tipo_QRS", Convert.ToString(DataGridView_Registro_Modificar.Rows.Count - 2 + 1), Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Registro_Parciales_Graficados(Index).Nombre_Tabla + "___Complejo_QRS"))
                    For Index1 = 0 To Datos_Tabla.Tables(0).Rows.Count - 1
                        Tabla_Datos.Rows.Add(Puntero, Datos_Tabla.Tables(0).Rows(Index1)(1), Datos_Tabla.Tables(0).Rows(Index1)(2), Datos_Tabla.Tables(0).Rows(Index1)(3), Datos_Tabla.Tables(0).Rows(Index1)(4), Datos_Tabla.Tables(0).Rows(Index1)(5), Datos_Tabla.Tables(0).Rows(Index1)(6))
                        If Puntero Mod Max_Datos_Almacenar = 0 Then
                            '------------------------------------------------
                            'Guardar los datos en la tabla  de la base de datos
                            '------------------------------------------------
                            Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Registro, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                            Tabla_Datos.Rows.Clear()
                            Tabla_Datos.AcceptChanges()
                        End If
                        Puntero = Puntero + 1
                    Next
                    If Tabla_Datos.Rows.Count > 0 Then
                        '------------------------------------------------
                        'Guardar los datos en la tabla  de la base de datos
                        '------------------------------------------------
                        Class_Funciones_Base_Datos.Registro_Almacenar_Datos(Coneccion_Registro, Tabla_Almacenamiento_Resultados, Tabla_Datos)
                        Tabla_Datos.Rows.Clear()
                        Tabla_Datos.AcceptChanges()
                    End If
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Registro_Parciales_Graficados(Index).Nombre_Tabla + "___Complejo_QRS")
                    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Almacenamiento_Resultados, Registro_Parciales_Graficados(Index).Nombre_Tabla + "___Complejo_QRS")

                End If
                Exit For
            End If
        Next

        Actualizar_Registro_Parcial()
        Actualizar_Tabla_DataGridView_Registro_Modificar()

    End Sub

    Private Sub Panel_Color_Registro_Graficado_BackColorChanged(sender As Object, e As EventArgs) Handles Panel_Color_Registro_Graficado.BackColorChanged
        If Registro_Parciales_Graficados.Count > 0 Then
            For Index = 0 To Registro_Parciales_Graficados.Count - 1
                If Registro_Parciales_Graficados(Index).Nombre_Tabla + "___" + Registro_Parciales_Graficados(Index).Nombre_Columna = ComboBox_Registro_Graficado.Text Then
                    Chart_Registro_Total.Series(Registro_Parciales_Graficados(Index).Nombre_Tabla + "___" + Registro_Parciales_Graficados(Index).Nombre_Columna).Color = Panel_Color_Registro_Graficado.BackColor
                    'Chart_Registro_Parcial.Series(Registro_Parciales_Graficados(Index).Nombre_Tabla + "___" + Registro_Parciales_Graficados(Index).Nombre_Columna).Color = Panel_Color_Registro_Graficado.BackColor
                    Registro_Parciales_Graficados_Temporal.Nombre_Tabla = Registro_Parciales_Graficados(Index).Nombre_Tabla
                    Registro_Parciales_Graficados_Temporal.Nombre_Columna = Registro_Parciales_Graficados(Index).Nombre_Columna
                    Registro_Parciales_Graficados_Temporal.Frecuencia = Registro_Parciales_Graficados(Index).Frecuencia
                    Registro_Parciales_Graficados_Temporal.Cantidad_Maxima_Datos = Registro_Parciales_Graficados(Index).Cantidad_Maxima_Datos
                    Registro_Parciales_Graficados_Temporal.Color = Panel_Color_Registro_Graficado.BackColor
                    Registro_Parciales_Graficados.RemoveAt(Index)
                    Registro_Parciales_Graficados.Insert(Index, Registro_Parciales_Graficados_Temporal)
                    'Actualiza la grafica parcial de los registros
                    Actualizar_Registro_Parcial()
                End If
            Next
        End If
    End Sub

    Private Sub CheckBox_Habilitar_Trasformada_Wavelet_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Habilitar_Trasformada_Wavelet_QRS.CheckedChanged
        Actualizar_Registro_Parcial()
    End Sub

    Private Sub Button_Eliminar_Ondas_MouseEnter(sender As Object, e As EventArgs) Handles Button_Eliminar_Ondas.MouseEnter

    End Sub
    Private Sub Button_Principal_MouseEnter(sender As Object, e As EventArgs) Handles Button_Eliminar_Ondas.MouseEnter, Button_Modificar_Datos.MouseEnter, Button_Buscar_Ondas.MouseEnter, Button_Borrar_Un_Registro.MouseEnter, Button_Borar_Registros.MouseEnter, Button_Agregar_Punto.MouseEnter, Button_Actualizar_Cambios.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde_Cambio
    End Sub

    Private Sub Button_Principal_MouseLeave(sender As Object, e As EventArgs) Handles Button_Modificar_Datos.MouseLeave, Button_Eliminar_Ondas.MouseLeave, Button_Buscar_Ondas.MouseLeave, Button_Borrar_Un_Registro.MouseLeave, Button_Borar_Registros.MouseLeave, Button_Agregar_Punto.MouseLeave, Button_Actualizar_Cambios.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde

    End Sub



    Private Sub RadioButton_R_R_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_R_R.CheckedChanged
        If RadioButton_R_R.Checked Then
            Actualizar_Tabla_DataGridView_Registro_Modificar()
        End If
    End Sub



    Private Sub TabControlEX_Selecion_Ondas_Intervalos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlEX_Selecion_Ondas_Intervalos.SelectedIndexChanged
        If (TabControlEX_Selecion_Ondas_Intervalos.TabPages(TabControlEX_Selecion_Ondas_Intervalos.SelectedIndex).Name = "TabPageEX_Ondas") Then
            Button_Eliminar_Ondas.Enabled = True
            Button_Modificar_Datos.Enabled = True
            Button_Agregar_Punto.Enabled = True
            Button_Actualizar_Cambios.Enabled = True
        ElseIf (TabControlEX_Selecion_Ondas_Intervalos.TabPages(TabControlEX_Selecion_Ondas_Intervalos.SelectedIndex).Name = "TabPageEX_Intervalos") Then
            Button_Eliminar_Ondas.Enabled = False
            Button_Modificar_Datos.Enabled = False
            Button_Agregar_Punto.Enabled = False
            Button_Actualizar_Cambios.Enabled = False
        End If

        Actualizar_Tabla_DataGridView_Registro_Modificar()
    End Sub

    Private Sub TextBox_Intervalo_Tabla_Min_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Intervalo_Tabla_Min.KeyPress
        Try
            If e.KeyChar = "." Or Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
                'Actualiza la grafica solo caundo se preciona enter
                If Asc(e.KeyChar) = 13 Then
                    Actualizar_Tabla_DataGridView_Registro_Modificar()
                End If
            Else
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox_Intervalo_Tabla_Max_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Intervalo_Tabla_Max.KeyPress
        Try
            If e.KeyChar = "." Or Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
                'Actualiza la grafica solo caundo se preciona enter
                If Asc(e.KeyChar) = 13 Then
                    Actualizar_Tabla_DataGridView_Registro_Modificar()
                End If
            Else
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox_Habilitar_Señal_Temporal_Filtrada_CheckedChanged(sender As Object, e As EventArgs)
        Actualizar_Registro_Parcial()
    End Sub

    Private Sub CheckBox_Trasformada_Wavelet_Busqueda_Onda_PT_CheckedChanged(sender As Object, e As EventArgs)
        Actualizar_Registro_Parcial()
    End Sub

    Private Sub CheckBox_Habilitar_Trasformada_Wavelet_Correccion_Onda_PT_CheckedChanged(sender As Object, e As EventArgs)
        Actualizar_Registro_Parcial()
    End Sub

    Private Sub CheckBox_Habilitar_Señal_Temporal_Filtrada_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox_Habilitar_Señal_Temporal_Filtrada.CheckedChanged
        Actualizar_Registro_Parcial()
    End Sub

    Private Sub TextBox_Onda_Tabla_Min_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Onda_Tabla_Min.KeyPress
        Try
            If e.KeyChar = "." Or Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
                'Actualiza la grafica solo caundo se preciona enter
                If Asc(e.KeyChar) = 13 Then
                    Actualizar_Tabla_DataGridView_Registro_Modificar()
                End If
            Else
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox_Onda_Tabla_Max_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Onda_Tabla_Max.KeyPress
        Try
            If e.KeyChar = "." Or Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
                'Actualiza la grafica solo caundo se preciona enter
                If Asc(e.KeyChar) = 13 Then
                    Actualizar_Tabla_DataGridView_Registro_Modificar()
                End If
            Else
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub


End Class