<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Modificar_Puntos_Registro
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Modificar_Puntos_Registro))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim StripLine1 As System.Windows.Forms.DataVisualization.Charting.StripLine = New System.Windows.Forms.DataVisualization.Charting.StripLine()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint1 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
        Dim DataPoint2 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.001R, 0R)
        Dim DataPoint3 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.002R, 0R)
        Dim DataPoint4 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.003R, 0.1R)
        Dim DataPoint5 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.004R, 0.3R)
        Dim DataPoint6 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.005R, 0.3R)
        Dim DataPoint7 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.006R, 0.1R)
        Dim DataPoint8 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.007R, 0R)
        Dim DataPoint9 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.008R, 0R)
        Dim DataPoint10 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.009R, -1.0R)
        Dim DataPoint11 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.01R, 4.0R)
        Dim DataPoint12 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.011R, -2.0R)
        Dim DataPoint13 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.012R, 0R)
        Dim DataPoint14 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.013R, 0R)
        Dim DataPoint15 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.014R, 0.2R)
        Dim DataPoint16 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.015R, 0.5R)
        Dim DataPoint17 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.016R, 0.5R)
        Dim DataPoint18 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.017R, 0.2R)
        Dim DataPoint19 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.018R, 0R)
        Dim DataPoint20 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0.1R, 0R)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox_ZOOM = New System.Windows.Forms.CheckBox()
        Me.ComboBox_Tipo_Onda_Modificar = New System.Windows.Forms.ComboBox()
        Me.NumericUpDown_Dato_5 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown_Dato_4 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown_Dato_3 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown_Dato_2 = New System.Windows.Forms.NumericUpDown()
        Me.Label_Dato_1 = New System.Windows.Forms.Label()
        Me.Label_Dato_4 = New System.Windows.Forms.Label()
        Me.Label_Dato_2 = New System.Windows.Forms.Label()
        Me.Label_Dato_3 = New System.Windows.Forms.Label()
        Me.Button_Actualizar = New System.Windows.Forms.Button()
        Me.Label_Dato_5 = New System.Windows.Forms.Label()
        Me.NumericUpDown_Dato_1 = New System.Windows.Forms.NumericUpDown()
        Me.CheckBox_Estilo_Linea = New System.Windows.Forms.CheckBox()
        Me.Button_Reset_Zoom = New System.Windows.Forms.Button()
        Me.Chart_Registro_Parcial = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.NumericUpDown_Dato_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_Dato_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_Dato_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_Dato_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_Dato_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart_Registro_Parcial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Size = New System.Drawing.Size(902, 478)
        Me.SplitContainer1.SplitterDistance = 294
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackgroundImage = Global.Bohíque_FMS.My.Resources.Resources.Fondo
        Me.SplitContainer2.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer2.Panel1.Controls.Add(Me.TableLayoutPanel1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Chart_Registro_Parcial)
        Me.SplitContainer2.Size = New System.Drawing.Size(902, 478)
        Me.SplitContainer2.SplitterDistance = 60
        Me.SplitContainer2.SplitterWidth = 3
        Me.SplitContainer2.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBox_ZOOM, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ComboBox_Tipo_Onda_Modificar, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDown_Dato_5, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDown_Dato_4, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDown_Dato_3, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDown_Dato_2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label_Dato_1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label_Dato_4, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label_Dato_2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label_Dato_3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button_Actualizar, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label_Dato_5, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.NumericUpDown_Dato_1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBox_Estilo_Linea, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button_Reset_Zoom, 7, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(902, 60)
        Me.TableLayoutPanel1.TabIndex = 15
        '
        'Button1
        '
        Me.Button1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.AutoSize = True
        Me.Button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(859, 35)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(39, 20)
        Me.Button1.TabIndex = 24
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CheckBox_ZOOM
        '
        Me.CheckBox_ZOOM.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_ZOOM.AutoSize = True
        Me.CheckBox_ZOOM.Location = New System.Drawing.Point(724, 5)
        Me.CheckBox_ZOOM.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBox_ZOOM.Name = "CheckBox_ZOOM"
        Me.CheckBox_ZOOM.Size = New System.Drawing.Size(76, 20)
        Me.CheckBox_ZOOM.TabIndex = 23
        Me.CheckBox_ZOOM.Text = "Zoom"
        Me.CheckBox_ZOOM.UseVisualStyleBackColor = True
        '
        'ComboBox_Tipo_Onda_Modificar
        '
        Me.ComboBox_Tipo_Onda_Modificar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_Tipo_Onda_Modificar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Tipo_Onda_Modificar.FormattingEnabled = True
        Me.ComboBox_Tipo_Onda_Modificar.Items.AddRange(New Object() {"Sin_QRS", "Qr", "qR", "Qrs", "qRs", "R", "Rs", "QS", "Qr_E", "Qrs_E", "qRs_E", "RS_E"})
        Me.ComboBox_Tipo_Onda_Modificar.Location = New System.Drawing.Point(544, 35)
        Me.ComboBox_Tipo_Onda_Modificar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComboBox_Tipo_Onda_Modificar.Name = "ComboBox_Tipo_Onda_Modificar"
        Me.ComboBox_Tipo_Onda_Modificar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox_Tipo_Onda_Modificar.Size = New System.Drawing.Size(172, 28)
        Me.ComboBox_Tipo_Onda_Modificar.TabIndex = 22
        '
        'NumericUpDown_Dato_5
        '
        Me.NumericUpDown_Dato_5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_Dato_5.DecimalPlaces = 4
        Me.NumericUpDown_Dato_5.Location = New System.Drawing.Point(435, 33)
        Me.NumericUpDown_Dato_5.Name = "NumericUpDown_Dato_5"
        Me.NumericUpDown_Dato_5.ReadOnly = True
        Me.NumericUpDown_Dato_5.Size = New System.Drawing.Size(102, 26)
        Me.NumericUpDown_Dato_5.TabIndex = 21
        Me.NumericUpDown_Dato_5.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'NumericUpDown_Dato_4
        '
        Me.NumericUpDown_Dato_4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_Dato_4.DecimalPlaces = 4
        Me.NumericUpDown_Dato_4.Location = New System.Drawing.Point(327, 33)
        Me.NumericUpDown_Dato_4.Name = "NumericUpDown_Dato_4"
        Me.NumericUpDown_Dato_4.ReadOnly = True
        Me.NumericUpDown_Dato_4.Size = New System.Drawing.Size(102, 26)
        Me.NumericUpDown_Dato_4.TabIndex = 20
        Me.NumericUpDown_Dato_4.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'NumericUpDown_Dato_3
        '
        Me.NumericUpDown_Dato_3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_Dato_3.DecimalPlaces = 4
        Me.NumericUpDown_Dato_3.Location = New System.Drawing.Point(219, 33)
        Me.NumericUpDown_Dato_3.Name = "NumericUpDown_Dato_3"
        Me.NumericUpDown_Dato_3.ReadOnly = True
        Me.NumericUpDown_Dato_3.Size = New System.Drawing.Size(102, 26)
        Me.NumericUpDown_Dato_3.TabIndex = 19
        Me.NumericUpDown_Dato_3.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'NumericUpDown_Dato_2
        '
        Me.NumericUpDown_Dato_2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_Dato_2.DecimalPlaces = 4
        Me.NumericUpDown_Dato_2.Location = New System.Drawing.Point(111, 33)
        Me.NumericUpDown_Dato_2.Name = "NumericUpDown_Dato_2"
        Me.NumericUpDown_Dato_2.ReadOnly = True
        Me.NumericUpDown_Dato_2.Size = New System.Drawing.Size(102, 26)
        Me.NumericUpDown_Dato_2.TabIndex = 18
        Me.NumericUpDown_Dato_2.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label_Dato_1
        '
        Me.Label_Dato_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label_Dato_1.AutoSize = True
        Me.Label_Dato_1.BackColor = System.Drawing.Color.Transparent
        Me.Label_Dato_1.Location = New System.Drawing.Point(3, 10)
        Me.Label_Dato_1.Name = "Label_Dato_1"
        Me.Label_Dato_1.Size = New System.Drawing.Size(33, 20)
        Me.Label_Dato_1.TabIndex = 5
        Me.Label_Dato_1.Text = "Q_i"
        '
        'Label_Dato_4
        '
        Me.Label_Dato_4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label_Dato_4.AutoSize = True
        Me.Label_Dato_4.BackColor = System.Drawing.Color.Transparent
        Me.Label_Dato_4.Location = New System.Drawing.Point(327, 10)
        Me.Label_Dato_4.Name = "Label_Dato_4"
        Me.Label_Dato_4.Size = New System.Drawing.Size(20, 20)
        Me.Label_Dato_4.TabIndex = 8
        Me.Label_Dato_4.Text = "S"
        '
        'Label_Dato_2
        '
        Me.Label_Dato_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label_Dato_2.AutoSize = True
        Me.Label_Dato_2.BackColor = System.Drawing.Color.Transparent
        Me.Label_Dato_2.Location = New System.Drawing.Point(111, 10)
        Me.Label_Dato_2.Name = "Label_Dato_2"
        Me.Label_Dato_2.Size = New System.Drawing.Size(21, 20)
        Me.Label_Dato_2.TabIndex = 6
        Me.Label_Dato_2.Text = "Q"
        '
        'Label_Dato_3
        '
        Me.Label_Dato_3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label_Dato_3.AutoSize = True
        Me.Label_Dato_3.BackColor = System.Drawing.Color.Transparent
        Me.Label_Dato_3.Location = New System.Drawing.Point(219, 10)
        Me.Label_Dato_3.Name = "Label_Dato_3"
        Me.Label_Dato_3.Size = New System.Drawing.Size(21, 20)
        Me.Label_Dato_3.TabIndex = 7
        Me.Label_Dato_3.Text = "R"
        '
        'Button_Actualizar
        '
        Me.Button_Actualizar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Button_Actualizar.BackColor = System.Drawing.Color.Transparent
        Me.Button_Actualizar.BackgroundImage = CType(resources.GetObject("Button_Actualizar.BackgroundImage"), System.Drawing.Image)
        Me.Button_Actualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Actualizar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_Actualizar.FlatAppearance.BorderSize = 0
        Me.Button_Actualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Actualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Actualizar.ForeColor = System.Drawing.Color.Black
        Me.Button_Actualizar.Location = New System.Drawing.Point(544, 5)
        Me.Button_Actualizar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button_Actualizar.Name = "Button_Actualizar"
        Me.Button_Actualizar.Size = New System.Drawing.Size(172, 20)
        Me.Button_Actualizar.TabIndex = 14
        Me.Button_Actualizar.Text = "Update"
        Me.Button_Actualizar.UseVisualStyleBackColor = False
        '
        'Label_Dato_5
        '
        Me.Label_Dato_5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label_Dato_5.AutoSize = True
        Me.Label_Dato_5.BackColor = System.Drawing.Color.Transparent
        Me.Label_Dato_5.Location = New System.Drawing.Point(435, 10)
        Me.Label_Dato_5.Name = "Label_Dato_5"
        Me.Label_Dato_5.Size = New System.Drawing.Size(17, 20)
        Me.Label_Dato_5.TabIndex = 9
        Me.Label_Dato_5.Text = "J"
        '
        'NumericUpDown_Dato_1
        '
        Me.NumericUpDown_Dato_1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_Dato_1.DecimalPlaces = 4
        Me.NumericUpDown_Dato_1.Location = New System.Drawing.Point(3, 33)
        Me.NumericUpDown_Dato_1.Name = "NumericUpDown_Dato_1"
        Me.NumericUpDown_Dato_1.ReadOnly = True
        Me.NumericUpDown_Dato_1.Size = New System.Drawing.Size(102, 26)
        Me.NumericUpDown_Dato_1.TabIndex = 17
        Me.NumericUpDown_Dato_1.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'CheckBox_Estilo_Linea
        '
        Me.CheckBox_Estilo_Linea.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_Estilo_Linea.AutoSize = True
        Me.CheckBox_Estilo_Linea.Checked = True
        Me.CheckBox_Estilo_Linea.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Estilo_Linea.Location = New System.Drawing.Point(724, 35)
        Me.CheckBox_Estilo_Linea.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CheckBox_Estilo_Linea.Name = "CheckBox_Estilo_Linea"
        Me.CheckBox_Estilo_Linea.Size = New System.Drawing.Size(109, 20)
        Me.CheckBox_Estilo_Linea.TabIndex = 15
        Me.CheckBox_Estilo_Linea.Text = "Show Line"
        Me.CheckBox_Estilo_Linea.UseVisualStyleBackColor = True
        '
        'Button_Reset_Zoom
        '
        Me.Button_Reset_Zoom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Reset_Zoom.AutoSize = True
        Me.Button_Reset_Zoom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Button_Reset_Zoom.BackColor = System.Drawing.Color.Transparent
        Me.Button_Reset_Zoom.BackgroundImage = CType(resources.GetObject("Button_Reset_Zoom.BackgroundImage"), System.Drawing.Image)
        Me.Button_Reset_Zoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Reset_Zoom.FlatAppearance.BorderSize = 0
        Me.Button_Reset_Zoom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Reset_Zoom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Reset_Zoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Reset_Zoom.ForeColor = System.Drawing.Color.Black
        Me.Button_Reset_Zoom.Location = New System.Drawing.Point(859, 5)
        Me.Button_Reset_Zoom.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button_Reset_Zoom.Name = "Button_Reset_Zoom"
        Me.Button_Reset_Zoom.Size = New System.Drawing.Size(39, 20)
        Me.Button_Reset_Zoom.TabIndex = 16
        Me.Button_Reset_Zoom.UseVisualStyleBackColor = False
        '
        'Chart_Registro_Parcial
        '
        ChartArea1.AxisX.InterlacedColor = System.Drawing.Color.White
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.LabelStyle.Format = "g4"
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisX.MajorGrid.Interval = 10.0R
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Maroon
        ChartArea1.AxisX.MajorGrid.LineWidth = 3
        ChartArea1.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea1.AxisX.MajorTickMark.LineWidth = 2
        ChartArea1.AxisX.MajorTickMark.Size = 2.0!
        ChartArea1.AxisX.MinorGrid.Interval = 5.0R
        ChartArea1.AxisX.MinorGrid.IntervalOffset = Double.NaN
        ChartArea1.AxisX.MinorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.NotSet
        ChartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.OrangeRed
        ChartArea1.AxisX.MinorTickMark.Interval = Double.NaN
        ChartArea1.AxisX.MinorTickMark.IntervalOffset = Double.NaN
        ChartArea1.AxisX.MinorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.NotSet
        ChartArea1.AxisX.ScaleBreakStyle.Enabled = True
        ChartArea1.AxisX2.IsLabelAutoFit = False
        ChartArea1.AxisX2.LabelStyle.Enabled = False
        ChartArea1.AxisX2.MajorTickMark.Enabled = False
        ChartArea1.AxisX2.MinorGrid.Enabled = True
        ChartArea1.AxisY.InterlacedColor = System.Drawing.Color.Transparent
        ChartArea1.AxisY.LabelStyle.Format = "g3"
        ChartArea1.AxisY.MajorGrid.Enabled = False
        ChartArea1.AxisY.MajorGrid.Interval = 2.0R
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Maroon
        ChartArea1.AxisY.MajorGrid.LineWidth = 3
        ChartArea1.AxisY.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea1.AxisY.MajorTickMark.LineWidth = 2
        ChartArea1.AxisY.MajorTickMark.Size = 0.5!
        ChartArea1.AxisY.MinorGrid.Interval = 1.0R
        ChartArea1.AxisY.MinorGrid.IntervalOffset = Double.NaN
        ChartArea1.AxisY.MinorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.NotSet
        ChartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.OrangeRed
        ChartArea1.AxisY.MinorTickMark.Interval = Double.NaN
        ChartArea1.AxisY.MinorTickMark.IntervalOffset = Double.NaN
        ChartArea1.AxisY.MinorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.NotSet
        ChartArea1.AxisY.MinorTickMark.Size = 0.25!
        StripLine1.StripWidth = 1.0R
        ChartArea1.AxisY.StripLines.Add(StripLine1)
        ChartArea1.AxisY2.IsLabelAutoFit = False
        ChartArea1.AxisY2.MajorTickMark.Enabled = False
        ChartArea1.AxisY2.MinorGrid.Enabled = True
        ChartArea1.Name = "ChartArea1"
        Me.Chart_Registro_Parcial.ChartAreas.Add(ChartArea1)
        Me.Chart_Registro_Parcial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Chart_Registro_Parcial.Location = New System.Drawing.Point(0, 0)
        Me.Chart_Registro_Parcial.Margin = New System.Windows.Forms.Padding(0)
        Me.Chart_Registro_Parcial.Name = "Chart_Registro_Parcial"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Name = "Series1"
        Series1.Points.Add(DataPoint1)
        Series1.Points.Add(DataPoint2)
        Series1.Points.Add(DataPoint3)
        Series1.Points.Add(DataPoint4)
        Series1.Points.Add(DataPoint5)
        Series1.Points.Add(DataPoint6)
        Series1.Points.Add(DataPoint7)
        Series1.Points.Add(DataPoint8)
        Series1.Points.Add(DataPoint9)
        Series1.Points.Add(DataPoint10)
        Series1.Points.Add(DataPoint11)
        Series1.Points.Add(DataPoint12)
        Series1.Points.Add(DataPoint13)
        Series1.Points.Add(DataPoint14)
        Series1.Points.Add(DataPoint15)
        Series1.Points.Add(DataPoint16)
        Series1.Points.Add(DataPoint17)
        Series1.Points.Add(DataPoint18)
        Series1.Points.Add(DataPoint19)
        Series1.Points.Add(DataPoint20)
        Me.Chart_Registro_Parcial.Series.Add(Series1)
        Me.Chart_Registro_Parcial.Size = New System.Drawing.Size(902, 415)
        Me.Chart_Registro_Parcial.TabIndex = 3
        '
        'Form_Modificar_Puntos_Registro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 478)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(510, 336)
        Me.Name = "Form_Modificar_Puntos_Registro"
        Me.Text = "Modify Record Points"
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.NumericUpDown_Dato_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_Dato_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_Dato_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_Dato_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_Dato_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart_Registro_Parcial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Chart_Registro_Parcial As DataVisualization.Charting.Chart
    Friend WithEvents Label_Dato_4 As Label
    Friend WithEvents Label_Dato_3 As Label
    Friend WithEvents Label_Dato_2 As Label
    Friend WithEvents Label_Dato_1 As Label
    Friend WithEvents Label_Dato_5 As Label
    Friend WithEvents Button_Actualizar As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents CheckBox_Estilo_Linea As CheckBox
    Friend WithEvents Button_Reset_Zoom As Button
    Friend WithEvents NumericUpDown_Dato_1 As NumericUpDown
    Friend WithEvents NumericUpDown_Dato_5 As NumericUpDown
    Friend WithEvents NumericUpDown_Dato_4 As NumericUpDown
    Friend WithEvents NumericUpDown_Dato_3 As NumericUpDown
    Friend WithEvents NumericUpDown_Dato_2 As NumericUpDown
    Friend WithEvents ComboBox_Tipo_Onda_Modificar As ComboBox
    Friend WithEvents CheckBox_ZOOM As CheckBox
    Friend WithEvents Button1 As Button
End Class
