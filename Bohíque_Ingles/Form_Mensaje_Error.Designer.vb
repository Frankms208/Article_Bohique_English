<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Mensaje_Error
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Mensaje_Error))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label_Mensaje1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label_Mensaje2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.Bohíque_FMS.My.Resources.Resources.Boton_Verde
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(248, 172)
        Me.Button1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(161, 62)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Accept"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label_Mensaje1
        '
        Me.Label_Mensaje1.AutoSize = True
        Me.Label_Mensaje1.BackColor = System.Drawing.Color.Transparent
        Me.Label_Mensaje1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Mensaje1.Location = New System.Drawing.Point(180, 66)
        Me.Label_Mensaje1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Mensaje1.Name = "Label_Mensaje1"
        Me.Label_Mensaje1.Size = New System.Drawing.Size(195, 29)
        Me.Label_Mensaje1.TabIndex = 1
        Me.Label_Mensaje1.Text = "Wrong password"
        Me.Label_Mensaje1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.Bohíque_FMS.My.Resources.Resources.Accept
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(95, 44)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(73, 74)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label_Mensaje2
        '
        Me.Label_Mensaje2.AutoSize = True
        Me.Label_Mensaje2.BackColor = System.Drawing.Color.Transparent
        Me.Label_Mensaje2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Mensaje2.Location = New System.Drawing.Point(180, 116)
        Me.Label_Mensaje2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label_Mensaje2.Name = "Label_Mensaje2"
        Me.Label_Mensaje2.Size = New System.Drawing.Size(0, 29)
        Me.Label_Mensaje2.TabIndex = 1
        Me.Label_Mensaje2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Form_Mensaje_Error
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(647, 257)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label_Mensaje2)
        Me.Controls.Add(Me.Label_Mensaje1)
        Me.Controls.Add(Me.Button1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "Form_Mensaje_Error"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wrong password"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label_Mensaje1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label_Mensaje2 As Label
End Class
