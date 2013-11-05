#Region " Read Me "
'Unfortunatelty the Web Browser control in VS2005 is just a wrapper of IE ActiveX control and not a very
'complete one, some methods were added to make some of the features you would want
'easier to access, but unfortunately to get some features you would want the easy way such as find
'and other dialogs that IE can show, you still have to reference 'SHDocVw' (the ie active x control).
'I decided to find a way to get at this functionality without referencing the SHDocVW.DLL directly in the 
'project and instead import the required features at runtime and then release them.
#End Region

Imports System
Imports System.Text
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports System.Security.Permissions

<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
<System.Runtime.InteropServices.ComVisibleAttribute(True)> _
Public Class exBrowser
    Inherits System.Windows.Forms.WebBrowser
  
#Region " COM Imports Etc..."
    <StructLayout(LayoutKind.Sequential)> _
Public Structure OLECMDTEXT
        Public cmdtextf As UInt32
        Public cwActual As UInt32
        Public cwBuf As UInt32
        Public rgwz As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure OLECMD
        Public cmdID As Long
        Public cmdf As UInt64
    End Structure
    ' Interop - IOleCommandTarget (See MSDN - http://support.microsoft.com/?kbid=311288)
    <ComImport(), Guid("b722bccb-4e68-101b-a2bc-00aa00404770"), _
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)> _
    Public Interface IOleCommandTarget
        Sub QueryStatus(ByRef pguidCmdGroup As Guid, ByVal cCmds As UInt32, _
            <MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=1)> ByVal prgCmds As OLECMD, _
            ByRef pCmdText As OLECMDTEXT)

        Sub Exec(ByRef pguidCmdGroup As Guid, ByVal nCmdId As Long, _
            ByVal nCmdExecOpt As Long, ByRef pvaIn As Object, _
            ByRef pvaOut As Object)
    End Interface

    Private cmdGUID As New Guid(&HED016940, -17061, _
  &H11CF, &HBA, &H4E, &H0, &HC0, &H4F, &HD7, &H8, &H16)


#Region " Commands Enumeration "
    'There are a ton of ole commands, we are only using a couple, msdn research will
    'allow you to figure out which ones you want to use.
    Enum oCommands As Long
        Options
        Find = 1
        ViewSource = 2
        '////////////////////////////////////////
        ID_FILE_SAVEAS = 32771
        ID_FILE_PAGESETUP = 32772
        ID_FILE_IMPORTEXPORT = 32774
        ID_FILE_PRINTPREVIEW = 32776
        ID_FILE_NEWIE = 32779
        ID_FILE_NEWMAIL = 32780
        PID_FILE_NEWINTERNETCALL = 32781
        ID_FILE_ADDTRUST = 32782
        ID_FILE_ADDLOCAL = 32783
        DLCTL_BGSOUNDS = &H40
        DLCTL_DLIMAGES = &H10
        DLCTL_DOWNLOADONLY = &H800
        DLCTL_FORCEOFFLINE = &H10000000
        DLCTL_NO_BEHAVIORS = &H800
        DLCTL_NO_CLIENTPULL = &H20000000
        DLCTL_NO_DLACTIVEXCTLS = &H400
        DLCTL_NO_FRAMEDOWNLOAD = &H1000
        DLCTL_NO_JAVA = &H100
        DLCTL_NO_METACHARSET = &H10000
        DLCTL_NO_RUNACTIVEXCTLS = &H200
        DLCTL_NO_SCRIPTS = &H80
        'DLCTL_OFFLINE DLCTL_OFFLINEIFNOTCONNECTED
        DLCTL_OFFLINEIFNOTCONNECTED = &H80000000
        DLCTL_PRAGMA_NO_CACHE = &H4000
        DLCTL_RESYNCHRONIZE = &H2000
        DLCTL_SILENT = &H40000000
        DLCTL_URL_ENCODING_DISABLE_UTF8 = &H20000
        DLCTL_URL_ENCODING_ENABLE_UTF8 = &H40000
        DLCTL_VIDEOS = &H20
    End Enum

#End Region

