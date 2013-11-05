'Ruler User Control
'Copyright 2007 - Thomas Maxwell
'Code for the ruler may not be redistributed without consent of the author (me)
'or without leaving this notice intact.
Imports System.Drawing
Imports System.ComponentModel
Public Class Ruler
    Private _LineSize As Integer = 2
    Private _TickStep As Integer = 3
    Private _DrawMode As DrawModes
    Private _DrawBorder As Boolean = True
    Private _DrawLabel As Boolean = False
    Private _Pen As Color = Color.Black

    Enum DrawModes
        TopOnly
        BottomOnly
        TopAndBottom
    End Enum

    Enum LineSizes
        None = 0
        Thin = 1
        Small = 2
        Medium = 3
        Large = 4
        Largest = 5
    End Enum

    <Browsable(True), DefaultValue(DrawModes.TopOnly), _
     Category("Appearance"), Description("Sets the mode the cotrol draws in")> _
    Public Property DrawMode() As DrawModes
        Get
            Return _DrawMode
        End Get
        Set(ByVal Value As DrawModes)
            _DrawMode = Value
            Me.Refresh()
        End Set
    End Property

    <Browsable(True), Category("Appearance"), DefaultValue(3), Description("Small Tick Frequency")> _
    Public Property TickStep() As Integer
        Get
            Return _TickStep
        End Get
        Set(ByVal Value As Integer)
            If Value > 5 Or Value < 0 Then
                MessageBox.Show("Tick step muct be between 0 and 5", "Invalid Number" _
                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                _TickStep = 1
            Else
                _TickStep = Value
            End If
            Me.Refresh()
        End Set
    End Property

    <Browsable(True), DefaultValue(True), Description("Determines if control draws a border."), _
    Category("Appearance")> Public Property ShowBorder() As Boolean
        Get
            Return _DrawBorder
        End Get
        Set(ByVal Value As Boolean)
            _DrawBorder = Value
            Me.Refresh()
        End Set
    End Property

    <Browsable(True), DefaultValue(True), Category("Appearance"), _
    Description("Determines whether the control will draw labels")> _
    Public Property DrawLabels() As Boolean
        Get
            Return _DrawLabel
        End Get
        Set(ByVal Value As Boolean)
            _DrawLabel = Value
            Me.Refresh()
        End Set
    End Property

    <Browsable(True), DefaultValue(True), Category("Appearance"), _
    Description("Determines color of the ticks")> _
    Public Property PenColor() As Color
        Get
            Return _Pen
        End Get
        Set(ByVal value As Color)
            _Pen = value
        End Set
    End Property

    Private Sub Ruler_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DrawRuler(ByVal g As Graphics, ByVal formWidth As Integer, ByVal formHeight As Integer)
        ' Border
        If ShowBorder = True Then
            g.DrawRectangle(Pens.Black, 0, 0, formWidth - 1, formHeight - 1)
        End If
        ' Width
        If DrawLabels = True Then
            g.DrawString(Me.Width.ToString + " pixels", Font, Brushes.Black, 10, (Me.Height / 2) - (Font.Height / 2))
        End If
        ' Ticks
        Dim i As Integer
        For i = 0 To formWidth - 1 Step i + _TickStep
            If i Mod 2 = 0 Then
                Dim tickHeight As Integer
                If i Mod 100 = 0 Then
                    tickHeight = 15
                    If DrawLabels = True Then
                        DrawTickLabel(g, i.ToString(), i, formHeight, tickHeight)
                    End If
                ElseIf i Mod 10 = 0 Then
                    tickHeight = 10
                Else
                    tickHeight = 5
                End If
                DrawTick(g, i, formHeight, tickHeight)
            End If
        Next
    End Sub

    Private Sub DrawTick(ByVal g As Graphics, ByVal xPos As Integer, ByVal formHeight As Integer, ByVal tickHeight As Integer)
        Select Case DrawMode
            Case DrawModes.BottomOnly
                g.DrawLine(New Pen(_Pen, 1), xPos, formHeight, xPos, formHeight - tickHeight)
            Case DrawModes.TopOnly
                g.DrawLine(New Pen(_Pen, 1), xPos, 0, xPos, tickHeight)
            Case DrawModes.TopAndBottom
                ' Top
                g.DrawLine(New Pen(_Pen, 1), xPos, 0, xPos, tickHeight)
                ' Bottom
                g.DrawLine(New Pen(_Pen, 1), xPos, formHeight, xPos, formHeight - tickHeight)
        End Select

    End Sub

    Private Sub DrawTickLabel(ByVal g As Graphics, ByVal text As String, ByVal xPos As Integer, ByVal formHeight As Integer, ByVal height As Integer)

        Select Case DrawMode
            Case DrawModes.BottomOnly
                g.DrawString(text, Font, Brushes.Black, xPos - 100, formHeight - height - Font.Height)
            Case DrawModes.TopOnly
                g.DrawString(text, Font, Brushes.Black, xPos - 100, height)
            Case DrawModes.TopAndBottom
                ' Top
                g.DrawString(text, Font, Brushes.Black, xPos - 100, height)
                ' Bottom
                g.DrawString(text, Font, Brushes.Black, xPos - 100, formHeight - height - Font.Height)
        End Select

    End Sub


    Private Sub Ruler_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim height As Integer = Me.Height
        Dim width As Integer = Me.Width
        'Select Case Orientation
        '    Case Orientations.Horizontal
        DrawRuler(e.Graphics, width, height)
    End Sub
End Class
