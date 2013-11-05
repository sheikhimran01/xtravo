<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocExplorer
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("<BODY>")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Document", New System.Windows.Forms.TreeNode() {TreeNode1})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocExplorer))
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.rtbSource = New System.Windows.Forms.RichTextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.deWB = New System.Windows.Forms.WebBrowser()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tvDoc = New System.Windows.Forms.TreeView()
        Me.il1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.pg = New System.Windows.Forms.PropertyGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.debugger = New System.Windows.Forms.Button()
        Me.save = New System.Windows.Forms.Button()
        Me.chkSupress = New System.Windows.Forms.CheckBox()
        Me.chkEditMode = New System.Windows.Forms.CheckBox()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.rtbSource)
        Me.TabPage1.Location = New System.Drawing.Point(4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(431, 413)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Source Code"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'rtbSource
        '
        Me.rtbSource.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbSource.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbSource.Location = New System.Drawing.Point(3, 3)
        Me.rtbSource.Name = "rtbSource"
        Me.rtbSource.Size = New System.Drawing.Size(425, 407)
        Me.rtbSource.TabIndex = 0
        Me.rtbSource.Text = ""
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.deWB)
        Me.TabPage2.Location = New System.Drawing.Point(4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(431, 413)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Browser"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'deWB
        '
        Me.deWB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.deWB.IsWebBrowserContextMenuEnabled = False
        Me.deWB.Location = New System.Drawing.Point(3, 3)
        Me.deWB.MinimumSize = New System.Drawing.Size(20, 20)
        Me.deWB.Name = "deWB"
        Me.deWB.ScriptErrorsSuppressed = True
        Me.deWB.Size = New System.Drawing.Size(425, 407)
        Me.deWB.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.GhostWhite
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(258, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Properties"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.GhostWhite
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 31)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvDoc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(831, 439)
        Me.SplitContainer1.SplitterDistance = 126
        Me.SplitContainer1.TabIndex = 3
        '
        'tvDoc
        '
        Me.tvDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvDoc.HideSelection = False
        Me.tvDoc.ImageIndex = 0
        Me.tvDoc.ImageList = Me.il1
        Me.tvDoc.Location = New System.Drawing.Point(0, 25)
        Me.tvDoc.Name = "tvDoc"
        TreeNode1.Name = "Node3"
        TreeNode1.Tag = "BODY"
        TreeNode1.Text = "<BODY>"
        TreeNode2.Name = "Node2"
        TreeNode2.Tag = "DOC"
        TreeNode2.Text = "Document"
        Me.tvDoc.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2})
        Me.tvDoc.SelectedImageIndex = 0
        Me.tvDoc.Size = New System.Drawing.Size(126, 414)
        Me.tvDoc.TabIndex = 2
        '
        'il1
        '
        Me.il1.ImageStream = CType(resources.GetObject("il1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.il1.TransparentColor = System.Drawing.Color.Transparent
        Me.il1.Images.SetKeyName(0, "Doc.ico")
        Me.il1.Images.SetKeyName(1, "Table.ico")
        Me.il1.Images.SetKeyName(2, "TAG2.ico")
        Me.il1.Images.SetKeyName(3, "TD3.ico")
        Me.il1.Images.SetKeyName(4, "TR2.ico")
        Me.il1.Images.SetKeyName(5, "UL.ico")
        Me.il1.Images.SetKeyName(6, "Unknown.ico")
        Me.il1.Images.SetKeyName(7, "A.ico")
        Me.il1.Images.SetKeyName(8, "text_bold.png")
        Me.il1.Images.SetKeyName(9, "text_align_center.png")
        Me.il1.Images.SetKeyName(10, "Checkbox.ico")
        Me.il1.Images.SetKeyName(11, "File.ico")
        Me.il1.Images.SetKeyName(12, "Font.ico")
        Me.il1.Images.SetKeyName(13, "FORM.ico")
        Me.il1.Images.SetKeyName(14, "I.ico")
        Me.il1.Images.SetKeyName(15, "Image.ico")
        Me.il1.Images.SetKeyName(16, "ListItem.ico")
        Me.il1.Images.SetKeyName(17, "Mail2.ico")
        Me.il1.Images.SetKeyName(18, "P.ico")
        Me.il1.Images.SetKeyName(19, "Script.ico")
        Me.il1.Images.SetKeyName(20, "Button.ico")
        Me.il1.Images.SetKeyName(21, "Input.ico")
        Me.il1.Images.SetKeyName(22, "Select.ico")
        Me.il1.Images.SetKeyName(23, "page_code.png")
        Me.il1.Images.SetKeyName(24, "text_heading_1.png")
        Me.il1.Images.SetKeyName(25, "text_heading_2.png")
        Me.il1.Images.SetKeyName(26, "text_heading_3.png")
        Me.il1.Images.SetKeyName(27, "text_heading_4.png")
        Me.il1.Images.SetKeyName(28, "text_heading_5.png")
        Me.il1.Images.SetKeyName(29, "text_heading_6.png")
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(126, 25)
        Me.Panel3.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.GhostWhite
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Document Outline"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitContainer3
        '
        Me.SplitContainer3.BackColor = System.Drawing.Color.GhostWhite
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.TabControl1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.pg)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer3.Size = New System.Drawing.Size(701, 439)
        Me.SplitContainer3.SplitterDistance = 439
        Me.SplitContainer3.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(439, 439)
        Me.TabControl1.TabIndex = 0
        '
        'pg
        '
        Me.pg.BackColor = System.Drawing.Color.AliceBlue
        Me.pg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pg.HelpVisible = False
        Me.pg.Location = New System.Drawing.Point(0, 25)
        Me.pg.Name = "pg"
        Me.pg.Size = New System.Drawing.Size(258, 414)
        Me.pg.TabIndex = 0
        Me.pg.ToolbarVisible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(258, 25)
        Me.Panel2.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.GhostWhite
        Me.Panel1.Controls.Add(Me.debugger)
        Me.Panel1.Controls.Add(Me.save)
        Me.Panel1.Controls.Add(Me.chkSupress)
        Me.Panel1.Controls.Add(Me.chkEditMode)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(831, 31)
        Me.Panel1.TabIndex = 4
        '
        'debugger
        '
        Me.debugger.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.debugger.Location = New System.Drawing.Point(672, 3)
        Me.debugger.Name = "debugger"
        Me.debugger.Size = New System.Drawing.Size(75, 23)
        Me.debugger.TabIndex = 3
        Me.debugger.Text = "Debug"
        Me.debugger.UseVisualStyleBackColor = True
        '
        'save
        '
        Me.save.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.save.Location = New System.Drawing.Point(753, 3)
        Me.save.Name = "save"
        Me.save.Size = New System.Drawing.Size(75, 23)
        Me.save.TabIndex = 2
        Me.save.Text = "Save"
        Me.save.UseVisualStyleBackColor = True
        '
        'chkSupress
        '
        Me.chkSupress.BackColor = System.Drawing.Color.Transparent
        Me.chkSupress.Checked = True
        Me.chkSupress.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSupress.ForeColor = System.Drawing.Color.Black
        Me.chkSupress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkSupress.Location = New System.Drawing.Point(152, 3)
        Me.chkSupress.Name = "chkSupress"
        Me.chkSupress.Size = New System.Drawing.Size(128, 28)
        Me.chkSupress.TabIndex = 1
        Me.chkSupress.Text = "Supress Script Errors"
        Me.chkSupress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSupress.UseVisualStyleBackColor = False
        '
        'chkEditMode
        '
        Me.chkEditMode.BackColor = System.Drawing.Color.Transparent
        Me.chkEditMode.ForeColor = System.Drawing.Color.Black
        Me.chkEditMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkEditMode.Location = New System.Drawing.Point(12, 3)
        Me.chkEditMode.Name = "chkEditMode"
        Me.chkEditMode.Size = New System.Drawing.Size(116, 28)
        Me.chkEditMode.TabIndex = 0
        Me.chkEditMode.Text = "Browser Edit Mode"
        Me.chkEditMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkEditMode.UseVisualStyleBackColor = False
        '
        'frmDocExplorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(831, 470)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDocExplorer"
        Me.Text = "Code Inspector"
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents deWB As System.Windows.Forms.WebBrowser
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Public WithEvents tvDoc As System.Windows.Forms.TreeView
    Friend WithEvents il1 As System.Windows.Forms.ImageList
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents pg As System.Windows.Forms.PropertyGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rtbSource As System.Windows.Forms.RichTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkEditMode As System.Windows.Forms.CheckBox
    Friend WithEvents chkSupress As System.Windows.Forms.CheckBox
    Friend WithEvents save As System.Windows.Forms.Button
    Friend WithEvents debugger As System.Windows.Forms.Button
End Class