#End Region

    'Just a little easier way to get at it.
    Public ReadOnly Property CurrentURL() As String
        Get
            Return Me.Document.Url.ToString
        End Get
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

#Region " Dialogs "

    Public Sub ShowOpen()
        Dim cdlOpen As New OpenFileDialog
        Try
            cdlOpen.Filter = "HTML Files (*.htm)|*.htm|HTML Files (*.html)|*.html|TextFiles" & _
                "(*.txt)|*.txt|Gif Files (*.gif)|*.gif|JPEG Files (*.jpg)|*.jpeg|" & _
                "PNG Files (*.png)|*.png|Art Files (*.art)|*.art|AU Fles (*.au)|*.au|" & _
                "AIFF Files (*.aif|*.aiff|XBM Files (*.xbm)|*.xbm|All Files (*.*)|*.*"

            cdlOpen.Title = " Open File "
            cdlOpen.ShowDialog()

            If cdlOpen.FileName > Nothing Then
                Me.Navigate(cdlOpen.FileName)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message.ToString)
        End Try
    End Sub

    Public Sub ShowSource()
        Dim cmdt As IOleCommandTarget
        Dim o As Object = Nothing
        Dim oIE As Object = Nothing
        Try
            cmdt = CType(Me.Document.DomDocument, IOleCommandTarget)
            cmdt.Exec(cmdGUID, oCommands.ViewSource, 1, o, o)

        Catch ex As Exception
            Throw New Exception(ex.Message.ToString, ex.InnerException)
        Finally
            cmdt = Nothing
        End Try
    End Sub

    Public Sub ShowFindDialog()
        Dim cmdt As IOleCommandTarget
        Dim o As Object = Nothing
        Dim oIE As Object = Nothing
        Try
            cmdt = CType(Me.Document.DomDocument, IOleCommandTarget)
            cmdt.Exec(cmdGUID, oCommands.Find, 0, o, o)

        Catch ex As Exception
            Throw New Exception(ex.Message.ToString, ex.InnerException)
        Finally
            cmdt = Nothing
        End Try
    End Sub

    Public Sub AddToFavorites(Optional ByVal strURL As String = "", Optional ByVal strTitle As String = "")
        Dim oHelper As Object = Nothing
        Try
            oHelper = New ShellUIHelper
            oHelper.AddFavorite(Me.Document.Url.ToString, Me.DocumentTitle.ToString)
        Catch ex As Exception
            Throw New Exception(ex.Message.ToString)
        End Try
        If oHelper IsNot Nothing AndAlso Marshal.IsComObject(oHelper) Then
            Marshal.ReleaseComObject(oHelper)
        End If
    End Sub

    Public Sub ShowOrganizeFavorites()
        'Organize Favorites
        Dim helper As Object = Nothing
        Try
            helper = New ShellUIHelper()
            helper.ShowBrowserUI("OrganizeFavorites", 0)
        Finally
            If helper IsNot Nothing AndAlso Marshal.IsComObject(helper) Then
                Marshal.ReleaseComObject(helper)
            End If
        End Try
    End Sub

    Public Sub SendToDesktop()
        'Shortcut to desktop
        Dim helper As Object = Nothing
        Try
            helper = New ShellUIHelper()
            helper.AddDesktopComponent(Me.Document.Url.ToString, "website")
        Finally
            If helper IsNot Nothing AndAlso Marshal.IsComObject(helper) Then
                Marshal.ReleaseComObject(helper)
            End If
        End Try
    End Sub

    ''' <summary>
    ''' This Will launch the internet option dialog.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowInternetOptions()
        Shell("rundll32.exe shell32.dll,Control_RunDLL inetcpl.cpl,,0", vbNormalFocus)
    End Sub

    Public Sub ShowPrivacyReport()
        Shell("rundll32.exe shell32.dll,Control_RunDLL inetcpl.cpl,,2", vbNormalFocus)
    End Sub

#End Region

