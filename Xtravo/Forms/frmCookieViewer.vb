'// Simple form to work with cookies.
Imports System.IO
Public Class frmCookieViewer
    Private SelNode As TreeNode

    Private Sub frmCookieViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCookies()
    End Sub

    Private Sub LoadCookies()
        tvCookies.Nodes.Clear()
        Dim s As String
        Dim oNode As TreeNode
        Dim oInfo As FileInfo
        For Each s In Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Cookies))
            If s.EndsWith(".txt") Then
                oInfo = New FileInfo(s)
                oNode = New TreeNode
                oNode.Text = oInfo.Name
                oNode.Tag = s
                oNode.ImageIndex = 0
                oNode.SelectedImageIndex = 0
                tvCookies.Nodes.Add(oNode)
            End If
        Next
    End Sub

    Private Sub ViewCookie(ByVal oNode As TreeNode)
        Try
            rtbCookies.LoadFile(oNode.Tag, RichTextBoxStreamType.PlainText)
        Catch ex As Exception
            Dim ofrm As New frmError
            ofrm.err = ex
            ofrm.ShowDialog(AppManager.MainForm)
        End Try
    End Sub

    Private Sub tvCookies_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvCookies.AfterSelect
        SelNode = e.Node
        btnDelete.Enabled = True
    End Sub

    Private Sub tvCookies_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvCookies.Click
        If Not IsNothing(SelNode) Then
            cmCookies.Enabled = True
        Else
            cmCookies.Enabled = False
        End If
    End Sub

    Private Sub tvCookies_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvCookies.NodeMouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ViewCookie(e.Node)
        Else
            tvCookies.SelectedNode = e.Node
        End If
    End Sub

    Private Sub mnuDeleteCookie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeleteCookie.Click
        DeleteCookie()
    End Sub

    Private Sub DeleteCookie()
        Try
            If Not IsNothing(SelNode) Then
                If MessageBox.Show("Are you sure you want to delete cookie" & tvCookies.SelectedNode.Text & "?", "Confirm Delete", MessageBoxButtons.YesNoCancel) = Windows.Forms.DialogResult.Yes Then
                    File.Delete(SelNode.Tag)
                    tvCookies.SelectedNode.Remove()
                End If
            End If
        Catch ex As Exception
            Dim ofrm As New frmError
            ofrm.err = ex
            ofrm.ShowDialog(AppManager.MainForm)
        End Try
    End Sub

    Private Sub btnDeleteALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteALL.Click
        If MessageBox.Show("Are you sure you want to delete all cookies?", "Confirm Delete", MessageBoxButtons.YesNoCancel) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim s As String
                For Each s In Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Cookies))
                    If s.EndsWith(".txt") Then
                        File.Delete(s)
                    End If
                Next
                tvCookies.Nodes.Clear()
            Catch ex As Exception
                Dim ofrm As New frmError
                ofrm.err = ex
                ofrm.ShowDialog(AppManager.MainForm)
            End Try
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        DeleteCookie()
    End Sub
End Class