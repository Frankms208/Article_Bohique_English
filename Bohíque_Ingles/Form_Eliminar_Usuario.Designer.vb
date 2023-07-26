<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Eliminar_Usuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Eliminar_Usuario))
        Me.ComboBox_Selecion_Usuario = New System.Windows.Forms.ComboBox()
        Me.TextBox_Contraseña_Confirmacion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label_Contraseña_Confirmacion = New System.Windows.Forms.Label()
        Me.Button_Eliminar_Usuario = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Contraseña = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Contraseña, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox_Selecion_Usuario
        '
        Me.ComboBox_Selecion_Usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Selecion_Usuario.FormattingEnabled = True
        Me.ComboBox_Selecion_Usuario.Location = New System.Drawing.Point(33, 95)
        Me.ComboBox_Selecion_Usuario.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.ComboBox_Selecion_Usuario.Name = "ComboBox_Selecion_Usuario"
        Me.ComboBox_Selecion_Usuario.Size = New System.Drawing.Size(355, 32)
        Me.ComboBox_Selecion_Usuario.TabIndex = 1
        '
        'TextBox_Contraseña_Confirmacion
        '
        Me.TextBox_Contraseña_Confirmacion.Location = New System.Drawing.Point(34, 202)
        Me.TextBox_Contraseña_Confirmacion.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.TextBox_Contraseña_Confirmacion.MaxLength = 20
        Me.TextBox_Contraseña_Confirmacion.Name = "TextBox_Contraseña_Confirmacion"
        Me.TextBox_Contraseña_Confirmacion.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Contraseña_Confirmacion.Size = New System.Drawing.Size(352, 29)
        Me.TextBox_Contraseña_Confirmacion.TabIndex = 2
        Me.TextBox_Contraseña_Confirmacion.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(98, 47)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 25)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "User"
        '
        'Label_Contraseña_Confirmacion
        '
        Me.Label_Contraseña_Confirmacion.AutoSize = True
        Me.Label_Contraseña_Confirmacion.BackColor = System.Drawing.Color.Transparent
        Me.Label_Contraseña_Confirmacion.Location = New System.Drawing.Point(98, 155)
        Me.Label_Contraseña_Confirmacion.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label_Contraseña_Confirmacion.Name = "Label_Contraseña_Confirmacion"
        Me.Label_Contraseña_Confirmacion.Size = New System.Drawing.Size(98, 25)
        Me.Label_Contraseña_Confirmacion.TabIndex = 5
        Me.Label_Contraseña_Confirmacion.Text = "Password"
        Me.Label_Contraseña_Confirmacion.Visible = False
        '
        'Button_Eliminar_Usuario
        '
        Me.Button_Eliminar_Usuario.BackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Usuario.BackgroundImage = Global.Bohíque_FMS.My.Resources.Resources.Boton_Verde
        Me.Button_Eliminar_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Eliminar_Usuario.FlatAppearance.BorderSize = 0
        Me.Button_Eliminar_Usuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Usuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Eliminar_Usuario.ForeColor = System.Drawing.Color.Black
        Me.Button_Eliminar_Usuario.Location = New System.Drawing.Point(133, 290)
        Me.Button_Eliminar_Usuario.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Button_Eliminar_Usuario.Name = "Button_Eliminar_Usuario"
        Me.Button_Eliminar_Usuario.Size = New System.Drawing.Size(143, 73)
        Me.Button_Eliminar_Usuario.TabIndex = 3
        Me.Button_Eliminar_Usuario.Text = "Select User"
        Me.Button_Eliminar_Usuario.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(34, 26)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(55, 55)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'PictureBox_Contraseña
        '
        Me.PictureBox_Contraseña.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Contraseña.BackgroundImage = CType(resources.GetObject("PictureBox_Contraseña.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox_Contraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox_Contraseña.Location = New System.Drawing.Point(34, 138)
        Me.PictureBox_Contraseña.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox_Contraseña.Name = "PictureBox_Contraseña"
        Me.PictureBox_Contraseña.Size = New System.Drawing.Size(55, 55)
        Me.PictureBox_Contraseña.TabIndex = 6
        Me.PictureBox_Contraseña.TabStop = False
        Me.PictureBox_Contraseña.Visible = False
        '
        'Form_Eliminar_Usuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(413, 415)
        Me.Controls.Add(Me.Button_Eliminar_Usuario)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label_Contraseña_Confirmacion)
        Me.Controls.Add(Me.ComboBox_Selecion_Usuario)
        Me.Controls.Add(Me.PictureBox_Contraseña)
        Me.Controls.Add(Me.TextBox_Contraseña_Confirmacion)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.Name = "Form_Eliminar_Usuario"
        Me.Text = "Delete User"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Contraseña, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button_Eliminar_Usuario As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ComboBox_Selecion_Usuario As ComboBox
    Friend WithEvents TextBox_Contraseña_Confirmacion As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox_Contraseña As PictureBox
    Friend WithEvents Label_Contraseña_Confirmacion As Label
End Class
