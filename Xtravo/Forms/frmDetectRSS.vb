Public Class frmDetectRSS
    Private hasFeeds As Boolean = False
    Private Sub frmDetectRSS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim li As ListItem
            Dim oEl As HtmlElement
            For Each oEl In AppManager.CurrentBrowser.Document.All
                If oEl.GetAttribute("Type") = "application/rss+xml" Then
                    li = New ListItem
                    li.Text = oEl.GetAttribute("Title")
                    li.Value = oEl.GetAttribute("Href")
                    ListBox1.Items.Add(li)
                    hasFeeds = True
                End If
            Next
            If hasFeeds = False Then
                Label1.Text = "No feeds detected on this webpage"
                btnAdd.Enabled = False
            End If
        Catch ex As Exception
            Label1.Text = "An error occured detecting feeds on this page."
            btnAdd.Enabled = False
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim ofrm As New frmAddRSS
        Dim li As ListItem = ListBox1.SelectedItem
        ofrm.txtTitle.Text = li.Text
        ofrm.txtURL.Text = li.Value
        ofrm.Mode = frmAddRSS.Modes.AddFeed
        ofrm.ShowDialog()
    End Sub
End Class