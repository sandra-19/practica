Public Class frmPrincipal
    Private Sub lblAlumno_Click(sender As Object, e As EventArgs) Handles lblAlumno.Click
        Dim frm As New frmAlumno
        frm.Show()
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub lblAsignatura_Click(sender As Object, e As EventArgs) Handles lblAsignatura.Click
        Dim frm As New frmAsignatura
        frm.Show()
    End Sub

    Private Sub lblNotas_Click(sender As Object, e As EventArgs) Handles lblNotas.Click
        Dim frm As New frmNotas
        frm.Show()
    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblHora.Text = DateTime.Now.ToString("hh:mm:ss")
        lblFecha.Text = DateTime.Now.ToLongDateString()
    End Sub
End Class