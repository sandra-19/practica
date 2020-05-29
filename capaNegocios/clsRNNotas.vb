Imports capaDatos
Imports capaEntidad
Public Class clsRNNotas
    Private objDatos As New clsDNotas

    Public Sub N_InsertarNota(enti As clsNotas)
        objDatos.D_InsertarNota(enti)
    End Sub

    Public Function N_ListaNotaAlumno() As DataTable
        Return objDatos.D_ListaNotaAlumnos
    End Function

    Public Sub N_EditarNotaAlumno(enti As clsNotas, idNot As Integer)
        objDatos.D_EditarNotaAlumno(enti, idNot)
    End Sub
    Public Sub N_EliminarNotaAlumno(idNota As Integer)
        objDatos.D_EliminarNotaAlumno(idNota)
    End Sub

End Class
