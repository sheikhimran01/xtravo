'///////////////////////////////////////////////////////////////////////////////////
'This form is just a simple document explorer and is not meant to be
'an html editor, you could easily extend this form to make your
'own built in editor. Allows exploring the loaded document, it's layout and elements.
'/////////////////////////////////////////////////////////////////////////////////////
Public Class frmDocExplorer
    Private WithEvents sDoc As HtmlDocument
    Private oEl As HtmlElement
    Private elID As Integer 'Counter

    Private Sub frmDocExplorer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        deWB.Dispose()
        rtbSource.Dispose()
        tvDoc.Dispose()
        pg.Dispose()
    End Sub

    Private Sub frmDocExplorer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sDoc = deWB.Document
        deWB.AllowNavigation = False
        rtbSource.Text = deWB.DocumentText
        pg.SelectedObject = sDoc
    End Sub


#Region " Load Doc Outline "

    Private Sub LoadDocumentOutline()
        On Error Resume Next
        tvDoc.Cursor = Cursors.WaitCursor
        tvDoc.BeginUpdate()
        Dim oitm As TreeNode
        Dim oelmt As HtmlElement
        Dim i As Integer
        For Each oelmt In deWB.Document.Body.Children
            If oelmt.Children.Count > 0 Then
                If IsNothing(oelmt.Id) Then
                    oEl.SetAttribute("ID", "de" & elID)
                End If
                oitm = New TreeNode
                oitm.Text = "<" & oelmt.TagName & ">"
                oitm.Name = oelmt.Id
                oitm.Tag = oelmt.Id
                oitm.ImageIndex = GetIconID(oelmt.TagName)
                oitm.SelectedImageIndex = GetIconID(oelmt.TagName)
                GetChildElements(oitm, oelmt)
                tvDoc.Nodes(0).Nodes(0).Nodes.Add(oitm)
            End If
            elID = elID + 1
        Next
        tvDoc.ExpandAll()
        tvDoc.EndUpdate()
        tvDoc.Cursor = Cursors.Default
    End Sub

    Private Sub GetChildElements(ByVal oNode As TreeNode, ByVal oElement As HtmlElement)
        Dim cl As HtmlElement
        Dim cn As TreeNode
        For Each cl In oElement.Children
            If IsNothing(cl.Id) Then
                cl.SetAttribute("ID", "de" & elID)
            End If
            cn = New TreeNode
            cn.Text = "<" & cl.TagName & ">"
            cn.Name = cl.Id
            cn.Tag = cl.Id
            cn.ImageIndex = GetIconID(cl.TagName)
            cn.SelectedImageIndex = GetIconID(cl.TagName)
            If cl.Children.Count > 0 Then
                GetChildElements(cn, cl)
            End If
            oNode.Nodes.Add(cn)
            elID = elID + 1
        Next
    End Sub

    Private Function GetIconID(ByVal strTag As String) As Integer
        'This code needs to be moved to the control
        Select Case strTag
            Case "TABLE"
                Return 1
            Case "TBODY"
                Return 1
            Case "A"
                Return 7
            Case "B"
                Return 8
            Case "SCRIPT"
                Return 19
            Case "H1"
                Return 24
            Case "H2"
                Return 25
            Case "H3"
                Return 26
            Case "H4"
                Return 27
            Case "H5"
                Return 28
            Case "H6"
                Return 29
            Case "TR"
                Return 4
            Case "TD"
                Return 3
            Case "UL"
                Return 5
            Case "LI"
                Return 16
            Case "SELECT"
                Return 22
            Case "IMG"
                Return 15
            Case "P"
                Return 18
            Case "BUTTON"
                Return 20
            Case "FONT"
                Return 12
            Case "INPUT"
                Return 21
            Case "FORM"
                Return 13
            Case "CENTER"
                Return 9
            Case Else
                Return 2
        End Select
    End Function
#End Region

    Private Sub tvDoc_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvDoc.NodeMouseClick
        Select Case e.Node.Tag
            Case "DOC"
                pg.SelectedObject = deWB.Document
            Case "BODY"
                pg.SelectedObject = deWB.Document.Body
            Case Else
                If Not IsNothing(e.Node.Tag) Then
                    Dim tmpEl As HtmlElement = sDoc.GetElementById(e.Node.Tag)
                    pg.SelectedObject = tmpEl
                    TabControl1.SelectedTab = TabControl1.TabPages(1)
                    tmpEl.ScrollIntoView(False)
                End If
        End Select
    End Sub

    Private Sub deWB_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles deWB.DocumentCompleted
        sDoc = deWB.Document
        deWB.AllowNavigation = False
        LoadDocumentOutline()
        rtbSource.Text = deWB.DocumentText
        pg.SelectedObject = sDoc
    End Sub

    Private Sub sDoc_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.HtmlElementEventArgs) Handles sDoc.Click
        Try
            Dim MousePoint As New Point(e.MousePosition.X, e.MousePosition.Y)
            oEl = sDoc.GetElementFromPoint(MousePoint)
            pg.SelectedObject = oEl
            Dim oNode As TreeNode = FindNode(tvDoc.Nodes(0), oEl.Id)
            If Not IsNothing(oNode) Then
                tvDoc.SelectedNode = oNode
                tvDoc.Select()
                oNode.EnsureVisible()
            End If
        Catch ex As Exception
            'do nothing
        End Try
    End Sub

    Public Function FindNode(ByVal ParentNode As TreeNode, ByVal SearchVal As String) As TreeNode
        Dim tmpNode As TreeNode
        If ParentNode.Tag = SearchVal Then
            Return ParentNode
        Else
            Dim child As TreeNode
            For Each child In ParentNode.Nodes
                tmpNode = FindNode(child, SearchVal)
                If Not tmpNode Is Nothing Then
                    Return tmpNode
                End If
            Next
        End If
        Return Nothing
    End Function

    Private Sub chkEditMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEditMode.CheckedChanged
        Select Case chkEditMode.Checked
            Case True
                deWB.Document.ExecCommand("EditMode", False, System.DBNull.Value)
            Case False
                deWB.Document.ExecCommand("BrowseMode", False, System.DBNull.Value)
        End Select
        TabControl1.SelectedTab = TabControl1.TabPages(1)
    End Sub

    Private Sub chkSupress_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSupress.CheckedChanged
        deWB.ScriptErrorsSuppressed = chkSupress.Checked
    End Sub

    Private Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        deWB.ShowSaveAsDialog()
    End Sub

    Private Sub debugger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles debugger.Click
        chkEditMode.Checked = False
        TabControl1.SelectedTab = TabControl1.TabPages(1)
    End Sub
End Class