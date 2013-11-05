'///////////////////////////////////////////
'Form to facilitate settings in the application.
'///////////////////////////////////////////
Imports System.Enum
Imports System.Data.OleDb
Imports System.IO
Imports Microsoft.Win32

Public Class frmSettings

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBlockedSites()
        LoadPhishingSites()
        LoadPopUpSettings()
        LoadPopAllowed()
        LoadAdditional()
        Loadsearchtool()
        LoadCurrenthomepage()
        LoadTabcurrentpage()
        Loadstatusdailysite()
        Loadprivateon()
        Addressn1()
        passlock.Text = My.Settings.Passwordbrowser
        Me.Opacity = 100

    End Sub

#Region " Popup Blocker Settings "



    Private Sub LoadPopUpSettings()
        chkAllowPop.Checked = My.Settings.PopUpBlockerEnabled
        chkPopSound.Checked = My.Settings.PopSound
        chkPopInfo.Checked = My.Settings.PopInfoBar
    End Sub

    Private Sub LoadPopAllowed()
        lbPop.Items.Clear()
        Dim li As ListItem
        Dim s As String
        For Each s In My.Settings.AllowedPopSites
            li = New ListItem
            li.Text = s
            lbPop.Items.Add(li)
        Next
    End Sub

    Private Sub chkAllowPop_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllowPop.CheckedChanged
        My.Settings.PopUpBlockerEnabled = chkAllowPop.Checked
        My.Settings.UseInternalMenu = True
        chkInternal.Checked = True
        My.Settings.Save()
        My.Settings.Save()

        If My.Settings.PopUpBlockerEnabled = False Then
            My.Settings.UseInternalMenu = False
            chkInternal.Checked = False
            My.Settings.Save()
            My.Settings.Save()
        End If
    End Sub

    Private Sub chkPopSound_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPopSound.CheckedChanged
        My.Settings.PopSound = chkPopSound.Checked
    End Sub

    Private Sub chkPopInfo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPopInfo.CheckedChanged
        My.Settings.PopInfoBar = chkPopInfo.Checked
    End Sub

    Private Sub btnPopAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPopAdd.Click
        If txtPop.Text = "www." & txtPop.Text Then
            'Do nothing
        Else
            My.Settings.AllowedPopSites.Add(txtPop.Text)
            txtPop.Text = String.Empty
            LoadPopAllowed()
        End If
    End Sub

    Private Sub btnPopRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPopRemove.Click
        Dim li As ListItem
        If lbPop.SelectedItems.Count > 0 Then
            For Each li In lbPop.SelectedItems
                My.Settings.AllowedPopSites.Remove(li.Text)
            Next
            LoadPopAllowed()
        End If
    End Sub

    Private Sub btnPopRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPopRemoveAll.Click
        My.Settings.AllowedPopSites.Clear()
        lbPop.Items.Clear()
    End Sub

#End Region

#Region " Blocked Sites "

    Private Sub LoadBlockedSites()
        lbBlocked.Items.Clear()
        Dim s As String
        For Each s In My.Settings.BlockedSites
            lbBlocked.Items.Add(s)
        Next
    End Sub

    Private Sub btnAddBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBlock.Click
        If txtBlock.Text = "" Then
            'Do nothing
        Else
            My.Settings.BlockedSites.Add(AppManager.FixURL(txtBlock.Text))
            LoadBlockedSites()
            txtBlock.Text = String.Empty
        End If
    End Sub

    Private Sub btnBlockRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBlockRemoveAll.Click
        Dim s As String
        For Each s In My.Settings.BlockedSites
            My.Settings.BlockedSites.Remove(s)
        Next
        LoadBlockedSites()
    End Sub

    Private Sub btnRemoveBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveBlock.Click
        If lbBlocked.SelectedIndices.Count > 0 Then
            My.Settings.BlockedSites.Remove(lbBlocked.SelectedItem)
            LoadBlockedSites()
        End If
    End Sub

