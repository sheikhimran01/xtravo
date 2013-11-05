Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Net
Imports Microsoft
Imports Microsoft.Win32.Registry


Public Class frmMain

#Region " API "
    'This is an API call to get the icon of a favorite.
    Private Structure SHFILEINFO
        Public hIcon As IntPtr            ' : icon
        Public iIcon As Integer           ' : icondex
        Public dwAttributes As Integer    ' : SFGAO_ flags
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String
    End Structure

    Private Declare Auto Function SHGetFileInfo Lib "shell32.dll" _
            (ByVal pszPath As String, _
             ByVal dwFileAttributes As Integer, _
             ByRef psfi As SHFILEINFO, _
             ByVal cbFileInfo As Integer, _
             ByVal uFlags As Integer) As IntPtr

    Private Const SHGFI_ICON = &H100
    Private Const SHGFI_SMALLICON = &H1
    Private Const SHGFI_LARGEICON = &H0    ' Large icon
    Private nIndex
#End Region
    Private CurSearchURL As String
    Private CurSearchTitle
    Private fitm As ToolStripMenuItem

#Region " FORM "

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Opacity = "0"
        Me.ShowInTaskbar = False
        If Not IsNothing(AppManager.CurrentBrowser) Then
            AppManager.CurrentBrowser.Dispose()
        End If
        frmSettings.Close()
        Dim oControl As Control
        For Each oControl In Me.Controls
            oControl.Dispose()
        Next
        If My.Settings.privateon = True Then
            Me.Opacity = "0"
            Me.ShowInTaskbar = False
            deletehistory()
            deletecookies()
            deletehistory()
            deletetemp()
            histcookiedel()
            DelIECache()
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim web As New WebClient
            Dim update As String = web.DownloadString("http://xtravo.jawoco.com/support/update/xtravo.txt")
            Dim productversion As String = Application.ProductVersion
            Dim sourceurl = "http://xtravo.jawoco.com/support/update/xtravo_update.exe"
            Dim filedir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/" & "xtravo_update.exe"
            If update.CompareTo(productversion) Then
                Try
                    If update > productversion Then
                        web.DownloadFileAsync(New Uri(sourceurl), (filedir))
                        frmpleasewait.Show()
                        Timer1.Start()
                    Else
                        If update < productversion Or update = productversion Then
                            Startup()
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Failed" & ErrorToString(), MsgBoxStyle.Critical)
                End Try
            Else
                Startup()
            End If
        Catch ex As Exception
            Startupoffline()
            AppManager.CurrentBrowser.Navigate("about:blank")
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            frmpleasewait.Close()
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/" & "xtravo_update.exe")
            Timer1.Stop()
            Me.Close()
        Catch ex As Exception
            frmpleasewait.Close()
            Me.Close()
        End Try
    End Sub
    Private Sub LoadURLnSearchCtrl()
        cboURL.TextBox.ContextMenuStrip = UrlboxRCtrl
        textsearch.TextBox.ContextMenuStrip = SearchboxRCtrl
    End Sub

    Private Sub Startupoffline()
        Lockupsetup()
        loadsearchstart()
        Addressn1()
        AppManager.MainForm = Me
        LoadFavorites()
        Dim ofrm As New frmBrowser
        Dim oTab As New Xtravo.TabPage(ofrm)
        Me.tc1.TabPages.Add(oTab.Form)
        'Set the 1st tab to non closeable, just like ie 7
        tc1.TabPages(0).CloseButtonVisible = True
        If My.Settings.UseStartPage = True Then
            ofrm.wb.Navigate("http://jawo.co/")
        Else
            If My.Settings.generalbank = True Then
                ofrm.wb.Navigate("about:blank")
            Else
                If My.Settings.personal = True Then
                    ofrm.wb.Navigate(My.Settings.gcp)
                End If
            End If
        End If
        btnBack.Visible = False And btnForward.Visible = True
        LoadURLnSearchCtrl()
        ShowInTaskbar = True
        Me.Opacity = "100"
    End Sub
    Private Sub Startup()
        Lockupsetup()
        loadsearchstart()
        Addressn1()
        AppManager.MainForm = Me
        LoadFavorites()
        Dim ofrm As New frmBrowser
        Dim oTab As New Xtravo.TabPage(ofrm)
        Me.tc1.TabPages.Add(oTab.Form)
        'Set the 1st tab to non closeable, just like ie 7
        tc1.TabPages(0).CloseButtonVisible = True
        If My.Settings.UseStartPage = True Then
            ofrm.wb.Navigate("http://jawo.co")
        Else
            If My.Settings.generalbank = True Then
                ofrm.wb.Navigate("about:blank")
            Else
                If My.Settings.personal = True Then
                    ofrm.wb.Navigate(My.Settings.gcp)
                End If
            End If
        End If
        LoadURLnSearchCtrl()
        ShowInTaskbar = True
        Me.Opacity = "100"
        If My.Settings.guidetour = True Then
            frmWhatsnew.Show()
        End If
        If My.Settings.welcomescreen = True Then
            frmwelcome.Show()
        End If

    End Sub
    Private Sub Lockupsetup()
        If My.Settings.lockup = True Then
            ResetSecurityCheck.Enabled = True
            DBD.Enabled = False
        Else
            ResetSecurityCheck.Enabled = False
            DBD.Enabled = True
        End If
    End Sub
