<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScrapeImages
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScrapeImages))
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pBar = New System.Windows.Forms.ProgressBar()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPath = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bmpbtn = New System.Windows.Forms.RadioButton()
        Me.gifbtn = New System.Windows.Forms.RadioButton()
        Me.pngbn = New System.Windows.Forms.RadioButton()
        Me.jpegbtn = New System.Windows.Forms.RadioButton()
        Me.chkOpen = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.Color.Transparent
        Me.btnStart.ForeColor = System.Drawing.Color.Black
        Me.btnStart.Location = New System.Drawing.Point(330, 156)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(56, 23)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(270, 156)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(54, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pBar
        '
        Me.pBar.Location = New System.Drawing.Point(8, 32)
        Me.pBar.Name = "pBar"
        Me.pBar.Size = New System.Drawing.Size(375, 18)
        Me.pBar.TabIndex = 2
        Me.pBar.Visible = False
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(61, 5)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(284, 21)
        Me.txtPath.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 18)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Save to:"
        '
        'btnPath
        '
        Me.btnPath.Location = New System.Drawing.Point(351, 3)
        Me.btnPath.Name = "btnPath"
        Me.btnPath.Size = New System.Drawing.Size(32, 23)
        Me.btnPath.TabIndex = 6
        Me.btnPath.Text = "..."
        Me.btnPath.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(11, 32)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(372, 39)
        Me.lblStatus.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.bmpbtn)
        Me.Panel1.Controls.Add(Me.gifbtn)
        Me.Panel1.Controls.Add(Me.pngbn)
        Me.Panel1.Controls.Add(Me.jpegbtn)
        Me.Panel1.Controls.Add(Me.txtPath)
        Me.Panel1.Controls.Add(Me.chkOpen)
        Me.Panel1.Controls.Add(Me.pBar)
        Me.Panel1.Controls.Add(Me.lblStatus)
        Me.Panel1.Controls.Add(Me.btnStart)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnPath)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(10, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(389, 187)
        Me.Panel1.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(58, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(272, 18)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Choose the Format of the File you want to Save As:"
        '
        'bmpbtn
        '
        Me.bmpbtn.AutoSize = True
        Me.bmpbtn.Location = New System.Drawing.Point(338, 121)
        Me.bmpbtn.Name = "bmpbtn"
        Me.bmpbtn.Size = New System.Drawing.Size(45, 17)
        Me.bmpbtn.TabIndex = 13
        Me.bmpbtn.TabStop = True
        Me.bmpbtn.Text = "Bmp"
        Me.bmpbtn.UseVisualStyleBackColor = True
        '
        'gifbtn
        '
        Me.gifbtn.AutoSize = True
        Me.gifbtn.Location = New System.Drawing.Point(245, 121)
        Me.gifbtn.Name = "gifbtn"
        Me.gifbtn.Size = New System.Drawing.Size(38, 17)
        Me.gifbtn.TabIndex = 12
        Me.gifbtn.TabStop = True
        Me.gifbtn.Text = "Gif"
        Me.gifbtn.UseVisualStyleBackColor = True
        '
        'pngbn
        '
        Me.pngbn.AutoSize = True
        Me.pngbn.Location = New System.Drawing.Point(135, 121)
        Me.pngbn.Name = "pngbn"
        Me.pngbn.Size = New System.Drawing.Size(43, 17)
        Me.pngbn.TabIndex = 11
        Me.pngbn.TabStop = True
        Me.pngbn.Text = "Png"
        Me.pngbn.UseVisualStyleBackColor = True
        '
        'jpegbtn
        '
        Me.jpegbtn.AutoSize = True
        Me.jpegbtn.Location = New System.Drawing.Point(14, 121)
        Me.jpegbtn.Name = "jpegbtn"
        Me.jpegbtn.Size = New System.Drawing.Size(48, 17)
        Me.jpegbtn.TabIndex = 10
        Me.jpegbtn.TabStop = True
        Me.jpegbtn.Text = "Jpeg"
        Me.jpegbtn.UseVisualStyleBackColor = True
        '
        'chkOpen
        '
        Me.chkOpen.Location = New System.Drawing.Point(14, 156)
        Me.chkOpen.Name = "chkOpen"
        Me.chkOpen.Size = New System.Drawing.Size(212, 19)
        Me.chkOpen.TabIndex = 9
        Me.chkOpen.Text = "Open save directory when complete."
        Me.chkOpen.UseVisualStyleBackColor = True
        '
        'frmScrapeImages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(409, 207)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScrapeImages"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Image Sniffer v2"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pBar As System.Windows.Forms.ProgressBar
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPath As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkOpen As System.Windows.Forms.CheckBox
    Friend WithEvents bmpbtn As System.Windows.Forms.RadioButton
    Friend WithEvents gifbtn As System.Windows.Forms.RadioButton
    Friend WithEvents pngbn As System.Windows.Forms.RadioButton
    Friend WithEvents jpegbtn As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
