<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControl_Modulo_Analicis_Señal
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_Modulo_Analicis_Señal))
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("QRS")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Waves", New System.Windows.Forms.TreeNode() {TreeNode9})
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("R-R")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Intervals", New System.Windows.Forms.TreeNode() {TreeNode11})
        Me.TabControlEX1 = New Dotnetrix.Controls.TabControlEX()
        Me.TabPageEX_Configuracion_Análisis = New Dotnetrix.Controls.TabPageEX()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.ComboBox_PorCiento_Rechazo_Extremos = New System.Windows.Forms.ComboBox()
        Me.Button_Resetear_Parametros = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ComboBox_PorCiento_Rechazo_Ruido_QRS = New System.Windows.Forms.ComboBox()
        Me.TextBox_Interv_Min_Entre_QRS = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox_Desplaz_Despues_QRS = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox_Duracion_Max_QRS = New System.Windows.Forms.TextBox()
        Me.TextBox_Duracion_Min_QRS = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboBox_Angulo_Rechazo_QRS = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS = New System.Windows.Forms.ComboBox()
        Me.ComboBox_P_C_Max_PorCiento_Comp_QRS = New System.Windows.Forms.ComboBox()
        Me.CheckBox_Selec_Auto_TW_QRS = New System.Windows.Forms.CheckBox()
        Me.Label_Parametros_Deteccion_Complejo_QRS = New System.Windows.Forms.Label()
        Me.Label_Fca = New System.Windows.Forms.Label()
        Me.Label_Fcb = New System.Windows.Forms.Label()
        Me.ComboBox_Fca_Configuracion_Deteccion_QRS = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Fcb_Configuracion_Deteccion_QRS = New System.Windows.Forms.ComboBox()
        Me.CheckBox_Eliminar_Temporales_Calculados = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Deteccion_Complejo_QRS_Faltantes = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Corregir_Puntos_Complejo_QRS = New System.Windows.Forms.CheckBox()
        Me.ComboBox_Selec_TW_QRS = New System.Windows.Forms.ComboBox()
        Me.CheckBox_Filtrar_Señal = New System.Windows.Forms.CheckBox()
        Me.TabPageEX_Análisis_Un_Registro = New Dotnetrix.Controls.TabPageEX()
        Me.Label_Registro_Analizado_Multi_Registro = New System.Windows.Forms.Label()
        Me.TreeView_Elementos_Calcular = New System.Windows.Forms.TreeView()
        Me.Label_Progreso = New System.Windows.Forms.Label()
        Me.CheckedListBox_Registros_Analizar_Multi_Registro = New System.Windows.Forms.CheckedListBox()
        Me.Button_Eliminar_Registro_Multi_Registro = New System.Windows.Forms.Button()
        Me.CheckBox_Recalcular_Resultados = New System.Windows.Forms.CheckBox()
        Me.Button_Analizar_Registro = New System.Windows.Forms.Button()
        Me.ProgressBar_Progreso_Analisis = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPageEX_Filtrar_Señal = New Dotnetrix.Controls.TabPageEX()
        Me.CheckBox_fcb_005_Hz = New System.Windows.Forms.CheckBox()
        Me.CheckBox_fcb_05_Hz = New System.Windows.Forms.CheckBox()
        Me.ComboBox_fcb = New System.Windows.Forms.ComboBox()
        Me.ComboBox_fca = New System.Windows.Forms.ComboBox()
        Me.Label_Filtro_Notch = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox_Filtro_Pasa_Banda = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Filtro_Para_Banda = New System.Windows.Forms.CheckBox()
        Me.CheckBox_fca_200_Hz = New System.Windows.Forms.CheckBox()
        Me.CheckBox_fca_150_Hz = New System.Windows.Forms.CheckBox()
        Me.CheckBox_fca_100_Hz = New System.Windows.Forms.CheckBox()
        Me.CheckBox_fcb_10_Hz = New System.Windows.Forms.CheckBox()
        Me.CheckBox_fca_50_Hz = New System.Windows.Forms.CheckBox()
        Me.CheckBox_fcb_5_Hz = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Notch_60_Hz = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Notch_50_Hz = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Notch_Ninguna = New System.Windows.Forms.CheckBox()
        Me.CheckBox_fca_Ninguna = New System.Windows.Forms.CheckBox()
        Me.CheckBox_fcb_1_Hz = New System.Windows.Forms.CheckBox()
        Me.CheckBox_fcb_Ninguna = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Reescribir_Registro = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Filtro_Personalizado = New System.Windows.Forms.CheckBox()
        Me.Label_Progreso_Filtro = New System.Windows.Forms.Label()
        Me.Button_Filtrar_Registro = New System.Windows.Forms.Button()
        Me.ProgressBar_Filtrar_Registro = New System.Windows.Forms.ProgressBar()
        Me.SplitContainer_Analizis_Registro = New System.Windows.Forms.SplitContainer()
        Me.CheckBox_Analisis_Multi_Registro = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Selecionar_Todos_Registros = New System.Windows.Forms.CheckBox()
        Me.CheckedListBox_Registros = New System.Windows.Forms.CheckedListBox()
        Me.ComboBox_Selecionar_Registro = New System.Windows.Forms.ComboBox()
        Me.Button_Independizar_Ventana = New System.Windows.Forms.Button()
        Me.Button_Cerrar = New System.Windows.Forms.Button()
        Me.PictureBox_Paciente = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Usuario = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Registro = New System.Windows.Forms.PictureBox()
        Me.Label_Usuario = New System.Windows.Forms.Label()
        Me.ComboBox_Selecion_Usuario = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Selecion_Paciente = New System.Windows.Forms.ComboBox()
        Me.Label_Paciente = New System.Windows.Forms.Label()
        Me.Label_Registro = New System.Windows.Forms.Label()
        Me.Button_Cargar_Registro = New System.Windows.Forms.Button()
        Me.SplitContainer_Analisis = New System.Windows.Forms.SplitContainer()
        Me.Label_Registro_Seleccionado = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BackgroundWorker_Analisis_Registro = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker_Filtrar_Registro = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker_Analisis_Multi_Registro = New System.ComponentModel.BackgroundWorker()
        Me.ToolTip_Informacion = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControlEX1.SuspendLayout()
        Me.TabPageEX_Configuracion_Análisis.SuspendLayout()
        Me.TabPageEX_Análisis_Un_Registro.SuspendLayout()
        Me.TabPageEX_Filtrar_Señal.SuspendLayout()
        CType(Me.SplitContainer_Analizis_Registro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_Analizis_Registro.Panel1.SuspendLayout()
        Me.SplitContainer_Analizis_Registro.Panel2.SuspendLayout()
        Me.SplitContainer_Analizis_Registro.SuspendLayout()
        CType(Me.PictureBox_Paciente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Usuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Registro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer_Analisis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_Analisis.Panel1.SuspendLayout()
        Me.SplitContainer_Analisis.Panel2.SuspendLayout()
        Me.SplitContainer_Analisis.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControlEX1
        '
        Me.TabControlEX1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlEX1.Appearance = Dotnetrix.Controls.TabAppearanceEX.FlatTab
        Me.TabControlEX1.BackColor = System.Drawing.Color.Transparent
        Me.TabControlEX1.Controls.Add(Me.TabPageEX_Configuracion_Análisis)
        Me.TabControlEX1.Controls.Add(Me.TabPageEX_Análisis_Un_Registro)
        Me.TabControlEX1.Controls.Add(Me.TabPageEX_Filtrar_Señal)
        Me.TabControlEX1.FlatBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.TabControlEX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControlEX1.ItemSize = New System.Drawing.Size(95, 30)
        Me.TabControlEX1.Location = New System.Drawing.Point(0, 0)
        Me.TabControlEX1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControlEX1.Name = "TabControlEX1"
        Me.TabControlEX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabControlEX1.SelectedIndex = 1
        Me.TabControlEX1.Size = New System.Drawing.Size(1678, 907)
        Me.TabControlEX1.TabIndex = 16
        Me.TabControlEX1.UseVisualStyles = False
        '
        'TabPageEX_Configuracion_Análisis
        '
        Me.TabPageEX_Configuracion_Análisis.AutoScroll = True
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.Label25)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.ComboBox_PorCiento_Rechazo_Extremos)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.Button_Resetear_Parametros)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.Label15)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.ComboBox_PorCiento_Rechazo_Ruido_QRS)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.TextBox_Interv_Min_Entre_QRS)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.Label13)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.TextBox_Desplaz_Despues_QRS)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.Label12)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.TextBox_Duracion_Max_QRS)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.TextBox_Duracion_Min_QRS)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.Label11)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.Label10)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.Label9)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.ComboBox_Angulo_Rechazo_QRS)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.Label7)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.Label6)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.Label3)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.ComboBox_P_C_Max_PorCiento_Comp_QRS)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.CheckBox_Selec_Auto_TW_QRS)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.Label_Parametros_Deteccion_Complejo_QRS)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.Label_Fca)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.Label_Fcb)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.ComboBox_Fca_Configuracion_Deteccion_QRS)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.ComboBox_Fcb_Configuracion_Deteccion_QRS)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.CheckBox_Eliminar_Temporales_Calculados)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.CheckBox_Deteccion_Complejo_QRS_Faltantes)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.CheckBox_Corregir_Puntos_Complejo_QRS)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.ComboBox_Selec_TW_QRS)
        Me.TabPageEX_Configuracion_Análisis.Controls.Add(Me.CheckBox_Filtrar_Señal)
        Me.TabPageEX_Configuracion_Análisis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPageEX_Configuracion_Análisis.Location = New System.Drawing.Point(4, 34)
        Me.TabPageEX_Configuracion_Análisis.Margin = New System.Windows.Forms.Padding(6)
        Me.TabPageEX_Configuracion_Análisis.Name = "TabPageEX_Configuracion_Análisis"
        Me.TabPageEX_Configuracion_Análisis.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TabPageEX_Configuracion_Análisis.Size = New System.Drawing.Size(1670, 869)
        Me.TabPageEX_Configuracion_Análisis.TabIndex = 3
        Me.TabPageEX_Configuracion_Análisis.Text = "Analysis Configuration"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(81, 428)
        Me.Label25.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(522, 25)
        Me.Label25.TabIndex = 53
        Me.Label25.Text = "Rejection % of the Central point against the Extreme points "
        '
        'ComboBox_PorCiento_Rechazo_Extremos
        '
        Me.ComboBox_PorCiento_Rechazo_Extremos.AutoCompleteCustomSource.AddRange(New String() {"TW 1", "TW 2", "TW 3", "TW 4", "TW 5", "TW 6", "TW 7", "TW 8", "TW 9", "TW 10"})
        Me.ComboBox_PorCiento_Rechazo_Extremos.FormattingEnabled = True
        Me.ComboBox_PorCiento_Rechazo_Extremos.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"})
        Me.ComboBox_PorCiento_Rechazo_Extremos.Location = New System.Drawing.Point(81, 463)
        Me.ComboBox_PorCiento_Rechazo_Extremos.Margin = New System.Windows.Forms.Padding(6)
        Me.ComboBox_PorCiento_Rechazo_Extremos.Name = "ComboBox_PorCiento_Rechazo_Extremos"
        Me.ComboBox_PorCiento_Rechazo_Extremos.Size = New System.Drawing.Size(116, 32)
        Me.ComboBox_PorCiento_Rechazo_Extremos.TabIndex = 52
        Me.ComboBox_PorCiento_Rechazo_Extremos.Text = "5"
        '
        'Button_Resetear_Parametros
        '
        Me.Button_Resetear_Parametros.BackColor = System.Drawing.Color.Transparent
        Me.Button_Resetear_Parametros.BackgroundImage = CType(resources.GetObject("Button_Resetear_Parametros.BackgroundImage"), System.Drawing.Image)
        Me.Button_Resetear_Parametros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Resetear_Parametros.FlatAppearance.BorderSize = 0
        Me.Button_Resetear_Parametros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Resetear_Parametros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Resetear_Parametros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Resetear_Parametros.ForeColor = System.Drawing.Color.Black
        Me.Button_Resetear_Parametros.Location = New System.Drawing.Point(228, 690)
        Me.Button_Resetear_Parametros.Margin = New System.Windows.Forms.Padding(6)
        Me.Button_Resetear_Parametros.Name = "Button_Resetear_Parametros"
        Me.Button_Resetear_Parametros.Size = New System.Drawing.Size(167, 94)
        Me.Button_Resetear_Parametros.TabIndex = 27
        Me.Button_Resetear_Parametros.Text = "Reset Parameters"
        Me.Button_Resetear_Parametros.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(400, 166)
        Me.Label15.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(170, 25)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "% Noise Rejection"
        '
        'ComboBox_PorCiento_Rechazo_Ruido_QRS
        '
        Me.ComboBox_PorCiento_Rechazo_Ruido_QRS.AutoCompleteCustomSource.AddRange(New String() {"TW 1", "TW 2", "TW 3", "TW 4", "TW 5", "TW 6", "TW 7", "TW 8", "TW 9", "TW 10"})
        Me.ComboBox_PorCiento_Rechazo_Ruido_QRS.FormattingEnabled = True
        Me.ComboBox_PorCiento_Rechazo_Ruido_QRS.Items.AddRange(New Object() {"7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50"})
        Me.ComboBox_PorCiento_Rechazo_Ruido_QRS.Location = New System.Drawing.Point(405, 209)
        Me.ComboBox_PorCiento_Rechazo_Ruido_QRS.Margin = New System.Windows.Forms.Padding(6)
        Me.ComboBox_PorCiento_Rechazo_Ruido_QRS.Name = "ComboBox_PorCiento_Rechazo_Ruido_QRS"
        Me.ComboBox_PorCiento_Rechazo_Ruido_QRS.Size = New System.Drawing.Size(116, 32)
        Me.ComboBox_PorCiento_Rechazo_Ruido_QRS.TabIndex = 30
        Me.ComboBox_PorCiento_Rechazo_Ruido_QRS.Text = "0"
        '
        'TextBox_Interv_Min_Entre_QRS
        '
        Me.TextBox_Interv_Min_Entre_QRS.Location = New System.Drawing.Point(405, 631)
        Me.TextBox_Interv_Min_Entre_QRS.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Interv_Min_Entre_QRS.Name = "TextBox_Interv_Min_Entre_QRS"
        Me.TextBox_Interv_Min_Entre_QRS.Size = New System.Drawing.Size(142, 29)
        Me.TextBox_Interv_Min_Entre_QRS.TabIndex = 24
        Me.TextBox_Interv_Min_Entre_QRS.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(405, 596)
        Me.Label13.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(302, 25)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Min. Interval Between 2 QRS(ms)"
        '
        'TextBox_Desplaz_Despues_QRS
        '
        Me.TextBox_Desplaz_Despues_QRS.Location = New System.Drawing.Point(81, 631)
        Me.TextBox_Desplaz_Despues_QRS.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Desplaz_Despues_QRS.Name = "TextBox_Desplaz_Despues_QRS"
        Me.TextBox_Desplaz_Despues_QRS.Size = New System.Drawing.Size(142, 29)
        Me.TextBox_Desplaz_Despues_QRS.TabIndex = 22
        Me.TextBox_Desplaz_Despues_QRS.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(81, 596)
        Me.Label12.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(302, 25)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Displacement After one QRS(ms)"
        '
        'TextBox_Duracion_Max_QRS
        '
        Me.TextBox_Duracion_Max_QRS.Location = New System.Drawing.Point(405, 548)
        Me.TextBox_Duracion_Max_QRS.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Duracion_Max_QRS.Name = "TextBox_Duracion_Max_QRS"
        Me.TextBox_Duracion_Max_QRS.Size = New System.Drawing.Size(142, 29)
        Me.TextBox_Duracion_Max_QRS.TabIndex = 20
        Me.TextBox_Duracion_Max_QRS.Text = "0"
        '
        'TextBox_Duracion_Min_QRS
        '
        Me.TextBox_Duracion_Min_QRS.Location = New System.Drawing.Point(81, 548)
        Me.TextBox_Duracion_Min_QRS.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Duracion_Min_QRS.Name = "TextBox_Duracion_Min_QRS"
        Me.TextBox_Duracion_Min_QRS.Size = New System.Drawing.Size(142, 29)
        Me.TextBox_Duracion_Min_QRS.TabIndex = 20
        Me.TextBox_Duracion_Min_QRS.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(405, 513)
        Me.Label11.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(213, 25)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Max QRS duration(ms)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(81, 513)
        Me.Label10.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(215, 25)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Min QRS Duration (ms)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(81, 343)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(148, 25)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Rejection Angle"
        '
        'ComboBox_Angulo_Rechazo_QRS
        '
        Me.ComboBox_Angulo_Rechazo_QRS.AutoCompleteCustomSource.AddRange(New String() {"TW 1", "TW 2", "TW 3", "TW 4", "TW 5", "TW 6", "TW 7", "TW 8", "TW 9", "TW 10"})
        Me.ComboBox_Angulo_Rechazo_QRS.FormattingEnabled = True
        Me.ComboBox_Angulo_Rechazo_QRS.Items.AddRange(New Object() {"10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90"})
        Me.ComboBox_Angulo_Rechazo_QRS.Location = New System.Drawing.Point(81, 378)
        Me.ComboBox_Angulo_Rechazo_QRS.Margin = New System.Windows.Forms.Padding(6)
        Me.ComboBox_Angulo_Rechazo_QRS.Name = "ComboBox_Angulo_Rechazo_QRS"
        Me.ComboBox_Angulo_Rechazo_QRS.Size = New System.Drawing.Size(116, 32)
        Me.ComboBox_Angulo_Rechazo_QRS.TabIndex = 18
        Me.ComboBox_Angulo_Rechazo_QRS.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(405, 343)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(425, 25)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "% Advance Before crossing by 0 at the Extreme"
        '
        'ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS
        '
        Me.ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS.AutoCompleteCustomSource.AddRange(New String() {"TW 1", "TW 2", "TW 3", "TW 4", "TW 5", "TW 6", "TW 7", "TW 8", "TW 9", "TW 10"})
        Me.ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS.FormattingEnabled = True
        Me.ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS.Items.AddRange(New Object() {"10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90"})
        Me.ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS.Location = New System.Drawing.Point(405, 378)
        Me.ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS.Margin = New System.Windows.Forms.Padding(6)
        Me.ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS.Name = "ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS"
        Me.ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS.Size = New System.Drawing.Size(116, 32)
        Me.ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS.TabIndex = 16
        Me.ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(402, 258)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(421, 25)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "% Progress Before crossing by 0 in the Center  "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(77, 258)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(198, 25)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "P_C_Max_%_Comp."
        '
        'ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS
        '
        Me.ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS.AutoCompleteCustomSource.AddRange(New String() {"TW 1", "TW 2", "TW 3", "TW 4", "TW 5", "TW 6", "TW 7", "TW 8", "TW 9", "TW 10"})
        Me.ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS.FormattingEnabled = True
        Me.ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS.Items.AddRange(New Object() {"10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90"})
        Me.ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS.Location = New System.Drawing.Point(405, 294)
        Me.ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS.Margin = New System.Windows.Forms.Padding(6)
        Me.ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS.Name = "ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS"
        Me.ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS.Size = New System.Drawing.Size(116, 32)
        Me.ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS.TabIndex = 14
        Me.ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS.Text = "0"
        '
        'ComboBox_P_C_Max_PorCiento_Comp_QRS
        '
        Me.ComboBox_P_C_Max_PorCiento_Comp_QRS.AutoCompleteCustomSource.AddRange(New String() {"TW 1", "TW 2", "TW 3", "TW 4", "TW 5", "TW 6", "TW 7", "TW 8", "TW 9", "TW 10"})
        Me.ComboBox_P_C_Max_PorCiento_Comp_QRS.FormattingEnabled = True
        Me.ComboBox_P_C_Max_PorCiento_Comp_QRS.Items.AddRange(New Object() {"10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90"})
        Me.ComboBox_P_C_Max_PorCiento_Comp_QRS.Location = New System.Drawing.Point(81, 294)
        Me.ComboBox_P_C_Max_PorCiento_Comp_QRS.Margin = New System.Windows.Forms.Padding(6)
        Me.ComboBox_P_C_Max_PorCiento_Comp_QRS.Name = "ComboBox_P_C_Max_PorCiento_Comp_QRS"
        Me.ComboBox_P_C_Max_PorCiento_Comp_QRS.Size = New System.Drawing.Size(116, 32)
        Me.ComboBox_P_C_Max_PorCiento_Comp_QRS.TabIndex = 14
        Me.ComboBox_P_C_Max_PorCiento_Comp_QRS.Text = "0"
        '
        'CheckBox_Selec_Auto_TW_QRS
        '
        Me.CheckBox_Selec_Auto_TW_QRS.AutoSize = True
        Me.CheckBox_Selec_Auto_TW_QRS.Checked = True
        Me.CheckBox_Selec_Auto_TW_QRS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Selec_Auto_TW_QRS.Location = New System.Drawing.Point(81, 166)
        Me.CheckBox_Selec_Auto_TW_QRS.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_Selec_Auto_TW_QRS.Name = "CheckBox_Selec_Auto_TW_QRS"
        Me.CheckBox_Selec_Auto_TW_QRS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_Selec_Auto_TW_QRS.Size = New System.Drawing.Size(249, 29)
        Me.CheckBox_Selec_Auto_TW_QRS.TabIndex = 13
        Me.CheckBox_Selec_Auto_TW_QRS.Text = "Automatic TW Selection"
        Me.CheckBox_Selec_Auto_TW_QRS.UseVisualStyleBackColor = True
        '
        'Label_Parametros_Deteccion_Complejo_QRS
        '
        Me.Label_Parametros_Deteccion_Complejo_QRS.AutoSize = True
        Me.Label_Parametros_Deteccion_Complejo_QRS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Parametros_Deteccion_Complejo_QRS.Location = New System.Drawing.Point(57, 135)
        Me.Label_Parametros_Deteccion_Complejo_QRS.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Parametros_Deteccion_Complejo_QRS.Name = "Label_Parametros_Deteccion_Complejo_QRS"
        Me.Label_Parametros_Deteccion_Complejo_QRS.Size = New System.Drawing.Size(405, 29)
        Me.Label_Parametros_Deteccion_Complejo_QRS.TabIndex = 12
        Me.Label_Parametros_Deteccion_Complejo_QRS.Text = "QRS Complex Detection Parameters"
        '
        'Label_Fca
        '
        Me.Label_Fca.AutoSize = True
        Me.Label_Fca.Location = New System.Drawing.Point(209, 55)
        Me.Label_Fca.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Fca.Name = "Label_Fca"
        Me.Label_Fca.Size = New System.Drawing.Size(76, 25)
        Me.Label_Fca.TabIndex = 11
        Me.Label_Fca.Text = "fca(Hz)"
        '
        'Label_Fcb
        '
        Me.Label_Fcb.AutoSize = True
        Me.Label_Fcb.Location = New System.Drawing.Point(99, 55)
        Me.Label_Fcb.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Fcb.Name = "Label_Fcb"
        Me.Label_Fcb.Size = New System.Drawing.Size(76, 25)
        Me.Label_Fcb.TabIndex = 11
        Me.Label_Fcb.Text = "fcb(Hz)"
        '
        'ComboBox_Fca_Configuracion_Deteccion_QRS
        '
        Me.ComboBox_Fca_Configuracion_Deteccion_QRS.AutoCompleteCustomSource.AddRange(New String() {"21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "", "", "", "", "", ""})
        Me.ComboBox_Fca_Configuracion_Deteccion_QRS.FormattingEnabled = True
        Me.ComboBox_Fca_Configuracion_Deteccion_QRS.Items.AddRange(New Object() {"25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
        Me.ComboBox_Fca_Configuracion_Deteccion_QRS.Location = New System.Drawing.Point(244, 94)
        Me.ComboBox_Fca_Configuracion_Deteccion_QRS.Margin = New System.Windows.Forms.Padding(6)
        Me.ComboBox_Fca_Configuracion_Deteccion_QRS.Name = "ComboBox_Fca_Configuracion_Deteccion_QRS"
        Me.ComboBox_Fca_Configuracion_Deteccion_QRS.Size = New System.Drawing.Size(83, 32)
        Me.ComboBox_Fca_Configuracion_Deteccion_QRS.TabIndex = 10
        Me.ComboBox_Fca_Configuracion_Deteccion_QRS.Text = "40"
        '
        'ComboBox_Fcb_Configuracion_Deteccion_QRS
        '
        Me.ComboBox_Fcb_Configuracion_Deteccion_QRS.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"})
        Me.ComboBox_Fcb_Configuracion_Deteccion_QRS.FormattingEnabled = True
        Me.ComboBox_Fcb_Configuracion_Deteccion_QRS.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"})
        Me.ComboBox_Fcb_Configuracion_Deteccion_QRS.Location = New System.Drawing.Point(108, 94)
        Me.ComboBox_Fcb_Configuracion_Deteccion_QRS.Margin = New System.Windows.Forms.Padding(6)
        Me.ComboBox_Fcb_Configuracion_Deteccion_QRS.Name = "ComboBox_Fcb_Configuracion_Deteccion_QRS"
        Me.ComboBox_Fcb_Configuracion_Deteccion_QRS.Size = New System.Drawing.Size(83, 32)
        Me.ComboBox_Fcb_Configuracion_Deteccion_QRS.TabIndex = 9
        Me.ComboBox_Fcb_Configuracion_Deteccion_QRS.Tag = ""
        Me.ComboBox_Fcb_Configuracion_Deteccion_QRS.Text = "1"
        '
        'CheckBox_Eliminar_Temporales_Calculados
        '
        Me.CheckBox_Eliminar_Temporales_Calculados.AutoSize = True
        Me.CheckBox_Eliminar_Temporales_Calculados.Checked = True
        Me.CheckBox_Eliminar_Temporales_Calculados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Eliminar_Temporales_Calculados.Location = New System.Drawing.Point(405, 96)
        Me.CheckBox_Eliminar_Temporales_Calculados.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_Eliminar_Temporales_Calculados.Name = "CheckBox_Eliminar_Temporales_Calculados"
        Me.CheckBox_Eliminar_Temporales_Calculados.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_Eliminar_Temporales_Calculados.Size = New System.Drawing.Size(292, 29)
        Me.CheckBox_Eliminar_Temporales_Calculados.TabIndex = 8
        Me.CheckBox_Eliminar_Temporales_Calculados.Text = "Delete Calculated Temporary"
        Me.CheckBox_Eliminar_Temporales_Calculados.UseVisualStyleBackColor = True
        '
        'CheckBox_Deteccion_Complejo_QRS_Faltantes
        '
        Me.CheckBox_Deteccion_Complejo_QRS_Faltantes.AutoSize = True
        Me.CheckBox_Deteccion_Complejo_QRS_Faltantes.Checked = True
        Me.CheckBox_Deteccion_Complejo_QRS_Faltantes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Deteccion_Complejo_QRS_Faltantes.Location = New System.Drawing.Point(405, 33)
        Me.CheckBox_Deteccion_Complejo_QRS_Faltantes.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_Deteccion_Complejo_QRS_Faltantes.Name = "CheckBox_Deteccion_Complejo_QRS_Faltantes"
        Me.CheckBox_Deteccion_Complejo_QRS_Faltantes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_Deteccion_Complejo_QRS_Faltantes.Size = New System.Drawing.Size(323, 29)
        Me.CheckBox_Deteccion_Complejo_QRS_Faltantes.TabIndex = 8
        Me.CheckBox_Deteccion_Complejo_QRS_Faltantes.Text = "Missing QRS Complex Detection"
        Me.CheckBox_Deteccion_Complejo_QRS_Faltantes.UseVisualStyleBackColor = True
        '
        'CheckBox_Corregir_Puntos_Complejo_QRS
        '
        Me.CheckBox_Corregir_Puntos_Complejo_QRS.AutoSize = True
        Me.CheckBox_Corregir_Puntos_Complejo_QRS.Checked = True
        Me.CheckBox_Corregir_Puntos_Complejo_QRS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Corregir_Puntos_Complejo_QRS.Location = New System.Drawing.Point(405, 65)
        Me.CheckBox_Corregir_Puntos_Complejo_QRS.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_Corregir_Puntos_Complejo_QRS.Name = "CheckBox_Corregir_Puntos_Complejo_QRS"
        Me.CheckBox_Corregir_Puntos_Complejo_QRS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_Corregir_Puntos_Complejo_QRS.Size = New System.Drawing.Size(318, 29)
        Me.CheckBox_Corregir_Puntos_Complejo_QRS.TabIndex = 8
        Me.CheckBox_Corregir_Puntos_Complejo_QRS.Text = "Correcting QRS Complex Points"
        Me.CheckBox_Corregir_Puntos_Complejo_QRS.UseVisualStyleBackColor = True
        '
        'ComboBox_Selec_TW_QRS
        '
        Me.ComboBox_Selec_TW_QRS.AutoCompleteCustomSource.AddRange(New String() {"TW 1", "TW 2", "TW 3", "TW 4", "TW 5", "TW 6", "TW 7", "TW 8", "TW 9", "TW 10"})
        Me.ComboBox_Selec_TW_QRS.FormattingEnabled = True
        Me.ComboBox_Selec_TW_QRS.Items.AddRange(New Object() {"TW 1", "TW 2", "TW 3", "TW 4", "TW 5", "TW 6", "TW 7", "TW 8", "TW 9", "TW 10"})
        Me.ComboBox_Selec_TW_QRS.Location = New System.Drawing.Point(81, 209)
        Me.ComboBox_Selec_TW_QRS.Margin = New System.Windows.Forms.Padding(6)
        Me.ComboBox_Selec_TW_QRS.Name = "ComboBox_Selec_TW_QRS"
        Me.ComboBox_Selec_TW_QRS.Size = New System.Drawing.Size(116, 32)
        Me.ComboBox_Selec_TW_QRS.TabIndex = 6
        Me.ComboBox_Selec_TW_QRS.Text = "TW 10"
        '
        'CheckBox_Filtrar_Señal
        '
        Me.CheckBox_Filtrar_Señal.AutoSize = True
        Me.CheckBox_Filtrar_Señal.Checked = True
        Me.CheckBox_Filtrar_Señal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Filtrar_Señal.Location = New System.Drawing.Point(48, 28)
        Me.CheckBox_Filtrar_Señal.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_Filtrar_Señal.Name = "CheckBox_Filtrar_Señal"
        Me.CheckBox_Filtrar_Señal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_Filtrar_Señal.Size = New System.Drawing.Size(293, 29)
        Me.CheckBox_Filtrar_Señal.TabIndex = 5
        Me.CheckBox_Filtrar_Señal.Text = "Filter Signal Before Analyzing"
        Me.CheckBox_Filtrar_Señal.UseVisualStyleBackColor = True
        '
        'TabPageEX_Análisis_Un_Registro
        '
        Me.TabPageEX_Análisis_Un_Registro.Controls.Add(Me.Label_Registro_Analizado_Multi_Registro)
        Me.TabPageEX_Análisis_Un_Registro.Controls.Add(Me.TreeView_Elementos_Calcular)
        Me.TabPageEX_Análisis_Un_Registro.Controls.Add(Me.Label_Progreso)
        Me.TabPageEX_Análisis_Un_Registro.Controls.Add(Me.CheckedListBox_Registros_Analizar_Multi_Registro)
        Me.TabPageEX_Análisis_Un_Registro.Controls.Add(Me.Button_Eliminar_Registro_Multi_Registro)
        Me.TabPageEX_Análisis_Un_Registro.Controls.Add(Me.CheckBox_Recalcular_Resultados)
        Me.TabPageEX_Análisis_Un_Registro.Controls.Add(Me.Button_Analizar_Registro)
        Me.TabPageEX_Análisis_Un_Registro.Controls.Add(Me.ProgressBar_Progreso_Analisis)
        Me.TabPageEX_Análisis_Un_Registro.Controls.Add(Me.Label2)
        Me.TabPageEX_Análisis_Un_Registro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPageEX_Análisis_Un_Registro.Location = New System.Drawing.Point(4, 34)
        Me.TabPageEX_Análisis_Un_Registro.Margin = New System.Windows.Forms.Padding(6)
        Me.TabPageEX_Análisis_Un_Registro.Name = "TabPageEX_Análisis_Un_Registro"
        Me.TabPageEX_Análisis_Un_Registro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TabPageEX_Análisis_Un_Registro.Size = New System.Drawing.Size(1670, 869)
        Me.TabPageEX_Análisis_Un_Registro.TabIndex = 0
        Me.TabPageEX_Análisis_Un_Registro.Text = "Record Analysis"
        '
        'Label_Registro_Analizado_Multi_Registro
        '
        Me.Label_Registro_Analizado_Multi_Registro.AutoSize = True
        Me.Label_Registro_Analizado_Multi_Registro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Registro_Analizado_Multi_Registro.Location = New System.Drawing.Point(29, 353)
        Me.Label_Registro_Analizado_Multi_Registro.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Registro_Analizado_Multi_Registro.Name = "Label_Registro_Analizado_Multi_Registro"
        Me.Label_Registro_Analizado_Multi_Registro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label_Registro_Analizado_Multi_Registro.Size = New System.Drawing.Size(74, 25)
        Me.Label_Registro_Analizado_Multi_Registro.TabIndex = 32
        Me.Label_Registro_Analizado_Multi_Registro.Text = "Record"
        '
        'TreeView_Elementos_Calcular
        '
        Me.TreeView_Elementos_Calcular.AllowDrop = True
        Me.TreeView_Elementos_Calcular.CheckBoxes = True
        Me.TreeView_Elementos_Calcular.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView_Elementos_Calcular.FullRowSelect = True
        Me.TreeView_Elementos_Calcular.Location = New System.Drawing.Point(29, 28)
        Me.TreeView_Elementos_Calcular.Margin = New System.Windows.Forms.Padding(4)
        Me.TreeView_Elementos_Calcular.Name = "TreeView_Elementos_Calcular"
        TreeNode9.ImageKey = "Bullet-Blue.png"
        TreeNode9.Name = "QRS"
        TreeNode9.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode9.SelectedImageKey = "Bullet-Blue.png"
        TreeNode9.Text = "QRS"
        TreeNode10.ImageKey = "Aol-Mail.png"
        TreeNode10.Name = "Ondas"
        TreeNode10.SelectedImageKey = "Aol-Mail.png"
        TreeNode10.Text = "Waves"
        TreeNode11.ImageKey = "Bullet-Yellow.png"
        TreeNode11.Name = "R-R"
        TreeNode11.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode11.SelectedImageKey = "Bullet-Yellow.png"
        TreeNode11.Text = "R-R"
        TreeNode12.ImageKey = "Aol-Mail.png"
        TreeNode12.Name = "Intervalos"
        TreeNode12.SelectedImageKey = "Aol-Mail.png"
        TreeNode12.Text = "Intervals"
        Me.TreeView_Elementos_Calcular.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode10, TreeNode12})
        Me.TreeView_Elementos_Calcular.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TreeView_Elementos_Calcular.Size = New System.Drawing.Size(545, 309)
        Me.TreeView_Elementos_Calcular.TabIndex = 17
        '
        'Label_Progreso
        '
        Me.Label_Progreso.AutoSize = True
        Me.Label_Progreso.Location = New System.Drawing.Point(28, 378)
        Me.Label_Progreso.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Progreso.Name = "Label_Progreso"
        Me.Label_Progreso.Size = New System.Drawing.Size(90, 25)
        Me.Label_Progreso.TabIndex = 16
        Me.Label_Progreso.Text = "Progress"
        '
        'CheckedListBox_Registros_Analizar_Multi_Registro
        '
        Me.CheckedListBox_Registros_Analizar_Multi_Registro.CheckOnClick = True
        Me.CheckedListBox_Registros_Analizar_Multi_Registro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBox_Registros_Analizar_Multi_Registro.FormattingEnabled = True
        Me.CheckedListBox_Registros_Analizar_Multi_Registro.HorizontalScrollbar = True
        Me.CheckedListBox_Registros_Analizar_Multi_Registro.Location = New System.Drawing.Point(609, 28)
        Me.CheckedListBox_Registros_Analizar_Multi_Registro.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckedListBox_Registros_Analizar_Multi_Registro.Name = "CheckedListBox_Registros_Analizar_Multi_Registro"
        Me.CheckedListBox_Registros_Analizar_Multi_Registro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckedListBox_Registros_Analizar_Multi_Registro.Size = New System.Drawing.Size(437, 238)
        Me.CheckedListBox_Registros_Analizar_Multi_Registro.TabIndex = 30
        Me.CheckedListBox_Registros_Analizar_Multi_Registro.ThreeDCheckBoxes = True
        Me.CheckedListBox_Registros_Analizar_Multi_Registro.Visible = False
        '
        'Button_Eliminar_Registro_Multi_Registro
        '
        Me.Button_Eliminar_Registro_Multi_Registro.BackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Registro_Multi_Registro.BackgroundImage = CType(resources.GetObject("Button_Eliminar_Registro_Multi_Registro.BackgroundImage"), System.Drawing.Image)
        Me.Button_Eliminar_Registro_Multi_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Eliminar_Registro_Multi_Registro.FlatAppearance.BorderSize = 0
        Me.Button_Eliminar_Registro_Multi_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Registro_Multi_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Registro_Multi_Registro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Eliminar_Registro_Multi_Registro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Eliminar_Registro_Multi_Registro.ForeColor = System.Drawing.Color.Black
        Me.Button_Eliminar_Registro_Multi_Registro.Location = New System.Drawing.Point(612, 449)
        Me.Button_Eliminar_Registro_Multi_Registro.Margin = New System.Windows.Forms.Padding(6)
        Me.Button_Eliminar_Registro_Multi_Registro.Name = "Button_Eliminar_Registro_Multi_Registro"
        Me.Button_Eliminar_Registro_Multi_Registro.Size = New System.Drawing.Size(143, 81)
        Me.Button_Eliminar_Registro_Multi_Registro.TabIndex = 16
        Me.Button_Eliminar_Registro_Multi_Registro.Text = "Delete Record"
        Me.Button_Eliminar_Registro_Multi_Registro.UseVisualStyleBackColor = False
        Me.Button_Eliminar_Registro_Multi_Registro.Visible = False
        '
        'CheckBox_Recalcular_Resultados
        '
        Me.CheckBox_Recalcular_Resultados.AutoSize = True
        Me.CheckBox_Recalcular_Resultados.Checked = True
        Me.CheckBox_Recalcular_Resultados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Recalcular_Resultados.Location = New System.Drawing.Point(61, 449)
        Me.CheckBox_Recalcular_Resultados.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_Recalcular_Resultados.Name = "CheckBox_Recalcular_Resultados"
        Me.CheckBox_Recalcular_Resultados.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_Recalcular_Resultados.Size = New System.Drawing.Size(208, 29)
        Me.CheckBox_Recalcular_Resultados.TabIndex = 15
        Me.CheckBox_Recalcular_Resultados.Text = "Recalculate Results"
        Me.CheckBox_Recalcular_Resultados.UseVisualStyleBackColor = True
        '
        'Button_Analizar_Registro
        '
        Me.Button_Analizar_Registro.BackColor = System.Drawing.Color.Transparent
        Me.Button_Analizar_Registro.BackgroundImage = CType(resources.GetObject("Button_Analizar_Registro.BackgroundImage"), System.Drawing.Image)
        Me.Button_Analizar_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Analizar_Registro.FlatAppearance.BorderSize = 0
        Me.Button_Analizar_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Analizar_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Analizar_Registro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Analizar_Registro.ForeColor = System.Drawing.Color.Black
        Me.Button_Analizar_Registro.Location = New System.Drawing.Point(350, 449)
        Me.Button_Analizar_Registro.Margin = New System.Windows.Forms.Padding(6)
        Me.Button_Analizar_Registro.Name = "Button_Analizar_Registro"
        Me.Button_Analizar_Registro.Size = New System.Drawing.Size(143, 81)
        Me.Button_Analizar_Registro.TabIndex = 0
        Me.Button_Analizar_Registro.Text = "Analyze"
        Me.Button_Analizar_Registro.UseVisualStyleBackColor = False
        '
        'ProgressBar_Progreso_Analisis
        '
        Me.ProgressBar_Progreso_Analisis.BackColor = System.Drawing.Color.White
        Me.ProgressBar_Progreso_Analisis.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ProgressBar_Progreso_Analisis.Location = New System.Drawing.Point(28, 408)
        Me.ProgressBar_Progreso_Analisis.Margin = New System.Windows.Forms.Padding(0)
        Me.ProgressBar_Progreso_Analisis.Name = "ProgressBar_Progreso_Analisis"
        Me.ProgressBar_Progreso_Analisis.Size = New System.Drawing.Size(550, 35)
        Me.ProgressBar_Progreso_Analisis.Step = 1
        Me.ProgressBar_Progreso_Analisis.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar_Progreso_Analisis.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(242, 25)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Parameters to Calculate"
        '
        'TabPageEX_Filtrar_Señal
        '
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_fcb_005_Hz)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_fcb_05_Hz)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.ComboBox_fcb)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.ComboBox_fca)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.Label_Filtro_Notch)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.Label5)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.Label4)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_Filtro_Pasa_Banda)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_Filtro_Para_Banda)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_fca_200_Hz)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_fca_150_Hz)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_fca_100_Hz)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_fcb_10_Hz)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_fca_50_Hz)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_fcb_5_Hz)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_Notch_60_Hz)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_Notch_50_Hz)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_Notch_Ninguna)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_fca_Ninguna)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_fcb_1_Hz)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_fcb_Ninguna)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_Reescribir_Registro)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.CheckBox_Filtro_Personalizado)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.Label_Progreso_Filtro)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.Button_Filtrar_Registro)
        Me.TabPageEX_Filtrar_Señal.Controls.Add(Me.ProgressBar_Filtrar_Registro)
        Me.TabPageEX_Filtrar_Señal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPageEX_Filtrar_Señal.Location = New System.Drawing.Point(4, 34)
        Me.TabPageEX_Filtrar_Señal.Margin = New System.Windows.Forms.Padding(6)
        Me.TabPageEX_Filtrar_Señal.Name = "TabPageEX_Filtrar_Señal"
        Me.TabPageEX_Filtrar_Señal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TabPageEX_Filtrar_Señal.Size = New System.Drawing.Size(1670, 869)
        Me.TabPageEX_Filtrar_Señal.TabIndex = 2
        Me.TabPageEX_Filtrar_Señal.Text = "Filter Signal"
        '
        'CheckBox_fcb_005_Hz
        '
        Me.CheckBox_fcb_005_Hz.AutoSize = True
        Me.CheckBox_fcb_005_Hz.Enabled = False
        Me.CheckBox_fcb_005_Hz.Location = New System.Drawing.Point(26, 102)
        Me.CheckBox_fcb_005_Hz.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_fcb_005_Hz.Name = "CheckBox_fcb_005_Hz"
        Me.CheckBox_fcb_005_Hz.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_fcb_005_Hz.Size = New System.Drawing.Size(105, 29)
        Me.CheckBox_fcb_005_Hz.TabIndex = 34
        Me.CheckBox_fcb_005_Hz.Text = "0.05 Hz"
        Me.CheckBox_fcb_005_Hz.UseVisualStyleBackColor = True
        '
        'CheckBox_fcb_05_Hz
        '
        Me.CheckBox_fcb_05_Hz.AutoSize = True
        Me.CheckBox_fcb_05_Hz.Enabled = False
        Me.CheckBox_fcb_05_Hz.Location = New System.Drawing.Point(28, 135)
        Me.CheckBox_fcb_05_Hz.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_fcb_05_Hz.Name = "CheckBox_fcb_05_Hz"
        Me.CheckBox_fcb_05_Hz.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_fcb_05_Hz.Size = New System.Drawing.Size(94, 29)
        Me.CheckBox_fcb_05_Hz.TabIndex = 33
        Me.CheckBox_fcb_05_Hz.Text = "0.5 Hz"
        Me.CheckBox_fcb_05_Hz.UseVisualStyleBackColor = True
        '
        'ComboBox_fcb
        '
        Me.ComboBox_fcb.FormattingEnabled = True
        Me.ComboBox_fcb.Items.AddRange(New Object() {"1 Hz", "2 Hz", "3 Hz", "4 Hz", "5 Hz", "6 Hz", "7 Hz", "8 Hz", "9 Hz", "10 Hz", "11 Hz", "12 Hz", "13 Hz", "14 Hz", "15 Hz", "16 Hz", "17 Hz", "18 Hz", "19 Hz", "20 Hz", "21 Hz", "22 Hz", "23 Hz", "24 Hz", "25 Hz", "26 Hz", "27 Hz", "28 Hz", "29 Hz", "30 Hz"})
        Me.ComboBox_fcb.Location = New System.Drawing.Point(552, 74)
        Me.ComboBox_fcb.Margin = New System.Windows.Forms.Padding(6)
        Me.ComboBox_fcb.Name = "ComboBox_fcb"
        Me.ComboBox_fcb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ComboBox_fcb.Size = New System.Drawing.Size(109, 32)
        Me.ComboBox_fcb.TabIndex = 32
        Me.ComboBox_fcb.Visible = False
        '
        'ComboBox_fca
        '
        Me.ComboBox_fca.FormattingEnabled = True
        Me.ComboBox_fca.Items.AddRange(New Object() {"40 Hz", "50 Hz", "60 Hz", "70 Hz", "80 Hz", "90 Hz", "100 Hz"})
        Me.ComboBox_fca.Location = New System.Drawing.Point(686, 74)
        Me.ComboBox_fca.Margin = New System.Windows.Forms.Padding(6)
        Me.ComboBox_fca.Name = "ComboBox_fca"
        Me.ComboBox_fca.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ComboBox_fca.Size = New System.Drawing.Size(109, 32)
        Me.ComboBox_fca.TabIndex = 32
        Me.ComboBox_fca.Visible = False
        '
        'Label_Filtro_Notch
        '
        Me.Label_Filtro_Notch.AutoSize = True
        Me.Label_Filtro_Notch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Filtro_Notch.Location = New System.Drawing.Point(24, 281)
        Me.Label_Filtro_Notch.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Filtro_Notch.Name = "Label_Filtro_Notch"
        Me.Label_Filtro_Notch.Size = New System.Drawing.Size(122, 25)
        Me.Label_Filtro_Notch.TabIndex = 31
        Me.Label_Filtro_Notch.Text = "Filtro Notch"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(297, 42)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(223, 25)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "High cut-off frequency"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 42)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(229, 25)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Low Cut-off Frequency"
        '
        'CheckBox_Filtro_Pasa_Banda
        '
        Me.CheckBox_Filtro_Pasa_Banda.AutoSize = True
        Me.CheckBox_Filtro_Pasa_Banda.Checked = True
        Me.CheckBox_Filtro_Pasa_Banda.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Filtro_Pasa_Banda.Location = New System.Drawing.Point(554, 137)
        Me.CheckBox_Filtro_Pasa_Banda.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_Filtro_Pasa_Banda.Name = "CheckBox_Filtro_Pasa_Banda"
        Me.CheckBox_Filtro_Pasa_Banda.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_Filtro_Pasa_Banda.Size = New System.Drawing.Size(180, 29)
        Me.CheckBox_Filtro_Pasa_Banda.TabIndex = 29
        Me.CheckBox_Filtro_Pasa_Banda.Text = "Band Pass Filter"
        Me.CheckBox_Filtro_Pasa_Banda.UseVisualStyleBackColor = True
        Me.CheckBox_Filtro_Pasa_Banda.Visible = False
        '
        'CheckBox_Filtro_Para_Banda
        '
        Me.CheckBox_Filtro_Para_Banda.AutoSize = True
        Me.CheckBox_Filtro_Para_Banda.Location = New System.Drawing.Point(552, 170)
        Me.CheckBox_Filtro_Para_Banda.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_Filtro_Para_Banda.Name = "CheckBox_Filtro_Para_Banda"
        Me.CheckBox_Filtro_Para_Banda.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_Filtro_Para_Banda.Size = New System.Drawing.Size(177, 29)
        Me.CheckBox_Filtro_Para_Banda.TabIndex = 29
        Me.CheckBox_Filtro_Para_Banda.Text = "Band Stop Filter"
        Me.CheckBox_Filtro_Para_Banda.UseVisualStyleBackColor = True
        Me.CheckBox_Filtro_Para_Banda.Visible = False
        '
        'CheckBox_fca_200_Hz
        '
        Me.CheckBox_fca_200_Hz.AutoSize = True
        Me.CheckBox_fca_200_Hz.Location = New System.Drawing.Point(308, 201)
        Me.CheckBox_fca_200_Hz.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_fca_200_Hz.Name = "CheckBox_fca_200_Hz"
        Me.CheckBox_fca_200_Hz.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_fca_200_Hz.Size = New System.Drawing.Size(100, 29)
        Me.CheckBox_fca_200_Hz.TabIndex = 29
        Me.CheckBox_fca_200_Hz.Text = "200 Hz"
        Me.CheckBox_fca_200_Hz.UseVisualStyleBackColor = True
        '
        'CheckBox_fca_150_Hz
        '
        Me.CheckBox_fca_150_Hz.AutoSize = True
        Me.CheckBox_fca_150_Hz.Location = New System.Drawing.Point(308, 170)
        Me.CheckBox_fca_150_Hz.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_fca_150_Hz.Name = "CheckBox_fca_150_Hz"
        Me.CheckBox_fca_150_Hz.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_fca_150_Hz.Size = New System.Drawing.Size(100, 29)
        Me.CheckBox_fca_150_Hz.TabIndex = 29
        Me.CheckBox_fca_150_Hz.Text = "150 Hz"
        Me.CheckBox_fca_150_Hz.UseVisualStyleBackColor = True
        '
        'CheckBox_fca_100_Hz
        '
        Me.CheckBox_fca_100_Hz.AutoSize = True
        Me.CheckBox_fca_100_Hz.Location = New System.Drawing.Point(308, 137)
        Me.CheckBox_fca_100_Hz.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_fca_100_Hz.Name = "CheckBox_fca_100_Hz"
        Me.CheckBox_fca_100_Hz.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_fca_100_Hz.Size = New System.Drawing.Size(100, 29)
        Me.CheckBox_fca_100_Hz.TabIndex = 29
        Me.CheckBox_fca_100_Hz.Text = "100 Hz"
        Me.CheckBox_fca_100_Hz.UseVisualStyleBackColor = True
        '
        'CheckBox_fcb_10_Hz
        '
        Me.CheckBox_fcb_10_Hz.AutoSize = True
        Me.CheckBox_fcb_10_Hz.Location = New System.Drawing.Point(28, 234)
        Me.CheckBox_fcb_10_Hz.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_fcb_10_Hz.Name = "CheckBox_fcb_10_Hz"
        Me.CheckBox_fcb_10_Hz.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_fcb_10_Hz.Size = New System.Drawing.Size(89, 29)
        Me.CheckBox_fcb_10_Hz.TabIndex = 29
        Me.CheckBox_fcb_10_Hz.Text = "10 Hz"
        Me.CheckBox_fcb_10_Hz.UseVisualStyleBackColor = True
        '
        'CheckBox_fca_50_Hz
        '
        Me.CheckBox_fca_50_Hz.AutoSize = True
        Me.CheckBox_fca_50_Hz.Location = New System.Drawing.Point(308, 103)
        Me.CheckBox_fca_50_Hz.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_fca_50_Hz.Name = "CheckBox_fca_50_Hz"
        Me.CheckBox_fca_50_Hz.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_fca_50_Hz.Size = New System.Drawing.Size(89, 29)
        Me.CheckBox_fca_50_Hz.TabIndex = 29
        Me.CheckBox_fca_50_Hz.Text = "50 Hz"
        Me.CheckBox_fca_50_Hz.UseVisualStyleBackColor = True
        '
        'CheckBox_fcb_5_Hz
        '
        Me.CheckBox_fcb_5_Hz.AutoSize = True
        Me.CheckBox_fcb_5_Hz.Location = New System.Drawing.Point(28, 201)
        Me.CheckBox_fcb_5_Hz.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_fcb_5_Hz.Name = "CheckBox_fcb_5_Hz"
        Me.CheckBox_fcb_5_Hz.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_fcb_5_Hz.Size = New System.Drawing.Size(78, 29)
        Me.CheckBox_fcb_5_Hz.TabIndex = 29
        Me.CheckBox_fcb_5_Hz.Text = "5 Hz"
        Me.CheckBox_fcb_5_Hz.UseVisualStyleBackColor = True
        '
        'CheckBox_Notch_60_Hz
        '
        Me.CheckBox_Notch_60_Hz.AutoSize = True
        Me.CheckBox_Notch_60_Hz.Location = New System.Drawing.Point(288, 312)
        Me.CheckBox_Notch_60_Hz.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_Notch_60_Hz.Name = "CheckBox_Notch_60_Hz"
        Me.CheckBox_Notch_60_Hz.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_Notch_60_Hz.Size = New System.Drawing.Size(89, 29)
        Me.CheckBox_Notch_60_Hz.TabIndex = 29
        Me.CheckBox_Notch_60_Hz.Text = "60 Hz"
        Me.CheckBox_Notch_60_Hz.UseVisualStyleBackColor = True
        '
        'CheckBox_Notch_50_Hz
        '
        Me.CheckBox_Notch_50_Hz.AutoSize = True
        Me.CheckBox_Notch_50_Hz.Checked = True
        Me.CheckBox_Notch_50_Hz.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Notch_50_Hz.Location = New System.Drawing.Point(161, 312)
        Me.CheckBox_Notch_50_Hz.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_Notch_50_Hz.Name = "CheckBox_Notch_50_Hz"
        Me.CheckBox_Notch_50_Hz.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_Notch_50_Hz.Size = New System.Drawing.Size(89, 29)
        Me.CheckBox_Notch_50_Hz.TabIndex = 29
        Me.CheckBox_Notch_50_Hz.Text = "50 Hz"
        Me.CheckBox_Notch_50_Hz.UseVisualStyleBackColor = True
        '
        'CheckBox_Notch_Ninguna
        '
        Me.CheckBox_Notch_Ninguna.AutoSize = True
        Me.CheckBox_Notch_Ninguna.Location = New System.Drawing.Point(35, 312)
        Me.CheckBox_Notch_Ninguna.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_Notch_Ninguna.Name = "CheckBox_Notch_Ninguna"
        Me.CheckBox_Notch_Ninguna.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_Notch_Ninguna.Size = New System.Drawing.Size(85, 29)
        Me.CheckBox_Notch_Ninguna.TabIndex = 29
        Me.CheckBox_Notch_Ninguna.Text = "None"
        Me.CheckBox_Notch_Ninguna.UseVisualStyleBackColor = True
        '
        'CheckBox_fca_Ninguna
        '
        Me.CheckBox_fca_Ninguna.AutoSize = True
        Me.CheckBox_fca_Ninguna.Checked = True
        Me.CheckBox_fca_Ninguna.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_fca_Ninguna.Location = New System.Drawing.Point(308, 70)
        Me.CheckBox_fca_Ninguna.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_fca_Ninguna.Name = "CheckBox_fca_Ninguna"
        Me.CheckBox_fca_Ninguna.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_fca_Ninguna.Size = New System.Drawing.Size(85, 29)
        Me.CheckBox_fca_Ninguna.TabIndex = 29
        Me.CheckBox_fca_Ninguna.Text = "None"
        Me.CheckBox_fca_Ninguna.UseVisualStyleBackColor = True
        '
        'CheckBox_fcb_1_Hz
        '
        Me.CheckBox_fcb_1_Hz.AutoSize = True
        Me.CheckBox_fcb_1_Hz.Location = New System.Drawing.Point(28, 168)
        Me.CheckBox_fcb_1_Hz.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_fcb_1_Hz.Name = "CheckBox_fcb_1_Hz"
        Me.CheckBox_fcb_1_Hz.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_fcb_1_Hz.Size = New System.Drawing.Size(78, 29)
        Me.CheckBox_fcb_1_Hz.TabIndex = 29
        Me.CheckBox_fcb_1_Hz.Text = "1 Hz"
        Me.CheckBox_fcb_1_Hz.UseVisualStyleBackColor = True
        '
        'CheckBox_fcb_Ninguna
        '
        Me.CheckBox_fcb_Ninguna.AutoSize = True
        Me.CheckBox_fcb_Ninguna.Checked = True
        Me.CheckBox_fcb_Ninguna.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_fcb_Ninguna.Location = New System.Drawing.Point(26, 70)
        Me.CheckBox_fcb_Ninguna.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_fcb_Ninguna.Name = "CheckBox_fcb_Ninguna"
        Me.CheckBox_fcb_Ninguna.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_fcb_Ninguna.Size = New System.Drawing.Size(85, 29)
        Me.CheckBox_fcb_Ninguna.TabIndex = 29
        Me.CheckBox_fcb_Ninguna.Text = "None"
        Me.CheckBox_fcb_Ninguna.UseVisualStyleBackColor = True
        '
        'CheckBox_Reescribir_Registro
        '
        Me.CheckBox_Reescribir_Registro.AutoSize = True
        Me.CheckBox_Reescribir_Registro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Reescribir_Registro.Location = New System.Drawing.Point(310, 7)
        Me.CheckBox_Reescribir_Registro.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_Reescribir_Registro.Name = "CheckBox_Reescribir_Registro"
        Me.CheckBox_Reescribir_Registro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_Reescribir_Registro.Size = New System.Drawing.Size(185, 29)
        Me.CheckBox_Reescribir_Registro.TabIndex = 29
        Me.CheckBox_Reescribir_Registro.Text = "Rewrite Record"
        Me.CheckBox_Reescribir_Registro.UseVisualStyleBackColor = True
        '
        'CheckBox_Filtro_Personalizado
        '
        Me.CheckBox_Filtro_Personalizado.AutoSize = True
        Me.CheckBox_Filtro_Personalizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Filtro_Personalizado.Location = New System.Drawing.Point(26, 7)
        Me.CheckBox_Filtro_Personalizado.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_Filtro_Personalizado.Name = "CheckBox_Filtro_Personalizado"
        Me.CheckBox_Filtro_Personalizado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_Filtro_Personalizado.Size = New System.Drawing.Size(165, 29)
        Me.CheckBox_Filtro_Personalizado.TabIndex = 29
        Me.CheckBox_Filtro_Personalizado.Text = "Custom Filter"
        Me.CheckBox_Filtro_Personalizado.UseVisualStyleBackColor = True
        '
        'Label_Progreso_Filtro
        '
        Me.Label_Progreso_Filtro.AutoSize = True
        Me.Label_Progreso_Filtro.Location = New System.Drawing.Point(42, 354)
        Me.Label_Progreso_Filtro.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Progreso_Filtro.Name = "Label_Progreso_Filtro"
        Me.Label_Progreso_Filtro.Size = New System.Drawing.Size(0, 25)
        Me.Label_Progreso_Filtro.TabIndex = 28
        '
        'Button_Filtrar_Registro
        '
        Me.Button_Filtrar_Registro.BackColor = System.Drawing.Color.Transparent
        Me.Button_Filtrar_Registro.BackgroundImage = CType(resources.GetObject("Button_Filtrar_Registro.BackgroundImage"), System.Drawing.Image)
        Me.Button_Filtrar_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Filtrar_Registro.FlatAppearance.BorderSize = 0
        Me.Button_Filtrar_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Filtrar_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Filtrar_Registro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Filtrar_Registro.ForeColor = System.Drawing.Color.Black
        Me.Button_Filtrar_Registro.Location = New System.Drawing.Point(227, 430)
        Me.Button_Filtrar_Registro.Margin = New System.Windows.Forms.Padding(6)
        Me.Button_Filtrar_Registro.Name = "Button_Filtrar_Registro"
        Me.Button_Filtrar_Registro.Size = New System.Drawing.Size(143, 81)
        Me.Button_Filtrar_Registro.TabIndex = 16
        Me.Button_Filtrar_Registro.Text = "Filter Record"
        Me.Button_Filtrar_Registro.UseVisualStyleBackColor = False
        '
        'ProgressBar_Filtrar_Registro
        '
        Me.ProgressBar_Filtrar_Registro.BackColor = System.Drawing.Color.White
        Me.ProgressBar_Filtrar_Registro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ProgressBar_Filtrar_Registro.Location = New System.Drawing.Point(37, 390)
        Me.ProgressBar_Filtrar_Registro.Margin = New System.Windows.Forms.Padding(0)
        Me.ProgressBar_Filtrar_Registro.Name = "ProgressBar_Filtrar_Registro"
        Me.ProgressBar_Filtrar_Registro.Size = New System.Drawing.Size(550, 35)
        Me.ProgressBar_Filtrar_Registro.Step = 1
        Me.ProgressBar_Filtrar_Registro.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar_Filtrar_Registro.TabIndex = 27
        '
        'SplitContainer_Analizis_Registro
        '
        Me.SplitContainer_Analizis_Registro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer_Analizis_Registro.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer_Analizis_Registro.IsSplitterFixed = True
        Me.SplitContainer_Analizis_Registro.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_Analizis_Registro.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer_Analizis_Registro.Name = "SplitContainer_Analizis_Registro"
        '
        'SplitContainer_Analizis_Registro.Panel1
        '
        Me.SplitContainer_Analizis_Registro.Panel1.BackgroundImage = CType(resources.GetObject("SplitContainer_Analizis_Registro.Panel1.BackgroundImage"), System.Drawing.Image)
        Me.SplitContainer_Analizis_Registro.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer_Analizis_Registro.Panel1.Controls.Add(Me.CheckBox_Analisis_Multi_Registro)
        Me.SplitContainer_Analizis_Registro.Panel1.Controls.Add(Me.CheckBox_Selecionar_Todos_Registros)
        Me.SplitContainer_Analizis_Registro.Panel1.Controls.Add(Me.CheckedListBox_Registros)
        Me.SplitContainer_Analizis_Registro.Panel1.Controls.Add(Me.ComboBox_Selecionar_Registro)
        Me.SplitContainer_Analizis_Registro.Panel1.Controls.Add(Me.Button_Independizar_Ventana)
        Me.SplitContainer_Analizis_Registro.Panel1.Controls.Add(Me.Button_Cerrar)
        Me.SplitContainer_Analizis_Registro.Panel1.Controls.Add(Me.PictureBox_Paciente)
        Me.SplitContainer_Analizis_Registro.Panel1.Controls.Add(Me.PictureBox_Usuario)
        Me.SplitContainer_Analizis_Registro.Panel1.Controls.Add(Me.PictureBox_Registro)
        Me.SplitContainer_Analizis_Registro.Panel1.Controls.Add(Me.Label_Usuario)
        Me.SplitContainer_Analizis_Registro.Panel1.Controls.Add(Me.ComboBox_Selecion_Usuario)
        Me.SplitContainer_Analizis_Registro.Panel1.Controls.Add(Me.ComboBox_Selecion_Paciente)
        Me.SplitContainer_Analizis_Registro.Panel1.Controls.Add(Me.Label_Paciente)
        Me.SplitContainer_Analizis_Registro.Panel1.Controls.Add(Me.Label_Registro)
        Me.SplitContainer_Analizis_Registro.Panel1.Controls.Add(Me.Button_Cargar_Registro)
        Me.SplitContainer_Analizis_Registro.Panel1MinSize = 200
        '
        'SplitContainer_Analizis_Registro.Panel2
        '
        Me.SplitContainer_Analizis_Registro.Panel2.AutoScroll = True
        Me.SplitContainer_Analizis_Registro.Panel2.BackgroundImage = CType(resources.GetObject("SplitContainer_Analizis_Registro.Panel2.BackgroundImage"), System.Drawing.Image)
        Me.SplitContainer_Analizis_Registro.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer_Analizis_Registro.Panel2.Controls.Add(Me.SplitContainer_Analisis)
        Me.SplitContainer_Analizis_Registro.Size = New System.Drawing.Size(1890, 916)
        Me.SplitContainer_Analizis_Registro.SplitterDistance = 210
        Me.SplitContainer_Analizis_Registro.SplitterWidth = 2
        Me.SplitContainer_Analizis_Registro.TabIndex = 0
        '
        'CheckBox_Analisis_Multi_Registro
        '
        Me.CheckBox_Analisis_Multi_Registro.AutoSize = True
        Me.CheckBox_Analisis_Multi_Registro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Analisis_Multi_Registro.Location = New System.Drawing.Point(6, 541)
        Me.CheckBox_Analisis_Multi_Registro.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_Analisis_Multi_Registro.Name = "CheckBox_Analisis_Multi_Registro"
        Me.CheckBox_Analisis_Multi_Registro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_Analisis_Multi_Registro.Size = New System.Drawing.Size(227, 29)
        Me.CheckBox_Analisis_Multi_Registro.TabIndex = 27
        Me.CheckBox_Analisis_Multi_Registro.Text = "Multi-Record Analysis"
        Me.CheckBox_Analisis_Multi_Registro.UseVisualStyleBackColor = True
        '
        'CheckBox_Selecionar_Todos_Registros
        '
        Me.CheckBox_Selecionar_Todos_Registros.AutoSize = True
        Me.CheckBox_Selecionar_Todos_Registros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Selecionar_Todos_Registros.Location = New System.Drawing.Point(6, 572)
        Me.CheckBox_Selecionar_Todos_Registros.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckBox_Selecionar_Todos_Registros.Name = "CheckBox_Selecionar_Todos_Registros"
        Me.CheckBox_Selecionar_Todos_Registros.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox_Selecionar_Todos_Registros.Size = New System.Drawing.Size(197, 29)
        Me.CheckBox_Selecionar_Todos_Registros.TabIndex = 26
        Me.CheckBox_Selecionar_Todos_Registros.Text = "Select All Records"
        Me.CheckBox_Selecionar_Todos_Registros.UseVisualStyleBackColor = True
        Me.CheckBox_Selecionar_Todos_Registros.Visible = False
        '
        'CheckedListBox_Registros
        '
        Me.CheckedListBox_Registros.FormattingEnabled = True
        Me.CheckedListBox_Registros.Location = New System.Drawing.Point(6, 338)
        Me.CheckedListBox_Registros.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.CheckedListBox_Registros.Name = "CheckedListBox_Registros"
        Me.CheckedListBox_Registros.Size = New System.Drawing.Size(354, 160)
        Me.CheckedListBox_Registros.TabIndex = 4
        '
        'ComboBox_Selecionar_Registro
        '
        Me.ComboBox_Selecionar_Registro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Selecionar_Registro.FormattingEnabled = True
        Me.ComboBox_Selecionar_Registro.Location = New System.Drawing.Point(6, 290)
        Me.ComboBox_Selecionar_Registro.Margin = New System.Windows.Forms.Padding(6)
        Me.ComboBox_Selecionar_Registro.Name = "ComboBox_Selecionar_Registro"
        Me.ComboBox_Selecionar_Registro.Size = New System.Drawing.Size(354, 32)
        Me.ComboBox_Selecionar_Registro.TabIndex = 3
        '
        'Button_Independizar_Ventana
        '
        Me.Button_Independizar_Ventana.BackColor = System.Drawing.Color.Transparent
        Me.Button_Independizar_Ventana.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Independizar_Ventana.FlatAppearance.BorderSize = 0
        Me.Button_Independizar_Ventana.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Independizar_Ventana.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Independizar_Ventana.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Independizar_Ventana.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Independizar_Ventana.ForeColor = System.Drawing.Color.Gray
        Me.Button_Independizar_Ventana.Location = New System.Drawing.Point(286, 0)
        Me.Button_Independizar_Ventana.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Independizar_Ventana.Name = "Button_Independizar_Ventana"
        Me.Button_Independizar_Ventana.Size = New System.Drawing.Size(55, 46)
        Me.Button_Independizar_Ventana.TabIndex = 12
        Me.Button_Independizar_Ventana.Text = "->"
        Me.Button_Independizar_Ventana.UseVisualStyleBackColor = False
        '
        'Button_Cerrar
        '
        Me.Button_Cerrar.BackColor = System.Drawing.Color.Transparent
        Me.Button_Cerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Cerrar.FlatAppearance.BorderSize = 0
        Me.Button_Cerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Cerrar.ForeColor = System.Drawing.Color.Gray
        Me.Button_Cerrar.Location = New System.Drawing.Point(341, 0)
        Me.Button_Cerrar.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Cerrar.Name = "Button_Cerrar"
        Me.Button_Cerrar.Size = New System.Drawing.Size(46, 46)
        Me.Button_Cerrar.TabIndex = 12
        Me.Button_Cerrar.Text = "X"
        Me.Button_Cerrar.UseVisualStyleBackColor = False
        '
        'PictureBox_Paciente
        '
        Me.PictureBox_Paciente.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Paciente.BackgroundImage = CType(resources.GetObject("PictureBox_Paciente.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Paciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Paciente.Location = New System.Drawing.Point(6, 118)
        Me.PictureBox_Paciente.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Paciente.Name = "PictureBox_Paciente"
        Me.PictureBox_Paciente.Size = New System.Drawing.Size(55, 55)
        Me.PictureBox_Paciente.TabIndex = 6
        Me.PictureBox_Paciente.TabStop = False
        '
        'PictureBox_Usuario
        '
        Me.PictureBox_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Usuario.BackgroundImage = CType(resources.GetObject("PictureBox_Usuario.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Usuario.Location = New System.Drawing.Point(6, 11)
        Me.PictureBox_Usuario.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Usuario.Name = "PictureBox_Usuario"
        Me.PictureBox_Usuario.Size = New System.Drawing.Size(55, 55)
        Me.PictureBox_Usuario.TabIndex = 6
        Me.PictureBox_Usuario.TabStop = False
        '
        'PictureBox_Registro
        '
        Me.PictureBox_Registro.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Registro.BackgroundImage = CType(resources.GetObject("PictureBox_Registro.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Registro.Location = New System.Drawing.Point(6, 229)
        Me.PictureBox_Registro.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Registro.Name = "PictureBox_Registro"
        Me.PictureBox_Registro.Size = New System.Drawing.Size(55, 55)
        Me.PictureBox_Registro.TabIndex = 6
        Me.PictureBox_Registro.TabStop = False
        '
        'Label_Usuario
        '
        Me.Label_Usuario.AutoSize = True
        Me.Label_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.Label_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label_Usuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label_Usuario.Location = New System.Drawing.Point(66, 22)
        Me.Label_Usuario.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Usuario.Name = "Label_Usuario"
        Me.Label_Usuario.Size = New System.Drawing.Size(53, 25)
        Me.Label_Usuario.TabIndex = 3
        Me.Label_Usuario.Text = "User"
        '
        'ComboBox_Selecion_Usuario
        '
        Me.ComboBox_Selecion_Usuario.CausesValidation = False
        Me.ComboBox_Selecion_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Selecion_Usuario.FormattingEnabled = True
        Me.ComboBox_Selecion_Usuario.Location = New System.Drawing.Point(6, 72)
        Me.ComboBox_Selecion_Usuario.Margin = New System.Windows.Forms.Padding(6)
        Me.ComboBox_Selecion_Usuario.Name = "ComboBox_Selecion_Usuario"
        Me.ComboBox_Selecion_Usuario.Size = New System.Drawing.Size(354, 32)
        Me.ComboBox_Selecion_Usuario.TabIndex = 1
        '
        'ComboBox_Selecion_Paciente
        '
        Me.ComboBox_Selecion_Paciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Selecion_Paciente.FormattingEnabled = True
        Me.ComboBox_Selecion_Paciente.Location = New System.Drawing.Point(6, 181)
        Me.ComboBox_Selecion_Paciente.Margin = New System.Windows.Forms.Padding(6)
        Me.ComboBox_Selecion_Paciente.Name = "ComboBox_Selecion_Paciente"
        Me.ComboBox_Selecion_Paciente.Size = New System.Drawing.Size(354, 32)
        Me.ComboBox_Selecion_Paciente.TabIndex = 2
        '
        'Label_Paciente
        '
        Me.Label_Paciente.AutoSize = True
        Me.Label_Paciente.BackColor = System.Drawing.Color.Transparent
        Me.Label_Paciente.Location = New System.Drawing.Point(68, 138)
        Me.Label_Paciente.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Paciente.Name = "Label_Paciente"
        Me.Label_Paciente.Size = New System.Drawing.Size(72, 25)
        Me.Label_Paciente.TabIndex = 4
        Me.Label_Paciente.Text = "Patient"
        '
        'Label_Registro
        '
        Me.Label_Registro.AutoSize = True
        Me.Label_Registro.BackColor = System.Drawing.Color.Transparent
        Me.Label_Registro.Location = New System.Drawing.Point(68, 246)
        Me.Label_Registro.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Registro.Name = "Label_Registro"
        Me.Label_Registro.Size = New System.Drawing.Size(74, 25)
        Me.Label_Registro.TabIndex = 4
        Me.Label_Registro.Text = "Record"
        '
        'Button_Cargar_Registro
        '
        Me.Button_Cargar_Registro.BackColor = System.Drawing.Color.Transparent
        Me.Button_Cargar_Registro.BackgroundImage = CType(resources.GetObject("Button_Cargar_Registro.BackgroundImage"), System.Drawing.Image)
        Me.Button_Cargar_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Cargar_Registro.FlatAppearance.BorderSize = 0
        Me.Button_Cargar_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Cargar_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Cargar_Registro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Cargar_Registro.ForeColor = System.Drawing.Color.Black
        Me.Button_Cargar_Registro.Location = New System.Drawing.Point(22, 620)
        Me.Button_Cargar_Registro.Margin = New System.Windows.Forms.Padding(6)
        Me.Button_Cargar_Registro.Name = "Button_Cargar_Registro"
        Me.Button_Cargar_Registro.Size = New System.Drawing.Size(143, 81)
        Me.Button_Cargar_Registro.TabIndex = 5
        Me.Button_Cargar_Registro.Text = "Load Record"
        Me.Button_Cargar_Registro.UseVisualStyleBackColor = False
        '
        'SplitContainer_Analisis
        '
        Me.SplitContainer_Analisis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_Analisis.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer_Analisis.IsSplitterFixed = True
        Me.SplitContainer_Analisis.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_Analisis.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer_Analisis.Name = "SplitContainer_Analisis"
        Me.SplitContainer_Analisis.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer_Analisis.Panel1
        '
        Me.SplitContainer_Analisis.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer_Analisis.Panel1.Controls.Add(Me.Label_Registro_Seleccionado)
        Me.SplitContainer_Analisis.Panel1.Controls.Add(Me.PictureBox1)
        Me.SplitContainer_Analisis.Panel1MinSize = 0
        '
        'SplitContainer_Analisis.Panel2
        '
        Me.SplitContainer_Analisis.Panel2.AutoScroll = True
        Me.SplitContainer_Analisis.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer_Analisis.Panel2.BackgroundImage = CType(resources.GetObject("SplitContainer_Analisis.Panel2.BackgroundImage"), System.Drawing.Image)
        Me.SplitContainer_Analisis.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer_Analisis.Panel2.Controls.Add(Me.TabControlEX1)
        Me.SplitContainer_Analisis.Panel2MinSize = 120
        Me.SplitContainer_Analisis.Size = New System.Drawing.Size(1678, 916)
        Me.SplitContainer_Analisis.SplitterDistance = 25
        Me.SplitContainer_Analisis.SplitterWidth = 2
        Me.SplitContainer_Analisis.TabIndex = 16
        '
        'Label_Registro_Seleccionado
        '
        Me.Label_Registro_Seleccionado.AutoSize = True
        Me.Label_Registro_Seleccionado.BackColor = System.Drawing.Color.Transparent
        Me.Label_Registro_Seleccionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Registro_Seleccionado.Location = New System.Drawing.Point(51, 7)
        Me.Label_Registro_Seleccionado.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Registro_Seleccionado.Name = "Label_Registro_Seleccionado"
        Me.Label_Registro_Seleccionado.Size = New System.Drawing.Size(110, 29)
        Me.Label_Registro_Seleccionado.TabIndex = 4
        Me.Label_Registro_Seleccionado.Text = "Records:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(46, 25)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'BackgroundWorker_Analisis_Registro
        '
        Me.BackgroundWorker_Analisis_Registro.WorkerReportsProgress = True
        Me.BackgroundWorker_Analisis_Registro.WorkerSupportsCancellation = True
        '
        'BackgroundWorker_Filtrar_Registro
        '
        Me.BackgroundWorker_Filtrar_Registro.WorkerReportsProgress = True
        Me.BackgroundWorker_Filtrar_Registro.WorkerSupportsCancellation = True
        '
        'BackgroundWorker_Analisis_Multi_Registro
        '
        Me.BackgroundWorker_Analisis_Multi_Registro.WorkerReportsProgress = True
        Me.BackgroundWorker_Analisis_Multi_Registro.WorkerSupportsCancellation = True
        '
        'ToolTip_Informacion
        '
        Me.ToolTip_Informacion.AutoPopDelay = 5000
        Me.ToolTip_Informacion.InitialDelay = 0
        Me.ToolTip_Informacion.ReshowDelay = 100
        '
        'UserControl_Modulo_Analicis_Señal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.SplitContainer_Analizis_Registro)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "UserControl_Modulo_Analicis_Señal"
        Me.Size = New System.Drawing.Size(1890, 916)
        Me.TabControlEX1.ResumeLayout(False)
        Me.TabPageEX_Configuracion_Análisis.ResumeLayout(False)
        Me.TabPageEX_Configuracion_Análisis.PerformLayout()
        Me.TabPageEX_Análisis_Un_Registro.ResumeLayout(False)
        Me.TabPageEX_Análisis_Un_Registro.PerformLayout()
        Me.TabPageEX_Filtrar_Señal.ResumeLayout(False)
        Me.TabPageEX_Filtrar_Señal.PerformLayout()
        Me.SplitContainer_Analizis_Registro.Panel1.ResumeLayout(False)
        Me.SplitContainer_Analizis_Registro.Panel1.PerformLayout()
        Me.SplitContainer_Analizis_Registro.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer_Analizis_Registro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Analizis_Registro.ResumeLayout(False)
        CType(Me.PictureBox_Paciente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Usuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Registro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Analisis.Panel1.ResumeLayout(False)
        Me.SplitContainer_Analisis.Panel1.PerformLayout()
        Me.SplitContainer_Analisis.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer_Analisis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Analisis.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer_Analizis_Registro As SplitContainer
    Friend WithEvents ComboBox_Selecionar_Registro As ComboBox
    Friend WithEvents PictureBox_Paciente As PictureBox
    Friend WithEvents PictureBox_Usuario As PictureBox
    Friend WithEvents PictureBox_Registro As PictureBox
    Friend WithEvents ComboBox_Selecion_Usuario As ComboBox
    Friend WithEvents ComboBox_Selecion_Paciente As ComboBox
    Friend WithEvents Label_Paciente As Label
    Friend WithEvents Label_Registro As Label
    Friend WithEvents CheckedListBox_Registros As CheckedListBox
    Friend WithEvents Label_Usuario As Label
    Friend WithEvents Button_Cerrar As Button
    Friend WithEvents Button_Cargar_Registro As Button
    Friend WithEvents BackgroundWorker_Analisis_Registro As System.ComponentModel.BackgroundWorker
    Friend WithEvents SplitContainer_Analisis As SplitContainer
    Friend WithEvents Label_Registro_Seleccionado As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TabPageEX_Análisis_Un_Registro As Dotnetrix.Controls.TabPageEX
    Friend WithEvents Button_Analizar_Registro As Button
    Friend WithEvents ProgressBar_Progreso_Analisis As ProgressBar
    Friend WithEvents Label2 As Label
    Friend WithEvents TabPageEX_Filtrar_Señal As Dotnetrix.Controls.TabPageEX
    Friend WithEvents CheckBox_Recalcular_Resultados As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label_Progreso_Filtro As Label
    Friend WithEvents Button_Filtrar_Registro As Button
    Friend WithEvents ProgressBar_Filtrar_Registro As ProgressBar
    Friend WithEvents CheckBox_fcb_10_Hz As CheckBox
    Friend WithEvents CheckBox_fcb_5_Hz As CheckBox
    Friend WithEvents CheckBox_fcb_1_Hz As CheckBox
    Friend WithEvents CheckBox_fcb_Ninguna As CheckBox
    Friend WithEvents CheckBox_fca_200_Hz As CheckBox
    Friend WithEvents CheckBox_fca_150_Hz As CheckBox
    Friend WithEvents CheckBox_fca_100_Hz As CheckBox
    Friend WithEvents CheckBox_fca_50_Hz As CheckBox
    Friend WithEvents CheckBox_fca_Ninguna As CheckBox
    Friend WithEvents Label_Filtro_Notch As Label
    Friend WithEvents CheckBox_Notch_60_Hz As CheckBox
    Friend WithEvents CheckBox_Notch_50_Hz As CheckBox
    Friend WithEvents CheckBox_Notch_Ninguna As CheckBox
    Friend WithEvents CheckBox_Reescribir_Registro As CheckBox
    Friend WithEvents CheckBox_Filtro_Personalizado As CheckBox
    Friend WithEvents ComboBox_fca As ComboBox
    Friend WithEvents ComboBox_fcb As ComboBox
    Friend WithEvents CheckBox_Filtro_Para_Banda As CheckBox
    Friend WithEvents CheckBox_Filtro_Pasa_Banda As CheckBox
    Friend WithEvents BackgroundWorker_Filtrar_Registro As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button_Independizar_Ventana As Button
    Friend WithEvents TabPageEX_Configuracion_Análisis As Dotnetrix.Controls.TabPageEX
    Friend WithEvents CheckBox_Filtrar_Señal As CheckBox
    Public WithEvents ComboBox_Selec_TW_QRS As ComboBox
    Friend WithEvents CheckedListBox_Registros_Analizar_Multi_Registro As CheckedListBox
    Friend WithEvents Button_Eliminar_Registro_Multi_Registro As Button
    Public WithEvents TabControlEX1 As Dotnetrix.Controls.TabControlEX
    Public WithEvents CheckBox_Selecionar_Todos_Registros As CheckBox
    Friend WithEvents BackgroundWorker_Analisis_Multi_Registro As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label_Registro_Analizado_Multi_Registro As Label
    Friend WithEvents Label_Progreso As Label
    Friend WithEvents CheckBox_Corregir_Puntos_Complejo_QRS As CheckBox
    Friend WithEvents CheckBox_Deteccion_Complejo_QRS_Faltantes As CheckBox
    Friend WithEvents CheckBox_Eliminar_Temporales_Calculados As CheckBox
    Friend WithEvents Label_Fcb As Label
    Public WithEvents ComboBox_Fca_Configuracion_Deteccion_QRS As ComboBox
    Friend WithEvents Label_Fca As Label
    Friend WithEvents Label_Parametros_Deteccion_Complejo_QRS As Label
    Friend WithEvents CheckBox_Selec_Auto_TW_QRS As CheckBox
    Friend WithEvents Label3 As Label
    Public WithEvents ComboBox_P_C_Max_PorCiento_Comp_QRS As ComboBox
    Friend WithEvents ToolTip_Informacion As ToolTip
    Friend WithEvents TextBox_Interv_Min_Entre_QRS As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox_Desplaz_Despues_QRS As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBox_Duracion_Max_QRS As TextBox
    Friend WithEvents TextBox_Duracion_Min_QRS As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Public WithEvents ComboBox_Angulo_Rechazo_QRS As ComboBox
    Friend WithEvents Label7 As Label
    Public WithEvents ComboBox_Avan_Antes_Cruce_Cero_Extremos_QRS As ComboBox
    Friend WithEvents Label6 As Label
    Public WithEvents ComboBox_Avan_Antes_Cruce_Cero_Centro_QRS As ComboBox
    Public WithEvents ComboBox_Fcb_Configuracion_Deteccion_QRS As ComboBox
    Friend WithEvents Label15 As Label
    Public WithEvents ComboBox_PorCiento_Rechazo_Ruido_QRS As ComboBox
    Friend WithEvents Button_Resetear_Parametros As Button
    Friend WithEvents CheckBox_fcb_005_Hz As CheckBox
    Friend WithEvents CheckBox_fcb_05_Hz As CheckBox
    Friend WithEvents TreeView_Elementos_Calcular As TreeView
    Public WithEvents CheckBox_Analisis_Multi_Registro As CheckBox
    Friend WithEvents Label25 As Label
    Public WithEvents ComboBox_PorCiento_Rechazo_Extremos As ComboBox
End Class
