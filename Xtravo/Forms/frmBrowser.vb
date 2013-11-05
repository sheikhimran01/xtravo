Imports System.IO
Imports System.Net
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Security.Permissions
Imports System.ComponentModel

<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
<System.Runtime.InteropServices.ComVisibleAttribute(True)> _
Public Class frmBrowser

    Public WithEvents oDoc As HtmlDocument
    Private oElement As HtmlElement
    Private TempPopAllowed As Boolean = False
    Private popURL As String
    Private LastDomain As String
    'Public PageImage As New PictureBox
    Public NumFeeds As Integer = 0

#Region " Form "
    Private Sub frmBrowser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        oDoc = Nothing
        My.Settings.Save()
        wb.Dispose()
    End Sub

    Private Sub frmBrowser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppManager.CurrentBrowser = Me.wb
        wb.ObjectForScripting = Me
        Me.wb.IsWebBrowserContextMenuEnabled = True
    End Sub

#End Region

#Region " Handleing Document Script Calls "
    'Since we are using the browser control, we have to handle javascript and other events raised by
    'the html document that target window.external such as add to favorites, organize favorites etc. 
    'We could implement this in the extended control itself, 
    'but for purposes of this demo, we will handle a couple common ones
    'in this region.
    '// Security note on Javascript handleing, you will probably want to check to make
    '//sure that the event was raised by a user click or show dialogs, not allow automatic running of
    '//these routines by using dialogs or other methods.
    '//Make sure your signatures match the common calls from the page.
    Public Sub AddFavorite(ByVal strURL As String, ByVal strTitle As String)
        wb.AddToFavorites(Trim(strURL), Trim(strTitle))
    End Sub

    Public Sub OrganizeFavorites()
        wb.ShowOrganizeFavorites()
    End Sub

    Public Sub ShowCalc()
        Process.Start("Calc.exe")
    End Sub

    Public Sub ShowSettings()
        Dim ofrm As New frmSettings
        ofrm.ShowDialog(AppManager.MainForm)
    End Sub

#End Region

