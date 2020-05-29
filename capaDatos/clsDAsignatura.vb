Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports capaEntidad
Public Class clsDAsignatura
    Private cn As New SqlConnection(ConfigurationManager.ConnectionStrings("crudColegio").ConnectionString)

    Public Function D_ListaAsignatura() As DataTable
        Dim cmd As New SqlCommand("exec pa_liAsignatura ", cn)
        cn.Open()
        cmd.CommandType = CommandType.Text
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        cn.Close()
        Return dt
    End Function

    Public Sub D_InsertarAsignatura(enti As clsAsignatura)
        Dim cmd As New SqlCommand("EXEC pa_registrar_asignatura @nomAsig,@numAula", cn)
        cn.Open()
        cmd.CommandType = CommandType.Text
        With cmd.Parameters
            .AddWithValue("@nomAsig", enti.nombreAsignatura)
            .AddWithValue("@numAula", enti.numAula)
        End With
        cmd.ExecuteNonQuery()
        cn.Close()
        cmd.Parameters.Clear()
    End Sub

    Public Sub D_EditarAsignatura(enti As clsAsignatura, idAsig As Integer)
        Dim cmd As New SqlCommand("EXEC pa_modificar_asignatura @idAsig,@nomAsig,@numAula", cn)
        cn.Open()
        cmd.CommandType = CommandType.Text
        With cmd.Parameters
            .AddWithValue("@idAsig", idAsig)
            .AddWithValue("@nomAsig", enti.nombreAsignatura)
            .AddWithValue("@numAula", enti.numAula)
        End With
        cmd.ExecuteNonQuery()
        cn.Close()
        cmd.Parameters.Clear()
    End Sub

    Public Sub D_EliminarAsignatura(idAsig As Integer)
        Dim cmd As New SqlCommand("EXEC pa_eliminar_asignatura @idAsig", cn)
        cn.Open()
        cmd.CommandType = CommandType.Text
        With cmd.Parameters
            .AddWithValue("@idAsig", idAsig)
        End With
        cmd.ExecuteNonQuery()
        cn.Close()
        cmd.Parameters.Clear()
    End Sub


    Public Function D_ListaAsignaturaList() As DataTable
        Dim cmd As New SqlCommand("exec pa_liAsignaturaList", cn)
        cn.Open()
        cmd.CommandType = CommandType.Text
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        cn.Close()
        Return dt
    End Function

End Class
