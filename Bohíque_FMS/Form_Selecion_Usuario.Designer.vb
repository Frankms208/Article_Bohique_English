<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Selecion_Usuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Selecion_Usuario))
        Me.Button_Cambio_Usuario = New System.Windows.Forms.Button()
        Me.TextBox_Contraseña = New System.Windows.Forms.TextBox()
        Me.Label_Tipo_Usuario = New System.Windows.Forms.Label()
        Me.Label_Usuario = New System.Windows.Forms.Label()
        Me.PictureBox_Tipo_Usuario = New System.Windows.Forms.PictureBox()
        Me.Label_Contraseña = New System.Windows.Forms.Label()
        Me.PictureBox_Usuario = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Contraseña = New System.Windows.Forms.PictureBox()
        Me.ComboBox_Selecion_Usuario = New System.Windows.Forms.ComboBox()
        Me.CheckBox_Mostrar_Contraseña = New System.Windows.Forms.CheckBox()
        Me.ComboBox_Selecion_Tipo_Usuario = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox_Tipo_Usuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Usuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Contraseña, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_Cambio_Usuario
        '
        Me.Button_Cambio_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.Button_Cambio_Usuario.BackgroundImage = Global.Bohíque_FMS.My.Resources.Resources.Boton_Verde
        Me.Button_Cambio_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Cambio_Usuario.FlatAppearance.BorderSize = 0
        Me.Button_Cambio_Usuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Cambio_Usuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Cambio_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Cambio_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Button_Cambio_Usuario.Location = New System.Drawing.Point(60, 209)
        Me.Button_Cambio_Usuario.Name = "Button_Cambio_Usuario"
        Me.Button_Cambio_Usuario.Size = New System.Drawing.Size(78, 32)
        Me.Button_Cambio_Usuario.TabIndex = 5
        Me.Button_Cambio_Usuario.Text = "Start"
        Me.Button_Cambio_Usuario.UseVisualStyleBackColor = False
        '
        'TextBox_Contraseña
        '
        Me.TextBox_Contraseña.Location = New System.Drawing.Point(9, 161)
        Me.TextBox_Contraseña.MaxLength = 20
        Me.TextBox_Contraseña.Name = "TextBox_Contraseña"
        Me.TextBox_Contraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Contraseña.Size = New System.Drawing.Size(194, 20)
        Me.TextBox_Contraseña.TabIndex = 3
        '
        'Label_Tipo_Usuario
        '
        Me.Label_Tipo_Usuario.AutoSize = True
        Me.Label_Tipo_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.Label_Tipo_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label_Tipo_Usuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label_Tipo_Usuario.Location = New System.Drawing.Point(43, 18)
        Me.Label_Tipo_Usuario.Name = "Label_Tipo_Usuario"
        Me.Label_Tipo_Usuario.Size = New System.Drawing.Size(56, 13)
        Me.Label_Tipo_Usuario.TabIndex = 3
        Me.Label_Tipo_Usuario.Text = "User Type"
        '
        'Label_Usuario
        '
        Me.Label_Usuario.AutoSize = True
        Me.Label_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.Label_Usuario.Location = New System.Drawing.Point(43, 78)
        Me.Label_Usuario.Name = "Label_Usuario"
        Me.Label_Usuario.Size = New System.Drawing.Size(29, 13)
        Me.Label_Usuario.TabIndex = 4
        Me.Label_Usuario.Text = "User"
        '
        'PictureBox_Tipo_Usuario
        '
        Me.PictureBox_Tipo_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Tipo_Usuario.BackgroundImage = CType(resources.GetObject("PictureBox_Tipo_Usuario.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Tipo_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Tipo_Usuario.Location = New System.Drawing.Point(9, 9)
        Me.PictureBox_Tipo_Usuario.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Tipo_Usuario.Name = "PictureBox_Tipo_Usuario"
        Me.PictureBox_Tipo_Usuario.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox_Tipo_Usuario.TabIndex = 6
        Me.PictureBox_Tipo_Usuario.TabStop = False
        '
        'Label_Contraseña
        '
        Me.Label_Contraseña.AutoSize = True
        Me.Label_Contraseña.BackColor = System.Drawing.Color.Transparent
        Me.Label_Contraseña.Location = New System.Drawing.Point(43, 136)
        Me.Label_Contraseña.Name = "Label_Contraseña"
        Me.Label_Contraseña.Size = New System.Drawing.Size(53, 13)
        Me.Label_Contraseña.TabIndex = 5
        Me.Label_Contraseña.Text = "Password"
        '
        'PictureBox_Usuario
        '
        Me.PictureBox_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Usuario.BackgroundImage = CType(resources.GetObject("PictureBox_Usuario.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Usuario.Location = New System.Drawing.Point(9, 68)
        Me.PictureBox_Usuario.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Usuario.Name = "PictureBox_Usuario"
        Me.PictureBox_Usuario.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox_Usuario.TabIndex = 6
        Me.PictureBox_Usuario.TabStop = False
        '
        'PictureBox_Contraseña
        '
        Me.PictureBox_Contraseña.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Contraseña.BackgroundImage = CType(resources.GetObject("PictureBox_Contraseña.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Contraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Contraseña.Location = New System.Drawing.Point(9, 127)
        Me.PictureBox_Contraseña.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Contraseña.Name = "PictureBox_Contraseña"
        Me.PictureBox_Contraseña.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox_Contraseña.TabIndex = 6
        Me.PictureBox_Contraseña.TabStop = False
        '
        'ComboBox_Selecion_Usuario
        '
        Me.ComboBox_Selecion_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Selecion_Usuario.FormattingEnabled = True
        Me.ComboBox_Selecion_Usuario.Location = New System.Drawing.Point(9, 103)
        Me.ComboBox_Selecion_Usuario.Name = "ComboBox_Selecion_Usuario"
        Me.ComboBox_Selecion_Usuario.Size = New System.Drawing.Size(195, 21)
        Me.ComboBox_Selecion_Usuario.TabIndex = 2
        '
        'CheckBox_Mostrar_Contraseña
        '
        Me.CheckBox_Mostrar_Contraseña.AutoSize = True
        Me.CheckBox_Mostrar_Contraseña.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_Mostrar_Contraseña.Location = New System.Drawing.Point(9, 187)
        Me.CheckBox_Mostrar_Contraseña.Name = "CheckBox_Mostrar_Contraseña"
        Me.CheckBox_Mostrar_Contraseña.Size = New System.Drawing.Size(102, 17)
        Me.CheckBox_Mostrar_Contraseña.TabIndex = 4
        Me.CheckBox_Mostrar_Contraseña.Text = "Show Password"
        Me.CheckBox_Mostrar_Contraseña.UseVisualStyleBackColor = False
        '
        'ComboBox_Selecion_Tipo_Usuario
        '
        Me.ComboBox_Selecion_Tipo_Usuario.CausesValidation = False
        Me.ComboBox_Selecion_Tipo_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Selecion_Tipo_Usuario.FormattingEnabled = True
        Me.ComboBox_Selecion_Tipo_Usuario.Items.AddRange(New Object() {"Guest", "User", "Admin"})
        Me.ComboBox_Selecion_Tipo_Usuario.Location = New System.Drawing.Point(9, 43)
        Me.ComboBox_Selecion_Tipo_Usuario.Name = "ComboBox_Selecion_Tipo_Usuario"
        Me.ComboBox_Selecion_Tipo_Usuario.Size = New System.Drawing.Size(195, 21)
        Me.ComboBox_Selecion_Tipo_Usuario.TabIndex = 1
        '
        'Form_Selecion_Usuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(218, 254)
        Me.Controls.Add(Me.CheckBox_Mostrar_Contraseña)
        Me.Controls.Add(Me.PictureBox_Tipo_Usuario)
        Me.Controls.Add(Me.Label_Tipo_Usuario)
        Me.Controls.Add(Me.PictureBox_Contraseña)
        Me.Controls.Add(Me.ComboBox_Selecion_Tipo_Usuario)
        Me.Controls.Add(Me.PictureBox_Usuario)
        Me.Controls.Add(Me.Label_Contraseña)
        Me.Controls.Add(Me.Label_Usuario)
        Me.Controls.Add(Me.TextBox_Contraseña)
        Me.Controls.Add(Me.Button_Cambio_Usuario)
        Me.Controls.Add(Me.ComboBox_Selecion_Usuario)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_Selecion_Usuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Selection"
        CType(Me.PictureBox_Tipo_Usuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Usuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Contraseña, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_Cambio_Usuario As Button
    Friend WithEvents TextBox_Contraseña As TextBox
    Friend WithEvents Label_Tipo_Usuario As Label
    Friend WithEvents Label_Usuario As Label
    Friend WithEvents PictureBox_Tipo_Usuario As PictureBox
    Friend WithEvents Label_Contraseña As Label
    Friend WithEvents PictureBox_Usuario As PictureBox
    Friend WithEvents PictureBox_Contraseña As PictureBox
    Friend WithEvents ComboBox_Selecion_Usuario As ComboBox
    Friend WithEvents CheckBox_Mostrar_Contraseña As CheckBox
    Friend WithEvents ComboBox_Selecion_Tipo_Usuario As ComboBox
End Class