#End Region

#Region " Integrations "

    Private Sub LoadAdditional()
        chkInternal.Checked = My.Settings.UseInternalMenu
        chkShowTags.Checked = My.Settings.ShowTags
        chkSupress.Checked = My.Settings.SupressScriptErrs
        chkStart.Checked = My.Settings.UseStartPage
        chkPhishing.Checked = My.Settings.UsePhishingFilter
        topsitespertab.Checked = My.Settings.Usetopsitestab
        linkssss.Checked = My.Settings.linksk
        statubarlook.Checked = My.Settings.statubar
        searchbox.Checked = My.Settings.searchbox
        rsscheckbox.Checked = My.Settings.RSScheck
        lockactivate.Checked = My.Settings.lockup
    End Sub

    Private Sub chkInternal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInternal.CheckedChanged
        My.Settings.UseInternalMenu = chkInternal.Checked
        Dim ofrm As frmBrowser
        Dim i As Integer
        For i = 0 To AppManager.MainForm.tc1.TabPages.Count - 1
            If TypeOf AppManager.MainForm.tc1.TabPages.Item(i).Form Is frmBrowser Then
                ofrm = AppManager.MainForm.tc1.TabPages.Item(i).Form
                ofrm.wb.IsWebBrowserContextMenuEnabled = Not (chkInternal.Checked)


            End If
        Next
    End Sub
    Private Sub chkShowTags_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowTags.CheckedChanged
        My.Settings.ShowTags = chkShowTags.Checked
    End Sub

    Private Sub chkSupress_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSupress.CheckedChanged
        My.Settings.SupressScriptErrs = chkSupress.Checked
        Dim ofrm As frmBrowser
        Dim i As Integer
        For i = 0 To AppManager.MainForm.tc1.TabPages.Count - 1
            If TypeOf AppManager.MainForm.tc1.TabPages.Item(i).Form Is frmBrowser Then
                ofrm = AppManager.MainForm.tc1.TabPages.Item(i).Form
                ofrm.wb.ScriptErrorsSuppressed = chkInternal.Checked
            End If
        Next
    End Sub

#End Region

#Region " Phishing "
    Private Sub LoadPhishingSites()
        lbPhishing.Items.Clear()
        Dim s As String
        For Each s In My.Settings.PhishingSites
            lbPhishing.Items.Add(s)
        Next
    End Sub
    Private Sub btnAddPhish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtPhishing.Text = "" Then
            'Do nothing
        Else
            My.Settings.PhishingSites.Add(AppManager.FixURL(txtPhishing.Text))
            LoadPhishingSites()
            txtPhishing.Text = String.Empty
        End If
    End Sub

    Private Sub btnRemovePhish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If lbPhishing.SelectedIndices.Count > 0 Then
            My.Settings.PhishingSites.Remove(lbPhishing.SelectedItem)
            LoadPhishingSites()
        End If
    End Sub

    Private Sub btnRemoveAllPhish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim s As String
        For Each s In My.Settings.PhishingSites
            My.Settings.PhishingSites.Remove(s)
        Next
        LoadPhishingSites()
    End Sub

#End Region

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub chkStart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStart.CheckedChanged
        My.Settings.UseStartPage = chkStart.Checked
        My.Settings.Save()
    End Sub

    Private Sub chkPhishing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.Settings.UsePhishingFilter = chkPhishing.Checked
        My.Settings.Save()
    End Sub

    Private Sub topsitespertab_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles topsitespertab.CheckedChanged
        My.Settings.Usetopsitestab = topsitespertab.Checked
        My.Settings.Save()
    End Sub

    Private Sub Loadsearchtool()
        Livesearch.Checked = My.Settings.bing
        googlesearch.Checked = My.Settings.googles
        yahoosearch.Checked = My.Settings.yahoo
        baidusearch.Checked = My.Settings.baidu
        yandex.Checked = My.Settings.yandex
        asksearch.Checked = My.Settings.asks
        blekko.Checked = My.Settings.blekko
        xsearch.Checked = My.Settings.xsearch
    End Sub
    Private Sub Addressn1()
        addressn1checkbox.Checked = My.Settings.addressn1
    End Sub
    Private Sub Loadprivateon()
        inp.Checked = My.Settings.privateon
    End Sub
