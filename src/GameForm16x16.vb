Imports System.Windows.Forms
Imports AxWMPLib
Imports WMPLib

Public Class GameForm16x16
    Private sudokuGrid16x16(15, 15) As TextBox ' Grille de Sudoku constituée de TextBox pour une grille 16x16
    Private WithEvents gameTimer16x16 As Timer ' Timer pour le compte à rebours du jeu
    Private timeLeft16x16 As Integer = 20 * 60 ' Temps restant en secondes (20 minutes pour 16x16)
    Private currentPlayer16x16 As Player ' Joueur actuel
    Private gameStartTime16x16 As DateTime ' Heure de début de la partie
    Private WithEvents player16x16 As WindowsMediaPlayer ' Lecteur Windows Media Player
    Private solutionGrid16x16(15, 15) As Integer ' Grille de solution pour le bouton de solution
    Private loading As Boolean ' Indicateur de chargement

    ' Constructeur de la classe recevant un joueur en paramètre
    Public Sub New(player As Player)
        Me.currentPlayer16x16 = player
        InitializeComponent16x16()
        InitializeSudokuGrid16x16()
        LoadInitialSudokuPuzzle16x16()
        gameStartTime16x16 = DateTime.Now

        ' Initialisez le lecteur Windows Media Player ici avec un chemin relatif
        Me.player16x16 = New WindowsMediaPlayer()
        Me.player16x16.settings.setMode("loop", True)
        Me.player16x16.URL = "Ressources\05 Sm64ds Luigi's Casino(1).mp3"
        Me.player16x16.controls.play()
    End Sub


    ' Méthode pour initialiser les composants de l'interface utilisateur
    Private Sub InitializeComponent16x16()
        Me.SuspendLayout()
        ' 
        ' GameForm16x16
        ' 
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Name = "GameForm16x16"

        Me.ResumeLayout(False)

        ' Configure la fenêtre pour être sans bordure et maximisée
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized

        ' Définit l'image de fond et la couleur de fond
        Me.BackgroundImage = Image.FromFile("Ressources\8f1ab8b14a55720d6859620a6f596933.jpg")
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Me.BackColor = Color.SkyBlue

        ' Initialiser le Timer de jeu
        InitializeGameTimer16x16()

        ' Ajouter des boutons et autres composants
        Dim button1 As New Button With {.Text = "Retour au menu", .Location = New Point(10, 10)}
        AddHandler button1.Click, AddressOf Button1_Click_1
        Me.Controls.Add(button1)

        Dim button2 As New Button With {.Text = "Nouvelle Grille", .Location = New Point(10, 50)}
        AddHandler button2.Click, AddressOf Button2_Click_1
        Me.Controls.Add(button2)



        Dim timerLabel16x16 As New Label With {
            .Name = "TimerLabel16x16",
            .Location = New Point(10, 130),
            .Font = New Font("Arial", 10, FontStyle.Bold),
            .AutoSize = True
        }
        Me.Controls.Add(timerLabel16x16)
    End Sub

    ' Méthode pour initialiser la grille de Sudoku
    Private Sub InitializeSudokuGrid16x16()
        Dim textBoxSize As Integer = 35 ' Ajusté pour une grille plus grande
        Dim spacing As Integer = 1
        Dim totalGridSize As Integer = (textBoxSize + spacing) * 16
        Dim startX As Integer = (Me.ClientSize.Width - totalGridSize) \ 2 + 80 ' Décalage vers la droite de 20 pixels
        Dim startY As Integer = (Me.ClientSize.Height - totalGridSize) \ 2


        For row As Integer = 0 To 15
            For col As Integer = 0 To 15
                sudokuGrid16x16(row, col) = New TextBox With {
                .Width = textBoxSize,
                .Height = textBoxSize,
                .Location = New Point(startX + (textBoxSize + spacing) * col, startY + (textBoxSize + spacing) * row),
                .TextAlign = HorizontalAlignment.Center,
                .Font = New Font("Arial", 10, FontStyle.Bold),
                .MaxLength = 2 ' Permet d'entrer des chiffres de 1 à 16 (affiché en 2 caractères)
            }
                AddHandler sudokuGrid16x16(row, col).KeyPress, AddressOf TextBox_KeyPress16x16
                AddHandler sudokuGrid16x16(row, col).TextChanged, AddressOf TextBox_TextChanged16x16
                Me.Controls.Add(sudokuGrid16x16(row, col))
            Next
        Next
    End Sub


    ' Méthode pour initialiser le Timer de jeu
    Private Sub InitializeGameTimer16x16()
        gameTimer16x16 = New Timer()
        gameTimer16x16.Interval = 1000 ' Intervalle de 1 seconde
        AddHandler gameTimer16x16.Tick, AddressOf GameTimer_Tick16x16
        gameTimer16x16.Start()
    End Sub

    ' Gestionnaire de l'événement Tick du Timer
    Private Sub GameTimer_Tick16x16(sender As Object, e As EventArgs)
        If timeLeft16x16 > 0 Then
            timeLeft16x16 -= 1
            UpdateTimerDisplay16x16()
        Else
            gameTimer16x16.Stop()
            MessageBox.Show("Temps écoulé !", "Fin du jeu", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EndGame16x16(False)
        End If
    End Sub

    ' Méthode pour mettre à jour l'affichage du Timer
    Private Sub UpdateTimerDisplay16x16()
        Dim timerLabel16x16 As Label = CType(Me.Controls("TimerLabel16x16"), Label)
        Dim minutes As Integer = timeLeft16x16 \ 60
        Dim seconds As Integer = timeLeft16x16 Mod 60
        If timerLabel16x16 IsNot Nothing Then
            timerLabel16x16.Text = $"Temps restant : {minutes:D2}:{seconds:D2}"
        End If
    End Sub

    ' Méthode pour charger le puzzle initial de Sudoku
    Private Sub LoadInitialSudokuPuzzle16x16()
        loading = True ' Début du chargement
        GenerateFullSudokuSolution16x16()
        For row As Integer = 0 To 15
            For col As Integer = 0 To 15
                If solutionGrid16x16(row, col) = 0 Then
                    sudokuGrid16x16(row, col).Text = ""
                    sudokuGrid16x16(row, col).ReadOnly = False
                    sudokuGrid16x16(row, col).BackColor = Color.White
                Else
                    sudokuGrid16x16(row, col).Text = solutionGrid16x16(row, col).ToString()
                    sudokuGrid16x16(row, col).ReadOnly = True
                    sudokuGrid16x16(row, col).BackColor = Color.LightGray
                End If
            Next
        Next
        loading = False ' Fin du chargement
    End Sub

    ' Méthode pour générer une solution complète de Sudoku
    Private Sub GenerateFullSudokuSolution16x16()
        ' Une grille 16x16 valide. Remplacer par une génération dynamique si nécessaire.
        Dim baseGrid(,) As Integer = {
            {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16},
            {5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 1, 2, 3, 4},
            {9, 10, 11, 12, 13, 14, 15, 16, 1, 2, 3, 4, 5, 6, 7, 8},
            {13, 14, 15, 16, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12},
            {2, 3, 4, 1, 6, 7, 8, 5, 10, 11, 12, 9, 14, 15, 16, 13},
            {6, 7, 8, 5, 10, 11, 12, 9, 14, 15, 16, 13, 2, 3, 4, 1},
            {10, 11, 12, 9, 14, 15, 16, 13, 2, 3, 4, 1, 6, 7, 8, 5},
            {14, 15, 16, 13, 2, 3, 4, 1, 6, 7, 8, 5, 10, 11, 12, 9},
            {3, 4, 1, 2, 7, 8, 5, 6, 11, 12, 9, 10, 15, 16, 13, 14},
            {7, 8, 5, 6, 11, 12, 9, 10, 15, 16, 13, 14, 3, 4, 1, 2},
            {11, 12, 9, 10, 15, 16, 13, 14, 3, 4, 1, 2, 7, 8, 5, 6},
            {15, 16, 13, 14, 3, 4, 1, 2, 7, 8, 5, 6, 11, 12, 9, 10},
            {4, 1, 2, 3, 8, 5, 6, 7, 12, 9, 10, 11, 16, 13, 14, 15},
            {8, 5, 6, 7, 12, 9, 10, 11, 16, 13, 14, 15, 4, 1, 2, 3},
            {12, 9, 10, 11, 16, 13, 14, 15, 4, 1, 2, 3, 8, 5, 6, 7},
            {16, 13, 14, 15, 4, 1, 2, 3, 8, 5, 6, 7, 12, 9, 10, 11}
        }
        Array.Copy(baseGrid, solutionGrid16x16, baseGrid.Length)

        ' Exemple: Vider aléatoirement des cases pour le puzzle
        Dim rand As New Random()
        For row As Integer = 0 To 15
            For col As Integer = 0 To 15
                If rand.NextDouble() < 0.5 Then ' 50% de chance de vider une case
                    solutionGrid16x16(row, col) = 0
                End If
            Next
        Next
    End Sub

    ' Gestionnaire de l'événement KeyPress pour les TextBox de la grille
    Private Sub TextBox_KeyPress16x16(sender As Object, e As KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) AndAlso Integer.Parse(e.KeyChar.ToString()) >= 1 AndAlso Integer.Parse(e.KeyChar.ToString()) <= 9) AndAlso Not (Char.IsLetter(e.KeyChar) AndAlso "A"c <= e.KeyChar AndAlso e.KeyChar <= "G"c) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Gestionnaire de l'événement TextChanged pour les TextBox de la grille
    Private Sub TextBox_TextChanged16x16(sender As Object, e As EventArgs)
        If Not loading Then
            Dim txtBox As TextBox = CType(sender, TextBox)
            Dim pos As Point = txtBox.Location
            Dim row As Integer = (pos.Y - sudokuGrid16x16(0, 0).Location.Y) \ (txtBox.Height + 1)
            Dim col As Integer = (pos.X - sudokuGrid16x16(0, 0).Location.X) \ (txtBox.Width + 1)
            If row >= 0 AndAlso row <= 15 AndAlso col >= 0 AndAlso col <= 15 Then
                If Not String.IsNullOrEmpty(txtBox.Text) AndAlso Not IsValidEntry16x16(row, col, txtBox.Text) Then
                    txtBox.ForeColor = Color.Red
                Else
                    txtBox.ForeColor = Color.Black
                End If
                If IsGameCompleted16x16() Then
                    gameTimer16x16.Stop()
                    MessageBox.Show("Félicitations ! Vous avez complété le Sudoku.", "Jeu Terminé", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    EndGame16x16(True)
                End If
            End If
        End If
    End Sub

    ' Méthode pour vérifier si une entrée est valide dans la grille de Sudoku
    Private Function IsValidEntry16x16(row As Integer, col As Integer, value As String) As Boolean
        ' Vérifier la ligne
        For i As Integer = 0 To 15
            If i <> col AndAlso sudokuGrid16x16(row, i).Text = value Then
                Return False
            End If
        Next

        ' Vérifier la colonne
        For i As Integer = 0 To 15
            If i <> row AndAlso sudokuGrid16x16(i, col).Text = value Then
                Return False
            End If
        Next

        ' Vérifier la région 4x4
        Dim startRow As Integer = (row \ 4) * 4
        Dim startCol As Integer = (col \ 4) * 4
        For i As Integer = 0 To 3
            For j As Integer = 0 To 3
                Dim r As Integer = startRow + i
                Dim c As Integer = startCol + j
                If (r <> row OrElse c <> col) AndAlso sudokuGrid16x16(r, c).Text = value Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    ' Méthode pour vérifier si le jeu est complété
    Private Function IsGameCompleted16x16() As Boolean
        For row As Integer = 0 To 15
            For col As Integer = 0 To 15
                If String.IsNullOrEmpty(sudokuGrid16x16(row, col).Text) OrElse sudokuGrid16x16(row, col).ForeColor = Color.Red Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    ' Méthode pour terminer le jeu
    Private Sub EndGame16x16(isCompleted As Boolean)
        player16x16.controls.stop()
        player16x16.close()
        Me.Close()
    End Sub

    ' Gestionnaires pour les boutons
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As DialogResult = MessageBox.Show("Êtes-vous sûr de vouloir revenir au Menu Principal ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            EndGame16x16(False)
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        LoadInitialSudokuPuzzle16x16()
    End Sub



    Private Sub GameForm16x16_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadInitialSudokuPuzzle16x16()
    End Sub
End Class
