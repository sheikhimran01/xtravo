<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CapBrowser
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.pb = New System.Windows.Forms.PictureBox
        Me.Panel1.SuspendLayout()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(5, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(320, 21)
        Me.Panel1.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = Global.Xtravo.My.Resources.Resources.Delete16
        Me.btnClose.Location = New System.Drawing.Point(297, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(23, 21)
        Me.btnClose.TabIndex = 0
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'pb
        '
        Me.pb.BackColor = System.Drawing.Color.White
        Me.pb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pb.Location = New System.Drawing.Point(5, 26)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(320, 151)
        Me.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb.TabIndex = 2
        Me.pb.TabStop = False
        '
        'CapBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(10)
        Me.Name = "CapBrowser"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.Size = New System.Drawing.Size(330, 182)
        Me.Panel1.ResumeLayout(False)
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pb As System.Windows.Forms.PictureBox

End Class