#Region "Search Engines"
    Private Sub Livesearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Livesearch.CheckedChanged
        My.Settings.bing = Livesearch.Checked
        frmMain.textsearch.Text = "Bing Search | Wiki Search "
        frmMain.textsearch.ToolTipText = "Bing Search Default / Use Wiki Search by Ctrl+Enter"
        My.Settings.Save()
    End Sub

    Private Sub googlesearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles googlesearch.CheckedChanged
        My.Settings.googles = googlesearch.Checked
        frmMain.textsearch.Text = "Google Search | Wiki Search "
        frmMain.textsearch.ToolTipText = "Google Search Default / Use Wiki Search by Ctrl+Enter"
        My.Settings.Save()
    End Sub

    Private Sub yahoosearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles yahoosearch.CheckedChanged
        My.Settings.yahoo = yahoosearch.Checked
        frmMain.textsearch.Text = "Yahoo! Search | Wiki Search "
        frmMain.textsearch.ToolTipText = "Yahoo! Search Default / Use Wiki Search by Ctrl+Enter"
        My.Settings.Save()
    End Sub

    Private Sub baidusearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles baidusearch.CheckedChanged
        My.Settings.baidu = baidusearch.Checked
        frmMain.textsearch.Text = "Baidu | Wiki Search "
        frmMain.textsearch.ToolTipText = "Baidu Search Default / Use Wiki Search by Ctrl+Enter"
        My.Settings.Save()
    End Sub

    Private Sub yandex_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles yandex.CheckedChanged
        My.Settings.yandex = yandex.Checked
        frmMain.textsearch.Text = "Yandex| Wiki Search "
        frmMain.textsearch.ToolTipText = "Yandex Search Default / Use Wiki Search by Ctrl+Enter"
        My.Settings.Save()
    End Sub

    Private Sub asksearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles asksearch.CheckedChanged
        My.Settings.asks = asksearch.Checked
        frmMain.textsearch.Text = "Ask Search | Wiki Search "
        frmMain.textsearch.ToolTipText = "Ask Search Default / Use Wiki Search by Ctrl+Enter"
        My.Settings.Save()
    End Sub

    Private Sub blekko_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles blekko.CheckedChanged
        My.Settings.blekko = blekko.Checked
        frmMain.textsearch.Text = "Blekko | Wiki Search "
        frmMain.textsearch.ToolTipText = "Blekko Default / Use Wiki Search by Ctrl+Enter"
        My.Settings.Save()
    End Sub

    Private Sub xsearch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles xsearch.CheckedChanged
        My.Settings.xsearch = xsearch.Checked
        frmMain.textsearch.Text = "Jawoco | Wiki Search "
        frmMain.textsearch.ToolTipText = "Jawoco Default / Use Wiki Search by Ctrl+Enter"
        My.Settings.Save()
    End Sub
