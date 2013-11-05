Imports System.ComponentModel
Public Class InfoBar

    Private _PlaySound As Boolean
    Private Sub InfoBar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Dock = DockStyle.Top
    End Sub

    Private Sub pbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbClose.Click
        Me.Visible = False
    End Sub

    <Browsable(True)> Public Overrides Property Text() As String
        Get
            Return Me.Label1.Text
        End Get
        Set(ByVal value As String)
            Me.Label1.Text = value
        End Set
    End Property

    <Browsable(True)> Public Property PlaySound() As Boolean
        Get
            Return _PlaySound
        End Get
        Set(ByVal value As Boolean)
            _PlaySound = value
        End Set
    End Property

    'We could really complete this control and put the play sound in here is we wanted to...
    Private Sub InfoBar_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        'If Me.Visible = True Then
        '    My.Computer.Audio.Play(My.Resources.Windows_Pop_up_Blocked, AudioPlayMode.Background)
        'End If
    End Sub

End Class
