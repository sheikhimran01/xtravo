Public Class frmpasscookie
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = My.Settings.Passwordbrowser Then
            Me.Close()
            Dim ofrm As New frmCookieViewer
            frmMain.tc1.TabPages.Add(ofrm)
            frmMain.gbFavs.Visible = False
        End If
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text = My.Settings.Passwordbrowser Then
                Me.Close()
                Dim ofrm As New frmCookieViewer
                frmMain.tc1.TabPages.Add(ofrm)
                frmMain.gbFavs.Visible = False
            End If
        End If
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class