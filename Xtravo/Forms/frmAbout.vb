Imports System.IO
Public Class frmAbout
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label1.Text = ProductVersion()
    End Sub
End Class