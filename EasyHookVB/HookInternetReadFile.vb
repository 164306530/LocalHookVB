Imports System.IO
Imports System.Runtime.InteropServices

Public Class HookInternetReadFile
    <DllImport("wininet.dll", SetLastError:=True)>
    Public Shared Function InternetReadFile(ByVal hFile As IntPtr, ByVal lpBuffer As IntPtr, ByVal dwNumberOfBytesToRead As Integer, ByRef lpdwNumberOfBytesRead As Integer) As Boolean
    End Function

    Private Delegate Function InternetReadFileDelegate(ByVal hFile As IntPtr, ByVal lpBuffer As IntPtr, ByVal dwNumberOfBytesToRead As Integer, ByRef lpdwNumberOfBytesRead As Integer) As Boolean
    Private Shared hook As EasyHook.LocalHook = Nothing

    Friend Shared CheatFileHandle As IntPtr = IntPtr.Zero   '要替换的文件的句柄，来源于HttpOpenRequest的返回值。
    Friend Shared CheatFile() As Byte = File.ReadAllBytes(My.Application.Info.DirectoryPath & "\abc.jpg")    '用于替换的文件
    Private Shared curcnt As Integer = 0

    Friend Shared Sub Install()
        Using hook
            If EasyHook.NativeAPI.GetModuleHandle("wininet.dll") = IntPtr.Zero Then
                EasyHook.NativeAPI.LoadLibrary("wininet.dll")
            End If
            hook = EasyHook.LocalHook.Create(EasyHook.LocalHook.GetProcAddress("wininet.dll", "InternetReadFile"), New InternetReadFileDelegate(AddressOf sendProc), Nothing)
            hook.ThreadACL.SetInclusiveACL(New Integer() {0})
        End Using
    End Sub

    Friend Shared Sub UnInstall()
        Using hook
            If hook IsNot Nothing Then
                hook.ThreadACL.SetExclusiveACL(New Integer() {0})
            End If
        End Using
    End Sub

    Private Shared Function sendProc(ByVal hFile As IntPtr, ByVal lpBuffer As IntPtr, ByVal dwNumberOfBytesToRead As Integer, ByRef lpdwNumberOfBytesRead As Integer) As Boolean
        If hFile = CheatFileHandle Then
            If curcnt = CheatFile.Length Then
                CheatFileHandle = IntPtr.Zero
                curcnt = 0
                lpdwNumberOfBytesRead = 0
            Else
                If curcnt + dwNumberOfBytesToRead <= CheatFile.Length Then
                    lpdwNumberOfBytesRead = dwNumberOfBytesToRead
                    Marshal.Copy(CheatFile, curcnt, lpBuffer, lpdwNumberOfBytesRead)
                    curcnt += dwNumberOfBytesToRead
                Else
                    lpdwNumberOfBytesRead = CheatFile.Length - curcnt
                    Marshal.Copy(CheatFile, curcnt, lpBuffer, lpdwNumberOfBytesRead)
                    curcnt = CheatFile.Length
                End If
            End If
            Return True
        Else
            Return InternetReadFile(hFile, lpBuffer, dwNumberOfBytesToRead, lpdwNumberOfBytesRead)
        End If
    End Function

End Class