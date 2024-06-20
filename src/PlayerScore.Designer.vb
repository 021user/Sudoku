<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlayerScore
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListBoxPlayerScores = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'ListBoxPlayerScores
        '
        Me.ListBoxPlayerScores.FormattingEnabled = True
        Me.ListBoxPlayerScores.ItemHeight = 31
        Me.ListBoxPlayerScores.Location = New System.Drawing.Point(639, 371)
        Me.ListBoxPlayerScores.Name = "ListBoxPlayerScores"
        Me.ListBoxPlayerScores.Size = New System.Drawing.Size(577, 283)
        Me.ListBoxPlayerScores.TabIndex = 0
        '
        'PlayerScore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1826, 1260)
        Me.Controls.Add(Me.ListBoxPlayerScores)
        Me.Name = "PlayerScore"
        Me.Text = "PlayerScore"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListBoxPlayerScores As ListBox
End Class
