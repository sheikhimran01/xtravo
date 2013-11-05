Public Class frmError
    Public err As Exception

    Private Sub frmError_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblErr.Text = "Error Message: " & err.Message.ToString & vbCrLf & _
        "Stack Trace: " & err.StackTrace.ToString
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        MessageBox.Show("Error sent" & _
        vbCrLf & "Thank You for your Bug Report" & vbCrLf & vbCrLf & _
        "Jawoco. Com", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class