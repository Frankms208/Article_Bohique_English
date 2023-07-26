<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Cargar_Registro
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Cargar_Registro))
        Me.OpenFileDialog_Buscar_Registro = New System.Windows.Forms.OpenFileDialog()
        Me.Button_Buscar_Registro = New System.Windows.Forms.Button()
        Me.ProgressBar_Cargar_Registro = New System.Windows.Forms.ProgressBar()
        Me.BackgroundWorker_Cargar_Registro = New System.ComponentModel.BackgroundWorker()
        Me.Label_Estado_Carga_Registro = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'OpenFileDialog_Buscar_Registro
        '
        Me.OpenFileDialog_Buscar_Registro.Filter = "ECGa|*.ecga|ECGb|*.ecgb|ECGc|*.ecgc"
        Me.OpenFileDialog_Buscar_Registro.Multiselect = True
        Me.OpenFileDialog_Buscar_Registro.Title = "Cargar Registro"
        '
        'Button_Buscar_Registro
        '
        Me.Button_Buscar_Registro.BackColor = System.Drawing.Color.Transparent
        Me.Button_Buscar_Registro.BackgroundImage = Global.Bohíque_FMS.My.Resources.Resources.Boton_Verde
        Me.Button_Buscar_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Buscar_Registro.FlatAppearance.BorderSize = 0
        Me.Button_Buscar_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Buscar_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Buscar_Registro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Buscar_Registro.ForeColor = System.Drawing.Color.Black
        Me.Button_Buscar_Registro.Location = New System.Drawing.Point(110, 15)
        Me.Button_Buscar_Registro.Margin = New System.Windows.Forms.Padding(6)
        Me.Button_Buscar_Registro.Name = "Button_Buscar_Registro"
        Me.Button_Buscar_Registro.Size = New System.Drawing.Size(165, 59)
        Me.Button_Buscar_Registro.TabIndex = 1
        Me.Button_Buscar_Registro.Text = "Search Record"
        Me.Button_Buscar_Registro.UseVisualStyleBackColor = False
        '
        'ProgressBar_Cargar_Registro
        '
        Me.ProgressBar_Cargar_Registro.Location = New System.Drawing.Point(86, 110)
        Me.ProgressBar_Cargar_Registro.Margin = New System.Windows.Forms.Padding(6)
        Me.ProgressBar_Cargar_Registro.Name = "ProgressBar_Cargar_Registro"
        Me.ProgressBar_Cargar_Registro.Size = New System.Drawing.Size(207, 33)
        Me.ProgressBar_Cargar_Registro.TabIndex = 2
        '
        'BackgroundWorker_Cargar_Registro
        '
        Me.BackgroundWorker_Cargar_Registro.WorkerReportsProgress = True
        Me.BackgroundWorker_Cargar_Registro.WorkerSupportsCancellation = True
        '
        'Label_Estado_Carga_Registro
        '
        Me.Label_Estado_Carga_Registro.AutoSize = True
        Me.Label_Estado_Carga_Registro.BackColor = System.Drawing.Color.Transparent
        Me.Label_Estado_Carga_Registro.Location = New System.Drawing.Point(111, 80)
        Me.Label_Estado_Carga_Registro.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Estado_Carga_Registro.Name = "Label_Estado_Carga_Registro"
        Me.Label_Estado_Carga_Registro.Size = New System.Drawing.Size(142, 25)
        Me.Label_Estado_Carga_Registro.TabIndex = 8
        Me.Label_Estado_Carga_Registro.Text = "Search Record"
        '
        'Form_Cargar_Registro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(408, 158)
        Me.Controls.Add(Me.Label_Estado_Carga_Registro)
        Me.Controls.Add(Me.ProgressBar_Cargar_Registro)
        Me.Controls.Add(Me.Button_Buscar_Registro)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "Form_Cargar_Registro"
        Me.Text = "Search Record"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog_Buscar_Registro As OpenFileDialog
    Friend WithEvents Button_Buscar_Registro As Button
    Friend WithEvents ProgressBar_Cargar_Registro As ProgressBar
    Friend WithEvents BackgroundWorker_Cargar_Registro As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label_Estado_Carga_Registro As Label
End Class
