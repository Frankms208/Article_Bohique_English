<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Inicio
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
        Me.components = New System.ComponentModel.Container()
        Me.PictureBox_Inicio = New System.Windows.Forms.PictureBox()
        Me.ProgressBar_Inicio = New System.Windows.Forms.ProgressBar()
        Me.Timer_Inicio = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox_Inicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox_Inicio
        '
        Me.PictureBox_Inicio.Image = Global.Bohíque_FMS.My.Resources.Resources.Inicio
        Me.PictureBox_Inicio.InitialImage = Global.Bohíque_FMS.My.Resources.Resources.Inicio
        Me.PictureBox_Inicio.Location = New System.Drawing.Point(1, 3)
        Me.PictureBox_Inicio.Name = "PictureBox_Inicio"
        Me.PictureBox_Inicio.Size = New System.Drawing.Size(536, 321)
        Me.PictureBox_Inicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox_Inicio.TabIndex = 0
        Me.PictureBox_Inicio.TabStop = False
        '
        'ProgressBar_Inicio
        '
        Me.ProgressBar_Inicio.Location = New System.Drawing.Point(1, 326)
        Me.ProgressBar_Inicio.Name = "ProgressBar_Inicio"
        Me.ProgressBar_Inicio.Size = New System.Drawing.Size(536, 11)
        Me.ProgressBar_Inicio.TabIndex = 1
        '
        'Timer_Inicio
        '
        Me.Timer_Inicio.Interval = 500
        '
        'Form_Inicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 341)
        Me.Controls.Add(Me.ProgressBar_Inicio)
        Me.Controls.Add(Me.PictureBox_Inicio)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form_Inicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        CType(Me.PictureBox_Inicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox_Inicio As PictureBox
    Friend WithEvents ProgressBar_Inicio As ProgressBar
    Friend WithEvents Timer_Inicio As Timer
End Class
