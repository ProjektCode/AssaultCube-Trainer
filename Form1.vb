Imports Memory
Imports System.Reflection
Imports System.Threading

Public Class Form1
    ReadOnly m As New Mem
    Dim player As New Player

    Private Shared ReadOnly PlayerBase As String = "ac_client.exe+0x109B74"
    Private Shared ReadOnly X As String = $"{PlayerBase},0x34"
    Private Shared ReadOnly Y As String = $"{PlayerBase},0x38"
    Private Shared ReadOnly Z As String = $"{PlayerBase},0x3C"
    Private Shared ReadOnly ViewAngleY = $"{PlayerBase},0x44"
    Private Shared ReadOnly ViewAngleX = $"{PlayerBase},0x40"

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text += $" {Assembly.GetExecutingAssembly().GetName().Version}"
        CheckForIllegalCrossThreadCalls = False
        Dim pid As Integer = m.GetProcIdFromName("ac_client")
        If pid > 0 Then
            m.OpenProcess(pid)
            Dim AB As New Thread(CType(Main(), ThreadStart)) With {
                .IsBackground = True
            }
            AB.Start()
        Else
            MessageBox.Show("Please open Assault Cube before starting the trainer.")
            Environment.Exit(0)
        End If
    End Sub

#Region "CheckBoxes"
    Private Sub cbAmmo_CheckedChanged(sender As Object, e As EventArgs) Handles cbAmmo.CheckedChanged
        If cbAmmo.Checked = True Then
            timerAmmo.Start()
        Else
            timerAmmo.Stop()
            m.WriteMemory(Offsets.BarAmmo, "int", "20")
            m.WriteMemory(Offsets.PistolAmmo, "int", "10")
            m.WriteMemory(Offsets.AkimboAmmo, "int", "20")
        End If
    End Sub

    Private Sub cbGodMode_CheckedChanged(sender As Object, e As EventArgs) Handles cbGodMode.CheckedChanged
        If cbGodMode.Checked = True Then
            timerGod.Start()
        Else
            timerGod.Stop()
            m.WriteMemory(Offsets.Health, "int", "100")
        End If
    End Sub
    Private Sub cbKevlar_CheckedChanged(sender As Object, e As EventArgs) Handles cbKevlar.CheckedChanged
        If cbKevlar.Checked = True Then
            timerKevlar.Start()
        Else
            timerKevlar.Stop()
            m.WriteMemory(Offsets.Kevlar, "int", "0")
        End If
    End Sub
#End Region

#Region "Timers"
    Private Sub TimerAmmo_Tick(sender As Object, e As EventArgs) Handles timerAmmo.Tick
        m.WriteMemory(Offsets.BarAmmo, "int", "999")
        m.WriteMemory(Offsets.PistolAmmo, "int", "999")
        m.WriteMemory(Offsets.AkimboAmmo, "int", "999")
    End Sub
    Private Sub timerGod_Tick(sender As Object, e As EventArgs) Handles timerGod.Tick
        m.WriteMemory(Offsets.Health, "int", "999")
    End Sub

    Private Sub timerKevlar_Tick(sender As Object, e As EventArgs) Handles timerKevlar.Tick
        m.WriteMemory(Offsets.Kevlar, "int", "100")
    End Sub
#End Region

#Region "Aimbot"
    Public Function Main()
        While True
            GetLocalPlayer()

            Threading.Thread.Sleep(10)
        End While
    End Function

    Private Function GetLocalPlayer() As Player
        Dim player As New Player With {
            .X = m.ReadFloat(Offsets.X),
            .Y = m.ReadFloat(Offsets.Y),
            .Z = m.ReadFloat(Offsets.Z)
        }

        Return player
    End Function
#End Region

End Class