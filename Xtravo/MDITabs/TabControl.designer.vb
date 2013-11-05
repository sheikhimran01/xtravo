<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TabControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container
        Me.pnlTop = New System.Windows.Forms.Panel
        Me.pnlControls = New System.Windows.Forms.Panel
        Me.pnlTabs = New System.Windows.Forms.Panel
        Me.pnlBottom = New System.Windows.Forms.Panel
        Me.WinMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddATabToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TabToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.DropButton = New Xtravo.ControlButton
        Me.CloseButton = New Xtravo.ControlButton
        Me.pnlTop.SuspendLayout()
        Me.pnlControls.SuspendLayout()
        Me.WinMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTop.BackColor = System.Drawing.Color.Transparent
        Me.pnlTop.Controls.Add(Me.pnlControls)
        Me.pnlTop.Controls.Add(Me.pnlTabs)
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(200, 31)
        Me.pnlTop.TabIndex = 6
        '
        'pnlControls
        '
        Me.pnlControls.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlControls.BackColor = System.Drawing.Color.Transparent
        Me.pnlControls.Controls.Add(Me.DropButton)
        Me.pnlControls.Controls.Add(Me.CloseButton)
        Me.pnlControls.Location = New System.Drawing.Point(175, 0)
        Me.pnlControls.Name = "pnlControls"
        Me.pnlControls.Size = New System.Drawing.Size(25, 30)
        Me.pnlControls.TabIndex = 1
        '
        'pnlTabs
        '
        Me.pnlTabs.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTabs.BackColor = System.Drawing.Color.Transparent
        Me.pnlTabs.ForeColor = System.Drawing.Color.DimGray
        Me.pnlTabs.Location = New System.Drawing.Point(0, 3)
        Me.pnlTabs.Name = "pnlTabs"
        Me.pnlTabs.Size = New System.Drawing.Size(200, 28)
        Me.pnlTabs.TabIndex = 0
        '
        'pnlBottom
        '
        Me.pnlBottom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBottom.BackColor = System.Drawing.Color.White
        Me.pnlBottom.Location = New System.Drawing.Point(0, 31)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(200, 99)
        Me.pnlBottom.TabIndex = 7
        '
        'WinMenu
        '
        Me.WinMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddATabToolStripMenuItem})
        Me.WinMenu.Name = "WinMenu"
        Me.WinMenu.Size = New System.Drawing.Size(129, 26)
        '
        'AddATabToolStripMenuItem
        '
        Me.AddATabToolStripMenuItem.Name = "AddATabToolStripMenuItem"
        Me.AddATabToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.AddATabToolStripMenuItem.Text = "Add a Tab"
        '
        'TabToolTip
        '
        Me.TabToolTip.ForeColor = System.Drawing.Color.SteelBlue
        '
        'DropButton
        '
        Me.DropButton.BackColor = System.Drawing.Color.Transparent
        Me.DropButton.Font = New System.Drawing.Font("Microsoft YaHei", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DropButton.ForeColor = System.Drawing.Color.DimGray
        Me.DropButton.Location = New System.Drawing.Point(4, 8)
        Me.DropButton.Name = "DropButton"
        Me.DropButton.Size = New System.Drawing.Size(10, 10)
        Me.DropButton.Style = Xtravo.ControlButton.ButtonStyle.Drop
        Me.DropButton.TabIndex = 0
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.BackColor = System.Drawing.Color.Transparent
        Me.CloseButton.BackHighColor = System.Drawing.Color.LightBlue
        Me.CloseButton.BackLowColor = System.Drawing.Color.SteelBlue
        Me.CloseButton.BorderColor = System.Drawing.Color.RoyalBlue
        Me.CloseButton.Location = New System.Drawing.Point(4, 8)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(10, 10)
        Me.CloseButton.Style = Xtravo.ControlButton.ButtonStyle.Drop
        Me.CloseButton.TabIndex = 0
        Me.CloseButton.Visible = False
        '
        'TabControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.pnlBottom)
        Me.Name = "TabControl"
        Me.Size = New System.Drawing.Size(200, 130)
        Me.pnlTop.ResumeLayout(False)
        Me.pnlControls.ResumeLayout(False)
        Me.WinMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents pnlTabs As System.Windows.Forms.Panel
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents WinMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DropButton As Xtravo.ControlButton
    Friend WithEvents TabToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents CloseButton As Xtravo.ControlButton
    Friend WithEvents pnlControls As System.Windows.Forms.Panel
    Friend WithEvents AddATabToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
