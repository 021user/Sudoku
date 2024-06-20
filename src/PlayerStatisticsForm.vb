Imports System.Windows.Forms
Imports WMPLib

Public Class PlayerStatisticsForm
    Private players As Dictionary(Of String, Player) ' Dictionnaire pour stocker les joueurs
    Private WithEvents jeu As WMPLib.WindowsMediaPlayer ' Objet pour la lecture de fichiers multimédias

    ' Constructeur de la classe qui reçoit un dictionnaire de joueurs
    Public Sub New(players As Dictionary(Of String, Player))
        InitializeComponent()
        Me.players = players
        LoadPlayerStatistics() ' Charge les statistiques des joueurs lors de la création de l'instance
    End Sub

    ' Méthode pour charger les statistiques des joueurs dans les contrôles de l'interface
    Private Sub LoadPlayerStatistics()
        ' Configure la fenêtre pour être sans bordure et maximisée
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized

        ' Vider les listes existantes
        PlayersListBox.Items.Clear()
        BestTimesListBox.Items.Clear()
        ListBox1.Items.Clear() ' Pour le nombre de parties jouées
        ListBox2.Items.Clear() ' Pour le temps total de jeu

        ' Ajouter les joueurs et leurs statistiques dans les ListBox correspondantes
        For Each player As Player In players.Values
            PlayersListBox.Items.Add(player.Name)
            BestTimesListBox.Items.Add(player.BestTime.ToString("hh\:mm\:ss"))
            ListBox1.Items.Add(player.GamesPlayed.ToString())
            ListBox2.Items.Add(player.TotalTimePlayed.ToString("hh\:mm\:ss"))
        Next

        ' Charger les noms des joueurs dans la ComboBox de recherche
        SearchPlayerComboBox.Items.Clear()
        SearchPlayerComboBox.Items.AddRange(players.Keys.ToArray())
    End Sub

    ' Méthode pour trier les joueurs par nom et recharger les statistiques
    Private Sub SortPlayersByNameButton_Click(sender As Object, e As EventArgs) Handles SortPlayersByNameButton.Click
        players = players.OrderBy(Function(x) x.Key).ToDictionary(Function(x) x.Key, Function(x) x.Value)
        LoadPlayerStatistics()
    End Sub

    ' Méthode pour trier les joueurs par meilleur temps et recharger les statistiques
    Private Sub SortPlayersByBestTimeButton_Click(sender As Object, e As EventArgs) Handles SortPlayersByBestTimeButton.Click
        players = players.OrderBy(Function(x) x.Value.BestTime).ToDictionary(Function(x) x.Key, Function(x) x.Value)
        LoadPlayerStatistics()
    End Sub

    ' Événement déclenché lors de la sélection d'un joueur dans la ComboBox de recherche
    Private Sub SearchPlayerComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SearchPlayerComboBox.SelectedIndexChanged
        ' Afficher les statistiques du joueur sélectionné
        Dim selectedPlayerName As String = SearchPlayerComboBox.SelectedItem.ToString()
        Dim selectedPlayer As Player = players(selectedPlayerName)
        MessageBox.Show($"Statistiques de {selectedPlayer.Name}:" & vbCrLf &
                        $"Meilleur temps : {selectedPlayer.BestTime.ToString("hh\:mm\:ss")}" & vbCrLf &
                        $"Nombre de parties jouées : {selectedPlayer.GamesPlayed}" & vbCrLf &
                        $"Temps total de jeu écoulé : {selectedPlayer.TotalTimePlayed.ToString("hh\:mm\:ss")}",
                        "Statistiques du joueur", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Événement déclenché lors de la sélection d'un joueur dans la ListBox des joueurs
    Private Sub PlayersListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PlayersListBox.SelectedIndexChanged
        ' Synchroniser la sélection dans les autres ListBox
        If PlayersListBox.SelectedIndex <> -1 Then
            BestTimesListBox.SelectedIndex = PlayersListBox.SelectedIndex
            ListBox1.SelectedIndex = PlayersListBox.SelectedIndex
            ListBox2.SelectedIndex = PlayersListBox.SelectedIndex
            SearchPlayerComboBox.SelectedItem = PlayersListBox.SelectedItem
        End If
    End Sub

    ' Événement déclenché lors de la sélection d'un meilleur temps dans la ListBox des meilleurs temps
    Private Sub BestTimesListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BestTimesListBox.SelectedIndexChanged
        ' Synchroniser la sélection dans les autres ListBox
        If BestTimesListBox.SelectedIndex <> -1 Then
            PlayersListBox.SelectedIndex = BestTimesListBox.SelectedIndex
            ListBox1.SelectedIndex = BestTimesListBox.SelectedIndex
            ListBox2.SelectedIndex = BestTimesListBox.SelectedIndex
            SearchPlayerComboBox.SelectedItem = PlayersListBox.Items(BestTimesListBox.SelectedIndex)
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ' Synchronise la sélection dans les autres ListBox
        If ListBox1.SelectedIndex <> -1 Then
            PlayersListBox.SelectedIndex = ListBox1.SelectedIndex
            BestTimesListBox.SelectedIndex = ListBox1.SelectedIndex
            ListBox2.SelectedIndex = ListBox1.SelectedIndex
            SearchPlayerComboBox.SelectedItem = PlayersListBox.Items(ListBox1.SelectedIndex)
        End If
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        ' Synchronise la sélection dans les autres ListBox
        If ListBox2.SelectedIndex <> -1 Then
            PlayersListBox.SelectedIndex = ListBox2.SelectedIndex
            BestTimesListBox.SelectedIndex = ListBox2.SelectedIndex
            ListBox1.SelectedIndex = ListBox2.SelectedIndex
            SearchPlayerComboBox.SelectedItem = PlayersListBox.Items(ListBox2.SelectedIndex)
        End If
    End Sub

    ' Événement déclenché lors du chargement du formulaire
    Private Sub PlayerStatisticsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Charger les noms des joueurs dans la ComboBox de recherche
        SearchPlayerComboBox.Items.Clear()
        SearchPlayerComboBox.Items.AddRange(players.Keys.ToArray())
    End Sub

    ' Événement déclenché lors du clic sur le bouton de retour au menu principal
    Private Sub Leave_Click(sender As Object, e As EventArgs) Handles Leave.Click
        Dim result As DialogResult = MessageBox.Show("Êtes-vous sûr de vouloir revenir au Menu Principal ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()

            ' Afficher le formulaire principal
            Form1.Show()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
