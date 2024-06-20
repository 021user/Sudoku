Public Class Player
    Public Property Name As String
    Public Property BestTime As TimeSpan
    Public Property GamesPlayed As Integer
    Public Property TotalTimePlayed As TimeSpan

    Public Sub New(name As String)
        Me.Name = name
        Me.BestTime = TimeSpan.MaxValue
        Me.GamesPlayed = 0
        Me.TotalTimePlayed = TimeSpan.Zero
    End Sub

    Public Overrides Function ToString() As String
        Return $"{Name};{BestTime};{GamesPlayed};{TotalTimePlayed}"
    End Function

    Public Shared Function FromString(data As String) As Player
        Dim parts As String() = data.Split(";"c)
        Dim name As String = parts(0)
        Dim bestTime As TimeSpan = TimeSpan.Parse(parts(1))
        Dim gamesPlayed As Integer = Integer.Parse(parts(2))
        Dim totalTimePlayed As TimeSpan = TimeSpan.Parse(parts(3))
        Return New Player(name) With {
            .BestTime = bestTime,
            .GamesPlayed = gamesPlayed,
            .TotalTimePlayed = totalTimePlayed
        }
    End Function
End Class
