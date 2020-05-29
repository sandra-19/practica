Imports capaDatos
Imports capaEntidad
Public Class clsRNAsignatura
    Private objDatos As New clsDAsignatura
    Public Function N_ListaAsignatura() As DataTable
        Return objDatos.D_ListaAsignatura
    End Function

    Public Sub N_InsertarAsignatura(enti As clsAsignatura)
        objDatos.D_InsertarAsignatura(enti)
    End Sub
    Public Sub N_EditarAsignatura(enti As clsAsignatura, idAsig As Integer)
        objDatos.D_EditarAsignatura(enti, idAsig)
    End Sub
    Public Sub N_EliminarAsignatura(idAsig As Integer)
        objDatos.D_EliminarAsignatura(idAsig)
    End Sub

    Public Function N_ListaAsignaturaList() As DataTable
        Return objDatos.D_ListaAsignaturaList
    End Function
End Class
