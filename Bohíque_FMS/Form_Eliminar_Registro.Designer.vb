<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Eliminar_Registro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Eliminar_Registro))
        Me.ComboBox_Selecion_Paciente = New System.Windows.Forms.ComboBox()
        Me.TextBox_Contraseña = New System.Windows.Forms.TextBox()
        Me.Label_Paciente = New System.Windows.Forms.Label()
        Me.Label_Contraseña = New System.Windows.Forms.Label()
        Me.ComboBox_Selecion_Usuario = New System.Windows.Forms.ComboBox()
        Me.Label_Usuario = New System.Windows.Forms.Label()
        Me.CheckBox_Mostrar_Contraseña = New System.Windows.Forms.CheckBox()
        Me.Label_Registro = New System.Windows.Forms.Label()
        Me.ComboBox_Selecionar_Registro = New System.Windows.Forms.ComboBox()
        Me.Button_Eliminar_Registro = New System.Windows.Forms.Button()
        Me.PictureBox_Usuario = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Contraseña = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Registro = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Paciente = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox_Usuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Contraseña, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Registro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Paciente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox_Selecion_Paciente
        '
        Me.ComboBox_Selecion_Paciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Selecion_Paciente.FormattingEnabled = True
        Me.ComboBox_Selecion_Paciente.Location = New System.Drawing.Point(54, 208)
        Me.ComboBox_Selecion_Paciente.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.ComboBox_Selecion_Paciente.Name = "ComboBox_Selecion_Paciente"
        Me.ComboBox_Selecion_Paciente.Size = New System.Drawing.Size(355, 32)
        Me.ComboBox_Selecion_Paciente.TabIndex = 2
        '
        'TextBox_Contraseña
        '
        Me.TextBox_Contraseña.Location = New System.Drawing.Point(54, 424)
        Me.TextBox_Contraseña.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.TextBox_Contraseña.MaxLength = 20
        Me.TextBox_Contraseña.Name = "TextBox_Contraseña"
        Me.TextBox_Contraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Contraseña.Size = New System.Drawing.Size(352, 29)
        Me.TextBox_Contraseña.TabIndex = 4
        '
        'Label_Paciente
        '
        Me.Label_Paciente.AutoSize = True
        Me.Label_Paciente.BackColor = System.Drawing.Color.Transparent
        Me.Label_Paciente.Location = New System.Drawing.Point(116, 164)
        Me.Label_Paciente.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Paciente.Name = "Label_Paciente"
        Me.Label_Paciente.Size = New System.Drawing.Size(72, 25)
        Me.Label_Paciente.TabIndex = 4
        Me.Label_Paciente.Text = "Patient"
        '
        'Label_Contraseña
        '
        Me.Label_Contraseña.AutoSize = True
        Me.Label_Contraseña.BackColor = System.Drawing.Color.Transparent
        Me.Label_Contraseña.Location = New System.Drawing.Point(116, 378)
        Me.Label_Contraseña.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Contraseña.Name = "Label_Contraseña"
        Me.Label_Contraseña.Size = New System.Drawing.Size(98, 25)
        Me.Label_Contraseña.TabIndex = 5
        Me.Label_Contraseña.Text = "Password"
        '
        'ComboBox_Selecion_Usuario
        '
        Me.ComboBox_Selecion_Usuario.CausesValidation = False
        Me.ComboBox_Selecion_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Selecion_Usuario.FormattingEnabled = True
        Me.ComboBox_Selecion_Usuario.Location = New System.Drawing.Point(54, 98)
        Me.ComboBox_Selecion_Usuario.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.ComboBox_Selecion_Usuario.Name = "ComboBox_Selecion_Usuario"
        Me.ComboBox_Selecion_Usuario.Size = New System.Drawing.Size(355, 32)
        Me.ComboBox_Selecion_Usuario.TabIndex = 1
        '
        'Label_Usuario
        '
        Me.Label_Usuario.AutoSize = True
        Me.Label_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.Label_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label_Usuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label_Usuario.Location = New System.Drawing.Point(116, 54)
        Me.Label_Usuario.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Usuario.Name = "Label_Usuario"
        Me.Label_Usuario.Size = New System.Drawing.Size(53, 25)
        Me.Label_Usuario.TabIndex = 3
        Me.Label_Usuario.Text = "User"
        '
        'CheckBox_Mostrar_Contraseña
        '
        Me.CheckBox_Mostrar_Contraseña.AutoSize = True
        Me.CheckBox_Mostrar_Contraseña.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_Mostrar_Contraseña.Location = New System.Drawing.Point(54, 472)
        Me.CheckBox_Mostrar_Contraseña.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.CheckBox_Mostrar_Contraseña.Name = "CheckBox_Mostrar_Contraseña"
        Me.CheckBox_Mostrar_Contraseña.Size = New System.Drawing.Size(177, 29)
        Me.CheckBox_Mostrar_Contraseña.TabIndex = 5
        Me.CheckBox_Mostrar_Contraseña.Text = "Show password"
        Me.CheckBox_Mostrar_Contraseña.UseVisualStyleBackColor = False
        '
        'Label_Registro
        '
        Me.Label_Registro.AutoSize = True
        Me.Label_Registro.BackColor = System.Drawing.Color.Transparent
        Me.Label_Registro.Location = New System.Drawing.Point(116, 272)
        Me.Label_Registro.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Registro.Name = "Label_Registro"
        Me.Label_Registro.Size = New System.Drawing.Size(74, 25)
        Me.Label_Registro.TabIndex = 4
        Me.Label_Registro.Text = "Record"
        '
        'ComboBox_Selecionar_Registro
        '
        Me.ComboBox_Selecionar_Registro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Selecionar_Registro.FormattingEnabled = True
        Me.ComboBox_Selecionar_Registro.Location = New System.Drawing.Point(54, 318)
        Me.ComboBox_Selecionar_Registro.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.ComboBox_Selecionar_Registro.Name = "ComboBox_Selecionar_Registro"
        Me.ComboBox_Selecionar_Registro.Size = New System.Drawing.Size(355, 32)
        Me.ComboBox_Selecionar_Registro.TabIndex = 3
        '
        'Button_Eliminar_Registro
        '
        Me.Button_Eliminar_Registro.BackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Registro.BackgroundImage = Global.Bohíque_FMS.My.Resources.Resources.Boton_Verde
        Me.Button_Eliminar_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Eliminar_Registro.FlatAppearance.BorderSize = 0
        Me.Button_Eliminar_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Registro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Eliminar_Registro.ForeColor = System.Drawing.Color.Black
        Me.Button_Eliminar_Registro.Location = New System.Drawing.Point(147, 514)
        Me.Button_Eliminar_Registro.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Button_Eliminar_Registro.Name = "Button_Eliminar_Registro"
        Me.Button_Eliminar_Registro.Size = New System.Drawing.Size(143, 58)
        Me.Button_Eliminar_Registro.TabIndex = 6
        Me.Button_Eliminar_Registro.Text = "Delete"
        Me.Button_Eliminar_Registro.UseVisualStyleBackColor = False
        '
        'PictureBox_Usuario
        '
        Me.PictureBox_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Usuario.BackgroundImage = CType(resources.GetObject("PictureBox_Usuario.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Usuario.Location = New System.Drawing.Point(54, 38)
        Me.PictureBox_Usuario.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Usuario.Name = "PictureBox_Usuario"
        Me.PictureBox_Usuario.Size = New System.Drawing.Size(55, 56)
        Me.PictureBox_Usuario.TabIndex = 6
        Me.PictureBox_Usuario.TabStop = False
        '
        'PictureBox_Contraseña
        '
        Me.PictureBox_Contraseña.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Contraseña.BackgroundImage = CType(resources.GetObject("PictureBox_Contraseña.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Contraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Contraseña.Location = New System.Drawing.Point(54, 362)
        Me.PictureBox_Contraseña.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Contraseña.Name = "PictureBox_Contraseña"
        Me.PictureBox_Contraseña.Size = New System.Drawing.Size(55, 56)
        Me.PictureBox_Contraseña.TabIndex = 6
        Me.PictureBox_Contraseña.TabStop = False
        '
        'PictureBox_Registro
        '
        Me.PictureBox_Registro.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Registro.BackgroundImage = CType(resources.GetObject("PictureBox_Registro.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Registro.Location = New System.Drawing.Point(54, 254)
        Me.PictureBox_Registro.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Registro.Name = "PictureBox_Registro"
        Me.PictureBox_Registro.Size = New System.Drawing.Size(55, 56)
        Me.PictureBox_Registro.TabIndex = 6
        Me.PictureBox_Registro.TabStop = False
        '
        'PictureBox_Paciente
        '
        Me.PictureBox_Paciente.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Paciente.BackgroundImage = CType(resources.GetObject("PictureBox_Paciente.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Paciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Paciente.Location = New System.Drawing.Point(54, 146)
        Me.PictureBox_Paciente.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Paciente.Name = "PictureBox_Paciente"
        Me.PictureBox_Paciente.Size = New System.Drawing.Size(55, 56)
        Me.PictureBox_Paciente.TabIndex = 6
        Me.PictureBox_Paciente.TabStop = False
        '
        'Form_Eliminar_Registro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(461, 638)
        Me.Controls.Add(Me.CheckBox_Mostrar_Contraseña)
        Me.Controls.Add(Me.Button_Eliminar_Registro)
        Me.Controls.Add(Me.PictureBox_Usuario)
        Me.Controls.Add(Me.ComboBox_Selecionar_Registro)
        Me.Controls.Add(Me.ComboBox_Selecion_Paciente)
        Me.Controls.Add(Me.Label_Usuario)
        Me.Controls.Add(Me.TextBox_Contraseña)
        Me.Controls.Add(Me.Label_Registro)
        Me.Controls.Add(Me.PictureBox_Contraseña)
        Me.Controls.Add(Me.Label_Paciente)
        Me.Controls.Add(Me.ComboBox_Selecion_Usuario)
        Me.Controls.Add(Me.PictureBox_Registro)
        Me.Controls.Add(Me.Label_Contraseña)
        Me.Controls.Add(Me.PictureBox_Paciente)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "Form_Eliminar_Registro"
        Me.Text = "Delete Record"
        CType(Me.PictureBox_Usuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Contraseña, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Registro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Paciente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBox_Selecion_Paciente As ComboBox
    Friend WithEvents Button_Eliminar_Registro As Button
    Friend WithEvents TextBox_Contraseña As TextBox
    Friend WithEvents Label_Paciente As Label
    Friend WithEvents Label_Contraseña As Label
    Friend WithEvents PictureBox_Paciente As PictureBox
    Friend WithEvents ComboBox_Selecion_Usuario As ComboBox
    Friend WithEvents PictureBox_Contraseña As PictureBox
    Friend WithEvents Label_Usuario As Label
    Friend WithEvents PictureBox_Usuario As PictureBox
    Friend WithEvents CheckBox_Mostrar_Contraseña As CheckBox
    Friend WithEvents PictureBox_Registro As PictureBox
    Friend WithEvents Label_Registro As Label
    Friend WithEvents ComboBox_Selecionar_Registro As ComboBox
End Class
