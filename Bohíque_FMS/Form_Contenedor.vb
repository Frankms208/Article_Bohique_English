Public Class Form_Contenedor
    Public Modulo_Anlisis As UserControl_Modulo_Analicis_Señal = Nothing
    Private Sub Form_Contenedor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If IsNothing(Modulo_Anlisis) = False Then
            Form_Principal.Estado_Registros.Desbloquear_Registro(Modulo_Anlisis.Registro_Seleccionado.Tabla)
            For j = Modulo_Anlisis.Registro_Seleccionado_Multi_Registros.Count - 1 To 0 Step -1
                Form_Principal.Estado_Registros.Desbloquear_Registro(Modulo_Anlisis.Registro_Seleccionado_Multi_Registros.Item(j).Tabla.ToString())
            Next j
        End If
    End Sub

    Private Sub Form_Contenedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class