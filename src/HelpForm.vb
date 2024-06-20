Public Class HelpForm
    Private Sub HelpForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Règles du Sudoku"
        Me.BackColor = Color.LightBlue
        Me.Size = New Size(400, 300)

        Dim lblRules As New Label()
        lblRules.Text = "Bienvenue dans le guide du Sudoku! Voici comment jouer:" & Environment.NewLine &
                        "1. Chaque ligne doit contenir les chiffres de 1 à 9, sans répétition." & Environment.NewLine &
                        "2. Chaque colonne doit également contenir les chiffres de 1 à 9, sans répétition." & Environment.NewLine &
                        "3. Chaque section 3x3 doit contenir les chiffres de 1 à 9, sans répétition."
        lblRules.Size = New Size(380, 280)
        lblRules.Location = New Point(10, 10)
        lblRules.Font = New Font("Arial", 10)
        Me.Controls.Add(lblRules)
    End Sub
End Class
