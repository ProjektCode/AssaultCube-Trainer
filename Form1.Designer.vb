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
        Me.components = New System.ComponentModel.Container()
        Me.cbAmmo = New System.Windows.Forms.CheckBox()
        Me.timerAmmo = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbAimBot = New System.Windows.Forms.CheckBox()
        Me.cbKevlar = New System.Windows.Forms.CheckBox()
        Me.cbGodMode = New System.Windows.Forms.CheckBox()
        Me.timerGod = New System.Windows.Forms.Timer(Me.components)
        Me.timerKevlar = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbAmmo
        '
        Me.cbAmmo.AutoSize = True
        Me.cbAmmo.ForeColor = System.Drawing.Color.White
        Me.cbAmmo.Location = New System.Drawing.Point(5, 5)
        Me.cbAmmo.Name = "cbAmmo"
        Me.cbAmmo.Size = New System.Drawing.Size(118, 19)
        Me.cbAmmo.TabIndex = 0
        Me.cbAmmo.Text = "Unlimited Ammo"
        Me.cbAmmo.UseVisualStyleBackColor = True
        '
        'timerAmmo
        '
        Me.timerAmmo.Interval = 10
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Crimson
        Me.Panel1.Controls.Add(Me.cbAimBot)
        Me.Panel1.Controls.Add(Me.cbKevlar)
        Me.Panel1.Controls.Add(Me.cbGodMode)
        Me.Panel1.Controls.Add(Me.cbAmmo)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 302)
        Me.Panel1.TabIndex = 1
        '
        'cbAimBot
        '
        Me.cbAimBot.AutoSize = True
        Me.cbAimBot.ForeColor = System.Drawing.Color.White
        Me.cbAimBot.Location = New System.Drawing.Point(5, 80)
        Me.cbAimBot.Name = "cbAimBot"
        Me.cbAimBot.Size = New System.Drawing.Size(66, 19)
        Me.cbAimBot.TabIndex = 3
        Me.cbAimBot.Text = "AimBot"
        Me.cbAimBot.UseVisualStyleBackColor = True
        '
        'cbKevlar
        '
        Me.cbKevlar.AutoSize = True
        Me.cbKevlar.ForeColor = System.Drawing.Color.White
        Me.cbKevlar.Location = New System.Drawing.Point(5, 55)
        Me.cbKevlar.Name = "cbKevlar"
        Me.cbKevlar.Size = New System.Drawing.Size(113, 19)
        Me.cbKevlar.TabIndex = 2
        Me.cbKevlar.Text = "Unlimited Kevlar"
        Me.cbKevlar.UseVisualStyleBackColor = True
        '
        'cbGodMode
        '
        Me.cbGodMode.AutoSize = True
        Me.cbGodMode.ForeColor = System.Drawing.Color.White
        Me.cbGodMode.Location = New System.Drawing.Point(5, 30)
        Me.cbGodMode.Name = "cbGodMode"
        Me.cbGodMode.Size = New System.Drawing.Size(82, 19)
        Me.cbGodMode.TabIndex = 1
        Me.cbGodMode.Text = "God Mode"
        Me.cbGodMode.UseVisualStyleBackColor = True
        '
        'timerGod
        '
        Me.timerGod.Interval = 10
        '
        'timerKevlar
        '
        Me.timerKevlar.Interval = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Projekt Assualt Cube Trainer"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cbAmmo As CheckBox
    Friend WithEvents timerAmmo As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cbGodMode As CheckBox
    Friend WithEvents timerGod As Timer
    Friend WithEvents cbKevlar As CheckBox
    Friend WithEvents timerKevlar As Timer
    Friend WithEvents cbAimBot As CheckBox
End Class
