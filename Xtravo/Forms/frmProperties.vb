Public Class frmProperties
    Public obj As Object
    Private Sub frmProperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pg.SelectedObject = obj
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class