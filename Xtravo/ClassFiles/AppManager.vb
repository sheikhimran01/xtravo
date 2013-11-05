Imports System.IO
Imports System.Net
Public Class AppManager

    Public Shared StartURL As String = ""

    Private Shared _CurrentBrowser As exBrowser
    Public Shared Property CurrentBrowser() As exBrowser
        Get
            Return _CurrentBrowser
        End Get
        Set(ByVal value As exBrowser)
            _CurrentBrowser = value
        End Set
    End Property

    Private Shared _MainForm As frmMain
    Public Shared Property MainForm() As frmMain
        Get
            Return _MainForm
        End Get
        Set(ByVal value As frmMain)
            _MainForm = value
        End Set
    End Property

    Public Shared ReadOnly Property ConnString() As String
        Get
            Return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
            Application.StartupPath & "\data\xdb.mdb;User Id=admin;Password=;"
        End Get
    End Property

#Region " Helper Routines "

    Public Shared Sub AddTab(ByVal ofrm As Form, Optional ByVal URL As String = "")
        _MainForm.tc1.TabPages.Add(ofrm)
        If URL = "" Then
            _CurrentBrowser.GoHome()
        Else
            Navigate(URL)
        End If
    End Sub

    Public Shared Sub AddTab(ByVal oTab As Xtravo.TabPage, Optional ByVal URL As String = "")
        _MainForm.tc1.TabPages.Add(oTab.Form)
        If URL = "" Then
            _CurrentBrowser.GoHome()
        Else
            Navigate(URL)
        End If
    End Sub

    Public Shared Sub Navigate(ByVal URL As String)
        _CurrentBrowser.Navigate(URL)
    End Sub

    Public Shared Function FixURL(ByVal sURL As String) As String
        If Not sURL.ToLower().StartsWith("http://") _
        Then sURL = "http://" & sURL
        Return sURL
    End Function

#End Region

    Public Shared Function GetWebImage(ByVal ImageURL As String) As Image
        Dim objImage As MemoryStream
        Dim objwebClient As WebClient
        Dim sURL As String = Trim(ImageURL)
        Dim oImage As Image
        Try
            If Not sURL.ToLower().StartsWith("http://") _
            Then sURL = "http://" & sURL
            objwebClient = New WebClient
            objImage = New _
            MemoryStream(objwebClient.DownloadData(sURL))
            oImage = System.Drawing.Image.FromStream(objImage)
            Return oImage
        Catch ex As Exception
            'Return something, an error or no image as default
            Return Nothing
        End Try
    End Function

    Public Shared Function GetFavIcon(ByVal IconURL As String) As Icon
        'Here we could implement some "caching" of our own by
        'saving the image, then later we could just grab the existing image.
        'For the purposes of this example, we'll just grab one if it's there
        'every time.
        Dim oIcon As Icon
        Dim objIcon As MemoryStream
        Dim objwebClient As WebClient
        Dim sURL As String = Trim(IconURL)

        Try
            If Not sURL.ToLower().StartsWith("http://") _
            Then sURL = "http://" & sURL
            objwebClient = New WebClient
            objIcon = New MemoryStream(objwebClient.DownloadData(sURL))
            oIcon = New Icon(objIcon)
            If IsNothing(oIcon) Then
                Return My.Resources.Globe
            Else
                Return oIcon
            End If
        Catch ex As Exception
            'Return the generic globe icon
            Return My.Resources.Globe
        End Try
    End Function

    Public Shared Function LoadWebImageToPictureBox(ByVal pb _
        As PictureBox, ByVal ImageURL As String) As Boolean

        Dim objImage As MemoryStream
        Dim objwebClient As WebClient
        Dim sURL As String = Trim(ImageURL)
        Dim bAns As Boolean

        Try
            If Not sURL.ToLower().StartsWith("http://") _
            Then sURL = "http://" & sURL
            objwebClient = New WebClient
            objImage = New _
            MemoryStream(objwebClient.DownloadData(sURL))
            pb.Image = System.Drawing.Image.FromStream(objImage)
            bAns = True
        Catch ex As Exception

            bAns = False
        End Try

        Return bAns

    End Function

    Public Shared Function IsValidUrl(ByVal url As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(url, _
            "(http|ftp|https)://([\w-]+\.)+(/[\w- ./?%&=]*)?")
    End Function

    Public Shared Function IsValidIP(ByVal ipAddress As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(ipAddress, _
            "^(25[0-5]|2[0-4]\d|[0-1]?\d?\d)(\.(25[0-5]|2[0-4]\d|[0-1]?\d?\d)){3}$")
    End Function

    Public Shared Function IsValidEmail(ByVal email As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(email, _
            "^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
    End Function

    Public Shared Sub ShellandWait(ByVal ProcessPath As String)
        Dim objProcess As System.Diagnostics.Process
        Try
            objProcess = New System.Diagnostics.Process()
            objProcess.StartInfo.FileName = ProcessPath
            objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            objProcess.Start()

            'Wait until the process passes back an exit code 
            objProcess.WaitForExit()

            'Free resources associated with this process
            objProcess.Close()
        Catch
            MessageBox.Show("Could not start process " & ProcessPath, "Error")
        End Try
    End Sub

    Public Shared Sub DetectFeeds()
        On Error Resume Next
        Dim li As ListItem
        Dim oEl As HtmlElement
        For Each oEl In CurrentBrowser.Document.All
            If oEl.GetAttribute("Type") = "application/rss+xml" Then
                MainForm.mnuFeeds.Enabled = True
                Exit Sub
            End If
        Next

        MainForm.mnuFeeds.Enabled = False
    End Sub

End Class
