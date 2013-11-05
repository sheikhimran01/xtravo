Imports System
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Imaging


'/ Provides functions to capture the entire screen, or a particular window, and save it to a file.
Public Class ScreenCap
    '/ Creates an Image object containing a screen shot of the entire desktop
    Public Function CaptureScreen() As Image
        Return CaptureWindow(User32.GetDesktopWindow())
    End Function 'CaptureScreen
    '/ Creates an Image object containing a screen shot of a specific window
    Public Function CaptureWindow(ByVal handle As IntPtr) As Image
        Dim SRCCOPY As Integer = &HCC0020
        ' get te hDC of the target window
        Dim hdcSrc As IntPtr = User32.GetWindowDC(handle)
        ' get the size
        Dim windowRect As New User32.RECT
        User32.GetWindowRect(handle, windowRect)
        Dim width As Integer = windowRect.right - windowRect.left
        Dim height As Integer = windowRect.bottom - windowRect.top
        ' create a device context we can copy to
        Dim hdcDest As IntPtr = GDI32.CreateCompatibleDC(hdcSrc)
        ' create a bitmap we can copy it to,
        ' using GetDeviceCaps to get the width/height
        Dim hBitmap As IntPtr = GDI32.CreateCompatibleBitmap(hdcSrc, width, height)
        ' select the bitmap object
        Dim hOld As IntPtr = GDI32.SelectObject(hdcDest, hBitmap)
        ' bitblt over
        GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, SRCCOPY)
        ' restore selection
        GDI32.SelectObject(hdcDest, hOld)
        ' clean up 
        GDI32.DeleteDC(hdcDest)
        User32.ReleaseDC(handle, hdcSrc)

        ' get a .NET image object for it
        Dim img As Image = Image.FromHbitmap(hBitmap)
        ' free up the Bitmap object
        GDI32.DeleteObject(hBitmap)

        Return img
    End Function 'CaptureWindow
    '/ Captures a screen shot of a specific window, and saves it to a file
    Public Sub CaptureWindowToFile(ByVal handle As IntPtr, ByVal filename As String, ByVal format As ImageFormat)
        Dim img As Image = CaptureWindow(handle)
        img.Save(filename, format)
    End Sub 'CaptureWindowToFile
    '/ Captures a screen shot of the entire desktop, and saves it to a file
    Public Sub CaptureScreenToFile(ByVal filename As String, ByVal format As ImageFormat)
        Dim img As Image = CaptureScreen()
        img.Save(filename, format)
    End Sub 'CaptureScreenToFile
    Public Function CaptureDeskTopRectangle(ByVal CapRect As Rectangle, ByVal CapRectWidth As Integer, ByVal CapRectHeight As Integer) As Bitmap
        '/ Returns BitMap of the region of the desktop, similar to CaptureWindow, but can be used to 
        '/ create a snapshot of the desktop when no handle is present, by passing in a rectangle 
        '/ Grabs snapshot of entire desktop, then crops it using the passed in rectangle's coordinates
        Dim SC As New ScreenCap
        Dim bmpImage As New Bitmap(SC.CaptureScreen)
        Dim bmpCrop As New Bitmap(CapRectWidth, CapRectHeight, bmpImage.PixelFormat)
        Dim recCrop As New Rectangle(CapRect.X, CapRect.Y, CapRectWidth, CapRectHeight)
        Dim gphCrop As Graphics = Graphics.FromImage(bmpCrop)
        Dim recDest As New Rectangle(0, 0, CapRectWidth, CapRectHeight)
        gphCrop.DrawImage(bmpImage, recDest, recCrop.X, recCrop.Y, recCrop.Width, _
          recCrop.Height, GraphicsUnit.Pixel)
        Return bmpCrop
    End Function
    '/ Helper class containing Gdi32 API functions
    Private Class GDI32
        Public SRCCOPY As Integer = &HCC0020
        ' BitBlt dwRop parameter
        Declare Function BitBlt Lib "gdi32.dll" ( _
            ByVal hDestDC As IntPtr, _
            ByVal x As Int32, _
            ByVal y As Int32, _
            ByVal nWidth As Int32, _
            ByVal nHeight As Int32, _
            ByVal hSrcDC As IntPtr, _
            ByVal xSrc As Int32, _
            ByVal ySrc As Int32, _
            ByVal dwRop As Int32) As Int32

        Declare Function CreateCompatibleBitmap Lib "gdi32.dll" ( _
            ByVal hdc As IntPtr, _
            ByVal nWidth As Int32, _
            ByVal nHeight As Int32) As IntPtr

        Declare Function CreateCompatibleDC Lib "gdi32.dll" ( _
            ByVal hdc As IntPtr) As IntPtr

        Declare Function DeleteDC Lib "gdi32.dll" ( _
            ByVal hdc As IntPtr) As Int32

        Declare Function DeleteObject Lib "gdi32.dll" ( _
            ByVal hObject As IntPtr) As Int32

        Declare Function SelectObject Lib "gdi32.dll" ( _
            ByVal hdc As IntPtr, _
            ByVal hObject As IntPtr) As IntPtr
    End Class 'GDI32
    '/ Helper class containing User32 API functions
    Public Class User32
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure RECT
            Public left As Integer
            Public top As Integer
            Public right As Integer
            Public bottom As Integer
        End Structure 'RECT

        Declare Function GetDesktopWindow Lib "user32.dll" () As IntPtr

        Declare Function GetWindowDC Lib "user32.dll" ( _
            ByVal hwnd As IntPtr) As IntPtr

        Declare Function ReleaseDC Lib "user32.dll" ( _
            ByVal hwnd As IntPtr, _
            ByVal hdc As IntPtr) As Int32

        Declare Function GetWindowRect Lib "user32.dll" ( _
            ByVal hwnd As IntPtr, _
            ByRef lpRect As RECT) As Int32

    End Class 'User32
End Class 'ScreenCapture 