#End Region
#Region "Custom"
    Private Sub statubarlook_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles statubarlook.CheckedChanged
        My.Settings.statubar = statubarlook.Checked
        My.Settings.Save()

        If My.Settings.statubar = True Then
            frmMain.sBar.Visible = True
        Else
            frmMain.sBar.Visible = False
            My.Settings.Save()


        End If
    End Sub
    Private Sub rsscheckbox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rsscheckbox.CheckedChanged
        My.Settings.RSScheck = rsscheckbox.Checked
        My.Settings.Save()
        If My.Settings.RSScheck = True Then
            frmMain.RssFeedToolStripMenuItem1.Enabled = True
            frmMain.CheckFeedsToolStripMenuItem.Enabled = True
        Else
            frmMain.RssFeedToolStripMenuItem1.Enabled = False
            frmMain.CheckFeedsToolStripMenuItem.Enabled = False
        End If

    End Sub
    Private Sub addressn1checkbox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles addressn1checkbox.CheckedChanged
        My.Settings.addressn1 = addressn1checkbox.Checked
        My.Settings.Save()
    End Sub
    Private Sub searchbox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles searchbox.CheckedChanged
        My.Settings.searchbox = searchbox.Checked
        My.Settings.Save()

        If My.Settings.searchbox = True Then
            frmMain.textsearch.Visible = True
            frmMain.livetxt.Visible = True
        Else
            frmMain.livetxt.Visible = False
            frmMain.textsearch.Visible = False
            My.Settings.Save()
        End If
    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        searchbox.Checked = True
        statubarlook.Checked = True
        chkSupress.Checked = True
        rsscheckbox.Checked = False
    End Sub
    Private Sub linkssss_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles linkssss.CheckedChanged
        My.Settings.linksk = linkssss.Checked
        My.Settings.Save()

        If My.Settings.linksk = True Then
            frmMain.tbLinks.Visible = True
        Else
            frmMain.tbLinks.Visible = False
            My.Settings.Save()
        End If
    End Sub
#Region "Delete Browsing Data"
    Private Sub temper_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles temper.CheckedChanged
        Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 8") 'Delete Temporary Internet Files 
    End Sub

    Private Sub browserhis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browserhis.CheckedChanged
        Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 1") 'Delete History
    End Sub
    Private Sub offdata_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles offdata.CheckedChanged
        Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 32") 'Delete Passwords
    End Sub

    Private Sub former_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles former.CheckedChanged
        Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 16") 'Delete Form Data
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess  255") 'Delete All Data
    End Sub


#Region "Data private"
    Private Sub deletetemp()
        Dim ExceptionOccured = False
        Dim folder As String
        Dim tempfolder = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)
        For Each folder In Directory.GetDirectories(tempfolder)
            Try
                IO.Directory.Delete(folder, True)
            Catch ex As Exception
                ExceptionOccured = True
            End Try
        Next
        Dim tempfile As String
        For Each tempfile In IO.Directory.GetFiles(tempfolder)
            Try
                IO.File.Delete(tempfile)
            Catch ex As Exception
                ExceptionOccured = True
            End Try
        Next

    End Sub
    Private Sub deletehistory()
        Dim ExceptionOccured = False
        Dim folder As String
        Dim tempfolder = Environment.GetFolderPath(Environment.SpecialFolder.History)
        For Each folder In Directory.GetDirectories(tempfolder)
            Try
                IO.Directory.Delete(folder, True)
            Catch ex As Exception
                ExceptionOccured = True
            End Try
        Next
        Dim tempfile As String
        For Each tempfile In IO.Directory.GetFiles(tempfolder)
            Try
                IO.File.Delete(tempfile)
            Catch ex As Exception
                ExceptionOccured = True
            End Try
        Next

    End Sub
    Private Sub deletecookies()
        Dim ExceptionOccured = False
        Dim folder As String
        Dim tempfolder = Environment.GetFolderPath(Environment.SpecialFolder.Cookies)
        For Each folder In Directory.GetDirectories(tempfolder)
            Try
                IO.Directory.Delete(folder, True)
            Catch ex As Exception
                ExceptionOccured = True
            End Try
        Next
        Dim tempfile As String
        For Each tempfile In IO.Directory.GetFiles(tempfolder)
            Try
                IO.File.Delete(tempfile)
            Catch ex As Exception
                ExceptionOccured = True
            End Try
        Next

    End Sub
    Public Sub DelIECache7()

        Dim di As New DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))

        On Error GoTo err

        If di.Exists = False Then

            di.Create()

        End If
        System.IO.File.SetAttributes(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache).ToString, FileAttributes.Hidden)

        Dim Cache1 As String

        Dim Cache2() As String

        Cache2 = IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))

        For Each Cache1 In Cache2 'Get all files in Temporary internet files, ‘folder and then set their attribute to normal, and then delete them.

            IO.File.SetAttributes(Cache1, FileAttributes.Hidden)

            IO.File.Delete(Cache1)

        Next

        ' The true indicates that if subdirectories

        ' or files are in this directory, they are to be deleted as well.

        di.Delete(True)

