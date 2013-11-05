Public Class frmpasshis
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = My.Settings.Passwordbrowser Then
            Me.Close()
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.History))
        End If
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text = My.Settings.Passwordbrowser Then
                Me.Close()
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.History))
            End If
        End If
    End Sub
End Class