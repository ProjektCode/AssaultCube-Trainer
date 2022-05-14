Imports Memory
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Threading

Public Class Form1
    ReadOnly m As New Mem
    Dim isAimbot As Boolean = False
    Dim viewY As Single

    <DllImport("user32.dll")>
    Public Shared Function GetAsyncKeyState(ByVal vKey As System.Windows.Forms.Keys) As Short
    End Function

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text += $" {Assembly.GetExecutingAssembly().GetName().Version}"
        CheckForIllegalCrossThreadCalls = False
        Dim pid As Integer = m.GetProcIdFromName("ac_client")
        If pid > 0 Then
            m.OpenProcess(pid)
            Timer1.Start()
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

    Private Sub cbAimBot_CheckedChanged(sender As Object, e As EventArgs) Handles cbAimBot.CheckedChanged
        If cbAimBot.Checked = True Then
            isAimbot = True
            Dim AB As New Thread(New ThreadStart(AddressOf Aimbot))
            AB.Start()
        Else
            isAimbot = False
        End If
    End Sub

    Private Sub cbNoRecoil_CheckedChanged(sender As Object, e As EventArgs) Handles cbNoRecoil.CheckedChanged
        If cbNoRecoil.Checked = True Then
            timerNoRecoil.Start()
        Else
            timerNoRecoil.Stop()
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

    Private Sub timerNoRecoil_Tick(sender As Object, e As EventArgs) Handles timerNoRecoil.Tick
        If GetAsyncKeyState(Keys.LButton) < 0 Then
            m.WriteMemory(Offsets.ViewAngleY, "float", viewY)
        Else
            viewY = m.ReadFloat(Offsets.ViewAngleY).ToString()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = m.ReadFloat(Offsets.ViewAngleY).ToString()
    End Sub
#End Region

#Region "Aimbot"
    Private Sub Aimbot()
        Thread.Sleep(1000)
        Do
            If isAimbot = True Then
                Dim localplayer = GetLocalPlayer()
                Dim players = GetPlayers(localplayer)

                players = players.OrderBy(Function(x) x.Magnitude).ToList()
                If players.Count <> 0 Then
                    Aim(localplayer, players(0))
                End If

                Thread.Sleep(100)
            Else
                Exit Do
            End If
        Loop
    End Sub
    Private Function GetLocalPlayer() As Player
        Dim player As New Player With {
            .X = m.ReadFloat(Offsets.X),
            .Y = m.ReadFloat(Offsets.Y),
            .Z = m.ReadFloat(Offsets.Z)
        }

        Return player
    End Function

    Public Shared Function GetMag(p As Player, e As Player) As Single
        Dim mag As Single

        mag = Convert.ToSingle(Math.Sqrt(Math.Pow(e.X - p.X, 2) + Math.Pow(e.Y - p.Y, 2) + Math.Pow(e.Z - p.Z, 2)))

        Return mag
    End Function

    Private Sub Aim(p As Player, e As Player)
        Dim deltaX As Single = e.X - p.X
        Dim deltaY As Single = e.Y - p.Y

        Dim viewX As Single = CSng(Math.Atan2(deltaY, deltaX) * 180 / Math.PI) + 90

        Dim deltaZ = e.Z - p.Z

        Dim distance As Double = Math.Sqrt(deltaX * deltaX + deltaY * deltaY)

        Dim viewY As Single = CSng(Math.Atan2(deltaZ, distance) * 180 / Math.PI)

        m.WriteMemory(Offsets.ViewAngleX, "float", viewX.ToString())
        m.WriteMemory(Offsets.ViewAngleY, "float", viewY.ToString())

    End Sub

    Private Function GetPlayers(local As Player) As List(Of Player)
        Dim Players As New List(Of Player)

        For i As Integer = 0 To 45
            Dim currentStr = Offsets.EntityList + ",0x" + (i * &H4).ToString("X")
            Dim player As New Player With {
                .X = m.ReadFloat(currentStr + Offsets.xOffset),
                .Y = m.ReadFloat(currentStr + Offsets.yOffset),
                .Z = m.ReadFloat(currentStr + Offsets.zOffset),
                .Health = m.ReadInt(currentStr + Offsets.HealthOffset)
            }
            player.Magnitude = GetMag(local, player)


            If player.Health > 0 And player.Health < 102 Then
                Players.Add(player)
            End If

        Next i

        Return Players
    End Function
#End Region

End Class