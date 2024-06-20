Imports System.Windows.Forms
Imports AxWMPLib
Imports WMPLib
Imports Projet_Sudoku.PlayerStatisticsForm

Public Class GameForm
    Private sudokuGrid(8, 8) As TextBox ' Grille de Sudoku constituée de TextBox
    Private WithEvents gameTimer As Timer ' Timer pour le compte à rebours du jeu
    Private timeLeft As Integer = 7 * 60 ' Temps restant en secondes (7 minutes)
    Private currentPlayer As Player ' Joueur actuel
    Private gameStartTime As DateTime ' Heure de début de la partie
    Private playerStatisticsForm As PlayerStatisticsForm ' Formulaire des statistiques des joueurs
    Private WithEvents player As WindowsMediaPlayer ' Lecteur Windows Media Player
    Private solutionGrid(8, 8) As Integer ' Grille de solution pour le bouton de solution

    ' Constructeur de la classe recevant un joueur en paramètre
    Public Sub New(player As Player)
        ' Cet appel est requis par le concepteur.
        InitializeComponent()
        ' Initialisation du joueur actuel
        currentPlayer = player
    End Sub

    ' Méthode pour accélérer le temps et la musique si moins de 2 minutes restantes
    Public Sub SpeedUp()
        If timeLeft < 2 * 60 Then
            ' Code pour accélérer le temps et la musique
        End If
    End Sub

    ' Événement déclenché lors du chargement du formulaire
    Private Sub GameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configure la fenêtre pour être sans bordure et maximisée
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        ' Définit l'image de fond et la couleur de fond
        Me.BackgroundImage = Image.FromFile("Ressources\8f1ab8b14a55720d6859620a6f596933.jpg")
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Me.BackColor = Color.SkyBlue

        ' Initialiser la grille de Sudoku et le Timer de jeu
        InitializeSudokuGrid()
        InitializeGameTimer()
        ' Charger le puzzle initial de Sudoku
        LoadInitialSudokuPuzzle()
        gameStartTime = DateTime.Now ' Enregistrer l'heure de début de la partie

        ' Initialiser le lecteur Windows Media Player
        player = New WindowsMediaPlayer()
        player.settings.setMode("loop", True)
        player.URL = "Ressources\05 Sm64ds Luigi's Casino(1).mp3"
        player.controls.play()
    End Sub


    ' Méthode pour initialiser la grille de Sudoku
    Private Sub InitializeSudokuGrid()
        Dim textBoxSize As Integer = 40
        Dim spacing As Integer = 2

        ' Ajouter une étiquette pour afficher le nom du joueur
        Dim playerNameLabel As New Label With {
                .Text = $"Joueur : {currentPlayer.Name}",
                .Location = New Point(10, 10),
                .AutoSize = True
            }
        Me.Controls.Add(playerNameLabel)

        ' Ajouter une étiquette pour afficher le temps restant
        Dim timerLabel As New Label With {
                .Name = "TimerLabel",
                .Location = New Point(10, 40),
                .Font = New Font("Arial", 12, FontStyle.Bold),
                .AutoSize = True
            }
        Me.Controls.Add(timerLabel)

        ' Initialiser chaque TextBox de la grille de Sudoku
        For row As Integer = 0 To 8
            For col As Integer = 0 To 8
                Dim txtBox As New TextBox With {
                        .Width = textBoxSize,
                        .Height = textBoxSize,
                        .Location = New Point((textBoxSize + spacing) * col, (textBoxSize + spacing) * (row + 2)),
                        .TextAlign = HorizontalAlignment.Center,
                        .Font = New Font("Arial", 20, FontStyle.Bold),
                        .MaxLength = 1
                    }

                ' Ajouter des gestionnaires d'événements pour les entrées de texte
                AddHandler txtBox.KeyPress, AddressOf TextBox_KeyPress
                AddHandler txtBox.TextChanged, AddressOf TextBox_TextChanged
                sudokuGrid(row, col) = txtBox
                Me.Controls.Add(txtBox)
            Next
        Next
    End Sub

    ' Méthode pour initialiser le Timer de jeu
    Public Sub InitializeGameTimer()
        gameTimer = New Timer()
        gameTimer.Interval = 1000 ' Intervalle de 1 seconde
        AddHandler gameTimer.Tick, AddressOf GameTimer_Tick
        gameTimer.Start()
    End Sub

    ' Gestionnaire de l'événement Tick du Timer
    Private Sub GameTimer_Tick(sender As Object, e As EventArgs)
        If timeLeft > 0 Then
            timeLeft -= 1
            UpdateTimerDisplay()
        Else
            gameTimer.Stop()
            MessageBox.Show("Temps écoulé !", "Fin du jeu", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EndGame(False)
        End If
    End Sub

    ' Méthode pour mettre à jour l'affichage du Timer
    Private Sub UpdateTimerDisplay()
        Dim timerLabel As Label = CType(Me.Controls("TimerLabel"), Label)

        If timerLabel IsNot Nothing Then
            Dim minutes As Integer = timeLeft \ 60
            Dim seconds As Integer = timeLeft Mod 60
            timerLabel.Text = $"Temps restant : {minutes:D2}:{seconds:D2}"
        End If
    End Sub

    ' Méthode pour charger le puzzle initial de Sudoku
    Private Sub LoadInitialSudokuPuzzle()
        ' Générer une grille complète de Sudoku
        GenerateFullSudokuSolution()

        ' Appliquer les valeurs initiales à la grille
        For row As Integer = 0 To 8
            For col As Integer = 0 To 8
                sudokuGrid(row, col).Text = If(solutionGrid(row, col) = 0, "", solutionGrid(row, col).ToString())
                sudokuGrid(row, col).ReadOnly = solutionGrid(row, col) <> 0
                sudokuGrid(row, col).BackColor = If(solutionGrid(row, col) = 0, Color.White, Color.LightGray)
            Next
        Next
    End Sub

    ' Méthode pour générer une solution complète de Sudoku
    Private Sub GenerateFullSudokuSolution()
        ' Implémentez ici un générateur de Sudoku ou utilisez une grille prédéfinie
        ' Exemple de grille complète (ceci est un exemple statique, remplacez par une génération dynamique si nécessaire)
        Dim baseGrid(,) As Integer = {
                {5, 3, 4, 6, 7, 8, 9, 1, 2},
                {6, 7, 2, 1, 9, 5, 3, 4, 8},
                {1, 9, 8, 3, 4, 2, 5, 6, 7},
                {8, 5, 9, 7, 6, 1, 4, 2, 3},
                {4, 2, 6, 8, 5, 3, 7, 9, 1},
                {7, 1, 3, 9, 2, 4, 8, 5, 6},
                {9, 6, 1, 5, 3, 7, 2, 8, 4},
                {2, 8, 7, 4, 1, 9, 6, 3, 5},
                {3, 4, 5, 2, 8, 6, 1, 7, 9}
            }
        Array.Copy(baseGrid, solutionGrid, baseGrid.Length)

        ' Exemple: Vider aléatoirement des cases pour le puzzle
        Dim rand As New Random()
        For row As Integer = 0 To 8
            For col As Integer = 0 To 8
                If rand.NextDouble() < 0.5 Then ' 50% de chance de vider une case
                    solutionGrid(row, col) = 0
                End If
            Next
        Next
    End Sub

    ' Gestionnaire de l'événement KeyPress pour les TextBox de la grille
    Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Permet uniquement les chiffres 1 à 9, et empêche le chiffre 0
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) OrElse e.KeyChar = "0"c Then
            e.Handled = True
        End If
    End Sub

    ' Gestionnaire de l'événement TextChanged pour les TextBox de la grille
    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs)
        Dim txtBox As TextBox = CType(sender, TextBox)
        Dim pos As Point = txtBox.Location

        ' Calculer la position dans la grille
        Dim row As Integer = (pos.Y - 70) \ (txtBox.Height + 2)
        Dim col As Integer = (pos.X) \ (txtBox.Width + 2)

        ' Vérifier si l'entrée est valide
        If Not String.IsNullOrEmpty(txtBox.Text) AndAlso Not IsValidEntry(row, col, Integer.Parse(txtBox.Text)) Then
            txtBox.ForeColor = Color.Red
        Else
            txtBox.ForeColor = Color.Black
        End If

        ' Vérifier si le jeu est complété
        If IsGameCompleted() Then
            gameTimer.Stop()
            MessageBox.Show("Félicitations ! Vous avez complété le Sudoku.", "Jeu Terminé", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EndGame(True)
        End If
    End Sub

    ' Méthode pour vérifier si une entrée est valide dans la grille de Sudoku
    Private Function IsValidEntry(row As Integer, col As Integer, value As Integer) As Boolean
        ' Vérifier la ligne
        For i As Integer = 0 To 8
            If i <> col AndAlso sudokuGrid(row, i).Text = value.ToString() Then
                Return False
            End If
        Next

        ' Vérifier la colonne
        For i As Integer = 0 To 8
            If i <> row AndAlso sudokuGrid(i, col).Text = value.ToString() Then
                Return False
            End If
        Next

        ' Vérifier la région 3x3
        Dim startRow As Integer = (row \ 3) * 3
        Dim startCol As Integer = (col \ 3) * 3
        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                Dim r As Integer = startRow + i
                Dim c As Integer = startCol + j
                If (r <> row OrElse c <> col) AndAlso sudokuGrid(r, c).Text = value.ToString() Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    ' Méthode pour vérifier si le jeu est complété
    Private Function IsGameCompleted() As Boolean
        For row As Integer = 0 To 8
            For col As Integer = 0 To 8
                If String.IsNullOrEmpty(sudokuGrid(row, col).Text) OrElse sudokuGrid(row, col).ForeColor = Color.Red Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    ' Méthode pour terminer le jeu
    Private Sub EndGame(isCompleted As Boolean)
        ' Arrêter la musique
        player.controls.stop()
        player.close()

        Dim totalTimePlayed As TimeSpan = DateTime.Now - gameStartTime

        currentPlayer.GamesPlayed += 1
        currentPlayer.TotalTimePlayed += totalTimePlayed

        ' Mettre à jour le meilleur temps si le jeu est complété
        If isCompleted AndAlso (currentPlayer.BestTime = TimeSpan.Zero OrElse totalTimePlayed < currentPlayer.BestTime) Then
            currentPlayer.BestTime = totalTimePlayed
        End If

        Me.Close()
    End Sub

    ' Événement déclenché lors du clic sur le bouton de retour au menu principal
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult = MessageBox.Show("Êtes-vous sûr de vouloir revenir au Menu Principal ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            EndGame(False)
        End If
    End Sub

    ' Événement déclenché lors du clic sur le bouton de génération d'une nouvelle grille
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Générer une nouvelle grille aléatoire
        LoadInitialSudokuPuzzle()
    End Sub

    ' Événement déclenché lors du clic sur le bouton de révélation de la solution
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Révéler la solution complète pour chaque case dans la grille
        For row As Integer = 0 To 8
            For col As Integer = 0 To 8
                ' Assurez-vous que la grille de solution contient les valeurs initiales correctes
                ' Voici un exemple de solution fixe. Assurez-vous que solutionGrid est correctement initialisé ailleurs dans votre code.
                Dim baseGrid(,) As Integer = {
                        {5, 3, 4, 6, 7, 8, 9, 1, 2},
                        {6, 7, 2, 1, 9, 5, 3, 4, 8},
                        {1, 9, 8, 3, 4, 2, 5, 6, 7},
                        {8, 5, 9, 7, 6, 1, 4, 2, 3},
                        {4, 2, 6, 8, 5, 3, 7, 9, 1},
                        {7, 1, 3, 9, 2, 4, 8, 5, 6},
                        {9, 6, 1, 5, 3, 7, 2, 8, 4},
                        {2, 8, 7, 4, 1, 9, 6, 3, 5},
                        {3, 4, 5, 2, 8, 6, 1, 7, 9}
                    }
                Array.Copy(baseGrid, solutionGrid, baseGrid.Length)

                sudokuGrid(row, col).Text = solutionGrid(row, col).ToString()
                sudokuGrid(row, col).ReadOnly = True  ' Rendre la case non modifiable
                sudokuGrid(row, col).BackColor = Color.LightGray ' Changer la couleur de fond pour indiquer une case de solution
            Next
        Next

        ' Désactiver le bouton de solution pour éviter de multiples utilisations et le bouton aléatoire
        Button3.Enabled = False
        Button2.Enabled = False

        ' Arrêter le timer puisque le jeu est terminé avec la révélation de la solution
        gameTimer.Stop()

        ' Afficher un message indiquant que la solution a été révélée
        MessageBox.Show("Solution révélée.", "Sudoku Solution", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