err:    '///IGNORE ERROR///

    End Sub
    Public Sub DelIECache()

        Dim di As New DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))

        On Error GoTo err

        If di.Exists = False Then

            di.Create()

        End If
        System.IO.File.SetAttributes(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache).ToString, FileAttributes.Temporary)

        Dim Cache1 As String

        Dim Cache2() As String

        Cache2 = IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))

        For Each Cache1 In Cache2 'Get all files in Temporary internet files, ‘folder and then set their attribute to normal, and then delete them.

            IO.File.SetAttributes(Cache1, FileAttributes.Temporary)

            IO.File.Delete(Cache1)

        Next

        ' The true indicates that if subdirectories

        ' or files are in this directory, they are to be deleted as well.

        di.Delete(True)

err:    '///IGNORE ERROR///

    End Sub

    Public Sub DelIECachep6()

        Dim di As New DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))

        On Error GoTo err

        If di.Exists = False Then

            di.Create()

        End If
        System.IO.File.SetAttributes(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache).ToString, FileAttributes.Encrypted)

        Dim Cache1 As String

        Dim Cache2() As String

        Cache2 = IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))

        For Each Cache1 In Cache2 'Get all files in Temporary internet files, ‘folder and then set their attribute to normal, and then delete them.

            IO.File.SetAttributes(Cache1, FileAttributes.Encrypted)

            IO.File.Delete(Cache1)

        Next

        ' The true indicates that if subdirectories

        ' or files are in this directory, they are to be deleted as well.

        di.Delete(True)

err:    '///IGNORE ERROR///

    End Sub
    Public Sub DelIECachep3()

        Dim di As New DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))

        On Error GoTo err

        If di.Exists = False Then

            di.Create()

        End If
        System.IO.File.SetAttributes(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache).ToString, FileAttributes.Offline)

        Dim Cache1 As String

        Dim Cache2() As String

        Cache2 = IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))

        For Each Cache1 In Cache2 'Get all files in Temporary internet files, ‘folder and then set their attribute to normal, and then delete them.

            IO.File.SetAttributes(Cache1, FileAttributes.Offline)

            IO.File.Delete(Cache1)

        Next

        ' The true indicates that if subdirectories

        ' or files are in this directory, they are to be deleted as well.

        di.Delete(True)

err:    '///IGNORE ERROR///

    End Sub
    Public Sub DelIECachep4()

        Dim di As New DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Cookies))

        On Error GoTo err

        If di.Exists = False Then

            di.Create()

        End If
        System.IO.File.SetAttributes(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache).ToString, FileAttributes.Normal)

        Dim Cache1 As String

        Dim Cache2() As String

        Cache2 = IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Cookies))

        For Each Cache1 In Cache2 'Get all files in Temporary internet files, ‘folder and then set their attribute to normal, and then delete them.

            IO.File.SetAttributes(Cache1, FileAttributes.Normal)

            IO.File.Delete(Cache1)

        Next

        ' The true indicates that if subdirectories

        ' or files are in this directory, they are to be deleted as well.

        di.Delete(True)

err:    '///IGNORE ERROR///

    End Sub
    Public Sub DelIECachep5()

        Dim di As New DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))

        On Error GoTo err

        If di.Exists = False Then

            di.Create()

        End If
        System.IO.File.SetAttributes(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache).ToString, FileAttributes.Normal)

        Dim Cache1 As String

        Dim Cache2() As String

        Cache2 = IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))

        For Each Cache1 In Cache2 'Get all files in Temporary internet files, ‘folder and then set their attribute to normal, and then delete them.

            IO.File.SetAttributes(Cache1, FileAttributes.Normal)

            IO.File.Delete(Cache1)

        Next

        ' The true indicates that if subdirectories

        ' or files are in this directory, they are to be deleted as well.

        di.Delete(True)

