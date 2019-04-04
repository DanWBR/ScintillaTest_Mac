using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using ObjCRuntime;

namespace ScintillaBinder
{
    [Native]
    public enum IBDisplay : ulong
    {
        Zoom = 1,
        CaretPosition = 2,
        StatusText = 4,
        All = 255
    }

    [Native]
    public enum NotificationType : long
    {
        ZoomChanged,
        CaretChanged,
        StatusChanged
    }

    //static class CFunctions
    //{
    //    // extern NSRect PRectangleToNSRect (const int Scintilla);
    //    [DllImport("__Internal")]
    //    static extern CGRect PRectangleToNSRect(int Scintilla);

    //    // extern CFStringEncoding EncodingFromCharacterSet (_Bool unicode, int characterSet);
    //    [DllImport("__Internal")]
    //    static extern uint EncodingFromCharacterSet(bool unicode, int characterSet);
    //}
}
