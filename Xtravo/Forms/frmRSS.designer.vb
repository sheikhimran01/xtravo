<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRSS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Feeds", 0, 0)
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRSS))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnAddFeed = New System.Windows.Forms.ToolStripButton()
        Me.btnAddGroup = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tvRSS = New System.Windows.Forms.TreeView()
        Me.cmRSS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.dgRSS = New System.Windows.Forms.DataGridView()
        Me.Title = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PubDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LinkURL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wbRSS = New Xtravo.exBrowser()
        Me.cmWB = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMainBrowser = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.cmRSS.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgRSS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmWB.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.GhostWhite
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddFeed, Me.btnAddGroup})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(769, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnAddFeed
        '
        Me.btnAddFeed.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddFeed.ForeColor = System.Drawing.Color.Black
        Me.btnAddFeed.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddFeed.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.btnAddFeed.Name = "btnAddFeed"
        Me.btnAddFeed.Size = New System.Drawing.Size(60, 22)
        Me.btnAddFeed.Text = "Add Feed"
        '
        'btnAddGroup
        '
        Me.btnAddGroup.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddGroup.ForeColor = System.Drawing.Color.Black
        Me.btnAddGroup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddGroup.Margin = New System.Windows.Forms.Padding(20, 1, 0, 2)
        Me.btnAddGroup.Name = "btnAddGroup"
        Me.btnAddGroup.Size = New System.Drawing.Size(68, 22)
        Me.btnAddGroup.Text = "Add Group"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Gainsboro
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvRSS)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(769, 459)
        Me.SplitContainer1.SplitterDistance = 209
        Me.SplitContainer1.TabIndex = 1
        '
        'tvRSS
        '
        Me.tvRSS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvRSS.ContextMenuStrip = Me.cmRSS
        Me.tvRSS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tvRSS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvRSS.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvRSS.ForeColor = System.Drawing.Color.Black
        Me.tvRSS.HotTracking = True
        Me.tvRSS.Location = New System.Drawing.Point(0, 0)
        Me.tvRSS.Name = "tvRSS"
        TreeNode1.ImageIndex = 0
        TreeNode1.Name = "nRoot"
        TreeNode1.SelectedImageIndex = 0
        TreeNode1.Text = "Feeds"
        Me.tvRSS.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.tvRSS.ShowRootLines = False
        Me.tvRSS.Size = New System.Drawing.Size(209, 459)
        Me.tvRSS.TabIndex = 1
        '
        'cmRSS
        '
        Me.cmRSS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem1, Me.mnuRefresh})
        Me.cmRSS.Name = "cmRSS"
        Me.cmRSS.Size = New System.Drawing.Size(114, 54)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(110, 6)
        '
        'mnuRefresh
        '
        Me.mnuRefresh.Name = "mnuRefresh"
        Me.mnuRefresh.Size = New System.Drawing.Size(113, 22)
        Me.mnuRefresh.Text = "Refresh"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BackColor = System.Drawing.Color.Gainsboro
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgRSS)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.wbRSS)
        Me.SplitContainer2.Size = New System.Drawing.Size(556, 459)
        Me.SplitContainer2.SplitterDistance = 227
        Me.SplitContainer2.TabIndex = 0
        '
        'dgRSS
        '
        Me.dgRSS.AllowUserToAddRows = False
        Me.dgRSS.AllowUserToDeleteRows = False
        Me.dgRSS.AllowUserToOrderColumns = True
        Me.dgRSS.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgRSS.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgRSS.BackgroundColor = System.Drawing.Color.White
        Me.dgRSS.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Tomato
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRSS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgRSS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRSS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Title, Me.Description, Me.PubDate, Me.LinkURL})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgRSS.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgRSS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgRSS.EnableHeadersVisualStyles = False
        Me.dgRSS.Location = New System.Drawing.Point(0, 0)
        Me.dgRSS.MultiSelect = False
        Me.dgRSS.Name = "dgRSS"
        Me.dgRSS.ReadOnly = True
        Me.dgRSS.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgRSS.RowHeadersVisible = False
        Me.dgRSS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRSS.ShowCellErrors = False
        Me.dgRSS.ShowEditingIcon = False
        Me.dgRSS.Size = New System.Drawing.Size(556, 227)
        Me.dgRSS.TabIndex = 1
        '
        'Title
        '
        Me.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Title.DataPropertyName = "Title"
        Me.Title.HeaderText = "Title"
        Me.Title.Name = "Title"
        Me.Title.ReadOnly = True
        '
        'Description
        '
        Me.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        '
        'PubDate
        '
        Me.PubDate.DataPropertyName = "PubDate"
        Me.PubDate.HeaderText = "Published"
        Me.PubDate.Name = "PubDate"
        Me.PubDate.ReadOnly = True
        '
        'LinkURL
        '
        Me.LinkURL.DataPropertyName = "Link"
        Me.LinkURL.HeaderText = "LinkURL"
        Me.LinkURL.Name = "LinkURL"
        Me.LinkURL.ReadOnly = True
        Me.LinkURL.Visible = False
        '
        'wbRSS
        '
        Me.wbRSS.ContextMenuStrip = Me.cmWB
        Me.wbRSS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbRSS.IsWebBrowserContextMenuEnabled = False
        Me.wbRSS.Location = New System.Drawing.Point(0, 0)
        Me.wbRSS.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbRSS.Name = "wbRSS"
        Me.wbRSS.ScriptErrorsSuppressed = True
        Me.wbRSS.Size = New System.Drawing.Size(556, 228)
        Me.wbRSS.TabIndex = 0
        '
        'cmWB
        '
        Me.cmWB.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMainBrowser})
        Me.cmWB.Name = "ContextMenuStrip1"
        Me.cmWB.Size = New System.Drawing.Size(185, 26)
        '
        'mnuMainBrowser
        '
        Me.mnuMainBrowser.Name = "mnuMainBrowser"
        Me.mnuMainBrowser.Size = New System.Drawing.Size(184, 22)
        Me.mnuMainBrowser.Text = "View in New Browser"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "feed.ico")
        Me.ImageList1.Images.SetKeyName(1, "folder3.png")
        '
        'frmRSS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(769, 484)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRSS"
        Me.Text = "RSS Viewer"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.cmRSS.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgRSS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmWB.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tvRSS As System.Windows.Forms.TreeView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgRSS As System.Windows.Forms.DataGridView
    Friend WithEvents wbRSS As Xtravo.exBrowser
    Friend WithEvents btnAddFeed As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAddGroup As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmRSS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Title As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PubDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LinkURL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmWB As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuMainBrowser As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRefresh As System.Windows.Forms.ToolStripMenuItem
End Class