#End Region


#Region " Favorites Loading Code "
    'In most custom browser implementations you will probably want to 
    'have your own favorite storage information, storing fav icons in your own cache
    'or in a database. You may also want to implement a custom import / export wizard. 
    'Since favorites are just text files simular to .ini files, for this example
    'we'll just load them the quickest way by loading the path and during the 
    'onclick in the handler open the file and direct the browser to the url. 

    Private Sub LoadFavorites()
        Dim Path As String = Environment.GetFolderPath(Environment.SpecialFolder.Favorites)
        tvFavs.BeginUpdate()
        ' Clear the Favorites list
        tvFavs.Nodes.Clear()
        ' Load favorites from all sub-directories
        LoadFolders(New System.IO.DirectoryInfo(Path), Nothing, Nothing)
        ' Load the favorites from the favorites folder
        LoadPath(Path, Nothing, Nothing)
        'Now lets load the links toobar
        LoadLinkFolders(New System.IO.DirectoryInfo(Path & "\Links\"), Nothing)
        LoadLinksPath(Path & "\Links\", Nothing)
        ' Repaint the TreeView
        tvFavs.EndUpdate()
    End Sub

    Private Sub LoadFolders(ByVal dirInfo As System.IO.DirectoryInfo, _
    ByVal currentNode As TreeNode, ByVal oitm As ToolStripMenuItem)

        Dim objNode As System.Windows.Forms.TreeNode
        Dim fitm As ToolStripMenuItem

        Dim objDir As System.IO.DirectoryInfo

        For Each objDir In dirInfo.GetDirectories()
            If currentNode Is Nothing Then
                objNode = tvFavs.Nodes.Add(objDir.Name, objDir.Name, 0, 1)
                objNode.Tag = String.Empty
                fitm = mnuFavs.DropDownItems.Add(objDir.Name)
                fitm.Image = My.Resources.folder3
            Else
                objNode = currentNode.Nodes.Add(objDir.Name, objDir.Name, 0, 1)
                objNode.Tag = String.Empty
                fitm = oitm.DropDownItems.Add(objDir.Name)
                fitm.Image = My.Resources.folder3
            End If
            ' Set the full path of the folder
            objNode.Tag = objDir.FullName
            fitm.Tag = objDir.FullName

            If objDir.GetDirectories().Length = 0 Then
                ' This node has no further sub-directories
                LoadPath(objDir.FullName, objNode, fitm)
            Else
                ' Add this folder to the current node and continue
                ' processing sub-directories.
                LoadFolders(objDir, objNode, fitm)
                LoadPath(objDir.FullName, objNode, fitm)
            End If
        Next objDir
    End Sub

    Private Sub LoadPath(ByVal strPath As String, _
    ByVal currentNode As TreeNode, ByVal mitm As ToolStripMenuItem)

        Dim oNode As TreeNode
        Dim oitm As ToolStripMenuItem
        Dim name As String
        Dim objDir As New System.IO.DirectoryInfo(strPath)
        Dim SmallIco As IntPtr
        Dim shinfo As SHFILEINFO
        shinfo = New SHFILEINFO
        ' Process each File in the path with a ".url" extension
        Dim objFile As System.IO.FileInfo
        For Each objFile In objDir.GetFiles("*.url")
            oNode = New TreeNode
            oitm = New ToolStripMenuItem
            '///////////////////////////////////////////////////
            'get the icon.
            'Note:
            'Here you could call the appmanager code to get the actual 
            'favorite icon from the site (will slow things down)...
            'If you decide to implement your own custom favorites
            'grab the fav icon and store it in an access db, xml file etc
            'either by path or ole object and save it locally.
            shinfo.szDisplayName = New String(Chr(0), 260)
            shinfo.szTypeName = New String(Chr(0), 80)
            'Get the small icon.
            SmallIco = SHGetFileInfo(objFile.FullName, 0, shinfo, _
                        Marshal.SizeOf(shinfo), _
                        SHGFI_ICON Or SHGFI_SMALLICON)
            '////////////////////////////////////////////////////
            ' Set the Text property to the "Friendly" name
            name = Path.GetFileNameWithoutExtension(objFile.Name)
            Dim oIcon As Icon = System.Drawing.Icon.FromHandle(shinfo.hIcon)
            tvFavs.ImageList.Images.Add(name, oIcon.ToBitmap)
            oNode.Text = name
            oNode.Tag = objFile.FullName
            oNode.ImageKey = name
            oNode.SelectedImageKey = name
            If currentNode Is Nothing Then
                tvFavs.Nodes.Add(oNode)
                oitm.Text = name
                oitm.Image = oIcon.ToBitmap
                oitm.Tag = objFile.FullName
                mnuFavs.DropDownItems.Add(oitm)
                AddHandler oitm.Click, AddressOf HandleFav
                'AddHandler oitm.MouseDown, AddressOf HandleFavMouseDown
            Else
                currentNode.Nodes.Add(oNode)
                oitm.Text = name
                oitm.Image = oIcon.ToBitmap
                oitm.Tag = objFile.FullName
                mitm.DropDownItems.Add(oitm)
                AddHandler oitm.Click, AddressOf HandleFav
                'AddHandler oitm.MouseDown, AddressOf HandleFavMouseDown
            End If
        Next objFile
    End Sub


    Private Sub LoadLinkFolders(ByVal dirInfo As System.IO.DirectoryInfo, _
    ByVal oitm As ToolStripMenuItem)

        Dim fitm As ToolStripMenuItem
        Dim objDir As System.IO.DirectoryInfo

        For Each objDir In dirInfo.GetDirectories()
            fitm = New ToolStripMenuItem
            fitm.Text = objDir.Name
            fitm.Tag = ""
            fitm.Image = My.Resources.folder3
            If oitm Is Nothing Then
                tbLinks.Items.Add(fitm)
            Else
                fitm.Image = My.Resources.folder3
                oitm.DropDownItems.Add(fitm)
            End If

            If objDir.GetDirectories().Length = 0 Then
                ' This node has no further sub-directories
                LoadLinksPath(objDir.FullName, fitm)
            Else
                ' Add this folder to the current node and continue
                ' processing sub-directories.
                LoadLinkFolders(objDir, fitm)
                LoadLinksPath(objDir.FullName, fitm)
            End If
        Next objDir
    End Sub

    Private Sub LoadLinksPath(ByVal strPath As String, _
    ByVal mitm As ToolStripMenuItem)

        Dim oitm As ToolStripMenuItem
        Dim name As String
        Dim objDir As New System.IO.DirectoryInfo(strPath)
        Dim SmallIco As IntPtr
        Dim shinfo As SHFILEINFO
        shinfo = New SHFILEINFO
        ' Process each URL in the path (URL files end with a ".url" extension
        Dim objFile As System.IO.FileInfo
        For Each objFile In objDir.GetFiles("*.url")
            oitm = New ToolStripMenuItem
            'get the icon.
            shinfo.szDisplayName = New String(Chr(0), 260)
            shinfo.szTypeName = New String(Chr(0), 80)
            'Get the small icon.
            SmallIco = SHGetFileInfo(objFile.FullName, 0, shinfo, _
                        Marshal.SizeOf(shinfo), _
                        SHGFI_ICON Or SHGFI_SMALLICON)
            ' Set the Text property to the "Friendly" name
            name = Path.GetFileNameWithoutExtension(objFile.Name)
            Dim oIcon As Icon = System.Drawing.Icon.FromHandle(shinfo.hIcon)

            If mitm Is Nothing Then
                oitm.Text = name
                oitm.Image = oIcon.ToBitmap
                oitm.Tag = objFile.FullName
                tbLinks.Items.Add(oitm)
                'AddHandler oitm.Click, AddressOf HandleFav
                AddHandler oitm.MouseDown, AddressOf HandleFavMouseDown
            Else
                oitm.Text = name
                oitm.Image = oIcon.ToBitmap
                oitm.Tag = objFile.FullName
                mitm.DropDownItems.Add(oitm)
                'AddHandler oitm.Click, AddressOf HandleFav
                AddHandler oitm.MouseDown, AddressOf HandleFavMouseDown
            End If
        Next objFile
    End Sub

#End Region

#Region " Favorite Event Handlers "

    Private Sub HandleFavMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left
                Dim fi As ToolStripMenuItem = sender
                Dim obj As New tlxIni(fi.Tag)
                AppManager.CurrentBrowser.Navigate(obj.GetString("INTERNETSHORTCUT", "URL", String.Empty))
            Case Windows.Forms.MouseButtons.Right
                cmFavs.Show(Cursor.Position.X, Cursor.Position.Y)
                fitm = sender
        End Select
    End Sub

    Private Sub HandleFav(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim fi As ToolStripMenuItem = sender
        Dim obj As New tlxIni(fi.Tag)
        AppManager.CurrentBrowser.Navigate(obj.GetString("INTERNETSHORTCUT", "URL", String.Empty))
    End Sub

    Private Sub tvFavs_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvFavs.NodeMouseClick
        If e.Node.Nodes.Count > 0 Then
            e.Node.Expand()
        Else
            If e.Node.ImageIndex = 0 Then
                Exit Sub
            Else
                Dim obj As New tlxIni(e.Node.Tag)
                AppManager.CurrentBrowser.Navigate(obj.GetString("INTERNETSHORTCUT", "URL", String.Empty))
                gbFavs.Visible = False
            End If
        End If
    End Sub

#End Region


#Region " Menus and toolbars "

    Private Sub btnForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForward.Click
        If AppManager.CurrentBrowser.CanGoForward Then
            AppManager.CurrentBrowser.GoForward()
        End If
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        If AppManager.CurrentBrowser.CanGoBack Then
            AppManager.CurrentBrowser.GoBack()
        End If
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        AppManager.CurrentBrowser.Stop()
    End Sub
    Private Sub cboURL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboURL.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBack.Visible = True
            If cboURL.Text <> "" And btnBack.Visible = True Then
                AppManager.CurrentBrowser.Navigate(cboURL.Text)
            End If
        End If
        If My.Settings.addressn1 = True Then
            If e.KeyCode = Keys.Enter Then
                If cboURL.Text <> "" Then
                    AppManager.CurrentBrowser.Navigate("http://google.com/search?btnI=1&q=" & cboURL.Text)
                End If
            End If
        End If
    End Sub
    Private Sub cboURL_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboURL.KeyDown

        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.Enter Then
            cboURL.Text = "http://www." & cboURL.Text & ".com"
            AppManager.CurrentBrowser.Navigate(cboURL.Text)
        End If

        If e.Modifiers = Keys.Shift AndAlso e.KeyCode = Keys.Enter Then
            cboURL.Text = "http://www." & cboURL.Text & ".net"
            AppManager.CurrentBrowser.Navigate(cboURL.Text)
        End If

        If e.Modifiers = Keys.Alt AndAlso e.KeyCode = Keys.Enter Then
            cboURL.Text = cboURL.Text
            Dim ofrm As New frmBrowser
            Dim oTab As New Xtravo.TabPage(ofrm)
            ofrm.wb.Navigate2(cboURL.Text)
            tc1.TabPages.Add(oTab.Form)
        End If
    End Sub

    Private Sub btnForward_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        AppManager.Navigate(e.ClickedItem.Tag)
    End Sub

    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AppManager.CurrentBrowser.GoHome()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AppManager.CurrentBrowser.Print()
    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AppManager.CurrentBrowser.ShowPrintPreviewDialog()
    End Sub

    Private Sub btnPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AppManager.CurrentBrowser.ShowPageSetupDialog()
    End Sub
    Private Sub AddToFavoritesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AppManager.CurrentBrowser.AddToFavorites(AppManager.CurrentBrowser.Url.ToString, AppManager.CurrentBrowser.DocumentTitle)
    End Sub
    Private Sub mnuSecInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ofrm As New frmSecInfo
        ofrm.ShowDialog(Me)
    End Sub
    Private Sub btnDocFav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocFav.Click
        Select Case btnDocFav.Tag
            Case 1
                gbFavs.Dock = DockStyle.Left
                gbFavs.SendToBack()
                btnDocFav.Image = My.Resources.Delete16
                btnDocFav.Tag = 2
            Case 2
                gbFavs.Dock = DockStyle.None
                gbFavs.BringToFront()
                gbFavs.Visible = False
                btnDocFav.Tag = 1
        End Select
    End Sub

    Private Sub mnuSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ofrm As New frmSettings
        ofrm.ShowDialog(Me)
    End Sub

    Private Sub btnRSS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ofrm As New frmRSS
        tc1.TabPages.Add(ofrm)
    End Sub

    Private Sub mnuPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AppManager.CurrentBrowser.ShowPageSetupDialog()
    End Sub

    Private Sub InternetOptionsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AppManager.CurrentBrowser.ShowInternetOptions()
    End Sub

    Private Sub PropertiesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AppManager.CurrentBrowser.ShowPropertiesDialog()
    End Sub

#End Region

#Region " Tab Control "
    Private Sub tc1_SelectedTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tc1.SelectedTabChanged
        On Error Resume Next
        Dim cForm As Form = tc1.SelectedForm
        If TypeOf cForm Is frmBrowser Then
            Dim ofrm As frmBrowser = cForm
            Me.Text = cForm.Text & " - " & My.Resources.AppName
            cboURL.Text = ofrm.wb.Url.ToString
            AppManager.CurrentBrowser = ofrm.wb
            btnBack.Enabled = AppManager.CurrentBrowser.CanGoBack
            btnForward.Enabled = AppManager.CurrentBrowser.CanGoForward
            If ofrm.NumFeeds = 0 Then
                mnuFeeds.Enabled = False
            Else
                mnuFeeds.Enabled = True
            End If
        Else
            'Nothing to do
        End If

    End Sub

#Region " Legacy Code "
    'The author of our tab control was kind enough to send an update on this control
    'So this code is not longer needed.
    'Private Sub tc1_OnSelectedTabChanged(ByVal e As System.Windows.Forms.Form) Handles tc1.OnSelectedTabChanged
    '    SetBrowser(e)
    'End Sub

    'Private Sub SetBrowser(ByVal cForm As Form)
    '    On Error Resume Next
    '    If TypeOf cForm Is frmBrowser Then
    '        Dim ofrm As frmBrowser = cForm
    '        Me.Text = cForm.Text & " - " & My.Resources.AppName
    '        cboURL.Text = ofrm.wb.Url.ToString
    '        AppManager.CurrentBrowser = ofrm.wb
    '        btnBack.Enabled = AppManager.CurrentBrowser.CanGoBack
    '        btnForward.Enabled = AppManager.CurrentBrowser.CanGoForward
    '    Else

    '    End If
    'End Sub
#End Region
#End Region

    Private Sub mnuFeeds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ofrm As New frmDetectRSS
        ofrm.ShowDialog(Me)
    End Sub

    Private Sub Tab_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab.Click
        If My.Settings.Usetopsitestab = True Then
            Dim ofrm As New frmBrowser
            Dim oTab As New Xtravo.TabPage(ofrm)
            tc1.TabPages.Add(oTab.Form)
            ofrm.wb.Navigate("http://jawoco.com/")
        Else
            If My.Settings.tabblank = True Then
                Dim ofrm As New frmBrowser
                Dim oTab As New Xtravo.TabPage(ofrm)
                tc1.TabPages.Add(oTab.Form)
                ofrm.wb.Navigate("about:blank")
            Else
                If My.Settings.tabcurrent = True Then
                    Dim ofrm As New frmBrowser
                    Dim oTab As New Xtravo.TabPage(ofrm)
                    tc1.TabPages.Add(oTab.Form)
                    ofrm.wb.Navigate(My.Settings.tcp)
                Else
                    If My.Settings.tabown = True Then
                        Dim ofrm As New frmBrowser
                        Dim oTab As New Xtravo.TabPage(ofrm)
                        tc1.TabPages.Add(oTab.Form)
                        ofrm.wb.Navigate(My.Settings.tcp)
                    Else
                        Dim ofrm As New frmBrowser
                        Dim oTab As New Xtravo.TabPage(ofrm)
                        'ofrm.MyTabPage = oTab
                        AppManager.AddTab(oTab)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub RSSViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ofrm As New frmRSS
        Me.tc1.TabPages.Add(ofrm)
    End Sub

    Private Sub InternetOptionsToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AppManager.CurrentBrowser.ShowInternetOptions()
    End Sub
    Private Sub NewTabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If My.Settings.Usetopsitestab = True Then
            Dim ofrm As New frmBrowser
            Dim oTab As New Xtravo.TabPage(ofrm)
            tc1.TabPages.Add(oTab.Form)
            ofrm.wb.Navigate("http://jawoco.com/")

        Else
            If My.Settings.tabblank = True Then
                Dim ofrm As New frmBrowser
                Dim oTab As New Xtravo.TabPage(ofrm)
                tc1.TabPages.Add(oTab.Form)
                ofrm.wb.Navigate("about:blank")
            Else
                If My.Settings.tabcurrent = True Then
                    Dim ofrm As New frmBrowser
                    Dim oTab As New Xtravo.TabPage(ofrm)
                    tc1.TabPages.Add(oTab.Form)
                    ofrm.wb.Navigate(My.Settings.tcp)
                Else
                    If My.Settings.tabown = True Then
                        Dim ofrm As New frmBrowser
                        Dim oTab As New Xtravo.TabPage(ofrm)
                        tc1.TabPages.Add(oTab.Form)
                        ofrm.wb.Navigate(My.Settings.tcp)
                    Else
                        Dim ofrm As New frmBrowser
                        Dim oTab As New Xtravo.TabPage(ofrm)
                        'ofrm.MyTabPage = oTab
                        AppManager.AddTab(oTab)
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub RSSFeedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ofrm As New frmRSS
        Me.tc1.TabPages.Add(ofrm)
    End Sub

    Private Sub CloseTabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tc1.TabPages.SelectedTab.Form.Close()
    End Sub

    Private Sub ContactUsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AppManager.CurrentBrowser.Navigate2("http://www.jawoco.com/aboutus/contact.html")
    End Sub

    Private Sub InternetExplorerOptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AppManager.CurrentBrowser.ShowInternetOptions()
    End Sub

    Private Sub XtravoExplorerSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ofrm As New frmSettings
        ofrm.ShowDialog(Me)
    End Sub

    Private Sub ViewHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewHIstoryToolStripMenuItem.Click
        Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.History))
    End Sub

    Private Sub CookieViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CookieViewerToolStripMenuItem.Click
        Dim ofrm As New frmCookieViewer
        tc1.TabPages.Add(ofrm)
        gbFavs.Visible = False
    End Sub

    Private Sub RssFeedToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ofrm As New frmRSS
        Me.tc1.TabPages.Add(ofrm)
    End Sub

    Private Sub CheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ofrm As New frmDetectRSS
        ofrm.ShowDialog(Me)
    End Sub

    Private Sub printshort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AppManager.CurrentBrowser.ShowPrintDialog()
    End Sub
    Private Sub refresh3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles refresh3.Click
        AppManager.CurrentBrowser.Refresh()
    End Sub
    Private Sub NewTabToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewTab.Click
        If My.Settings.Usetopsitestab = True Then
            Dim ofrm As New frmBrowser
            Dim oTab As New Xtravo.TabPage(ofrm)
            tc1.TabPages.Add(oTab.Form)
            ofrm.wb.Navigate("http://jawoco.com/")
        Else
            If My.Settings.tabblank = True Then
                Dim ofrm As New frmBrowser
                Dim oTab As New Xtravo.TabPage(ofrm)
                tc1.TabPages.Add(oTab.Form)
                ofrm.wb.Navigate("about:blank")
            Else
                If My.Settings.tabcurrent = True Then
                    Dim ofrm As New frmBrowser
                    Dim oTab As New Xtravo.TabPage(ofrm)
                    tc1.TabPages.Add(oTab.Form)
                    ofrm.wb.Navigate(My.Settings.tcp)
                Else

                    If My.Settings.tabown = True Then
                        Dim ofrm As New frmBrowser
                        Dim oTab As New Xtravo.TabPage(ofrm)
                        tc1.TabPages.Add(oTab.Form)
                        ofrm.wb.Navigate(My.Settings.tcp)
                    Else
                        Dim ofrm As New frmBrowser
                        Dim oTab As New Xtravo.TabPage(ofrm)
                        'ofrm.MyTabPage = oTab
                        AppManager.AddTab(oTab)
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub OpenAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenAs.Click
        AppManager.CurrentBrowser.ShowOpen()
    End Sub

    Private Sub SavaAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavaAstool.Click
        AppManager.CurrentBrowser.ShowSaveAsDialog()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Print.Click
        AppManager.CurrentBrowser.ShowPrintDialog()
    End Sub
    Private Sub AboutUsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutUs.Click
        Dim ofrm As New frmAbout
        ofrm.ShowDialog(Me)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub textsearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles textsearch.KeyDown
        If My.Settings.googles = True Then
            If e.KeyCode = Keys.Enter Then
                AppManager.CurrentBrowser.Navigate2("http://www.google.com/search?hl=en&q=" & textsearch.Text)
            End If
        End If
        If My.Settings.bing = True Then
            If e.KeyCode = Keys.Enter Then
                AppManager.CurrentBrowser.Navigate2("http://www.bing.com/search?q=" & textsearch.Text)
            End If
        End If
        If My.Settings.yahoo = True Then
            If e.KeyCode = Keys.Enter Then
                AppManager.CurrentBrowser.Navigate2("http://search.yahoo.com/search?p=" & textsearch.Text)
            End If
        End If
        If My.Settings.yandex = True Then
            If e.KeyCode = Keys.Enter Then
                AppManager.CurrentBrowser.Navigate2("http://yandex.ru/yandsearch?rpt=rad&text=" & textsearch.Text)
            End If
        End If
        If My.Settings.asks = True Then
            If e.KeyCode = Keys.Enter Then
                AppManager.CurrentBrowser.Navigate2("http://www.ask.com/web?q=" & textsearch.Text)
            End If
        End If
        If My.Settings.baidu = True Then
            If e.KeyCode = Keys.Enter Then
                AppManager.CurrentBrowser.Navigate2("http://www.baidu.com/s?wd=" & textsearch.Text)
            End If
        End If
        If My.Settings.blekko = True Then
            If e.KeyCode = Keys.Enter Then
                AppManager.CurrentBrowser.Navigate2("http://blekko.com/ws/" & textsearch.Text)
            End If
        End If
        If My.Settings.xsearch = True Then
            If e.KeyCode = Keys.Enter Then
                AppManager.CurrentBrowser.Navigate2("http://search.jawoco.com/index.php?page=search/web/" & textsearch.Text)
            End If
        End If
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.Enter Then
            AppManager.CurrentBrowser.Navigate2("http://en.wikipedia.org/wiki/" & textsearch.Text)
        End If
    End Sub
    Private Sub textsearch_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textsearch.Click
        textsearch.Text = String.Empty
    End Sub
    Private Sub ViewHIstoryToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If My.Settings.lockup = True Then
            frmpasshis.Show()
        Else
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.History))
        End If
    End Sub

    Private Sub CookieViewerToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If My.Settings.lockup = True Then
            frmpasscookie.Show()
        Else
            Dim ofrm As New frmCookieViewer
            tc1.TabPages.Add(ofrm)
            gbFavs.Visible = False
        End If
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Options.Click
        If My.Settings.lockup = True Then
            frmpassoption.Show()
        Else
            Dim ofrm As New frmSettings
            ofrm.ShowDialog(Me)
        End If
    End Sub
    Private Sub livetxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles livetxt.Click
        If My.Settings.lockup = True Then
            frmpasssearch.Show()
        Else
            frmSettings.Show()
            frmSettings.TabControl1.SelectedTab = frmSettings.TabControl1.TabPages(3)
        End If

    End Sub
    Private Sub DBD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBD.Click
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


    Private Sub Addressn1()
        frmSettings.addressn1checkbox.Checked = My.Settings.addressn1
    End Sub
    Private Sub loadsearchstart()
        frmSettings.Livesearch.Checked = My.Settings.bing
        frmSettings.googlesearch.Checked = My.Settings.googles
        frmSettings.yahoosearch.Checked = My.Settings.yahoo
        frmSettings.baidusearch.Checked = My.Settings.baidu
        frmSettings.yandex.Checked = My.Settings.yandex
        frmSettings.asksearch.Checked = My.Settings.asks
        frmSettings.blekko.Checked = My.Settings.blekko
        frmSettings.xsearch.Checked = My.Settings.xsearch
        Customizeloads()
        Loadstatusdailysite()
    End Sub
    Private Sub addfavsbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addfavsbutton.Click
        AppManager.CurrentBrowser.AddToFavorites(AppManager.CurrentBrowser.Url.ToString, AppManager.CurrentBrowser.DocumentTitle)
        mnuFavs.DropDownItems.Clear()
        mnuFavs.DropDownItems.GetEnumerator()
        tbLinks.Items.Clear()
        LoadFavorites()
        tbLinks.Refresh()
    End Sub
    Private Sub AddToFavorites_Click_1(sender As System.Object, e As System.EventArgs) Handles AddToFavorites.Click
        AppManager.CurrentBrowser.AddToFavorites(AppManager.CurrentBrowser.Url.ToString, AppManager.CurrentBrowser.DocumentTitle)
        mnuFavs.DropDownItems.Clear()
        mnuFavs.DropDownItems.GetEnumerator()
        tbLinks.Items.Clear()
        LoadFavorites()
        tbLinks.Refresh()
    End Sub

    Private Sub CustomizeSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomizeSettingsToolStripMenuItem.Click
        frmSettings.Show()
        frmSettings.TabControl1.SelectedTab = frmSettings.TabControl1.TabPages(1)
    End Sub
