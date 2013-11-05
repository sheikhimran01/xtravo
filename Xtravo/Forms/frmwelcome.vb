Public Class frmwelcome

    Private Sub frmwelcome_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.welcomescreen = False
    End Sub
End Class