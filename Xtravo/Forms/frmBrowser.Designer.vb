<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrowser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBrowser))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuPage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPageSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveAllImages = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPagePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenInNewTabToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuImageSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewImageNewTab = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuImageCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem18 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuImageProperties = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem15 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuBack = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuForward = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem17 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ElemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmiInfoBar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuPopTempAllow = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPopAllowthissite = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPopBlockEnabled = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPopShowInfoBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPopMoreSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.wb = New Xtravo.exBrowser()
        Me.InfoBar1 = New Xtravo.InfoBar()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.cmiInfoBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPage, Me.ToolStripMenuItem1, Me.OpenInNewTabToolStripMenuItem, Me.ToolStripMenuItem14, Me.mnuImage, Me.ToolStripMenuItem15, Me.mnuBack, Me.mnuForward, Me.mnuRefresh, Me.ToolStripMenuItem17, Me.mnuCopy, Me.mnuPaste, Me.ToolStripMenuItem2, Me.ElemToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(178, 232)
        '
        'mnuPage
        '
        Me.mnuPage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPageSaveAs, Me.mnuSaveAllImages, Me.ToolStripMenuItem4, Me.mnuPagePrint, Me.ToolStripMenuItem11, Me.mnuFind, Me.ToolStripMenuItem3, Me.PropertiesToolStripMenuItem})
        Me.mnuPage.Name = "mnuPage"
        Me.mnuPage.Size = New System.Drawing.Size(177, 22)
        Me.mnuPage.Text = "Options"
        '
        'mnuPageSaveAs
        '
        Me.mnuPageSaveAs.Name = "mnuPageSaveAs"
        Me.mnuPageSaveAs.Size = New System.Drawing.Size(179, 22)
        Me.mnuPageSaveAs.Text = "Save As..."
        '
        'mnuSaveAllImages
        '
        Me.mnuSaveAllImages.Name = "mnuSaveAllImages"
        Me.mnuSaveAllImages.Size = New System.Drawing.Size(179, 22)
        Me.mnuSaveAllImages.Text = "Save All Images"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(176, 6)
        '
        'mnuPagePrint
        '
        Me.mnuPagePrint.Name = "mnuPagePrint"
        Me.mnuPagePrint.Size = New System.Drawing.Size(179, 22)
        Me.mnuPagePrint.Text = "Print..."
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(176, 6)
        '
        'mnuFind
        '
        Me.mnuFind.Name = "mnuFind"
        Me.mnuFind.Size = New System.Drawing.Size(179, 22)
        Me.mnuFind.Text = "Find On this page..."
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(176, 6)
        '
        'PropertiesToolStripMenuItem
        '
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.PropertiesToolStripMenuItem.Text = "Properties"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(174, 6)
        '
        'OpenInNewTabToolStripMenuItem
        '
        Me.OpenInNewTabToolStripMenuItem.Name = "OpenInNewTabToolStripMenuItem"
        Me.OpenInNewTabToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.OpenInNewTabToolStripMenuItem.Text = "Open in New tab"
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(174, 6)
        '
        'mnuImage
        '
        Me.mnuImage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuImageSave, Me.ToolStripMenuItem9, Me.mnuViewImageNewTab, Me.ToolStripMenuItem5, Me.mnuImageCopy, Me.ToolStripMenuItem18, Me.mnuImageProperties})
        Me.mnuImage.Name = "mnuImage"
        Me.mnuImage.Size = New System.Drawing.Size(177, 22)
        Me.mnuImage.Text = "Image"
        '
        'mnuImageSave
        '
        Me.mnuImageSave.Name = "mnuImageSave"
        Me.mnuImageSave.Size = New System.Drawing.Size(164, 22)
        Me.mnuImageSave.Text = "Save As..."
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(161, 6)
        '
        'mnuViewImageNewTab
        '
        Me.mnuViewImageNewTab.Name = "mnuViewImageNewTab"
        Me.mnuViewImageNewTab.Size = New System.Drawing.Size(164, 22)
        Me.mnuViewImageNewTab.Text = "View in New Tab"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(161, 6)
        '
        'mnuImageCopy
        '
        Me.mnuImageCopy.Name = "mnuImageCopy"
        Me.mnuImageCopy.Size = New System.Drawing.Size(164, 22)
        Me.mnuImageCopy.Text = "Copy"
        '
        'ToolStripMenuItem18
        '
        Me.ToolStripMenuItem18.Name = "ToolStripMenuItem18"
        Me.ToolStripMenuItem18.Size = New System.Drawing.Size(161, 6)
        '
        'mnuImageProperties
        '
        Me.mnuImageProperties.Name = "mnuImageProperties"
        Me.mnuImageProperties.Size = New System.Drawing.Size(164, 22)
        Me.mnuImageProperties.Text = "Properties"
        '
        'ToolStripMenuItem15
        '
        Me.ToolStripMenuItem15.Name = "ToolStripMenuItem15"
        Me.ToolStripMenuItem15.Size = New System.Drawing.Size(174, 6)
        '
        'mnuBack
        '
        Me.mnuBack.Name = "mnuBack"
        Me.mnuBack.Size = New System.Drawing.Size(177, 22)
        Me.mnuBack.Text = "Back"
        '
        'mnuForward
        '
        Me.mnuForward.Name = "mnuForward"
        Me.mnuForward.Size = New System.Drawing.Size(177, 22)
        Me.mnuForward.Text = "Forward"
        '
        'mnuRefresh
        '
        Me.mnuRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuRefresh.ImageTransparentColor = System.Drawing.Color.White
        Me.mnuRefresh.Name = "mnuRefresh"
        Me.mnuRefresh.Size = New System.Drawing.Size(177, 22)
        Me.mnuRefresh.Text = "Refresh"
        '
        'ToolStripMenuItem17
        '
        Me.ToolStripMenuItem17.Name = "ToolStripMenuItem17"
        Me.ToolStripMenuItem17.Size = New System.Drawing.Size(174, 6)
        '
        'mnuCopy
        '
        Me.mnuCopy.Name = "mnuCopy"
        Me.mnuCopy.Size = New System.Drawing.Size(177, 22)
        Me.mnuCopy.Text = "Copy"
        '
        'mnuPaste
        '
        Me.mnuPaste.Name = "mnuPaste"
        Me.mnuPaste.Size = New System.Drawing.Size(177, 22)
        Me.mnuPaste.Text = "Paste"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(174, 6)
        '
        'ElemToolStripMenuItem
        '
        Me.ElemToolStripMenuItem.Name = "ElemToolStripMenuItem"
        Me.ElemToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ElemToolStripMenuItem.Text = "Element Properties"
        '
        'cmiInfoBar
        '
        Me.cmiInfoBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPopTempAllow, Me.mnuPopAllowthissite, Me.SettingsToolStripMenuItem})
        Me.cmiInfoBar.Name = "cmiInfoBar"
        Me.cmiInfoBar.Size = New System.Drawing.Size(267, 70)
        '
        'mnuPopTempAllow
        '
        Me.mnuPopTempAllow.Name = "mnuPopTempAllow"
        Me.mnuPopTempAllow.Size = New System.Drawing.Size(266, 22)
        Me.mnuPopTempAllow.Text = "Temporarily Allow PopUps"
        '
        'mnuPopAllowthissite
        '
        Me.mnuPopAllowthissite.Name = "mnuPopAllowthissite"
        Me.mnuPopAllowthissite.Size = New System.Drawing.Size(266, 22)
        Me.mnuPopAllowthissite.Text = "Always allow popups from this site..."
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPopBlockEnabled, Me.mnuPopShowInfoBar, Me.mnuPopMoreSettings})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'mnuPopBlockEnabled
        '
        Me.mnuPopBlockEnabled.Name = "mnuPopBlockEnabled"
        Me.mnuPopBlockEnabled.Size = New System.Drawing.Size(208, 22)
        Me.mnuPopBlockEnabled.Text = "Turn Off Popup Blocker"
        '
        'mnuPopShowInfoBar
        '
        Me.mnuPopShowInfoBar.Name = "mnuPopShowInfoBar"
        Me.mnuPopShowInfoBar.Size = New System.Drawing.Size(208, 22)
        Me.mnuPopShowInfoBar.Text = "Show Info Bar for popups"
        '
        'mnuPopMoreSettings
        '
        Me.mnuPopMoreSettings.Name = "mnuPopMoreSettings"
        Me.mnuPopMoreSettings.Size = New System.Drawing.Size(208, 22)
        Me.mnuPopMoreSettings.Text = "More settings..."
        '
        'wb
        '
        Me.wb.ContextMenuStrip = Me.ContextMenuStrip1
        Me.wb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wb.Location = New System.Drawing.Point(0, 16)
        Me.wb.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wb.Name = "wb"
        Me.wb.ScriptErrorsSuppressed = True
        Me.wb.Size = New System.Drawing.Size(616, 420)
        Me.wb.TabIndex = 0
        '
        'InfoBar1
        '
        Me.InfoBar1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.InfoBar1.ContextMenuStrip = Me.cmiInfoBar
        Me.InfoBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.InfoBar1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoBar1.ForeColor = System.Drawing.Color.Black
        Me.InfoBar1.Location = New System.Drawing.Point(0, 0)
        Me.InfoBar1.Name = "InfoBar1"
        Me.InfoBar1.PlaySound = False
        Me.InfoBar1.Size = New System.Drawing.Size(616, 16)
        Me.InfoBar1.TabIndex = 0
        Me.InfoBar1.Visible = False
        '
        'frmBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(616, 436)
        Me.Controls.Add(Me.wb)
        Me.Controls.Add(Me.InfoBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBrowser"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.cmiInfoBar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents InfoBar1 As Xtravo.InfoBar
    Friend WithEvents wb As Xtravo.exBrowser
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuPage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPageSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPagePrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuImageSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuImageCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuImageProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuBack As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuForward As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ElemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewImageNewTab As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmiInfoBar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuPopTempAllow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPopAllowthissite As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPopBlockEnabled As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPopShowInfoBar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPopMoreSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSaveAllImages As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenInNewTabToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
