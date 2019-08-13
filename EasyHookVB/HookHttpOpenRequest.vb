Imports System.Runtime.InteropServices
Imports System.Text

Public Class HookHttpOpenRequest

    <DllImport("wininet.dll")>
    Public Shared Function HttpOpenRequestW(hConnect As IntPtr, szVerb As IntPtr, szURI As IntPtr, szHttpVersion As IntPtr, szReferer As IntPtr, accetpType As IntPtr, dwflags As Integer, dwcontext As IntPtr) As IntPtr
    End Function

    Private Delegate Function HttpOpenRequestDelegate(hConnect As IntPtr, szVerb As IntPtr, szURI As IntPtr, szHttpVersion As IntPtr, szReferer As IntPtr, accetpType As IntPtr, dwflags As Integer, dwcontext As IntPtr) As IntPtr
    Private Shared hook As EasyHook.LocalHook = Nothing

    Friend Shared Sub Install()
        Using hook
            If EasyHook.NativeAPI.GetModuleHandle("wininet.dll") = IntPtr.Zero Then
                EasyHook.NativeAPI.LoadLibrary("wininet.dll")
            End If
            hook = EasyHook.LocalHook.Create(EasyHook.LocalHook.GetProcAddress("wininet.dll", "HttpOpenRequestW"), New HttpOpenRequestDelegate(AddressOf sendProc), Nothing)
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

    Private Shared Function sendProc(hConnect As IntPtr, szVerb As IntPtr, szURI As IntPtr, szHttpVersion As IntPtr, szReferer As IntPtr, accetpType As IntPtr, dwflags As Integer, dwcontext As IntPtr) As IntPtr
        Dim uri As String = Marshal.PtrToStringUni(szURI)
        Dim result As IntPtr = HttpOpenRequestW(hConnect, szVerb, szURI, szHttpVersion, szReferer, accetpType, dwflags, dwcontext)
        If uri.Contains("/8MXBCxc") Then '根据名称区分要替换的图片. 
            HookInternetReadFile.CheatFileHandle = result

        End If

        Return result

    End Function

End Class