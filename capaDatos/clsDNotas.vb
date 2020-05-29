Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports capaEntidad
Public Class clsDNotas

    Private cn As New SqlConnection(ConfigurationManager.ConnectionStrings("crudColegio").ConnectionString)

    Public Sub D_InsertarNota(enti As clsNotas)
        Dim cmd As New SqlCommand("EXEC pa_registrar_notas @id_Asig,@calificacion,@fecha_examen,@id_Alum", cn)
        cn.Open()
        cmd.CommandType = CommandType.Text
        With cmd.Parameters
            .AddWithValue("@id_Asig", enti.idAsigNatura)
            .AddWithValue("@calificacion", enti.calificacion)
            .AddWithValue("@fecha_examen", enti.fecha)
            .AddWithValue("@id_Alum", enti.idAlumno)
        End With
        cmd.ExecuteNonQuery()
        cn.Close()
        cmd.Parameters.Clear()
    End Sub

    Public Function D_ListaNotaAlumnos() As DataTable
        Dim cmd As New SqlCommand("EXEC pa_liNotas", cn)
        cn.Open()
        cmd.CommandType = CommandType.Text
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        cn.Close()
        Return dt
    End Function

    Public Sub D_EditarNotaAlumno(enti As clsNotas, idNota As Integer)
        Dim cmd As New SqlCommand("EXEC pa_modificarNota @idNota,@cali,@fechaexam", cn)
        cn.Open()
        cmd.CommandType = CommandType.Text
        With cmd.Parameters
            .AddWithValue("@idNota", idNota)
            .AddWithValue("@cali", enti.calificacion)
            .AddWithValue("@fechaexam", enti.fecha)
        End With
        cmd.ExecuteNonQuery()
        cn.Close()
        cmd.Parameters.Clear()
    End Sub

    Public Sub D_EliminarNotaAlumno(idNota As Integer)
        Dim cmd As New SqlCommand("EXEC pa_eliminar_Nota_Alumno @idNota", cn)
        cn.Open()
        cmd.CommandType = CommandType.Text
        With cmd.Parameters
            .AddWithValue("@idNota", idNota)
        End With
        cmd.ExecuteNonQuery()
        cn.Close()
        cmd.Parameters.Clear()
    End Sub
End Class
