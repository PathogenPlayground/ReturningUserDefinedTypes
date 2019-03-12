using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

public class ImGuiSupport
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate void* PlatformGetWindowPositionDelegate(out Vector2 vector, ImGuiViewportPtr viewport);

    // Delegates must be cached to ensure they aren't garbage collected while ImGui holds a pointer to them.
    private readonly List<Delegate> MarshaledDelegateCache = new List<Delegate>();

    public ImGuiSupport()
    {
        PlatformGetWindowPositionDelegate platformGetWindowPosition = PlatformGetWindowPosition;
        MarshaledDelegateCache.Add(platformGetWindowPosition);
        ImGui.GetPlatformIO().Platform_GetWindowPos = Marshal.GetFunctionPointerForDelegate(platformGetWindowPosition);
    }

    private unsafe void* PlatformGetWindowPosition(out Vector2 ret, ImGuiViewportPtr viewport)
    {
        Console.WriteLine($"Getting window position for {(ulong)viewport.NativePtr:X}");
        ret = new Vector2(1879, 3226);
        return Unsafe.AsPointer(ref ret);
    }
}
