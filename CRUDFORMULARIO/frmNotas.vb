Imports capaNegocios
Imports capaEntidad
Public Class frmNotas
    Dim objNego As New clsRNAsignatura
    Dim objNegoA As New clsNegocios
    Dim objNegoN As New clsRNNotas
    Dim objNota As New clsNotas
    Dim idAsig As Integer
    Dim idAlumno As Integer
    Sub ListaAsignaturas()
        Dim dt As DataTable = objNego.N_ListaAsignaturaList
        Dgv_Asignatura.DataSource = dt
    End Sub

    Sub ListaAlumnos()
        Dim dt As DataTable = objNegoA.N_ListaAlumnoList
        dgv_Alumno.DataSource = dt

    End Sub
    Private Sub frmNotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListaAsignaturas()
        ListaAlumnos()
    End Sub

    Private Sub Dgv_Asignatura_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Asignatura.CellClick
        Dim i As Integer
        i = Dgv_Asignatura.CurrentRow.Index
        idAsig = Dgv_Asignatura.Item(0, i).Value()
        txtAsignatura.Text = Dgv_Asignatura.Item(1, i).Value()
    End Sub


    Private Sub dgv_Alumno_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Alumno.CellClick
        Dim i As Integer
        i = dgv_Alumno.CurrentRow.Index
        idAlumno = dgv_Alumno.Item(0, i).Value()
        txtAlumno.Text = dgv_Alumno.Item(1, i).Value()
    End Sub

    Sub Limpiar()
        txtAsignatura.Clear()
        txtAlumno.Clear()
        txtCalificacion.Clear()
        dtpFecha.CustomFormat = ""
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        objNota.idAsigNatura = idAsig
        objNota.idAlumno = idAlumno
        Dim d As DateTime = Nothing
        If txtCalificacion.Text = "" Or dtpFecha.Value = d Then
            MessageBox.Show("Porfavor llene todos los datos")
        Else
            Try
                If Val(txtCalificacion.Text) > 0 And Val(txtCalificacion.Text) < 20 Then
                    objNota.calificacion = txtCalificacion.Text
                Else
                    MessageBox.Show("La calificación debe estar entre 0 y 20")
                    txtCalificacion.Clear()
                    Return
                End If

                objNota.fecha = dtpFecha.Value

                objNegoN.N_InsertarNota(objNota)
                MessageBox.Show("Datos Insertados correctamente")
                Limpiar()
                ListaAlumnos()
            Catch ex As Exception
                MessageBox.Show("Debe elegir Asignatura y Alumno validos")
                Limpiar()
            End Try
        End If

    End Sub

    Private Sub btnListaNotas_Click(sender As Object, e As EventArgs) Handles btnListaNotas.Click
        Dim frm As New frmListaNotas
        frm.Show()
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