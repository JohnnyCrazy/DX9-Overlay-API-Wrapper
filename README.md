DX9-Overlay-API-Wrapper
=======================

A .NET Wrapper for the [DX9-Overlay-API](https://github.com/agrippa1994/DX9-Overlay-API)


#####Usage Example (Add the Wrapper DLL as reference):

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using DX9OverlayAPIWrapper;

namespace DX9OverlayWrapperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DX9Overlay.SetParam("process", "GFXTest.exe");
            DX9Overlay.DestroyAllVisual();
            TextLabel text = new TextLabel("Arial", 20, TypeFace.NONE, new Point(5, 5), Color.Red, "Test123", true, true);
            Thread.Sleep(5000);
            text.Text = "Text2"; //Text updaten
            Thread.Sleep(5000);
            text.Color = Color.Cyan; //Color updaten
            Thread.Sleep(5000);
            text.Destroy(); //Text entfernen
        }
    }
}

```

For all types, look at the source Files
