Imports capaDatos
Imports capaEntidad

Public Class clsNegocios
    Private objDatos As New clsDatos
    Public Function N_ListaAlumnos() As DataTable
        Return objDatos.D_ListaAlumnos
    End Function

    Public Sub N_InsertarAlumnos(enti As clsAlumno)
        objDatos.D_InsertarAlumnos(enti)
    End Sub

    Public Sub N_EditarAlumnos(enti As clsAlumno, idAlumnos As Integer)
        objDatos.D_EditarAlumnos(enti, idAlumnos)
    End Sub

    Public Sub N_EliminarAlumno(idAlumn As Integer)
        objDatos.D_EliminarAlumnos(idAlumn)
    End Sub



    Public Function N_ListaAlumnoList() As DataTable
        Return objDatos.D_ListaAlumnoList
    End Function


End Class