#Region " Browser Control  / Document "
    Private Sub wb_CanGoBackChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles wb.CanGoBackChanged
        AppManager.MainForm.btnBack.Enabled = wb.CanGoBack
    End Sub

    Private Sub wb_CanGoForwardChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles wb.CanGoForwardChanged
        AppManager.MainForm.btnForward.Enabled = wb.CanGoForward
    End Sub

    Private Sub wb_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles wb.DocumentCompleted
        FastWebsiteLoading()
    End Sub
    Private Sub FastWebsiteLoading()
        oDoc = wb.Document
        Dim s As String
        Dim strDomain() As String
        For Each s In My.Settings.BlockedSites
            strDomain = Split(s, "http://")
            If strDomain(1) = wb.Document.Domain Then
                wb.DocumentText = My.Resources.Blocked
                AppManager.MainForm.pBar.Visible = False
                Exit Sub
            End If
            Me.wb.ObjectForScripting = True
            wb.ScriptErrorsSuppressed = True

        Next

        Me.Text = wb.DocumentTitle
        'Here you may want to prefetch the icon, or implement a form of caching icons.

        AppManager.MainForm.pBar.Visible = False

        If LastDomain = oDoc.Domain Then
            'We want to leave the popup settings alone.
        Else
            'different domain, reset the popup blocker.
            Me.TempPopAllowed = False
            InfoBar1.PictureBox1.Image = My.Resources.popBlocked
            InfoBar1.Text = " Pop up blocked."
            LastDomain = oDoc.Domain
        End If
        If My.Settings.UsePhishingFilter = True Then
            RunPhishingFilter()
        End If
    End Sub


    Private Sub oDoc_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.HtmlElementEventArgs) Handles oDoc.MouseDown
        'Here is it's an input element? if yes we want to show the normal windows options....
        If My.Settings.UseInternalMenu = True Then
            If e.MouseButtonsPressed = Windows.Forms.MouseButtons.Right And oElement.TagName = "INPUT" Then
                wb.IsWebBrowserContextMenuEnabled = True
            Else
                wb.IsWebBrowserContextMenuEnabled = False
            End If
        End If
        Dim MPoint As New Point(e.MousePosition.X, e.MousePosition.Y)
        oElement = oDoc.GetElementFromPoint(MPoint)

        If MouseButtons = Windows.Forms.MouseButtons.Middle Then
            Dim ofrm As New frmBrowser
            AppManager.AddTab(ofrm, oElement.GetAttribute("HREF"))
        End If
    End Sub

    Private Sub oDoc_MouseMove(ByVal sender As Object, _
    ByVal e As System.Windows.Forms.HtmlElementEventArgs) Handles oDoc.MouseMove
        On Error Resume Next
        Dim MPoint As New Point(e.MousePosition.X, e.MousePosition.Y)
        If My.Settings.ShowTags = True Then
            AppManager.MainForm.lblElement.Text = "<" & oElement.TagName & ">"
        Else
            AppManager.MainForm.lblElement.Text = String.Empty
        End If
        oElement = oDoc.GetElementFromPoint(MPoint)
    End Sub

    Private Sub wb_EncryptionLevelChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles wb.EncryptionLevelChanged
        With AppManager.MainForm.lblSec
            Select Case wb.EncryptionLevel
                Case WebBrowserEncryptionLevel.Bit128
                    .Image = My.Resources.Lock
                Case WebBrowserEncryptionLevel.Bit40
                    .Image = My.Resources.Lock
                Case WebBrowserEncryptionLevel.Bit56
                    .Image = My.Resources.Lock
                Case WebBrowserEncryptionLevel.Fortezza
                    .Image = My.Resources.Lock
                Case WebBrowserEncryptionLevel.Insecure
                    .Image = My.Resources.LockOpen
                Case WebBrowserEncryptionLevel.Mixed
                    .Image = My.Resources.LockOpen
                Case WebBrowserEncryptionLevel.Unknown
                    .Image = My.Resources.LockOpen
                Case Else
                    .Image = My.Resources.LockOpen
            End Select
            .ToolTipText = wb.EncryptionLevel.ToString
        End With
    End Sub

    Private Sub wb_NavigatingExtended(ByVal sender As Object, ByVal e As exBrowser.WebBrowserNavigatingExtendedEventArgs) Handles wb.NavigatingExtended
        Dim s As String
        For Each s In My.Settings.BlockedSites
            If s = e.Url.ToString Or s & "/" = e.Url.ToString Then
                e.Cancel = True
                wb.DocumentText = My.Resources.Blocked
                AppManager.MainForm.pBar.Visible = False
            Else
                AppManager.MainForm.pBar.Visible = True
            End If
        Next
    End Sub

    Private Sub wb_NewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles wb.NewWindow
        e.Cancel = True
    End Sub

    Private Sub wb_NewWindowExtended(ByVal sender As Object, _
    ByVal e As exBrowser.WebBrowserNewWindowExtendedEventArgs) Handles wb.NewWindowExtended

        '//////////// End DL checking ///////////////////////
        'Here we implement something simular to IE 7
        'You might want to allow shit + click or some other override, that's up to you.
        '1st check if site is in allowed list
        Dim s As String
        For Each s In My.Settings.AllowedPopSites
            If s = wb.Document.Domain Then
                'Site is allowed... Show pop in new tab and exit...
                e.Cancel = True
                Dim ofrm As New frmBrowser
                AppManager.AddTab(ofrm, e.Url.ToString)
                Exit Sub
            End If
        Next
        If My.Settings.PopUpBlockerEnabled = True Then
            If Me.TempPopAllowed = True Then
                'Site temporarily allowed... open in new tab, then exit...
                e.Cancel = True
                Dim ofrm As New frmBrowser
                AppManager.AddTab(ofrm, e.Url.ToString)
                Exit Sub
            Else
                'Blocker is enabled and not temp allowed...
                e.Cancel = True
                If My.Settings.PopSound = True Then
                    My.Computer.Audio.Play(My.Resources.Windows_Pop_up_Blocked, AudioPlayMode.Background)
                End If
                If My.Settings.PopInfoBar = True Then
                    Me.InfoBar1.Visible = True
                End If
                popURL = e.Url.ToString
            End If
        Else
            'Blocker is not enabled... open in new tab.
            e.Cancel = True
            Dim ofrm As New frmBrowser
            AppManager.AddTab(ofrm, e.Url.ToString)
        End If

    End Sub

    Private Sub wb_StatusTextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles wb.StatusTextChanged
        If AppManager.CurrentBrowser Is Me.wb Then
            AppManager.MainForm.lblStatus.Text = wb.StatusText
        End If
    End Sub

    Private Function FixURL(ByVal sURL As String) As String
        sURL = sURL.Trim
        If Not sURL.ToLower().StartsWith("http://") _
        Then sURL = "http://" & sURL
        Return sURL
    End Function
    Private Sub wb_DocumentTitleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles wb.DocumentTitleChanged
        Me.Text = wb.DocumentTitle
        AppManager.MainForm.Text = wb.DocumentTitle & " - " & My.Resources.AppName
    End Sub

    Private Sub wb_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles wb.Navigated
        AppManager.MainForm.Text = wb.DocumentTitle & " - " & My.Resources.AppName
        AppManager.MainForm.pBar.Visible = False
        Me.Icon = AppManager.GetFavIcon(wb.Document.Domain & "/favicon.ico")
        AppManager.MainForm.tc1.TabPages(Me).Icon = Me.Icon
        AppManager.MainForm.cboURL.Text = wb.Url.ToString
        wb.ScriptErrorsSuppressed = True
        If My.Settings.RSScheck = True Then
            DetectFeeds()
        Else
            frmMain.CheckFeedsToolStripMenuItem.Enabled = False
            frmMain.RssFeedToolStripMenuItem1.Enabled = False
        End If
    End Sub

    Private Sub RunPhishingFilter()
        '///////////////////////////////////////////////////////////
        'Here you could parse the page for bad links, images etc from
        'a known list of sites...
        'Here we will just use the blocked sites list
        'as an example of what to do
        '///////////////////////////////////////////////////////////
        Dim BadLink As Boolean = False
        Dim oEl As HtmlElement
        Dim s As String
        Dim li As ListItem
        Dim ofrm As New frmPhising
        For Each oEl In oDoc.Links
            For Each s In My.Settings.PhishingSites
                If InStr(oEl.GetAttribute("HREF"), s) Then
                    li = New ListItem
                    li.Text = oEl.GetAttribute("HREF")
                    ofrm.lbPhishing.Items.Add(li)
                    BadLink = True
                End If
            Next
        Next
        If BadLink = True Then
            ofrm.ShowDialog()
        Else
            ofrm.Dispose()
        End If
    End Sub

    Private Sub DetectFeeds()
        Try
            Dim oEl As HtmlElement
            For Each oEl In wb.Document.All
                If oEl.GetAttribute("Type") = "application/rss+xml" Then
                    NumFeeds = NumFeeds + 1
                End If
            Next
            If NumFeeds = 0 Then
                AppManager.MainForm.mnuFeeds.Enabled = False
            Else
                AppManager.MainForm.mnuFeeds.Enabled = True
            End If
        Catch ex As Exception
            NumFeeds = 0
            AppManager.MainForm.mnuFeeds.Enabled = False
        End Try
    End Sub