err:    '///IGNORE ERROR///

    End Sub
    Public Sub DelIECachep2()

        Dim di As New DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.History))

        On Error GoTo err

        If di.Exists = False Then

            di.Create()

        End If
        System.IO.File.SetAttributes(Environment.GetFolderPath(Environment.SpecialFolder.History).ToString, FileAttributes.Normal)

        Dim Cache1 As String

        Dim Cache2() As String

        Cache2 = IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.History))

        For Each Cache1 In Cache2 'Get all files in Temporary internet files, ‘folder and then set their attribute to normal, and then delete them.

            IO.File.SetAttributes(Cache1, FileAttributes.Normal)

            IO.File.Delete(Cache1)

        Next

        ' The true indicates that if subdirectories

        ' or files are in this directory, they are to be deleted as well.

        di.Delete(True)

err:    '///IGNORE ERROR///
    End Sub
    Private Sub histcookiedel()
        Dim H As String
        For Each H In Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.History))
            File.Delete(H)
        Next
        Dim II As String
        For Each II In Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache))
            File.Delete(II)
        Next
        Dim s As String
        For Each s In Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Cookies))
            If s.EndsWith(".txt") Then
                File.Delete(s)
            End If
        Next
        frmCookieViewer.tvCookies.Nodes.Clear()
    End Sub
#End Region
#End Region

#Region "General"
    Private Sub dailysites_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dailysites.Click
        TextBox2.Text = "Jawoco Startpage"
        My.Settings.gcp = TextBox2.Text
        My.Settings.UseStartPage = True
        My.Settings.generalbank = False
        My.Settings.Save()
    End Sub

    Private Sub blankpager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles blankpager.Click
        TextBox2.Text = "about:blank"
        My.Settings.gcp = TextBox2.Text
        My.Settings.generalbank = True
        My.Settings.UseStartPage = False
        My.Settings.Save()
    End Sub
    Private Sub LoadCurrenthomepage()
        TextBox2.Text = My.Settings.gcp
    End Sub
    Private Sub currentpager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles currentpager.Click
        TextBox2.Text = frmMain.cboURL.Text
        My.Settings.personal = True
        My.Settings.gcp = TextBox2.Text
        My.Settings.UseStartPage = False
        My.Settings.generalbank = False
        My.Settings.Save()
    End Sub


    Private Sub removehomes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removehomes.Click
        My.Settings.gcp = TextBox2.Text
        My.Settings.personal = True
        My.Settings.UseStartPage = False
        My.Settings.generalbank = False
        My.Settings.Save()
    End Sub
    Private Sub textbox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            My.Settings.gcp = TextBox2.Text
            My.Settings.personal = True
            My.Settings.UseStartPage = False
            My.Settings.generalbank = False
            My.Settings.Save()
        End If
    End Sub

