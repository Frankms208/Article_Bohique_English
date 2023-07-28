<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Chart_Personalizado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Chart_Personalizado))
        Dim ChartArea5 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint17 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
        Dim DataPoint18 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(2.0R, 2.0R)
        Dim DataPoint19 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
        Dim ChartArea6 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim DataPoint20 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
        Dim DataPoint21 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(1.0R, 1.0R)
        Dim DataPoint22 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(2.0R, 2.0R)
        Dim DataPoint23 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(1.0R, 1.0R)
        Dim DataPoint24 As System.Windows.Forms.DataVisualization.Charting.DataPoint = New System.Windows.Forms.DataVisualization.Charting.DataPoint(0R, 0R)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TabControlEX1 = New Dotnetrix.Controls.TabControlEX()
        Me.TabPageEX1 = New Dotnetrix.Controls.TabPageEX()
        Me.TabPageEX2 = New Dotnetrix.Controls.TabPageEX()
        Me.SplitContainer_Principal = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer_Control = New System.Windows.Forms.SplitContainer()
        Me.CheckBox_Bloquear_Ventana = New System.Windows.Forms.CheckBox()
        Me.TextBox_Limite_Superior = New System.Windows.Forms.TextBox()
        Me.TextBox_Limite_Inferior = New System.Windows.Forms.TextBox()
        Me.ComboBox_Cuadricula_ECG_Velocidad = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Escala = New System.Windows.Forms.ComboBox()
        Me.Chart_Registro_Total = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.SplitContainer_Grafica = New System.Windows.Forms.SplitContainer()
        Me.Chart_Registro_Parcial = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label_Registro = New System.Windows.Forms.Label()
        Me.Label_Paciente = New System.Windows.Forms.Label()
        Me.Label_Usuario = New System.Windows.Forms.Label()
        Me.ComboBox__Registro = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Paciente = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Usuario = New System.Windows.Forms.ComboBox()
        Me.TabControlEX1.SuspendLayout()
        Me.TabPageEX1.SuspendLayout()
        Me.TabPageEX2.SuspendLayout()
        CType(Me.SplitContainer_Principal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_Principal.Panel1.SuspendLayout()
        Me.SplitContainer_Principal.Panel2.SuspendLayout()
        Me.SplitContainer_Principal.SuspendLayout()
        CType(Me.SplitContainer_Control, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_Control.Panel1.SuspendLayout()
        Me.SplitContainer_Control.Panel2.SuspendLayout()
        Me.SplitContainer_Control.SuspendLayout()
        CType(Me.Chart_Registro_Total, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer_Grafica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_Grafica.Panel1.SuspendLayout()
        Me.SplitContainer_Grafica.SuspendLayout()
        CType(Me.Chart_Registro_Parcial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'TabControlEX1
        '
        Me.TabControlEX1.Controls.Add(Me.TabPageEX1)
        Me.TabControlEX1.Controls.Add(Me.TabPageEX2)
        Me.TabControlEX1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlEX1.FlatBorderColor = System.Drawing.Color.Transparent
        Me.TabControlEX1.Location = New System.Drawing.Point(0, 0)
        Me.TabControlEX1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControlEX1.Name = "TabControlEX1"
        Me.TabControlEX1.SelectedIndex = 0
        Me.TabControlEX1.Size = New System.Drawing.Size(800, 400)
        Me.TabControlEX1.TabIndex = 2
        '
        'TabPageEX1
        '
        Me.TabPageEX1.Controls.Add(Me.SplitContainer_Principal)
        Me.TabPageEX1.Location = New System.Drawing.Point(4, 25)
        Me.TabPageEX1.Name = "TabPageEX1"
        Me.TabPageEX1.Size = New System.Drawing.Size(792, 371)
        Me.TabPageEX1.TabIndex = 0
        Me.TabPageEX1.Text = "TabPageEX1"
        '
        'TabPageEX2
        '
        Me.TabPageEX2.BackgroundImage = CType(resources.GetObject("TabPageEX2.BackgroundImage"), System.Drawing.Image)
        Me.TabPageEX2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.TabPageEX2.Controls.Add(Me.Label_Registro)
        Me.TabPageEX2.Controls.Add(Me.Label_Paciente)
        Me.TabPageEX2.Controls.Add(Me.Label_Usuario)
        Me.TabPageEX2.Controls.Add(Me.ComboBox__Registro)
        Me.TabPageEX2.Controls.Add(Me.ComboBox_Paciente)
        Me.TabPageEX2.Controls.Add(Me.ComboBox_Usuario)
        Me.TabPageEX2.Location = New System.Drawing.Point(4, 25)
        Me.TabPageEX2.Name = "TabPageEX2"
        Me.TabPageEX2.Size = New System.Drawing.Size(792, 371)
        Me.TabPageEX2.TabIndex = 1
        Me.TabPageEX2.Text = "TabPageEX2"
        '
        'SplitContainer_Principal
        '
        Me.SplitContainer_Principal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_Principal.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer_Principal.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_Principal.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer_Principal.Name = "SplitContainer_Principal"
        Me.SplitContainer_Principal.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer_Principal.Panel1
        '
        Me.SplitContainer_Principal.Panel1.Controls.Add(Me.SplitContainer_Control)
        Me.SplitContainer_Principal.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer_Principal.Panel2
        '
        Me.SplitContainer_Principal.Panel2.Controls.Add(Me.SplitContainer_Grafica)
        Me.SplitContainer_Principal.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer_Principal.Size = New System.Drawing.Size(792, 371)
        Me.SplitContainer_Principal.SplitterDistance = 100
        Me.SplitContainer_Principal.SplitterWidth = 1
        Me.SplitContainer_Principal.TabIndex = 2
        '
        'SplitContainer_Control
        '
        Me.SplitContainer_Control.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_Control.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer_Control.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_Control.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer_Control.Name = "SplitContainer_Control"
        Me.SplitContainer_Control.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer_Control.Panel1
        '
        Me.SplitContainer_Control.Panel1.BackgroundImage = CType(resources.GetObject("SplitContainer_Control.Panel1.BackgroundImage"), System.Drawing.Image)
        Me.SplitContainer_Control.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer_Control.Panel1.Controls.Add(Me.CheckBox_Bloquear_Ventana)
        Me.SplitContainer_Control.Panel1.Controls.Add(Me.TextBox_Limite_Superior)
        Me.SplitContainer_Control.Panel1.Controls.Add(Me.TextBox_Limite_Inferior)
        Me.SplitContainer_Control.Panel1.Controls.Add(Me.ComboBox_Cuadricula_ECG_Ganancia)
        Me.SplitContainer_Control.Panel1.Controls.Add(Me.ComboBox_Cuadricula_ECG_Velocidad)
        Me.SplitContainer_Control.Panel1.Controls.Add(Me.ComboBox_Escala)
        Me.SplitContainer_Control.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer_Control.Panel2
        '
        Me.SplitContainer_Control.Panel2.BackgroundImage = CType(resources.GetObject("SplitContainer_Control.Panel2.BackgroundImage"), System.Drawing.Image)
        Me.SplitContainer_Control.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer_Control.Panel2.Controls.Add(Me.Chart_Registro_Total)
        Me.SplitContainer_Control.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer_Control.Size = New System.Drawing.Size(792, 100)
        Me.SplitContainer_Control.SplitterDistance = 30
        Me.SplitContainer_Control.SplitterWidth = 1
        Me.SplitContainer_Control.TabIndex = 0
        '
        'CheckBox_Bloquear_Ventana
        '
        Me.CheckBox_Bloquear_Ventana.AutoSize = True
        Me.CheckBox_Bloquear_Ventana.Location = New System.Drawing.Point(136, 6)
        Me.CheckBox_Bloquear_Ventana.Name = "CheckBox_Bloquear_Ventana"
        Me.CheckBox_Bloquear_Ventana.Size = New System.Drawing.Size(111, 17)
        Me.CheckBox_Bloquear_Ventana.TabIndex = 2
        Me.CheckBox_Bloquear_Ventana.Text = "Bloquear Ventana"
        Me.CheckBox_Bloquear_Ventana.UseVisualStyleBackColor = True
        '
        'TextBox_Limite_Superior
        '
        Me.TextBox_Limite_Superior.Location = New System.Drawing.Point(90, 3)
        Me.TextBox_Limite_Superior.Name = "TextBox_Limite_Superior"
        Me.TextBox_Limite_Superior.Size = New System.Drawing.Size(39, 20)
        Me.TextBox_Limite_Superior.TabIndex = 1
        '
        'TextBox_Limite_Inferior
        '
        Me.TextBox_Limite_Inferior.Location = New System.Drawing.Point(45, 4)
        Me.TextBox_Limite_Inferior.Name = "TextBox_Limite_Inferior"
        Me.TextBox_Limite_Inferior.Size = New System.Drawing.Size(39, 20)
        Me.TextBox_Limite_Inferior.TabIndex = 1
        '
        'ComboBox_Cuadricula_ECG_Ganancia
        '
        Me.ComboBox_Cuadricula_ECG_Ganancia.FormattingEnabled = True
        Me.ComboBox_Cuadricula_ECG_Ganancia.Items.AddRange(New Object() {"2.5 mm/mV", "5 mm/mV", "10 mm/mV", "15 mm/mV", "20 mm/mV", "30 mm/mV"})
        Me.ComboBox_Cuadricula_ECG_Ganancia.Location = New System.Drawing.Point(315, 3)
        Me.ComboBox_Cuadricula_ECG_Ganancia.Name = "ComboBox_Cuadricula_ECG_Ganancia"
        Me.ComboBox_Cuadricula_ECG_Ganancia.Size = New System.Drawing.Size(56, 21)
        Me.ComboBox_Cuadricula_ECG_Ganancia.TabIndex = 0
        '
        'ComboBox_Cuadricula_ECG_Velocidad
        '
        Me.ComboBox_Cuadricula_ECG_Velocidad.FormattingEnabled = True
        Me.ComboBox_Cuadricula_ECG_Velocidad.Items.AddRange(New Object() {"12.5 mm/s", "25 mm/s", "37.5 mm/s", "50 mm/s", "75 mm/s", "100 mm/s"})
        Me.ComboBox_Cuadricula_ECG_Velocidad.Location = New System.Drawing.Point(253, 4)
        Me.ComboBox_Cuadricula_ECG_Velocidad.Name = "ComboBox_Cuadricula_ECG_Velocidad"
        Me.ComboBox_Cuadricula_ECG_Velocidad.Size = New System.Drawing.Size(56, 21)
        Me.ComboBox_Cuadricula_ECG_Velocidad.TabIndex = 0
        '
        'ComboBox_Escala
        '
        Me.ComboBox_Escala.FormattingEnabled = True
        Me.ComboBox_Escala.Items.AddRange(New Object() {"s", "min", "h"})
        Me.ComboBox_Escala.Location = New System.Drawing.Point(3, 3)
        Me.ComboBox_Escala.Name = "ComboBox_Escala"
        Me.ComboBox_Escala.Size = New System.Drawing.Size(36, 21)
        Me.ComboBox_Escala.TabIndex = 0
        '
        'Chart_Registro_Total
        '
        Me.Chart_Registro_Total.BackColor = System.Drawing.Color.Transparent
        ChartArea5.Name = "ChartArea1"
        Me.Chart_Registro_Total.ChartAreas.Add(ChartArea5)
        Me.Chart_Registro_Total.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Chart_Registro_Total.Location = New System.Drawing.Point(0, 0)
        Me.Chart_Registro_Total.Margin = New System.Windows.Forms.Padding(0)
        Me.Chart_Registro_Total.Name = "Chart_Registro_Total"
        Series5.ChartArea = "ChartArea1"
        Series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series5.Name = "Series1"
        Series5.Points.Add(DataPoint17)
        Series5.Points.Add(DataPoint18)
        Series5.Points.Add(DataPoint19)
        Me.Chart_Registro_Total.Series.Add(Series5)
        Me.Chart_Registro_Total.Size = New System.Drawing.Size(792, 69)
        Me.Chart_Registro_Total.TabIndex = 0
        Me.Chart_Registro_Total.Text = "Chart1"
        '
        'SplitContainer_Grafica
        '
        Me.SplitContainer_Grafica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_Grafica.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer_Grafica.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_Grafica.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer_Grafica.Name = "SplitContainer_Grafica"
        Me.SplitContainer_Grafica.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer_Grafica.Panel1
        '
        Me.SplitContainer_Grafica.Panel1.BackgroundImage = CType(resources.GetObject("SplitContainer_Grafica.Panel1.BackgroundImage"), System.Drawing.Image)
        Me.SplitContainer_Grafica.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer_Grafica.Panel1.Controls.Add(Me.Chart_Registro_Parcial)
        Me.SplitContainer_Grafica.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer_Grafica.Panel1MinSize = 30
        '
        'SplitContainer_Grafica.Panel2
        '
        Me.SplitContainer_Grafica.Panel2.BackgroundImage = CType(resources.GetObject("SplitContainer_Grafica.Panel2.BackgroundImage"), System.Drawing.Image)
        Me.SplitContainer_Grafica.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer_Grafica.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer_Grafica.Size = New System.Drawing.Size(792, 270)
        Me.SplitContainer_Grafica.SplitterDistance = 212
        Me.SplitContainer_Grafica.SplitterWidth = 1
        Me.SplitContainer_Grafica.TabIndex = 0
        '
        'Chart_Registro_Parcial
        '
        Me.Chart_Registro_Parcial.BackColor = System.Drawing.Color.Transparent
        Me.Chart_Registro_Parcial.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea6.Name = "ChartArea1"
        Me.Chart_Registro_Parcial.ChartAreas.Add(ChartArea6)
        Me.Chart_Registro_Parcial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Chart_Registro_Parcial.Location = New System.Drawing.Point(0, 0)
        Me.Chart_Registro_Parcial.Name = "Chart_Registro_Parcial"
        Series6.ChartArea = "ChartArea1"
        Series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series6.Name = "Series1"
        Series6.Points.Add(DataPoint20)
        Series6.Points.Add(DataPoint21)
        Series6.Points.Add(DataPoint22)
        Series6.Points.Add(DataPoint23)
        Series6.Points.Add(DataPoint24)
        Me.Chart_Registro_Parcial.Series.Add(Series6)
        Me.Chart_Registro_Parcial.Size = New System.Drawing.Size(792, 212)
        Me.Chart_Registro_Parcial.TabIndex = 0
        Me.Chart_Registro_Parcial.Text = "Chart2"
        '
        'Label_Registro
        '
        Me.Label_Registro.AutoSize = True
        Me.Label_Registro.Location = New System.Drawing.Point(126, 161)
        Me.Label_Registro.Name = "Label_Registro"
        Me.Label_Registro.Size = New System.Drawing.Size(43, 13)
        Me.Label_Registro.TabIndex = 5
        Me.Label_Registro.Text = "Usuario"
        '
        'Label_Paciente
        '
        Me.Label_Paciente.AutoSize = True
        Me.Label_Paciente.Location = New System.Drawing.Point(126, 107)
        Me.Label_Paciente.Name = "Label_Paciente"
        Me.Label_Paciente.Size = New System.Drawing.Size(49, 13)
        Me.Label_Paciente.TabIndex = 6
        Me.Label_Paciente.Text = "Paciente"
        '
        'Label_Usuario
        '
        Me.Label_Usuario.AutoSize = True
        Me.Label_Usuario.Location = New System.Drawing.Point(126, 59)
        Me.Label_Usuario.Name = "Label_Usuario"
        Me.Label_Usuario.Size = New System.Drawing.Size(43, 13)
        Me.Label_Usuario.TabIndex = 7
        Me.Label_Usuario.Text = "Usuario"
        '
        'ComboBox__Registro
        '
        Me.ComboBox__Registro.FormattingEnabled = True
        Me.ComboBox__Registro.Location = New System.Drawing.Point(126, 180)
        Me.ComboBox__Registro.Name = "ComboBox__Registro"
        Me.ComboBox__Registro.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox__Registro.TabIndex = 2
        '
        'ComboBox_Paciente
        '
        Me.ComboBox_Paciente.FormattingEnabled = True
        Me.ComboBox_Paciente.Location = New System.Drawing.Point(126, 126)
        Me.ComboBox_Paciente.Name = "ComboBox_Paciente"
        Me.ComboBox_Paciente.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox_Paciente.TabIndex = 3
        '
        'ComboBox_Usuario
        '
        Me.ComboBox_Usuario.FormattingEnabled = True
        Me.ComboBox_Usuario.Location = New System.Drawing.Point(126, 78)
        Me.ComboBox_Usuario.Name = "ComboBox_Usuario"
        Me.ComboBox_Usuario.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox_Usuario.TabIndex = 4
        '
        'Chart_Personalizado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Controls.Add(Me.TabControlEX1)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "Chart_Personalizado"
        Me.Size = New System.Drawing.Size(800, 400)
        Me.TabControlEX1.ResumeLayout(False)
        Me.TabPageEX1.ResumeLayout(False)
        Me.TabPageEX2.ResumeLayout(False)
        Me.TabPageEX2.PerformLayout()
        Me.SplitContainer_Principal.Panel1.ResumeLayout(False)
        Me.SplitContainer_Principal.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer_Principal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Principal.ResumeLayout(False)
        Me.SplitContainer_Control.Panel1.ResumeLayout(False)
        Me.SplitContainer_Control.Panel1.PerformLayout()
        Me.SplitContainer_Control.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer_Control, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Control.ResumeLayout(False)
        CType(Me.Chart_Registro_Total, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Grafica.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer_Grafica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Grafica.ResumeLayout(False)
        CType(Me.Chart_Registro_Parcial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents TabControlEX1 As Dotnetrix.Controls.TabControlEX
    Friend WithEvents TabPageEX1 As Dotnetrix.Controls.TabPageEX
    Friend WithEvents SplitContainer_Principal As SplitContainer
    Friend WithEvents SplitContainer_Control As SplitContainer
    Friend WithEvents CheckBox_Bloquear_Ventana As CheckBox
    Friend WithEvents TextBox_Limite_Superior As TextBox
    Friend WithEvents TextBox_Limite_Inferior As TextBox

    Friend WithEvents ComboBox_Cuadricula_ECG_Velocidad As ComboBox
    Friend WithEvents ComboBox_Cuadricula_ECG_Ganancia As ComboBox
    Friend WithEvents ComboBox_Escala As ComboBox
    Friend WithEvents Chart_Registro_Total As DataVisualization.Charting.Chart
    Friend WithEvents SplitContainer_Grafica As SplitContainer
    Friend WithEvents Chart_Registro_Parcial As DataVisualization.Charting.Chart
    Friend WithEvents TabPageEX2 As Dotnetrix.Controls.TabPageEX
    Friend WithEvents Label_Registro As Label
    Friend WithEvents Label_Paciente As Label
    Friend WithEvents Label_Usuario As Label
    Friend WithEvents ComboBox__Registro As ComboBox
    Friend WithEvents ComboBox_Paciente As ComboBox
    Friend WithEvents ComboBox_Usuario As ComboBox
End Class
