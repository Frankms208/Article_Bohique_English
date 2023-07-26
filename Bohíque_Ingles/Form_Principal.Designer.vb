<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Principal
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
        Dim TabControlEX_Principal As Dotnetrix.Controls.TabControlEX
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Principal))
        Me.TabPageEX_Usuarios = New Dotnetrix.Controls.TabPageEX()
        Me.FlowLayoutPanel_Principal = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button_Cambiar_Usuario = New System.Windows.Forms.Button()
        Me.Button_Modificar_Contraseña = New System.Windows.Forms.Button()
        Me.Button_Crear_Usuario = New System.Windows.Forms.Button()
        Me.Button_Eliminar_Usuario = New System.Windows.Forms.Button()
        Me.TabPageEX_Registro = New Dotnetrix.Controls.TabPageEX()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanel_Registro = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button_Almacenar_Multiples_Registros = New System.Windows.Forms.Button()
        Me.Button_Eliminar_Registro = New System.Windows.Forms.Button()
        Me.Button_Modificar_Datos_Paciente = New System.Windows.Forms.Button()
        Me.Button_Eliminar_Paciente = New System.Windows.Forms.Button()
        Me.TabPageEX_Herramientas = New Dotnetrix.Controls.TabPageEX()
        Me.FlowLayoutPanel_Herramientas = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button_Analizis_Registro = New System.Windows.Forms.Button()
        Me.Button_Agregar_Grafica = New System.Windows.Forms.Button()
        Me.Button_Limpiar_Temporales = New System.Windows.Forms.Button()
        Me.Button_Exportar_Resultados = New System.Windows.Forms.Button()
        Me.TabPageEX_Especiales = New Dotnetrix.Controls.TabPageEX()
        Me.FlowLayoutPanel_Control_Especial = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button_Buscar_Base_Datos = New System.Windows.Forms.Button()
        Me.Button_Optimizar_Base_Datos = New System.Windows.Forms.Button()
        Me.Button_Crear_Base_Datos = New System.Windows.Forms.Button()
        Me.Button_Reiniciar_Base_Datos = New System.Windows.Forms.Button()
        Me.SplitContainer_Principal = New System.Windows.Forms.SplitContainer()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog_Buscar_Carpeta_Registros = New System.Windows.Forms.FolderBrowserDialog()
        Me.BackgroundWorker_Exportar_Resultados_1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker_Exportar_Resultados_2 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker_Exportar_Resultados_3 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker_Exportar_Resultados_4 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker_Exportar_Resultados_5 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker_Exportar_Resultados_6 = New System.ComponentModel.BackgroundWorker()
        Me.FolderBrowserDialog_Ubicacion_Base_Datos = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog_Buscar_Base_Datos = New System.Windows.Forms.OpenFileDialog()
        TabControlEX_Principal = New Dotnetrix.Controls.TabControlEX()
        TabControlEX_Principal.SuspendLayout()
        Me.TabPageEX_Usuarios.SuspendLayout()
        Me.FlowLayoutPanel_Principal.SuspendLayout()
        Me.TabPageEX_Registro.SuspendLayout()
        Me.FlowLayoutPanel_Registro.SuspendLayout()
        Me.TabPageEX_Herramientas.SuspendLayout()
        Me.FlowLayoutPanel_Herramientas.SuspendLayout()
        Me.TabPageEX_Especiales.SuspendLayout()
        Me.FlowLayoutPanel_Control_Especial.SuspendLayout()
        CType(Me.SplitContainer_Principal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_Principal.Panel1.SuspendLayout()
        Me.SplitContainer_Principal.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlEX_Principal
        '
        TabControlEX_Principal.Appearance = Dotnetrix.Controls.TabAppearanceEX.FlatTab
        TabControlEX_Principal.BackColor = System.Drawing.Color.Transparent
        TabControlEX_Principal.Controls.Add(Me.TabPageEX_Usuarios)
        TabControlEX_Principal.Controls.Add(Me.TabPageEX_Registro)
        TabControlEX_Principal.Controls.Add(Me.TabPageEX_Herramientas)
        TabControlEX_Principal.Controls.Add(Me.TabPageEX_Especiales)
        TabControlEX_Principal.Dock = System.Windows.Forms.DockStyle.Fill
        TabControlEX_Principal.FlatBorderColor = System.Drawing.SystemColors.ActiveCaption
        TabControlEX_Principal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TabControlEX_Principal.ItemSize = New System.Drawing.Size(95, 30)
        TabControlEX_Principal.Location = New System.Drawing.Point(0, 0)
        TabControlEX_Principal.Margin = New System.Windows.Forms.Padding(0)
        TabControlEX_Principal.Name = "TabControlEX_Principal"
        TabControlEX_Principal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        TabControlEX_Principal.SelectedIndex = 2
        TabControlEX_Principal.Size = New System.Drawing.Size(902, 130)
        TabControlEX_Principal.TabIndex = 3
        TabControlEX_Principal.UseVisualStyles = False
        '
        'TabPageEX_Usuarios
        '
        Me.TabPageEX_Usuarios.Controls.Add(Me.FlowLayoutPanel_Principal)
        Me.TabPageEX_Usuarios.Location = New System.Drawing.Point(4, 34)
        Me.TabPageEX_Usuarios.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPageEX_Usuarios.Name = "TabPageEX_Usuarios"
        Me.TabPageEX_Usuarios.Size = New System.Drawing.Size(894, 162)
        Me.TabPageEX_Usuarios.TabIndex = 0
        Me.TabPageEX_Usuarios.Text = "Users"
        '
        'FlowLayoutPanel_Principal
        '
        Me.FlowLayoutPanel_Principal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.FlowLayoutPanel_Principal.Controls.Add(Me.Button_Cambiar_Usuario)
        Me.FlowLayoutPanel_Principal.Controls.Add(Me.Button_Modificar_Contraseña)
        Me.FlowLayoutPanel_Principal.Controls.Add(Me.Button_Crear_Usuario)
        Me.FlowLayoutPanel_Principal.Controls.Add(Me.Button_Eliminar_Usuario)
        Me.FlowLayoutPanel_Principal.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel_Principal.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel_Principal.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel_Principal.Name = "FlowLayoutPanel_Principal"
        Me.FlowLayoutPanel_Principal.Size = New System.Drawing.Size(454, 138)
        Me.FlowLayoutPanel_Principal.TabIndex = 0
        Me.FlowLayoutPanel_Principal.TabStop = True
        '
        'Button_Cambiar_Usuario
        '
        Me.Button_Cambiar_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Cambiar_Usuario.FlatAppearance.BorderSize = 0
        Me.Button_Cambiar_Usuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Cambiar_Usuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Cambiar_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Cambiar_Usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Cambiar_Usuario.Image = CType(resources.GetObject("Button_Cambiar_Usuario.Image"), System.Drawing.Image)
        Me.Button_Cambiar_Usuario.Location = New System.Drawing.Point(0, 0)
        Me.Button_Cambiar_Usuario.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Cambiar_Usuario.Name = "Button_Cambiar_Usuario"
        Me.Button_Cambiar_Usuario.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Cambiar_Usuario.Size = New System.Drawing.Size(105, 138)
        Me.Button_Cambiar_Usuario.TabIndex = 1
        Me.Button_Cambiar_Usuario.Text = "Change User"
        Me.Button_Cambiar_Usuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Cambiar_Usuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Cambiar_Usuario.UseVisualStyleBackColor = True
        '
        'Button_Modificar_Contraseña
        '
        Me.Button_Modificar_Contraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Modificar_Contraseña.FlatAppearance.BorderSize = 0
        Me.Button_Modificar_Contraseña.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Modificar_Contraseña.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Modificar_Contraseña.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Modificar_Contraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Modificar_Contraseña.Image = CType(resources.GetObject("Button_Modificar_Contraseña.Image"), System.Drawing.Image)
        Me.Button_Modificar_Contraseña.Location = New System.Drawing.Point(105, 0)
        Me.Button_Modificar_Contraseña.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Modificar_Contraseña.Name = "Button_Modificar_Contraseña"
        Me.Button_Modificar_Contraseña.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Modificar_Contraseña.Size = New System.Drawing.Size(140, 138)
        Me.Button_Modificar_Contraseña.TabIndex = 2
        Me.Button_Modificar_Contraseña.Text = "Modify Password"
        Me.Button_Modificar_Contraseña.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Modificar_Contraseña.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Modificar_Contraseña.UseVisualStyleBackColor = True
        '
        'Button_Crear_Usuario
        '
        Me.Button_Crear_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Crear_Usuario.FlatAppearance.BorderSize = 0
        Me.Button_Crear_Usuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Crear_Usuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Crear_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Crear_Usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Crear_Usuario.Image = CType(resources.GetObject("Button_Crear_Usuario.Image"), System.Drawing.Image)
        Me.Button_Crear_Usuario.Location = New System.Drawing.Point(245, 0)
        Me.Button_Crear_Usuario.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Crear_Usuario.Name = "Button_Crear_Usuario"
        Me.Button_Crear_Usuario.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Crear_Usuario.Size = New System.Drawing.Size(105, 138)
        Me.Button_Crear_Usuario.TabIndex = 3
        Me.Button_Crear_Usuario.Text = "Create User"
        Me.Button_Crear_Usuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Crear_Usuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Crear_Usuario.UseVisualStyleBackColor = True
        '
        'Button_Eliminar_Usuario
        '
        Me.Button_Eliminar_Usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Eliminar_Usuario.FlatAppearance.BorderSize = 0
        Me.Button_Eliminar_Usuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Usuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Eliminar_Usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Eliminar_Usuario.Image = CType(resources.GetObject("Button_Eliminar_Usuario.Image"), System.Drawing.Image)
        Me.Button_Eliminar_Usuario.Location = New System.Drawing.Point(0, 138)
        Me.Button_Eliminar_Usuario.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Eliminar_Usuario.Name = "Button_Eliminar_Usuario"
        Me.Button_Eliminar_Usuario.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Eliminar_Usuario.Size = New System.Drawing.Size(105, 138)
        Me.Button_Eliminar_Usuario.TabIndex = 4
        Me.Button_Eliminar_Usuario.Text = "Delete User"
        Me.Button_Eliminar_Usuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Eliminar_Usuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Eliminar_Usuario.UseVisualStyleBackColor = True
        '
        'TabPageEX_Registro
        '
        Me.TabPageEX_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPageEX_Registro.Controls.Add(Me.FlowLayoutPanel2)
        Me.TabPageEX_Registro.Controls.Add(Me.FlowLayoutPanel_Registro)
        Me.TabPageEX_Registro.Location = New System.Drawing.Point(4, 34)
        Me.TabPageEX_Registro.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPageEX_Registro.Name = "TabPageEX_Registro"
        Me.TabPageEX_Registro.Size = New System.Drawing.Size(894, 162)
        Me.TabPageEX_Registro.TabIndex = 1
        Me.TabPageEX_Registro.Text = "Record"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(-30, -482)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(420, 138)
        Me.FlowLayoutPanel2.TabIndex = 2
        Me.FlowLayoutPanel2.TabStop = True
        '
        'FlowLayoutPanel_Registro
        '
        Me.FlowLayoutPanel_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.FlowLayoutPanel_Registro.Controls.Add(Me.Button_Almacenar_Multiples_Registros)
        Me.FlowLayoutPanel_Registro.Controls.Add(Me.Button_Eliminar_Registro)
        Me.FlowLayoutPanel_Registro.Controls.Add(Me.Button_Modificar_Datos_Paciente)
        Me.FlowLayoutPanel_Registro.Controls.Add(Me.Button_Eliminar_Paciente)
        Me.FlowLayoutPanel_Registro.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel_Registro.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel_Registro.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel_Registro.Name = "FlowLayoutPanel_Registro"
        Me.FlowLayoutPanel_Registro.Size = New System.Drawing.Size(676, 138)
        Me.FlowLayoutPanel_Registro.TabIndex = 2
        Me.FlowLayoutPanel_Registro.TabStop = True
        '
        'Button_Almacenar_Multiples_Registros
        '
        Me.Button_Almacenar_Multiples_Registros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Almacenar_Multiples_Registros.FlatAppearance.BorderSize = 0
        Me.Button_Almacenar_Multiples_Registros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Almacenar_Multiples_Registros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Almacenar_Multiples_Registros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Almacenar_Multiples_Registros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Almacenar_Multiples_Registros.Image = Global.Bohíque_FMS.My.Resources.Resources.Disk_Multiple
        Me.Button_Almacenar_Multiples_Registros.Location = New System.Drawing.Point(0, 0)
        Me.Button_Almacenar_Multiples_Registros.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Almacenar_Multiples_Registros.Name = "Button_Almacenar_Multiples_Registros"
        Me.Button_Almacenar_Multiples_Registros.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Almacenar_Multiples_Registros.Size = New System.Drawing.Size(135, 138)
        Me.Button_Almacenar_Multiples_Registros.TabIndex = 1
        Me.Button_Almacenar_Multiples_Registros.Text = "Store Records (*.xlsx)"
        Me.Button_Almacenar_Multiples_Registros.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Almacenar_Multiples_Registros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Almacenar_Multiples_Registros.UseVisualStyleBackColor = True
        '
        'Button_Eliminar_Registro
        '
        Me.Button_Eliminar_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Eliminar_Registro.FlatAppearance.BorderSize = 0
        Me.Button_Eliminar_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Registro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Eliminar_Registro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Eliminar_Registro.Image = CType(resources.GetObject("Button_Eliminar_Registro.Image"), System.Drawing.Image)
        Me.Button_Eliminar_Registro.Location = New System.Drawing.Point(135, 0)
        Me.Button_Eliminar_Registro.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Eliminar_Registro.Name = "Button_Eliminar_Registro"
        Me.Button_Eliminar_Registro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Eliminar_Registro.Size = New System.Drawing.Size(135, 138)
        Me.Button_Eliminar_Registro.TabIndex = 2
        Me.Button_Eliminar_Registro.Text = "Delete Record"
        Me.Button_Eliminar_Registro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Eliminar_Registro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Eliminar_Registro.UseVisualStyleBackColor = True
        '
        'Button_Modificar_Datos_Paciente
        '
        Me.Button_Modificar_Datos_Paciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Modificar_Datos_Paciente.FlatAppearance.BorderSize = 0
        Me.Button_Modificar_Datos_Paciente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Modificar_Datos_Paciente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Modificar_Datos_Paciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Modificar_Datos_Paciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Modificar_Datos_Paciente.Image = CType(resources.GetObject("Button_Modificar_Datos_Paciente.Image"), System.Drawing.Image)
        Me.Button_Modificar_Datos_Paciente.Location = New System.Drawing.Point(270, 0)
        Me.Button_Modificar_Datos_Paciente.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Modificar_Datos_Paciente.Name = "Button_Modificar_Datos_Paciente"
        Me.Button_Modificar_Datos_Paciente.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Modificar_Datos_Paciente.Size = New System.Drawing.Size(135, 138)
        Me.Button_Modificar_Datos_Paciente.TabIndex = 3
        Me.Button_Modificar_Datos_Paciente.Text = "Edit Patient Data"
        Me.Button_Modificar_Datos_Paciente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Modificar_Datos_Paciente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Modificar_Datos_Paciente.UseVisualStyleBackColor = True
        '
        'Button_Eliminar_Paciente
        '
        Me.Button_Eliminar_Paciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Eliminar_Paciente.FlatAppearance.BorderSize = 0
        Me.Button_Eliminar_Paciente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Paciente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Eliminar_Paciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Eliminar_Paciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Eliminar_Paciente.Image = Global.Bohíque_FMS.My.Resources.Resources.Vcard_Delete
        Me.Button_Eliminar_Paciente.Location = New System.Drawing.Point(405, 0)
        Me.Button_Eliminar_Paciente.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Eliminar_Paciente.Name = "Button_Eliminar_Paciente"
        Me.Button_Eliminar_Paciente.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Eliminar_Paciente.Size = New System.Drawing.Size(135, 138)
        Me.Button_Eliminar_Paciente.TabIndex = 4
        Me.Button_Eliminar_Paciente.Text = "Delete Patients"
        Me.Button_Eliminar_Paciente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Eliminar_Paciente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Eliminar_Paciente.UseVisualStyleBackColor = True
        '
        'TabPageEX_Herramientas
        '
        Me.TabPageEX_Herramientas.Controls.Add(Me.FlowLayoutPanel_Herramientas)
        Me.TabPageEX_Herramientas.Location = New System.Drawing.Point(4, 34)
        Me.TabPageEX_Herramientas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPageEX_Herramientas.Name = "TabPageEX_Herramientas"
        Me.TabPageEX_Herramientas.Size = New System.Drawing.Size(894, 92)
        Me.TabPageEX_Herramientas.TabIndex = 2
        Me.TabPageEX_Herramientas.Text = "Tools"
        '
        'FlowLayoutPanel_Herramientas
        '
        Me.FlowLayoutPanel_Herramientas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.FlowLayoutPanel_Herramientas.Controls.Add(Me.Button_Analizis_Registro)
        Me.FlowLayoutPanel_Herramientas.Controls.Add(Me.Button_Agregar_Grafica)
        Me.FlowLayoutPanel_Herramientas.Controls.Add(Me.Button_Limpiar_Temporales)
        Me.FlowLayoutPanel_Herramientas.Controls.Add(Me.Button_Exportar_Resultados)
        Me.FlowLayoutPanel_Herramientas.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel_Herramientas.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel_Herramientas.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel_Herramientas.Name = "FlowLayoutPanel_Herramientas"
        Me.FlowLayoutPanel_Herramientas.Size = New System.Drawing.Size(525, 138)
        Me.FlowLayoutPanel_Herramientas.TabIndex = 2
        Me.FlowLayoutPanel_Herramientas.TabStop = True
        '
        'Button_Analizis_Registro
        '
        Me.Button_Analizis_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Analizis_Registro.FlatAppearance.BorderSize = 0
        Me.Button_Analizis_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Analizis_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Analizis_Registro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Analizis_Registro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Analizis_Registro.Image = Global.Bohíque_FMS.My.Resources.Resources.Document_Inspector
        Me.Button_Analizis_Registro.Location = New System.Drawing.Point(0, 0)
        Me.Button_Analizis_Registro.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Analizis_Registro.Name = "Button_Analizis_Registro"
        Me.Button_Analizis_Registro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Analizis_Registro.Size = New System.Drawing.Size(120, 138)
        Me.Button_Analizis_Registro.TabIndex = 1
        Me.Button_Analizis_Registro.Text = "Process Record"
        Me.Button_Analizis_Registro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Analizis_Registro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Analizis_Registro.UseVisualStyleBackColor = True
        '
        'Button_Agregar_Grafica
        '
        Me.Button_Agregar_Grafica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Agregar_Grafica.FlatAppearance.BorderSize = 0
        Me.Button_Agregar_Grafica.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Agregar_Grafica.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Agregar_Grafica.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Agregar_Grafica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Agregar_Grafica.Image = CType(resources.GetObject("Button_Agregar_Grafica.Image"), System.Drawing.Image)
        Me.Button_Agregar_Grafica.Location = New System.Drawing.Point(120, 0)
        Me.Button_Agregar_Grafica.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Agregar_Grafica.Name = "Button_Agregar_Grafica"
        Me.Button_Agregar_Grafica.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Agregar_Grafica.Size = New System.Drawing.Size(120, 138)
        Me.Button_Agregar_Grafica.TabIndex = 2
        Me.Button_Agregar_Grafica.Text = "Plot Record"
        Me.Button_Agregar_Grafica.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Agregar_Grafica.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Agregar_Grafica.UseVisualStyleBackColor = True
        '
        'Button_Limpiar_Temporales
        '
        Me.Button_Limpiar_Temporales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Limpiar_Temporales.FlatAppearance.BorderSize = 0
        Me.Button_Limpiar_Temporales.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Limpiar_Temporales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Limpiar_Temporales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Limpiar_Temporales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Limpiar_Temporales.Image = Global.Bohíque_FMS.My.Resources.Resources.Document_Shred
        Me.Button_Limpiar_Temporales.Location = New System.Drawing.Point(240, 0)
        Me.Button_Limpiar_Temporales.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Limpiar_Temporales.Name = "Button_Limpiar_Temporales"
        Me.Button_Limpiar_Temporales.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Limpiar_Temporales.Size = New System.Drawing.Size(142, 138)
        Me.Button_Limpiar_Temporales.TabIndex = 2
        Me.Button_Limpiar_Temporales.Text = "Clean Temporary"
        Me.Button_Limpiar_Temporales.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Limpiar_Temporales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Limpiar_Temporales.UseVisualStyleBackColor = True
        '
        'Button_Exportar_Resultados
        '
        Me.Button_Exportar_Resultados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Exportar_Resultados.FlatAppearance.BorderSize = 0
        Me.Button_Exportar_Resultados.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Exportar_Resultados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Exportar_Resultados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Exportar_Resultados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Exportar_Resultados.Image = Global.Bohíque_FMS.My.Resources.Resources.Document_Move
        Me.Button_Exportar_Resultados.Location = New System.Drawing.Point(382, 0)
        Me.Button_Exportar_Resultados.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Exportar_Resultados.Name = "Button_Exportar_Resultados"
        Me.Button_Exportar_Resultados.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Exportar_Resultados.Size = New System.Drawing.Size(142, 138)
        Me.Button_Exportar_Resultados.TabIndex = 2
        Me.Button_Exportar_Resultados.Text = "Export Results"
        Me.Button_Exportar_Resultados.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Exportar_Resultados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Exportar_Resultados.UseVisualStyleBackColor = True
        '
        'TabPageEX_Especiales
        '
        Me.TabPageEX_Especiales.Controls.Add(Me.FlowLayoutPanel_Control_Especial)
        Me.TabPageEX_Especiales.Location = New System.Drawing.Point(4, 34)
        Me.TabPageEX_Especiales.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TabPageEX_Especiales.Name = "TabPageEX_Especiales"
        Me.TabPageEX_Especiales.Size = New System.Drawing.Size(894, 92)
        Me.TabPageEX_Especiales.TabIndex = 3
        Me.TabPageEX_Especiales.Text = "Special Controls"
        '
        'FlowLayoutPanel_Control_Especial
        '
        Me.FlowLayoutPanel_Control_Especial.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel_Control_Especial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.FlowLayoutPanel_Control_Especial.Controls.Add(Me.Button_Buscar_Base_Datos)
        Me.FlowLayoutPanel_Control_Especial.Controls.Add(Me.Button_Optimizar_Base_Datos)
        Me.FlowLayoutPanel_Control_Especial.Controls.Add(Me.Button_Crear_Base_Datos)
        Me.FlowLayoutPanel_Control_Especial.Controls.Add(Me.Button_Reiniciar_Base_Datos)
        Me.FlowLayoutPanel_Control_Especial.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel_Control_Especial.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel_Control_Especial.Margin = New System.Windows.Forms.Padding(0)
        Me.FlowLayoutPanel_Control_Especial.Name = "FlowLayoutPanel_Control_Especial"
        Me.FlowLayoutPanel_Control_Especial.Size = New System.Drawing.Size(616, 138)
        Me.FlowLayoutPanel_Control_Especial.TabIndex = 3
        Me.FlowLayoutPanel_Control_Especial.TabStop = True
        '
        'Button_Buscar_Base_Datos
        '
        Me.Button_Buscar_Base_Datos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Buscar_Base_Datos.FlatAppearance.BorderSize = 0
        Me.Button_Buscar_Base_Datos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Buscar_Base_Datos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Buscar_Base_Datos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Buscar_Base_Datos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Buscar_Base_Datos.Image = CType(resources.GetObject("Button_Buscar_Base_Datos.Image"), System.Drawing.Image)
        Me.Button_Buscar_Base_Datos.Location = New System.Drawing.Point(0, 0)
        Me.Button_Buscar_Base_Datos.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Buscar_Base_Datos.Name = "Button_Buscar_Base_Datos"
        Me.Button_Buscar_Base_Datos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Buscar_Base_Datos.Size = New System.Drawing.Size(142, 138)
        Me.Button_Buscar_Base_Datos.TabIndex = 1
        Me.Button_Buscar_Base_Datos.Text = "Search Database"
        Me.Button_Buscar_Base_Datos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Buscar_Base_Datos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Buscar_Base_Datos.UseVisualStyleBackColor = True
        '
        'Button_Optimizar_Base_Datos
        '
        Me.Button_Optimizar_Base_Datos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Optimizar_Base_Datos.FlatAppearance.BorderSize = 0
        Me.Button_Optimizar_Base_Datos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Optimizar_Base_Datos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Optimizar_Base_Datos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Optimizar_Base_Datos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Optimizar_Base_Datos.Image = CType(resources.GetObject("Button_Optimizar_Base_Datos.Image"), System.Drawing.Image)
        Me.Button_Optimizar_Base_Datos.Location = New System.Drawing.Point(142, 0)
        Me.Button_Optimizar_Base_Datos.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Optimizar_Base_Datos.Name = "Button_Optimizar_Base_Datos"
        Me.Button_Optimizar_Base_Datos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Optimizar_Base_Datos.Size = New System.Drawing.Size(165, 138)
        Me.Button_Optimizar_Base_Datos.TabIndex = 3
        Me.Button_Optimizar_Base_Datos.Text = "Optimize Database"
        Me.Button_Optimizar_Base_Datos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Optimizar_Base_Datos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Optimizar_Base_Datos.UseVisualStyleBackColor = True
        Me.Button_Optimizar_Base_Datos.Visible = False
        '
        'Button_Crear_Base_Datos
        '
        Me.Button_Crear_Base_Datos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Crear_Base_Datos.FlatAppearance.BorderSize = 0
        Me.Button_Crear_Base_Datos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Crear_Base_Datos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Crear_Base_Datos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Crear_Base_Datos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Crear_Base_Datos.Image = CType(resources.GetObject("Button_Crear_Base_Datos.Image"), System.Drawing.Image)
        Me.Button_Crear_Base_Datos.Location = New System.Drawing.Point(307, 0)
        Me.Button_Crear_Base_Datos.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Crear_Base_Datos.Name = "Button_Crear_Base_Datos"
        Me.Button_Crear_Base_Datos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Crear_Base_Datos.Size = New System.Drawing.Size(142, 138)
        Me.Button_Crear_Base_Datos.TabIndex = 2
        Me.Button_Crear_Base_Datos.Text = "Create Database"
        Me.Button_Crear_Base_Datos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Crear_Base_Datos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Crear_Base_Datos.UseVisualStyleBackColor = True
        Me.Button_Crear_Base_Datos.Visible = False
        '
        'Button_Reiniciar_Base_Datos
        '
        Me.Button_Reiniciar_Base_Datos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button_Reiniciar_Base_Datos.FlatAppearance.BorderSize = 0
        Me.Button_Reiniciar_Base_Datos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button_Reiniciar_Base_Datos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button_Reiniciar_Base_Datos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Reiniciar_Base_Datos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Reiniciar_Base_Datos.Image = CType(resources.GetObject("Button_Reiniciar_Base_Datos.Image"), System.Drawing.Image)
        Me.Button_Reiniciar_Base_Datos.Location = New System.Drawing.Point(449, 0)
        Me.Button_Reiniciar_Base_Datos.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Reiniciar_Base_Datos.Name = "Button_Reiniciar_Base_Datos"
        Me.Button_Reiniciar_Base_Datos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_Reiniciar_Base_Datos.Size = New System.Drawing.Size(165, 138)
        Me.Button_Reiniciar_Base_Datos.TabIndex = 4
        Me.Button_Reiniciar_Base_Datos.Text = "Reset Database"
        Me.Button_Reiniciar_Base_Datos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_Reiniciar_Base_Datos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button_Reiniciar_Base_Datos.UseVisualStyleBackColor = True
        Me.Button_Reiniciar_Base_Datos.Visible = False
        '
        'SplitContainer_Principal
        '
        Me.SplitContainer_Principal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_Principal.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer_Principal.IsSplitterFixed = True
        Me.SplitContainer_Principal.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_Principal.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer_Principal.Name = "SplitContainer_Principal"
        Me.SplitContainer_Principal.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer_Principal.Panel1
        '
        Me.SplitContainer_Principal.Panel1.BackgroundImage = CType(resources.GetObject("SplitContainer_Principal.Panel1.BackgroundImage"), System.Drawing.Image)
        Me.SplitContainer_Principal.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer_Principal.Panel1.Controls.Add(TabControlEX_Principal)
        Me.SplitContainer_Principal.Panel1MinSize = 120
        '
        'SplitContainer_Principal.Panel2
        '
        Me.SplitContainer_Principal.Panel2.AutoScroll = True
        Me.SplitContainer_Principal.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer_Principal.Panel2.BackgroundImage = CType(resources.GetObject("SplitContainer_Principal.Panel2.BackgroundImage"), System.Drawing.Image)
        Me.SplitContainer_Principal.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitContainer_Principal.Panel2MinSize = 120
        Me.SplitContainer_Principal.Size = New System.Drawing.Size(902, 498)
        Me.SplitContainer_Principal.SplitterDistance = 130
        Me.SplitContainer_Principal.SplitterWidth = 2
        Me.SplitContainer_Principal.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'BackgroundWorker_Exportar_Resultados_1
        '
        Me.BackgroundWorker_Exportar_Resultados_1.WorkerReportsProgress = True
        Me.BackgroundWorker_Exportar_Resultados_1.WorkerSupportsCancellation = True
        '
        'BackgroundWorker_Exportar_Resultados_2
        '
        Me.BackgroundWorker_Exportar_Resultados_2.WorkerReportsProgress = True
        Me.BackgroundWorker_Exportar_Resultados_2.WorkerSupportsCancellation = True
        '
        'BackgroundWorker_Exportar_Resultados_3
        '
        Me.BackgroundWorker_Exportar_Resultados_3.WorkerReportsProgress = True
        Me.BackgroundWorker_Exportar_Resultados_3.WorkerSupportsCancellation = True
        '
        'BackgroundWorker_Exportar_Resultados_4
        '
        Me.BackgroundWorker_Exportar_Resultados_4.WorkerReportsProgress = True
        Me.BackgroundWorker_Exportar_Resultados_4.WorkerSupportsCancellation = True
        '
        'BackgroundWorker_Exportar_Resultados_5
        '
        Me.BackgroundWorker_Exportar_Resultados_5.WorkerReportsProgress = True
        Me.BackgroundWorker_Exportar_Resultados_5.WorkerSupportsCancellation = True
        '
        'BackgroundWorker_Exportar_Resultados_6
        '
        Me.BackgroundWorker_Exportar_Resultados_6.WorkerReportsProgress = True
        Me.BackgroundWorker_Exportar_Resultados_6.WorkerSupportsCancellation = True
        '
        'OpenFileDialog_Buscar_Base_Datos
        '
        Me.OpenFileDialog_Buscar_Base_Datos.FileName = "OpenFileDialog2"
        Me.OpenFileDialog_Buscar_Base_Datos.Filter = "Base de Datos|*.mdf"
        '
        'Form_Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(902, 498)
        Me.Controls.Add(Me.SplitContainer_Principal)
        Me.Enabled = False
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimumSize = New System.Drawing.Size(896, 476)
        Me.Name = "Form_Principal"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guest"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        TabControlEX_Principal.ResumeLayout(False)
        Me.TabPageEX_Usuarios.ResumeLayout(False)
        Me.FlowLayoutPanel_Principal.ResumeLayout(False)
        Me.TabPageEX_Registro.ResumeLayout(False)
        Me.FlowLayoutPanel_Registro.ResumeLayout(False)
        Me.TabPageEX_Herramientas.ResumeLayout(False)
        Me.FlowLayoutPanel_Herramientas.ResumeLayout(False)
        Me.TabPageEX_Especiales.ResumeLayout(False)
        Me.FlowLayoutPanel_Control_Especial.ResumeLayout(False)
        Me.SplitContainer_Principal.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer_Principal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Principal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer_Principal As SplitContainer
    Friend WithEvents FlowLayoutPanel_Principal As FlowLayoutPanel
    Friend WithEvents Button_Cambiar_Usuario As Button
    Friend WithEvents TabPageEX_Usuarios As Dotnetrix.Controls.TabPageEX
    Friend WithEvents TabPageEX_Registro As Dotnetrix.Controls.TabPageEX
    Friend WithEvents TabPageEX_Herramientas As Dotnetrix.Controls.TabPageEX
    Friend WithEvents Button_Modificar_Contraseña As Button
    Friend WithEvents Button_Crear_Usuario As Button
    Friend WithEvents Button_Eliminar_Usuario As Button
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel_Registro As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel_Herramientas As FlowLayoutPanel
    Friend WithEvents Button_Analizis_Registro As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Button_Eliminar_Registro As Button
    Friend WithEvents Button_Modificar_Datos_Paciente As Button
    Friend WithEvents Button_Eliminar_Paciente As Button
    Friend WithEvents Button_Agregar_Grafica As Button
    Friend WithEvents Button_Limpiar_Temporales As Button
    Friend WithEvents Button_Exportar_Resultados As Button
    Friend WithEvents Button_Almacenar_Multiples_Registros As Button
    Friend WithEvents FolderBrowserDialog_Buscar_Carpeta_Registros As FolderBrowserDialog
    Friend WithEvents TabPageEX_Especiales As Dotnetrix.Controls.TabPageEX
    Friend WithEvents FlowLayoutPanel_Control_Especial As FlowLayoutPanel
    Friend WithEvents Button_Reiniciar_Base_Datos As Button
    Friend WithEvents BackgroundWorker_Exportar_Resultados_1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker_Exportar_Resultados_2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker_Exportar_Resultados_3 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker_Exportar_Resultados_4 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker_Exportar_Resultados_5 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker_Exportar_Resultados_6 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button_Optimizar_Base_Datos As Button
    Friend WithEvents FolderBrowserDialog_Ubicacion_Base_Datos As FolderBrowserDialog
    Friend WithEvents Button_Buscar_Base_Datos As Button
    Friend WithEvents OpenFileDialog_Buscar_Base_Datos As OpenFileDialog
    Friend WithEvents Button_Crear_Base_Datos As Button
End Class