#Region "Shortcuts"
    Private Sub StopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopToolStripMenuItem.Click
        AppManager.CurrentBrowser.Stop()
    End Sub

    Private Sub FavToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FavToolStripMenuItem.Click
        AppManager.CurrentBrowser.AddToFavorites(AppManager.CurrentBrowser.Url.ToString, AppManager.CurrentBrowser.DocumentTitle)
        mnuFavs.DropDownItems.Clear()
        mnuFavs.DropDownItems.GetEnumerator()
        tbLinks.Items.Clear()
        LoadFavorites()
        tbLinks.Refresh()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        AppManager.CurrentBrowser.Refresh()
    End Sub

    Private Sub OrganizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrganizeToolStripMenuItem.Click
        AppManager.CurrentBrowser.ShowOrganizeFavorites()
        mnuFavs.DropDownItems.Clear()
        mnuFavs.DropDownItems.GetEnumerator()
        tbLinks.Items.Clear()
        LoadFavorites()
        tbLinks.Refresh()
    End Sub

    Private Sub BackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackToolStripMenuItem.Click
        If AppManager.CurrentBrowser.CanGoBack Then
            AppManager.CurrentBrowser.GoBack()
        End If
    End Sub

    Private Sub ForwardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForwardToolStripMenuItem.Click
        If AppManager.CurrentBrowser.CanGoForward Then
            AppManager.CurrentBrowser.GoForward()
        End If
    End Sub
