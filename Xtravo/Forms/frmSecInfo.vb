'///////////////////////////////////////////
'This form just shows a little bit of grabbing
'some info from the loaded document and 
'displaying it.
'simular routines could be use to implement
'additional security such as a phishing filter
'etc.
'///////////////////////////////////////////
Public Class frmSecInfo

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmSecInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oelement As HtmlElement
        For Each oelement In AppManager.CurrentBrowser.Document.Links
            ListBox1.Items.Add(oelement.GetAttribute("HREF"))
        Next

        Dim str As String = AppManager.CurrentBrowser.Document.Cookie.ToString
        txtCookie.Text = str
    End Sub

    Private Sub lbCookies_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbCookies.LinkClicked
        Dim ofrm As New frmBrowser
        AppManager.AddTab(ofrm, "http://www.microsoft.com/info/cookies.mspx")
        Me.Close()
    End Sub
End Class