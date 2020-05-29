Imports capaNegocios
Imports capaEntidad
Public Class frmListaNotas
    Dim objNego As New clsRNNotas
    Dim objNota As New clsNotas
    Sub ListaNotasAlumnos()
        Dim dt As DataTable = objNego.N_ListaNotaAlumno
        Dgv_NotaAlumnos.DataSource = dt
    End Sub

    Sub Limpiar()
        txtCalificacion.Clear()
        dtpFecha.CustomFormat = ""
    End Sub
    Private Sub frmListaNotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListaNotasAlumnos()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim idNota As Integer
        Dim i As Integer
        Dim d As DateTime = Nothing
        If Me.Dgv_NotaAlumnos.CurrentRow IsNot Nothing Then
            If txtCalificacion.Text = "" Or dtpFecha.Value = d Then
                MessageBox.Show("Porfavor llene todos los datos")
            Else
                i = Dgv_NotaAlumnos.CurrentRow.Index
                idNota = Dgv_NotaAlumnos.Item(0, i).Value()


                objNota.calificacion = txtCalificacion.Text
                objNota.fecha = dtpFecha.Value
                objNego.N_EditarNotaAlumno(objNota, idNota)
                Limpiar()
                MsgBox("Actualización Exitosa")
                ListaNotasAlumnos()
            End If
        Else
            MsgBox("No hay notas para seleccionar")
        End If


    End Sub

    Private Sub Dgv_NotaAlumnos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_NotaAlumnos.CellClick
        Dim i As Integer
        i = Dgv_NotaAlumnos.CurrentRow.Index
        txtCalificacion.Text = Dgv_NotaAlumnos.Item(4, i).Value()
        dtpFecha.Value = Dgv_NotaAlumnos.Item(5, i).Value()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim idNota As Integer
        Dim i As Integer
        If Not Dgv_NotaAlumnos.CurrentRow Is Nothing Then
            i = Dgv_NotaAlumnos.CurrentRow.Index
            idNota = Dgv_NotaAlumnos.Item(0, i).Value()
            objNego.N_EliminarNotaAlumno(idNota)
            Limpiar()
            MsgBox("Eliminacion Exitosa")
            ListaNotasAlumnos()
        Else
            MsgBox("No hay notas registradas")
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Public Sub NumerosyDecimal(ByVal CajaTexto As Windows.Forms.TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not CajaTexto.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtCalificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCalificacion.KeyPress
        NumerosyDecimal(txtCalificacion, e)
    End Sub
End Class