#End Region

    Private Sub Loadstatusdailysite()
        frmSettings.TextBox2.Text = My.Settings.gcp
        frmSettings.TextBox3.Text = My.Settings.tcp
    End Sub
    Private Sub Customizeloads()
        If My.Settings.statubar = True Then
            sBar.Visible = True
            My.Settings.Save()
        Else
            If My.Settings.statubar = False Then
                sBar.Visible = False
                My.Settings.Save()
            End If
        End If
        If My.Settings.linksk = True Then
            tbLinks.Visible = True
            My.Settings.Save()
        Else
            If My.Settings.linksk = False Then
                tbLinks.Visible = False
                My.Settings.Save()
            End If
        End If
        If My.Settings.searchbox = True Then
            textsearch.Visible = True
            livetxt.Visible = True
            My.Settings.Save()
        Else
            livetxt.Visible = False
            textsearch.Visible = False
            My.Settings.Save()
        End If
    End Sub
    Private Sub OrganizeFavoritesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrganizeFavorites.Click

        AppManager.CurrentBrowser.ShowOrganizeFavorites()
        mnuFavs.DropDownItems.Clear()
        mnuFavs.DropDownItems.GetEnumerator()
        tbLinks.Items.Clear()
        LoadFavorites()
        tbLinks.Refresh()
    End Sub

    Private Sub ToolStripStatusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel1.Click
        Dim ofrm As New frmSecInfo
        ofrm.ShowDialog(Me)
    End Sub

    Private Sub GoHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoHome.Click
        If My.Settings.UseStartPage = True Then
            AppManager.CurrentBrowser.Navigate("http://www.jawoco.com/")
        Else
            If My.Settings.generalbank = True Then
                AppManager.CurrentBrowser.Navigate("about:blank")
            Else

                If My.Settings.personal = True Then
                    AppManager.CurrentBrowser.Navigate(My.Settings.gcp)
                End If
            End If
        End If
    End Sub
    Private Sub EscToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EscToolStripMenuItem.Click
        Me.Opacity = 100
        Me.ShowInTaskbar = True
    End Sub

    Private Sub ResetSecurityCheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetSecurityCheck.Click
        My.Settings.Passwordbrowser = "iforgotmypassword"
        My.Settings.Save()
        Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess  255") 'Delete All Data
        MsgBox("Your password has been reset and all data have been cleared. Your password is 'iforgotmypassword'. ", MsgBoxStyle.Information)
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        tc1.TabPages.SelectedTab.Form.Close()
    End Sub
    Private Sub CodeInspectorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CodeInspectorToolStripMenuItem.Click
        Dim ofrm As New frmDocExplorer
        ofrm.deWB.Navigate(AppManager.CurrentBrowser.Url.ToString)
        tc1.TabPages.Add(ofrm)
    End Sub

    Private Sub ImageSnifferToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImageSnifferToolStripMenuItem.Click
        Dim ofrm As New frmScrapeImages
        ofrm.ShowDialog(AppManager.MainForm)
    End Sub

    Private Sub SourceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SourceToolStripMenuItem.Click
        AppManager.CurrentBrowser.ShowSource()
    End Sub

    Private Sub PropertiesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        Dim ofrm As New frmProperties
        ofrm.obj = AppManager.CurrentBrowser.Document
        ofrm.ShowDialog(Me)
    End Sub

    Private Sub RssFeedToolStripMenuItem_Click_2(sender As System.Object, e As System.EventArgs) Handles RssFeedToolStripMenuItem1.Click
        Dim ofrm As New frmRSS
        Me.tc1.TabPages.Add(ofrm)
    End Sub

    Private Sub CheckFeedsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CheckFeedsToolStripMenuItem.Click
        Dim ofrm As New frmDetectRSS
        ofrm.ShowDialog(Me)
    End Sub

    Private Sub btnCut_Click(sender As System.Object, e As System.EventArgs) Handles btnCut.Click
        AppManager.CurrentBrowser.Document.ExecCommand("Cut", False, System.DBNull.Value)
    End Sub
    Private Sub btnCopy_Click(sender As System.Object, e As System.EventArgs) Handles btnCopy.Click
        If Not IsNothing(AppManager.CurrentBrowser.Document) Then
            AppManager.CurrentBrowser.Document.ExecCommand("Copy", False, System.DBNull.Value)
        End If
    End Sub
    Private Sub btnPaste_Click(sender As System.Object, e As System.EventArgs) Handles btnPaste.Click
        If Not IsNothing(AppManager.CurrentBrowser.Document) Then
            AppManager.CurrentBrowser.Document.ExecCommand("Paste", False, System.DBNull.Value)
        End If
    End Sub
    Private Sub btnselectall_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectAll.Click
        If Not IsNothing(AppManager.CurrentBrowser.Document) Then
            AppManager.CurrentBrowser.Document.Focus()
            AppManager.CurrentBrowser.Document.ExecCommand("SelectAll", False, System.DBNull.Value)
            AppManager.CurrentBrowser.Document.Focus()
        End If
    End Sub
    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        AppManager.CurrentBrowser.ShowFindDialog()
    End Sub

    Private Sub xtravoguide_Click(sender As System.Object, e As System.EventArgs) Handles xtravoguide.Click
        frmWhatsnew.Show()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UndoUBRC.Click
        cboURL.Undo()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyUBRC.Click
        cboURL.Copy()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CutUBRC.Click
        cboURL.Cut()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PasteUBRC.Click
        cboURL.Paste()
    End Sub

    Private Sub PasteSearchToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PasteSearchUBRC.Click
        cboURL.Paste()
        AppManager.CurrentBrowser.Navigate(cboURL.Text)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteUBRC.Click
        cboURL.Clear()
    End Sub

    Private Sub UndoSBRC_Click(sender As System.Object, e As System.EventArgs) Handles UndoSBRC.Click
        textsearch.Undo()
    End Sub

    Private Sub CopySBRC_Click(sender As System.Object, e As System.EventArgs) Handles CopySBRC.Click
        textsearch.Copy()
    End Sub

    Private Sub CutSBRC_Click(sender As System.Object, e As System.EventArgs) Handles CutSBRC.Click
        textsearch.Cut()
    End Sub

    Private Sub PasteSBRC_Click(sender As System.Object, e As System.EventArgs) Handles PasteSBRC.Click
        textsearch.Paste()
    End Sub

    Private Sub DeleteSBRC_Click(sender As System.Object, e As System.EventArgs) Handles DeleteSBRC.Click
        textsearch.Clear()
    End Sub
End Class
