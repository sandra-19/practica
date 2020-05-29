Imports capaNegocios
Imports capaEntidad
Public Class frmAsignatura
    Dim objNego As New clsRNAsignatura
    Dim objEnt As New clsAsignatura

    Sub Limpiar()
        txtNombreAsignatura.Clear()
        txtNumAula.Clear()
    End Sub

    Sub ListaAsignatura()
        Dim dt As DataTable = objNego.N_ListaAsignatura
        Dgv_Asignatura.DataSource = dt

    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If txtNombreAsignatura.Text = "" Or txtNumAula.Text = "" Then
            MessageBox.Show("Porfavor llene todos los datos")
        Else
            objEnt.nombreAsignatura = txtNombreAsignatura.Text
            objEnt.numAula = txtNumAula.Text
            objNego.N_InsertarAsignatura(objEnt)
            MessageBox.Show("Datos Insertados correctamente")
            Limpiar()
            ListaAsignatura()
        End If

    End Sub

    Private Sub frmAsignatura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListaAsignatura()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim idAsignatura As Integer
        Dim i As Integer

        If Me.Dgv_Asignatura.CurrentRow IsNot Nothing Then
            If txtNombreAsignatura.Text = "" Or txtNumAula.Text = "" Then
                MessageBox.Show("Porfavor llene todos los datos")
            Else
                i = Dgv_Asignatura.CurrentRow.Index
                idAsignatura = Dgv_Asignatura.Item(0, i).Value()


                objEnt.nombreAsignatura = txtNombreAsignatura.Text
                objEnt.numAula = txtNumAula.Text
                objNego.N_EditarAsignatura(objEnt, idAsignatura)
                Limpiar()
                MsgBox("Actualización Exitosa")
                btnAgregar.Enabled = True
                ListaAsignatura()
            End If
        Else

        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim idAsig As Integer
        Dim i As Integer
        If Not Dgv_Asignatura.CurrentRow Is Nothing Then
            i = Dgv_Asignatura.CurrentRow.Index
            idAsig = Dgv_Asignatura.Item(0, i).Value()
            Try
                objNego.N_EliminarAsignatura(idAsig)
                Limpiar()
                MsgBox("Eliminacion Exitosa")
                btnAgregar.Enabled = True
                ListaAsignatura()
            Catch ex As Exception
                MsgBox("Esta asignatura tiene notas asignadas porfavor primero elimine las notas")
                Limpiar()
            End Try
        Else
            MsgBox("No hay asignaturas registradas")
        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Dgv_Asignatura_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Asignatura.CellClick
        Dim i As Integer
        btnAgregar.Enabled = False
        i = Dgv_Asignatura.CurrentRow.Index
        txtNombreAsignatura.Text = Dgv_Asignatura.Item(1, i).Value()
        txtNumAula.Text = Dgv_Asignatura.Item(2, i).Value()
    End Sub

    Private Sub txtNombreAsignatura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreAsignatura.KeyPress
        If Not Char.IsLetter(e.KeyChar) _
                     AndAlso Not Char.IsControl(e.KeyChar) _
                     AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumAula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumAula.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class