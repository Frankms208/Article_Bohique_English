<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Modificar_Contraseña
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Modificar_Contraseña))
        Me.TextBox_Contraseña_Nueva_2 = New System.Windows.Forms.TextBox()
        Me.CheckBox_Mostrar_Contraseña = New System.Windows.Forms.CheckBox()
        Me.Label_Contraseña = New System.Windows.Forms.Label()
        Me.PictureBox_Contraseña = New System.Windows.Forms.PictureBox()
        Me.Label_Usuario = New System.Windows.Forms.Label()
        Me.TextBox_Contraseña_Nueva_1 = New System.Windows.Forms.TextBox()
        Me.ComboBox_Selecion_Usuario = New System.Windows.Forms.ComboBox()
        Me.PictureBox_Usuario = New System.Windows.Forms.PictureBox()
        Me.Button_Modificar_Contraseña = New System.Windows.Forms.Button()
        CType(Me.PictureBox_Contraseña, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Usuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox_Contraseña_Nueva_2
        '
        Me.TextBox_Contraseña_Nueva_2.Location = New System.Drawing.Point(46, 238)
        Me.TextBox_Contraseña_Nueva_2.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TextBox_Contraseña_Nueva_2.MaxLength = 20
        Me.TextBox_Contraseña_Nueva_2.Name = "TextBox_Contraseña_Nueva_2"
        Me.TextBox_Contraseña_Nueva_2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Contraseña_Nueva_2.Size = New System.Drawing.Size(352, 29)
        Me.TextBox_Contraseña_Nueva_2.TabIndex = 3
        '
        'CheckBox_Mostrar_Contraseña
        '
        Me.CheckBox_Mostrar_Contraseña.AutoSize = True
        Me.CheckBox_Mostrar_Contraseña.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_Mostrar_Contraseña.Location = New System.Drawing.Point(46, 292)
        Me.CheckBox_Mostrar_Contraseña.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.CheckBox_Mostrar_Contraseña.Name = "CheckBox_Mostrar_Contraseña"
        Me.CheckBox_Mostrar_Contraseña.Size = New System.Drawing.Size(177, 29)
        Me.CheckBox_Mostrar_Contraseña.TabIndex = 4
        Me.CheckBox_Mostrar_Contraseña.Text = "Show password"
        Me.CheckBox_Mostrar_Contraseña.UseVisualStyleBackColor = False
        '
        'Label_Contraseña
        '
        Me.Label_Contraseña.AutoSize = True
        Me.Label_Contraseña.BackColor = System.Drawing.Color.Transparent
        Me.Label_Contraseña.Location = New System.Drawing.Point(108, 133)
        Me.Label_Contraseña.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label_Contraseña.Name = "Label_Contraseña"
        Me.Label_Contraseña.Size = New System.Drawing.Size(142, 25)
        Me.Label_Contraseña.TabIndex = 5
        Me.Label_Contraseña.Text = "New Password"
        '
        'PictureBox_Contraseña
        '
        Me.PictureBox_Contraseña.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Contraseña.BackgroundImage = CType(resources.GetObject("PictureBox_Contraseña.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Contraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Contraseña.Location = New System.Drawing.Point(46, 116)
        Me.PictureBox_Contraseña.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Contraseña.Name = "PictureBox_Contraseña"
        Me.PictureBox_Contraseña.Size = New System.Drawing.Size(55, 55)
        Me.PictureBox_Contraseña.TabIndex = 6
        Me.PictureBox_Contraseña.TabStop = False
        '
        'Label_Usuario
        '
        Me.Label_Usuario.AutoSize = True
        Me.Label_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.Label_Usuario.Location = New System.Drawing.Point(108, 24)
        Me.Label_Usuario.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label_Usuario.Name = "Label_Usuario"
        Me.Label_Usuario.Size = New System.Drawing.Size(53, 25)
        Me.Label_Usuario.TabIndex = 4
        Me.Label_Usuario.Text = "User"
        '
        'TextBox_Contraseña_Nueva_1
        '
        Me.TextBox_Contraseña_Nueva_1.Location = New System.Drawing.Point(46, 179)
        Me.TextBox_Contraseña_Nueva_1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TextBox_Contraseña_Nueva_1.MaxLength = 20
        Me.TextBox_Contraseña_Nueva_1.Name = "TextBox_Contraseña_Nueva_1"
        Me.TextBox_Contraseña_Nueva_1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Contraseña_Nueva_1.Size = New System.Drawing.Size(352, 29)
        Me.TextBox_Contraseña_Nueva_1.TabIndex = 2
        '
        'ComboBox_Selecion_Usuario
        '
        Me.ComboBox_Selecion_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Selecion_Usuario.FormattingEnabled = True
        Me.ComboBox_Selecion_Usuario.Location = New System.Drawing.Point(44, 72)
        Me.ComboBox_Selecion_Usuario.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.ComboBox_Selecion_Usuario.Name = "ComboBox_Selecion_Usuario"
        Me.ComboBox_Selecion_Usuario.Size = New System.Drawing.Size(354, 32)
        Me.ComboBox_Selecion_Usuario.TabIndex = 1
        '
        'PictureBox_Usuario
        '
        Me.PictureBox_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Usuario.BackgroundImage = CType(resources.GetObject("PictureBox_Usuario.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Usuario.Location = New System.Drawing.Point(46, 6)
        Me.PictureBox_Usuario.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Usuario.Name = "PictureBox_Usuario"
        Me.PictureBox_Usuario.Size = New System.Drawing.Size(55, 55)
        Me.PictureBox_Usuario.TabIndex = 6
        Me.PictureBox_Usuario.TabStop = False
        '
        'Button_Modificar_Contraseña
        '
        Me.Button_Modificar_Contraseña.BackColor = System.Drawing.Color.Transparent
        Me.Button_Modificar_Contraseña.BackgroundImage = Global.Bohíque_FMS.My.Resources.Resources.Boton_Verde
        Me.Button_Modificar_Contraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Modificar_Contraseña.FlatAppearance.BorderSize = 0
        Me.Button_Modificar_Contraseña.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Modificar_Contraseña.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Modificar_Contraseña.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Modificar_Contraseña.ForeColor = System.Drawing.Color.Black
        Me.Button_Modificar_Contraseña.Location = New System.Drawing.Point(144, 334)
        Me.Button_Modificar_Contraseña.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Button_Modificar_Contraseña.Name = "Button_Modificar_Contraseña"
        Me.Button_Modificar_Contraseña.Size = New System.Drawing.Size(143, 74)
        Me.Button_Modificar_Contraseña.TabIndex = 5
        Me.Button_Modificar_Contraseña.Text = "Change Password"
        Me.Button_Modificar_Contraseña.UseVisualStyleBackColor = False
        '
        'Form_Modificar_Contraseña
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(445, 432)
        Me.Controls.Add(Me.CheckBox_Mostrar_Contraseña)
        Me.Controls.Add(Me.Button_Modificar_Contraseña)
        Me.Controls.Add(Me.Label_Contraseña)
        Me.Controls.Add(Me.PictureBox_Contraseña)
        Me.Controls.Add(Me.Label_Usuario)
        Me.Controls.Add(Me.TextBox_Contraseña_Nueva_1)
        Me.Controls.Add(Me.ComboBox_Selecion_Usuario)
        Me.Controls.Add(Me.TextBox_Contraseña_Nueva_2)
        Me.Controls.Add(Me.PictureBox_Usuario)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Name = "Form_Modificar_Contraseña"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Password"
        CType(Me.PictureBox_Contraseña, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Usuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox_Contraseña_Nueva_2 As TextBox
    Friend WithEvents CheckBox_Mostrar_Contraseña As CheckBox
    Friend WithEvents Label_Contraseña As Label
    Friend WithEvents PictureBox_Contraseña As PictureBox
    Friend WithEvents Label_Usuario As Label
    Friend WithEvents TextBox_Contraseña_Nueva_1 As TextBox
    Friend WithEvents ComboBox_Selecion_Usuario As ComboBox
    Friend WithEvents PictureBox_Usuario As PictureBox
    Friend WithEvents Button_Modificar_Contraseña As Button
End Class
