<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPhising
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPhising))
        Me.btnBack = New System.Windows.Forms.Button
        Me.btnIgnore = New System.Windows.Forms.Button
        Me.lbPhishing = New System.Windows.Forms.ListBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(209, 3)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 25)
        Me.btnBack.TabIndex = 0
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnIgnore
        '
        Me.btnIgnore.Location = New System.Drawing.Point(3, 3)
        Me.btnIgnore.Name = "btnIgnore"
        Me.btnIgnore.Size = New System.Drawing.Size(128, 25)
        Me.btnIgnore.TabIndex = 1
        Me.btnIgnore.Text = "Ignore and continue"
        Me.btnIgnore.UseVisualStyleBackColor = True
        '
        'lbPhishing
        '
        Me.lbPhishing.FormattingEnabled = True
        Me.lbPhishing.ItemHeight = 14
        Me.lbPhishing.Location = New System.Drawing.Point(3, 33)
        Me.lbPhishing.Name = "lbPhishing"
        Me.lbPhishing.Size = New System.Drawing.Size(293, 130)
        Me.lbPhishing.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnBack)
        Me.Panel1.Controls.Add(Me.btnIgnore)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 173)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(299, 37)
        Me.Panel1.TabIndex = 4
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.DimGray
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Enabled = False
        Me.Splitter1.Location = New System.Drawing.Point(0, 170)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(299, 3)
        Me.Splitter1.TabIndex = 5
        Me.Splitter1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(301, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Phishing Filter has detected potentially harmful content."
        '
        'frmPhising
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(299, 210)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbPhishing)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPhising"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Phishing Warning"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnIgnore As System.Windows.Forms.Button
    Friend WithEvents lbPhishing As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
