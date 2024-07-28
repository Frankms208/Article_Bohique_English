<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControl_Modulo_Graficar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_Modulo_Graficar))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint1 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint2 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(1.0R, 0R)
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim StripLine1 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint3 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
        Dim DataPoint4 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.001R, 0R)
        Dim DataPoint5 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.002R, 0R)
        Dim DataPoint6 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.003R, 0.1R)
        Dim DataPoint7 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.004R, 0.3R)
        Dim DataPoint8 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.005R, 0.3R)
        Dim DataPoint9 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.006R, 0.1R)
        Dim DataPoint10 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.007R, 0R)
        Dim DataPoint11 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.008R, 0R)
        Dim DataPoint12 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.009R, -1.0R)
        Dim DataPoint13 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.01R, 4.0R)
        Dim DataPoint14 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.011R, -2.0R)
        Dim DataPoint15 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.012R, 0R)
        Dim DataPoint16 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.013R, 0R)
        Dim DataPoint17 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.014R, 0.2R)
        Dim DataPoint18 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.015R, 0.5R)
        Dim DataPoint19 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.016R, 0.5R)
        Dim DataPoint20 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.017R, 0.2R)
        Dim DataPoint21 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.018R, 0R)
        Dim DataPoint22 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.1R, 0R)
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("P_i")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("P")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("P_f")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("P Wave", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Q_i")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Q")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("R")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("S")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("J")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("QRS Complex", New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode6, TreeNode7, TreeNode8, TreeNode9})
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("T_i")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("T")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("T_f")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("T Wave", New System.Windows.Forms.TreeNode() {TreeNode11, TreeNode12, TreeNode13})
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Intervalo R-R")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Intervalo P-R")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Intervalo Q-T")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Intervals", New System.Windows.Forms.TreeNode() {TreeNode15, TreeNode16, TreeNode17})
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel_Modulo_Grafico = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel_Control = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button_Borar_Registros = New System.Windows.Forms.Button()
        Me.TextBox_Registro_Parcial_Minimo = New System.Windows.Forms.TextBox()
        Me.TextBox_Registro_Parcial_Maximo = New System.Windows.Forms.TextBox()
        Me.ComboBox_Escala_Tiempo = New System.Windows.Forms.ComboBox()
        Me.CheckBox_Cuadricula = New System.Windows.Forms.CheckBox()
        Me.ComboBox_Cuadricula_ECG_Velocidad = New System.Windows.Forms.ComboBox()
        Me.CheckBox_Bloquear_Ventana = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Estilo_Linea = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button_Cerrar = New System.Windows.Forms.Button()
        Me.Button_Independizar_Ventana = New System.Windows.Forms.Button()
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1 = New System.Windows.Forms.Button()
        Me.ComboBox_Cuadricula_ECG_Ganancia = New System.Windows.Forms.ComboBox()
        Me.Chart_Registro_Total = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart_Registro_Parcial = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.BackgroundWorker_Grafica = New System.ComponentModel.BackgroundWorker()
        Me.SplitContainer_Modulo_Grafico = New System.Windows.Forms.SplitContainer()
        Me.TabControlEX_Modulo_Grafico_Control = New Dotnetrix.Controls.TabControlEX()
        Me.TabPageEX_Registros = New Dotnetrix.Controls.TabPageEX()
        Me.Button_Graficar_Registro = New System.Windows.Forms.Button()
        Me.PictureBox_Usuario = New System.Windows.Forms.PictureBox()
        Me.ComboBox_Selecion_Usuario = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Selecion_Paciente = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Registro = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label_Usuario = New System.Windows.Forms.Label()
        Me.Label_Registro = New System.Windows.Forms.Label()
        Me.ComboBox_Selecionar_Derivacion = New System.Windows.Forms.ComboBox()
        Me.PictureBox_Paciente = New System.Windows.Forms.PictureBox()
        Me.ComboBox_Selecionar_Registro = New System.Windows.Forms.ComboBox()
        Me.Label_Paciente = New System.Windows.Forms.Label()
        Me.TabPageEX2 = New Dotnetrix.Controls.TabPageEX()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.RichTextBox_Datos_Paciente = New System.Windows.Forms.RichTextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button_Borrar_Un_Registro = New System.Windows.Forms.Button()
        Me.Panel_Color_Registro_Graficado_Fondo = New System.Windows.Forms.Panel()
        Me.Panel_Color_Registro_Graficado = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox_Tamaño_Letra = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Registro_Graficado = New System.Windows.Forms.ComboBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TabPageEX3 = New Dotnetrix.Controls.TabPageEX()
        Me.CheckBox_Habilitar_Trasformada_Wavelet_Correccion_Onda_PT = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Trasformada_Wavelet_Busqueda_Onda_PT = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Habilitar_Señal_Temporal_Filtrada = New System.Windows.Forms.CheckBox()
        Me.TreeView_Graficar = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.CheckBox_Habilitar_Trasformada_Wavelet_QRS = New System.Windows.Forms.CheckBox()
        Me.TabPageEX4 = New Dotnetrix.Controls.TabPageEX()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TabControlEX_Selecion_Ondas_Intervalos = New Dotnetrix.Controls.TabControlEX()
        Me.TabPageEX_Ondas = New Dotnetrix.Controls.TabPageEX()
        Me.GroupBox_Ondas = New System.Windows.Forms.GroupBox()
        Me.TextBox_Onda_Tabla_Max = New System.Windows.Forms.TextBox()
        Me.TextBox_Onda_Tabla_Min = New System.Windows.Forms.TextBox()
        Me.RadioButton_P = New System.Windows.Forms.RadioButton()
        Me.RadioButton_T = New System.Windows.Forms.RadioButton()
        Me.RadioButton_QRS = New System.Windows.Forms.RadioButton()
        Me.TabPageEX_Intervalos = New Dotnetrix.Controls.TabPageEX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox_Intervalo_Tabla_Max = New System.Windows.Forms.TextBox()
        Me.RadioButton_P_R = New System.Windows.Forms.RadioButton()
        Me.TextBox_Intervalo_Tabla_Min = New System.Windows.Forms.TextBox()
        Me.RadioButton_Q_T = New System.Windows.Forms.RadioButton()
        Me.RadioButton_R_R = New System.Windows.Forms.RadioButton()
        Me.ComboBox_Registro_Modificar = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel_Color_Registro_Modificar = New System.Windows.Forms.Panel()
        Me.DataGridView_Registro_Modificar = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button_Actualizar_Cambios = New System.Windows.Forms.Button()
        Me.Button_Modificar_Datos = New System.Windows.Forms.Button()
        Me.Button_Agregar_Punto = New System.Windows.Forms.Button()
        Me.Button_Eliminar_Ondas = New System.Windows.Forms.Button()
        Me.Button_Buscar_Ondas = New System.Windows.Forms.Button()
        Me.TableLayoutPanel_Modulo_Grafico.SuspendLayout()
        Me.Panel_Control.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.Chart_Registro_Total, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart_Registro_Parcial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer_Modulo_Grafico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_Modulo_Grafico.Panel1.SuspendLayout()
        Me.SplitContainer_Modulo_Grafico.Panel2.SuspendLayout()
        Me.SplitContainer_Modulo_Grafico.SuspendLayout()
        Me.TabControlEX_Modulo_Grafico_Control.SuspendLayout()
        Me.TabPageEX_Registros.SuspendLayout()
        CType(Me.PictureBox_Usuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Registro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Paciente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageEX2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel_Color_Registro_Graficado_Fondo.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageEX3.SuspendLayout()
        Me.TabPageEX4.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TabControlEX_Selecion_Ondas_Intervalos.SuspendLayout()
        Me.TabPageEX_Ondas.SuspendLayout()
        Me.GroupBox_Ondas.SuspendLayout()
        Me.TabPageEX_Intervalos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView_Registro_Modificar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel_Modulo_Grafico
        '
        Me.TableLayoutPanel_Modulo_Grafico.AutoScroll = True
        Me.TableLayoutPanel_Modulo_Grafico.ColumnCount = 1
        Me.TableLayoutPanel_Modulo_Grafico.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel_Modulo_Grafico.Controls.Add(Me.Panel_Control, 0, 0)
        Me.TableLayoutPanel_Modulo_Grafico.Controls.Add(Me.Chart_Registro_Total, 0, 1)
        Me.TableLayoutPanel_Modulo_Grafico.Controls.Add(Me.Chart_Registro_Parcial, 0, 2)
        Me.TableLayoutPanel_Modulo_Grafico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel_Modulo_Grafico.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel_Modulo_Grafico.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel_Modulo_Grafico.Name = "TableLayoutPanel_Modulo_Grafico"
        Me.TableLayoutPanel_Modulo_Grafico.RowCount = 3
        Me.TableLayoutPanel_Modulo_Grafico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.TableLayoutPanel_Modulo_Grafico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 122.0!))
        Me.TableLayoutPanel_Modulo_Grafico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel_Modulo_Grafico.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.TableLayoutPanel_Modulo_Grafico.Size = New System.Drawing.Size(996, 738)
        Me.TableLayoutPanel_Modulo_Grafico.TabIndex = 0
        '
        'Panel_Control
        '
        Me.Panel_Control.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Control.BackgroundImage = CType(resources.GetObject("Panel_Control.BackgroundImage"), System.Drawing.Image)
        Me.Panel_Control.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Control.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel_Control.Controls.Add(Me.FlowLayoutPanel2)
        Me.Panel_Control.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Control.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel_Control.Name = "Panel_Control"
        Me.Panel_Control.Size = New System.Drawing.Size(996, 38)
        Me.Panel_Control.TabIndex = 7
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Button_Borar_Registros)
        Me.FlowLayoutPanel2.Controls.Add(Me.TextBox_Registro_Parcial_Minimo)
        Me.FlowLayoutPanel2.Controls.Add(Me.TextBox_Registro_Parcial_Maximo)
        Me.FlowLayoutPanel2.Controls.Add(Me.CheckBox_Cuadricula)
        Me.FlowLayoutPanel2.Controls.Add(Me.ComboBox_Cuadricula_ECG_Velocidad)
        Me.FlowLayoutPanel2.Controls.Add(Me.ComboBox_Cuadricula_ECG_Ganancia)
        Me.FlowLayoutPanel2.Controls.Add(Me.CheckBox_Bloquear_Ventana)
        Me.FlowLayoutPanel2.Controls.Add(Me.CheckBox_Estilo_Linea)
        Me.FlowLayoutPanel2.Controls.Add(Me.ComboBox_Escala_Tiempo)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(996, 38)
        Me.FlowLayoutPanel2.TabIndex = 7
        '
        'Button_Borar_Registros
        '
        Me.Button_Borar_Registros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Borar_Registros.BackColor = System.Drawing.Color.Transparent
        Me.Button_Borar_Registros.BackgroundImage = CType(resources.GetObject("Button_Borar_Registros.BackgroundImage"), System.Drawing.Image)
        Me.Button_Borar_Registros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Borar_Registros.FlatAppearance.BorderSize = 0
        Me.Button_Borar_Registros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Borar_Registros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Borar_Registros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Borar_Registros.ForeColor = System.Drawing.Color.Black
        Me.Button_Borar_Registros.Location = New System.Drawing.Point(5, 2)
        Me.Button_Borar_Registros.Margin = New System.Windows.Forms.Padding(5, 2, 5, 2)
        Me.Button_Borar_Registros.Name = "Button_Borar_Registros"
        Me.Button_Borar_Registros.Size = New System.Drawing.Size(68, 34)
        Me.Button_Borar_Registros.TabIndex = 2
        Me.Button_Borar_Registros.Text = "Clear"
        Me.Button_Borar_Registros.UseVisualStyleBackColor = False
        '
        'TextBox_Registro_Parcial_Minimo
        '
        Me.TextBox_Registro_Parcial_Minimo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Registro_Parcial_Minimo.Location = New System.Drawing.Point(83, 5)
        Me.TextBox_Registro_Parcial_Minimo.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBox_Registro_Parcial_Minimo.Name = "TextBox_Registro_Parcial_Minimo"
        Me.TextBox_Registro_Parcial_Minimo.Size = New System.Drawing.Size(100, 26)
        Me.TextBox_Registro_Parcial_Minimo.TabIndex = 3
        Me.TextBox_Registro_Parcial_Minimo.Text = "0"
        '
        'TextBox_Registro_Parcial_Maximo
        '
        Me.TextBox_Registro_Parcial_Maximo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Registro_Parcial_Maximo.Location = New System.Drawing.Point(193, 5)
        Me.TextBox_Registro_Parcial_Maximo.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBox_Registro_Parcial_Maximo.Name = "TextBox_Registro_Parcial_Maximo"
        Me.TextBox_Registro_Parcial_Maximo.Size = New System.Drawing.Size(100, 26)
        Me.TextBox_Registro_Parcial_Maximo.TabIndex = 4
        Me.TextBox_Registro_Parcial_Maximo.Text = "1"
        '
        'ComboBox_Escala_Tiempo
        '
        Me.ComboBox_Escala_Tiempo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_Escala_Tiempo.FormattingEnabled = True
        Me.ComboBox_Escala_Tiempo.Items.AddRange(New Object() {"s", "min", "h"})
        Me.ComboBox_Escala_Tiempo.Location = New System.Drawing.Point(876, 5)
        Me.ComboBox_Escala_Tiempo.Margin = New System.Windows.Forms.Padding(5)
        Me.ComboBox_Escala_Tiempo.Name = "ComboBox_Escala_Tiempo"
        Me.ComboBox_Escala_Tiempo.Size = New System.Drawing.Size(64, 28)
        Me.ComboBox_Escala_Tiempo.TabIndex = 6
        Me.ComboBox_Escala_Tiempo.Visible = False
        '
        'CheckBox_Cuadricula
        '
        Me.CheckBox_Cuadricula.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_Cuadricula.AutoSize = True
        Me.CheckBox_Cuadricula.Location = New System.Drawing.Point(303, 5)
        Me.CheckBox_Cuadricula.Margin = New System.Windows.Forms.Padding(5)
        Me.CheckBox_Cuadricula.Name = "CheckBox_Cuadricula"
        Me.CheckBox_Cuadricula.Size = New System.Drawing.Size(65, 28)
        Me.CheckBox_Cuadricula.TabIndex = 7
        Me.CheckBox_Cuadricula.Text = "Grid"
        Me.CheckBox_Cuadricula.UseVisualStyleBackColor = True
        '
        'ComboBox_Cuadricula_ECG_Velocidad
        '
        Me.ComboBox_Cuadricula_ECG_Velocidad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_Cuadricula_ECG_Velocidad.FormattingEnabled = True
        Me.ComboBox_Cuadricula_ECG_Velocidad.Items.AddRange(New Object() {"12.5 mm/s", "25 mm/s", "37.5 mm/s", "50 mm/s", "75 mm/s", "100 mm/s", "125 mm/s"})
        Me.ComboBox_Cuadricula_ECG_Velocidad.Location = New System.Drawing.Point(378, 5)
        Me.ComboBox_Cuadricula_ECG_Velocidad.Margin = New System.Windows.Forms.Padding(5)
        Me.ComboBox_Cuadricula_ECG_Velocidad.Name = "ComboBox_Cuadricula_ECG_Velocidad"
        Me.ComboBox_Cuadricula_ECG_Velocidad.Size = New System.Drawing.Size(106, 28)
        Me.ComboBox_Cuadricula_ECG_Velocidad.TabIndex = 8
        '
        'CheckBox_Bloquear_Ventana
        '
        Me.CheckBox_Bloquear_Ventana.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_Bloquear_Ventana.AutoSize = True
        Me.CheckBox_Bloquear_Ventana.Location = New System.Drawing.Point(623, 5)
        Me.CheckBox_Bloquear_Ventana.Margin = New System.Windows.Forms.Padding(5)
        Me.CheckBox_Bloquear_Ventana.Name = "CheckBox_Bloquear_Ventana"
        Me.CheckBox_Bloquear_Ventana.Size = New System.Drawing.Size(124, 28)
        Me.CheckBox_Bloquear_Ventana.TabIndex = 5
        Me.CheckBox_Bloquear_Ventana.Text = "Lock Screen"
        Me.CheckBox_Bloquear_Ventana.UseVisualStyleBackColor = True
        '
        'CheckBox_Estilo_Linea
        '
        Me.CheckBox_Estilo_Linea.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_Estilo_Linea.AutoSize = True
        Me.CheckBox_Estilo_Linea.Checked = True
        Me.CheckBox_Estilo_Linea.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Estilo_Linea.Location = New System.Drawing.Point(757, 5)
        Me.CheckBox_Estilo_Linea.Margin = New System.Windows.Forms.Padding(5)
        Me.CheckBox_Estilo_Linea.Name = "CheckBox_Estilo_Linea"
        Me.CheckBox_Estilo_Linea.Size = New System.Drawing.Size(109, 28)
        Me.CheckBox_Estilo_Linea.TabIndex = 7
        Me.CheckBox_Estilo_Linea.Text = "Show Line"
        Me.CheckBox_Estilo_Linea.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Button_Cerrar)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button_Independizar_Ventana)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(888, 0)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(108, 38)
        Me.FlowLayoutPanel1.TabIndex = 14
        '
        'Button_Cerrar
        '
        Me.Button_Cerrar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button_Cerrar.BackColor = System.Drawing.Color.Transparent
        Me.Button_Cerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Cerrar.FlatAppearance.BorderSize = 0
        Me.Button_Cerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Cerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Cerrar.ForeColor = System.Drawing.Color.Gray
        Me.Button_Cerrar.Location = New System.Drawing.Point(70, 0)
        Me.Button_Cerrar.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Cerrar.Name = "Button_Cerrar"
        Me.Button_Cerrar.Size = New System.Drawing.Size(38, 38)
        Me.Button_Cerrar.TabIndex = 1
        Me.Button_Cerrar.Text = "X"
        Me.Button_Cerrar.UseVisualStyleBackColor = False
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
        Me.Button_Independizar_Ventana.Location = New System.Drawing.Point(25, 0)
        Me.Button_Independizar_Ventana.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Independizar_Ventana.Name = "Button_Independizar_Ventana"
        Me.Button_Independizar_Ventana.Size = New System.Drawing.Size(45, 38)
        Me.Button_Independizar_Ventana.TabIndex = 13
        Me.Button_Independizar_Ventana.Text = "->"
        Me.Button_Independizar_Ventana.UseVisualStyleBackColor = False
        '
        'Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1
        '
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.AutoSize = True
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.BackgroundImage = CType(resources.GetObject("Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.FlatAppearance.BorderSize = 0
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.Location = New System.Drawing.Point(70, 38)
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.Name = "Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1"
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.Size = New System.Drawing.Size(38, 38)
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.TabIndex = 5
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1.UseVisualStyleBackColor = True
        '
        'ComboBox_Cuadricula_ECG_Ganancia
        '
        Me.ComboBox_Cuadricula_ECG_Ganancia.FormattingEnabled = True
        Me.ComboBox_Cuadricula_ECG_Ganancia.Items.AddRange(New Object() {"2.5 mm/mV", "5 mm/mV", "10 mm/mV", "15 mm/mV", "20 mm/mV", "30 mm/mV"})
        Me.ComboBox_Cuadricula_ECG_Ganancia.Location = New System.Drawing.Point(494, 5)
        Me.ComboBox_Cuadricula_ECG_Ganancia.Margin = New System.Windows.Forms.Padding(5)
        Me.ComboBox_Cuadricula_ECG_Ganancia.Name = "ComboBox_Cuadricula_ECG_Ganancia"
        Me.ComboBox_Cuadricula_ECG_Ganancia.Size = New System.Drawing.Size(119, 28)
        Me.ComboBox_Cuadricula_ECG_Ganancia.TabIndex = 9
        '
        'Chart_Registro_Total
        '
        Me.Chart_Registro_Total.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.AxisX.IsMarginVisible = False
        ChartArea1.AxisX.LabelStyle.Format = "g3"
        ChartArea1.AxisX.LineWidth = 0
        ChartArea1.AxisX.MinorTickMark.Enabled = True
        ChartArea1.AxisY.IsMarginVisible = False
        ChartArea1.AxisY.LabelStyle.Enabled = False
        ChartArea1.AxisY.LabelStyle.Format = "g3"
        ChartArea1.AxisY.MajorGrid.Enabled = False
        ChartArea1.AxisY.MajorTickMark.Enabled = False
        ChartArea1.AxisY.MinorGrid.Interval = Double.NaN
        ChartArea1.AxisY.MinorGrid.IntervalOffset = Double.NaN
        ChartArea1.AxisY.MinorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.NotSet
        ChartArea1.AxisY.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.NotSet
        ChartArea1.Name = "ChartArea1"
        Me.Chart_Registro_Total.ChartAreas.Add(ChartArea1)
        Me.Chart_Registro_Total.Location = New System.Drawing.Point(0, 38)
        Me.Chart_Registro_Total.Margin = New System.Windows.Forms.Padding(0)
        Me.Chart_Registro_Total.Name = "Chart_Registro_Total"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Series1.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet
        Series1.MarkerBorderColor = System.Drawing.Color.Transparent
        Series1.MarkerColor = System.Drawing.Color.Transparent
        Series1.Name = "Series_Min"
        Series1.Points.Add(DataPoint1)
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Series2.Name = "Series_Max"
        Series2.Points.Add(DataPoint2)
        Me.Chart_Registro_Total.Series.Add(Series1)
        Me.Chart_Registro_Total.Series.Add(Series2)
        Me.Chart_Registro_Total.Size = New System.Drawing.Size(996, 122)
        Me.Chart_Registro_Total.TabIndex = 1
        Me.Chart_Registro_Total.Text = "Chart1"
        Title1.Name = "Title1"
        Title1.Text = "Time (s)"
        Me.Chart_Registro_Total.Titles.Add(Title1)
        '
        'Chart_Registro_Parcial
        '
        Me.Chart_Registro_Parcial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea2.AxisX.InterlacedColor = System.Drawing.Color.White
        ChartArea2.AxisX.IsLabelAutoFit = False
        ChartArea2.AxisX.LabelStyle.Format = "g4"
        ChartArea2.AxisX.MajorGrid.Enabled = False
        ChartArea2.AxisX.MajorGrid.Interval = 10.0R
        ChartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Maroon
        ChartArea2.AxisX.MajorGrid.LineWidth = 3
        ChartArea2.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisX.MajorTickMark.LineWidth = 2
        ChartArea2.AxisX.MajorTickMark.Size = 2.0!
        ChartArea2.AxisX.MinorGrid.Interval = 5.0R
        ChartArea2.AxisX.MinorGrid.IntervalOffset = Double.NaN
        ChartArea2.AxisX.MinorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.NotSet
        ChartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.OrangeRed
        ChartArea2.AxisX.MinorTickMark.Interval = Double.NaN
        ChartArea2.AxisX.MinorTickMark.IntervalOffset = Double.NaN
        ChartArea2.AxisX.MinorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.NotSet
        ChartArea2.AxisX.ScaleBreakStyle.Enabled = True
        ChartArea2.AxisX2.IsLabelAutoFit = False
        ChartArea2.AxisX2.LabelStyle.Enabled = False
        ChartArea2.AxisX2.MajorTickMark.Enabled = False
        ChartArea2.AxisX2.MinorGrid.Enabled = True
        ChartArea2.AxisY.InterlacedColor = System.Drawing.Color.Transparent
        ChartArea2.AxisY.LabelStyle.Format = "g3"
        ChartArea2.AxisY.MajorGrid.Enabled = False
        ChartArea2.AxisY.MajorGrid.Interval = 2.0R
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Maroon
        ChartArea2.AxisY.MajorGrid.LineWidth = 3
        ChartArea2.AxisY.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisY.MajorTickMark.LineWidth = 2
        ChartArea2.AxisY.MajorTickMark.Size = 0.5!
        ChartArea2.AxisY.MinorGrid.Interval = 1.0R
        ChartArea2.AxisY.MinorGrid.IntervalOffset = Double.NaN
        ChartArea2.AxisY.MinorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.NotSet
        ChartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.OrangeRed
        ChartArea2.AxisY.MinorTickMark.Interval = Double.NaN
        ChartArea2.AxisY.MinorTickMark.IntervalOffset = Double.NaN
        ChartArea2.AxisY.MinorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.NotSet
        ChartArea2.AxisY.MinorTickMark.Size = 0.25!
        StripLine1.StripWidth = 1.0R
        ChartArea2.AxisY.StripLines.Add(StripLine1)
        ChartArea2.AxisY2.IsLabelAutoFit = False
        ChartArea2.AxisY2.MajorTickMark.Enabled = False
        ChartArea2.AxisY2.MinorGrid.Enabled = True
        ChartArea2.Name = "ChartArea1"
        Me.Chart_Registro_Parcial.ChartAreas.Add(ChartArea2)
        Me.Chart_Registro_Parcial.Location = New System.Drawing.Point(0, 160)
        Me.Chart_Registro_Parcial.Margin = New System.Windows.Forms.Padding(0)
        Me.Chart_Registro_Parcial.Name = "Chart_Registro_Parcial"
        Series3.BorderWidth = 3
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series3.MarkerStep = 20
        Series3.Name = "Series1"
        Series3.Points.Add(DataPoint3)
        Series3.Points.Add(DataPoint4)
        Series3.Points.Add(DataPoint5)
        Series3.Points.Add(DataPoint6)
        Series3.Points.Add(DataPoint7)
        Series3.Points.Add(DataPoint8)
        Series3.Points.Add(DataPoint9)
        Series3.Points.Add(DataPoint10)
        Series3.Points.Add(DataPoint11)
        Series3.Points.Add(DataPoint12)
        Series3.Points.Add(DataPoint13)
        Series3.Points.Add(DataPoint14)
        Series3.Points.Add(DataPoint15)
        Series3.Points.Add(DataPoint16)
        Series3.Points.Add(DataPoint17)
        Series3.Points.Add(DataPoint18)
        Series3.Points.Add(DataPoint19)
        Series3.Points.Add(DataPoint20)
        Series3.Points.Add(DataPoint21)
        Series3.Points.Add(DataPoint22)
        Me.Chart_Registro_Parcial.Series.Add(Series3)
        Me.Chart_Registro_Parcial.Size = New System.Drawing.Size(996, 578)
        Me.Chart_Registro_Parcial.TabIndex = 2
        Me.Chart_Registro_Parcial.Text = "Chart1"
        '
        'BackgroundWorker_Grafica
        '
        Me.BackgroundWorker_Grafica.WorkerSupportsCancellation = True
        '
        'SplitContainer_Modulo_Grafico
        '
        Me.SplitContainer_Modulo_Grafico.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer_Modulo_Grafico.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_Modulo_Grafico.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer_Modulo_Grafico.Name = "SplitContainer_Modulo_Grafico"
        '
        'SplitContainer_Modulo_Grafico.Panel1
        '
        Me.SplitContainer_Modulo_Grafico.Panel1.BackgroundImage = CType(resources.GetObject("SplitContainer_Modulo_Grafico.Panel1.BackgroundImage"), System.Drawing.Image)
        Me.SplitContainer_Modulo_Grafico.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer_Modulo_Grafico.Panel1.Controls.Add(Me.TabControlEX_Modulo_Grafico_Control)
        Me.SplitContainer_Modulo_Grafico.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer_Modulo_Grafico.Panel1MinSize = 0
        '
        'SplitContainer_Modulo_Grafico.Panel2
        '
        Me.SplitContainer_Modulo_Grafico.Panel2.BackgroundImage = CType(resources.GetObject("SplitContainer_Modulo_Grafico.Panel2.BackgroundImage"), System.Drawing.Image)
        Me.SplitContainer_Modulo_Grafico.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer_Modulo_Grafico.Panel2.Controls.Add(Me.TableLayoutPanel_Modulo_Grafico)
        Me.SplitContainer_Modulo_Grafico.Size = New System.Drawing.Size(1350, 738)
        Me.SplitContainer_Modulo_Grafico.SplitterDistance = 351
        Me.SplitContainer_Modulo_Grafico.SplitterWidth = 3
        Me.SplitContainer_Modulo_Grafico.TabIndex = 2
        '
        'TabControlEX_Modulo_Grafico_Control
        '
        Me.TabControlEX_Modulo_Grafico_Control.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.TabControlEX_Modulo_Grafico_Control.Appearance = Dotnetrix.Controls.TabAppearanceEX.FlatTab
        Me.TabControlEX_Modulo_Grafico_Control.AutoLoadTabPages = True
        Me.TabControlEX_Modulo_Grafico_Control.Controls.Add(Me.TabPageEX_Registros)
        Me.TabControlEX_Modulo_Grafico_Control.Controls.Add(Me.TabPageEX2)
        Me.TabControlEX_Modulo_Grafico_Control.Controls.Add(Me.TabPageEX3)
        Me.TabControlEX_Modulo_Grafico_Control.Controls.Add(Me.TabPageEX4)
        Me.TabControlEX_Modulo_Grafico_Control.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlEX_Modulo_Grafico_Control.ExtendContextMenuToTabs = True
        Me.TabControlEX_Modulo_Grafico_Control.Location = New System.Drawing.Point(0, 0)
        Me.TabControlEX_Modulo_Grafico_Control.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControlEX_Modulo_Grafico_Control.Multiline = True
        Me.TabControlEX_Modulo_Grafico_Control.Name = "TabControlEX_Modulo_Grafico_Control"
        Me.TabControlEX_Modulo_Grafico_Control.Padding = New System.Drawing.Point(0, 0)
        Me.TabControlEX_Modulo_Grafico_Control.SelectedIndex = 0
        Me.TabControlEX_Modulo_Grafico_Control.Size = New System.Drawing.Size(351, 738)
        Me.TabControlEX_Modulo_Grafico_Control.TabIndex = 0
        Me.TabControlEX_Modulo_Grafico_Control.UseVisualStyles = False
        '
        'TabPageEX_Registros
        '
        Me.TabPageEX_Registros.AutoScroll = True
        Me.TabPageEX_Registros.Controls.Add(Me.Button_Graficar_Registro)
        Me.TabPageEX_Registros.Controls.Add(Me.PictureBox_Usuario)
        Me.TabPageEX_Registros.Controls.Add(Me.ComboBox_Selecion_Usuario)
        Me.TabPageEX_Registros.Controls.Add(Me.ComboBox_Selecion_Paciente)
        Me.TabPageEX_Registros.Controls.Add(Me.PictureBox1)
        Me.TabPageEX_Registros.Controls.Add(Me.PictureBox_Registro)
        Me.TabPageEX_Registros.Controls.Add(Me.Label1)
        Me.TabPageEX_Registros.Controls.Add(Me.Label_Usuario)
        Me.TabPageEX_Registros.Controls.Add(Me.Label_Registro)
        Me.TabPageEX_Registros.Controls.Add(Me.ComboBox_Selecionar_Derivacion)
        Me.TabPageEX_Registros.Controls.Add(Me.PictureBox_Paciente)
        Me.TabPageEX_Registros.Controls.Add(Me.ComboBox_Selecionar_Registro)
        Me.TabPageEX_Registros.Controls.Add(Me.Label_Paciente)
        Me.TabPageEX_Registros.Location = New System.Drawing.Point(31, 4)
        Me.TabPageEX_Registros.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPageEX_Registros.Name = "TabPageEX_Registros"
        Me.TabPageEX_Registros.Size = New System.Drawing.Size(316, 730)
        Me.TabPageEX_Registros.TabIndex = 0
        Me.TabPageEX_Registros.Text = "Records"
        '
        'Button_Graficar_Registro
        '
        Me.Button_Graficar_Registro.BackColor = System.Drawing.Color.Transparent
        Me.Button_Graficar_Registro.BackgroundImage = CType(resources.GetObject("Button_Graficar_Registro.BackgroundImage"), System.Drawing.Image)
        Me.Button_Graficar_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Graficar_Registro.FlatAppearance.BorderSize = 0
        Me.Button_Graficar_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Graficar_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Graficar_Registro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Graficar_Registro.ForeColor = System.Drawing.Color.Black
        Me.Button_Graficar_Registro.Location = New System.Drawing.Point(42, 392)
        Me.Button_Graficar_Registro.Margin = New System.Windows.Forms.Padding(5)
        Me.Button_Graficar_Registro.Name = "Button_Graficar_Registro"
        Me.Button_Graficar_Registro.Size = New System.Drawing.Size(123, 55)
        Me.Button_Graficar_Registro.TabIndex = 5
        Me.Button_Graficar_Registro.Text = "Plot"
        Me.Button_Graficar_Registro.UseVisualStyleBackColor = False
        '
        'PictureBox_Usuario
        '
        Me.PictureBox_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Usuario.BackgroundImage = CType(resources.GetObject("PictureBox_Usuario.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Usuario.Location = New System.Drawing.Point(7, 11)
        Me.PictureBox_Usuario.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Usuario.Name = "PictureBox_Usuario"
        Me.PictureBox_Usuario.Size = New System.Drawing.Size(45, 46)
        Me.PictureBox_Usuario.TabIndex = 6
        Me.PictureBox_Usuario.TabStop = False
        '
        'ComboBox_Selecion_Usuario
        '
        Me.ComboBox_Selecion_Usuario.CausesValidation = False
        Me.ComboBox_Selecion_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Selecion_Usuario.FormattingEnabled = True
        Me.ComboBox_Selecion_Usuario.Location = New System.Drawing.Point(7, 65)
        Me.ComboBox_Selecion_Usuario.Margin = New System.Windows.Forms.Padding(5)
        Me.ComboBox_Selecion_Usuario.Name = "ComboBox_Selecion_Usuario"
        Me.ComboBox_Selecion_Usuario.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox_Selecion_Usuario.Size = New System.Drawing.Size(204, 28)
        Me.ComboBox_Selecion_Usuario.TabIndex = 2
        '
        'ComboBox_Selecion_Paciente
        '
        Me.ComboBox_Selecion_Paciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Selecion_Paciente.FormattingEnabled = True
        Me.ComboBox_Selecion_Paciente.Location = New System.Drawing.Point(7, 155)
        Me.ComboBox_Selecion_Paciente.Margin = New System.Windows.Forms.Padding(5)
        Me.ComboBox_Selecion_Paciente.Name = "ComboBox_Selecion_Paciente"
        Me.ComboBox_Selecion_Paciente.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox_Selecion_Paciente.Size = New System.Drawing.Size(204, 28)
        Me.ComboBox_Selecion_Paciente.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(7, 280)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(45, 46)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'PictureBox_Registro
        '
        Me.PictureBox_Registro.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Registro.BackgroundImage = CType(resources.GetObject("PictureBox_Registro.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Registro.Location = New System.Drawing.Point(7, 194)
        Me.PictureBox_Registro.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Registro.Name = "PictureBox_Registro"
        Me.PictureBox_Registro.Size = New System.Drawing.Size(45, 46)
        Me.PictureBox_Registro.TabIndex = 6
        Me.PictureBox_Registro.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(60, 295)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Derivation"
        '
        'Label_Usuario
        '
        Me.Label_Usuario.AutoSize = True
        Me.Label_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.Label_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label_Usuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label_Usuario.Location = New System.Drawing.Point(60, 27)
        Me.Label_Usuario.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label_Usuario.Name = "Label_Usuario"
        Me.Label_Usuario.Size = New System.Drawing.Size(43, 20)
        Me.Label_Usuario.TabIndex = 3
        Me.Label_Usuario.Text = "User"
        '
        'Label_Registro
        '
        Me.Label_Registro.AutoSize = True
        Me.Label_Registro.BackColor = System.Drawing.Color.Transparent
        Me.Label_Registro.Location = New System.Drawing.Point(60, 209)
        Me.Label_Registro.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label_Registro.Name = "Label_Registro"
        Me.Label_Registro.Size = New System.Drawing.Size(61, 20)
        Me.Label_Registro.TabIndex = 4
        Me.Label_Registro.Text = "Record"
        '
        'ComboBox_Selecionar_Derivacion
        '
        Me.ComboBox_Selecionar_Derivacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Selecionar_Derivacion.FormattingEnabled = True
        Me.ComboBox_Selecionar_Derivacion.Location = New System.Drawing.Point(7, 334)
        Me.ComboBox_Selecionar_Derivacion.Margin = New System.Windows.Forms.Padding(5)
        Me.ComboBox_Selecionar_Derivacion.Name = "ComboBox_Selecionar_Derivacion"
        Me.ComboBox_Selecionar_Derivacion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox_Selecionar_Derivacion.Size = New System.Drawing.Size(204, 28)
        Me.ComboBox_Selecionar_Derivacion.TabIndex = 4
        '
        'PictureBox_Paciente
        '
        Me.PictureBox_Paciente.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Paciente.BackgroundImage = CType(resources.GetObject("PictureBox_Paciente.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Paciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Paciente.Location = New System.Drawing.Point(7, 103)
        Me.PictureBox_Paciente.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Paciente.Name = "PictureBox_Paciente"
        Me.PictureBox_Paciente.Size = New System.Drawing.Size(45, 46)
        Me.PictureBox_Paciente.TabIndex = 6
        Me.PictureBox_Paciente.TabStop = False
        '
        'ComboBox_Selecionar_Registro
        '
        Me.ComboBox_Selecionar_Registro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Selecionar_Registro.FormattingEnabled = True
        Me.ComboBox_Selecionar_Registro.Location = New System.Drawing.Point(7, 247)
        Me.ComboBox_Selecionar_Registro.Margin = New System.Windows.Forms.Padding(5)
        Me.ComboBox_Selecionar_Registro.Name = "ComboBox_Selecionar_Registro"
        Me.ComboBox_Selecionar_Registro.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox_Selecionar_Registro.Size = New System.Drawing.Size(204, 28)
        Me.ComboBox_Selecionar_Registro.TabIndex = 4
        '
        'Label_Paciente
        '
        Me.Label_Paciente.AutoSize = True
        Me.Label_Paciente.BackColor = System.Drawing.Color.Transparent
        Me.Label_Paciente.Location = New System.Drawing.Point(60, 118)
        Me.Label_Paciente.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label_Paciente.Name = "Label_Paciente"
        Me.Label_Paciente.Size = New System.Drawing.Size(59, 20)
        Me.Label_Paciente.TabIndex = 4
        Me.Label_Paciente.Text = "Patient"
        '
        'TabPageEX2
        '
        Me.TabPageEX2.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPageEX2.Enabled = False
        Me.TabPageEX2.Location = New System.Drawing.Point(31, 4)
        Me.TabPageEX2.Name = "TabPageEX2"
        Me.TabPageEX2.Size = New System.Drawing.Size(316, 730)
        Me.TabPageEX2.TabIndex = 1
        Me.TabPageEX2.Text = "Patient Data"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.RichTextBox_Datos_Paciente, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(316, 730)
        Me.TableLayoutPanel1.TabIndex = 14
        '
        'RichTextBox_Datos_Paciente
        '
        Me.RichTextBox_Datos_Paciente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox_Datos_Paciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox_Datos_Paciente.Location = New System.Drawing.Point(3, 185)
        Me.RichTextBox_Datos_Paciente.Name = "RichTextBox_Datos_Paciente"
        Me.RichTextBox_Datos_Paciente.ReadOnly = True
        Me.RichTextBox_Datos_Paciente.Size = New System.Drawing.Size(310, 444)
        Me.RichTextBox_Datos_Paciente.TabIndex = 12
        Me.RichTextBox_Datos_Paciente.Text = ""
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.Bohíque_FMS.My.Resources.Resources.Fondo
        Me.Panel3.Controls.Add(Me.Button_Borrar_Un_Registro)
        Me.Panel3.Controls.Add(Me.Panel_Color_Registro_Graficado_Fondo)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.ComboBox_Tamaño_Letra)
        Me.Panel3.Controls.Add(Me.ComboBox_Registro_Graficado)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(316, 182)
        Me.Panel3.TabIndex = 13
        '
        'Button_Borrar_Un_Registro
        '
        Me.Button_Borrar_Un_Registro.BackColor = System.Drawing.Color.Transparent
        Me.Button_Borrar_Un_Registro.BackgroundImage = CType(resources.GetObject("Button_Borrar_Un_Registro.BackgroundImage"), System.Drawing.Image)
        Me.Button_Borrar_Un_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Borrar_Un_Registro.FlatAppearance.BorderSize = 0
        Me.Button_Borrar_Un_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Borrar_Un_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Borrar_Un_Registro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Borrar_Un_Registro.ForeColor = System.Drawing.Color.Black
        Me.Button_Borrar_Un_Registro.Location = New System.Drawing.Point(5, 86)
        Me.Button_Borrar_Un_Registro.Margin = New System.Windows.Forms.Padding(5)
        Me.Button_Borrar_Un_Registro.Name = "Button_Borrar_Un_Registro"
        Me.Button_Borrar_Un_Registro.Size = New System.Drawing.Size(72, 31)
        Me.Button_Borrar_Un_Registro.TabIndex = 2
        Me.Button_Borrar_Un_Registro.Text = "Clear"
        Me.Button_Borrar_Un_Registro.UseVisualStyleBackColor = False
        '
        'Panel_Color_Registro_Graficado_Fondo
        '
        Me.Panel_Color_Registro_Graficado_Fondo.Controls.Add(Me.Panel_Color_Registro_Graficado)
        Me.Panel_Color_Registro_Graficado_Fondo.Location = New System.Drawing.Point(3, 51)
        Me.Panel_Color_Registro_Graficado_Fondo.Name = "Panel_Color_Registro_Graficado_Fondo"
        Me.Panel_Color_Registro_Graficado_Fondo.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel_Color_Registro_Graficado_Fondo.Size = New System.Drawing.Size(34, 31)
        Me.Panel_Color_Registro_Graficado_Fondo.TabIndex = 11
        '
        'Panel_Color_Registro_Graficado
        '
        Me.Panel_Color_Registro_Graficado.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Color_Registro_Graficado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Color_Registro_Graficado.Location = New System.Drawing.Point(3, 3)
        Me.Panel_Color_Registro_Graficado.Name = "Panel_Color_Registro_Graficado"
        Me.Panel_Color_Registro_Graficado.Size = New System.Drawing.Size(28, 25)
        Me.Panel_Color_Registro_Graficado.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(167, 91)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Font Size"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(52, 14)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Record Plot"
        '
        'ComboBox_Tamaño_Letra
        '
        Me.ComboBox_Tamaño_Letra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Tamaño_Letra.FormattingEnabled = True
        Me.ComboBox_Tamaño_Letra.IntegralHeight = False
        Me.ComboBox_Tamaño_Letra.Items.AddRange(New Object() {"7", "8", "9", "10", "11", "12", "13", "14", "16", "18", "20", "22", "26", "30", "34", "40"})
        Me.ComboBox_Tamaño_Letra.Location = New System.Drawing.Point(87, 87)
        Me.ComboBox_Tamaño_Letra.Margin = New System.Windows.Forms.Padding(5)
        Me.ComboBox_Tamaño_Letra.Name = "ComboBox_Tamaño_Letra"
        Me.ComboBox_Tamaño_Letra.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox_Tamaño_Letra.Size = New System.Drawing.Size(72, 28)
        Me.ComboBox_Tamaño_Letra.TabIndex = 13
        '
        'ComboBox_Registro_Graficado
        '
        Me.ComboBox_Registro_Graficado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_Registro_Graficado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Registro_Graficado.FormattingEnabled = True
        Me.ComboBox_Registro_Graficado.Location = New System.Drawing.Point(48, 54)
        Me.ComboBox_Registro_Graficado.Margin = New System.Windows.Forms.Padding(5)
        Me.ComboBox_Registro_Graficado.Name = "ComboBox_Registro_Graficado"
        Me.ComboBox_Registro_Graficado.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox_Registro_Graficado.Size = New System.Drawing.Size(314, 28)
        Me.ComboBox_Registro_Graficado.TabIndex = 8
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(-2, 3)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(45, 46)
        Me.PictureBox2.TabIndex = 9
        Me.PictureBox2.TabStop = False
        '
        'TabPageEX3
        '
        Me.TabPageEX3.Controls.Add(Me.CheckBox_Habilitar_Trasformada_Wavelet_Correccion_Onda_PT)
        Me.TabPageEX3.Controls.Add(Me.CheckBox_Trasformada_Wavelet_Busqueda_Onda_PT)
        Me.TabPageEX3.Controls.Add(Me.CheckBox_Habilitar_Señal_Temporal_Filtrada)
        Me.TabPageEX3.Controls.Add(Me.TreeView_Graficar)
        Me.TabPageEX3.Controls.Add(Me.CheckBox_Habilitar_Trasformada_Wavelet_QRS)
        Me.TabPageEX3.Enabled = False
        Me.TabPageEX3.Location = New System.Drawing.Point(31, 4)
        Me.TabPageEX3.Name = "TabPageEX3"
        Me.TabPageEX3.Size = New System.Drawing.Size(316, 730)
        Me.TabPageEX3.TabIndex = 2
        Me.TabPageEX3.Text = "Points and Intervals"
        '
        'CheckBox_Habilitar_Trasformada_Wavelet_Correccion_Onda_PT
        '
        Me.CheckBox_Habilitar_Trasformada_Wavelet_Correccion_Onda_PT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_Habilitar_Trasformada_Wavelet_Correccion_Onda_PT.AutoSize = True
        Me.CheckBox_Habilitar_Trasformada_Wavelet_Correccion_Onda_PT.Location = New System.Drawing.Point(5, 701)
        Me.CheckBox_Habilitar_Trasformada_Wavelet_Correccion_Onda_PT.Margin = New System.Windows.Forms.Padding(5)
        Me.CheckBox_Habilitar_Trasformada_Wavelet_Correccion_Onda_PT.Name = "CheckBox_Habilitar_Trasformada_Wavelet_Correccion_Onda_PT"
        Me.CheckBox_Habilitar_Trasformada_Wavelet_Correccion_Onda_PT.Size = New System.Drawing.Size(239, 24)
        Me.CheckBox_Habilitar_Trasformada_Wavelet_Correccion_Onda_PT.TabIndex = 10
        Me.CheckBox_Habilitar_Trasformada_Wavelet_Correccion_Onda_PT.Text = "Plot TW P-T Wave Correction"
        Me.CheckBox_Habilitar_Trasformada_Wavelet_Correccion_Onda_PT.UseVisualStyleBackColor = True
        '
        'CheckBox_Trasformada_Wavelet_Busqueda_Onda_PT
        '
        Me.CheckBox_Trasformada_Wavelet_Busqueda_Onda_PT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_Trasformada_Wavelet_Busqueda_Onda_PT.AutoSize = True
        Me.CheckBox_Trasformada_Wavelet_Busqueda_Onda_PT.Location = New System.Drawing.Point(5, 676)
        Me.CheckBox_Trasformada_Wavelet_Busqueda_Onda_PT.Margin = New System.Windows.Forms.Padding(5)
        Me.CheckBox_Trasformada_Wavelet_Busqueda_Onda_PT.Name = "CheckBox_Trasformada_Wavelet_Busqueda_Onda_PT"
        Me.CheckBox_Trasformada_Wavelet_Busqueda_Onda_PT.Size = New System.Drawing.Size(243, 24)
        Me.CheckBox_Trasformada_Wavelet_Busqueda_Onda_PT.TabIndex = 9
        Me.CheckBox_Trasformada_Wavelet_Busqueda_Onda_PT.Text = "Plotting TW P-T Wave Search"
        Me.CheckBox_Trasformada_Wavelet_Busqueda_Onda_PT.UseVisualStyleBackColor = True
        '
        'CheckBox_Habilitar_Señal_Temporal_Filtrada
        '
        Me.CheckBox_Habilitar_Señal_Temporal_Filtrada.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_Habilitar_Señal_Temporal_Filtrada.AutoSize = True
        Me.CheckBox_Habilitar_Señal_Temporal_Filtrada.Location = New System.Drawing.Point(5, 626)
        Me.CheckBox_Habilitar_Señal_Temporal_Filtrada.Margin = New System.Windows.Forms.Padding(5)
        Me.CheckBox_Habilitar_Señal_Temporal_Filtrada.Name = "CheckBox_Habilitar_Señal_Temporal_Filtrada"
        Me.CheckBox_Habilitar_Señal_Temporal_Filtrada.Size = New System.Drawing.Size(249, 24)
        Me.CheckBox_Habilitar_Señal_Temporal_Filtrada.TabIndex = 8
        Me.CheckBox_Habilitar_Señal_Temporal_Filtrada.Text = "Plot Temporary Signal Filtering"
        Me.CheckBox_Habilitar_Señal_Temporal_Filtrada.UseVisualStyleBackColor = True
        '
        'TreeView_Graficar
        '
        Me.TreeView_Graficar.AllowDrop = True
        Me.TreeView_Graficar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView_Graficar.CheckBoxes = True
        Me.TreeView_Graficar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView_Graficar.FullRowSelect = True
        Me.TreeView_Graficar.ImageIndex = 0
        Me.TreeView_Graficar.ImageList = Me.ImageList1
        Me.TreeView_Graficar.Location = New System.Drawing.Point(0, 0)
        Me.TreeView_Graficar.Name = "TreeView_Graficar"
        TreeNode1.ImageIndex = 3
        TreeNode1.Name = "P_i"
        TreeNode1.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode1.SelectedImageKey = "Bullet-Green.png"
        TreeNode1.Text = "P_i"
        TreeNode2.ImageIndex = 1
        TreeNode2.Name = "P"
        TreeNode2.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode2.SelectedImageKey = "Bullet-Blue.png"
        TreeNode2.Text = "P"
        TreeNode3.ImageIndex = 8
        TreeNode3.Name = "P_f"
        TreeNode3.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode3.SelectedImageKey = "Bullet-Purple .png"
        TreeNode3.Text = "P_f"
        TreeNode4.ImageIndex = 12
        TreeNode4.Name = "Onda_P"
        TreeNode4.SelectedImageKey = "Aol-Mail.png"
        TreeNode4.Text = "P Wave"
        TreeNode5.ImageIndex = 5
        TreeNode5.Name = "Q_i"
        TreeNode5.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode5.SelectedImageKey = "Bullet-Orange.png"
        TreeNode5.Text = "Q_i"
        TreeNode6.ImageIndex = 6
        TreeNode6.Name = "Q"
        TreeNode6.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode6.SelectedImageKey = "Bullet-Orange1.png"
        TreeNode6.Text = "Q"
        TreeNode7.ImageIndex = 7
        TreeNode7.Name = "R"
        TreeNode7.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode7.SelectedImageKey = "Bullet-Pink.png"
        TreeNode7.Text = "R"
        TreeNode8.ImageIndex = 2
        TreeNode8.Name = "S"
        TreeNode8.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode8.SelectedImageKey = "Bullet-Blue1.png"
        TreeNode8.Text = "S"
        TreeNode9.ImageIndex = 10
        TreeNode9.Name = "J"
        TreeNode9.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode9.SelectedImageKey = "Bullet-Red.png"
        TreeNode9.Text = "J"
        TreeNode10.ImageIndex = 12
        TreeNode10.Name = "Complejo_QRS"
        TreeNode10.SelectedImageKey = "Aol-Mail.png"
        TreeNode10.Text = "QRS Complex"
        TreeNode11.ImageIndex = 11
        TreeNode11.Name = "T_i"
        TreeNode11.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode11.SelectedImageKey = "Bullet-Yellow.png"
        TreeNode11.Text = "T_i"
        TreeNode12.ImageIndex = 9
        TreeNode12.Name = "T"
        TreeNode12.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode12.SelectedImageKey = "Bullet-Purple.png"
        TreeNode12.Text = "T"
        TreeNode13.ImageIndex = 4
        TreeNode13.Name = "T_f"
        TreeNode13.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.857143!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode13.SelectedImageKey = "Bullet-Green-Olivo.png"
        TreeNode13.Text = "T_f"
        TreeNode14.ImageIndex = 12
        TreeNode14.Name = "Onda_T"
        TreeNode14.SelectedImageKey = "Aol-Mail.png"
        TreeNode14.Text = "T Wave"
        TreeNode15.ImageIndex = 13
        TreeNode15.Name = "Intervalo_R_R"
        TreeNode15.SelectedImageKey = "Document-Page-Next.png"
        TreeNode15.Text = "Intervalo R-R"
        TreeNode16.ImageIndex = 13
        TreeNode16.Name = "Intervalo_P_R"
        TreeNode16.SelectedImageKey = "Document-Page-Next.png"
        TreeNode16.Text = "Intervalo P-R"
        TreeNode17.ImageIndex = 13
        TreeNode17.Name = "Intervalo_Q_T"
        TreeNode17.SelectedImageKey = "Document-Page-Next.png"
        TreeNode17.Text = "Intervalo Q-T"
        TreeNode18.ImageIndex = 12
        TreeNode18.Name = "Intervalos"
        TreeNode18.SelectedImageKey = "Aol-Mail.png"
        TreeNode18.Text = "Intervals"
        Me.TreeView_Graficar.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode10, TreeNode14, TreeNode18})
        Me.TreeView_Graficar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TreeView_Graficar.SelectedImageIndex = 12
        Me.TreeView_Graficar.Size = New System.Drawing.Size(256, 618)
        Me.TreeView_Graficar.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Red
        Me.ImageList1.Images.SetKeyName(0, "Bullet-Black.png")
        Me.ImageList1.Images.SetKeyName(1, "Bullet-Blue.png")
        Me.ImageList1.Images.SetKeyName(2, "Bullet-Blue1.png")
        Me.ImageList1.Images.SetKeyName(3, "Bullet-Green.png")
        Me.ImageList1.Images.SetKeyName(4, "Bullet-Green-Olivo.png")
        Me.ImageList1.Images.SetKeyName(5, "Bullet-Orange.png")
        Me.ImageList1.Images.SetKeyName(6, "Bullet-Orange1.png")
        Me.ImageList1.Images.SetKeyName(7, "Bullet-Pink.png")
        Me.ImageList1.Images.SetKeyName(8, "Bullet-Purple .png")
        Me.ImageList1.Images.SetKeyName(9, "Bullet-Purple.png")
        Me.ImageList1.Images.SetKeyName(10, "Bullet-Red.png")
        Me.ImageList1.Images.SetKeyName(11, "Bullet-Yellow.png")
        Me.ImageList1.Images.SetKeyName(12, "Aol-Mail.png")
        Me.ImageList1.Images.SetKeyName(13, "Document-Page-Next.png")
        '
        'CheckBox_Habilitar_Trasformada_Wavelet_QRS
        '
        Me.CheckBox_Habilitar_Trasformada_Wavelet_QRS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_Habilitar_Trasformada_Wavelet_QRS.AutoSize = True
        Me.CheckBox_Habilitar_Trasformada_Wavelet_QRS.Location = New System.Drawing.Point(5, 652)
        Me.CheckBox_Habilitar_Trasformada_Wavelet_QRS.Margin = New System.Windows.Forms.Padding(5)
        Me.CheckBox_Habilitar_Trasformada_Wavelet_QRS.Name = "CheckBox_Habilitar_Trasformada_Wavelet_QRS"
        Me.CheckBox_Habilitar_Trasformada_Wavelet_QRS.Size = New System.Drawing.Size(129, 24)
        Me.CheckBox_Habilitar_Trasformada_Wavelet_QRS.TabIndex = 7
        Me.CheckBox_Habilitar_Trasformada_Wavelet_QRS.Text = "Plot TW QRS"
        Me.CheckBox_Habilitar_Trasformada_Wavelet_QRS.UseVisualStyleBackColor = True
        '
        'TabPageEX4
        '
        Me.TabPageEX4.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPageEX4.Enabled = False
        Me.TabPageEX4.Location = New System.Drawing.Point(31, 4)
        Me.TabPageEX4.Name = "TabPageEX4"
        Me.TabPageEX4.Size = New System.Drawing.Size(316, 730)
        Me.TabPageEX4.TabIndex = 3
        Me.TabPageEX4.Text = "Modify Points"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TabControlEX_Selecion_Ondas_Intervalos, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBox_Registro_Modificar, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DataGridView_Registro_Modificar, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel4, 0, 3)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(316, 730)
        Me.TableLayoutPanel2.TabIndex = 16
        '
        'TabControlEX_Selecion_Ondas_Intervalos
        '
        Me.TabControlEX_Selecion_Ondas_Intervalos.Appearance = Dotnetrix.Controls.TabAppearanceEX.FlatTab
        Me.TableLayoutPanel2.SetColumnSpan(Me.TabControlEX_Selecion_Ondas_Intervalos, 2)
        Me.TabControlEX_Selecion_Ondas_Intervalos.Controls.Add(Me.TabPageEX_Ondas)
        Me.TabControlEX_Selecion_Ondas_Intervalos.Controls.Add(Me.TabPageEX_Intervalos)
        Me.TabControlEX_Selecion_Ondas_Intervalos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlEX_Selecion_Ondas_Intervalos.Location = New System.Drawing.Point(5, 39)
        Me.TabControlEX_Selecion_Ondas_Intervalos.Margin = New System.Windows.Forms.Padding(5)
        Me.TabControlEX_Selecion_Ondas_Intervalos.Name = "TabControlEX_Selecion_Ondas_Intervalos"
        Me.TabControlEX_Selecion_Ondas_Intervalos.SelectedIndex = 0
        Me.TabControlEX_Selecion_Ondas_Intervalos.Size = New System.Drawing.Size(306, 95)
        Me.TabControlEX_Selecion_Ondas_Intervalos.TabIndex = 5
        Me.TabControlEX_Selecion_Ondas_Intervalos.UseVisualStyles = False
        '
        'TabPageEX_Ondas
        '
        Me.TabPageEX_Ondas.Controls.Add(Me.GroupBox_Ondas)
        Me.TabPageEX_Ondas.Location = New System.Drawing.Point(4, 29)
        Me.TabPageEX_Ondas.Margin = New System.Windows.Forms.Padding(5)
        Me.TabPageEX_Ondas.Name = "TabPageEX_Ondas"
        Me.TabPageEX_Ondas.Size = New System.Drawing.Size(298, 62)
        Me.TabPageEX_Ondas.TabIndex = 0
        Me.TabPageEX_Ondas.Text = "Waves"
        '
        'GroupBox_Ondas
        '
        Me.GroupBox_Ondas.AutoSize = True
        Me.GroupBox_Ondas.Controls.Add(Me.TextBox_Onda_Tabla_Max)
        Me.GroupBox_Ondas.Controls.Add(Me.TextBox_Onda_Tabla_Min)
        Me.GroupBox_Ondas.Controls.Add(Me.RadioButton_P)
        Me.GroupBox_Ondas.Controls.Add(Me.RadioButton_T)
        Me.GroupBox_Ondas.Controls.Add(Me.RadioButton_QRS)
        Me.GroupBox_Ondas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox_Ondas.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox_Ondas.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox_Ondas.Name = "GroupBox_Ondas"
        Me.GroupBox_Ondas.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox_Ondas.Size = New System.Drawing.Size(298, 62)
        Me.GroupBox_Ondas.TabIndex = 15
        Me.GroupBox_Ondas.TabStop = False
        '
        'TextBox_Onda_Tabla_Max
        '
        Me.TextBox_Onda_Tabla_Max.Location = New System.Drawing.Point(267, 22)
        Me.TextBox_Onda_Tabla_Max.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox_Onda_Tabla_Max.Name = "TextBox_Onda_Tabla_Max"
        Me.TextBox_Onda_Tabla_Max.Size = New System.Drawing.Size(51, 26)
        Me.TextBox_Onda_Tabla_Max.TabIndex = 17
        Me.TextBox_Onda_Tabla_Max.Text = "10"
        '
        'TextBox_Onda_Tabla_Min
        '
        Me.TextBox_Onda_Tabla_Min.Location = New System.Drawing.Point(200, 22)
        Me.TextBox_Onda_Tabla_Min.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox_Onda_Tabla_Min.Name = "TextBox_Onda_Tabla_Min"
        Me.TextBox_Onda_Tabla_Min.Size = New System.Drawing.Size(51, 26)
        Me.TextBox_Onda_Tabla_Min.TabIndex = 16
        Me.TextBox_Onda_Tabla_Min.Text = "0"
        '
        'RadioButton_P
        '
        Me.RadioButton_P.AutoSize = True
        Me.RadioButton_P.Location = New System.Drawing.Point(6, 22)
        Me.RadioButton_P.Name = "RadioButton_P"
        Me.RadioButton_P.Size = New System.Drawing.Size(44, 24)
        Me.RadioButton_P.TabIndex = 14
        Me.RadioButton_P.TabStop = True
        Me.RadioButton_P.Text = "P"
        Me.RadioButton_P.UseVisualStyleBackColor = True
        '
        'RadioButton_T
        '
        Me.RadioButton_T.AutoSize = True
        Me.RadioButton_T.Location = New System.Drawing.Point(150, 22)
        Me.RadioButton_T.Name = "RadioButton_T"
        Me.RadioButton_T.Size = New System.Drawing.Size(43, 24)
        Me.RadioButton_T.TabIndex = 14
        Me.RadioButton_T.TabStop = True
        Me.RadioButton_T.Text = "T"
        Me.RadioButton_T.UseVisualStyleBackColor = True
        '
        'RadioButton_QRS
        '
        Me.RadioButton_QRS.AutoSize = True
        Me.RadioButton_QRS.Checked = True
        Me.RadioButton_QRS.Location = New System.Drawing.Point(66, 22)
        Me.RadioButton_QRS.Name = "RadioButton_QRS"
        Me.RadioButton_QRS.Size = New System.Drawing.Size(69, 24)
        Me.RadioButton_QRS.TabIndex = 14
        Me.RadioButton_QRS.TabStop = True
        Me.RadioButton_QRS.Text = "QRS"
        Me.RadioButton_QRS.UseVisualStyleBackColor = True
        '
        'TabPageEX_Intervalos
        '
        Me.TabPageEX_Intervalos.Controls.Add(Me.GroupBox1)
        Me.TabPageEX_Intervalos.Location = New System.Drawing.Point(4, 29)
        Me.TabPageEX_Intervalos.Margin = New System.Windows.Forms.Padding(5)
        Me.TabPageEX_Intervalos.Name = "TabPageEX_Intervalos"
        Me.TabPageEX_Intervalos.Size = New System.Drawing.Size(298, 62)
        Me.TabPageEX_Intervalos.TabIndex = 1
        Me.TabPageEX_Intervalos.Text = "Intervals"
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Controls.Add(Me.TextBox_Intervalo_Tabla_Max)
        Me.GroupBox1.Controls.Add(Me.RadioButton_P_R)
        Me.GroupBox1.Controls.Add(Me.TextBox_Intervalo_Tabla_Min)
        Me.GroupBox1.Controls.Add(Me.RadioButton_Q_T)
        Me.GroupBox1.Controls.Add(Me.RadioButton_R_R)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Size = New System.Drawing.Size(298, 62)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'TextBox_Intervalo_Tabla_Max
        '
        Me.TextBox_Intervalo_Tabla_Max.Location = New System.Drawing.Point(276, 22)
        Me.TextBox_Intervalo_Tabla_Max.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox_Intervalo_Tabla_Max.Name = "TextBox_Intervalo_Tabla_Max"
        Me.TextBox_Intervalo_Tabla_Max.Size = New System.Drawing.Size(51, 26)
        Me.TextBox_Intervalo_Tabla_Max.TabIndex = 16
        Me.TextBox_Intervalo_Tabla_Max.Text = "480"
        '
        'RadioButton_P_R
        '
        Me.RadioButton_P_R.AutoSize = True
        Me.RadioButton_P_R.Location = New System.Drawing.Point(6, 22)
        Me.RadioButton_P_R.Name = "RadioButton_P_R"
        Me.RadioButton_P_R.Size = New System.Drawing.Size(61, 24)
        Me.RadioButton_P_R.TabIndex = 14
        Me.RadioButton_P_R.TabStop = True
        Me.RadioButton_P_R.Text = "P-R"
        Me.RadioButton_P_R.UseVisualStyleBackColor = True
        '
        'TextBox_Intervalo_Tabla_Min
        '
        Me.TextBox_Intervalo_Tabla_Min.Location = New System.Drawing.Point(221, 22)
        Me.TextBox_Intervalo_Tabla_Min.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox_Intervalo_Tabla_Min.Name = "TextBox_Intervalo_Tabla_Min"
        Me.TextBox_Intervalo_Tabla_Min.Size = New System.Drawing.Size(51, 26)
        Me.TextBox_Intervalo_Tabla_Min.TabIndex = 15
        Me.TextBox_Intervalo_Tabla_Min.Text = "0"
        '
        'RadioButton_Q_T
        '
        Me.RadioButton_Q_T.AutoSize = True
        Me.RadioButton_Q_T.Location = New System.Drawing.Point(150, 22)
        Me.RadioButton_Q_T.Name = "RadioButton_Q_T"
        Me.RadioButton_Q_T.Size = New System.Drawing.Size(60, 24)
        Me.RadioButton_Q_T.TabIndex = 14
        Me.RadioButton_Q_T.TabStop = True
        Me.RadioButton_Q_T.Text = "Q-T"
        Me.RadioButton_Q_T.UseVisualStyleBackColor = True
        '
        'RadioButton_R_R
        '
        Me.RadioButton_R_R.AutoSize = True
        Me.RadioButton_R_R.Checked = True
        Me.RadioButton_R_R.Location = New System.Drawing.Point(77, 22)
        Me.RadioButton_R_R.Name = "RadioButton_R_R"
        Me.RadioButton_R_R.Size = New System.Drawing.Size(63, 24)
        Me.RadioButton_R_R.TabIndex = 14
        Me.RadioButton_R_R.TabStop = True
        Me.RadioButton_R_R.Text = "R-R"
        Me.RadioButton_R_R.UseVisualStyleBackColor = True
        '
        'ComboBox_Registro_Modificar
        '
        Me.ComboBox_Registro_Modificar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBox_Registro_Modificar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Registro_Modificar.FormattingEnabled = True
        Me.ComboBox_Registro_Modificar.Location = New System.Drawing.Point(45, 5)
        Me.ComboBox_Registro_Modificar.Margin = New System.Windows.Forms.Padding(5)
        Me.ComboBox_Registro_Modificar.Name = "ComboBox_Registro_Modificar"
        Me.ComboBox_Registro_Modificar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox_Registro_Modificar.Size = New System.Drawing.Size(266, 28)
        Me.ComboBox_Registro_Modificar.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel_Color_Registro_Modificar)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel2.Size = New System.Drawing.Size(34, 27)
        Me.Panel2.TabIndex = 13
        '
        'Panel_Color_Registro_Modificar
        '
        Me.Panel_Color_Registro_Modificar.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Color_Registro_Modificar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Color_Registro_Modificar.Location = New System.Drawing.Point(3, 3)
        Me.Panel_Color_Registro_Modificar.Name = "Panel_Color_Registro_Modificar"
        Me.Panel_Color_Registro_Modificar.Size = New System.Drawing.Size(28, 21)
        Me.Panel_Color_Registro_Modificar.TabIndex = 10
        '
        'DataGridView_Registro_Modificar
        '
        Me.DataGridView_Registro_Modificar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView_Registro_Modificar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.142858!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView_Registro_Modificar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView_Registro_Modificar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel2.SetColumnSpan(Me.DataGridView_Registro_Modificar, 2)
        Me.DataGridView_Registro_Modificar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_Registro_Modificar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView_Registro_Modificar.Location = New System.Drawing.Point(3, 142)
        Me.DataGridView_Registro_Modificar.Name = "DataGridView_Registro_Modificar"
        Me.DataGridView_Registro_Modificar.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView_Registro_Modificar.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView_Registro_Modificar.RowHeadersWidth = 20
        Me.DataGridView_Registro_Modificar.RowTemplate.Height = 5
        Me.DataGridView_Registro_Modificar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView_Registro_Modificar.Size = New System.Drawing.Size(310, 485)
        Me.DataGridView_Registro_Modificar.TabIndex = 0
        '
        'Panel4
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Panel4, 2)
        Me.Panel4.Controls.Add(Me.Button_Actualizar_Cambios)
        Me.Panel4.Controls.Add(Me.Button_Modificar_Datos)
        Me.Panel4.Controls.Add(Me.Button_Agregar_Punto)
        Me.Panel4.Controls.Add(Me.Button_Eliminar_Ondas)
        Me.Panel4.Controls.Add(Me.Button_Buscar_Ondas)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 633)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(310, 94)
        Me.Panel4.TabIndex = 16
        '
        'Button_Actualizar_Cambios
        '
        Me.Button_Actualizar_Cambios.BackColor = System.Drawing.Color.Transparent
        Me.Button_Actualizar_Cambios.BackgroundImage = CType(resources.GetObject("Button_Actualizar_Cambios.BackgroundImage"), System.Drawing.Image)
        Me.Button_Actualizar_Cambios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Actualizar_Cambios.FlatAppearance.BorderSize = 0
        Me.Button_Actualizar_Cambios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Actualizar_Cambios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Actualizar_Cambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Actualizar_Cambios.ForeColor = System.Drawing.Color.Black
        Me.Button_Actualizar_Cambios.Location = New System.Drawing.Point(129, 51)
        Me.Button_Actualizar_Cambios.Margin = New System.Windows.Forms.Padding(5)
        Me.Button_Actualizar_Cambios.Name = "Button_Actualizar_Cambios"
        Me.Button_Actualizar_Cambios.Size = New System.Drawing.Size(88, 38)
        Me.Button_Actualizar_Cambios.TabIndex = 4
        Me.Button_Actualizar_Cambios.Text = "Update"
        Me.Button_Actualizar_Cambios.UseVisualStyleBackColor = False
        '
        'Button_Modificar_Datos
        '
        Me.Button_Modificar_Datos.BackColor = System.Drawing.Color.Transparent
        Me.Button_Modificar_Datos.BackgroundImage = CType(resources.GetObject("Button_Modificar_Datos.BackgroundImage"), System.Drawing.Image)
        Me.Button_Modificar_Datos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Modificar_Datos.FlatAppearance.BorderSize = 0
        Me.Button_Modificar_Datos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Modificar_Datos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Modificar_Datos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Modificar_Datos.ForeColor = System.Drawing.Color.Black
        Me.Button_Modificar_Datos.Location = New System.Drawing.Point(79, 3)
        Me.Button_Modificar_Datos.Margin = New System.Windows.Forms.Padding(5)
        Me.Button_Modificar_Datos.Name = "Button_Modificar_Datos"
        Me.Button_Modificar_Datos.Size = New System.Drawing.Size(96, 38)
        Me.Button_Modificar_Datos.TabIndex = 3
        Me.Button_Modificar_Datos.Text = "Modify"
        Me.Button_Modificar_Datos.UseVisualStyleBackColor = False
        '
        'Button_Agregar_Punto
        '
        Me.Button_Agregar_Punto.BackColor = System.Drawing.Color.Transparent
        Me.Button_Agregar_Punto.BackgroundImage = CType(resources.GetObject("Button_Agregar_Punto.BackgroundImage"), System.Drawing.Image)
        Me.Button_Agregar_Punto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Agregar_Punto.FlatAppearance.BorderSize = 0
        Me.Button_Agregar_Punto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Agregar_Punto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Agregar_Punto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Agregar_Punto.ForeColor = System.Drawing.Color.Black
        Me.Button_Agregar_Punto.Location = New System.Drawing.Point(177, 3)
        Me.Button_Agregar_Punto.Margin = New System.Windows.Forms.Padding(5)
        Me.Button_Agregar_Punto.Name = "Button_Agregar_Punto"
        Me.Button_Agregar_Punto.Size = New System.Drawing.Size(77, 38)
        Me.Button_Agregar_Punto.TabIndex = 3
        Me.Button_Agregar_Punto.Text = "Add"
        Me.Button_Agregar_Punto.UseVisualStyleBackColor = False
        '
        'Button_Eliminar_Ondas
        '
        Me.Button_Eliminar_Ondas.BackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Ondas.BackgroundImage = CType(resources.GetObject("Button_Eliminar_Ondas.BackgroundImage"), System.Drawing.Image)
        Me.Button_Eliminar_Ondas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Eliminar_Ondas.FlatAppearance.BorderSize = 0
        Me.Button_Eliminar_Ondas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Ondas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Ondas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Eliminar_Ondas.ForeColor = System.Drawing.Color.Black
        Me.Button_Eliminar_Ondas.Location = New System.Drawing.Point(-2, 3)
        Me.Button_Eliminar_Ondas.Margin = New System.Windows.Forms.Padding(5)
        Me.Button_Eliminar_Ondas.Name = "Button_Eliminar_Ondas"
        Me.Button_Eliminar_Ondas.Size = New System.Drawing.Size(77, 38)
        Me.Button_Eliminar_Ondas.TabIndex = 3
        Me.Button_Eliminar_Ondas.Text = "Delete"
        Me.Button_Eliminar_Ondas.UseVisualStyleBackColor = False
        '
        'Button_Buscar_Ondas
        '
        Me.Button_Buscar_Ondas.BackColor = System.Drawing.Color.Transparent
        Me.Button_Buscar_Ondas.BackgroundImage = CType(resources.GetObject("Button_Buscar_Ondas.BackgroundImage"), System.Drawing.Image)
        Me.Button_Buscar_Ondas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Buscar_Ondas.FlatAppearance.BorderSize = 0
        Me.Button_Buscar_Ondas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Buscar_Ondas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Buscar_Ondas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Buscar_Ondas.ForeColor = System.Drawing.Color.Black
        Me.Button_Buscar_Ondas.Location = New System.Drawing.Point(42, 51)
        Me.Button_Buscar_Ondas.Margin = New System.Windows.Forms.Padding(5)
        Me.Button_Buscar_Ondas.Name = "Button_Buscar_Ondas"
        Me.Button_Buscar_Ondas.Size = New System.Drawing.Size(77, 38)
        Me.Button_Buscar_Ondas.TabIndex = 3
        Me.Button_Buscar_Ondas.Text = "Search"
        Me.Button_Buscar_Ondas.UseVisualStyleBackColor = False
        '
        'UserControl_Modulo_Graficar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.SplitContainer_Modulo_Grafico)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "UserControl_Modulo_Graficar"
        Me.Size = New System.Drawing.Size(1350, 738)
        Me.TableLayoutPanel_Modulo_Grafico.ResumeLayout(False)
        Me.Panel_Control.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        CType(Me.Chart_Registro_Total, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart_Registro_Parcial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Modulo_Grafico.Panel1.ResumeLayout(False)
        Me.SplitContainer_Modulo_Grafico.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer_Modulo_Grafico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Modulo_Grafico.ResumeLayout(False)
        Me.TabControlEX_Modulo_Grafico_Control.ResumeLayout(False)
        Me.TabPageEX_Registros.ResumeLayout(False)
        Me.TabPageEX_Registros.PerformLayout()
        CType(Me.PictureBox_Usuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Registro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Paciente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageEX2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel_Color_Registro_Graficado_Fondo.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageEX3.ResumeLayout(False)
        Me.TabPageEX3.PerformLayout()
        Me.TabPageEX4.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TabControlEX_Selecion_Ondas_Intervalos.ResumeLayout(False)
        Me.TabPageEX_Ondas.ResumeLayout(False)
        Me.TabPageEX_Ondas.PerformLayout()
        Me.GroupBox_Ondas.ResumeLayout(False)
        Me.GroupBox_Ondas.PerformLayout()
        Me.TabPageEX_Intervalos.ResumeLayout(False)
        Me.TabPageEX_Intervalos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView_Registro_Modificar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel_Modulo_Grafico As TableLayoutPanel
    Friend WithEvents Panel_Control As Panel
    Friend WithEvents Chart_Registro_Total As DataVisualization.Charting.Chart
    Friend WithEvents Chart_Registro_Parcial As DataVisualization.Charting.Chart
    Friend WithEvents BackgroundWorker_Grafica As System.ComponentModel.BackgroundWorker
    Friend WithEvents TextBox_Registro_Parcial_Maximo As TextBox
    Friend WithEvents TextBox_Registro_Parcial_Minimo As TextBox
    Friend WithEvents Button_Borar_Registros As Button
    Friend WithEvents Button_Cerrar As Button
    Friend WithEvents ComboBox_Cuadricula_ECG_Ganancia As ComboBox
    Friend WithEvents ComboBox_Cuadricula_ECG_Velocidad As ComboBox
    Friend WithEvents ComboBox_Escala_Tiempo As ComboBox
    Friend WithEvents CheckBox_Bloquear_Ventana As CheckBox
    Friend WithEvents CheckBox_Cuadricula As CheckBox
    Friend WithEvents Button_Independizar_Ventana As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents CheckBox_Estilo_Linea As CheckBox
    Friend WithEvents SplitContainer_Modulo_Grafico As SplitContainer
    Friend WithEvents Button_Bloqueo_Ventana_SplitContainer_Modulo_Grafico_Panel1 As Button
    Friend WithEvents TabControlEX_Modulo_Grafico_Control As Dotnetrix.Controls.TabControlEX
    Friend WithEvents TabPageEX_Registros As Dotnetrix.Controls.TabPageEX
    Friend WithEvents Button_Graficar_Registro As Button
    Friend WithEvents PictureBox_Usuario As PictureBox
    Friend WithEvents ComboBox_Selecion_Usuario As ComboBox
    Friend WithEvents ComboBox_Selecion_Paciente As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox_Registro As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label_Usuario As Label
    Friend WithEvents Label_Registro As Label
    Friend WithEvents ComboBox_Selecionar_Derivacion As ComboBox
    Friend WithEvents PictureBox_Paciente As PictureBox
    Friend WithEvents ComboBox_Selecionar_Registro As ComboBox
    Friend WithEvents Label_Paciente As Label
    Friend WithEvents TabPageEX2 As Dotnetrix.Controls.TabPageEX
    Friend WithEvents ComboBox_Tamaño_Letra As ComboBox
    Friend WithEvents Panel_Color_Registro_Graficado_Fondo As Panel
    Friend WithEvents Panel_Color_Registro_Graficado As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox_Registro_Graficado As ComboBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Button_Borrar_Un_Registro As Button
    Friend WithEvents TabPageEX3 As Dotnetrix.Controls.TabPageEX
    Friend WithEvents CheckBox_Habilitar_Trasformada_Wavelet_QRS As CheckBox
    Friend WithEvents TabPageEX4 As Dotnetrix.Controls.TabPageEX
    Friend WithEvents TreeView_Graficar As TreeView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents DataGridView_Registro_Modificar As DataGridView
    Friend WithEvents Button_Agregar_Punto As Button
    Friend WithEvents Button_Buscar_Ondas As Button
    Friend WithEvents Button_Modificar_Datos As Button
    Friend WithEvents Button_Eliminar_Ondas As Button
    Friend WithEvents RadioButton_T As RadioButton
    Friend WithEvents RadioButton_QRS As RadioButton
    Friend WithEvents RadioButton_P As RadioButton
    Friend WithEvents ComboBox_Registro_Modificar As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel_Color_Registro_Modificar As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents RichTextBox_Datos_Paciente As RichTextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button_Actualizar_Cambios As Button
    Friend WithEvents TabControlEX_Selecion_Ondas_Intervalos As Dotnetrix.Controls.TabControlEX
    Friend WithEvents TabPageEX_Ondas As Dotnetrix.Controls.TabPageEX
    Friend WithEvents GroupBox_Ondas As GroupBox
    Friend WithEvents TabPageEX_Intervalos As Dotnetrix.Controls.TabPageEX
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton_P_R As RadioButton
    Friend WithEvents RadioButton_Q_T As RadioButton
    Friend WithEvents RadioButton_R_R As RadioButton
    Friend WithEvents TextBox_Intervalo_Tabla_Max As TextBox
    Friend WithEvents TextBox_Intervalo_Tabla_Min As TextBox
    Friend WithEvents TextBox_Onda_Tabla_Max As TextBox
    Friend WithEvents TextBox_Onda_Tabla_Min As TextBox
    Friend WithEvents CheckBox_Habilitar_Señal_Temporal_Filtrada As CheckBox
    Friend WithEvents CheckBox_Habilitar_Trasformada_Wavelet_Correccion_Onda_PT As CheckBox
    Friend WithEvents CheckBox_Trasformada_Wavelet_Busqueda_Onda_PT As CheckBox
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
End Class
