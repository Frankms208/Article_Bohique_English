Imports System.Data.SqlClient
Public Class UserControl_Modulo_Analicis_Señal
    Public Modulo_Anlisis As New Class_Analisis_Registro
    Public Bandera_Anclaje As Int16 = 0 'Establec a que for esta anclado el modulo 0-> Form_Principla, 1-> Form_Contenedor
    'Si Estado_Registro=0 No se ha cargardo ningun registro 
    Friend Estado_Registro As Int16
    Friend CheckedListBox_Registros_Analizar_Multi_Registro_Tecla_Presionada As Int16
    Friend CheckedListBox_Registros_Analizar_Multi_Registro_Item_Selecionado As Int16
    Friend CheckedListBox_Registros_Analizar_Multi_Registro_Bandera_Seleccion As Int16 = 0



    Public Configuracion_Deteccion_QRS As Class_Analisis_Registro.Configuracion_Deteccion_QRS_1
    Function Incilizar_Configuracion_Deteccion_QRS()

        Configuracion_Deteccion_QRS.m_Comparacion_Wavelet_QRS = 1 'tang 45°=1 Pendiente de comparacion Para deterla busqueda de punos significativos  
        Configuracion_Deteccion_QRS.Margen_Actualizacion_R_Promedio = 2.5 'Limite maximo de un P_Max_Central para poder actualizar el Valor_Promedio_P_Max
        Configuracion_Deteccion_QRS.Cantidad_Latido_Ectopico = 4 'Cantidad de posibles latidos Ectopicos antes de actulizar Vector_Valor_P_Max  

        Configuracion_Deteccion_QRS.Demora_Despues_QRS = 0.2 'Demora_Despues_QRS*frecuencia desplasamiento despues de detectar un QRS   

        Configuracion_Deteccion_QRS.Cantida_Datos_TW = 200000 'Cantidad Maxima de datos ledias de para ser prosesada  
        Configuracion_Deteccion_QRS.Cantida_Datos_Retenidos = 10 'el quivalente a 10 segundos Math.Floor(Cantida_Datos_Retenidos * Frecuencia) de datos alamcenadades para ser prosesada         Static Reset_Limite_Max_Min As Int32    'Limite de tiempo sin detectar un QRS para resetear  Limite_Max y Limite_Min

        Configuracion_Deteccion_QRS.Frecuencia_Baja_Filtro = 1 'Frecuencia pasa Baja del Filtro pasa banda
        Configuracion_Deteccion_QRS.Frecuencia_Alta_Filtro = 40 'Frecuencia pasa Alta del Filtro pasa banda

        Configuracion_Deteccion_QRS.Escala_TW_QRS = 3 'Escala de la TW empleda para el analisis del QRS
        Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda = 4 'Escala de la TW empleada para la busqueda de la Onda T
        Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion = 1 'Escala de la TW empleada para la Correcion de la Onda T 



        'Parametros comunes entre las Busqueda de Complejos QRS y la Busqueda de complejos QRS Faltantes 
        '-------------------------------------------------------------------------------------------------------------------------
        Configuracion_Deteccion_QRS.Margen_Separacion_QRS_Ruido = 50 'Establece el limite de cuanto pude crecer la amplitud de P_Max_Central con respecto a Valor_Promedio_P_Max sin considerarse ruido 
        Configuracion_Deteccion_QRS.Margen_Separacion_Desniveles = 0.2 'Establece  la relacion minima entre P_Max_Central y uno de los minimos para direnciar los cambios de nivel en la señal y un QRS

        Configuracion_Deteccion_QRS.Duracion_Maxima_QRS = 0.2 'Duracion Maxima que puede tener un QRS
        Configuracion_Deteccion_QRS.Duracion_Minima_QRS = 0.02 'Duracion Minima que puede tener un QRS
        Configuracion_Deteccion_QRS.Separacion_Minima_QRS = 0.2 'En segundos =200ms Separacion minima de debe existir entre dos QRS consecutivos de 200 ms 

        Configuracion_Deteccion_QRS.PorCiento_Comparacion_QRS = 0.75 'Determian el cuanto se reduce margen Valor_Promedio_P_Max minimo para asignarselo a Valor_P_Max
        Configuracion_Deteccion_QRS.PorCiento_Comparacion_Busqueda_QRS = 0.3 'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW entre P_Max_Izquierda y P_Max_Derecha 
        Configuracion_Deteccion_QRS.PorCiento_Comparacion_Busqueda_Extremos_QRS = 0.5 'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW fuera de lso puntos P_Max_Izquierda y P_Max_Derecha 
        Configuracion_Deteccion_QRS.PorCiento_Rechazo_Extremos = 0.05 '% de rechaso de los puntos estremos(P_Max_Derecha y P_Max_Izquierda ) con respecto P_Max_Central

        '-------------------------------------------------------------------------------------------------------------------------
        'Parametros para la Optencion de las Ondas P y T
        '-------------------------------------------------------------------------------------------------------------------------
        Configuracion_Deteccion_QRS.m_Comparacion_Wavelet_Ondas_PT = Convert.ToString(Math.Tan(Math.PI * 15 / 180))   'tang 45°=1 Pendiente de comparacion Para deterla busqueda de punos significativos  
        Configuracion_Deteccion_QRS.PorCiento_Comparacion_Ondas_PT = 0.8 'Determian el cuanto se reduce margen Valor_Promedio_P_Max en % para asignarselo a Valor_P_Max
        Configuracion_Deteccion_QRS.PorCiento_Comparacion_Busqueda_Ondas_PT = 0.3 'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW entre P_Max_Izquierda y P_Max_Derecha 

        Configuracion_Deteccion_QRS.Dezplazamiento_Despues_Punto_J_Onda_T = 0.04 'Desplasamiento(s) despues del Punto J antes de buscar la Onda T 
        Configuracion_Deteccion_QRS.PorCiento_Busqueda_en_Interv_RR_Onda_T = 0.6 '% del Intervalo RR Asta el cual se busca la Onda T apartir del punto J   

        Configuracion_Deteccion_QRS.Dezplazamiento_Despues_Punto_Qi_Onda_P = 0.03 'Desplasamiento(s) Antes del Punto Qi antes de buscar la Onda P 
        Configuracion_Deteccion_QRS.PorCiento_Busqueda_en_Interv_RR_Onda_P = 0.4 '% del Intervalo RR Asta el cual se busca la Onda P apartir del punto Qi
        Configuracion_Deteccion_QRS.PorCiento_Discriminante_Ruido_PT = 0.3 '% del Intervalo RR Asta el cual se busca la Onda P apartir del punto Qi

        '-------------------------------------------------------------------------------------------------------------------------




        ComboBox_PorCiento_Rechazo_Ruido_QRS.Text = Convert.ToString(100 * Configuracion_Deteccion_QRS.Margen_Separacion_Desniveles) 'Establece  la relacion minima entre P_Max_Central y uno de los minimos para direnciar los cambios de nivel en la señal y un QRS

        ComboBox_Angulo_Rechazo_QRS.Text = Convert.ToString(Math.Atan(Configuracion_Deteccion_QRS.m_Comparacion_Wavelet_QRS) * 180 / Math.PI) 'tang 45°=1 Pendiente de comparacion Para deterla busqueda de punos significativos  



        ComboBox_P_C_Max_PorCiento_Comp_QRS.Text = Convert.ToString(100 * Configuracion_Deteccion_QRS.PorCiento_Comparacion_QRS) 'Determian el cuanto se reduce margen Valor_Promedio_P_Max minimo para asignarselo a Valor_P_Max
        ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS.Text = Convert.ToString(100 * Configuracion_Deteccion_QRS.PorCiento_Comparacion_Busqueda_QRS) 'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW entre P_Max_Izquierda y P_Max_Derecha 
        ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS.Text = Convert.ToString(100 * Configuracion_Deteccion_QRS.PorCiento_Comparacion_Busqueda_Extremos_QRS) 'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW fuera de lso puntos P_Max_Izquierda y P_Max_Derecha 

        TextBox_Duracion_Max_QRS.Text = Convert.ToString(1000 * Configuracion_Deteccion_QRS.Duracion_Maxima_QRS) 'Duracion Maxima que puede tener un QRS
        TextBox_Duracion_Min_QRS.Text = Convert.ToString(1000 * Configuracion_Deteccion_QRS.Duracion_Minima_QRS) 'Duracion Minima que puede tener un QRS

        TextBox_Interv_Min_Entre_QRS.Text = Convert.ToString(1000 * Configuracion_Deteccion_QRS.Separacion_Minima_QRS) 'En segundos =200ms Separacion minima de debe existir entre dos QRS consecutivos de 200 ms 
        TextBox_Desplaz_Despues_QRS.Text = Convert.ToString(1000 * Configuracion_Deteccion_QRS.Demora_Despues_QRS) 'Demora_Despues_QRS*frecuencia desplasamiento despues de detectar un QRS   


        ComboBox_Fcb_Configuracion_Deteccion_QRS.Text = Convert.ToString(Configuracion_Deteccion_QRS.Frecuencia_Baja_Filtro) 'Frecuencia pasa Baja del Filtro pasa banda
        ComboBox_Fca_Configuracion_Deteccion_QRS.Text = Convert.ToString(Configuracion_Deteccion_QRS.Frecuencia_Alta_Filtro) 'Frecuencia pasa Alta del Filtro pasa banda

        ComboBox_Selec_TW_QRS.Text = "TW " + Convert.ToString(Configuracion_Deteccion_QRS.Escala_TW_QRS) 'Escala de la TW empleda para el analisis del QRS
        ComboBox_Selec_TW_Onda_PT_Busqueda.Text = "TW " + Convert.ToString(Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda) 'Escala de la TW empleada para la busqueda de la Onda T
        ComboBox_Selec_TW_Onda_PT_Correcion.Text = "TW " + Convert.ToString(Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion) 'Escala de la TW empleada para la Correcion de la Onda T 

        '-------------------------------------------------------------------------------------------------------------------------
        'Parametros para la Optencion de las Ondas P y T
        '-------------------------------------------------------------------------------------------------------------------------
        ComboBox_Angulo_Rechazo_Onda_PT.Text = Convert.ToString(Math.Atan(Configuracion_Deteccion_QRS.m_Comparacion_Wavelet_Ondas_PT) * 180 / Math.PI) 'tang 45°=1 Pendiente de comparacion Para deterla busqueda de punos significativos  
        ComboBox_P_C_Max_PorCiento_Comp_Onda_PT.Text = Convert.ToString(100 * Configuracion_Deteccion_QRS.PorCiento_Comparacion_Ondas_PT) 'Determian el cuanto se reduce margen Valor_Promedio_P_Max en % para asignarselo a Valor_P_Max
        ComboBox_Avan_Antes_Cruce_Cero_Centro_Onda_PT.Text = Convert.ToString(100 * Configuracion_Deteccion_QRS.PorCiento_Comparacion_Busqueda_Ondas_PT) 'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW entre P_Max_Izquierda y P_Max_Derecha 

        TextBox_Desplaz_Despues__Punto_J_Onda_T.Text = Convert.ToString(1000 * Configuracion_Deteccion_QRS.Dezplazamiento_Despues_Punto_J_Onda_T) 'Desplasamiento(ms) despues del Punto J antes de buscar la Onda T 
        ComboBox_PorCiento_Busqueda_Interv_RR_Onda_T.Text = Convert.ToString(100 * Configuracion_Deteccion_QRS.PorCiento_Busqueda_en_Interv_RR_Onda_T) '% del Intervalo RR Asta el cual se busca la Onda T apartir del punto J   

        TextBox_Desplaz_Antes__Punto_Qi_Onda_P.Text = Convert.ToString(1000 * Configuracion_Deteccion_QRS.Dezplazamiento_Despues_Punto_Qi_Onda_P) 'Desplasamiento(ms) Antes del Punto Qi antes de buscar la Onda P 
        ComboBox_PorCiento_Busqueda_Interv_RR_Onda_P.Text = Convert.ToString(100 * Configuracion_Deteccion_QRS.PorCiento_Busqueda_en_Interv_RR_Onda_P) '% del Intervalo RR Asta el cual se busca la Onda P apartir del punto Qi
        ComboBox_Discriminante_Ruido.Text = Convert.ToString(100 * Configuracion_Deteccion_QRS.PorCiento_Discriminante_Ruido_PT) ''% de P_Min_Max_Comparacion para comparar los maximos-minimos y eliminar el posible ruido ruido

        '-------------------------------------------------------------------------------------------------------------------------





        CheckBox_Selec_Auto_TW_QRS.Checked = True
        CheckBox_Selec_Auto_TW_Onda_PT_Busqueda.Checked = True
        CheckBox_Selec_Auto_TW_Onda_PT_Correcion.Checked = True






    End Function

    Public Structure Registro_Activo
        Public Usuario As String
        Public Paciente As String
        Public Fecha_Registro As String
        Public Tabla As String
        Public Max_Puntero As Int32
        Public Frecuencia As Double
        Public Bandera_Nuevo_Registro As Int16
        'Si Bandera_Nuevo_Registro=0 se cargo un nuevo registro
        'Si Bandera_Nuevo_Registro=1 no es un nuevo registro
    End Structure
    Public Registro_Seleccionado As Registro_Activo
    Public Registro_Seleccionado_Multi_Registros As New List(Of Registro_Activo)
    Public Registro_En_Analisis_Multi_Registros As Int64
    Public Structure Filtro
        Public fca As Double
        Public fcb As Double
    End Structure
    Public Filtro_Personalisado_fc As Filtro



    Private Sub ComboBox_Selecion_Usuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Selecion_Usuario.SelectedIndexChanged
        ComboBox_Selecion_Paciente.Items.Clear()

        Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
        'Identificar los pacientes existentes relacionados con el usuario 
        If ComboBox_Selecion_Usuario.Items.Count > 0 Then


            Dim Pacientes As New DataSet
            Pacientes = Class_Funciones_Base_Datos.Tabla_Datos_Pacientes_Buscar_Pacientes(Coneccion_Usuarios, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"))

            ComboBox_Selecion_Paciente.Items.Clear()

            For i = 0 To Pacientes.Tables(0).Rows.Count - 1
                ComboBox_Selecion_Paciente.Items.Add(Pacientes.Tables(0).Rows(i)(0))
            Next i
        End If

        'Identificar los registors existentes relacionados con el pacientes 
        If ComboBox_Selecion_Paciente.Items.Count > 0 Then
            ComboBox_Selecion_Paciente.SelectedIndex = 0
        End If
        Coneccion_Usuarios.Close()
    End Sub

    Private Sub ComboBox_Selecion_Paciente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Selecion_Paciente.SelectedIndexChanged
        If CheckBox_Analisis_Multi_Registro.Checked = False Then
            'Si esta activo al analisis de un solso registro registro
            If Form_Principal.Usuario_Activo.Tipo_Usuario = 1 Then
                Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
                'Identificar los registors existentes relacionados con el paciente
                If ComboBox_Selecion_Paciente.Items.Count > 0 Then
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
                Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
                'Identificar los registors existentes relacionados con el paciente
                If ComboBox_Selecion_Paciente.Items.Count > 0 Then
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

            End If


        Else
            'Si esta activo al analisis multi registro
            If Form_Principal.Usuario_Activo.Tipo_Usuario = 1 Then
                Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
                'Identificar los registors existentes relacionados con el paciente
                If ComboBox_Selecion_Paciente.Items.Count > 0 Then
                    Dim Fecha_Registro As New DataSet
                    Fecha_Registro = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Usuarios, Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"))

                    CheckedListBox_Registros.Items.Clear()

                    For i = 0 To Fecha_Registro.Tables(0).Rows.Count - 1
                        CheckedListBox_Registros.Items.Add(Fecha_Registro.Tables(0).Rows(i)(0))
                    Next i
                    Coneccion_Usuarios.Close()

                End If
            ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
                Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
                'Identificar los registors existentes relacionados con el paciente
                If ComboBox_Selecion_Paciente.Items.Count > 0 Then
                    Dim Fecha_Registro As New DataSet
                    Fecha_Registro = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Usuarios, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"))

                    CheckedListBox_Registros.Items.Clear()

                    For i = 0 To Fecha_Registro.Tables(0).Rows.Count - 1
                        CheckedListBox_Registros.Items.Add(Fecha_Registro.Tables(0).Rows(i)(0))
                    Next i

                End If
            End If
            If CheckBox_Selecionar_Todos_Registros.Checked Then
                For i = 0 To CheckedListBox_Registros.Items.Count - 1
                    CheckedListBox_Registros.SetItemChecked(i, True)
                Next
            End If
        End If

    End Sub



    Private Sub UserControl_Modulo_Analicis_Señal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Incilizar_Configuracion_Deteccion_QRS()

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
            Coneccion_Usuarios.Close()
        ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
            'Identificar los usuarios existentes
            Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
            'Identificar los usuarios existentes
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
            End If
        End If



    End Sub

    Private Sub Button_Cerrar_Click_1(sender As Object, e As EventArgs) Handles Button_Cerrar.Click
        Form_Principal.SplitContainer_Principal.Panel2.Controls.Remove(Me)
        Form_Principal.Estado_Registros.Desbloquear_Registro(Registro_Seleccionado.Tabla)
        For j = Registro_Seleccionado_Multi_Registros.Count - 1 To 0 Step -1
            Form_Principal.Estado_Registros.Desbloquear_Registro(Registro_Seleccionado_Multi_Registros.Item(j).Tabla.ToString())
        Next j
        Me.Dispose()
    End Sub



    Private Sub Button_Cargar_Registro_Click(sender As Object, e As EventArgs) Handles Button_Cargar_Registro.Click
        If CheckBox_Analisis_Multi_Registro.Checked = False Then
            'Si esta activo al analisis de un solso registro registro

            Dim Registro_Anterior As String = Registro_Seleccionado.Tabla

            If ComboBox_Selecionar_Registro.Text <> "" Then
                If Form_Principal.Usuario_Activo.Tipo_Usuario = 1 Then
                    Registro_Seleccionado.Usuario = (Form_Principal.Usuario_Activo.Usuario.TrimEnd).Replace(" ", "_")
                ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
                    Registro_Seleccionado.Usuario = ComboBox_Selecion_Usuario.Text
                End If
                Dim Coneccion_Base_Datos As New SqlConnection
                Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
                Coneccion_Base_Datos.Open()

                Registro_Seleccionado.Tabla = Registro_Seleccionado.Usuario + "___" + (ComboBox_Selecion_Paciente.Text).Replace(" ", "_") + "___" + ComboBox_Selecionar_Registro.Text
                Registro_Seleccionado.Paciente = (ComboBox_Selecion_Paciente.Text).Replace(" ", "_")
                Registro_Seleccionado.Fecha_Registro = ComboBox_Selecionar_Registro.Text
                'Comprobar si el nuevo registro selecionado es el mismos que el registro previo
                If Registro_Anterior <> Registro_Seleccionado.Tabla Then
                    'Comprobar si el nuevo registro selecionado esta bloqueado
                    If Form_Principal.Estado_Registros.Consultar_Registro_Bloqueado(Registro_Seleccionado.Tabla) = False Then
                        CheckedListBox_Registros.Items.Clear()
                        'Bloquear el nuevo registro 
                        'Form_Principal.Estado_Registros.Bloquear_Registro(Registro_Seleccionado.Usuario, Registro_Seleccionado.Paciente, Registro_Seleccionado.Fecha_Registro)
                        ''Desbloquear el registro anterior 
                        'Form_Principal.Estado_Registros.Desbloquear_Registro(Registro_Anterior)

                        'Cargar las derivaciones disponibles
                        'Dim Columnas As List(Of String) = Class_Funciones_Base_Datos.Columnas_Existentes_Tabla(Coneccion_Usuarios, Registro_Seleccionado.Tabla)
                        Dim Columnas As List(Of String) = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Derivaciones_Registro(Coneccion_Base_Datos, Registro_Seleccionado.Usuario, Registro_Seleccionado.Paciente, Registro_Seleccionado.Fecha_Registro)

                        For i = 0 To Columnas.Count - 1
                            If Columnas.Item(i) <> "Puntero" Then
                                CheckedListBox_Registros.Items.Add(Columnas.Item(i))
                            End If
                        Next i
                        Coneccion_Base_Datos.Close()

                        Dim Coneccion_Registro As New SqlConnection
                        Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Registro_Seleccionado.Usuario, Registro_Seleccionado.Paciente, Registro_Seleccionado.Fecha_Registro, Columnas.Item(0).ToString)

                        Label_Registro_Seleccionado.Text = "Records: " + Registro_Seleccionado.Tabla
                        Registro_Seleccionado.Frecuencia = Class_Funciones_Base_Datos.Registro_Frecuencia(Coneccion_Base_Datos, Registro_Seleccionado.Usuario, Registro_Seleccionado.Paciente, Registro_Seleccionado.Fecha_Registro)
                        Registro_Seleccionado.Max_Puntero = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Registro_Seleccionado.Usuario, Registro_Seleccionado.Paciente, Registro_Seleccionado.Fecha_Registro)

                        'Cargar las Frecuencias de corte en el filtro personalizado de acuerdo a la frecuencia de muestreo
                        ComboBox_fca.Items.Clear()
                        ComboBox_fcb.Items.Clear()
                        For i = 1 To Registro_Seleccionado.Frecuencia / 2 - 1
                            ComboBox_fca.Items.Add(Convert.ToString(i) + " Hz")
                            ComboBox_fcb.Items.Add(Convert.ToString(i) + " Hz")
                        Next
                        ComboBox_fca.SelectedIndex = ComboBox_fca.Items.Count - 1
                        ComboBox_fcb.SelectedIndex = 0

                        'Cargar las Frecuencias de corte en el filtro pordefecto de acuerdo a la frecuencia de muestreo
                        If CheckBox_Filtro_Personalizado.Checked Then
                            CheckBox_fca_Ninguna.Visible = False
                            CheckBox_fca_50_Hz.Visible = False
                            CheckBox_fca_100_Hz.Visible = False
                            CheckBox_fca_150_Hz.Visible = False
                            CheckBox_fca_200_Hz.Visible = False

                            CheckBox_fcb_Ninguna.Visible = False
                            CheckBox_fcb_1_Hz.Visible = False
                            CheckBox_fcb_5_Hz.Visible = False
                            CheckBox_fcb_10_Hz.Visible = False

                        Else
                            CheckBox_fca_Ninguna.Visible = True
                            CheckBox_fcb_Ninguna.Visible = True
                            CheckBox_Notch_60_Hz.Visible = True


                            If (Registro_Seleccionado.Frecuencia - 1) < 200 Then
                                CheckBox_Notch_60_Hz.Visible = False

                                CheckBox_fca_50_Hz.Visible = True
                                CheckBox_fca_100_Hz.Visible = False
                                CheckBox_fca_150_Hz.Visible = False
                                CheckBox_fca_200_Hz.Visible = False
                            ElseIf (Registro_Seleccionado.Frecuencia - 1) < 300 Then

                                CheckBox_fca_50_Hz.Visible = True
                                CheckBox_fca_100_Hz.Visible = True
                                CheckBox_fca_150_Hz.Visible = False
                                CheckBox_fca_200_Hz.Visible = False
                            ElseIf (Registro_Seleccionado.Frecuencia - 1) < 400 Then
                                CheckBox_fca_50_Hz.Visible = True
                                CheckBox_fca_100_Hz.Visible = True
                                CheckBox_fca_150_Hz.Visible = True
                                CheckBox_fca_200_Hz.Visible = False
                            Else
                                CheckBox_fca_50_Hz.Visible = True
                                CheckBox_fca_100_Hz.Visible = True
                                CheckBox_fca_150_Hz.Visible = True
                                CheckBox_fca_200_Hz.Visible = True
                            End If

                        End If

                        ' Para repocicionar los elementos en teimpo de ejecucion y no esten encimados con los otros elemestos fuera de la ejecucion
                        ComboBox_fcb.Left = 14
                        ComboBox_fca.Left = 168
                        CheckBox_Filtro_Para_Banda.Left = 14
                        CheckBox_Filtro_Pasa_Banda.Left = 14
                    Else
                        'Mesaje de que no se ha seleciondado ningun registro
                        Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                        Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "The Registry is already", "in use", "Error in the Record", 0)
                    End If
                End If

            Else
                'Mesaje de que no se ha seleciondado ningun registro
                Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "None selected", "Record", "Error in the Record", 0)
            End If
        Else
            'Si esta activo al analisis multi registro
            If ComboBox_Selecion_Paciente.Text <> "" Then
                If CheckedListBox_Registros.CheckedItems.Count <> 0 Then

                    Dim Coneccion_Base_Datos As New SqlConnection
                    Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()

                    Dim Usuario As String
                    Dim Paciente As String
                    Dim Fechas_Registros As New DataSet
                    Dim Fecha_Registro As String
                    Dim Tabla As String
                    'Determino el usuario activo 
                    If Form_Principal.Usuario_Activo.Tipo_Usuario = 1 Then
                        Usuario = (Form_Principal.Usuario_Activo.Usuario.TrimEnd).Replace(" ", "_")
                    ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
                        Usuario = ComboBox_Selecion_Usuario.Text
                    Else
                        Usuario = "Guest"
                    End If
                    'Determino si voy a seleccionar todos los registros  o solo los marcados
                    If CheckBox_Selecionar_Todos_Registros.Checked = False Then
                        'Seleccionar los registros solo los marcados
                        Paciente = ComboBox_Selecion_Paciente.Text
                        For i = 0 To CheckedListBox_Registros.CheckedItems.Count - 1
                            Fecha_Registro = CheckedListBox_Registros.CheckedItems(i).ToString()
                            Tabla = Usuario + "___" + (Paciente).Replace(" ", "_") + "___" + Fecha_Registro
                            If Form_Principal.Estado_Registros.Consultar_Registro_Bloqueado(Tabla) = False Then
                                'Bloquear el nuevo registro 
                                Form_Principal.Estado_Registros.Bloquear_Registro(Usuario, Paciente, Fecha_Registro)
                                CheckedListBox_Registros_Analizar_Multi_Registro.Items.Add(Tabla)
                                Dim Registro_Analizar As New Registro_Activo
                                Registro_Analizar.Paciente = Paciente
                                Registro_Analizar.Usuario = Usuario
                                Registro_Analizar.Fecha_Registro = Fecha_Registro
                                Registro_Analizar.Frecuencia = Class_Funciones_Base_Datos.Registro_Frecuencia(Coneccion_Base_Datos, Usuario, Paciente, Fecha_Registro)

                                Dim Columnas As List(Of String) = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Derivaciones_Registro(Coneccion_Base_Datos, Registro_Analizar.Usuario, Registro_Analizar.Paciente, Registro_Analizar.Fecha_Registro)
                                Dim Coneccion_Registro As New SqlConnection
                                Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Registro_Analizar.Usuario, Registro_Analizar.Paciente, Registro_Analizar.Fecha_Registro, Columnas.Item(0).ToString)

                                Registro_Analizar.Max_Puntero = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Usuario, Paciente, Fecha_Registro)
                                Registro_Analizar.Tabla = Tabla
                                Registro_Seleccionado_Multi_Registros.Add(Registro_Analizar)

                            End If

                        Next i
                    Else
                        'Seleccionar todos los registros 
                        'Seleccionar todos los registros 
                        For j = 0 To ComboBox_Selecion_Paciente.Items.Count - 1
                            Paciente = ComboBox_Selecion_Paciente.Items(j).ToString()
                            'Paciente = ComboBox_Selecion_Paciente.Text
                            Fechas_Registros = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Base_Datos, Usuario, Paciente)

                            For i = 0 To Fechas_Registros.Tables(0).Rows.Count - 1
                                Fecha_Registro = Fechas_Registros.Tables(0).Rows(i)(0)
                                Tabla = Usuario + "___" + (Paciente).Replace(" ", "_") + "___" + Fecha_Registro
                                If Form_Principal.Estado_Registros.Consultar_Registro_Bloqueado(Tabla) = False Then
                                    'Bloquear el nuevo registro 

                                    Form_Principal.Estado_Registros.Bloquear_Registro(Usuario, Paciente, Fecha_Registro)
                                    CheckedListBox_Registros_Analizar_Multi_Registro.Items.Add(Tabla)
                                    Dim Registro_Analizar As New Registro_Activo
                                    Registro_Analizar.Paciente = Paciente
                                    Registro_Analizar.Usuario = Usuario
                                    Registro_Analizar.Fecha_Registro = Fecha_Registro
                                    Registro_Analizar.Frecuencia = Class_Funciones_Base_Datos.Registro_Frecuencia(Coneccion_Base_Datos, Usuario, Paciente, Fecha_Registro)

                                    Dim Columnas As List(Of String) = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Derivaciones_Registro(Coneccion_Base_Datos, Registro_Analizar.Usuario, Registro_Analizar.Paciente, Registro_Analizar.Fecha_Registro)
                                    Dim Coneccion_Registro As New SqlConnection
                                    Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Registro_Analizar.Usuario, Registro_Analizar.Paciente, Registro_Analizar.Fecha_Registro, Columnas.Item(0).ToString)

                                    Registro_Analizar.Max_Puntero = Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Registro, Usuario, Paciente, Fecha_Registro)
                                    Registro_Analizar.Tabla = Tabla
                                    Registro_Seleccionado_Multi_Registros.Add(Registro_Analizar)

                                End If

                            Next i
                        Next j

                    End If


                Else
                    'Mesaje de que no se ha seleciondado ningun registro
                    Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                    Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "No Record selected", "", "Error in the Record", 0)

                End If
            Else
                'Mesaje de que no se ha seleciondado ningun registro
                Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "No patient selected", "", "Error in the Record", 0)

            End If
        End If







    End Sub
    Private Sub BackgroundWorker_Analisis_Registro_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Analisis_Registro.DoWork
        'Coneccion_Registro.Open()
        'Tablas Empleadas en el anailizis
        Dim Coneccion_Base_Datos_Filtrado_Temp As New SqlConnection
        Dim Coneccion_Base_Datos_Transformada_Wavelet_QRS As New SqlConnection
        Dim Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp As New SqlConnection
        Dim Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp As New SqlConnection


        Dim Coneccion_Registro_Analizar As New SqlConnection
        Dim Registro_Analizar As String = "Temp"
        Dim Tabla_Transformada_Wavelet_QRS As String = "Temp"
        Dim Tabla_Transformada_Wavelet_Onda_PT_Busqueda As String = "Temp"
        Dim Tabla_Transformada_Wavelet_Onda_PT_Correcion As String = "Temp"

        Dim Tabla_QRS As String
        Dim Tabla_Onda_T As String
        Dim Tabla_Onda_P As String
        Dim Tabla_Intervalo_R_R As String
        Dim Tabla_Intervalo_Q_T As String
        Dim Tabla_Intervalo_P_R As String

        'Funciones para determinar los parametros que son necesarios calcular si Se activa la funcion Recalcular
        'Dim Recalcular_Deteccion_Complejo_QRS As Boolean = CheckBox_Calcular_QRS.Checked Or CheckBox_Calcular_T.Checked Or CheckBox_Calcular_P.Checked
        'Dim Recalcular_Deteccion_Onda_T As Boolean = CheckBox_Calcular_T.Checked
        'Dim Recalcular_Deteccion_Onda_P As Boolean = CheckBox_Calcular_P.Checked
        'Dim Recalcular_Busqueda_Complejos_QRS_NO_Detectados As Boolean = Recalcular_Deteccion_Complejo_QRS And CheckBox_Deteccion_Complejo_QRS_Faltantes.Checked
        'Funciones para determinar los parametros que son necesarios calcular si, no Se activa la funcion Recalcular
        Dim Deteccion_Complejo_QRS As Boolean = False
        Dim Deteccion_Onda_T As Boolean = False
        Dim Deteccion_Onda_P As Boolean = False
        Dim Deteccion_Intervalo_R_R As Boolean = False
        Dim Deteccion_Intervalo_Q_T As Boolean = False
        Dim Deteccion_Intervalo_P_R As Boolean = False

        Dim Deteccion_Complejo_QRS_temp As Boolean = False
        Dim Deteccion_Onda_T_temp As Boolean = False
        Dim Deteccion_Onda_P_temp As Boolean = False
        Dim Deteccion_Intervalo_R_R_temp As Boolean = False
        Dim Deteccion_Intervalo_Q_T_temp As Boolean = False
        Dim Deteccion_Intervalo_P_R_temp As Boolean = False

        Dim Recalcular_Elementos As Boolean = CheckBox_Recalcular_Resultados.Checked
        Dim Filtrar_Señal As Boolean = False
        Dim Busqueda_Complejos_QRS_NO_Detectados As Boolean = False
        Dim Correccion_Puntos_Complejo_QRS As Boolean = False





        Dim m() As Double = {0.3749, 0.1934, 0.1297, 0.0975, 0.078, 0.065, 0.0558, 0.0488, 0.0434, 0.039}
        Dim Escala_Trasnformada_Wavelet_QRS As Int16 = 2
        Dim Escala_Trasnformada_Wavelet_Onda_PT_Busqueda As Int16 = 2
        Dim Escala_Trasnformada_Wavelet_Onda_PT_Correcion As Int16 = 2
        Dim Bandera_Nueva_Derivacion As Int16 = 0 'Especifica cuando es una derivacion nueva
        'Dim Tabla_Trasnformada_Wavelet As String = "Tabla_Transformada_Wavelet_QRS" 'Especifica cuando es una derivacion nueva
        'Determinar las clomunas existentees de la tabla Temp_Transformada_Wavele
        Dim Coneccion_Base_Datos As New SqlConnection
        Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
        Coneccion_Base_Datos.Open()
        ''Determinar las columnas existentes del registro a analizar
        'Dim Columnas_Existentes As List(Of String) = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Derivaciones_Registro(Coneccion_Base_Datos, Registro_Seleccionado.Usuario, Registro_Seleccionado.Paciente, Registro_Seleccionado.Fecha_Registro)

        For Index1 = 0 To CheckedListBox_Registros.CheckedItems.Count - 1
            Dim Coneccion_Registro As New SqlConnection
            Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Registro_Seleccionado.Usuario, Registro_Seleccionado.Paciente, Registro_Seleccionado.Fecha_Registro, CheckedListBox_Registros.CheckedItems(Index1).ToString())
            Coneccion_Registro.Open()
            'Identificar que Ondas, Segmotos y Intervalos tengo que Calcular para obtner los resultados deseados

            For Index_TreeView_0 = 0 To TreeView_Elementos_Calcular.Nodes.Count - 1
                For Index_TreeView_1 = 0 To TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes.Count - 1
                    'Onda P
                    If TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "P" And TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked Then
                        Deteccion_Onda_P = True
                        Deteccion_Complejo_QRS_temp = True
                        If CheckBox_Filtrar_Señal.Checked Then
                            Filtrar_Señal = True
                        End If
                    End If
                    'Complejo QRS
                    If TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "QRS" And TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked Then
                        Deteccion_Complejo_QRS = True
                        If CheckBox_Filtrar_Señal.Checked Then
                            Filtrar_Señal = True
                        End If
                    End If
                    'Onda T
                    If TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "T" And TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked Then
                        Deteccion_Onda_T = True
                        Deteccion_Complejo_QRS_temp = True
                        If CheckBox_Filtrar_Señal.Checked Then
                            Filtrar_Señal = True
                        End If
                    End If
                    'Intervalo R-R
                    If TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "R-R" And TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked Then
                        Deteccion_Intervalo_R_R = True
                        'Validar si ya se calculo la ubicacion de los Complejos QRS
                        If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Complejo_QRS") Then
                            Deteccion_Complejo_QRS_temp = True
                        End If
                    End If
                    'Intervalo Q-T
                    If TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "Q-T" And TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked Then
                        Deteccion_Intervalo_Q_T = True
                        'Validar si ya se calculo la ubicacion de los Complejos QRS
                        If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Complejo_QRS") Then
                            Deteccion_Complejo_QRS_temp = True
                        End If
                        'Validar si ya se calculo la ubicacion de la Onda T
                        If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_T") Then
                            Deteccion_Onda_T_temp = True
                        End If
                    End If
                    'Intervalo P-R
                    If TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "P-R" And TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked Then
                        Deteccion_Intervalo_P_R = True
                        'Validar si ya se calculo la ubicacion de los Complejos QRS
                        If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Complejo_QRS") Then
                            Deteccion_Complejo_QRS_temp = True
                        End If
                        'Validar si ya se calculo la ubicacion de la Onda P
                        If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_P") Then
                            Deteccion_Onda_P_temp = True
                        End If
                    End If
                Next

            Next

            'Determinar si tengo que relizar Busqueda_Complejos_QRS_NO_Detectados
            'Valido si necesito obtener el Complejo QRS y si Esta activo la Busqueda_Complejos_QRS_NO_Detectados    
            If Deteccion_Complejo_QRS And CheckBox_Deteccion_Complejo_QRS_Faltantes.Checked Then
                Busqueda_Complejos_QRS_NO_Detectados = True
            End If

            'Determinar si tengo que relizar Correccion_Puntos_Complejo_QRS
            'Valido si necesito obtener el Complejo QRS y si Esta activo la Correccion_Puntos_Complejo_QRS    
            If Deteccion_Complejo_QRS And CheckBox_Corregir_Puntos_Complejo_QRS.CheckState Then
                Correccion_Puntos_Complejo_QRS = True
            End If

            'Determinar si tengo que relizar Filtrar_Señal
            'Valido Si esta activo el Filtrar_Señal
            'Valido si tengo que recalcular  alguna de los Deteccion_Onda_P Or Deteccion_Complejo_QRS Or Deteccion_Onda_T
            'Valido si no se ha calculado alguna de los Deteccion_Onda_P Or Deteccion_Complejo_QRS Or Deteccion_Onda_T y es ncesario hacerlo 
            If CheckBox_Filtrar_Señal.Checked Then
                If (Recalcular_Elementos And (Deteccion_Onda_P Or Deteccion_Complejo_QRS Or Deteccion_Onda_T)) Or (Recalcular_Elementos = False And (Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_P") <> 1 And Deteccion_Onda_P = True) Or (Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_T") <> 1 And Deteccion_Onda_T = True)) Then
                    Filtrar_Señal = True
                End If
            End If

            If Recalcular_Elementos Then
                'Filtrado de la Señal
                If Filtrar_Señal Then
                    Dim Coenficientes_Filtro(500) As Double
                    Coenficientes_Filtro = Modulo_Anlisis.Diseño_Filtro_Barlett(2, 500, Registro_Seleccionado.Frecuencia, Configuracion_Deteccion_QRS.Frecuencia_Baja_Filtro, Configuracion_Deteccion_QRS.Frecuencia_Alta_Filtro)
                    Modulo_Anlisis.Filtrado_Registro_500_Polos_Face_Cero_Reset_Coeficientes()
                    'Creo la base de datos de la señal filtrada
                    Registro_Analizar = Registro_Seleccionado.Tabla + "___" + CheckedListBox_Registros.CheckedItems(Index1).ToString() + "___Filtrado_Temp"
                    If Coneccion_Base_Datos_Filtrado_Temp.State <> 0 Then
                        Coneccion_Base_Datos_Filtrado_Temp.Close()
                    End If
                    Coneccion_Base_Datos_Filtrado_Temp.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Registro_Analizar)
                    Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Filtrado_Temp, Registro_Analizar)
                    If (Modulo_Anlisis.Filtrado_Registro_500_Polos_Face_Cero(Coneccion_Registro, Coneccion_Base_Datos_Filtrado_Temp, Registro_Seleccionado.Tabla, Registro_Analizar, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Coenficientes_Filtro, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False) Then
                        e.Cancel = True
                        Return
                    End If
                Else
                    If Coneccion_Base_Datos_Filtrado_Temp.State <> 0 Then
                        Coneccion_Base_Datos_Filtrado_Temp.Close()
                    End If
                    Coneccion_Base_Datos_Filtrado_Temp.ConnectionString = Coneccion_Registro.ConnectionString
                    Registro_Analizar = Registro_Seleccionado.Tabla
                End If

                'Deteccion del Complejo QRS
                'Se calcula el Complejo QRS si se solicita la recalculacion o si no se a calculado previamente y es necesario
                If Deteccion_Complejo_QRS Or (Deteccion_Complejo_QRS_temp And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Complejo_QRS") <> 1) Then
                    'Calculo de la Transformada Wavelet
                    Tabla_Transformada_Wavelet_QRS = Registro_Seleccionado.Tabla + "___" + CheckedListBox_Registros.CheckedItems(Index1).ToString() + "___Transformada_Wavelet_Complejo_QRS_Temp"
                    If Coneccion_Base_Datos_Transformada_Wavelet_QRS.State <> 0 Then
                        Coneccion_Base_Datos_Transformada_Wavelet_QRS.Close()
                    End If
                    Coneccion_Base_Datos_Transformada_Wavelet_QRS.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Tabla_Transformada_Wavelet_QRS)
                    Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Tabla_Transformada_Wavelet_QRS)

                    'Determinar la escala de la TW
                    If CheckBox_Selec_Auto_TW_QRS.Checked = True Then
                        Escala_Trasnformada_Wavelet_QRS = 1
                        While Registro_Seleccionado.Frecuencia * m(Escala_Trasnformada_Wavelet_QRS - 1) > 50 And Escala_Trasnformada_Wavelet_QRS < 10
                            Escala_Trasnformada_Wavelet_QRS = Escala_Trasnformada_Wavelet_QRS + 1
                        End While
                    Else
                        Escala_Trasnformada_Wavelet_QRS = Configuracion_Deteccion_QRS.Escala_TW_QRS
                    End If
                    Modulo_Anlisis.Transformada_Wavelet_Reset_Escala(Escala_Trasnformada_Wavelet_QRS)
                    'Creo la base de datos de la señal filtrada

                    Select Case Escala_Trasnformada_Wavelet_QRS

                        Case 1
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_1(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 2
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_2(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 3
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_3(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 4
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_4(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 5
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_5(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 6
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_6(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 7
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_7(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 8
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_8(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 9
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_9(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case Else
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_10(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                    End Select

                    'Deteccion del Complejo QRS
                    Tabla_QRS = Registro_Seleccionado.Tabla + "___Tabla_QRS_Temp"
                    If Modulo_Anlisis.Deteccion_QRS_Con_Deteccion_Puntos(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Coneccion_Registro, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Tabla_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Frecuencia, Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Tabla_Transformada_Wavelet_QRS), Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                        e.Cancel = True
                        Return
                    End If
                    'Correcion de los puntos  del Complejo QRS 
                    If Correccion_Puntos_Complejo_QRS Then
                        If Modulo_Anlisis.Correccion_Puntos_QRS_En_Señal(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Registro, Registro_Analizar, Tabla_QRS, Tabla_QRS + "_1", CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                            e.Cancel = True
                            Return
                        Else
                            Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_QRS)
                            Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS + "_1", Tabla_QRS)
                        End If
                    End If
                    'Busqueda del Complejo QRS Faltantes
                    If Busqueda_Complejos_QRS_NO_Detectados Then
                        If Modulo_Anlisis.Busqueda_Complejos_QRS_NO_Detectados_En_Transformada_Wavelet(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Coneccion_Registro, Tabla_Transformada_Wavelet_QRS, Tabla_QRS, Tabla_QRS + "_1", CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                            e.Cancel = True
                            Return
                        Else
                            Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_QRS)
                            Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS + "_1", Tabla_QRS)
                        End If
                    End If
                    'Correcion de los puntos  del Complejo QRS 
                    If Correccion_Puntos_Complejo_QRS Then
                        If Modulo_Anlisis.Correccion_Puntos_QRS_En_Señal(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Registro, Registro_Analizar, Tabla_QRS, Tabla_QRS + "_1", CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                            e.Cancel = True
                            Return
                        Else
                            Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_QRS)
                            Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS + "_1", Tabla_QRS)
                        End If
                    End If
                ElseIf Deteccion_Complejo_QRS_temp Then
                    Tabla_QRS = Registro_Seleccionado.Tabla + "___Complejo_QRS"
                End If

                'Determinar si es necesario calcular la nueva trasnfrmada waveet 
                If Deteccion_Onda_P Or Deteccion_Onda_T Or (Deteccion_Onda_P_temp And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_P") <> 1) Or (Deteccion_Onda_T_temp And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_T") <> 1) Then
                    If Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp.State <> 0 Then
                        Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp.Close()
                    End If
                    If Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp.State <> 0 Then
                        Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp.Close()
                    End If
                    'Crear base de datos temporal par ala Transformada Wavelet de busqueda
                    Tabla_Transformada_Wavelet_Onda_PT_Busqueda = Registro_Seleccionado.Tabla + "___" + CheckedListBox_Registros.CheckedItems(Index1).ToString() + "___Transformada_Wavelet_Onda_PT_Busqueda_Temp"
                    Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Tabla_Transformada_Wavelet_Onda_PT_Busqueda)
                    Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Tabla_Transformada_Wavelet_Onda_PT_Busqueda)

                    'Crear base de datos temporal par ala Transformada Wavelet de correcion
                    Tabla_Transformada_Wavelet_Onda_PT_Correcion = Registro_Seleccionado.Tabla + "___" + CheckedListBox_Registros.CheckedItems(Index1).ToString() + "___Transformada_Wavelet_Onda_PT_Correcion_Temp"
                    Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Tabla_Transformada_Wavelet_Onda_PT_Correcion)
                    Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Tabla_Transformada_Wavelet_Onda_PT_Correcion)

                    'Determinando la escala de la transformadad wavelet DWE BUsqueda y Correcion 
                    Escala_Trasnformada_Wavelet_Onda_PT_Busqueda = 1
                    If CheckBox_Selec_Auto_TW_Onda_PT_Busqueda.CheckState Then
                        While Registro_Seleccionado.Frecuencia * m(Escala_Trasnformada_Wavelet_Onda_PT_Busqueda - 1) > 35 And Escala_Trasnformada_Wavelet_Onda_PT_Busqueda < 10
                            Escala_Trasnformada_Wavelet_Onda_PT_Busqueda = Escala_Trasnformada_Wavelet_Onda_PT_Busqueda + 1
                        End While
                    Else
                        Escala_Trasnformada_Wavelet_Onda_PT_Busqueda = Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda
                    End If

                    If CheckBox_Selec_Auto_TW_Onda_PT_Correcion.CheckState Then
                        Escala_Trasnformada_Wavelet_Onda_PT_Correcion = 1
                    Else
                        Escala_Trasnformada_Wavelet_Onda_PT_Correcion = Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion
                    End If

                    'Calculo De la Transformada Wavelet con escala de Busqueda 
                    Modulo_Anlisis.Transformada_Wavelet_Reset_Escala(Escala_Trasnformada_Wavelet_Onda_PT_Busqueda)
                    Select Case Escala_Trasnformada_Wavelet_Onda_PT_Busqueda
                        Case 1
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_1(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 2
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_2(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 3
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_3(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 4
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_4(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 5
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_5(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 6
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_6(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 7
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_7(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 8
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_8(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 9
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_9(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case Else
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_10(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If
                    End Select

                    'Calculo De la Transformada Wavelet con escala de Correcion 
                    Modulo_Anlisis.Transformada_Wavelet_Reset_Escala(Escala_Trasnformada_Wavelet_Onda_PT_Correcion)
                    Select Case Escala_Trasnformada_Wavelet_Onda_PT_Correcion
                        Case 1
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_1(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 2
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_2(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 3
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_3(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 4
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_4(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 5
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_5(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 6
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_6(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 7
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_7(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 8
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_8(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 9
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_9(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case Else
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_10(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If
                    End Select
                End If

                'Deteccion de la Onda T
                'Se calcula el Onda T si se solicita la recalculacion o si no se a calculado previamente y es necesario
                If Deteccion_Onda_T Or (Deteccion_Onda_T_temp And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_T") <> 1) Then
                    Tabla_Onda_T = Registro_Seleccionado.Tabla + "___Tabla_Onda_T_Temp"
                    If Modulo_Anlisis.Deteccion_Onda_T_Clasificacion_Con_Correccion(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Coneccion_Registro, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Tabla_QRS, Tabla_Onda_T, Registro_Seleccionado.Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                        e.Cancel = True
                        Return
                    End If
                Else
                    Tabla_Onda_T = Registro_Seleccionado.Tabla + "___Onda_T"
                End If

                'Deteccion de la Onda P
                'Se calcula el Onda P si se solicita la recalculacion o si no se a calculado previamente y es necesario
                If Deteccion_Onda_P Or (Deteccion_Onda_P_temp And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_P") <> 1) Then
                    Tabla_Onda_P = Registro_Seleccionado.Tabla + "___Tabla_Onda_P_Temp"
                    If Modulo_Anlisis.Deteccion_Onda_P_Clasificacion_Con_Correccion(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Coneccion_Registro, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Tabla_QRS, Tabla_Onda_P, Registro_Seleccionado.Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                        e.Cancel = True
                        Return
                    End If
                Else
                    Tabla_Onda_P = Registro_Seleccionado.Tabla + "___Onda_P"
                End If
                'Calculo Intervalo R-R
                If Deteccion_Intervalo_R_R Then
                    Tabla_Intervalo_R_R = Registro_Seleccionado.Tabla + "___Tabla_Intervalo_R_R_Temp"
                    If Modulo_Anlisis.Calculo_Intervalo_En_Una_Tabla(Coneccion_Registro, Tabla_QRS, "R", Tabla_Intervalo_R_R, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Frecuencia, BackgroundWorker_Analisis_Registro) = False Then
                        e.Cancel = True
                        Return
                    End If
                End If
                'Calculo Intervalo Q-T
                If Deteccion_Intervalo_Q_T Then
                    Tabla_Intervalo_Q_T = Registro_Seleccionado.Tabla + "___Tabla_Intervalo_Q_T_Temp"
                    If Modulo_Anlisis.Calculo_Intervalo_En_Dos_Tabla(Coneccion_Registro, Tabla_QRS, "Q", Tabla_Onda_T, "T", Tabla_Intervalo_Q_T, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Frecuencia, BackgroundWorker_Analisis_Registro) = False Then
                        e.Cancel = True
                        Return
                    End If
                End If
                'Calculo Intervalo P-R
                If Deteccion_Intervalo_P_R Then
                    Tabla_Intervalo_P_R = Registro_Seleccionado.Tabla + "___Tabla_Intervalo_P_R_Temp"
                    If Modulo_Anlisis.Calculo_Intervalo_En_Dos_Tabla(Coneccion_Registro, Tabla_Onda_P, "P", Tabla_QRS, "R", Tabla_Intervalo_P_R, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Frecuencia, BackgroundWorker_Analisis_Registro) = False Then
                        e.Cancel = True
                        Return
                    End If
                End If
            Else
                'Filtrado de la Señal
                If Filtrar_Señal And ((Deteccion_Complejo_QRS Or Deteccion_Complejo_QRS_temp) And (Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Complejo_QRS") <> 1 Or Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_T") <> 1 Or Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_P") <> 1)) Then
                    Dim Coenficientes_Filtro(500) As Double
                    Coenficientes_Filtro = Modulo_Anlisis.Diseño_Filtro_Barlett(2, 500, Registro_Seleccionado.Frecuencia, Configuracion_Deteccion_QRS.Frecuencia_Baja_Filtro, Configuracion_Deteccion_QRS.Frecuencia_Alta_Filtro)
                    Modulo_Anlisis.Filtrado_Registro_500_Polos_Face_Cero_Reset_Coeficientes()
                    'Creo la base de datos de la señal filtrada
                    Registro_Analizar = Registro_Seleccionado.Tabla + "___" + CheckedListBox_Registros.CheckedItems(Index1).ToString() + "___Filtrado_Temp"
                    If Coneccion_Base_Datos_Filtrado_Temp.State <> 0 Then
                        Coneccion_Base_Datos_Filtrado_Temp.Close()
                    End If
                    Coneccion_Base_Datos_Filtrado_Temp.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Registro_Analizar)
                    Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Filtrado_Temp, Registro_Analizar)
                    If (Modulo_Anlisis.Filtrado_Registro_500_Polos_Face_Cero(Coneccion_Registro, Coneccion_Base_Datos_Filtrado_Temp, Registro_Seleccionado.Tabla, Registro_Analizar, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Coenficientes_Filtro, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False) Then
                        e.Cancel = True
                        Return
                    End If
                Else
                    If Coneccion_Base_Datos_Filtrado_Temp.State <> 0 Then
                        Coneccion_Base_Datos_Filtrado_Temp.Close()
                    End If
                    Coneccion_Base_Datos_Filtrado_Temp.ConnectionString = Coneccion_Registro.ConnectionString
                    Registro_Analizar = Registro_Seleccionado.Tabla
                End If
                'Deteccion del Complejo QRS
                If Deteccion_Complejo_QRS Or Deteccion_Complejo_QRS_temp Then
                    'Determino si ya esta calculado la uvicacion del Complejo QRS
                    If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Complejo_QRS") = 1 Then
                        Tabla_QRS = Registro_Seleccionado.Tabla + "___Complejo_QRS"
                    Else
                        'Calculo de la Transformada Wavelet
                        Tabla_Transformada_Wavelet_QRS = Registro_Seleccionado.Tabla + "___" + CheckedListBox_Registros.CheckedItems(Index1).ToString() + "___Transformada_Wavelet_Complejo_QRS_Temp"
                        If Coneccion_Base_Datos_Transformada_Wavelet_QRS.State <> 0 Then
                            Coneccion_Base_Datos_Transformada_Wavelet_QRS.Close()
                        End If
                        Coneccion_Base_Datos_Transformada_Wavelet_QRS.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Tabla_Transformada_Wavelet_QRS)
                        Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Tabla_Transformada_Wavelet_QRS)

                        'Determinar la escala de la TW
                        If CheckBox_Selec_Auto_TW_QRS.Checked = True Then
                            Escala_Trasnformada_Wavelet_QRS = 1
                            While Registro_Seleccionado.Frecuencia * m(Escala_Trasnformada_Wavelet_QRS - 1) > 50 And Escala_Trasnformada_Wavelet_QRS < 10
                                Escala_Trasnformada_Wavelet_QRS = Escala_Trasnformada_Wavelet_QRS + 1
                            End While
                        Else
                            Escala_Trasnformada_Wavelet_QRS = Configuracion_Deteccion_QRS.Escala_TW_QRS
                        End If
                        Modulo_Anlisis.Transformada_Wavelet_Reset_Escala(Escala_Trasnformada_Wavelet_QRS)
                        'Creo la base de datos de la señal filtrada

                        Select Case Escala_Trasnformada_Wavelet_QRS

                            Case 1
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_1(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 2
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_2(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 3
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_3(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 4
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_4(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 5
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_5(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 6
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_6(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 7
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_7(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 8
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_8(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 9
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_9(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case Else
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_10(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                        End Select

                        'Deteccion del Complejo QRS
                        Tabla_QRS = Registro_Seleccionado.Tabla + "___Tabla_QRS_Temp"
                        If Modulo_Anlisis.Deteccion_QRS_Con_Deteccion_Puntos(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Coneccion_Registro, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Tabla_QRS, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Frecuencia, Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Tabla_Transformada_Wavelet_QRS), Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                            e.Cancel = True
                            Return
                        End If
                        'Correcion de los puntos  del Complejo QRS 
                        If Correccion_Puntos_Complejo_QRS Then
                            If Modulo_Anlisis.Correccion_Puntos_QRS_En_Señal(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Registro, Registro_Analizar, Tabla_QRS, Tabla_QRS + "_1", CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            Else
                                Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_QRS)
                                Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS + "_1", Tabla_QRS)
                            End If
                        End If
                        'Busqueda del Complejo QRS Faltantes
                        If Busqueda_Complejos_QRS_NO_Detectados Then
                            If Modulo_Anlisis.Busqueda_Complejos_QRS_NO_Detectados_En_Transformada_Wavelet(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Coneccion_Registro, Tabla_Transformada_Wavelet_QRS, Tabla_QRS, Tabla_QRS + "_1", CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            Else
                                Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_QRS)
                                Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS + "_1", Tabla_QRS)
                            End If
                        End If
                        'Correcion de los puntos  del Complejo QRS 
                        If Correccion_Puntos_Complejo_QRS Then
                            If Modulo_Anlisis.Correccion_Puntos_QRS_En_Señal(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Registro, Registro_Analizar, Tabla_QRS, Tabla_QRS + "_1", CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            Else
                                Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_QRS)
                                Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS + "_1", Tabla_QRS)
                            End If
                        End If
                    End If
                End If

                'Determinar si es necesario obtner la TW para la obtencio de las Ondas T o P
                If (Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_P") <> 1 And (Deteccion_Onda_P = True Or Deteccion_Onda_P_temp = True)) Or (Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_T") <> 1 And (Deteccion_Onda_T = True Or Deteccion_Onda_T_temp = True)) Then
                    If Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp.State <> 0 Then
                        Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp.Close()
                    End If
                    If Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp.State <> 0 Then
                        Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp.Close()
                    End If
                    'Crear base de datos temporal par ala Transformada Wavelet de busqueda
                    Tabla_Transformada_Wavelet_Onda_PT_Busqueda = Registro_Seleccionado.Tabla + "___" + CheckedListBox_Registros.CheckedItems(Index1).ToString() + "___Transformada_Wavelet_Onda_PT_Busqueda_Temp"
                    Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Tabla_Transformada_Wavelet_Onda_PT_Busqueda)
                    Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Tabla_Transformada_Wavelet_Onda_PT_Busqueda)

                    'Crear base de datos temporal par ala Transformada Wavelet de correcion
                    Tabla_Transformada_Wavelet_Onda_PT_Correcion = Registro_Seleccionado.Tabla + "___" + CheckedListBox_Registros.CheckedItems(Index1).ToString() + "___Transformada_Wavelet_Onda_PT_Correcion_Temp"
                    Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Tabla_Transformada_Wavelet_Onda_PT_Correcion)
                    Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Tabla_Transformada_Wavelet_Onda_PT_Correcion)

                    'Determinando la escala de la transformadad wavelet DWE BUsqueda y Correcion 
                    Escala_Trasnformada_Wavelet_Onda_PT_Busqueda = 1
                    If CheckBox_Selec_Auto_TW_Onda_PT_Busqueda.CheckState Then
                        While Registro_Seleccionado.Frecuencia * m(Escala_Trasnformada_Wavelet_Onda_PT_Busqueda - 1) > 35 And Escala_Trasnformada_Wavelet_Onda_PT_Busqueda < 10
                            Escala_Trasnformada_Wavelet_Onda_PT_Busqueda = Escala_Trasnformada_Wavelet_Onda_PT_Busqueda + 1
                        End While
                    Else
                        Escala_Trasnformada_Wavelet_Onda_PT_Busqueda = Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda
                    End If

                    If CheckBox_Selec_Auto_TW_Onda_PT_Correcion.CheckState Then
                        Escala_Trasnformada_Wavelet_Onda_PT_Correcion = 1
                    Else
                        Escala_Trasnformada_Wavelet_Onda_PT_Correcion = Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion
                    End If

                    'Calculo De la Transformada Wavelet con escala de Busqueda 
                    Modulo_Anlisis.Transformada_Wavelet_Reset_Escala(Escala_Trasnformada_Wavelet_Onda_PT_Busqueda)
                    Select Case Escala_Trasnformada_Wavelet_Onda_PT_Busqueda
                        Case 1
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_1(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 2
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_2(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 3
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_3(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 4
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_4(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 5
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_5(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 6
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_6(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 7
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_7(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 8
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_8(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 9
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_9(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case Else
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_10(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If
                    End Select

                    'Calculo De la Transformada Wavelet con escala de Correcion 
                    Modulo_Anlisis.Transformada_Wavelet_Reset_Escala(Escala_Trasnformada_Wavelet_Onda_PT_Correcion)
                    Select Case Escala_Trasnformada_Wavelet_Onda_PT_Correcion
                        Case 1
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_1(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 2
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_2(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 3
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_3(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 4
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_4(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 5
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_5(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 6
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_6(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 7
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_7(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 8
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_8(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case 9
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_9(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        Case Else
                            If Modulo_Anlisis.Transformada_Wavelet_Escala_10(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If
                    End Select

                End If

                'Deteccion de la Onda T
                If Deteccion_Onda_T Or Deteccion_Onda_T_temp Then
                    If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_T") = 1 Then
                        Tabla_Onda_T = Registro_Seleccionado.Tabla + "___Onda_T"
                    Else
                        Tabla_Onda_T = Registro_Seleccionado.Tabla + "___Tabla_Onda_T_Temp"
                        If Modulo_Anlisis.Deteccion_Onda_T_Clasificacion_Con_Correccion(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Coneccion_Registro, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Tabla_QRS, Tabla_Onda_T, Registro_Seleccionado.Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                            e.Cancel = True
                            Return
                        End If
                    End If
                End If
                'Deteccion de la Onda P
                If Deteccion_Onda_P Or Deteccion_Onda_P_temp Then
                    If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_P") = 1 Then
                        Tabla_Onda_P = Registro_Seleccionado.Tabla + "___Onda_P"
                    Else
                        Tabla_Onda_P = Registro_Seleccionado.Tabla + "___Tabla_Onda_P_Temp"
                        If Modulo_Anlisis.Deteccion_Onda_P_Clasificacion_Con_Correccion(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Coneccion_Registro, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Tabla_Transformada_Wavelet_Onda_PT_Correcion, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Tabla_QRS, Tabla_Onda_P, Registro_Seleccionado.Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Registro) = False Then
                            e.Cancel = True
                            Return
                        End If
                    End If
                End If

                'Calculo Intervalo R-R
                If Deteccion_Intervalo_R_R Then
                    If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Intervalo_R_R") = 1 Then
                        Tabla_Intervalo_R_R = Registro_Seleccionado.Tabla + "___Intervalo_R_R"
                    Else
                        Tabla_Intervalo_R_R = Registro_Seleccionado.Tabla + "___Tabla_Intervalo_R_R_Temp"
                        If Modulo_Anlisis.Calculo_Intervalo_En_Una_Tabla(Coneccion_Registro, Tabla_QRS, "R", "Temp", CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Frecuencia, BackgroundWorker_Analisis_Registro) = False Then
                            e.Cancel = True
                            Return
                        End If
                    End If
                End If

                'Calculo Intervalo Q-T
                If Deteccion_Intervalo_Q_T Then
                    If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Intervalo_Q_T") = 1 Then
                        Tabla_Intervalo_Q_T = Registro_Seleccionado.Tabla + "___Intervalo_Q_T"
                    Else
                        Tabla_Intervalo_Q_T = Registro_Seleccionado.Tabla + "___Tabla_Intervalo_Q_T_Temp"
                        If Modulo_Anlisis.Calculo_Intervalo_En_Dos_Tabla(Coneccion_Registro, Tabla_QRS, "Q", Tabla_Onda_T, "T", Tabla_Intervalo_Q_T, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Frecuencia, BackgroundWorker_Analisis_Registro) = False Then
                            e.Cancel = True
                            Return
                        End If
                    End If
                End If
                'Calculo Intervalo P-R
                If Deteccion_Intervalo_P_R Then
                    If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Intervalo_P_R") = 1 Then
                        Tabla_Intervalo_P_R = Registro_Seleccionado.Tabla + "___Intervalo_P_R"
                    Else
                        Tabla_Intervalo_P_R = Registro_Seleccionado.Tabla + "___Tabla_Intervalo_P_R_Temp"
                        If Modulo_Anlisis.Calculo_Intervalo_En_Dos_Tabla(Coneccion_Registro, Tabla_QRS, "Q", Tabla_Onda_T, "T", Tabla_Intervalo_P_R, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Registro_Seleccionado.Frecuencia, BackgroundWorker_Analisis_Registro) = False Then
                            e.Cancel = True
                            Return
                        End If
                    End If
                End If
            End If


            'Almacenar Datos(Se modifica ekl nombre de las tablas de los elementos selecionados por lo que se eliminan los temporales), Si no se entra en esta obcion los datos quedan en los temporales

            If Recalcular_Elementos Then
                'Comprobar si existe el registro rescribirlo 
                If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Derivacion_Filtrada") = 2 Then
                    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Agregar_Dato(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Derivacion_Filtrada", "0")
                    'Else
                    '    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Eliminar_Dato(Coneccion_Registro, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString())
                    '    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Agregar_Dato(Coneccion_Registro, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Derivacion_Filtrada", "0")
                End If

                If Deteccion_Complejo_QRS Then
                    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Complejo_QRS", "1")
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Registro_Seleccionado.Tabla + "___Complejo_QRS")
                    'If CheckBox_Corregir_Puntos_Complejo_QRS.CheckState Then
                    '    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS + "_1", Registro_Seleccionado.Tabla   + "___Complejo_QRS")
                    'Else
                    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS, Registro_Seleccionado.Tabla + "___Complejo_QRS")
                    'End If
                End If
                If Deteccion_Onda_T Then
                    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_T", "1")
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Registro_Seleccionado.Tabla + "___Onda_T")
                    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Onda_T, Registro_Seleccionado.Tabla + "___Onda_T")

                End If
                If Deteccion_Onda_P Then
                    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_P", "1")
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Registro_Seleccionado.Tabla + "___Onda_P")
                    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Onda_P, Registro_Seleccionado.Tabla + "___Onda_P")
                End If

                If Deteccion_Intervalo_R_R Then
                    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Intervalo_R_R", "1")
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Registro_Seleccionado.Tabla + "___Intervalo_R_R")
                    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Intervalo_R_R, Registro_Seleccionado.Tabla + "___Intervalo_R_R")
                End If

                If Deteccion_Intervalo_Q_T Then
                    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Intervalo_Q_T", "1")
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Registro_Seleccionado.Tabla + "___Intervalo_Q_T")
                    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Intervalo_Q_T, Registro_Seleccionado.Tabla + "___Intervalo_Q_T")
                End If

                If Deteccion_Intervalo_P_R Then
                    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Intervalo_P_R", "1")
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Registro_Seleccionado.Tabla + "___Intervalo_P_R")
                    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Intervalo_P_R, Registro_Seleccionado.Tabla + "___Intervalo_P_R")
                End If

            Else
                'Comprobar si existe el registro rescribirlo 
                If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Derivacion_Filtrada") = 2 Then
                    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Agregar_Dato(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Derivacion_Filtrada", "0")
                End If

                If Deteccion_Complejo_QRS And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Complejo_QRS") <> 1 Then
                    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Complejo_QRS", "1")
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Registro_Seleccionado.Tabla + "___Complejo_QRS")
                    'If CheckBox_Corregir_Puntos_Complejo_QRS.CheckState Then
                    '    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS + "_1", Registro_Seleccionado.Tabla   + "___Complejo_QRS")
                    'Else
                    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS, Registro_Seleccionado.Tabla + "___Complejo_QRS")
                    'End If
                End If
                If Deteccion_Onda_T And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_T") <> 1 Then
                    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_T", "1")
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Registro_Seleccionado.Tabla + "___Onda_T")
                    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Onda_T, Registro_Seleccionado.Tabla + "___Onda_T")

                End If
                If Deteccion_Onda_P And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_P") <> 1 Then
                    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Onda_P", "1")
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Registro_Seleccionado.Tabla + "___Onda_P")
                    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Onda_P, Registro_Seleccionado.Tabla + "___Onda_P")
                End If

                If Deteccion_Intervalo_R_R And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Intervalo_R_R") <> 1 Then
                    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Intervalo_R_R", "1")
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Registro_Seleccionado.Tabla + "___Intervalo_R_R")
                    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Intervalo_R_R, Registro_Seleccionado.Tabla + "___Intervalo_R_R")
                End If

                If Deteccion_Intervalo_Q_T And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Intervalo_Q_T") <> 1 Then
                    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Intervalo_Q_T", "1")
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Registro_Seleccionado.Tabla + "___Intervalo_Q_T")
                    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Intervalo_Q_T, Registro_Seleccionado.Tabla + "___Intervalo_Q_T")
                End If

                If Deteccion_Intervalo_P_R And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Intervalo_P_R") <> 1 Then
                    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Registro_Seleccionado.Tabla, CheckedListBox_Registros.CheckedItems(Index1).ToString(), "Intervalo_P_R", "1")
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Registro_Seleccionado.Tabla + "___Intervalo_P_R")
                    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Intervalo_P_R, Registro_Seleccionado.Tabla + "___Intervalo_P_R")
                End If
            End If

            If CheckBox_Eliminar_Temporales_Calculados.Checked Then
                Dim Nombre_Tablas_Existentes As New DataSet
                Nombre_Tablas_Existentes = Class_Funciones_Base_Datos.Tabla_Todas_Existentes(Coneccion_Registro)

                For Index = Nombre_Tablas_Existentes.Tables(0).Rows.Count - 1 To 0 Step -1
                    If InStr(Nombre_Tablas_Existentes.Tables(0).Rows(Index)(0), "Temp") <> 0 Then
                        Class_Funciones_Base_Datos.Tabla_Eliminar(Coneccion_Registro, Nombre_Tablas_Existentes.Tables(0).Rows(Index)(0))
                    End If
                Next Index
                Class_Funciones_Base_Datos.Eliminar_Base_Datos(Registro_Analizar)
                Class_Funciones_Base_Datos.Eliminar_Base_Datos(Tabla_Transformada_Wavelet_QRS)
                Class_Funciones_Base_Datos.Eliminar_Base_Datos(Tabla_Transformada_Wavelet_Onda_PT_Busqueda)
                Class_Funciones_Base_Datos.Eliminar_Base_Datos(Tabla_Transformada_Wavelet_Onda_PT_Correcion)
                'Optimiso la base de datos
                Try
                    Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Registro)
                    Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Registro)
                Catch ex As Exception

                End Try
            Else
                If (Tabla_Transformada_Wavelet_Onda_PT_Busqueda <> Nothing) Then
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_Transformada_Wavelet_Onda_PT_Busqueda)
                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_Transformada_Wavelet_Onda_PT_Correcion)
                End If
                Try
                    Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_QRS)
                    Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_QRS)
                    Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp)
                    Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp)
                    Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp)
                    Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp)
                    Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Base_Datos_Filtrado_Temp)
                    Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Base_Datos_Filtrado_Temp)
                    Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Registro)
                    Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Registro)
                Catch ex As Exception

                End Try
            End If
            'Optimiso el espacio de la base de datos del registro y sus indeices de busqueda
            'Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Registro)
            'Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Registro)



            Coneccion_Registro.Close()
            Coneccion_Registro.Dispose()
        Next
        'Optimiso el espacio de la base de datos principal y sus indeices de busqueda
        'Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Base_Datos)
        'Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Base_Datos)

        Coneccion_Base_Datos.Close()
        Coneccion_Base_Datos.Dispose()
    End Sub

    Private Sub BackgroundWorker_Analisis_Registro_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_Analisis_Registro.RunWorkerCompleted
        Dim Contraseña_Incorrecta As New Form_Mensaje_Error
        Button_Analizar_Registro.Enabled = True

        Button_Analizar_Registro.Text = "Analyze"

        ProgressBar_Progreso_Analisis.Value = 0
        Label_Registro_Analizado_Multi_Registro.Text = "Record"
        Label_Progreso.Text = "Progress"
        If e.Cancelled = True Then
            Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "Analysis", "Canceled", "Finished", 0)
        Else
            Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "Analysis", "Completed", "Completed", 1)
        End If

        'Desbloquear el registro anterior 
        Form_Principal.Estado_Registros.Desbloquear_Registro(Registro_Seleccionado.Usuario, Registro_Seleccionado.Paciente, Registro_Seleccionado.Fecha_Registro)
        'Desbloquear parametros de analisis
        TabPageEX_Configuracion_Análisis.Enabled = True
        TabPageEX_Filtrar_Señal.Enabled = True
        Button_Cargar_Registro.Enabled = True
        Button_Eliminar_Registro_Multi_Registro.Enabled = True

        ''Liberando Archivo Temporal 
        'If CheckBox_Almacenar_Resultados.Checked = False Then
        '    Form_Principal.Estado_Registros.Desbloquear_Registro("_", "_", "Temp")
        'End If
    End Sub

    Private Sub BackgroundWorker_Analisis_Registro_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker_Analisis_Registro.ProgressChanged
        Dim Progreso As Int64 = e.ProgressPercentage
        Dim Porcentaje_Progreso As Int64 = Progreso Mod 1000
        Dim Derivacion As Int64 = (Progreso Mod 100000) / 1000
        Dim Procedimiento As Int64 = Math.Floor(Progreso / 100000)
        Dim Texto As String
        Texto = Convert.ToString(Porcentaje_Progreso) + "% " + Modulo_Anlisis.Derivada_To_String(Derivacion) + " "

        Const Procedimiento_Filtrando_Señal = 1
        Const Procedimiento_Trasnformada_Wavelet = 2
        Const Procedimiento_Deteccion_QRS = 3
        Const Procedimiento_Deteccion_Onda_T = 4
        Const Procedimiento_Deteccion_Onda_P = 5
        Const Procedimiento_Correcion_Puntos_Complejo_QRS = 6
        Const Procedimiento_Busqueda_Complejo_QRS_No_Detectados = 7
        Const Procedimiento_Calculo_Intervalo = 8
        Const Procedimiento_Calculo_Intervalo_RR = 9
        Const Procedimiento_Calculo_Intervalo_QT = 10
        Const Procedimiento_Calculo_Intervalo_PR = 11

        Select Case Procedimiento
            Case Procedimiento_Filtrando_Señal
                Texto = Texto + "Filtering Derivation"
            Case Procedimiento_Trasnformada_Wavelet
                Texto = Texto + "Calculation Wavelet Transform"
            Case Procedimiento_Deteccion_QRS
                Texto = Texto + "Obtaining points of the QRS complex"
            Case Procedimiento_Deteccion_Onda_T
                Texto = Texto + "Obtaining points of Wave T"
            Case Procedimiento_Deteccion_Onda_P
                Texto = Texto + "Obtaining points of Wave P"
            Case Procedimiento_Correcion_Puntos_Complejo_QRS
                Texto = Texto + "Correction of QRS Complex Points"
            Case Procedimiento_Busqueda_Complejo_QRS_No_Detectados
                Texto = Texto + "Search for Undetected QRS Complexes"
            Case Procedimiento_Calculo_Intervalo
                Texto = Texto + "Interval Calculation"
            Case Procedimiento_Calculo_Intervalo_RR
                Texto = Texto + "RR Interval Calculation"
            Case Procedimiento_Calculo_Intervalo_QT
                Texto = Texto + "QT Interval Calculation"
            Case Procedimiento_Calculo_Intervalo_PR
                Texto = Texto + "PR Interval Calculation"
            Case Else
        End Select
        Label_Progreso.Text = Texto
        If Porcentaje_Progreso > 100 Then
            Porcentaje_Progreso = 100
        End If
        ProgressBar_Progreso_Analisis.Value = Porcentaje_Progreso
    End Sub

    Private Sub Button_Analizar_Registro_Click(sender As Object, e As EventArgs) Handles Button_Analizar_Registro.Click
        'Identifico si se selecciono un elemento a calcular
        Dim Bandera_Proceso As Boolean = False
        For Index_TreeView_0 = 0 To TreeView_Elementos_Calcular.Nodes.Count - 1
            For Index_TreeView_1 = 0 To TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes.Count - 1
                If TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked Then
                    Bandera_Proceso = True
                End If
                If Bandera_Proceso Then
                    Exit For
                End If
            Next
            If Bandera_Proceso Then
                Exit For
            End If
        Next

        If Bandera_Proceso Then
            'Identifico si se va analizar un solo registro o varios
            If CheckBox_Analisis_Multi_Registro.Checked Then
                If CheckedListBox_Registros_Analizar_Multi_Registro.Items.Count > 0 Then
                    If (Button_Analizar_Registro.Text = "Analyze") Then
                        Button_Analizar_Registro.Text = "Cancel"
                        'Bloque o los parametros del analisis 
                        TabPageEX_Configuracion_Análisis.Enabled = False
                        TabPageEX_Filtrar_Señal.Enabled = False
                        Button_Cargar_Registro.Enabled = False
                        Button_Eliminar_Registro_Multi_Registro.Enabled = False
                        'Inicio el analisis
                        BackgroundWorker_Analisis_Multi_Registro.RunWorkerAsync()

                    Else
                        Label_Progreso.Text = "Canceling Analysis"
                        Button_Analizar_Registro.Text = "Canceling Analysis"
                        Button_Analizar_Registro.Enabled = False
                        BackgroundWorker_Analisis_Multi_Registro.CancelAsync()
                    End If

                Else
                    'Mesaje de que no se ha seleciondado ningun registro
                    Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                    Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "No record selected", "", "Error in the Record", 0)
                End If
            Else

                If CheckedListBox_Registros.CheckedItems.Count <> 0 Then
                    'If Form_Principal.Estado_Registros.Consultar_Registro_Bloqueado("_", "_", "Temp") = True And CheckBox_Almacenar_Resultados.Checked = False Then
                    '    'Mesaje de que el Regsitrp ya esta en uso
                    '    Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                    '    Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "Los archivos temporales", "ya estan en uso", "Error in the Record")
                    'Else
                    If (Button_Analizar_Registro.Text = "Analyze") Then
                        Button_Analizar_Registro.Text = "Cancel"

                        'Bloqueando Archivo Temporal 
                        Form_Principal.Estado_Registros.Bloquear_Registro(Registro_Seleccionado.Usuario, Registro_Seleccionado.Paciente, Registro_Seleccionado.Fecha_Registro)
                        'Bloque o los parametros del analisis 
                        TabPageEX_Configuracion_Análisis.Enabled = False
                        TabPageEX_Filtrar_Señal.Enabled = False
                        Button_Cargar_Registro.Enabled = False
                        Button_Eliminar_Registro_Multi_Registro.Enabled = False
                        'Inicio el analisis
                        BackgroundWorker_Analisis_Registro.RunWorkerAsync()

                        'If CheckBox_Almacenar_Resultados.Checked = False Then
                        '    'Bloqueando Archivo Temporal 
                        '    Form_Principal.Estado_Registros.Bloquear_Registro("_", "_", "Temp")
                        'End If
                    Else
                        Label_Progreso.Text = "Canceling Analysis"
                        Button_Analizar_Registro.Text = "Canceling Analysis"
                        Button_Analizar_Registro.Enabled = False
                        BackgroundWorker_Analisis_Registro.CancelAsync()
                    End If


                    'End If

                Else
                    'Mesaje de que no se ha seleciondado ningun registro
                    Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                    Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "No record selected", "", "Error in the Record", 0)
                End If
            End If
        Else
            'Mesaje de que no se ha seleciondado ningun registro
            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "No Parameter to Calculate selected", "", "Error in Parameters to Calculate", 0)
        End If

    End Sub



    Private Sub CheckBox_Filtro_Personalizado_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Filtro_Personalizado.CheckedChanged

        If CheckBox_Filtro_Personalizado.Checked Then

            ComboBox_fcb.Left = 14
            ComboBox_fca.Left = 168
            CheckBox_Filtro_Para_Banda.Left = 14
            CheckBox_Filtro_Pasa_Banda.Left = 14

            ComboBox_fcb.Visible = True
            ComboBox_fca.Visible = True
            CheckBox_Filtro_Pasa_Banda.Visible = True
            CheckBox_Filtro_Para_Banda.Visible = True

            CheckBox_fcb_Ninguna.Visible = False
            CheckBox_fcb_005_Hz.Visible = False
            CheckBox_fcb_05_Hz.Visible = False
            CheckBox_fcb_1_Hz.Visible = False
            CheckBox_fcb_5_Hz.Visible = False
            CheckBox_fcb_10_Hz.Visible = False

            CheckBox_fca_Ninguna.Visible = False
            CheckBox_fca_50_Hz.Visible = False
            CheckBox_fca_100_Hz.Visible = False
            CheckBox_fca_150_Hz.Visible = False
            CheckBox_fca_200_Hz.Visible = False

            Label_Filtro_Notch.Visible = False
            CheckBox_Notch_Ninguna.Visible = False
            CheckBox_Notch_50_Hz.Visible = False
            CheckBox_Notch_60_Hz.Visible = False
        Else
            ComboBox_fcb.Visible = False
            ComboBox_fca.Visible = False
            CheckBox_Filtro_Pasa_Banda.Visible = False
            CheckBox_Filtro_Para_Banda.Visible = False

            CheckBox_fcb_Ninguna.Visible = True
            CheckBox_fcb_005_Hz.Visible = True
            CheckBox_fcb_05_Hz.Visible = True
            CheckBox_fcb_1_Hz.Visible = True
            CheckBox_fcb_5_Hz.Visible = True
            CheckBox_fcb_10_Hz.Visible = True

            CheckBox_fca_Ninguna.Visible = True
            CheckBox_fca_50_Hz.Visible = True
            CheckBox_fca_100_Hz.Visible = True
            CheckBox_fca_150_Hz.Visible = True
            CheckBox_fca_200_Hz.Visible = True

            Label_Filtro_Notch.Visible = True
            CheckBox_Notch_Ninguna.Visible = True
            CheckBox_Notch_50_Hz.Visible = True
            CheckBox_Notch_60_Hz.Visible = True

        End If
    End Sub

    Private Sub CheckBox_fcb_Ninguna_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox_fcb_Ninguna.MouseUp
        CheckBox_fcb_Ninguna.Checked = True
        CheckBox_fcb_005_Hz.Checked = False
        CheckBox_fcb_05_Hz.Checked = False
        CheckBox_fcb_1_Hz.Checked = False
        CheckBox_fcb_5_Hz.Checked = False
        CheckBox_fcb_10_Hz.Checked = False

        CheckBox_Notch_Ninguna.Checked = True
        CheckBox_Notch_50_Hz.Checked = False
        CheckBox_Notch_60_Hz.Checked = False
    End Sub

    Private Sub CheckBox_fcb_1_Hz_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox_fcb_1_Hz.MouseUp
        CheckBox_fcb_Ninguna.Checked = False
        CheckBox_fcb_005_Hz.Checked = False
        CheckBox_fcb_05_Hz.Checked = False
        CheckBox_fcb_1_Hz.Checked = True
        CheckBox_fcb_5_Hz.Checked = False
        CheckBox_fcb_10_Hz.Checked = False

        CheckBox_Notch_Ninguna.Checked = True
        CheckBox_Notch_50_Hz.Checked = False
        CheckBox_Notch_60_Hz.Checked = False
    End Sub

    Private Sub CheckBox_fcb_5_Hz_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox_fcb_5_Hz.MouseUp

        CheckBox_fcb_Ninguna.Checked = False
        CheckBox_fcb_005_Hz.Checked = False
        CheckBox_fcb_05_Hz.Checked = False
        CheckBox_fcb_1_Hz.Checked = False
        CheckBox_fcb_5_Hz.Checked = True
        CheckBox_fcb_10_Hz.Checked = False

        CheckBox_Notch_Ninguna.Checked = True
        CheckBox_Notch_50_Hz.Checked = False
        CheckBox_Notch_60_Hz.Checked = False
    End Sub

    Private Sub CheckBox_fcb_10_Hz_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox_fcb_10_Hz.MouseUp
        CheckBox_fcb_Ninguna.Checked = False
        CheckBox_fcb_005_Hz.Checked = False
        CheckBox_fcb_05_Hz.Checked = False
        CheckBox_fcb_1_Hz.Checked = False
        CheckBox_fcb_5_Hz.Checked = False
        CheckBox_fcb_10_Hz.Checked = True

        CheckBox_Notch_Ninguna.Checked = True
        CheckBox_Notch_50_Hz.Checked = False
        CheckBox_Notch_60_Hz.Checked = False
    End Sub

    Private Sub CheckBox_fca_Ninguna_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox_fca_Ninguna.MouseUp
        CheckBox_fca_Ninguna.Checked = True
        CheckBox_fca_50_Hz.Checked = False
        CheckBox_fca_100_Hz.Checked = False
        CheckBox_fca_150_Hz.Checked = False
        CheckBox_fca_200_Hz.Checked = False

        CheckBox_Notch_Ninguna.Checked = True
        CheckBox_Notch_50_Hz.Checked = False
        CheckBox_Notch_60_Hz.Checked = False
    End Sub
    Private Sub CheckBox_fca_50_Hz_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox_fca_50_Hz.MouseUp
        CheckBox_fca_Ninguna.Checked = False
        CheckBox_fca_50_Hz.Checked = True
        CheckBox_fca_100_Hz.Checked = False
        CheckBox_fca_150_Hz.Checked = False
        CheckBox_fca_200_Hz.Checked = False

        CheckBox_Notch_Ninguna.Checked = True
        CheckBox_Notch_50_Hz.Checked = False
        CheckBox_Notch_60_Hz.Checked = False
    End Sub
    Private Sub CheckBox_fca_100_Hz_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox_fca_100_Hz.MouseUp
        CheckBox_fca_Ninguna.Checked = False
        CheckBox_fca_50_Hz.Checked = False
        CheckBox_fca_100_Hz.Checked = True
        CheckBox_fca_150_Hz.Checked = False
        CheckBox_fca_200_Hz.Checked = False

        CheckBox_Notch_Ninguna.Checked = True
        CheckBox_Notch_50_Hz.Checked = False
        CheckBox_Notch_60_Hz.Checked = False
    End Sub
    Private Sub CheckBox_fca_150_Hz_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox_fca_150_Hz.MouseUp
        CheckBox_fca_Ninguna.Checked = False
        CheckBox_fca_50_Hz.Checked = False
        CheckBox_fca_100_Hz.Checked = False
        CheckBox_fca_150_Hz.Checked = True
        CheckBox_fca_200_Hz.Checked = False

        CheckBox_Notch_Ninguna.Checked = True
        CheckBox_Notch_50_Hz.Checked = False
        CheckBox_Notch_60_Hz.Checked = False
    End Sub
    Private Sub CheckBox_fca_200_Hz_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox_fca_200_Hz.MouseUp
        CheckBox_fca_Ninguna.Checked = False
        CheckBox_fca_50_Hz.Checked = False
        CheckBox_fca_100_Hz.Checked = False
        CheckBox_fca_150_Hz.Checked = False
        CheckBox_fca_200_Hz.Checked = True

        CheckBox_Notch_Ninguna.Checked = True
        CheckBox_Notch_50_Hz.Checked = False
        CheckBox_Notch_60_Hz.Checked = False
    End Sub
    Private Sub CheckBox_Notch_Ninguna_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox_Notch_Ninguna.MouseUp
        CheckBox_Notch_Ninguna.Checked = True
        CheckBox_Notch_50_Hz.Checked = False
        CheckBox_Notch_60_Hz.Checked = False
    End Sub
    Private Sub CheckBox_Notch_50_Hz_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox_Notch_50_Hz.MouseUp
        CheckBox_Notch_Ninguna.Checked = False
        CheckBox_Notch_50_Hz.Checked = True
        CheckBox_Notch_60_Hz.Checked = False

        CheckBox_fca_Ninguna.Checked = True
        CheckBox_fca_50_Hz.Checked = False
        CheckBox_fca_100_Hz.Checked = False
        CheckBox_fca_150_Hz.Checked = False
        CheckBox_fca_200_Hz.Checked = False

        CheckBox_fcb_Ninguna.Checked = True
        CheckBox_fcb_1_Hz.Checked = False
        CheckBox_fcb_5_Hz.Checked = False
        CheckBox_fcb_10_Hz.Checked = False
    End Sub
    Private Sub CheckBox_Notch_60_Hz_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox_Notch_60_Hz.MouseUp
        CheckBox_Notch_Ninguna.Checked = False
        CheckBox_Notch_50_Hz.Checked = False
        CheckBox_Notch_60_Hz.Checked = True

        CheckBox_fca_Ninguna.Checked = True
        CheckBox_fca_50_Hz.Checked = False
        CheckBox_fca_100_Hz.Checked = False
        CheckBox_fca_150_Hz.Checked = False
        CheckBox_fca_200_Hz.Checked = False

        CheckBox_fcb_Ninguna.Checked = True
        CheckBox_fcb_1_Hz.Checked = False
        CheckBox_fcb_5_Hz.Checked = False
        CheckBox_fcb_10_Hz.Checked = False
    End Sub
    Private Sub CheckBox_Filtro_Pasa_Banda_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox_Filtro_Pasa_Banda.MouseUp
        CheckBox_Filtro_Pasa_Banda.Checked = True
        CheckBox_Filtro_Para_Banda.Checked = False

    End Sub
    Private Sub CheckBox_Filtro_Para_Banda_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox_Filtro_Para_Banda.MouseUp
        CheckBox_Filtro_Pasa_Banda.Checked = False
        CheckBox_Filtro_Para_Banda.Checked = True
    End Sub

    Private Sub Button_Filtrar_Registro_Click(sender As Object, e As EventArgs) Handles Button_Filtrar_Registro.Click

        If Label_Registro_Seleccionado.Text = "Records:" Then
            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "You have to select a Record", "", "Error", 0)
            Return
        End If
        If CheckBox_Filtro_Personalizado.Checked Then
            Filtro_Personalisado_fc.fca = Convert.ToDouble(ComboBox_fca.Text.Replace(" Hz", " "))
            Filtro_Personalisado_fc.fcb = Convert.ToDouble(ComboBox_fcb.Text.Replace(" Hz", " "))
            If (Filtro_Personalisado_fc.fca - Filtro_Personalisado_fc.fcb) < 1 Then
                'Mesaje de que no se ha seleciondado ningun registro
                Dim Contraseña_Incorrecta As New Form_Mensaje_Error
                Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "Low Cutoff Frequency must be lower than ", "High Cutoff Frequency", "Cutting Frequencies Error", 0)
                Return
            End If
        End If
        If CheckBox_fca_Ninguna.Checked And CheckBox_fcb_Ninguna.Checked And CheckBox_Notch_Ninguna.Checked And CheckBox_Filtro_Personalizado.Checked = False Then
            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "You have to select at least one option ", "in the Filtering Frequencies", "Cutting Frequencies Error", 0)
            Return
        End If


        If CheckedListBox_Registros.CheckedItems.Count <> 0 Then
            If (Button_Filtrar_Registro.Text = "Filter Record") Then
                Button_Filtrar_Registro.Text = "Cancel Filtering"
                'Bloque o los parametros del analisis 
                TabPageEX_Configuracion_Análisis.Enabled = False
                TabPageEX_Análisis_Un_Registro.Enabled = False
                Button_Cargar_Registro.Enabled = False
                'Inicio el analisis
                BackgroundWorker_Filtrar_Registro.RunWorkerAsync()
            Else
                Label_Progreso.Text = "Cancelling Filtering"
                Button_Filtrar_Registro.Text = "Cancelling Filtering"
                Button_Filtrar_Registro.Enabled = False
                BackgroundWorker_Filtrar_Registro.CancelAsync()
            End If
        Else
            'Mesaje de que no se ha seleciondado ningun registro
            Dim Contraseña_Incorrecta As New Form_Mensaje_Error
            Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "No record selected", "", "Error in the Record", 0)
        End If
    End Sub

    Private Sub BackgroundWorker_Filtrar_Registro_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Filtrar_Registro.DoWork
        Dim Coenficientes_Filtro() As Double

        Dim fcb, fca As Double 'fcb: frecuencia de corte baja, fca:frecuencia de corte alta 
        Dim Tipo_Filtro As Double 'fcb: frecuencia de corte baja, fca:frecuencia de corte alta 

        Dim Coneccion_Base_Datos As New SqlConnection
        Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
        Coneccion_Base_Datos.Open()

        If CheckBox_Filtro_Personalizado.Checked Then
            If (CheckBox_Filtro_Pasa_Banda.Checked) Then
                Coenficientes_Filtro = Modulo_Anlisis.Diseño_Filtro_Barlett(2, 500, Registro_Seleccionado.Frecuencia, Filtro_Personalisado_fc.fcb, Filtro_Personalisado_fc.fca)
            Else
                Coenficientes_Filtro = Modulo_Anlisis.Diseño_Filtro_Hamming(3, 500, Registro_Seleccionado.Frecuencia, Filtro_Personalisado_fc.fcb, Filtro_Personalisado_fc.fca)
            End If
        Else
            Tipo_Filtro = 2

            If CheckBox_fcb_005_Hz.Checked Then
                fcb = 0.05
            ElseIf CheckBox_fcb_05_Hz.Checked Then
                fcb = 0.5
            ElseIf CheckBox_fcb_1_Hz.Checked Then
                fcb = 1
            ElseIf CheckBox_fcb_5_Hz.Checked Then
                fcb = 5
            ElseIf CheckBox_fcb_10_Hz.Checked Then
                fcb = 10
            End If

            If CheckBox_fca_50_Hz.Checked Then
                fca = 50
            ElseIf CheckBox_fca_100_Hz.Checked Then
                fca = 100
            ElseIf CheckBox_fca_150_Hz.Checked Then
                fca = 150
            ElseIf CheckBox_fca_200_Hz.Checked Then
                fca = 200
            End If


            If CheckBox_fcb_Ninguna.Checked And CheckBox_fca_Ninguna.Checked And CheckBox_Notch_Ninguna.Checked Then
                Return
            ElseIf CheckBox_fcb_Ninguna.Checked And CheckBox_fca_Ninguna.Checked Then
                Tipo_Filtro = 4
                If CheckBox_Notch_50_Hz.Checked Then
                    fcb = 50
                Else
                    fcb = 60
                End If
            ElseIf CheckBox_fca_Ninguna.Checked Then
                Tipo_Filtro = 1
            ElseIf CheckBox_fcb_Ninguna.Checked Then
                Tipo_Filtro = 0
            End If
            If Tipo_Filtro = 4 Then
                Coenficientes_Filtro = Modulo_Anlisis.Diseño_Filtro_Hamming(4, 500, Registro_Seleccionado.Frecuencia, fcb, fca)
            ElseIf Tipo_Filtro = 0 Then
                Coenficientes_Filtro = Modulo_Anlisis.Diseño_Filtro_Barlett(Tipo_Filtro, 500, Registro_Seleccionado.Frecuencia, fca, fca)
            Else
                Coenficientes_Filtro = Modulo_Anlisis.Diseño_Filtro_Barlett(Tipo_Filtro, 500, Registro_Seleccionado.Frecuencia, fcb, fca)
            End If
        End If


        For Index1 = 0 To CheckedListBox_Registros.CheckedItems.Count - 1
            'Filtrado de la Señal
            Modulo_Anlisis.Filtrado_Registro_500_Polos_Face_Cero_Reset_Coeficientes()
            'If (Modulo_Anlisis.Filtrado_Registro_500_Polos_Face_Cero(Coneccion_Usuarios, Registro_Seleccionado.Tabla, Registro_Seleccionado.Tabla + "___Filtrado", CheckedListBox_Registros.CheckedItems(Index1).ToString(), Coenficientes_Filtro, Configuracion_Deteccion_QRS, BackgroundWorker_Filtrar_Registro) = False) Then
            Dim Tabla_Almacenamiento As String = Registro_Seleccionado.Tabla + "___" + CheckedListBox_Registros.CheckedItems(Index1).ToString() + "___Filtrado_Temp"

            Dim Coneccion_Registro As New SqlConnection
            Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Registro_Seleccionado.Usuario, Registro_Seleccionado.Paciente, Registro_Seleccionado.Fecha_Registro, CheckedListBox_Registros.CheckedItems(Index1).ToString())

            Dim Coneccion_Base_Datos_Filtrado_Temp As New SqlConnection
            Coneccion_Base_Datos_Filtrado_Temp.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Tabla_Almacenamiento)
            Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Filtrado_Temp, Tabla_Almacenamiento)

            If (Modulo_Anlisis.Filtrado_Registro_500_Polos_Face_Cero(Coneccion_Registro, Coneccion_Base_Datos_Filtrado_Temp, Registro_Seleccionado.Tabla, Tabla_Almacenamiento, CheckedListBox_Registros.CheckedItems(Index1).ToString(), Coenficientes_Filtro, Configuracion_Deteccion_QRS, BackgroundWorker_Filtrar_Registro) = False) Then
                e.Cancel = True
                Return
            End If
            If CheckBox_Reescribir_Registro.Checked Then
                Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Base_Datos_Filtrado_Temp, Tabla_Almacenamiento, Registro_Seleccionado.Tabla)
                Class_Funciones_Base_Datos.Registro_Copiar_Registro(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Registro, Registro_Seleccionado.Tabla)
                Try
                    Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Registro)
                    Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Registro)
                    Class_Funciones_Base_Datos.Eliminar_Base_Datos(Tabla_Almacenamiento)
                Catch ex As Exception

                End Try
            Else
                Try
                    Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Base_Datos_Filtrado_Temp)
                    Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Base_Datos_Filtrado_Temp)
                Catch ex As Exception

                End Try
            End If

        Next
        'Tabla_Datos.Dispose()


        'BackgroundWorker_Analisis_Registro.ReportProgress(200000 + 0 * 1000 + 0.5 * 100)
        Coneccion_Base_Datos.Close()

    End Sub

    Private Sub BackgroundWorker_Filtrar_Registro_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker_Filtrar_Registro.ProgressChanged
        Dim Progreso As Int64 = e.ProgressPercentage
        Dim Porcentaje_Progreso As Int64 = Progreso Mod 1000
        Dim Derivacion As Int64 = (Progreso Mod 100000) / 1000
        Dim Procedimiento As Int64 = Math.Floor(Progreso / 100000)
        Dim Texto As String
        Texto = Convert.ToString(Porcentaje_Progreso) + "% " + Modulo_Anlisis.Derivada_To_String(Derivacion) + " "

        Const Procedimiento_Filtrando_Señal = 1
        Const Procedimiento_Trasnformada_Wavelet = 2
        Const Procedimiento_Deteccion_QRS = 3
        Const Procedimiento_Deteccion_Onda_T = 4
        Const Procedimiento_Deteccion_Onda_P = 5

        Select Case Procedimiento
            Case Procedimiento_Filtrando_Señal
                Texto = Texto + "Filtering Derivation"
            Case Procedimiento_Trasnformada_Wavelet
                Texto = Texto + "Calculation Wavelet Transform"
            Case Procedimiento_Deteccion_QRS
                Texto = Texto + "Obtaining points of the QRS complex"
            Case Procedimiento_Deteccion_Onda_T
                Texto = Texto + "Obtaining points of Wave T"
            Case Procedimiento_Deteccion_Onda_P
                Texto = Texto + "Obtaining points of Wave P"
            Case Else
        End Select
        Label_Progreso_Filtro.Text = Texto
        ProgressBar_Filtrar_Registro.Value = Porcentaje_Progreso
    End Sub

    Private Sub BackgroundWorker_Filtrar_Registro_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_Filtrar_Registro.RunWorkerCompleted
        Dim Contraseña_Incorrecta As New Form_Mensaje_Error
        Button_Filtrar_Registro.Enabled = True

        Button_Filtrar_Registro.Text = "Filter Record"
        Label_Progreso_Filtro.Text = ""
        ProgressBar_Filtrar_Registro.Value = 0
        If e.Cancelled = True Then
            Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "Analysis", "Canceled", "Finished", 0)
        Else
            Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "Analysis", "Completed", "Completed", 1)
        End If
        'Desbloquear parametros de analisis
        TabPageEX_Configuracion_Análisis.Enabled = True
        TabPageEX_Análisis_Un_Registro.Enabled = True
        Button_Cargar_Registro.Enabled = True

    End Sub

    Private Sub Button_Independizar_Ventana_Click(sender As Object, e As EventArgs) Handles Button_Independizar_Ventana.Click


        If Bandera_Anclaje = 0 Then
            Dim Modulo_Contenedor As New Form_Contenedor
            Modulo_Contenedor.Controls.Add(Me)


            'Me.Anchor = AnchorStyles.Left And AnchorStyles.Right And AnchorStyles.Top And AnchorStyles.Bottom
            Me.Anchor = AnchorStyles.Left And AnchorStyles.Right
            Me.Dock = DockStyle.Fill
            Me.Location = New Point(0, 0)
            ' Modulo_Contenedor.MinimumSize = Me.Size

            Modulo_Contenedor.Show()
            Modulo_Contenedor.Modulo_Anlisis = Me
            Form_Contenedor.BringToFront()

            Button_Cerrar.Visible = False

            Bandera_Anclaje = 1
        Else
            Dim Modulo_Contenedor As Form_Contenedor = Me.FindForm
            Form_Principal.BringToFront()
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
    Private Sub Button_Cerrar_MouseLeave_1(sender As Object, e As EventArgs) Handles Button_Cerrar.MouseLeave
        Button_Cerrar.BackgroundImage = Nothing
    End Sub

    Private Sub Button_Cerrar_MouseEnter_1(sender As Object, e As EventArgs) Handles Button_Cerrar.MouseEnter
        Button_Cerrar.BackgroundImage = My.Resources.Cambio_Boton
    End Sub

    'Private Sub CheckedListBox_Registros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox_Registros.SelectedIndexChanged
    '    If (CheckedListBox_Registros.CheckedItems.Count > 1) Then
    '        CheckBox_Almacenar_Resultados.Checked = True
    '        CheckBox_Almacenar_Resultados.Enabled = False
    '    Else
    '        CheckBox_Almacenar_Resultados.Checked = True
    '        CheckBox_Almacenar_Resultados.Enabled = True

    '    End If
    'End Sub


    'Private Sub CheckBox_Almacenar_Resultados_CheckedChanged(sender As Object, e As EventArgs)
    '    If (CheckedListBox_Registros.CheckedItems.Count < 2 And CheckBox_Almacenar_Resultados.Checked = False) Then
    '        CheckBox_Recalcular_Resultados.Checked = True
    '        CheckBox_Recalcular_Resultados.Enabled = False
    '    Else
    '        CheckBox_Recalcular_Resultados.Checked = False
    '        CheckBox_Recalcular_Resultados.Enabled = True
    '    End If
    'End Sub

    Private Sub UserControl_Modulo_Analicis_Señal_ControlRemoved(sender As Object, e As ControlEventArgs) Handles MyBase.ControlRemoved
        Form_Principal.Estado_Registros.Desbloquear_Registro(Registro_Seleccionado.Tabla)
        For j = Registro_Seleccionado_Multi_Registros.Count - 1 To 0 Step -1
            Form_Principal.Estado_Registros.Desbloquear_Registro(Registro_Seleccionado_Multi_Registros.Item(j).Tabla.ToString())
        Next j
    End Sub

    Private Sub ComboBox_Selec_TW_QRS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Selec_TW_QRS.SelectedIndexChanged
        Select Case ComboBox_Selec_TW_QRS.Text
            Case "TW 1"
                Configuracion_Deteccion_QRS.Escala_TW_QRS = 1
            Case "TW 2"
                Configuracion_Deteccion_QRS.Escala_TW_QRS = 2
            Case "TW 3"
                Configuracion_Deteccion_QRS.Escala_TW_QRS = 3
            Case "TW 4"
                Configuracion_Deteccion_QRS.Escala_TW_QRS = 4
            Case "TW 5"
                Configuracion_Deteccion_QRS.Escala_TW_QRS = 5
            Case "TW 6"
                Configuracion_Deteccion_QRS.Escala_TW_QRS = 6
            Case "TW 7"
                Configuracion_Deteccion_QRS.Escala_TW_QRS = 7
            Case "TW 8"
                Configuracion_Deteccion_QRS.Escala_TW_QRS = 8
            Case "TW 9"
                Configuracion_Deteccion_QRS.Escala_TW_QRS = 9
            Case "TW 10"
                Configuracion_Deteccion_QRS.Escala_TW_QRS = 10
            Case Else
                Configuracion_Deteccion_QRS.Escala_TW_QRS = 1
                ComboBox_Selec_TW_QRS.Text = "TW 1"
        End Select
    End Sub



    Private Sub TabControlEX1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlEX1.SelectedIndexChanged
        If TabControlEX1.SelectedTab.Text = "Filter Signal" Then
            CheckBox_Analisis_Multi_Registro.Checked = False
            CheckBox_Analisis_Multi_Registro.Visible = False
        Else
            CheckBox_Analisis_Multi_Registro.Visible = True
        End If
    End Sub

    Private Sub Button_Eliminar_Registro_Multi_Registro_Click(sender As Object, e As EventArgs) Handles Button_Eliminar_Registro_Multi_Registro.Click
        Dim Registro_Tabla As String

        For i = CheckedListBox_Registros_Analizar_Multi_Registro.Items.Count - 1 To 0 Step -1
            If CheckedListBox_Registros_Analizar_Multi_Registro.GetItemChecked(i) Then
                Registro_Tabla = CheckedListBox_Registros_Analizar_Multi_Registro.Items(i).ToString()
                For j = Registro_Seleccionado_Multi_Registros.Count - 1 To 0 Step -1
                    If Registro_Tabla = Registro_Seleccionado_Multi_Registros.Item(j).Tabla Then
                        Form_Principal.Estado_Registros.Desbloquear_Registro(Registro_Tabla)
                        Registro_Seleccionado_Multi_Registros.RemoveAt(j)
                    End If
                Next j
                CheckedListBox_Registros_Analizar_Multi_Registro.Items.RemoveAt(i)
            End If
        Next i
    End Sub

    Private Sub CheckBox_Selecionar_Todos_Registros_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Selecionar_Todos_Registros.CheckedChanged
        If CheckBox_Selecionar_Todos_Registros.Checked Then
            For i = 0 To CheckedListBox_Registros.Items.Count - 1
                CheckedListBox_Registros.SetItemChecked(i, True)
            Next
            CheckBox_Selecionar_Todos_Registros.Text = "Deselect all records"
        Else
            For i = 0 To CheckedListBox_Registros.Items.Count - 1
                CheckedListBox_Registros.SetItemChecked(i, False)
            Next
            CheckBox_Selecionar_Todos_Registros.Text = "Select All Records"
        End If
    End Sub



    Private Sub BackgroundWorker_Analisis_Multi_Registro_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Analisis_Multi_Registro.DoWork
        'Tablas Empleadas en el anailizis
        Dim Coneccion_Base_Datos_Filtrado_Temp As New SqlConnection
        Dim Coneccion_Base_Datos_Transformada_Wavelet_QRS As New SqlConnection
        Dim Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp As New SqlConnection
        Dim Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp As New SqlConnection
        Dim Coneccion_Registro_Analizar As New SqlConnection

        Dim Registro_Analizar As String = "Temp"
        Dim Tabla_Transformada_Wavelet_QRS As String = "Temp"
        Dim Tabla_Transformada_Wavelet_Onda_PT_Busqueda As String = "Temp"
        Dim Tabla_Transformada_Wavelet_Onda_PT_Correcion As String = "Temp"

        'Tablas Empleadas en el anailizis
        Dim Tabla_QRS As String
        Dim Tabla_Onda_T As String
        Dim Tabla_Onda_P As String
        Dim Tabla_Intervalo_R_R As String
        Dim Tabla_Intervalo_Q_T As String
        Dim Tabla_Intervalo_P_R As String
        'Funciones para determinar los parametros que son necesarios calcular si Se activa la funcion Recalcular
        'Dim Recalcular_Deteccion_Complejo_QRS As Boolean = CheckBox_Calcular_QRS.Checked Or CheckBox_Calcular_T.Checked Or CheckBox_Calcular_P.Checked
        'Dim Recalcular_Deteccion_Onda_T As Boolean = CheckBox_Calcular_T.Checked
        'Dim Recalcular_Deteccion_Onda_P As Boolean = CheckBox_Calcular_P.Checked
        'Dim Recalcular_Busqueda_Complejos_QRS_NO_Detectados As Boolean = Recalcular_Deteccion_Complejo_QRS And CheckBox_Deteccion_Complejo_QRS_Faltantes.Checked

        'Funciones para determinar los parametros que son necesarios calcular si, no Se activa la funcion Recalcular
        Dim Deteccion_Complejo_QRS As Boolean = False
        Dim Deteccion_Onda_T As Boolean = False
        Dim Deteccion_Onda_P As Boolean = False
        Dim Deteccion_Intervalo_R_R As Boolean = False
        Dim Deteccion_Intervalo_Q_T As Boolean = False
        Dim Deteccion_Intervalo_P_R As Boolean = False

        Dim Deteccion_Complejo_QRS_temp As Boolean = False
        Dim Deteccion_Onda_T_temp As Boolean = False
        Dim Deteccion_Onda_P_temp As Boolean = False
        Dim Deteccion_Intervalo_R_R_temp As Boolean = False
        Dim Deteccion_Intervalo_Q_T_temp As Boolean = False
        Dim Deteccion_Intervalo_P_R_temp As Boolean = False

        Dim Recalcular_Elementos As Boolean = CheckBox_Recalcular_Resultados.Checked
        Dim Filtrar_Señal As Boolean = False
        Dim Busqueda_Complejos_QRS_NO_Detectados As Boolean = False
        Dim Correccion_Puntos_Complejo_QRS As Boolean = False




        Dim m() As Double = {0.3749, 0.1934, 0.1297, 0.0975, 0.078, 0.065, 0.0558, 0.0488, 0.0434, 0.039}
        Dim Escala_Trasnformada_Wavelet_QRS As Int16 = 2
        Dim Escala_Trasnformada_Wavelet_Onda_PT_Busqueda As Int16 = 2
        Dim Escala_Trasnformada_Wavelet_Onda_PT_Correcion As Int16 = 2
        Dim Bandera_Nueva_Derivacion As Int16 = 0 'Especifica cuando es una derivacion nueva
        'Dim Tabla_Trasnformada_Wavelet As String = "Tabla_Transformada_Wavelet_QRS" 'Especifica cuando es una derivacion nueva
        Dim Usuario As String
        Dim Paciente As String
        Dim Fecha_Registro As String
        Dim Tabla As String
        Dim Max_Puntero As Int32
        Dim Frecuencia As Double

        Dim Coneccion_Base_Datos As New SqlConnection
        Coneccion_Base_Datos.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString()
        Coneccion_Base_Datos.Open()
        For Index_Multi_Registro = 0 To Registro_Seleccionado_Multi_Registros.Count - 1
            Usuario = Registro_Seleccionado_Multi_Registros.Item(Index_Multi_Registro).Usuario
            Paciente = Registro_Seleccionado_Multi_Registros.Item(Index_Multi_Registro).Paciente
            Fecha_Registro = Registro_Seleccionado_Multi_Registros.Item(Index_Multi_Registro).Fecha_Registro
            Tabla = Registro_Seleccionado_Multi_Registros.Item(Index_Multi_Registro).Tabla
            Max_Puntero = Registro_Seleccionado_Multi_Registros.Item(Index_Multi_Registro).Max_Puntero
            Frecuencia = Registro_Seleccionado_Multi_Registros.Item(Index_Multi_Registro).Frecuencia
            Registro_En_Analisis_Multi_Registros = Index_Multi_Registro

            'Determinar las columnas existentes del registro a analizar
            Dim Columnas_Existentes As List(Of String) = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Derivaciones_Registro(Coneccion_Base_Datos, Usuario, Paciente, Fecha_Registro)

            For Index1 = 0 To Columnas_Existentes.Count - 1
                Dim Coneccion_Registro As New SqlConnection
                Coneccion_Registro.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Usuario, Paciente, Fecha_Registro, Columnas_Existentes(Index1))
                Coneccion_Registro.Open()
                'Identificar que Ondas, Segmentos y Intervalos tengo que Calcular para obtner los resultados deseados
                For Index_TreeView_0 = 0 To TreeView_Elementos_Calcular.Nodes.Count - 1
                    For Index_TreeView_1 = 0 To TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes.Count - 1
                        'Onda P
                        If TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "P" And TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked Then
                            Deteccion_Onda_P = True
                            Deteccion_Complejo_QRS_temp = True
                        End If
                        'Complejo QRS
                        If TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "QRS" And TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked Then
                            Deteccion_Complejo_QRS = True

                        End If
                        'Onda T
                        If TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "T" And TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked Then
                            Deteccion_Onda_T = True
                            Deteccion_Complejo_QRS_temp = True
                        End If
                        'Intervalo R-R
                        If TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "R-R" And TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked Then
                            Deteccion_Intervalo_R_R = True
                            'Validar si ya se calculo la ubicacion de los Complejos QRS
                            If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Complejo_QRS") Then
                                Deteccion_Complejo_QRS_temp = True
                            End If
                        End If
                        'Intervalo Q-T
                        If TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "Q-T" And TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked Then
                            Deteccion_Intervalo_Q_T = True
                            'Validar si ya se calculo la ubicacion de los Complejos QRS
                            If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Complejo_QRS") Then
                                Deteccion_Complejo_QRS_temp = True
                            End If
                            'Validar si ya se calculo la ubicacion de la Onda T
                            If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_T") Then
                                Deteccion_Onda_T_temp = True
                            End If

                        End If
                        'Intervalo P-R
                        If TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Text = "P-R" And TreeView_Elementos_Calcular.Nodes(Index_TreeView_0).Nodes(Index_TreeView_1).Checked Then
                            Deteccion_Intervalo_P_R = True
                            'Validar si ya se calculo la ubicacion de los Complejos QRS
                            If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Complejo_QRS") Then
                                Deteccion_Complejo_QRS_temp = True
                            End If
                            'Validar si ya se calculo la ubicacion de la Onda T
                            If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_P") Then
                                Deteccion_Onda_P_temp = True
                            End If
                        End If
                    Next

                Next
                'Determinar si tengo que relizar Busqueda_Complejos_QRS_NO_Detectados
                'Valido si necesito obtener el Complejo QRS y si Esta activo la Busqueda_Complejos_QRS_NO_Detectados    
                If Deteccion_Complejo_QRS And CheckBox_Deteccion_Complejo_QRS_Faltantes.Checked Then
                    Busqueda_Complejos_QRS_NO_Detectados = True
                End If

                'Determinar si tengo que relizar Correccion_Puntos_Complejo_QRS
                'Valido si necesito obtener el Complejo QRS y si Esta activo la Correccion_Puntos_Complejo_QRS    
                If Deteccion_Complejo_QRS And CheckBox_Corregir_Puntos_Complejo_QRS.CheckState Then
                    Correccion_Puntos_Complejo_QRS = True
                End If
                'Determinar si tengo que relizar Filtrar_Señal
                'Valido Si esta activo el Filtrar_Señal
                'Valido si tengo que recalcular  alguna de los Deteccion_Onda_P Or Deteccion_Complejo_QRS Or Deteccion_Onda_T
                'Valido si no se ha calculado alguna de los Deteccion_Onda_P Or Deteccion_Complejo_QRS Or Deteccion_Onda_T y es ncesario hacerlo 
                If CheckBox_Filtrar_Señal.Checked Then
                    If (Recalcular_Elementos And (Deteccion_Onda_P Or Deteccion_Complejo_QRS Or Deteccion_Onda_T)) Or (Recalcular_Elementos = False And ((Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_P") <> 1 And Deteccion_Onda_P = True) Or (Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Complejo_QRS") <> 1 And Deteccion_Complejo_QRS = True) Or (Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_T") <> 1 And Deteccion_Onda_T = True))) Then
                        Filtrar_Señal = True
                    End If
                End If
                If Recalcular_Elementos Then
                    'Filtrado de la Señal
                    If Filtrar_Señal Then
                        Dim Coenficientes_Filtro(500) As Double
                        Coenficientes_Filtro = Modulo_Anlisis.Diseño_Filtro_Barlett(2, 501, Frecuencia, Configuracion_Deteccion_QRS.Frecuencia_Baja_Filtro, Configuracion_Deteccion_QRS.Frecuencia_Alta_Filtro)
                        Modulo_Anlisis.Filtrado_Registro_500_Polos_Face_Cero_Reset_Coeficientes()
                        'Creo la base de datos de la señal filtrada
                        Registro_Analizar = Tabla + "___" + Columnas_Existentes.Item(Index1).ToString() + "___Filtrado_Temp"
                        If Coneccion_Base_Datos_Filtrado_Temp.State <> 0 Then
                            Coneccion_Base_Datos_Filtrado_Temp.Close()
                        End If
                        Coneccion_Base_Datos_Filtrado_Temp.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Registro_Analizar)
                        Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Filtrado_Temp, Registro_Analizar)

                        If (Modulo_Anlisis.Filtrado_Registro_500_Polos_Face_Cero(Coneccion_Registro, Coneccion_Base_Datos_Filtrado_Temp, Tabla, Registro_Analizar, Columnas_Existentes.Item(Index1).ToString(), Coenficientes_Filtro, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False) Then
                            e.Cancel = True
                            Return
                        End If

                    Else
                        If Coneccion_Base_Datos_Filtrado_Temp.State <> 0 Then
                            Coneccion_Base_Datos_Filtrado_Temp.Close()
                        End If
                        Coneccion_Base_Datos_Filtrado_Temp.ConnectionString = Coneccion_Registro.ConnectionString
                        Registro_Analizar = Tabla
                    End If
                    'Deteccion del Complejo QRS
                    'Se calcula el Complejo QRS si se solicita la recalculacion o si no se a calculado previamente y es necesario

                    If Deteccion_Complejo_QRS Or (Deteccion_Complejo_QRS_temp And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Complejo_QRS") <> 1) Then
                        'Calculo de la Transformada Wavelet
                        Tabla_Transformada_Wavelet_QRS = Tabla + "___" + Columnas_Existentes.Item(Index1).ToString() + "___Transformada_Wavelet_Complejo_QRS_Temp"
                        If Coneccion_Base_Datos_Transformada_Wavelet_QRS.State <> 0 Then
                            Coneccion_Base_Datos_Transformada_Wavelet_QRS.Close()
                        End If
                        Coneccion_Base_Datos_Transformada_Wavelet_QRS.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Tabla_Transformada_Wavelet_QRS)
                        Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Tabla_Transformada_Wavelet_QRS)
                        'Determinar la escala de la TW
                        If CheckBox_Selec_Auto_TW_QRS.Checked = True Then
                            Escala_Trasnformada_Wavelet_QRS = 1
                            While Frecuencia * m(Escala_Trasnformada_Wavelet_QRS - 1) > 50 And Escala_Trasnformada_Wavelet_QRS < 10
                                Escala_Trasnformada_Wavelet_QRS = Escala_Trasnformada_Wavelet_QRS + 1
                            End While
                        Else
                            Escala_Trasnformada_Wavelet_QRS = Configuracion_Deteccion_QRS.Escala_TW_QRS
                        End If
                        Modulo_Anlisis.Transformada_Wavelet_Reset_Escala(Escala_Trasnformada_Wavelet_QRS)

                        Select Case Escala_Trasnformada_Wavelet_QRS
                            Case 1
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_1(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 2
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_2(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 3
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_3(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 4
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_4(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 5
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_5(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 6
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_6(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 7
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_7(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 8
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_8(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 9
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_9(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case Else
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_10(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If
                        End Select

                        Tabla_QRS = Tabla + "___Tabla_QRS_Temp"
                        If Modulo_Anlisis.Deteccion_QRS_Con_Deteccion_Puntos(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Coneccion_Registro, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Tabla_QRS, Columnas_Existentes.Item(Index1).ToString(), Frecuencia, Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Tabla_Transformada_Wavelet_QRS), Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                            e.Cancel = True
                            Return
                        End If

                        'Correcion de los puntos  del Complejo QRS 
                        If Correccion_Puntos_Complejo_QRS Then
                            If Modulo_Anlisis.Correccion_Puntos_QRS_En_Señal(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Registro, Registro_Analizar, Tabla_QRS, Tabla_QRS + "_1", Columnas_Existentes.Item(Index1).ToString(), Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                e.Cancel = True
                                Return
                            Else
                                Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_QRS)
                                Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS + "_1", Tabla_QRS)
                            End If
                        End If
                        'Busqueda del Complejo QRS Faltantes
                        If Busqueda_Complejos_QRS_NO_Detectados Then
                            If Modulo_Anlisis.Busqueda_Complejos_QRS_NO_Detectados_En_Transformada_Wavelet(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Coneccion_Registro, Tabla_Transformada_Wavelet_QRS, Tabla_QRS, Tabla_QRS + "_1", Columnas_Existentes.Item(Index1).ToString(), Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                e.Cancel = True
                                Return
                            Else
                                Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_QRS)
                                Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS + "_1", Tabla_QRS)
                            End If
                        End If
                        'Correcion de los puntos  del Complejo QRS 
                        If Correccion_Puntos_Complejo_QRS Then
                            If Modulo_Anlisis.Correccion_Puntos_QRS_En_Señal(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Registro, Registro_Analizar, Tabla_QRS, Tabla_QRS + "_1", Columnas_Existentes.Item(Index1).ToString(), Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                e.Cancel = True
                                Return
                            Else
                                Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_QRS)
                                Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS + "_1", Tabla_QRS)
                            End If
                        End If
                    Else
                        Tabla_QRS = Tabla + "___Complejo_QRS"
                    End If

                    'Determinar si es necesario calcular la nueva trasnfrmada waveet 
                    If Deteccion_Onda_P Or Deteccion_Onda_T Or (Deteccion_Onda_P_temp And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_P") <> 1) Or (Deteccion_Onda_T_temp And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_T") <> 1) Then
                        If Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp.State <> 0 Then
                            Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp.Close()
                        End If
                        If Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp.State <> 0 Then
                            Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp.Close()
                        End If
                        'Crear base de datos temporal par ala Transformada Wavelet de busqueda
                        Tabla_Transformada_Wavelet_Onda_PT_Busqueda = Tabla + "___" + Columnas_Existentes.Item(Index1).ToString() + "___Transformada_Wavelet_Onda_PT_Busqueda_Temp"
                        Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Tabla_Transformada_Wavelet_Onda_PT_Busqueda)
                        Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Tabla_Transformada_Wavelet_Onda_PT_Busqueda)

                        'Crear base de datos temporal par ala Transformada Wavelet de correcion
                        Tabla_Transformada_Wavelet_Onda_PT_Correcion = Tabla + "___" + Columnas_Existentes.Item(Index1).ToString() + "___Transformada_Wavelet_Onda_PT_Correcion_Temp"
                        Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Tabla_Transformada_Wavelet_Onda_PT_Correcion)
                        Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Tabla_Transformada_Wavelet_Onda_PT_Correcion)

                        'Determinando la escala de la transformadad wavelet DWE BUsqueda y Correcion 
                        Escala_Trasnformada_Wavelet_Onda_PT_Busqueda = 1
                        If CheckBox_Selec_Auto_TW_Onda_PT_Busqueda.CheckState Then
                            While Frecuencia * m(Escala_Trasnformada_Wavelet_Onda_PT_Busqueda - 1) > 35 And Escala_Trasnformada_Wavelet_Onda_PT_Busqueda < 10
                                Escala_Trasnformada_Wavelet_Onda_PT_Busqueda = Escala_Trasnformada_Wavelet_Onda_PT_Busqueda + 1
                            End While
                        Else
                            Escala_Trasnformada_Wavelet_Onda_PT_Busqueda = Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda
                        End If

                        If CheckBox_Selec_Auto_TW_Onda_PT_Correcion.CheckState Then
                            Escala_Trasnformada_Wavelet_Onda_PT_Correcion = 1
                        Else
                            Escala_Trasnformada_Wavelet_Onda_PT_Correcion = Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion
                        End If

                        'Calculo De la Transformada Wavelet con escala de Busqueda 

                        'Calculo De la Transformada Wavelet con escala de Busqueda 
                        Modulo_Anlisis.Transformada_Wavelet_Reset_Escala(Escala_Trasnformada_Wavelet_Onda_PT_Busqueda)
                        Select Case Escala_Trasnformada_Wavelet_Onda_PT_Busqueda
                            Case 1
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_1(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 2
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_2(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 3
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_3(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 4
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_4(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 5
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_5(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 6
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_6(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 7
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_7(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 8
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_8(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 9
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_9(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case Else
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_10(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If
                        End Select

                        'Calculo De la Transformada Wavelet con escala de Correcion 
                        Modulo_Anlisis.Transformada_Wavelet_Reset_Escala(Escala_Trasnformada_Wavelet_Onda_PT_Correcion)
                        Select Case Escala_Trasnformada_Wavelet_Onda_PT_Correcion
                            Case 1
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_1(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 2
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_2(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 3
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_3(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 4
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_4(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 5
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_5(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 6
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_6(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 7
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_7(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 8
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_8(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 9
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_9(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case Else
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_10(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If
                        End Select
                    End If

                    'Deteccion de la Onda T
                    'Se calcula el Onda T si se solicita la recalculacion o si no se a calculado previamente y es necesario
                    If Deteccion_Onda_T Or (Deteccion_Onda_T_temp And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_T") <> 1) Then
                        Tabla_Onda_T = Tabla + "___Tabla_Onda_T_Temp"
                        If Modulo_Anlisis.Deteccion_Onda_T_Clasificacion_Con_Correccion(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Coneccion_Registro, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Tabla_QRS, Tabla_Onda_T, Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                            e.Cancel = True
                            Return
                        End If
                    Else
                        Tabla_Onda_T = Tabla + "___Onda_T"
                    End If

                    'Deteccion de la Onda P
                    'Se calcula el Onda P si se solicita la recalculacion o si no se a calculado previamente y es necesario
                    If Deteccion_Onda_P Or (Deteccion_Onda_P_temp And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_P") <> 1) Then
                        Tabla_Onda_P = Tabla + "___Tabla_Onda_P_Temp"
                        If Modulo_Anlisis.Deteccion_Onda_P_Clasificacion_Con_Correccion(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Coneccion_Registro, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Tabla_QRS, Tabla_Onda_P, Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                            e.Cancel = True
                            Return
                        End If
                    Else
                        Tabla_Onda_P = Tabla + "___Onda_P"
                    End If


                    'Calculo Intervalo R-R
                    If Deteccion_Intervalo_R_R Then
                        Tabla_Intervalo_R_R = Tabla + "___Tabla_Intervalo_R_R_Temp"
                        If Modulo_Anlisis.Calculo_Intervalo_En_Una_Tabla(Coneccion_Registro, Tabla_QRS, "R", Tabla_Intervalo_R_R, Columnas_Existentes.Item(Index1).ToString(), Frecuencia, BackgroundWorker_Analisis_Multi_Registro) = False Then
                            e.Cancel = True
                            Return
                        End If
                    End If
                    'Calculo Intervalo Q-T
                    If Deteccion_Intervalo_Q_T Then
                        Tabla_Intervalo_Q_T = Tabla + "___Tabla_Intervalo_Q_T_Temp"
                        If Modulo_Anlisis.Calculo_Intervalo_En_Dos_Tabla(Coneccion_Registro, Tabla_QRS, "Q", Tabla_Onda_T, "T", Tabla_Intervalo_Q_T, Columnas_Existentes.Item(Index1).ToString(), Frecuencia, BackgroundWorker_Analisis_Multi_Registro) = False Then
                            e.Cancel = True
                            Return
                        End If
                    End If
                    'Calculo Intervalo P-R
                    If Deteccion_Intervalo_P_R Then
                        Tabla_Intervalo_P_R = Tabla + "___Tabla_Intervalo_P_R_Temp"
                        If Modulo_Anlisis.Calculo_Intervalo_En_Dos_Tabla(Coneccion_Registro, Tabla_Onda_P, "P", Tabla_QRS, "R", Tabla_Intervalo_P_R, Columnas_Existentes.Item(Index1).ToString(), Frecuencia, BackgroundWorker_Analisis_Multi_Registro) = False Then
                            e.Cancel = True
                            Return
                        End If
                    End If

                Else
                    'Filtrado de la Señal
                    If Filtrar_Señal Then
                        Dim Coenficientes_Filtro(500) As Double
                        Coenficientes_Filtro = Modulo_Anlisis.Diseño_Filtro_Barlett(2, 500, Frecuencia, Configuracion_Deteccion_QRS.Frecuencia_Baja_Filtro, Configuracion_Deteccion_QRS.Frecuencia_Alta_Filtro)
                        Modulo_Anlisis.Filtrado_Registro_500_Polos_Face_Cero_Reset_Coeficientes()
                        'Creo la base de datos de la señal filtrada
                        Registro_Analizar = Tabla + "___" + Columnas_Existentes.Item(Index1).ToString() + "___Filtrado_Temp"
                        If Coneccion_Base_Datos_Filtrado_Temp.State <> 0 Then
                            Coneccion_Base_Datos_Filtrado_Temp.Close()
                        End If
                        Coneccion_Base_Datos_Filtrado_Temp.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Registro_Analizar)
                        Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Filtrado_Temp, Registro_Analizar)

                        If (Modulo_Anlisis.Filtrado_Registro_500_Polos_Face_Cero(Coneccion_Registro, Coneccion_Base_Datos_Filtrado_Temp, Tabla, Registro_Analizar, Columnas_Existentes.Item(Index1).ToString(), Coenficientes_Filtro, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False) Then
                            e.Cancel = True
                            Return
                        End If
                    Else
                        If Coneccion_Base_Datos_Filtrado_Temp.State <> 0 Then
                            Coneccion_Base_Datos_Filtrado_Temp.Close()
                        End If
                        Coneccion_Base_Datos_Filtrado_Temp.ConnectionString = Coneccion_Registro.ConnectionString
                        Registro_Analizar = Tabla
                    End If

                    'Deteccion del Complejo QRS
                    If Deteccion_Complejo_QRS Or Deteccion_Complejo_QRS_temp Then
                        If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Complejo_QRS") = 1 Then
                            Tabla_QRS = Tabla + "___Complejo_QRS"
                        Else
                            'Calculo de la Transformada Wavelet
                            Tabla_Transformada_Wavelet_QRS = Tabla + "___" + Columnas_Existentes.Item(Index1).ToString() + "___Transformada_Wavelet_Complejo_QRS_Temp"
                            If Coneccion_Base_Datos_Transformada_Wavelet_QRS.State <> 0 Then
                                Coneccion_Base_Datos_Transformada_Wavelet_QRS.Close()
                            End If
                            Coneccion_Base_Datos_Transformada_Wavelet_QRS.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Tabla_Transformada_Wavelet_QRS)
                            Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Tabla_Transformada_Wavelet_QRS)
                            'Determinar la escala de la TW
                            If CheckBox_Selec_Auto_TW_QRS.Checked = True Then
                                Escala_Trasnformada_Wavelet_QRS = 1
                                While Frecuencia * m(Escala_Trasnformada_Wavelet_QRS - 1) > 50 And Escala_Trasnformada_Wavelet_QRS < 10
                                    Escala_Trasnformada_Wavelet_QRS = Escala_Trasnformada_Wavelet_QRS + 1
                                End While
                            Else
                                Escala_Trasnformada_Wavelet_QRS = Configuracion_Deteccion_QRS.Escala_TW_QRS
                            End If
                            Modulo_Anlisis.Transformada_Wavelet_Reset_Escala(Escala_Trasnformada_Wavelet_QRS)

                            Select Case Configuracion_Deteccion_QRS.Escala_TW_QRS
                                Case 1
                                    If Modulo_Anlisis.Transformada_Wavelet_Escala_1(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                        e.Cancel = True
                                        Return
                                    End If

                                Case 2
                                    If Modulo_Anlisis.Transformada_Wavelet_Escala_2(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                        e.Cancel = True
                                        Return
                                    End If

                                Case 3
                                    If Modulo_Anlisis.Transformada_Wavelet_Escala_3(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                        e.Cancel = True
                                        Return
                                    End If

                                Case 4
                                    If Modulo_Anlisis.Transformada_Wavelet_Escala_4(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                        e.Cancel = True
                                        Return
                                    End If

                                Case 5
                                    If Modulo_Anlisis.Transformada_Wavelet_Escala_5(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                        e.Cancel = True
                                        Return
                                    End If

                                Case 6
                                    If Modulo_Anlisis.Transformada_Wavelet_Escala_6(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                        e.Cancel = True
                                        Return
                                    End If

                                Case 7
                                    If Modulo_Anlisis.Transformada_Wavelet_Escala_7(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                        e.Cancel = True
                                        Return
                                    End If

                                Case 8
                                    If Modulo_Anlisis.Transformada_Wavelet_Escala_8(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                        e.Cancel = True
                                        Return
                                    End If

                                Case 9
                                    If Modulo_Anlisis.Transformada_Wavelet_Escala_9(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                        e.Cancel = True
                                        Return
                                    End If

                                Case Else
                                    If Modulo_Anlisis.Transformada_Wavelet_Escala_10(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_QRS, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                        e.Cancel = True
                                        Return
                                    End If
                            End Select

                            'Deteccion del Complejo QRS
                            Tabla_QRS = Tabla + "___" + Columnas_Existentes.Item(Index1).ToString() + "___Tabla_QRS_Temp"
                            If Modulo_Anlisis.Deteccion_QRS_Con_Deteccion_Puntos(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Coneccion_Registro, Registro_Analizar, Tabla_Transformada_Wavelet_QRS, Tabla_QRS, Columnas_Existentes.Item(Index1).ToString(), Frecuencia, Class_Funciones_Base_Datos.Registro_Maximo_Valor_Puntero(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Tabla_Transformada_Wavelet_QRS), Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                            'Correcion de los puntos  del Complejo QRS 
                            If Correccion_Puntos_Complejo_QRS Then
                                If Modulo_Anlisis.Correccion_Puntos_QRS_En_Señal(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Registro, Registro_Analizar, Tabla_QRS, Tabla_QRS + "_1", Columnas_Existentes.Item(Index1).ToString(), Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                Else
                                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_QRS)
                                    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS + "_1", Tabla_QRS)

                                End If
                            End If

                            'Busqueda del Complejo QRS Faltantes
                            If Busqueda_Complejos_QRS_NO_Detectados Then
                                If Modulo_Anlisis.Busqueda_Complejos_QRS_NO_Detectados_En_Transformada_Wavelet(Coneccion_Base_Datos_Transformada_Wavelet_QRS, Coneccion_Registro, Tabla_Transformada_Wavelet_QRS, Tabla_QRS, Tabla_QRS + "_1", Columnas_Existentes.Item(Index1).ToString(), Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                Else
                                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_QRS)
                                    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS + "_1", Tabla_QRS)

                                End If
                            End If
                            'Correcion de los puntos  del Complejo QRS 
                            If Correccion_Puntos_Complejo_QRS Then
                                If Modulo_Anlisis.Correccion_Puntos_QRS_En_Señal(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Registro, Registro_Analizar, Tabla_QRS, Tabla_QRS + "_1", Columnas_Existentes.Item(Index1).ToString(), Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                Else
                                    Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_QRS)
                                    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS + "_1", Tabla_QRS)

                                End If
                            End If

                        End If
                    End If

                    'Determinar si es necesario obtner la TW para la obtencio de las Ondas T o P
                    If (Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_P") <> 1 And (Deteccion_Onda_P = True Or Deteccion_Onda_P_temp = True)) Or (Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_T") <> 1 And (Deteccion_Onda_T = True Or Deteccion_Onda_T_temp = True)) Then
                        If Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp.State <> 0 Then
                            Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp.Close()
                        End If
                        If Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp.State <> 0 Then
                            Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp.Close()
                        End If
                        'Crear base de datos temporal par ala Transformada Wavelet de busqueda
                        Tabla_Transformada_Wavelet_Onda_PT_Busqueda = Tabla + "___" + Columnas_Existentes.Item(Index1).ToString() + "___Transformada_Wavelet_Onda_PT_Busqueda_Temp"
                        Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Tabla_Transformada_Wavelet_Onda_PT_Busqueda)
                        Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Tabla_Transformada_Wavelet_Onda_PT_Busqueda)

                        'Crear base de datos temporal par ala Transformada Wavelet de correcion
                        Tabla_Transformada_Wavelet_Onda_PT_Correcion = Tabla + "___" + Columnas_Existentes.Item(Index1).ToString() + "___Transformada_Wavelet_Onda_PT_Correcion_Temp"
                        Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp.ConnectionString = Class_Funciones_Base_Datos.Coneccion_Base_Datos_ConnectionString(Tabla_Transformada_Wavelet_Onda_PT_Correcion)
                        Class_Funciones_Base_Datos.Crear_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Tabla_Transformada_Wavelet_Onda_PT_Correcion)

                        'Determinando la escala de la transformadad wavelet DWE BUsqueda y Correcion 
                        Escala_Trasnformada_Wavelet_Onda_PT_Busqueda = 1
                        If CheckBox_Selec_Auto_TW_Onda_PT_Busqueda.CheckState Then
                            While Registro_Seleccionado.Frecuencia * m(Escala_Trasnformada_Wavelet_Onda_PT_Busqueda - 1) > 35 And Escala_Trasnformada_Wavelet_Onda_PT_Busqueda < 10
                                Escala_Trasnformada_Wavelet_Onda_PT_Busqueda = Escala_Trasnformada_Wavelet_Onda_PT_Busqueda + 1
                            End While
                        Else
                            Escala_Trasnformada_Wavelet_Onda_PT_Busqueda = Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda
                        End If

                        If CheckBox_Selec_Auto_TW_Onda_PT_Correcion.CheckState Then
                            Escala_Trasnformada_Wavelet_Onda_PT_Correcion = 1
                        Else
                            Escala_Trasnformada_Wavelet_Onda_PT_Correcion = Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion
                        End If

                        'Calculo De la Transformada Wavelet con escala de Busqueda 
                        Modulo_Anlisis.Transformada_Wavelet_Reset_Escala(Escala_Trasnformada_Wavelet_Onda_PT_Busqueda)
                        Select Case Escala_Trasnformada_Wavelet_Onda_PT_Busqueda
                            Case 1
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_1(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 2
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_2(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 3
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_3(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 4
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_4(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 5
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_5(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 6
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_6(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 7
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_7(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 8
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_8(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 9
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_9(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case Else
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_10(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If
                        End Select

                        'Calculo De la Transformada Wavelet con escala de Correcion 
                        Modulo_Anlisis.Transformada_Wavelet_Reset_Escala(Escala_Trasnformada_Wavelet_Onda_PT_Correcion)
                        Select Case Escala_Trasnformada_Wavelet_Onda_PT_Correcion
                            Case 1
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_1(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 2
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_2(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 3
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_3(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 4
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_4(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 5
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_5(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 6
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_6(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 7
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_7(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 8
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_8(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case 9
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_9(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If

                            Case Else
                                If Modulo_Anlisis.Transformada_Wavelet_Escala_10(Coneccion_Base_Datos_Filtrado_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Registro_Analizar, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Max_Puntero, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                    e.Cancel = True
                                    Return
                                End If
                        End Select

                    End If

                    'Deteccion de la Onda T
                    If Deteccion_Onda_T Or Deteccion_Onda_T_temp Then
                        If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_T") = 1 Then
                            Tabla_Onda_T = Tabla + "___Onda_T"
                        Else
                            Tabla_Onda_T = Tabla + "___Tabla_Onda_T_Temp"
                            If Modulo_Anlisis.Deteccion_Onda_T_Clasificacion_Con_Correccion(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Coneccion_Registro, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Tabla_QRS, Tabla_Onda_T, Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        End If
                    End If

                    'Deteccion de la Onda P
                    If Deteccion_Onda_P Or Deteccion_Onda_P_temp Then
                        If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_P") = 1 Then
                            Tabla_Onda_P = Tabla + "___Onda_P"
                        Else
                            Tabla_Onda_P = Tabla + "___Tabla_Onda_P_Temp"
                            If Modulo_Anlisis.Deteccion_Onda_P_Clasificacion_Con_Correccion(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp, Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp, Coneccion_Registro, Tabla_Transformada_Wavelet_Onda_PT_Busqueda, Tabla_Transformada_Wavelet_Onda_PT_Correcion, Columnas_Existentes.Item(Index1).ToString(), Tabla_QRS, Tabla_Onda_P, Frecuencia, Configuracion_Deteccion_QRS, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If

                        End If
                    End If

                    'Calculo Intervalo R-R
                    If Deteccion_Intervalo_R_R Then
                        If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Intervalo_R_R") = 1 Then
                            Tabla_Intervalo_R_R = Tabla + "___Intervalo_R_R"
                        Else
                            Tabla_Intervalo_R_R = Tabla + "___Tabla_Intervalo_R_R_Temp"
                            If Modulo_Anlisis.Calculo_Intervalo_En_Una_Tabla(Coneccion_Registro, Tabla_QRS, "R", "Temp", Columnas_Existentes.Item(Index1).ToString(), Frecuencia, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If
                        End If
                    End If

                    'Calculo Intervalo Q-T
                    If Deteccion_Intervalo_Q_T Then
                        If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Intervalo_Q_T") = 1 Then
                            Tabla_Intervalo_Q_T = Tabla + "___Intervalo_Q_T"
                        Else
                            Tabla_Intervalo_Q_T = Tabla + "___Tabla_Intervalo_Q_T_Temp"
                            If Modulo_Anlisis.Calculo_Intervalo_En_Dos_Tabla(Coneccion_Registro, Tabla_QRS, "Q", Tabla_Onda_T, "T", Tabla_Intervalo_Q_T, Columnas_Existentes.Item(Index1).ToString(), Frecuencia, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If
                        End If
                    End If
                    'Calculo Intervalo P-R
                    If Deteccion_Intervalo_P_R Then
                        If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Intervalo_P_R") = 1 Then
                            Tabla_Intervalo_P_R = Tabla + "___Intervalo_P_R"
                        Else
                            Tabla_Intervalo_P_R = Tabla + "___Tabla_Intervalo_P_R_Temp"
                            If Modulo_Anlisis.Calculo_Intervalo_En_Dos_Tabla(Coneccion_Registro, Tabla_QRS, "Q", Tabla_Onda_T, "T", Tabla_Intervalo_P_R, Columnas_Existentes.Item(Index1).ToString(), Frecuencia, BackgroundWorker_Analisis_Multi_Registro) = False Then
                                e.Cancel = True
                                Return
                            End If
                        End If
                    End If

                End If

                'Almacenar Datos(Se modifica el nombre de las tablas de los elementos selecionados por lo que se eliminan los temporales), Si no se entra en esta obcion los datos quedan en los temporales
                If CheckBox_Recalcular_Resultados.Checked Then
                    'Comprobar si existe el registro rescribirlo 
                    If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Derivacion_Filtrada") = 2 Then
                        Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Agregar_Dato(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Derivacion_Filtrada", "0")
                        'Else
                        '    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Eliminar_Dato(Coneccion_Registro, Tabla, Columnas_Existentes.Item(Index1).ToString().ToString())
                        '    Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Agregar_Dato(Coneccion_Registro, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Derivacion_Filtrada", "0")
                    End If

                    If Deteccion_Complejo_QRS Then
                        Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Complejo_QRS", "1")
                        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla + "___Complejo_QRS")
                        'If CheckBox_Corregir_Puntos_Complejo_QRS.CheckState Then
                        '    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS + "_1", Tabla  + "___Complejo_QRS")
                        'Else
                        Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS, Tabla + "___Complejo_QRS")
                        'End If
                    End If
                    If Deteccion_Onda_T Then
                        Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_T", "1")
                        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla + "___Onda_T")
                        Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Onda_T, Tabla + "___Onda_T")
                    End If
                    If Deteccion_Onda_P Then
                        Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_P", "1")
                        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla + "___Onda_P")
                        Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Onda_P, Tabla + "___Onda_P")
                    End If

                    If Deteccion_Intervalo_R_R Then
                        Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Intervalo_R_R", "1")
                        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla + "___Intervalo_R_R")
                        Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Intervalo_R_R, Tabla + "___Intervalo_R_R")
                    End If

                    If Deteccion_Intervalo_Q_T Then
                        Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Intervalo_Q_T", "1")
                        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla + "___Intervalo_Q_T")
                        Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Intervalo_Q_T, Tabla + "___Intervalo_Q_T")
                    End If

                    If Deteccion_Intervalo_P_R Then
                        Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Intervalo_P_R", "1")
                        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla + "___Intervalo_P_R")
                        Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Intervalo_P_R, Tabla + "___Intervalo_P_R")
                    End If
                Else
                    'Comprobar si existe el registro rescribirlo 
                    If Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Derivacion_Filtrada") = 2 Then
                        Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Agregar_Dato(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Derivacion_Filtrada", "0")
                    End If

                    If Deteccion_Complejo_QRS And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Complejo_QRS") <> 1 Then
                        Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Complejo_QRS", "1")
                        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla + "___Complejo_QRS")
                        'If CheckBox_Corregir_Puntos_Complejo_QRS.CheckState Then
                        '    Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS + "_1", Tabla  + "___Complejo_QRS")
                        'Else
                        Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_QRS, Tabla + "___Complejo_QRS")
                        'End If
                    End If
                    If Deteccion_Onda_T And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_T") <> 1 Then
                        Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_T", "1")
                        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla + "___" + Columnas_Existentes.Item(Index1).ToString().ToString() + "___Onda_T")
                        Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Onda_T, Tabla + "___Onda_T")
                    End If
                    If Deteccion_Onda_P And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_P") <> 1 Then
                        Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Onda_P", "1")
                        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla + "___Onda_P")
                        Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Onda_P, Tabla + "___Onda_P")
                    End If
                    If Deteccion_Intervalo_R_R And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Intervalo_R_R") <> 1 Then
                        Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Intervalo_R_R", "1")
                        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla + "___Intervalo_R_R")
                        Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Intervalo_R_R, Tabla + "___Intervalo_R_R")
                    End If

                    If Deteccion_Intervalo_Q_T And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Intervalo_Q_T") <> 1 Then
                        Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Intervalo_Q_T", "1")
                        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla + "___Intervalo_Q_T")
                        Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Intervalo_Q_T, Tabla + "___Intervalo_Q_T")
                    End If

                    If Deteccion_Intervalo_P_R And Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Consultar_Dato_Campo(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Intervalo_P_R") <> 1 Then
                        Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Derivada_Procesada_Actualizar_Dato(Coneccion_Base_Datos, Tabla, Columnas_Existentes.Item(Index1).ToString(), "Intervalo_P_R", "1")
                        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla + "___Intervalo_P_R")
                        Class_Funciones_Base_Datos.Registros_Renombrar_Registro(Coneccion_Registro, Tabla_Intervalo_P_R, Tabla + "___Intervalo_P_R")
                    End If
                End If

                If CheckBox_Eliminar_Temporales_Calculados.Checked Then
                    Dim Nombre_Tablas_Existentes As New DataSet
                    Nombre_Tablas_Existentes = Class_Funciones_Base_Datos.Tabla_Todas_Existentes(Coneccion_Registro)

                    For Index = Nombre_Tablas_Existentes.Tables(0).Rows.Count - 1 To 0 Step -1
                        If InStr(Nombre_Tablas_Existentes.Tables(0).Rows(Index)(0), "Temp") <> 0 Then
                            Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Nombre_Tablas_Existentes.Tables(0).Rows(Index)(0))
                        End If
                    Next Index
                    Try
                        Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Registro)
                        Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Registro)
                    Catch ex As Exception

                    End Try
                    'If InStr(Registro_Analizar, "___Filtrado_Temp") <> 0 Then
                    '    Class_Funciones_Base_Datos.Eliminar_Tabla(Coneccion_Registro, Registro_Analizar)
                    'End If
                    ''Class_Funciones_Base_Datos.Eliminar_Tabla(Coneccion_Registro, Tabla + "___Filtrado_Temp")
                    'If Tabla_Transformada_Wavelet_QRS <> Nothing Then
                    '    Class_Funciones_Base_Datos.Eliminar_Tabla(Coneccion_Registro, Tabla_Transformada_Wavelet_QRS)
                    'End If
                    'If (Tabla_Transformada_Wavelet_Onda_PT_Busqueda <> Nothing) Then
                    '    Class_Funciones_Base_Datos.Eliminar_Tabla(Coneccion_Registro, Tabla_Transformada_Wavelet_Onda_PT_Busqueda)
                    '    Class_Funciones_Base_Datos.Eliminar_Tabla(Coneccion_Registro, Tabla_Transformada_Wavelet_Onda_PT_Correcion)
                    'End If
                    'Class_Funciones_Base_Datos.Eliminar_Tabla(Coneccion_Registro, Tabla + "___" + Columnas_Existentes.Item(Index1).ToString() + "___Tabla_QRS_Temp")
                    'Class_Funciones_Base_Datos.Eliminar_Tabla(Coneccion_Registro, Tabla + "___" + Columnas_Existentes.Item(Index1).ToString() + "___Tabla_QRS_Temp_1")
                    'Class_Funciones_Base_Datos.Eliminar_Tabla(Coneccion_Registro, Tabla + "___Tabla_QRS_Temp_11")
                    'Class_Funciones_Base_Datos.Eliminar_Tabla(Coneccion_Registro, Tabla + "___Tabla_Onda_T_Temp")
                    'Class_Funciones_Base_Datos.Eliminar_Tabla(Coneccion_Registro, Tabla + "___Tabla_Onda_P_Temp")
                Else
                    If (Tabla_Transformada_Wavelet_Onda_PT_Busqueda <> Nothing) Then
                        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_Transformada_Wavelet_Onda_PT_Busqueda)
                        Class_Funciones_Base_Datos.Registros_Eliminar_Registro(Coneccion_Registro, Tabla_Transformada_Wavelet_Onda_PT_Correcion)
                    End If
                    Try
                        Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_QRS)
                        Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_QRS)
                        Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp)
                        Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Busqueda_Temp)
                        Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp)
                        Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Base_Datos_Transformada_Wavelet_Onda_PT_Correcion_Temp)
                        Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Base_Datos_Filtrado_Temp)
                        Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Base_Datos_Filtrado_Temp)
                        Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Registro)
                        Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Registro)
                    Catch ex As Exception

                    End Try
                End If
                'Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Registro)
                'Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Registro)
                Coneccion_Registro.Close()
                Coneccion_Registro.Dispose()
            Next
            Columnas_Existentes.Clear()
        Next Index_Multi_Registro
        'Class_Funciones_Base_Datos.Optimizar_Espacio_Base_Datos(Coneccion_Base_Datos)
        'Class_Funciones_Base_Datos.Optimizar_Indices_Acceso_Tabla_Base_Datos(Coneccion_Base_Datos)
        Coneccion_Base_Datos.Close()
        Coneccion_Base_Datos.Dispose()


    End Sub

    Private Sub BackgroundWorker_Analisis_Multi_Registro_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker_Analisis_Multi_Registro.ProgressChanged
        Dim Progreso As Int64 = e.ProgressPercentage
        Dim Porcentaje_Progreso As Int64 = Progreso Mod 1000
        Dim Derivacion As Int64 = (Progreso Mod 100000) / 1000
        Dim Procedimiento As Int64 = Math.Floor(Progreso / 100000)
        Dim Texto As String
        Texto = Convert.ToString(Porcentaje_Progreso) + "% " + Modulo_Anlisis.Derivada_To_String(Derivacion) + " "

        Const Procedimiento_Filtrando_Señal = 1
        Const Procedimiento_Trasnformada_Wavelet = 2
        Const Procedimiento_Deteccion_QRS = 3
        Const Procedimiento_Deteccion_Onda_T = 4
        Const Procedimiento_Deteccion_Onda_P = 5
        Const Procedimiento_Correcion_Puntos_Complejo_QRS = 6
        Const Procedimiento_Busqueda_Complejo_QRS_No_Detectados = 7
        Const Procedimiento_Calculo_Intervalo = 8
        Const Procedimiento_Calculo_Intervalo_RR = 9
        Const Procedimiento_Calculo_Intervalo_QT = 10
        Const Procedimiento_Calculo_Intervalo_PR = 11

        Select Case Procedimiento
            Case Procedimiento_Filtrando_Señal
                Texto = Texto + "Filtering Derivation"
            Case Procedimiento_Trasnformada_Wavelet
                Texto = Texto + "Calculation Wavelet Transform"
            Case Procedimiento_Deteccion_QRS
                Texto = Texto + "Obtaining points of the QRS complex"
            Case Procedimiento_Deteccion_Onda_T
                Texto = Texto + "Obtaining points of Wave T"
            Case Procedimiento_Deteccion_Onda_P
                Texto = Texto + "Obtaining points of Wave P"
            Case Procedimiento_Correcion_Puntos_Complejo_QRS
                Texto = Texto + "Correction of QRS Complex Points"
            Case Procedimiento_Busqueda_Complejo_QRS_No_Detectados
                Texto = Texto + "Search for Undetected QRS Complexes"
            Case Procedimiento_Calculo_Intervalo
                Texto = Texto + "Interval Calculation"
            Case Procedimiento_Calculo_Intervalo_RR
                Texto = Texto + "RR Interval Calculation"
            Case Procedimiento_Calculo_Intervalo_QT
                Texto = Texto + "QT Interval Calculation"
            Case Procedimiento_Calculo_Intervalo_PR
                Texto = Texto + "PR Interval Calculation"
            Case Else
        End Select
        Label_Progreso.Text = Texto
        If Porcentaje_Progreso > 100 Then
            Porcentaje_Progreso = 100
        End If
        ProgressBar_Progreso_Analisis.Value = Porcentaje_Progreso
        Label_Registro_Analizado_Multi_Registro.Text = Registro_Seleccionado_Multi_Registros.Item(Registro_En_Analisis_Multi_Registros).Tabla + "(" + Convert.ToString(Registro_En_Analisis_Multi_Registros + 1) + "/" + Convert.ToString(Registro_Seleccionado_Multi_Registros.Count) + ")"

    End Sub

    Private Sub BackgroundWorker_Analisis_Multi_Registro_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker_Analisis_Multi_Registro.RunWorkerCompleted
        Dim Contraseña_Incorrecta As New Form_Mensaje_Error
        Button_Analizar_Registro.Enabled = True

        Button_Analizar_Registro.Text = "Analyze"
        Label_Registro_Analizado_Multi_Registro.Text = "Record"
        Label_Progreso.Text = "Progress"
        ProgressBar_Progreso_Analisis.Value = 0
        If e.Cancelled = True Then
            Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "Analysis", "Canceled", "Finished", 0)
        Else
            Contraseña_Incorrecta.Form_Mensaje(Form_Principal, "Analysis", "Completed", "Completed", 1)
        End If
        'Desbloquear parametros de analisis
        TabPageEX_Configuracion_Análisis.Enabled = True
        TabPageEX_Filtrar_Señal.Enabled = True
        Button_Cargar_Registro.Enabled = True
        Button_Eliminar_Registro_Multi_Registro.Enabled = True
    End Sub



    Private Sub CheckedListBox_Registros_Analizar_Multi_Registro_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckedListBox_Registros_Analizar_Multi_Registro.KeyDown
        If CheckedListBox_Registros_Analizar_Multi_Registro_Bandera_Seleccion = 0 Then
            CheckedListBox_Registros_Analizar_Multi_Registro_Bandera_Seleccion = 1
            CheckedListBox_Registros_Analizar_Multi_Registro_Tecla_Presionada = e.KeyValue
            CheckedListBox_Registros_Analizar_Multi_Registro_Item_Selecionado = CheckedListBox_Registros_Analizar_Multi_Registro.SelectedIndex
        End If
    End Sub

    Private Sub CheckedListBox_Registros_Analizar_Multi_Registro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox_Registros_Analizar_Multi_Registro.SelectedIndexChanged

        If CheckedListBox_Registros_Analizar_Multi_Registro_Item_Selecionado - CheckedListBox_Registros_Analizar_Multi_Registro.SelectedIndex <> 0 And CheckedListBox_Registros_Analizar_Multi_Registro_Tecla_Presionada = 16 Then
            If CheckedListBox_Registros_Analizar_Multi_Registro.SelectedIndex - CheckedListBox_Registros_Analizar_Multi_Registro_Item_Selecionado > 0 Then
                For i = 0 To CheckedListBox_Registros_Analizar_Multi_Registro.Items.Count - 1
                    If i >= CheckedListBox_Registros_Analizar_Multi_Registro_Item_Selecionado And i <= CheckedListBox_Registros_Analizar_Multi_Registro.SelectedIndex Then
                        CheckedListBox_Registros_Analizar_Multi_Registro.SetItemChecked(i, True)
                    Else
                        CheckedListBox_Registros_Analizar_Multi_Registro.SetItemChecked(i, False)
                    End If
                Next
            Else
                For i = 0 To CheckedListBox_Registros_Analizar_Multi_Registro.Items.Count - 1
                    If i <= CheckedListBox_Registros_Analizar_Multi_Registro_Item_Selecionado And i >= CheckedListBox_Registros_Analizar_Multi_Registro.SelectedIndex Then
                        CheckedListBox_Registros_Analizar_Multi_Registro.SetItemChecked(i, True)
                    Else
                        CheckedListBox_Registros_Analizar_Multi_Registro.SetItemChecked(i, False)
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub CheckedListBox_Registros_Analizar_Multi_Registro_KeyUp(sender As Object, e As KeyEventArgs) Handles CheckedListBox_Registros_Analizar_Multi_Registro.KeyUp
        CheckedListBox_Registros_Analizar_Multi_Registro_Tecla_Presionada = -1
        CheckedListBox_Registros_Analizar_Multi_Registro_Item_Selecionado = -1
        CheckedListBox_Registros_Analizar_Multi_Registro_Bandera_Seleccion = 0

    End Sub

    Private Sub ComboBox_Fcb_Configuracion_Deteccion_QRS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Fcb_Configuracion_Deteccion_QRS.SelectedIndexChanged
        Configuracion_Deteccion_QRS.Frecuencia_Baja_Filtro = Convert.ToInt32(ComboBox_Fcb_Configuracion_Deteccion_QRS.Text)
        If Configuracion_Deteccion_QRS.Frecuencia_Baja_Filtro > Configuracion_Deteccion_QRS.Frecuencia_Alta_Filtro Then
            ComboBox_Fcb_Configuracion_Deteccion_QRS.Text = Convert.ToString(Configuracion_Deteccion_QRS.Frecuencia_Alta_Filtro - 1)
        End If
        Configuracion_Deteccion_QRS.Frecuencia_Baja_Filtro = Convert.ToDouble(ComboBox_Fcb_Configuracion_Deteccion_QRS.Text) 'Frecuencia pasa Baja del Filtro pasa banda
    End Sub

    Private Sub ComboBox_Fca_Configuracion_Deteccion_QRS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Fca_Configuracion_Deteccion_QRS.SelectedIndexChanged
        Configuracion_Deteccion_QRS.Frecuencia_Alta_Filtro = Convert.ToInt32(ComboBox_Fca_Configuracion_Deteccion_QRS.Text)
        If Configuracion_Deteccion_QRS.Frecuencia_Baja_Filtro > Configuracion_Deteccion_QRS.Frecuencia_Alta_Filtro Then
            ComboBox_Fca_Configuracion_Deteccion_QRS.Text = Convert.ToString(Configuracion_Deteccion_QRS.Frecuencia_Baja_Filtro + 1)
        End If
        Configuracion_Deteccion_QRS.Frecuencia_Alta_Filtro = Convert.ToDouble(ComboBox_Fca_Configuracion_Deteccion_QRS.Text) 'Frecuencia pasa Alta del Filtro pasa banda
    End Sub



    Private Sub TextBox_Duracion_Min_QRS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Duracion_Min_QRS.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox_Duracion_Max_QRS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Duracion_Max_QRS.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox_Desplaz_Despues_QRS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Desplaz_Despues_QRS.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox_Interv_Min_Entre_QRS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Interv_Min_Entre_QRS.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Button_Resetear_Parametros_Click(sender As Object, e As EventArgs) Handles Button_Resetear_Parametros.Click
        Incilizar_Configuracion_Deteccion_QRS()
    End Sub

    Private Sub ComboBox_Selec_TW_Onda_T_Busqueda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Selec_TW_Onda_PT_Busqueda.SelectedIndexChanged
        Select Case ComboBox_Selec_TW_Onda_PT_Busqueda.Text
            Case "TW 1"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda = 1
            Case "TW 2"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda = 2
            Case "TW 3"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda = 3
            Case "TW 4"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda = 4
            Case "TW 5"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda = 5
            Case "TW 6"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda = 6
            Case "TW 7"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda = 7
            Case "TW 8"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda = 8
            Case "TW 9"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda = 9
            Case "TW 10"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda = 10
            Case Else
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Busqueda = 1
                ComboBox_Selec_TW_QRS.Text = "TW 1"
        End Select
    End Sub

    Private Sub ComboBox_Selec_TW_Onda_T_Correcion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Selec_TW_Onda_PT_Correcion.SelectedIndexChanged
        Select Case ComboBox_Selec_TW_Onda_PT_Correcion.Text
            Case "TW 1"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion = 1
            Case "TW 2"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion = 2
            Case "TW 3"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion = 3
            Case "TW 4"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion = 4
            Case "TW 5"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion = 5
            Case "TW 6"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion = 6
            Case "TW 7"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion = 7
            Case "TW 8"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion = 8
            Case "TW 9"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion = 9
            Case "TW 10"
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion = 10
            Case Else
                Configuracion_Deteccion_QRS.Escala_TW_Onda_PT_Correcion = 1
                ComboBox_Selec_TW_QRS.Text = "TW 1"
        End Select
    End Sub

    Private Sub ComboBox_PorCiento_Rechazo_Ruido_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_PorCiento_Rechazo_Ruido_QRS.SelectedIndexChanged
        Try
            Configuracion_Deteccion_QRS.Margen_Separacion_Desniveles = Convert.ToDouble(ComboBox_PorCiento_Rechazo_Ruido_QRS.Text) / 100  'Establece  la relacion minima entre P_Max_Central y uno de los minimos para direnciar los cambios de nivel en la señal y un QRS
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox_P_C_Max_PorCiento_Comp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_P_C_Max_PorCiento_Comp_QRS.SelectedIndexChanged
        Try
            Configuracion_Deteccion_QRS.PorCiento_Comparacion_QRS = Convert.ToDouble(ComboBox_P_C_Max_PorCiento_Comp_QRS.Text) / 100 'Determian el cuanto se reduce margen Valor_Promedio_P_Max minimo para asignarselo a Valor_P_Max
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox_Avan_Antes_Cruce_Cero_Centro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS.SelectedIndexChanged
        Try
            Configuracion_Deteccion_QRS.PorCiento_Comparacion_Busqueda_QRS = Convert.ToDouble(ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS.Text) / 100 'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW entre P_Max_Izquierda y P_Max_Derecha 
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox_Angulo_Rechazo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Angulo_Rechazo_QRS.SelectedIndexChanged
        Try
            Configuracion_Deteccion_QRS.m_Comparacion_Wavelet_QRS = Math.Tan(Convert.ToDouble(ComboBox_Angulo_Rechazo_QRS.Text) * (Math.PI / 180)) 'tang 45°=1 Pendiente de comparacion Para deterla busqueda de punos significativos  
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox_Avan_Antes_Cruce_Cero_Extremos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS.SelectedIndexChanged
        Try
            Configuracion_Deteccion_QRS.PorCiento_Comparacion_Busqueda_Extremos_QRS = Convert.ToDouble(ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS.Text) / 100 'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW fuera de lso puntos P_Max_Izquierda y P_Max_Derecha 
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox_Duracion_Min_QRS_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Duracion_Min_QRS.TextChanged
        Try
            Configuracion_Deteccion_QRS.Duracion_Minima_QRS = Convert.ToDouble(TextBox_Duracion_Min_QRS.Text) / 1000 'Duracion Minima que puede tener un QRS
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox_Duracion_Max_QRS_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Duracion_Max_QRS.TextChanged
        Try
            Configuracion_Deteccion_QRS.Duracion_Maxima_QRS = Convert.ToDouble(TextBox_Duracion_Max_QRS.Text) / 1000 'Duracion Maxima que puede tener un QRS
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox_Desplaz_Despues_QRS_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Desplaz_Despues_QRS.TextChanged
        Try
            Configuracion_Deteccion_QRS.Demora_Despues_QRS = Convert.ToDouble(TextBox_Desplaz_Despues_QRS.Text) / 1000 'Demora_Despues_QRS*frecuencia desplasamiento despues de detectar un QRS   
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox_Interv_Min_Entre_QRS_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Interv_Min_Entre_QRS.TextChanged
        Try
            Configuracion_Deteccion_QRS.Separacion_Minima_QRS = Convert.ToDouble(TextBox_Interv_Min_Entre_QRS.Text) / 1000 'En segundos =200ms Separacion minima de debe existir entre dos QRS consecutivos de 200 ms 
        Catch ex As Exception

        End Try
    End Sub


    Private Sub TextBox_Desplaz_Despues__Punto_J_Onda_T_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Desplaz_Despues__Punto_J_Onda_T.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox_Desplaz_Antes__Punto_Qi_Onda_P_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Desplaz_Antes__Punto_Qi_Onda_P.KeyPress
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox_P_C_Max_PorCiento_Comp_Onda_PT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_P_C_Max_PorCiento_Comp_Onda_PT.SelectedIndexChanged
        Configuracion_Deteccion_QRS.PorCiento_Comparacion_Ondas_PT = Convert.ToDouble(ComboBox_P_C_Max_PorCiento_Comp_Onda_PT.Text) / 100 'Determian el cuanto se reduce margen Valor_Promedio_P_Max en % para asignarselo a Valor_P_Max
    End Sub

    Private Sub ComboBox_Avan_Antes_Cruce_Cero_Centro_Onda_PT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Avan_Antes_Cruce_Cero_Centro_Onda_PT.SelectedIndexChanged
        Configuracion_Deteccion_QRS.PorCiento_Comparacion_Busqueda_Ondas_PT = Convert.ToDouble(ComboBox_Avan_Antes_Cruce_Cero_Centro_Onda_PT.Text) / 100 'Determian asta que % de un maximo o un minimo se avansa antes de buscar el cruce por cero en la TW entre P_Max_Izquierda y P_Max_Derecha 
    End Sub

    Private Sub ComboBox_Angulo_Rechazo_Onda_PT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Angulo_Rechazo_Onda_PT.SelectedIndexChanged
        Configuracion_Deteccion_QRS.m_Comparacion_Wavelet_Ondas_PT = Math.Tan(Convert.ToDouble(ComboBox_Angulo_Rechazo_Onda_PT.Text) * (Math.PI / 180)) 'tang 45°=1 Pendiente de comparacion Para deterla busqueda de punos significativos  
    End Sub

    Private Sub TextBox_Desplaz_Despues__Punto_J_Onda_T_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Desplaz_Despues__Punto_J_Onda_T.TextChanged
        If TextBox_Desplaz_Despues__Punto_J_Onda_T.Text <> "" Then
            Configuracion_Deteccion_QRS.Dezplazamiento_Despues_Punto_J_Onda_T = Convert.ToDouble(TextBox_Desplaz_Despues__Punto_J_Onda_T.Text) / 1000 'Desplasamiento(ms) despues del Punto J antes de buscar la Onda T 
        End If
    End Sub

    Private Sub TextBox_Desplaz_Antes__Punto_Qi_Onda_P_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Desplaz_Antes__Punto_Qi_Onda_P.TextChanged
        If TextBox_Desplaz_Antes__Punto_Qi_Onda_P.Text <> "" Then
            Configuracion_Deteccion_QRS.Dezplazamiento_Despues_Punto_Qi_Onda_P = Convert.ToDouble(TextBox_Desplaz_Antes__Punto_Qi_Onda_P.Text) / 1000 'Desplasamiento(ms) Antes del Punto Qi antes de buscar la Onda P 
        End If
    End Sub

    Private Sub ComboBox_PorCiento_Busqueda_Interv_RR_Onda_T_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_PorCiento_Busqueda_Interv_RR_Onda_T.SelectedIndexChanged
        If ComboBox_PorCiento_Busqueda_Interv_RR_Onda_T.Text <> "" Then
            Configuracion_Deteccion_QRS.PorCiento_Busqueda_en_Interv_RR_Onda_T = Convert.ToDouble(ComboBox_PorCiento_Busqueda_Interv_RR_Onda_T.Text) / 100 '% del Intervalo RR Asta el cual se busca la Onda T apartir del punto J   
            Configuracion_Deteccion_QRS.PorCiento_Busqueda_en_Interv_RR_Onda_P = 1 - Convert.ToDouble(ComboBox_PorCiento_Busqueda_Interv_RR_Onda_T.Text) / 100 '% del Intervalo RR Asta el cual se busca la Onda P apartir del punto Qi
            ComboBox_PorCiento_Busqueda_Interv_RR_Onda_T.SelectedIndex = ComboBox_PorCiento_Busqueda_Interv_RR_Onda_T.FindString(Convert.ToString(Configuracion_Deteccion_QRS.PorCiento_Busqueda_en_Interv_RR_Onda_T * 100))
            ComboBox_PorCiento_Busqueda_Interv_RR_Onda_P.SelectedIndex = ComboBox_PorCiento_Busqueda_Interv_RR_Onda_P.FindString(Convert.ToString(Configuracion_Deteccion_QRS.PorCiento_Busqueda_en_Interv_RR_Onda_P * 100))
        Else
            ComboBox_PorCiento_Busqueda_Interv_RR_Onda_T.SelectedIndex = ComboBox_PorCiento_Busqueda_Interv_RR_Onda_T.FindString(Convert.ToString(Configuracion_Deteccion_QRS.PorCiento_Busqueda_en_Interv_RR_Onda_T * 100))
            ComboBox_PorCiento_Busqueda_Interv_RR_Onda_P.SelectedIndex = ComboBox_PorCiento_Busqueda_Interv_RR_Onda_P.FindString(Convert.ToString(Configuracion_Deteccion_QRS.PorCiento_Busqueda_en_Interv_RR_Onda_P * 100))

        End If
    End Sub

    Private Sub ComboBox_PorCiento_Busqueda_Interv_RR_Onda_P_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_PorCiento_Busqueda_Interv_RR_Onda_P.SelectedIndexChanged
        If ComboBox_PorCiento_Busqueda_Interv_RR_Onda_P.Text <> "" Then
            Configuracion_Deteccion_QRS.PorCiento_Busqueda_en_Interv_RR_Onda_P = Convert.ToDouble(ComboBox_PorCiento_Busqueda_Interv_RR_Onda_P.Text) / 100 '% del Intervalo RR Asta el cual se busca la Onda P apartir del punto Qi
            Configuracion_Deteccion_QRS.PorCiento_Busqueda_en_Interv_RR_Onda_T = 1 - Convert.ToDouble(ComboBox_PorCiento_Busqueda_Interv_RR_Onda_P.Text) / 100 '% del Intervalo RR Asta el cual se busca la Onda T apartir del punto J   
            ComboBox_PorCiento_Busqueda_Interv_RR_Onda_T.SelectedIndex = ComboBox_PorCiento_Busqueda_Interv_RR_Onda_T.FindString(Convert.ToString(Configuracion_Deteccion_QRS.PorCiento_Busqueda_en_Interv_RR_Onda_T * 100))
            ComboBox_PorCiento_Busqueda_Interv_RR_Onda_P.SelectedIndex = ComboBox_PorCiento_Busqueda_Interv_RR_Onda_P.FindString(Convert.ToString(Configuracion_Deteccion_QRS.PorCiento_Busqueda_en_Interv_RR_Onda_P * 100))
        Else
            ComboBox_PorCiento_Busqueda_Interv_RR_Onda_T.SelectedIndex = ComboBox_PorCiento_Busqueda_Interv_RR_Onda_T.FindString(Convert.ToString(Configuracion_Deteccion_QRS.PorCiento_Busqueda_en_Interv_RR_Onda_T * 100))
            ComboBox_PorCiento_Busqueda_Interv_RR_Onda_P.SelectedIndex = ComboBox_PorCiento_Busqueda_Interv_RR_Onda_P.FindString(Convert.ToString(Configuracion_Deteccion_QRS.PorCiento_Busqueda_en_Interv_RR_Onda_P * 100))
        End If
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
    Private Sub TreeView_Elementos_Calcular_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView_Elementos_Calcular.AfterCheck
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
    End Sub

    Private Sub CheckBox_Analisis_Multi_Registro_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Analisis_Multi_Registro.CheckedChanged
        If CheckBox_Analisis_Multi_Registro.Checked = False Then
            'Si esta activo al analisis de un solo registro
            CheckBox_Selecionar_Todos_Registros.Visible = False
            CheckBox_Selecionar_Todos_Registros.Checked = False
            PictureBox_Registro.Visible = True
            ComboBox_Selecionar_Registro.Visible = True
            Label_Registro.Visible = True
            CheckedListBox_Registros.Location = New Point(3, 183)
            CheckedListBox_Registros.Items.Clear()
            For j = Registro_Seleccionado_Multi_Registros.Count - 1 To 0 Step -1
                Form_Principal.Estado_Registros.Desbloquear_Registro(Registro_Seleccionado_Multi_Registros.Item(j).Tabla.ToString())
            Next j

            CheckedListBox_Registros_Analizar_Multi_Registro.Items.Clear()
            Label_Registro_Seleccionado.Text = "Records:"
            SplitContainer_Analisis.SplitterDistance = 25
            CheckedListBox_Registros_Analizar_Multi_Registro.Visible = False
            Button_Eliminar_Registro_Multi_Registro.Visible = False
        Else
            'Si esta activo al analisis de  multi registro
            CheckBox_Selecionar_Todos_Registros.Visible = True
            PictureBox_Registro.Visible = False
            ComboBox_Selecionar_Registro.Visible = False
            Label_Registro.Visible = False

            CheckedListBox_Registros.Location = PictureBox_Registro.Location
            'Liberar el registro selecionado
            Form_Principal.Estado_Registros.Desbloquear_Registro(Registro_Seleccionado.Tabla)
            Registro_Seleccionado.Usuario = ""
            Registro_Seleccionado.Paciente = ""
            Registro_Seleccionado.Fecha_Registro = ""
            Registro_Seleccionado.Tabla = ""
            Registro_Seleccionado.Max_Puntero = 0
            Registro_Seleccionado.Frecuencia = 0

            SplitContainer_Analisis.SplitterDistance = 0
            CheckedListBox_Registros_Analizar_Multi_Registro.Visible = True
            Button_Eliminar_Registro_Multi_Registro.Visible = True
        End If

        If CheckBox_Analisis_Multi_Registro.Checked = False Then
            'Si esta activo al analisis de un solso registro registro
            If Form_Principal.Usuario_Activo.Tipo_Usuario = 1 Then
                Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
                'Identificar los registors existentes relacionados con el paciente
                If ComboBox_Selecion_Paciente.Items.Count > 0 Then
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
                If Registro_Seleccionado.Tabla <> "" Then
                    'Cargar las derivaciones disponibles
                    Dim Columnas As List(Of String) = Class_Funciones_Base_Datos.Columnas_Existentes_Tabla(Coneccion_Usuarios, Registro_Seleccionado.Tabla)
                    For i = 0 To Columnas.Count - 1
                        If Columnas.Item(i) <> "Puntero" Then
                            CheckedListBox_Registros.Items.Add(Columnas.Item(i))
                        End If
                    Next i
                End If
            ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
                Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
                'Identificar los registors existentes relacionados con el paciente
                If ComboBox_Selecion_Paciente.Items.Count > 0 Then
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
                If Registro_Seleccionado.Tabla <> "" Then
                    'Cargar las derivaciones disponibles
                    Dim Columnas As List(Of String) = Class_Funciones_Base_Datos.Columnas_Existentes_Tabla(Coneccion_Usuarios, Registro_Seleccionado.Tabla)
                    For i = 0 To Columnas.Count - 1
                        If Columnas.Item(i) <> "Puntero" Then
                            CheckedListBox_Registros.Items.Add(Columnas.Item(i))
                        End If
                    Next i
                End If
            End If


        Else
            'Si esta activo al analisis de  multi registro
            If Form_Principal.Usuario_Activo.Tipo_Usuario = 1 Then
                Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
                'Identificar los registors existentes relacionados con el paciente
                If ComboBox_Selecion_Paciente.Items.Count > 0 Then
                    Dim Fecha_Registro As New DataSet
                    Fecha_Registro = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Usuarios, Form_Principal.Usuario_Activo.Usuario.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"))

                    CheckedListBox_Registros.Items.Clear()

                    For i = 0 To Fecha_Registro.Tables(0).Rows.Count - 1
                        CheckedListBox_Registros.Items.Add(Fecha_Registro.Tables(0).Rows(i)(0))
                    Next i
                    Coneccion_Usuarios.Close()

                End If
            ElseIf Form_Principal.Usuario_Activo.Tipo_Usuario = 2 Then
                Dim Coneccion_Usuarios As SqlConnection = Class_Funciones_Base_Datos.Coneccion_Base_Datos()
                'Identificar los registors existentes relacionados con el paciente
                If ComboBox_Selecion_Paciente.Items.Count > 0 Then
                    Dim Fecha_Registro As New DataSet
                    Fecha_Registro = Class_Funciones_Base_Datos.Tabla_Relacion_Registro_Paciente_Usuario_Buscar_Registros(Coneccion_Usuarios, ComboBox_Selecion_Usuario.Text.TrimEnd.Replace(" ", "_"), ComboBox_Selecion_Paciente.Text.TrimEnd.Replace(" ", "_"))

                    CheckedListBox_Registros.Items.Clear()

                    For i = 0 To Fecha_Registro.Tables(0).Rows.Count - 1
                        CheckedListBox_Registros.Items.Add(Fecha_Registro.Tables(0).Rows(i)(0))
                    Next i

                End If
            End If
            If CheckBox_Selecionar_Todos_Registros.Checked Then
                For i = 0 To CheckedListBox_Registros.Items.Count - 1
                    CheckedListBox_Registros.SetItemChecked(i, True)
                Next
            End If
        End If
    End Sub


    Private Sub Button_Principal_MouseEnter(sender As Object, e As EventArgs) Handles Button_Analizar_Registro.MouseEnter, Button_Resetear_Parametros.MouseEnter, Button_Filtrar_Registro.MouseEnter, Button_Eliminar_Registro_Multi_Registro.MouseEnter, Button_Cargar_Registro.MouseEnter
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseEnter
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde_Cambio
    End Sub

    Private Sub Button_Principal_MouseLeave(sender As Object, e As EventArgs) Handles Button_Analizar_Registro.MouseLeave, Button_Resetear_Parametros.MouseLeave, Button_Filtrar_Registro.MouseLeave, Button_Eliminar_Registro_Multi_Registro.MouseLeave, Button_Cargar_Registro.MouseLeave
        'Funcion General para el cambio de fondo en los botones del Form Principal cuano ocurre MouseLeave
        Dim Buttom_Temp = CType(sender, Button)
        Buttom_Temp.BackgroundImage = My.Resources.Boton_Verde
    End Sub

    Private Sub ComboBox_Discriminante_Ruido_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Discriminante_Ruido.SelectedIndexChanged
        If ComboBox_Discriminante_Ruido.Text <> "" Then
            Configuracion_Deteccion_QRS.PorCiento_Discriminante_Ruido_PT = Convert.ToDouble(ComboBox_Discriminante_Ruido.Text) / 100 '% de P_Min_Max_Comparacion para comparar los maximos-minimos y eliminar el posible ruido ruido
            ComboBox_Discriminante_Ruido.SelectedIndex = ComboBox_Discriminante_Ruido.FindString(Convert.ToString(Configuracion_Deteccion_QRS.PorCiento_Discriminante_Ruido_PT * 100))
        Else
            ComboBox_Discriminante_Ruido.SelectedIndex = ComboBox_Discriminante_Ruido.FindString(Convert.ToString(Configuracion_Deteccion_QRS.PorCiento_Discriminante_Ruido_PT * 100))
        End If
    End Sub

    Private Sub CheckBox_fcb_05_Hz_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox_fcb_05_Hz.MouseUp
        CheckBox_fcb_Ninguna.Checked = False
        CheckBox_fcb_005_Hz.Checked = False
        CheckBox_fcb_05_Hz.Checked = True
        CheckBox_fcb_1_Hz.Checked = False
        CheckBox_fcb_5_Hz.Checked = False
        CheckBox_fcb_10_Hz.Checked = False

        CheckBox_Notch_Ninguna.Checked = True
        CheckBox_Notch_50_Hz.Checked = False
        CheckBox_Notch_60_Hz.Checked = False
    End Sub

    Private Sub CheckBox_fcb_005_Hz_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckBox_fcb_005_Hz.MouseUp
        CheckBox_fcb_Ninguna.Checked = False
        CheckBox_fcb_005_Hz.Checked = True
        CheckBox_fcb_05_Hz.Checked = False
        CheckBox_fcb_1_Hz.Checked = False
        CheckBox_fcb_5_Hz.Checked = False
        CheckBox_fcb_10_Hz.Checked = False

        CheckBox_Notch_Ninguna.Checked = True
        CheckBox_Notch_50_Hz.Checked = False
        CheckBox_Notch_60_Hz.Checked = False
    End Sub

    Private Sub ComboBox_PorCiento_Rechazo_Extremos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_PorCiento_Rechazo_Extremos.SelectedIndexChanged
        Configuracion_Deteccion_QRS.PorCiento_Rechazo_Extremos = Convert.ToDouble(ComboBox_PorCiento_Rechazo_Extremos.Text) / 100 '% de rechaso de los puntos estremos(P_Max_Derecha y P_Max_Izquierda ) con respecto P_Max_Central
    End Sub
End Class
