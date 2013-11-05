'This is just a simple form to add new feeds or groups.

Imports System.Data.OleDb

Public Class frmAddRSS
    Public GroupID As Integer
    Public RSSForm As frmRSS
    Enum Modes
        AddFeed
        AddGroup
    End Enum
    Private _mode As Modes
    Public Property Mode() As Modes
        Get
            Return _mode
        End Get
        Set(ByVal value As Modes)
            _mode = value
        End Set
    End Property

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoadFromDB()
        Dim strSQL As String = "SELECT * FROM RSSGROUPS"
        Dim oConn As New OleDbConnection(AppManager.ConnString)
        Dim oDa As New OleDbDataAdapter(strSQL, oConn)
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim li As ListItem

        Try

            oDa.Fill(dt)

            For Each dr In dt.Rows
                li = New ListItem
                If dr.Item("ParentID") = 0 Then
                    li.Text = dr.Item("GroupTitle")
                    li.Value = dr.Item("ID")
                    cboGroups.Items.Add(li)
                    GetChildren(li.Value, dt)
                End If
            Next

        Catch ex As Exception
            Dim ofrm As New frmError
            ofrm.err = ex
            ofrm.ShowDialog()
        End Try
    End Sub

    Private Sub GetChildren(ByVal itmID As Integer, ByVal dt As DataTable)
        Dim dv As New DataView(dt)
        dv.RowFilter = "parentID=" & Integer.Parse(itmID)
        Dim row As DataRowView
        Dim itm As ListItem
        Try
            For Each row In dv
                ' Perform the node addition
                itm = New ListItem
                itm.Text = row("GroupTitle")
                itm.Value = row("ID")
                cboGroups.Items.Add(itm)
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

    Private Sub frmAddRSS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.Mode = Modes.AddGroup Then
            txtURL.Enabled = False
            Dim li As New ListItem
            li.Text = "Top level"
            li.Value = 0
            cboGroups.Items.Add(li)
        End If
        LoadFromDB()
        cboGroups.SelectedIndex = 0
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Select Case Me.Mode
            Case Modes.AddFeed
                If txtTitle.Text = "" Then
                    MsgBox("Please enter a Title.")
                    Exit Sub
                End If
                If txtURL.Text = "" Then
                    MsgBox("Please enter a URL.")
                    Exit Sub
                End If
                If IsNothing(cboGroups.SelectedItem) Then
                    MsgBox("Please select a group.")
                    Exit Sub
                End If
                AddFeed()
            Case Modes.AddGroup
                If IsNothing(cboGroups.SelectedItem) Then
                    MsgBox("Please select a group.")
                    Exit Sub
                End If
                If txtTitle.Text = "" Then
                    MsgBox("Please enter a Title.")
                    Exit Sub
                End If
                AddGroup()
        End Select
    End Sub

    Private Sub AddFeed()
        Dim li As ListItem = cboGroups.SelectedItem
        Dim strSQL As String = "INSERT INTO RSSChannels (GroupID, ChannelTitle, Link) VALUES ('" & _
        CInt(li.Value) & "', '" & txtTitle.Text & "', '" & txtURL.Text & "')"
        Dim oConn As New OleDbConnection(AppManager.ConnString)
        Dim oCmd As New OleDbCommand(strSQL, oConn)
        Try
            oConn.Open()
            oCmd.ExecuteNonQuery()
            oConn.Close()
            If Not IsNothing(Me.RSSForm) Then
                Me.RSSForm.LoadFromDB()
            End If
            Me.Close()
        Catch ex As Exception
            Dim ofrm As New frmError
            ofrm.err = ex
            ofrm.ShowDialog(Me)
        Finally
            oConn.Dispose()
            oCmd.Dispose()
        End Try
    End Sub

    Private Sub AddGroup()
        Dim li As ListItem = cboGroups.SelectedItem
        Dim strSQL As String = "INSERT INTO RSSGroups (ParentID, GroupTitle) VALUES ('" & _
        CInt(li.Value) & "', '" & txtTitle.Text & "')"
        Dim oConn As New OleDbConnection(AppManager.ConnString)
        Dim oCmd As New OleDbCommand(strSQL, oConn)
        Try
            oConn.Open()
            oCmd.ExecuteNonQuery()
            oConn.Close()
            Me.RSSForm.LoadFromDB()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            oConn.Dispose()
            oCmd.Dispose()
        End Try
    End Sub

    Private Sub cboGroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGroups.SelectedIndexChanged

    End Sub
End Class