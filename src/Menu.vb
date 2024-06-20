Imports System.Windows.Forms
Imports System.IO
Imports WMPLib

Public Class Form1
    ' Dictionnaire pour stocker les joueurs avec leur nom comme clé
    Private players As New Dictionary(Of String, Player)()
    ' Chemin du fichier de données des joueurs
    Private playerFilePath As String = "joueur.txt"
    ' Instance du lecteur Windows Media Player
    Private WithEvents player As WMPLib.WindowsMediaPlayer
    ' Processus pour la lecture vidéo
    Private videoProcess As Process
    Private toolTip As ToolTip

    ' Événement déclenché lors du chargement du formulaire
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configure la fenêtre pour être sans bordure et maximisée
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        ' Définit l'image de fond
        Me.BackgroundImage = Image.FromFile("Ressources\2020-07-22_14.29.27.png")
        Me.BackgroundImageLayout = ImageLayout.Stretch
        ' Charge les données des joueurs
        LoadPlayerData()
        ' Charge les noms des joueurs dans le contrôle Saisie_Nom
        LoadPlayerNames()

        ' Initialise le lecteur Windows Media Player
        player = New WMPLib.WindowsMediaPlayer()
        player.settings.setMode("loop", True)
        player.URL = "Ressources\1-18. Sweden.mp3"
        player.controls.play()
        player.settings.volume = 100
        pnlNiveau.Visible = False
        toolTip = New ToolTip()
        Dim steveButton As New Button()
        steveButton.Size = New Size(400, 500) ' Ajustez la taille selon vos besoins
        steveButton.Location = New Point(1000, 100) ' Positionnez le bouton où vous le souhaitez
        steveButton.Image = Image.FromFile("Ressources\SteveMinecraft.png")
        steveButton.ImageAlign = ContentAlignment.MiddleCenter

        AddHandler steveButton.Click, AddressOf SteveButton_Click

        Me.Controls.Add(steveButton)
    End Sub

    Private Sub SteveButton_Click(sender As Object, e As EventArgs)
        Dim rules As String = "Règles du Sudoku : " & vbCrLf &
                              "1. Remplissez la grille de sorte que chaque ligne, chaque colonne " & vbCrLf &
                              "   et chaque sous-grille de 3x3 ou 4x4 contienne tous les chiffres de 1 à 9 ou 1 à 16." & vbCrLf &
                              "2. Aucun chiffre ne doit être répété dans une ligne, une colonne ou une sous-grille." & vbCrLf &
                              "3. Utilisez la logique pour déduire les chiffres manquants."

        toolTip.Show(rules, CType(sender, Button), 5000) ' Affiche la bulle de texte pendant 5 secondes
    End Sub

    ' Événement déclenché lors de la fermeture du formulaire
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Arrête la lecture et ferme le lecteur
        player.controls.stop()
        player.close()
        ' Sauvegarde les données des joueurs
        SavePlayerData()
    End Sub

    ' Événement déclenché lorsque la visibilité du formulaire change
    Private Sub Form1_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible = False Then
            player.controls.stop()
        Else
            player.controls.play()
        End If
    End Sub

    ' Charge les noms des joueurs dans le contrôle Saisie_Nom
    Private Sub LoadPlayerNames()
        Saisie_Nom.Items.Clear()
        Saisie_Nom.Items.AddRange(players.Keys.ToArray())
    End Sub

    ' Charge les données des joueurs depuis le fichier
    Private Sub LoadPlayerData()
        If File.Exists(playerFilePath) Then
            Using reader As New StreamReader(playerFilePath)
                Dim header As String = reader.ReadLine()
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Dim player As Player = Player.FromString(line)
                    players(player.Name) = player
                End While
            End Using
        End If
    End Sub

    ' Sauvegarde les données des joueurs dans le fichier
    Public Sub SavePlayerData()
        Using writer As New StreamWriter(playerFilePath)
            writer.WriteLine("Name;BestTime;GamesPlayed;TotalTimePlayed")
            For Each player As Player In players.Values
                writer.WriteLine(player.ToString())
            Next
        End Using
    End Sub

    ' Événement déclenché lors du clic sur le bouton de démarrage de la partie
    Private Sub ButtonGameStart_Click(sender As Object, e As EventArgs) Handles ButtonGameStart.Click
        If String.IsNullOrWhiteSpace(Saisie_Nom.Text) Then
            MessageBox.Show("Veuillez entrer un nom de joueur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim playerName As String = Saisie_Nom.Text
            If Not players.ContainsKey(playerName) Then
                players.Add(playerName, New Player(playerName))
            End If
            LoadPlayerNames()
            pnlNiveau.Visible = True ' Afficher le panel de sélection de la grille
        End If
    End Sub

    ' Événement déclenché lors du clic sur le bouton des scores
    Private Sub Score_Click(sender As Object, e As EventArgs) Handles Score.Click
        Dim playerStatisticsForm As New PlayerStatisticsForm(players)
        playerStatisticsForm.Show()
    End Sub

    ' Événement déclenché lors du clic sur le bouton de sortie
    Private Sub Leave_Click(sender As Object, e As EventArgs) Handles Leave.Click
        Dim result As DialogResult = MessageBox.Show("êtes vous sûr de vouloir quitter l'application ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    ' Événement déclenché lors de l'appui sur une touche dans le champ de saisie du nom
    Private Sub Saisie_Nom_KeyDown(sender As Object, e As KeyEventArgs) Handles Saisie_Nom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim playerName As String = Saisie_Nom.Text.Trim()
            If Not String.IsNullOrEmpty(playerName) Then
                If Not players.ContainsKey(playerName) Then
                    players.Add(playerName, New Player(playerName))
                    MessageBox.Show($"Nouveau joueur {playerName} ajouté.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SavePlayerData()
                Else
                    MessageBox.Show($"Joueur {playerName} sélectionné.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                LoadPlayerNames()
                Saisie_Nom.SelectedItem = playerName
            End If
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Événement déclenché lors de la mise à jour du texte dans le champ de saisie du nom
    Private Sub Saisie_Nom_TextUpdate(sender As Object, e As EventArgs) Handles Saisie_Nom.TextUpdate
        Dim currentText As String = Saisie_Nom.Text
        Saisie_Nom.Items.Clear()

        ' Recharger les noms des joueurs qui commencent par le texte actuel
        Dim matchingPlayers = players.Keys.Where(Function(name) name.StartsWith(currentText, StringComparison.InvariantCultureIgnoreCase)).ToArray()
        Saisie_Nom.Items.AddRange(matchingPlayers)

        ' Ouvrir la liste déroulante pour afficher les correspondances
        Saisie_Nom.DroppedDown = True

        ' Déplacer le curseur à la fin du texte
        Saisie_Nom.SelectionStart = currentText.Length
        Saisie_Nom.SelectionLength = 0
    End Sub

    ' Événement déclenché lors de la sélection d'un nom dans le champ de saisie du nom
    Private Sub Saisie_Nom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Saisie_Nom.SelectedIndexChanged
        Dim selectedPlayerName As String = Saisie_Nom.SelectedItem?.ToString()
        If Not String.IsNullOrEmpty(selectedPlayerName) Then
            MessageBox.Show($"Joueur {selectedPlayerName} sélectionné.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    ' Événement déclenché lors du clic sur le bouton RickRoll
    Private Sub RickRoll_Click(sender As Object, e As EventArgs) Handles RickRoll.Click
        ' Chemin du fichier vidéo MP4
        Dim videoPath As String = "Ressources\rickroll.mp4"

        ' Vérifie si le fichier existe
        If File.Exists(videoPath) Then
            ' Ouvre le fichier vidéo avec le lecteur multimédia par défaut
            Process.Start(videoPath)
            Application.Exit()
        Else
            MessageBox.Show("Le fichier vidéo n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnGame9x9_Click(sender As Object, e As EventArgs) Handles btnGame9x9.Click
        If Not String.IsNullOrWhiteSpace(Saisie_Nom.Text) AndAlso players.ContainsKey(Saisie_Nom.Text) Then
            Dim playerName As String = Saisie_Nom.Text
            Dim gameForm As New GameForm(players(playerName))
            Me.Hide()
            gameForm.ShowDialog()
            pnlNiveau.Hide()
            Me.Show()
        Else
            MessageBox.Show("Veuillez entrer un nom de joueur valide ou s'assurer qu'il est enregistré.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnGame16x16_Click(sender As Object, e As EventArgs) Handles btnGame16x16.Click
        If Not String.IsNullOrWhiteSpace(Saisie_Nom.Text) AndAlso players.ContainsKey(Saisie_Nom.Text) Then
            Dim playerName As String = Saisie_Nom.Text
            Dim gameForm16 As New GameForm16x16(players(playerName))
            Me.Hide()
            gameForm16.ShowDialog()
            pnlNiveau.Hide()

            Me.Show()
        Else
            MessageBox.Show("Veuillez entrer un nom de joueur valide ou s'assurer qu'il est enregistré.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class
