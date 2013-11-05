Public Class frmPhising

    Private Sub btnIgnore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIgnore.Click
        Me.Close()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        AppManager.CurrentBrowser.GoBack()
        Me.Close()
    End Sub

    Private Sub frmPhising_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '
    End Sub
End Class