#End Region

#Region " Context Menu "
    Private Sub mnuImageSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImageSave.Click
        Dim opb As New PictureBox
        Dim sfd As New SaveFileDialog

        Try
            Dim odir As String = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            sfd.InitialDirectory = odir.ToString
            Dim ofile() As String = Split(oElement.GetAttribute("src"), "/")
            sfd.Title = "Save web image"
            sfd.FileName = ofile(UBound(ofile)).ToString
            If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If sfd.FileName = String.Empty Then
                    Exit Sub
                Else
                    AppManager.LoadWebImageToPictureBox(opb, oElement.GetAttribute("src"))
                    opb.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
                End If
                If AppManager.LoadWebImageToPictureBox(opb, oElement.GetAttribute("src")) Then
                    opb.Image.Save(sfd.FileName, Imaging.ImageFormat.Gif)
                End If
                If AppManager.LoadWebImageToPictureBox(opb, oElement.GetAttribute("src")) Then
                    opb.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
                    If AppManager.LoadWebImageToPictureBox(opb, oElement.GetAttribute("src")) Then
                        opb.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
                    End If
                    If AppManager.LoadWebImageToPictureBox(opb, oElement.GetAttribute("src")) Then
                        opb.Image.Save(sfd.FileName, Imaging.ImageFormat.Emf)
                    End If
                    If AppManager.LoadWebImageToPictureBox(opb, oElement.GetAttribute("src")) Then
                        opb.Image.Save(sfd.FileName, Imaging.ImageFormat.Icon)
                    End If
                    If AppManager.LoadWebImageToPictureBox(opb, oElement.GetAttribute("src")) Then
                        opb.Image.Save(sfd.FileName, Imaging.ImageFormat.Tiff)
                    End If
                    If AppManager.LoadWebImageToPictureBox(opb, oElement.GetAttribute("src")) Then
                        opb.Image.Save(sfd.FileName, Imaging.ImageFormat.Wmf)
                    End If
                End If
            End If
        Catch ex As Exception
            Dim ofrm As New frmError
            ofrm.err = ex
            ofrm.ShowDialog()
        Finally
            opb.Dispose()
            sfd.Dispose()
        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If Not IsNothing(oElement) Then
            If oElement.TagName = "IMG" Then
                mnuImage.Enabled = True
            Else
                mnuImage.Enabled = False
            End If
            If oElement.TagName = "A" Or oElement.TagName = "AREA" Or oElement.TagName = "p" Then
                OpenInNewTabToolStripMenuItem.Enabled = True
            Else
                OpenInNewTabToolStripMenuItem.Enabled = False
            End If
        End If
        mnuBack.Enabled = AppManager.CurrentBrowser.CanGoBack
        mnuForward.Enabled = AppManager.CurrentBrowser.CanGoForward
    End Sub

    Private Sub ElemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ElemToolStripMenuItem.Click
        ShowProps()
    End Sub
    Private Sub mnuImageProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImageProperties.Click
        ShowProps()
    End Sub

    Private Sub ShowProps()
        Dim ofrm As New frmProperties
        ofrm.obj = oElement
        ofrm.Show()
    End Sub
    Private Sub PropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        AppManager.CurrentBrowser.ShowPropertiesDialog()
    End Sub

    Private Sub mnuPageSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPageSaveAs.Click
        AppManager.CurrentBrowser.ShowSaveAsDialog()
    End Sub

    Private Sub mnuPagePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPagePrint.Click
        AppManager.CurrentBrowser.ShowPrintDialog()
    End Sub
    Private Sub mnuCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopy.Click
        AppManager.CurrentBrowser.Document.ExecCommand("Copy", False, System.DBNull.Value)
    End Sub

    Private Sub mnuPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPaste.Click
        AppManager.CurrentBrowser.Document.ExecCommand("Paste", False, System.DBNull.Value)
    End Sub
    Private Sub mnuViewImageNewTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewImageNewTab.Click
        Dim ofrm As New frmBrowser
        AppManager.AddTab(ofrm, oElement.GetAttribute("src"))
    End Sub

    Private Sub mnuFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFind.Click
        AppManager.CurrentBrowser.ShowFindDialog()
    End Sub

    Private Sub wb_ProgressChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs) Handles wb.ProgressChanged
        If AppManager.CurrentBrowser Is Me.wb Then
            AppManager.MainForm.lblStatus.Text = wb.StatusText
            AppManager.MainForm.pBar.Value = ((e.CurrentProgress / e.MaximumProgress) * 100)
        End If
    End Sub

    Private Sub mnuImageCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImageCopy.Click
        Dim opb As New PictureBox
        AppManager.LoadWebImageToPictureBox(opb, oElement.GetAttribute("src"))
        Clipboard.SetImage(opb.Image)
        opb.Dispose()
    End Sub

    Private Sub mnuPopTempAllow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPopTempAllow.Click
        Me.TempPopAllowed = True
        InfoBar1.Text = "Popups Temporarily allowed."
        InfoBar1.PictureBox1.Image = My.Resources.popallowed
        If Me.popURL = "" Then
            'Nothing to do
        Else
            Dim oFrm As New frmBrowser
            AppManager.AddTab(oFrm, popURL)
            InfoBar1.Visible = False
        End If
    End Sub

    Private Sub mnuPopAllowthissite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPopAllowthissite.Click
        My.Settings.AllowedPopSites.Add(wb.Document.Domain)
    End Sub

    Private Sub mnuPopBlockEnabled_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPopBlockEnabled.Click
        My.Settings.PopUpBlockerEnabled = mnuPopBlockEnabled.Checked
    End Sub

    Private Sub mnuPopShowInfoBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPopShowInfoBar.Click
        My.Settings.PopInfoBar = mnuPopShowInfoBar.Checked
    End Sub

    Private Sub mnuPopMoreSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPopMoreSettings.Click
        Dim ofrm As New frmSettings
        ofrm.TabControl1.SelectedIndex = 0
        ofrm.ShowDialog(AppManager.MainForm)
    End Sub

    Private Sub cmiInfoBar_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmiInfoBar.Opening
        Select Case My.Settings.PopUpBlockerEnabled
            Case True
                mnuPopBlockEnabled.Text = "Pop up Blocker Enabled."
            Case False
                mnuPopBlockEnabled.Text = "Pop up Blocker Disabled."
        End Select
        mnuPopBlockEnabled.Checked = My.Settings.PopUpBlockerEnabled
        mnuPopShowInfoBar.Checked = My.Settings.PopInfoBar
    End Sub
    Private Sub mnuSaveAllImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveAllImages.Click
        Dim ofrm As New frmScrapeImages
        ofrm.ShowDialog(AppManager.MainForm)
    End Sub

#End Region

    Private Sub OpenInNewTabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenInNewTabToolStripMenuItem.Click
        Dim ofrm As New frmBrowser
        AppManager.AddTab(ofrm, oElement.GetAttribute("HREF"))
    End Sub
End Class
