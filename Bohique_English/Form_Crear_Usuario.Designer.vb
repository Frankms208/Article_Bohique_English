<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Crear_Usuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Crear_Usuario))
        Me.Label_Usuario = New System.Windows.Forms.Label()
        Me.PictureBox_Usuario = New System.Windows.Forms.PictureBox()
        Me.ComboBox_Tipo_Usuario = New System.Windows.Forms.ComboBox()
        Me.Label_Tipo_Usuario = New System.Windows.Forms.Label()
        Me.PictureBox_Tipo_Usuario = New System.Windows.Forms.PictureBox()
        Me.TextBox_Nombre_Usuario = New System.Windows.Forms.TextBox()
        Me.CheckBox_Mostrar_Contraseña = New System.Windows.Forms.CheckBox()
        Me.TextBox_Contraseña_2 = New System.Windows.Forms.TextBox()
        Me.TextBox_Contraseña_1 = New System.Windows.Forms.TextBox()
        Me.PictureBox_Contraseña = New System.Windows.Forms.PictureBox()
        Me.Label_Contraseña = New System.Windows.Forms.Label()
        Me.Button_Crear_Usuario = New System.Windows.Forms.Button()
        CType(Me.PictureBox_Usuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Tipo_Usuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Contraseña, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label_Usuario
        '
        Me.Label_Usuario.AutoSize = True
        Me.Label_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.Label_Usuario.Location = New System.Drawing.Point(48, 81)
        Me.Label_Usuario.Name = "Label_Usuario"
        Me.Label_Usuario.Size = New System.Drawing.Size(60, 13)
        Me.Label_Usuario.TabIndex = 4
        Me.Label_Usuario.Text = "User Name"
        '
        'PictureBox_Usuario
        '
        Me.PictureBox_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Usuario.BackgroundImage = CType(resources.GetObject("PictureBox_Usuario.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Usuario.Location = New System.Drawing.Point(14, 71)
        Me.PictureBox_Usuario.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Usuario.Name = "PictureBox_Usuario"
        Me.PictureBox_Usuario.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox_Usuario.TabIndex = 6
        Me.PictureBox_Usuario.TabStop = False
        '
        'ComboBox_Tipo_Usuario
        '
        Me.ComboBox_Tipo_Usuario.CausesValidation = False
        Me.ComboBox_Tipo_Usuario.FormattingEnabled = True
        Me.ComboBox_Tipo_Usuario.Items.AddRange(New Object() {"User", "Admin"})
        Me.ComboBox_Tipo_Usuario.Location = New System.Drawing.Point(14, 46)
        Me.ComboBox_Tipo_Usuario.Name = "ComboBox_Tipo_Usuario"
        Me.ComboBox_Tipo_Usuario.Size = New System.Drawing.Size(195, 21)
        Me.ComboBox_Tipo_Usuario.TabIndex = 1
        '
        'Label_Tipo_Usuario
        '
        Me.Label_Tipo_Usuario.AutoSize = True
        Me.Label_Tipo_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.Label_Tipo_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label_Tipo_Usuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label_Tipo_Usuario.Location = New System.Drawing.Point(48, 21)
        Me.Label_Tipo_Usuario.Name = "Label_Tipo_Usuario"
        Me.Label_Tipo_Usuario.Size = New System.Drawing.Size(56, 13)
        Me.Label_Tipo_Usuario.TabIndex = 3
        Me.Label_Tipo_Usuario.Text = "User Type"
        '
        'PictureBox_Tipo_Usuario
        '
        Me.PictureBox_Tipo_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Tipo_Usuario.BackgroundImage = CType(resources.GetObject("PictureBox_Tipo_Usuario.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Tipo_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Tipo_Usuario.Location = New System.Drawing.Point(14, 12)
        Me.PictureBox_Tipo_Usuario.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Tipo_Usuario.Name = "PictureBox_Tipo_Usuario"
        Me.PictureBox_Tipo_Usuario.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox_Tipo_Usuario.TabIndex = 6
        Me.PictureBox_Tipo_Usuario.TabStop = False
        '
        'TextBox_Nombre_Usuario
        '
        Me.TextBox_Nombre_Usuario.Location = New System.Drawing.Point(14, 107)
        Me.TextBox_Nombre_Usuario.MaxLength = 30
        Me.TextBox_Nombre_Usuario.Name = "TextBox_Nombre_Usuario"
        Me.TextBox_Nombre_Usuario.Size = New System.Drawing.Size(194, 20)
        Me.TextBox_Nombre_Usuario.TabIndex = 2
        '
        'CheckBox_Mostrar_Contraseña
        '
        Me.CheckBox_Mostrar_Contraseña.AutoSize = True
        Me.CheckBox_Mostrar_Contraseña.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_Mostrar_Contraseña.Location = New System.Drawing.Point(14, 225)
        Me.CheckBox_Mostrar_Contraseña.Name = "CheckBox_Mostrar_Contraseña"
        Me.CheckBox_Mostrar_Contraseña.Size = New System.Drawing.Size(102, 17)
        Me.CheckBox_Mostrar_Contraseña.TabIndex = 7
        Me.CheckBox_Mostrar_Contraseña.Text = "Show Password"
        Me.CheckBox_Mostrar_Contraseña.UseVisualStyleBackColor = False
        '
        'TextBox_Contraseña_2
        '
        Me.TextBox_Contraseña_2.Location = New System.Drawing.Point(14, 196)
        Me.TextBox_Contraseña_2.MaxLength = 20
        Me.TextBox_Contraseña_2.Name = "TextBox_Contraseña_2"
        Me.TextBox_Contraseña_2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Contraseña_2.Size = New System.Drawing.Size(194, 20)
        Me.TextBox_Contraseña_2.TabIndex = 4
        '
        'TextBox_Contraseña_1
        '
        Me.TextBox_Contraseña_1.Location = New System.Drawing.Point(14, 164)
        Me.TextBox_Contraseña_1.MaxLength = 20
        Me.TextBox_Contraseña_1.Name = "TextBox_Contraseña_1"
        Me.TextBox_Contraseña_1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Contraseña_1.Size = New System.Drawing.Size(194, 20)
        Me.TextBox_Contraseña_1.TabIndex = 3
        '
        'PictureBox_Contraseña
        '
        Me.PictureBox_Contraseña.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Contraseña.BackgroundImage = CType(resources.GetObject("PictureBox_Contraseña.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Contraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Contraseña.Location = New System.Drawing.Point(14, 130)
        Me.PictureBox_Contraseña.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Contraseña.Name = "PictureBox_Contraseña"
        Me.PictureBox_Contraseña.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox_Contraseña.TabIndex = 6
        Me.PictureBox_Contraseña.TabStop = False
        '
        'Label_Contraseña
        '
        Me.Label_Contraseña.AutoSize = True
        Me.Label_Contraseña.BackColor = System.Drawing.Color.Transparent
        Me.Label_Contraseña.Location = New System.Drawing.Point(48, 139)
        Me.Label_Contraseña.Name = "Label_Contraseña"
        Me.Label_Contraseña.Size = New System.Drawing.Size(53, 13)
        Me.Label_Contraseña.TabIndex = 5
        Me.Label_Contraseña.Text = "Password"
        '
        'Button_Crear_Usuario
        '
        Me.Button_Crear_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.Button_Crear_Usuario.BackgroundImage = Global.Bohíque_FMS.My.Resources.Resources.Boton_Verde
        Me.Button_Crear_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Crear_Usuario.FlatAppearance.BorderSize = 0
        Me.Button_Crear_Usuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Crear_Usuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Crear_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Crear_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Button_Crear_Usuario.Location = New System.Drawing.Point(68, 248)
        Me.Button_Crear_Usuario.Name = "Button_Crear_Usuario"
        Me.Button_Crear_Usuario.Size = New System.Drawing.Size(78, 32)
        Me.Button_Crear_Usuario.TabIndex = 5
        Me.Button_Crear_Usuario.Text = "Create"
        Me.Button_Crear_Usuario.UseVisualStyleBackColor = False
        '
        'Form_Crear_Usuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(232, 294)
        Me.Controls.Add(Me.CheckBox_Mostrar_Contraseña)
        Me.Controls.Add(Me.Button_Crear_Usuario)
        Me.Controls.Add(Me.PictureBox_Tipo_Usuario)
        Me.Controls.Add(Me.Label_Tipo_Usuario)
        Me.Controls.Add(Me.TextBox_Contraseña_2)
        Me.Controls.Add(Me.TextBox_Nombre_Usuario)
        Me.Controls.Add(Me.TextBox_Contraseña_1)
        Me.Controls.Add(Me.PictureBox_Contraseña)
        Me.Controls.Add(Me.Label_Usuario)
        Me.Controls.Add(Me.ComboBox_Tipo_Usuario)
        Me.Controls.Add(Me.Label_Contraseña)
        Me.Controls.Add(Me.PictureBox_Usuario)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_Crear_Usuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create User"
        CType(Me.PictureBox_Usuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Tipo_Usuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Contraseña, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label_Usuario As Label
    Friend WithEvents PictureBox_Usuario As PictureBox
    Friend WithEvents ComboBox_Tipo_Usuario As ComboBox
    Friend WithEvents Label_Tipo_Usuario As Label
    Friend WithEvents PictureBox_Tipo_Usuario As PictureBox
    Friend WithEvents TextBox_Nombre_Usuario As TextBox
    Friend WithEvents CheckBox_Mostrar_Contraseña As CheckBox
    Friend WithEvents TextBox_Contraseña_2 As TextBox
    Friend WithEvents TextBox_Contraseña_1 As TextBox
    Friend WithEvents PictureBox_Contraseña As PictureBox
    Friend WithEvents Label_Contraseña As Label
    Friend WithEvents Button_Crear_Usuario As Button
End Class
