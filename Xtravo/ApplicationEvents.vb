Namespace My

    ' The following events are availble for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            'Lets setup a command line start, say if a user drops a url file onto our executable.
            'On Error Resume Next
            Try
                If e.CommandLine.Count > 0 Or Me.CommandLineArgs.Count > 0 Then
                    If e.CommandLine.Item(0).EndsWith(".url") Then
                        Dim oIni As New tlxIni(e.CommandLine.Item(0).ToString)
                        AppManager.StartURL = oIni.GetString("INTERNETSHORTCUT", "URL", String.Empty)
                    ElseIf InStr(e.CommandLine.Item(0).ToString, "http://") Or _
                        InStr(e.CommandLine.Item(0).ToString, "www.") Then
                        AppManager.StartURL = e.CommandLine.Item(0).ToString
                        'Else
                        'MsgBox("> 0 " & e.CommandLine.Count)
                    End If
                Else
                    'Code here for process start
                End If
            Catch ex As Exception
                MsgBox("ERROR: " & ex.Message.ToString)
            End Try
        End Sub
    End Class

End Namespace

