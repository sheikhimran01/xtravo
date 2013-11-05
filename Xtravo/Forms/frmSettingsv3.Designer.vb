<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettingsv3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettingsv3))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.homepage_set_url = New System.Windows.Forms.TextBox()
        Me.save_all_btn = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.tabpage_set_url = New System.Windows.Forms.TextBox()
        Me.blank_page_open_btn = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(-2, -1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(584, 436)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.RadioButton3)
        Me.TabPage1.Controls.Add(Me.RadioButton2)
        Me.TabPage1.Controls.Add(Me.blank_page_open_btn)
        Me.TabPage1.Controls.Add(Me.tabpage_set_url)
        Me.TabPage1.Controls.Add(Me.homepage_set_url)
        Me.TabPage1.Controls.Add(Me.save_all_btn)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(576, 410)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Home"
        '
        'homepage_set_url
        '
        Me.homepage_set_url.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.homepage_set_url.Location = New System.Drawing.Point(187, 26)
        Me.homepage_set_url.Name = "homepage_set_url"
        Me.homepage_set_url.Size = New System.Drawing.Size(349, 29)
        Me.homepage_set_url.TabIndex = 1
        '
        'save_all_btn
        '
        Me.save_all_btn.Location = New System.Drawing.Point(410, 61)
        Me.save_all_btn.Name = "save_all_btn"
        Me.save_all_btn.Size = New System.Drawing.Size(75, 23)
        Me.save_all_btn.TabIndex = 0
        Me.save_all_btn.Text = "Save All"
        Me.save_all_btn.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(523, 333)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Privacy"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(523, 333)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Customize"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(523, 333)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Data"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'tabpage_set_url
        '
        Me.tabpage_set_url.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabpage_set_url.Location = New System.Drawing.Point(118, 104)
        Me.tabpage_set_url.Name = "tabpage_set_url"
        Me.tabpage_set_url.Size = New System.Drawing.Size(349, 29)
        Me.tabpage_set_url.TabIndex = 2
        '
        'blank_page_open_btn
        '
        Me.blank_page_open_btn.AutoSize = True
        Me.blank_page_open_btn.Location = New System.Drawing.Point(278, 70)
        Me.blank_page_open_btn.Name = "blank_page_open_btn"
        Me.blank_page_open_btn.Size = New System.Drawing.Size(80, 17)
        Me.blank_page_open_btn.TabIndex = 4
        Me.blank_page_open_btn.TabStop = True
        Me.blank_page_open_btn.Text = "Blank Page"
        Me.blank_page_open_btn.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(90, 70)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(84, 17)
        Me.RadioButton2.TabIndex = 5
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Current URL"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(73, 38)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(90, 17)
        Me.RadioButton3.TabIndex = 6
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Custom page:"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'frmSettingsv3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 433)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSettingsv3"
        Me.Text = "Options"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents homepage_set_url As System.Windows.Forms.TextBox
    Friend WithEvents save_all_btn As System.Windows.Forms.Button
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents blank_page_open_btn As System.Windows.Forms.RadioButton
    Friend WithEvents tabpage_set_url As System.Windows.Forms.TextBox
End Class
