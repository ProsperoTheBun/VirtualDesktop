﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsDesktop.Interop.Build22000;

public class VirtualDesktop : ComWrapperBase<IVirtualDesktop>, IVirtualDesktop
{
    private Guid? _id;

    internal VirtualDesktop(ComInterfaceAssembly assembly, object comObject)
        : base(assembly, comObject)
    {
    }

    public bool IsViewVisible(IntPtr hWnd)
        => this.InvokeMethod<bool>(Args(hWnd));

    public Guid GetID()
        => this._id ?? (Guid)(this._id = this.InvokeMethod<Guid>());

    public string GetName()
        => this.InvokeMethod<IntPtr>().MarshalFromHString();

    public string GetWallpaperPath()
        => this.InvokeMethod<IntPtr>().MarshalFromHString();
}
