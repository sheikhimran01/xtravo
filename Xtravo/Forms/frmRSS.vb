'///////////////////////////////////////////
'This form is just a quick and dirty example of 
'implementing a RSS reader application
'There are tons of great RSS Reader examples
'available online if you would choose to
'extend the reader to a full powered reader.
'///////////////////////////////////////////
Imports System.Data.OleDb
Imports System.Text
Public Class frmRSS

    Private ShowMenu As Boolean = False

    Private Sub frmRSS_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        wbRSS.Dispose()
    End Sub

    Private Sub frmRSS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgRSS.AutoGenerateColumns = False
        LoadFromDB()
    End Sub


    Dim pcount As Integer = 0

    Public Sub LoadFromDB()

        tvRSS.Nodes(0).Nodes.Clear()
        Dim strSQL As String = "SELECT * FROM RSSGROUPS"
        Dim oConn As New OleDbConnection(AppManager.ConnString)
        Dim oDa As New OleDbDataAdapter(strSQL, oConn)
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oNode As TreeNode

        Try

            oDa.Fill(dt)

            For Each dr In dt.Rows
                oNode = New TreeNode
                If dr.Item("ParentID") = 0 Then
                    oNode.Text = dr.Item("GroupTitle")
                    oNode.Tag = dr.Item("ID")
                    oNode.ImageIndex = 1
                    oNode.StateImageIndex = 1
                    tvRSS.Nodes(0).Nodes.Add(oNode)
                    GetChildren(oNode, dt)
                End If
            Next
            tvRSS.Nodes(0).Expand()
        Catch ex As Exception
            Dim ofrm As New frmError
            ofrm.err = ex
            ofrm.ShowDialog(AppManager.MainForm)
        End Try
    End Sub

    Private Sub GetChildren(ByVal oNode As TreeNode, ByVal dt As DataTable)
        Dim dv As New DataView(dt)
        dv.RowFilter = "parentID=" & Integer.Parse(oNode.Tag)
        Dim row As DataRowView
        Dim cNode As TreeNode
        Try
            For Each row In dv
                ' Perform the node addition
                cNode = New TreeNode
                cNode.Text = row("GroupTitle")
                cNode.Tag = row("ID")
                cNode.ImageIndex = 1
                cNode.StateImageIndex = 1
                oNode.Nodes.Add(cNode)
                GetChannels(cNode)
                GetChildren(cNode, dt)
            Next
        Catch ex As Exception
            Dim ofrm As New frmError
            ofrm.err = ex
            ofrm.ShowDialog(AppManager.MainForm)
        End Try
    End Sub

    Private Sub GetChannels(ByVal iNode As TreeNode)
        Dim strSQL As String = "SELECT * FROM RSSChannels WHERE GROUPID=" & iNode.Tag
        Dim oConn As New OleDbConnection(AppManager.ConnString)
        Dim oDa As New OleDbDataAdapter(strSQL, oConn)
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim xNode As TreeNode

        Try
            oDa.Fill(dt)

            For Each dr In dt.Rows
                xNode = New TreeNode
                xNode.Text = dr.Item("ChannelTitle")
                xNode.Tag = dr.Item("Link")
                xNode.ImageIndex = 0
                xNode.SelectedImageIndex = 0
                iNode.Nodes.Add(xNode)
            Next

        Catch ex As Exception
            Dim ofrm As New frmError
            ofrm.err = ex
            ofrm.ShowDialog(AppManager.MainForm)
        End Try
    End Sub

    Private Sub GetItemsDB(ByVal ChannelID As Integer)
        Dim strSQL As String = "SELECT * FROM RSSFEEDS WHERE ChannelID=" & ChannelID
        Dim oConn As New OleDbConnection(AppManager.ConnString)
        Dim oDa As New OleDbDataAdapter(strSQL, oConn)
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oNode As TreeNode

        Try
            oDa.Fill(dt)

            For Each dr In dt.Rows
                oNode = New TreeNode
                oNode.Text = dr.Item("Title")
                oNode.Tag = dr.Item("Link")
            Next
        Catch ex As Exception
            Dim ofrm As New frmError
            ofrm.err = ex
            If Not IsNothing(Me.Parent) Then
                ofrm.ShowDialog(Me.Parent)
            Else
                ofrm.ShowDialog(Me)
            End If
        End Try
    End Sub

    Private Sub GetItemsFromInternet(ByVal RssLink As String)

        'I am implementing a simple reader here just to show possible add ins..
        'You will probably want to implement something more like...
        'Dim myUrl As String = "URL to feed..."
        'Dim reader As XmlReader = XmlReader.Create(myUrl)
        'While reader.Read

        'End While

        Try
            Dim ds As New DataSet
            ds.ReadXml(RssLink)
            dgRSS.DataSource = ds.Tables("item")
            dgRSS.Update()
            AppManager.MainForm.pBar.Visible = False
        Catch ex As Exception
            Dim ofrm As New frmError
            ofrm.err = ex
            ofrm.ShowDialog(AppManager.MainForm)

        Finally
            '
        End Try
    End Sub

    Private Sub tvRSS_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvRSS.NodeMouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If InStr(e.Node.Tag, "http://") Then
                GetItemsFromInternet(e.Node.Tag)
            End If
        End If
    End Sub

    Private Sub dgRSS_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgRSS.CellContentClick
        'Build a "virtual" page to fully show returned details.
        Select Case e.ColumnIndex
            Case 0
                Dim strHtml As New StringBuilder
                strHtml.Append("<div align=""center"">")
                strHtml.Append("    <table border=""0"" width=""80%"">")
                strHtml.Append("        <tr>")
                strHtml.Append("            <td width=""100%"" height=""28"">")
                strHtml.Append("                <p align=""center""><font face=""Tahoma"" Color=""Black"">")
                strHtml.Append("<a href=""" & dgRSS.Rows(e.RowIndex).Cells(3).Value & """><b>" & _
                dgRSS.Rows(e.RowIndex).Cells(0).Value & "</b></font></p>")
                strHtml.Append("            </td>")
                strHtml.Append("        </tr>")
                strHtml.Append("        <tr>")
                strHtml.Append("            <td width=""100%"" height=""68"" valign=""top"">")
                strHtml.Append("                <p><font face=""Courier"" size=""3"">" & _
                dgRSS.Rows(e.RowIndex).Cells(1).Value & "... " & _
                "<a href=""" & dgRSS.Rows(e.RowIndex).Cells(3).Value & """>More info...</a></font></p>")
                strHtml.Append("            </td>")
                strHtml.Append("        </tr>")
                strHtml.Append("    </table>")
                strHtml.Append("</div>")
                wbRSS.DocumentText = strHtml.ToString
        End Select
    End Sub

    Private Sub wbRSS_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles wbRSS.DocumentCompleted
        ShowMenu = True
    End Sub

    Private Sub wbRSS_ProgressChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs) Handles wbRSS.ProgressChanged
        AppManager.MainForm.lblStatus.Text = wbRSS.StatusText
        AppManager.MainForm.pBar.Value = ((e.CurrentProgress / e.MaximumProgress) * 100)
    End Sub

    Private Sub wbRSS_StatusTextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles wbRSS.StatusTextChanged
        AppManager.MainForm.lblStatus.Text = wbRSS.StatusText
    End Sub

    Private Sub btnAddFeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFeed.Click
        Dim ofrm As New frmAddRSS
        ofrm.Mode = frmAddRSS.Modes.AddFeed
        ofrm.RSSForm = Me
        ofrm.ShowDialog(AppManager.MainForm)
    End Sub

    Private Sub btnAddGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddGroup.Click
        Dim ofrm As New frmAddRSS
        ofrm.Mode = frmAddRSS.Modes.AddGroup
        ofrm.RSSForm = Me
        ofrm.ShowDialog(AppManager.MainForm)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If Not IsNothing(tvRSS.SelectedNode) Then
            If InStr(tvRSS.SelectedNode.Tag, "http://") Then
                'We are deleting a single feed.
                If MessageBox.Show("Are you sure you want to delete feed " & _
                tvRSS.SelectedNode.Text & "?", "Confirm Delete", MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    DeleteItem()
                End If
            Else
                'We are deleting a group
                If tvRSS.SelectedNode.Nodes.Count > 0 Then
                    MessageBox.Show("You must 1st delete any children of this group", "Cannot delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If MessageBox.Show("Are you sure you want to delete group " & _
                    tvRSS.SelectedNode.Text & "?", "Confirm Delete", MessageBoxButtons.YesNo, _
                    MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        DeleteGroup()
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub DeleteItem()
        Dim strSQL As String = "DELETE FROM RssChannels WHERE Link='" & _
        tvRSS.SelectedNode.Tag & "'"
        Dim oConn As New OleDbConnection(AppManager.ConnString)
        Dim oCmd As New OleDbCommand(strSQL, oConn)
        Try
            oConn.Open()
            oCmd.ExecuteNonQuery()
            oConn.Close()
            LoadFromDB()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            oConn.Dispose()
            oCmd.Dispose()
        End Try
    End Sub

    Private Sub DeleteGroup()
        Dim strSQL As String = "DELETE FROM RssGroups WHERE ID=" & _
         CInt(tvRSS.SelectedNode.Tag)
        Dim oConn As New OleDbConnection(AppManager.ConnString)
        Dim oCmd As New OleDbCommand(strSQL, oConn)
        Try
            oConn.Open()
            oCmd.ExecuteNonQuery()
            oConn.Close()
            LoadFromDB()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            oConn.Dispose()
            oCmd.Dispose()
        End Try
    End Sub

    Private Sub mnuMainBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMainBrowser.Click
        If Not IsNothing(wbRSS.Document.Url) Then
            Dim ofrm As New frmBrowser
            AppManager.AddTab(ofrm, wbRSS.Document.Url.ToString)
        End If
    End Sub

    Private Sub cmWB_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmWB.Opening
        cmWB.Enabled = ShowMenu
    End Sub

    Private Sub mnuRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRefresh.Click
        LoadFromDB()
    End Sub
End Class