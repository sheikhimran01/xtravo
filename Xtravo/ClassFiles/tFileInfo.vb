Module tFileInfo

    ' put this in a module
    ' if you want to put in a form or class module
    ' change all "public" to "private"

    Public Structure SHELLEXECUTEINFO
        Dim cbSize As Integer
        Dim fMask As Integer
        Dim hwnd As Integer
        Dim lpVerb As String
        Dim lpFile As String
        Dim lpParameters As String
        Dim lpDirectory As String
        Dim nShow As Integer
        Dim hInstApp As Integer
        Dim lpIDList As Integer
        Dim lpClass As String
        Dim hkeyClass As Integer
        Dim dwHotKey As Integer
        Dim hIcon As Integer
        Dim hProcess As Integer
    End Structure

    'UPGRADE_WARNING: Structure SHELLEXECUTEINFO may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1050"'
    Public Declare Function ShellExecuteEx Lib "shell32" (ByRef SEI As SHELLEXECUTEINFO) As Integer

    Public Function ShowProp(ByRef FileName As String) As Boolean
        Dim SEI As SHELLEXECUTEINFO = Nothing

        With SEI

            'Set the structure's size
            .cbSize = Len(SEI)
            'Set the mask
            .fMask = &H44CS
            'Show the properties
            .lpVerb = "properties"
            'Set the filename
            .lpFile = FileName

        End With

        ShowProp = ShellExecuteEx(SEI) <> 0

    End Function
End Module

