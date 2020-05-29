Public Class Presentacion
    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles btnIngresarPresentacion.Click
        Dim fc As New frmPrincipal
        fc.Show()
        Me.Hide()
    End Sub

End Class