#End Region
#Region "Tabpage"
    Private Sub LoadTabcurrentpage()
        TextBox3.Text = My.Settings.tcp
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        TextBox3.Text = "about:blank"
        My.Settings.tcp = TextBox3.Text
        My.Settings.tabblank = True
        My.Settings.tabown = False
        My.Settings.Usetopsitestab = False
        My.Settings.Save()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        TextBox3.Text = "Jawoco Startpage"
        My.Settings.tcp = TextBox3.Text
        My.Settings.tabblank = False
        My.Settings.tabown = False
        My.Settings.Usetopsitestab = True
        My.Settings.Save()
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox3.Text = "IE Homepage"
        My.Settings.tcp = TextBox3.Text
        My.Settings.tabblank = False
        My.Settings.tabown = False
        My.Settings.Usetopsitestab = False
        My.Settings.Save()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox3.Text = frmMain.cboURL.Text
        My.Settings.tcp = TextBox3.Text
        My.Settings.tabblank = False
        My.Settings.tabown = True
        My.Settings.Usetopsitestab = False
        My.Settings.Save()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Settings.tcp = TextBox3.Text
        My.Settings.tabblank = False
        My.Settings.tabown = True
        My.Settings.Usetopsitestab = False
        My.Settings.Save()
    End Sub
    Private Sub textbox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            My.Settings.tcp = TextBox3.Text
            My.Settings.tabblank = False
            My.Settings.tabown = True
            My.Settings.Usetopsitestab = False
            My.Settings.Save()
        End If
    End Sub

    Private Sub Loadstatusdailysite()
        TextBox2.Text = My.Settings.gcp
        TextBox3.Text = My.Settings.tcp
    End Sub
#End Region

    Private Sub cookiesw_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cookiesw.CheckedChanged
        Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2") 'Delete Cookies
    End Sub
    Private Sub inp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inp.CheckedChanged
        My.Settings.privateon = inp.Checked
        My.Settings.Save()
    End Sub

    Private Sub btnAddPhish_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPhish.Click
        If txtPhishing.Text = "" Then
            'Do nothing
        Else
            My.Settings.PhishingSites.Add(AppManager.FixURL(txtPhishing.Text))
            LoadPhishingSites()
            txtPhishing.Text = String.Empty
        End If
    End Sub

    Private Sub btnRemovePhish_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemovePhish.Click
        If lbPhishing.SelectedIndices.Count > 0 Then
            My.Settings.PhishingSites.Remove(lbPhishing.SelectedItem)
            LoadPhishingSites()
        End If
    End Sub

    Private Sub btnRemoveAllPhish_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllPhish.Click
        Dim s As String
        For Each s In My.Settings.PhishingSites
            My.Settings.PhishingSites.Remove(s)
        Next
        LoadPhishingSites()
    End Sub


    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
     AppManager.CurrentBrowser.ShowPrivacyReport()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Process.Start("rundll32.exe", "msrating.dll,RatingSetupUI") 'Display Content Advisor
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim ofrm As New frmBrowser
        AppManager.AddTab(ofrm, "http://www.macromedia.com/support/documentation/en/flashplayer/help/settings_manager07.html")
        Me.Close()
    End Sub

    Private Sub lockactivate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lockactivate.CheckedChanged
        My.Settings.lockup = lockactivate.Checked
        My.Settings.Save()
        If My.Settings.lockup = True Then
            passlock.Enabled = True
            lockitbtn.Enabled = True
            frmMain.DBD.Enabled = False
            frmMain.ResetSecurityCheck.Enabled = True
        Else
            passlock.Enabled = False
            lockitbtn.Enabled = False
            frmMain.DBD.Enabled = True
            frmMain.ResetSecurityCheck.Enabled = False
        End If

    End Sub

    Private Sub lockitbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lockitbtn.Click
        If passlock.Text = Nothing Then
            MsgBox("Please enter Password to use Lockup feature. Enable it again and enter a Password.", MsgBoxStyle.Exclamation)
            lockactivate.Checked = False
        Else
            My.Settings.Passwordbrowser = passlock.Text
            My.Settings.Save()
            MsgBox("You have successfully secured your Xtravo browser.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub passlock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles passlock.KeyDown
        If e.KeyCode = Keys.Enter And passlock.Text = Nothing Then
            MsgBox("Please enter Password to use Lockup feature. Enable it again and enter a Password.", MsgBoxStyle.Exclamation)
            lockactivate.Checked = False
        Else
            If e.KeyCode = Keys.Enter Then
                My.Settings.Passwordbrowser = passlock.Text
                My.Settings.Save()
                MsgBox("You have successfully secured your Xtravo browser.", MsgBoxStyle.Information)
            End If
        End If
    End Sub
End Class