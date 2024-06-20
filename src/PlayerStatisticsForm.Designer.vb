<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PlayerStatisticsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PlayersListBox = New System.Windows.Forms.ListBox()
        Me.BestTimesListBox = New System.Windows.Forms.ListBox()
        Me.SearchPlayerComboBox = New System.Windows.Forms.ComboBox()
        Me.SortPlayersByNameButton = New System.Windows.Forms.Button()
        Me.SortPlayersByBestTimeButton = New System.Windows.Forms.Button()
        Me.Leave = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PlayersListBox
        '
        Me.PlayersListBox.FormattingEnabled = True
        Me.PlayersListBox.ItemHeight = 31
        Me.PlayersListBox.Location = New System.Drawing.Point(950, 194)
        Me.PlayersListBox.Name = "PlayersListBox"
        Me.PlayersListBox.Size = New System.Drawing.Size(270, 283)
        Me.PlayersListBox.TabIndex = 0
        '
        'BestTimesListBox
        '
        Me.BestTimesListBox.FormattingEnabled = True
        Me.BestTimesListBox.ItemHeight = 31
        Me.BestTimesListBox.Location = New System.Drawing.Point(1369, 194)
        Me.BestTimesListBox.Name = "BestTimesListBox"
        Me.BestTimesListBox.Size = New System.Drawing.Size(249, 283)
        Me.BestTimesListBox.TabIndex = 1
        '
        'SearchPlayerComboBox
        '
        Me.SearchPlayerComboBox.FormattingEnabled = True
        Me.SearchPlayerComboBox.Location = New System.Drawing.Point(1567, 680)
        Me.SearchPlayerComboBox.Name = "SearchPlayerComboBox"
        Me.SearchPlayerComboBox.Size = New System.Drawing.Size(292, 39)
        Me.SearchPlayerComboBox.TabIndex = 2
        '
        'SortPlayersByNameButton
        '
        Me.SortPlayersByNameButton.Location = New System.Drawing.Point(1369, 832)
        Me.SortPlayersByNameButton.Name = "SortPlayersByNameButton"
        Me.SortPlayersByNameButton.Size = New System.Drawing.Size(278, 129)
        Me.SortPlayersByNameButton.TabIndex = 3
        Me.SortPlayersByNameButton.Text = "Nom Joueur"
        Me.SortPlayersByNameButton.UseVisualStyleBackColor = True
        '
        'SortPlayersByBestTimeButton
        '
        Me.SortPlayersByBestTimeButton.Location = New System.Drawing.Point(1765, 832)
        Me.SortPlayersByBestTimeButton.Name = "SortPlayersByBestTimeButton"
        Me.SortPlayersByBestTimeButton.Size = New System.Drawing.Size(278, 129)
        Me.SortPlayersByBestTimeButton.TabIndex = 4
        Me.SortPlayersByBestTimeButton.Text = "Meilleur Temps"
        Me.SortPlayersByBestTimeButton.UseVisualStyleBackColor = True
        '
        'Leave
        '
        Me.Leave.Location = New System.Drawing.Point(1589, 1053)
        Me.Leave.Name = "Leave"
        Me.Leave.Size = New System.Drawing.Size(222, 136)
        Me.Leave.TabIndex = 5
        Me.Leave.Text = "leave"
        Me.Leave.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 31
        Me.ListBox1.Location = New System.Drawing.Point(1776, 194)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(249, 283)
        Me.ListBox1.TabIndex = 6
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 31
        Me.ListBox2.Location = New System.Drawing.Point(2166, 194)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(249, 283)
        Me.ListBox2.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1043, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 32)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Nom"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1391, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 32)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Meilleur Temps"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2166, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(249, 32)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Total Temps Jouer"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1747, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(313, 32)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Nombre de Partie Jouer"
        '
        'PlayerStatisticsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2996, 1419)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Leave)
        Me.Controls.Add(Me.SortPlayersByBestTimeButton)
        Me.Controls.Add(Me.SortPlayersByNameButton)
        Me.Controls.Add(Me.SearchPlayerComboBox)
        Me.Controls.Add(Me.BestTimesListBox)
        Me.Controls.Add(Me.PlayersListBox)
        Me.Name = "PlayerStatisticsForm"
        Me.Text = "PlayerStatisticsForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PlayersListBox As ListBox
    Friend WithEvents BestTimesListBox As ListBox
    Friend WithEvents SearchPlayerComboBox As ComboBox
    Friend WithEvents SortPlayersByNameButton As Button
    Friend WithEvents SortPlayersByBestTimeButton As Button
    Friend WithEvents Leave As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
