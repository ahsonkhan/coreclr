// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable enable
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System
{
    internal static class ApplicationModel
    {
#if FEATURE_APPX
        // Cache the value in readonly static that can be optimized out by the JIT
        internal readonly static bool IsUap = IsAppXProcess();

        [DllImport(JitHelpers.QCall, CharSet = CharSet.Unicode)]
        private static extern bool IsAppXProcess();
#endif
    }
}