#Region " Extended "

    <ComImport(), _
        Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D"), _
        InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch), _
        TypeLibType(TypeLibTypeFlags.FHidden)> _
        Public Interface DWebBrowserEvents2

        <DispId(250)> _
        Sub BeforeNavigate2(<[In](), MarshalAs(UnmanagedType.IDispatch)> ByVal pDisp As Object, _
        <InAttribute(), MarshalAs(UnmanagedType.BStr)> ByRef URL As String, _
        <InAttribute()> ByRef flags As Object, _
        <InAttribute(), MarshalAs(UnmanagedType.BStr)> ByRef targetFrameName As String, _
        <InAttribute()> ByRef postdata As Object, _
        <InAttribute(), MarshalAs(UnmanagedType.BStr)> ByRef headers As String, _
        <InAttribute(), OutAttribute()> ByRef cancel As Boolean)

        'Note: Postdata is a SafeArray but for some reason, if I do a proper declaration, the event will not be raised:
        '<[In](), MarshalAs(UnmanagedType.SafeArray, safearraysubtype:=VarEnum.VT_UI1)> ByRef postdata() As Byte, _

        <DispId(273)> _
        Sub NewWindow3(<InAttribute(), MarshalAs(UnmanagedType.IDispatch)> ByVal pDisp As Object, _
        <InAttribute(), OutAttribute()> ByRef cancel As Boolean, _
        <InAttribute()> ByRef Flags As Object, _
        <InAttribute(), MarshalAs(UnmanagedType.BStr)> ByRef UrlContext As String, _
        <InAttribute(), MarshalAs(UnmanagedType.BStr)> ByRef Url As String)

    End Interface

    Public Enum NWMF
        NWMF_UNLOADING = &H1&
        NWMF_USERINITED = &H2&
        NWMF_FIRST_USERINITED = &H4&
        NWMF_OVERRIDEKEY = &H8&
        NWMF_SHOWHELP = &H10&
        NWMF_HTMLDIALOG = &H20&
        NWMF_FROMPROXY = &H40&
    End Enum

    Private cookie As AxHost.ConnectionPointCookie
    Private wevents As WebBrowserExtendedEvents

    'This method will be called to give you a chance to create your own event sink
    Protected Overrides Sub CreateSink()
        'MAKE SURE TO CALL THE BASE or the normal events won't fire
        MyBase.CreateSink()
        wevents = New WebBrowserExtendedEvents(Me)
        cookie = New AxHost.ConnectionPointCookie(Me.ActiveXInstance, wevents, GetType(DWebBrowserEvents2))
    End Sub

    Protected Overrides Sub DetachSink()
        If Not cookie Is Nothing Then
            cookie.Disconnect()
            cookie = Nothing
        End If
        MyBase.DetachSink()
    End Sub

    'This new event will fire when the page is navigating
    Public Delegate Sub WebBrowserNavigatingExtendedEventHandler(ByVal sender As Object, ByVal e As WebBrowserNavigatingExtendedEventArgs)
    Public Event NavigatingExtended As WebBrowserNavigatingExtendedEventHandler

    'This event will fire when a new window is about to be opened
    Public Delegate Sub WebBrowserNewWindowExtendedEventHandler(ByVal sender As Object, ByVal e As WebBrowserNewWindowExtendedEventArgs)
    Public Event NewWindowExtended As WebBrowserNewWindowExtendedEventHandler

    Protected Friend Sub OnNavigatingExtended(ByVal Url As String, ByVal Frame As String, ByVal Postdata As Byte(), ByVal Headers As String, ByRef Cancel As Boolean)
        Dim e As WebBrowserNavigatingExtendedEventArgs = New WebBrowserNavigatingExtendedEventArgs(Url, Frame, Postdata, Headers)
        RaiseEvent NavigatingExtended(Me, e)
        Cancel = e.Cancel
    End Sub

    Protected Friend Sub OnNewWindowExtended(ByVal Url As String, ByRef Cancel As Boolean, ByVal Flags As NWMF, ByVal UrlContext As String)
        Dim e As WebBrowserNewWindowExtendedEventArgs = New WebBrowserNewWindowExtendedEventArgs(Url, UrlContext, Flags)
        RaiseEvent NewWindowExtended(Me, e)
        Cancel = e.Cancel
    End Sub

    Public Overloads Sub Navigate2(ByVal URL As String)
        MyBase.Navigate(URL)
    End Sub

