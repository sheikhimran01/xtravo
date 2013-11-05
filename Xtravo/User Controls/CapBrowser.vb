Imports System
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Imaging
Public Class CapBrowser

    <System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
    Private Shared Function BitBlt( _
    ByVal hdcDest As IntPtr, _
    ByVal nXDest As Integer, _
    ByVal nYDest As Integer, _
    ByVal nWidth As Integer, _
    ByVal nHeight As Integer, _
    ByVal hdcSrc As IntPtr, _
    ByVal nXSrc As Integer, _
    ByVal nYSrc As Integer, _
    ByVal dwRop As System.Int32) As Boolean
    End Function

    Public Sub GetImage(ByVal ofrm As frmBrowser)
        Dim g1 As Graphics = ofrm.wb.CreateGraphics()
        Dim MyImage = New Bitmap(ofrm.wb.ClientRectangle.Width, ofrm.wb.ClientRectangle.Height, g1)
        Dim g2 As Graphics = Graphics.FromImage(MyImage)
        Dim dc1 As IntPtr = g1.GetHdc()
        Dim dc2 As IntPtr = g2.GetHdc()
        BitBlt(dc2, 0, 0, ofrm.wb.ClientRectangle.Width, ofrm.wb.ClientRectangle.Height, dc1, 0, 0, 13369376)
        g1.ReleaseHdc(dc1)
        g2.ReleaseHdc(dc2)
        pb.Image = MyImage
        'MessageBox.Show("Finished Saving Image")
    End Sub

    Private Sub CapBrowser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
