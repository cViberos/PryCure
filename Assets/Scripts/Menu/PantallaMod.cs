using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Diagnostics;
using UnityEngine;

public class PantallaMod : MonoBehaviour
{
    public Rect screenPosition;
    [DllImport("User32.dll")]
    static extern IntPtr SetWindowLong (IntPtr hwnd, int _nIndex, int dwNewLong);
    [DllImport("User32.dll")]
    static extern bool SetWindowPos (IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
    [DllImport("User32.dll")]
    static extern IntPtr GetForegroundWindow ();
    
    //VARIABLES NO USADAS TODAVIA
    //const uint SWP_NOMOVE = 0x2;
    //const uint SWP_NOSIZE = 1;
    //const uint SWP_NOZORDER = 0x4;
    //const uint SWP_HIDEWINDOW = 0x0080;
    const uint SWP_SHOWWINDOW = 0x0040;
    const int GWL_STYLE = -16;
    const int WS_BORDER = 1;

    void Start(){
        SetWindowLong (GetForegroundWindow(), GWL_STYLE, WS_BORDER);
        bool result = SetWindowPos (GetForegroundWindow(), 0, (int)screenPosition.x, (int)screenPosition.y, (int)screenPosition.width, (int)screenPosition.height, SWP_SHOWWINDOW);
    }
}
