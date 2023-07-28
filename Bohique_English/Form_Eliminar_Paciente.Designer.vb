<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Eliminar_Paciente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Eliminar_Paciente))
        Me.Label_Seleccion_Usuario = New System.Windows.Forms.Label()
        Me.TextBox_Contraseña_Confirmacion = New System.Windows.Forms.TextBox()
        Me.ComboBox_Selecion_Usuario = New System.Windows.Forms.ComboBox()
        Me.Label_Contraseña_Confirmacion = New System.Windows.Forms.Label()
        Me.Button_Eliminar_Usuario = New System.Windows.Forms.Button()
        Me.PictureBox_Seleccion_Usuario = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Contraseña = New System.Windows.Forms.PictureBox()
        Me.ComboBox_Seleccion_Eliminar_Paciente = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox_Seleccion_Usuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Contraseña, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label_Seleccion_Usuario
        '
        Me.Label_Seleccion_Usuario.AutoSize = True
        Me.Label_Seleccion_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.Label_Seleccion_Usuario.Location = New System.Drawing.Point(92, 46)
        Me.Label_Seleccion_Usuario.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label_Seleccion_Usuario.Name = "Label_Seleccion_Usuario"
        Me.Label_Seleccion_Usuario.Size = New System.Drawing.Size(53, 25)
        Me.Label_Seleccion_Usuario.TabIndex = 4
        Me.Label_Seleccion_Usuario.Text = "User"
        '
        'TextBox_Contraseña_Confirmacion
        '
        Me.TextBox_Contraseña_Confirmacion.Location = New System.Drawing.Point(27, 313)
        Me.TextBox_Contraseña_Confirmacion.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TextBox_Contraseña_Confirmacion.MaxLength = 20
        Me.TextBox_Contraseña_Confirmacion.Name = "TextBox_Contraseña_Confirmacion"
        Me.TextBox_Contraseña_Confirmacion.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Contraseña_Confirmacion.Size = New System.Drawing.Size(352, 29)
        Me.TextBox_Contraseña_Confirmacion.TabIndex = 3
        '
        'ComboBox_Selecion_Usuario
        '
        Me.ComboBox_Selecion_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Selecion_Usuario.FormattingEnabled = True
        Me.ComboBox_Selecion_Usuario.Location = New System.Drawing.Point(27, 94)
        Me.ComboBox_Selecion_Usuario.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.ComboBox_Selecion_Usuario.Name = "ComboBox_Selecion_Usuario"
        Me.ComboBox_Selecion_Usuario.Size = New System.Drawing.Size(355, 32)
        Me.ComboBox_Selecion_Usuario.TabIndex = 1
        '
        'Label_Contraseña_Confirmacion
        '
        Me.Label_Contraseña_Confirmacion.AutoSize = True
        Me.Label_Contraseña_Confirmacion.BackColor = System.Drawing.Color.Transparent
        Me.Label_Contraseña_Confirmacion.Location = New System.Drawing.Point(89, 266)
        Me.Label_Contraseña_Confirmacion.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label_Contraseña_Confirmacion.Name = "Label_Contraseña_Confirmacion"
        Me.Label_Contraseña_Confirmacion.Size = New System.Drawing.Size(98, 25)
        Me.Label_Contraseña_Confirmacion.TabIndex = 5
        Me.Label_Contraseña_Confirmacion.Text = "Password"
        '
        'Button_Eliminar_Usuario
        '
        Me.Button_Eliminar_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Usuario.BackgroundImage = Global.Bohíque_FMS.My.Resources.Resources.Boton_Verde
        Me.Button_Eliminar_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Eliminar_Usuario.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Eliminar_Usuario.FlatAppearance.BorderSize = 0
        Me.Button_Eliminar_Usuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Usuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Eliminar_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Button_Eliminar_Usuario.Location = New System.Drawing.Point(144, 385)
        Me.Button_Eliminar_Usuario.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Button_Eliminar_Usuario.Name = "Button_Eliminar_Usuario"
        Me.Button_Eliminar_Usuario.Size = New System.Drawing.Size(131, 73)
        Me.Button_Eliminar_Usuario.TabIndex = 4
        Me.Button_Eliminar_Usuario.Text = "Delete"
        Me.Button_Eliminar_Usuario.UseVisualStyleBackColor = False
        '
        'PictureBox_Seleccion_Usuario
        '
        Me.PictureBox_Seleccion_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Seleccion_Usuario.BackgroundImage = CType(resources.GetObject("PictureBox_Seleccion_Usuario.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Seleccion_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Seleccion_Usuario.Location = New System.Drawing.Point(29, 25)
        Me.PictureBox_Seleccion_Usuario.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Seleccion_Usuario.Name = "PictureBox_Seleccion_Usuario"
        Me.PictureBox_Seleccion_Usuario.Size = New System.Drawing.Size(55, 55)
        Me.PictureBox_Seleccion_Usuario.TabIndex = 6
        Me.PictureBox_Seleccion_Usuario.TabStop = False
        '
        'PictureBox_Contraseña
        '
        Me.PictureBox_Contraseña.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Contraseña.BackgroundImage = CType(resources.GetObject("PictureBox_Contraseña.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Contraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Contraseña.Location = New System.Drawing.Point(27, 251)
        Me.PictureBox_Contraseña.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Contraseña.Name = "PictureBox_Contraseña"
        Me.PictureBox_Contraseña.Size = New System.Drawing.Size(55, 55)
        Me.PictureBox_Contraseña.TabIndex = 6
        Me.PictureBox_Contraseña.TabStop = False
        '
        'ComboBox_Seleccion_Eliminar_Paciente
        '
        Me.ComboBox_Seleccion_Eliminar_Paciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Seleccion_Eliminar_Paciente.FormattingEnabled = True
        Me.ComboBox_Seleccion_Eliminar_Paciente.Location = New System.Drawing.Point(29, 205)
        Me.ComboBox_Seleccion_Eliminar_Paciente.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.ComboBox_Seleccion_Eliminar_Paciente.Name = "ComboBox_Seleccion_Eliminar_Paciente"
        Me.ComboBox_Seleccion_Eliminar_Paciente.Size = New System.Drawing.Size(355, 32)
        Me.ComboBox_Seleccion_Eliminar_Paciente.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(93, 157)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 25)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Patient"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(32, 138)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(55, 55)
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = False
        '
        'Form_Eliminar_Paciente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(433, 515)
        Me.Controls.Add(Me.Button_Eliminar_Usuario)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox_Seleccion_Usuario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label_Seleccion_Usuario)
        Me.Controls.Add(Me.Label_Contraseña_Confirmacion)
        Me.Controls.Add(Me.TextBox_Contraseña_Confirmacion)
        Me.Controls.Add(Me.ComboBox_Seleccion_Eliminar_Paciente)
        Me.Controls.Add(Me.ComboBox_Selecion_Usuario)
        Me.Controls.Add(Me.PictureBox_Contraseña)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Name = "Form_Eliminar_Paciente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delete Patient"
        CType(Me.PictureBox_Seleccion_Usuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Contraseña, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label_Seleccion_Usuario As Label
    Friend WithEvents TextBox_Contraseña_Confirmacion As TextBox
    Friend WithEvents PictureBox_Contraseña As PictureBox
    Friend WithEvents ComboBox_Selecion_Usuario As ComboBox
    Friend WithEvents Label_Contraseña_Confirmacion As Label
    Friend WithEvents PictureBox_Seleccion_Usuario As PictureBox
    Friend WithEvents Button_Eliminar_Usuario As Button
    Friend WithEvents ComboBox_Seleccion_Eliminar_Paciente As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
