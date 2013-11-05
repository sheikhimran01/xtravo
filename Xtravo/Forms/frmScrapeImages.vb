Imports System.IO
Public Class frmScrapeImages

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        'Don't really care if this fails due to some fluke, 
        'Want the process to continue and grab as many images as it can.
        On Error Resume Next
        If txtPath.Text = String.Empty Then
            MessageBox.Show("Please select a folder to save the images to", _
            "Select Folder", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Not Directory.Exists(txtPath.Text) Then
            MessageBox.Show("Please select a valid directory.", _
            "Select Folder", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        btnStart.Enabled = False
        btnCancel.Enabled = False
        Dim oDoc As HtmlDocument = AppManager.CurrentBrowser.Document
        pBar.Visible = True
        pBar.Maximum = oDoc.Images.Count
        Dim oImage As Image

        Dim i As Integer
        For i = 0 To oDoc.Images.Count - 1
            oImage = AppManager.GetWebImage(oDoc.Images(i).GetAttribute("src"))
            If Not IsNothing(oImage) Then
                Dim ofile() As String = Split(oDoc.Images(i).GetAttribute("src"), "/")
                If jpegbtn.Checked = True Then
                    oImage.Save(txtPath.Text & "\Image" & i & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
                Else
                    If pngbn.Checked = True Then
                        oImage.Save(txtPath.Text & "\Image" & i & ".png", System.Drawing.Imaging.ImageFormat.Png)
                    Else
                        If gifbtn.Checked = True Then
                            oImage.Save(txtPath.Text & "\Image" & i & ".gif", System.Drawing.Imaging.ImageFormat.Gif)
                        Else
                            If bmpbtn.Checked = True Then
                                oImage.Save(txtPath.Text & "\Image" & i & ".bmp", System.Drawing.Imaging.ImageFormat.Bmp)
                                lblStatus.Text = "Saving " & ofile(UBound(ofile)).ToString & "..."
                            End If
                        End If
                    End If
                End If
            End If
            pBar.Value = i
            Application.DoEvents()
            oImage = Nothing
        Next

        If chkOpen.Checked = True Then
            'Even though we already checked... we'll check again just to be safe.
            If Directory.Exists(txtPath.Text) Then
                Process.Start(txtPath.Text)
            End If
        End If

        Me.Close()
    End Sub

    Private Sub btnPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPath.Click
        Dim fbd As New FolderBrowserDialog
        fbd.ShowDialog()
        txtPath.Text = fbd.SelectedPath
    End Sub

    Private Sub frmScrapeImages_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class