<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCookieViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCookieViewer))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tvCookies = New System.Windows.Forms.TreeView()
        Me.cmCookies = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDeleteCookie = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnDeleteALL = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.rtbCookies = New System.Windows.Forms.RichTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.cmCookies.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.GhostWhite
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvCookies)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.rtbCookies)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(842, 445)
        Me.SplitContainer1.SplitterDistance = 277
        Me.SplitContainer1.TabIndex = 0
        '
        'tvCookies
        '
        Me.tvCookies.ContextMenuStrip = Me.cmCookies
        Me.tvCookies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvCookies.FullRowSelect = True
        Me.tvCookies.HideSelection = False
        Me.tvCookies.HotTracking = True
        Me.tvCookies.ImageIndex = 0
        Me.tvCookies.ImageList = Me.ImageList1
        Me.tvCookies.Location = New System.Drawing.Point(0, 25)
        Me.tvCookies.Name = "tvCookies"
        Me.tvCookies.SelectedImageIndex = 0
        Me.tvCookies.Size = New System.Drawing.Size(277, 420)
        Me.tvCookies.TabIndex = 0
        '
        'cmCookies
        '
        Me.cmCookies.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDeleteCookie})
        Me.cmCookies.Name = "cmCookies"
        Me.cmCookies.Size = New System.Drawing.Size(108, 26)
        '
        'mnuDeleteCookie
        '
        Me.mnuDeleteCookie.Name = "mnuDeleteCookie"
        Me.mnuDeleteCookie.Size = New System.Drawing.Size(107, 22)
        Me.mnuDeleteCookie.Text = "Delete"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "cookie.png")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.GhostWhite
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDeleteALL, Me.btnDelete})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(277, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnDeleteALL
        '
        Me.btnDeleteALL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnDeleteALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteALL.ForeColor = System.Drawing.Color.Black
        Me.btnDeleteALL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeleteALL.Name = "btnDeleteALL"
        Me.btnDeleteALL.Size = New System.Drawing.Size(112, 22)
        Me.btnDeleteALL.Text = "Delete All Cookies"
        '
        'btnDelete
        '
        Me.btnDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnDelete.Enabled = False
        Me.btnDelete.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.Black
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(98, 22)
        Me.btnDelete.Text = "Delete Selected"
        '
        'rtbCookies
        '
        Me.rtbCookies.BackColor = System.Drawing.Color.White
        Me.rtbCookies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbCookies.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbCookies.Location = New System.Drawing.Point(0, 25)
        Me.rtbCookies.Name = "rtbCookies"
        Me.rtbCookies.ReadOnly = True
        Me.rtbCookies.Size = New System.Drawing.Size(561, 420)
        Me.rtbCookies.TabIndex = 0
        Me.rtbCookies.Text = ""
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(561, 25)
        Me.Panel1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.GhostWhite
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(561, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Information (Read Only)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCookieViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 445)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCookieViewer"
        Me.Text = "Cookies Manager"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.cmCookies.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tvCookies As System.Windows.Forms.TreeView
    Friend WithEvents rtbCookies As System.Windows.Forms.RichTextBox
    Friend WithEvents cmCookies As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDeleteCookie As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnDeleteALL As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
End Class
