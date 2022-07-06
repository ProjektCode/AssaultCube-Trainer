NotInheritable Class Offsets

    Public Shared ReadOnly PlayerBase As String = "ac_client.exe+0x109B74"
    Public Shared ReadOnly EntityList As String = "ac_client.exe+0x110D90"
    Public Shared ReadOnly BarAmmo As String = $"{PlayerBase},0x150"
    Public Shared ReadOnly PistolAmmo As String = $"{PlayerBase},0x13C"
    Public Shared ReadOnly AkimboAmmo As String = $"{PlayerBase},0x15C"
    Public Shared ReadOnly Health As String = $"{PlayerBase},0xF8"
    Public Shared ReadOnly Kevlar As String = $"{PlayerBase},0xFC"
    Public Shared ReadOnly X As String = $"{PlayerBase},0x34"
    Public Shared ReadOnly Y As String = $"{PlayerBase},0x38"
    Public Shared ReadOnly Z As String = $"{PlayerBase},0x3C"
    Public Shared ReadOnly ViewAngleY = $"{PlayerBase},0x44"
    Public Shared ReadOnly ViewAngleX = $"{PlayerBase},0x40"
    Public Shared ReadOnly Roll = $"{PlayerBase},0x48"

    Public Shared ReadOnly HealthOffset As String = ",0xF8"
    Public Shared ReadOnly xOffset As String = ",0x34"
    Public Shared ReadOnly yOffset As String = ",0x38"
    Public Shared ReadOnly zOffset As String = ",0x3C"

End Class
