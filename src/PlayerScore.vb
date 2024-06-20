Friend Class PlayerScore
    Private players As Dictionary(Of String, Player)

    Public Sub New(players As Dictionary(Of String, Player))
        Me.players = players
    End Sub
End Class
