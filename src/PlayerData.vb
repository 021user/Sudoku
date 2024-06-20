Module PlayerData
    Public Players As New Dictionary(Of String, PlayerInfo)

    Public Structure PlayerInfo
        Public Name As String
        Public BestTime As TimeSpan
        Public GamesPlayed As Integer
        Public TotalTimePlayed As TimeSpan
        Public Difficulty As String

        Public Sub New(name As String)
            Me.Name = name
            BestTime = TimeSpan.Zero
            GamesPlayed = 0
            TotalTimePlayed = TimeSpan.Zero
            Difficulty = "Medium" ' Valeur par défaut
        End Sub
    End Structure

    Public Sub LoadPlayerData()
        ' Implémentez le chargement des données ici
    End Sub

    Public Sub SavePlayerData()
        ' Implémentez la sauvegarde des données ici
    End Sub
End Module
