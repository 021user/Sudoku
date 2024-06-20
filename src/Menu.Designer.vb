<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Saisie_Nom = New System.Windows.Forms.ComboBox()
        Me.ButtonGameStart = New System.Windows.Forms.Button()
        Me.Leave = New System.Windows.Forms.Button()
        Me.Score = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RickRoll = New System.Windows.Forms.Button()
        Me.pnlNiveau = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGame16x16 = New System.Windows.Forms.Button()
        Me.btnGame9x9 = New System.Windows.Forms.Button()
        Me.AxWindowsMediaPlayer2 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.pnlNiveau.SuspendLayout()
        CType(Me.AxWindowsMediaPlayer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Saisie_Nom
        '
        Me.Saisie_Nom.BackColor = System.Drawing.Color.DimGray
        Me.Saisie_Nom.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Saisie_Nom.FormattingEnabled = True
        Me.Saisie_Nom.Location = New System.Drawing.Point(1690, 719)
        Me.Saisie_Nom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Saisie_Nom.Name = "Saisie_Nom"
        Me.Saisie_Nom.Size = New System.Drawing.Size(748, 39)
        Me.Saisie_Nom.TabIndex = 0
        '
        'ButtonGameStart
        '
        Me.ButtonGameStart.BackColor = System.Drawing.Color.DimGray
        Me.ButtonGameStart.Location = New System.Drawing.Point(1774, 948)
        Me.ButtonGameStart.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonGameStart.Name = "ButtonGameStart"
        Me.ButtonGameStart.Size = New System.Drawing.Size(563, 198)
        Me.ButtonGameStart.TabIndex = 1
        Me.ButtonGameStart.Text = "Lancer une Partie"
        Me.ButtonGameStart.UseVisualStyleBackColor = False
        '
        'Leave
        '
        Me.Leave.BackColor = System.Drawing.Color.DimGray
        Me.Leave.Location = New System.Drawing.Point(1830, 1648)
        Me.Leave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Leave.Name = "Leave"
        Me.Leave.Size = New System.Drawing.Size(467, 122)
        Me.Leave.TabIndex = 4
        Me.Leave.Text = "Quitter"
        Me.Leave.UseVisualStyleBackColor = False
        '
        'Score
        '
        Me.Score.BackColor = System.Drawing.Color.DimGray
        Me.Score.Location = New System.Drawing.Point(1774, 1265)
        Me.Score.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Score.Name = "Score"
        Me.Score.Size = New System.Drawing.Size(563, 196)
        Me.Score.TabIndex = 5
        Me.Score.Text = "Voir le score"
        Me.Score.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1997, 633)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 32)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Pseudo :"
        '
        'RickRoll
        '
        Me.RickRoll.Location = New System.Drawing.Point(3721, 68)
        Me.RickRoll.Name = "RickRoll"
        Me.RickRoll.Size = New System.Drawing.Size(193, 89)
        Me.RickRoll.TabIndex = 86
        Me.RickRoll.Text = "Button1"
        Me.RickRoll.UseVisualStyleBackColor = True
        '
        'pnlNiveau
        '
        Me.pnlNiveau.BackColor = System.Drawing.Color.Transparent
        Me.pnlNiveau.Controls.Add(Me.Label2)
        Me.pnlNiveau.Controls.Add(Me.Label3)
        Me.pnlNiveau.Controls.Add(Me.btnGame16x16)
        Me.pnlNiveau.Controls.Add(Me.btnGame9x9)
        Me.pnlNiveau.Location = New System.Drawing.Point(1645, 872)
        Me.pnlNiveau.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.pnlNiveau.Name = "pnlNiveau"
        Me.pnlNiveau.Size = New System.Drawing.Size(820, 651)
        Me.pnlNiveau.TabIndex = 87
        Me.pnlNiveau.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Mistral", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(549, 379)
        Me.Label2.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 57)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "16x16"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Mistral", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(185, 382)
        Me.Label3.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 57)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "9x9"
        '
        'btnGame16x16
        '
        Me.btnGame16x16.BackColor = System.Drawing.Color.Transparent
        Me.btnGame16x16.BackgroundImage = CType(resources.GetObject("btnGame16x16.BackgroundImage"), System.Drawing.Image)
        Me.btnGame16x16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGame16x16.Location = New System.Drawing.Point(517, 222)
        Me.btnGame16x16.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btnGame16x16.Name = "btnGame16x16"
        Me.btnGame16x16.Size = New System.Drawing.Size(195, 136)
        Me.btnGame16x16.TabIndex = 7
        Me.btnGame16x16.Tag = "4"
        Me.btnGame16x16.UseVisualStyleBackColor = False
        '
        'btnGame9x9
        '
        Me.btnGame9x9.BackColor = System.Drawing.Color.Transparent
        Me.btnGame9x9.BackgroundImage = CType(resources.GetObject("btnGame9x9.BackgroundImage"), System.Drawing.Image)
        Me.btnGame9x9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGame9x9.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnGame9x9.Location = New System.Drawing.Point(140, 222)
        Me.btnGame9x9.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btnGame9x9.Name = "btnGame9x9"
        Me.btnGame9x9.Size = New System.Drawing.Size(181, 136)
        Me.btnGame9x9.TabIndex = 8
        Me.btnGame9x9.Tag = "3"
        Me.btnGame9x9.UseVisualStyleBackColor = False
        '
        'AxWindowsMediaPlayer2
        '
        Me.AxWindowsMediaPlayer2.Enabled = True
        Me.AxWindowsMediaPlayer2.Location = New System.Drawing.Point(2765, 633)
        Me.AxWindowsMediaPlayer2.Name = "AxWindowsMediaPlayer2"
        Me.AxWindowsMediaPlayer2.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer2.Size = New System.Drawing.Size(145, 182)
        Me.AxWindowsMediaPlayer2.TabIndex = 85
        Me.AxWindowsMediaPlayer2.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(3844, 2268)
        Me.Controls.Add(Me.pnlNiveau)
        Me.Controls.Add(Me.RickRoll)
        Me.Controls.Add(Me.AxWindowsMediaPlayer2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Score)
        Me.Controls.Add(Me.Leave)
        Me.Controls.Add(Me.ButtonGameStart)
        Me.Controls.Add(Me.Saisie_Nom)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnlNiveau.ResumeLayout(False)
        Me.pnlNiveau.PerformLayout()
        CType(Me.AxWindowsMediaPlayer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Saisie_Nom As ComboBox
    Friend WithEvents ButtonGameStart As Button
    Friend WithEvents Leave As Button
    Friend WithEvents Score As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents AxWindowsMediaPlayer2 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents RickRoll As Button
    Friend WithEvents pnlNiveau As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnGame16x16 As Button
    Friend WithEvents btnGame9x9 As Button
End Class
