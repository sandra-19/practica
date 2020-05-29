Imports capaNegocios
Imports capaEntidad


Public Class frmAlumno
    Dim objNego As New clsNegocios
    Dim objEnt As New clsAlumno

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListaAlumnos()


    End Sub
    Sub ListaAlumnos()
        Dim dt As DataTable = objNego.N_ListaAlumnos
        Dgv_Alumnos.DataSource = dt

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim sexo As String = ""
        If rbFemenino.Checked = False And rbMasculino.Checked = False Or txtNombreAlumno.Text = "" Or txtApellidosAlumnos.Text = "" Or txtTelefono.Text = "" Or txtCorreo.Text = "" Then
            MessageBox.Show("Porfavor llene todos los datos")
        Else
            If rbFemenino.Checked = True Then
                sexo = "F"
            ElseIf rbMasculino.Checked = True Then
                sexo = "M"
            End If


            objEnt.nombre = txtNombreAlumno.Text
            objEnt.apellido = txtApellidosAlumnos.Text
            objEnt.sexo = sexo


            If txtTelefono.Text.Trim().Length > 9 Then
                MessageBox.Show("El Teléfono debe tener 9 dígitos")
                txtTelefono.Clear()
                Return
            Else
                objEnt.numero = txtTelefono.Text
            End If


            objEnt.email = txtCorreo.Text
            objNego.N_InsertarAlumnos(objEnt)
            MessageBox.Show("Datos Insertados correctamente")
            Limpiar()
            ListaAlumnos()
        End If


    End Sub

    Private Sub btnEditar_Click_1(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim idAlumnos As Integer
        Dim i As Integer

        If Me.Dgv_Alumnos.CurrentRow IsNot Nothing Then
            If rbFemenino.Checked = False And rbMasculino.Checked = False Or txtNombreAlumno.Text = "" Or txtApellidosAlumnos.Text = "" Or txtTelefono.Text = "" Or txtCorreo.Text = "" Then
                MessageBox.Show("Porfavor llene todos los datos")
            Else
                i = Dgv_Alumnos.CurrentRow.Index
                idAlumnos = Dgv_Alumnos.Item(0, i).Value()
                Dim sexo As String = ""
                If rbFemenino.Checked = True Then
                    sexo = "F"
                ElseIf rbMasculino.Checked = True Then
                    sexo = "M"
                End If

                If txtTelefono.Text.Trim().Length > 9 Then
                    MessageBox.Show("El Teléfono debe tener 9 dígitos")
                    txtTelefono.Clear()
                    Return
                Else
                    objEnt.numero = txtTelefono.Text
                End If

                objEnt.nombre = txtNombreAlumno.Text
                objEnt.apellido = txtApellidosAlumnos.Text
                objEnt.sexo = sexo
                objEnt.email = txtCorreo.Text
                objNego.N_EditarAlumnos(objEnt, idAlumnos)
                Limpiar()
                MsgBox("Actualización Exitosa")
                btnAgregar.Enabled = True
                ListaAlumnos()
            End If
        Else
            MsgBox("No existe ningun alumno registrado")
        End If


    End Sub
    Sub Limpiar()
        txtNombreAlumno.Clear()
        txtApellidosAlumnos.Clear()
        txtTelefono.Clear()
        txtCorreo.Clear()
        rbFemenino.Checked = False
        rbMasculino.Checked = False
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim idAlumn As Integer
        Dim i As Integer
        If Not Dgv_Alumnos.CurrentRow Is Nothing Then
            i = Dgv_Alumnos.CurrentRow.Index
            idAlumn = Dgv_Alumnos.Item(0, i).Value()
            Try
                objNego.N_EliminarAlumno(idAlumn)
                Limpiar()
                MsgBox("Eliminacion Exitosa")
                btnAgregar.Enabled = True
                ListaAlumnos()
            Catch ex As Exception
                MsgBox("Esta alumno tiene notas asignadas porfavor primero elimine las notas")
                Limpiar()
            End Try
        Else
            MsgBox("No hay alumnos registrados")
        End If

    End Sub

    Private Sub Dgv_Alumnos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv_Alumnos.CellClick
        Dim i As Integer
        btnAgregar.Enabled = False
        If Dgv_Alumnos.Item(3, i).Value() = "F" Then
            rbFemenino.Checked = True
        ElseIf Dgv_Alumnos.Item(3, i).Value() = "M" Then
            rbMasculino.Checked = True
        End If
        i = Dgv_Alumnos.CurrentRow.Index
        txtNombreAlumno.Text = Dgv_Alumnos.Item(1, i).Value()
        txtApellidosAlumnos.Text = Dgv_Alumnos.Item(2, i).Value()
        txtTelefono.Text = Dgv_Alumnos.Item(4, i).Value()
        txtCorreo.Text = Dgv_Alumnos.Item(5, i).Value()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtNombreAlumno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreAlumno.KeyPress
        If Not Char.IsLetter(e.KeyChar) _
                     AndAlso Not Char.IsControl(e.KeyChar) _
                     AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtApellidosAlumnos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellidosAlumnos.KeyPress
        If Not Char.IsLetter(e.KeyChar) _
                     AndAlso Not Char.IsControl(e.KeyChar) _
                     AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class
