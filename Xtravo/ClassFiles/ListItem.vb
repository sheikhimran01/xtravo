Public Class ListItem

    Private _Text As String
    Public Property Text() As String
        Get
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
        End Set
    End Property

    Private _Value As String
    Public Property Value() As String
        Get
            Return _Value
        End Get
        Set(ByVal value As String)
            _Value = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return _Text
    End Function

End Class