#End Region

#Region " Extended Event Classes "
    'This class will capture events from the WebBrowser
    Friend Class WebBrowserExtendedEvents
        Inherits System.Runtime.InteropServices.StandardOleMarshalObject
        Implements DWebBrowserEvents2

        Private m_Browser As exBrowser

        Public Sub New(ByVal browser As exBrowser)
            m_Browser = browser
        End Sub

        'Implement whichever events you wish
        Public Sub BeforeNavigate2(ByVal pDisp As Object, ByRef URL As String, ByRef flags As Object, ByRef targetFrameName As String, ByRef postData As Object, ByRef headers As String, ByRef cancel As Boolean) Implements DWebBrowserEvents2.BeforeNavigate2
            m_Browser.OnNavigatingExtended(URL, targetFrameName, CType(postData, Byte()), headers, cancel)
        End Sub

        Public Sub NewWindow3(ByVal pDisp As Object, ByRef Cancel As Boolean, ByRef Flags As Object, ByRef UrlContext As String, ByRef Url As String) Implements DWebBrowserEvents2.NewWindow3
            m_Browser.OnNewWindowExtended(Url, Cancel, CType(Flags, NWMF), UrlContext)
        End Sub
    End Class


    Public Class WebBrowserNewWindowExtendedEventArgs
        Inherits CancelEventArgs

        Private m_Url As String
        Private m_UrlContext As String
        Private m_Flags As NWMF

        Public ReadOnly Property Url() As String
            Get
                Return m_Url
            End Get
        End Property

        Public ReadOnly Property UrlContext() As String
            Get
                Return m_UrlContext
            End Get
        End Property

        Public ReadOnly Property Flags() As NWMF
            Get
                Return m_Flags
            End Get
        End Property

        Public Sub New(ByVal url As String, ByVal urlcontext As String, ByVal flags As NWMF)
            m_Url = url
            m_UrlContext = urlcontext
            m_Flags = flags
        End Sub

    End Class


    'First define a new EventArgs class to contain the newly exposed data
    Public Class WebBrowserNavigatingExtendedEventArgs
        Inherits CancelEventArgs

        Private m_Url As String
        Private m_Frame As String
        Private m_Postdata() As Byte
        Private m_Headers As String

        Public ReadOnly Property Url() As String
            Get
                Return m_Url
            End Get
        End Property

        Public ReadOnly Property Frame() As String
            Get
                Return m_Frame
            End Get
        End Property

        Public ReadOnly Property Headers() As String
            Get
                Return m_Headers
            End Get
        End Property

        Public ReadOnly Property Postdata() As String
            Get
                Return PostdataToString(m_Postdata)
            End Get
        End Property

        Public ReadOnly Property PostdataByte() As Byte()
            Get
                Return m_Postdata
            End Get
        End Property

        Public Sub New(ByVal url As String, ByVal frame As String, ByVal postdata As Byte(), ByVal headers As String)
            m_Url = url
            m_Frame = frame
            m_Postdata = postdata
            m_Headers = headers
        End Sub

        Private Function PostdataToString(ByVal p() As Byte) As String
            'not sexy but it works...
            Dim tabpd() As Byte, bstop As Boolean = False, stmp As String = "", i As Integer = 0
            tabpd = p
            If tabpd Is Nothing OrElse tabpd.Length = 0 Then
                Return ""
            Else
                For i = 0 To tabpd.Length - 1
                    stmp += ChrW(tabpd(i))
                Next
                stmp = Replace(stmp, ChrW(13), "")
                stmp = Replace(stmp, ChrW(10), "")
                stmp = Replace(stmp, ChrW(0), "")
            End If
            If stmp = Nothing Then
                Return ""
            Else
                Return stmp
            End If
        End Function

    End Class
#End Region

    <ComImport(), Guid("64AB4BB7-111E-11D1-8F79-00C04FC2FBE1")> _
    Public Class ShellUIHelper
        '
    End Class

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'exBrowser
        '
        Me.ScriptErrorsSuppressed = True
        Me.ResumeLayout(False)

    End Sub
End Class







