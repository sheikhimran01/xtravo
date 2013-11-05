Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.IO
Imports System.Drawing.Imaging
Public Class Page2Image
    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Public Shared Function FindWindowEx(ByVal parent As IntPtr, ByVal [next] As IntPtr, ByVal sClassName As String, ByVal sWindowTitle As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", ExactSpelling:=True, CharSet:=CharSet.Auto)> _
    Public Shared Function GetWindow(ByVal hWnd As IntPtr, ByVal uCmd As Integer) As IntPtr
    End Function

    <DllImport("user32.Dll")> _
    Public Shared Sub GetClassName(ByVal h As Integer, ByVal s As StringBuilder, ByVal nMaxCount As Integer)
    End Sub

    <DllImport("user32.dll")> _
    Private Shared Function PrintWindow(ByVal hwnd As IntPtr, ByVal hdcBlt As IntPtr, ByVal nFlags As UInteger) As Boolean
    End Function

    Public Const GW_CHILD As Integer = 5
    Public Const GW_HWNDNEXT As Integer = 2

    Public Function CapturePage(ByVal oDoc As HtmlDocument) As Image
        Try
            'URL Location
            Dim chkShowGuides As Boolean = False
            Dim myLocalLink As String = oDoc.Url.ToString
            Dim URLExtraHeight As Integer = 0
            Dim URLExtraLeft As Integer = 0

            'Adjustment variable for capture size.
            'If chkWriteURL.Checked = True Then
            '    URLExtraHeight = 25
            'End If

            'TrimHeight and TrimLeft trims off some captured IE graphics.
            Dim trimHeight As Integer = 3
            Dim trimLeft As Integer = 3

            'Use UrlExtra height to carry trimHeight.
            URLExtraHeight = URLExtraHeight - trimHeight
            URLExtraLeft = URLExtraLeft - trimLeft

            oDoc.Body.SetAttribute("scroll", "yes")

            'Get Browser Window Height
            Dim heightsize As Integer = CInt(oDoc.Body.GetAttribute("scrollHeight"))
            Dim widthsize As Integer = CInt(oDoc.Body.GetAttribute("scrollWidth"))

            'Get Screen Height
            Dim screenHeight As Integer = CInt(oDoc.Body.GetAttribute("clientHeight"))
            Dim screenWidth As Integer = CInt(oDoc.Body.GetAttribute("clientWidth"))

            'Get bitmap to hold screen fragment.
            Dim bm As New Bitmap(screenWidth, screenHeight, System.Drawing.Imaging.PixelFormat.Format16bppRgb555)

            'Create a target bitmap to draw into.
            Dim bm2 As New Bitmap(widthsize + URLExtraLeft, heightsize + URLExtraHeight - trimHeight, System.Drawing.Imaging.PixelFormat.Format16bppRgb555)
            Dim g2 As Graphics = Graphics.FromImage(bm2)

            Dim g As Graphics = Nothing
            Dim hdc As IntPtr
            Dim screenfrag As Image = Nothing
            Dim brwTop As Integer = 0
            Dim brwLeft As Integer = 0
            Dim myPage As Integer = 0
            Dim myIntptr As IntPtr = DirectCast(AppManager.CurrentBrowser.Handle, IntPtr)
            'Get inner browser window.
            Dim hwndInt As Integer = myIntptr.ToInt32()
            Dim hwnd As IntPtr = myIntptr
            hwnd = GetWindow(hwnd, GW_CHILD)
            Dim sbc As New StringBuilder(256)
            'Get Browser "Document" Handle
            While hwndInt <> 0
                hwndInt = hwnd.ToInt32()
                GetClassName(hwndInt, sbc, 256)

                If sbc.ToString().IndexOf("Shell DocObject View", 0) > -1 Then
                    hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Internet Explorer_Server", IntPtr.Zero)
                    Exit While
                End If

                hwnd = GetWindow(hwnd, GW_HWNDNEXT)
            End While

            'Get Screen Height (for bottom up screen drawing)
            While (myPage * screenHeight) < heightsize
                oDoc.Body.SetAttribute("scrollTop", (screenHeight - 5) * myPage)
                myPage += 1
            End While
            'Rollback the page count by one
            myPage -= 1

            Dim myPageWidth As Integer = 0

            While (myPageWidth * screenWidth) < widthsize
                oDoc.Body.SetAttribute("scrollLeft", (screenWidth - 5) * myPageWidth)
                brwLeft = CInt(oDoc.Body.GetAttribute("scrollLeft"))
                For i As Integer = myPage To 0 Step -1
                    'Shoot visible window
                    g = Graphics.FromImage(bm)
                    hdc = g.GetHdc()
                    oDoc.Body.SetAttribute("scrollTop", (screenHeight - 5) * i)
                    brwTop = CInt(oDoc.Body.GetAttribute("scrollTop"))
                    PrintWindow(hwnd, hdc, 0)
                    g.ReleaseHdc(hdc)
                    g.Flush()
                    screenfrag = Image.FromHbitmap(bm.GetHbitmap())
                    g2.DrawImage(screenfrag, brwLeft + URLExtraLeft, brwTop + URLExtraHeight)
                Next
                myPageWidth += 1
            End While

            'Draw Standard Resolution Guides
            If chkShowGuides = True Then
                ' Create pen.
                Dim myWidth As Integer = 1
                Dim myPen As New Pen(Color.Navy, myWidth)
                Dim myShadowPen As New Pen(Color.NavajoWhite, myWidth)
                ' Create coordinates of points that define line.
                Dim x1 As Single = -CSng(myWidth) - 1 + URLExtraLeft
                Dim y1 As Single = -CSng(myWidth) - 1 + URLExtraHeight

                Dim x600 As Single = 600.0F + CSng(myWidth) + 1
                Dim y480 As Single = 480.0F + CSng(myWidth) + 1

                Dim x2 As Single = 800.0F + CSng(myWidth) + 1
                Dim y2 As Single = 600.0F + CSng(myWidth) + 1

                Dim x3 As Single = 1024.0F + CSng(myWidth) + 1
                Dim y3 As Single = 768.0F + CSng(myWidth) + 1

                Dim x1280 As Single = 1280.0F + CSng(myWidth) + 1
                Dim y1024 As Single = 1024.0F + CSng(myWidth) + 1

                ' Draw line to screen.
                g2.DrawRectangle(myPen, x1, y1, x600 + myWidth, y480 + myWidth)
                g2.DrawRectangle(myPen, x1, y1, x2 + myWidth, y2 + myWidth)
                g2.DrawRectangle(myPen, x1, y1, x3 + myWidth, y3 + myWidth)
                g2.DrawRectangle(myPen, x1, y1, x1280 + myWidth, y1024 + myWidth)

                ' Create font and brush.
                Dim drawFont As New Font("Arial", 12)
                Dim drawBrush As New SolidBrush(Color.Navy)
                Dim drawBrush2 As New SolidBrush(Color.NavajoWhite)

                ' Set format of string.
                Dim drawFormat As New StringFormat()
                drawFormat.FormatFlags = StringFormatFlags.FitBlackBox
                ' Draw string to screen.
                g2.DrawString("600 x 480", drawFont, drawBrush, 5, y480 - 20 + URLExtraHeight, drawFormat)
                g2.DrawString("800 x 600", drawFont, drawBrush, 5, y2 - 20 + URLExtraHeight, drawFormat)
                g2.DrawString("1024 x 768", drawFont, drawBrush, 5, y3 - 20 + URLExtraHeight, drawFormat)
                g2.DrawString("1280 x 1024", drawFont, drawBrush, 5, y1024 - 20 + URLExtraHeight, drawFormat)
            End If
            Dim chkWriteURL As Boolean = True
            'Write URL
            If chkWriteURL = True Then
                'Backfill URL paint location
                Dim whiteBrush As New SolidBrush(Color.White)
                Dim fillRect As New Rectangle(0, 0, widthsize, URLExtraHeight + 2)
                Dim fillRegion As New Region(fillRect)
                g2.FillRegion(whiteBrush, fillRegion)

                Dim drawBrushURL As New SolidBrush(Color.Black)
                Dim drawFont As New Font("Arial", 12)
                Dim drawFormat As New StringFormat()
                drawFormat.FormatFlags = StringFormatFlags.FitBlackBox

                g2.DrawString(myLocalLink, drawFont, drawBrushURL, 0, 0, drawFormat)
            End If

            'Reduce Resolution Size
            Dim myResolution As Double = Convert.ToDouble(100) * 0.01 'Convert.ToDouble(cmbResolution.Text) * 0.01
            Dim finalWidth As Integer = CInt(((widthsize + URLExtraLeft) * myResolution))
            Dim finalHeight As Integer = CInt(((heightsize + URLExtraHeight) * myResolution))
            Dim finalImage As New Bitmap(finalWidth, finalHeight, System.Drawing.Imaging.PixelFormat.Format16bppRgb555)
            Dim gFinal As Graphics = Graphics.FromImage(DirectCast(finalImage, Image))
            gFinal.DrawImage(bm2, 0, 0, finalWidth, finalHeight)

            'Get Time Stamp
            Dim myTime As DateTime = DateTime.Now
            Dim format As String = "MM.dd.hh.mm.ss"

            'Create Directory to save image to.
            Directory.CreateDirectory("C:\IECapture")

            'Write Image.
            Dim eps As New EncoderParameters(1)
            Dim myQuality As Long = Convert.ToInt64(100) 'Convert.ToInt64(cmbQuality.Text)
            eps.Param(0) = New EncoderParameter(System.Drawing.Imaging.Encoder.Quality, myQuality)
            Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")
            'finalImage.Save("c:\\IECapture\Captured_" + myTime.ToString(format) + ".jpg", ici, eps)

            Return finalImage
            'Clean Up.
            'myDoc = Nothing
            g.Dispose()
            g2.Dispose()
            gFinal.Dispose()
            bm.Dispose()
            bm2.Dispose()
            'finalImage.Dispose()

            Cursor.Current = Cursors.[Default]
        Catch ex As Exception
            Dim ofrm As New frmError
            ofrm.err = ex
            ofrm.Show()
            Return Nothing
        End Try
    End Function

    Private Shared Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        Dim j As Integer
        Dim encoders As ImageCodecInfo()
        encoders = ImageCodecInfo.GetImageEncoders()
        For j = 0 To encoders.Length - 1
            If encoders(j).MimeType = mimeType Then
                Return encoders(j)
            End If
        Next
        Return Nothing
    End Function
End Class
