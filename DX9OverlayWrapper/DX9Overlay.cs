using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DX9OverlayAPIWrapper
{
    /// <summary>
    /// Class providing all necessary Functions for the API
    /// </summary>
    public static class DX9Overlay
    {
        private const String PATH = "dx9_overlay.dll";

        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextCreate(string font, int fontSize, bool bBold, bool bItalic, int x, int y, uint color, string text, bool bShadow, bool bShow);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextDestroy(int id);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextSetShadow(int id, bool b);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextSetShown(int id, bool b);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextSetColor(int id, uint color);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextSetPos(int id, int x, int y);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextSetString(int id, string str);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TextUpdate(int id, string font, int fontSize, bool bBold, bool bItalic);

        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxCreate(int x, int y, int w, int h, uint dwColor, bool bShow);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxDestroy(int id);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxSetShown(int id, bool bShown);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxSetBorder(int id, int height, bool bShown);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxSetBorderColor(int id, uint dwColor);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxSetColor(int id, uint dwColor);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxSetHeight(int id, int height);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxSetPos(int id, int x, int y);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int BoxSetWidth(int id, int width);

        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LineCreate(int x1, int y1, int x2, int y2, int width, uint color, bool bShow);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LineDestroy(int id);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LineSetShown(int id, bool bShown);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LineSetColor(int id, uint color);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LineSetWidth(int id, int width);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int LineSetPos(int id, int x1, int y1, int x2, int y2);

        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImageCreate(string path, int x, int y, int rotation, int align, bool bShow);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImageDestroy(int id);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImageSetShown(int id, bool bShown);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImageSetAlign(int id, int align);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImageSetPos(int id, int x, int y);
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImageSetRotation(int id, int rotation);

        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DestroyAllVisual();
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ShowAllVisual();
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int HideAllVisual();

        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetFrameRate();
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetScreenSpecs(out int width, out int height);

        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Init();
        [DllImport(PATH, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetParam(string _szParamName, string _szParamValue);

        public static string ToHexValueRGB(Color color)
        {
            return $"{color.R.ToString("X2")}{color.G.ToString("X2")}{color.B.ToString("X2")}";
        }

        public static string ToHexValueARGB(Color color)
        {
            return $"{color.A.ToString("X2")}{color.R.ToString("X2")}{color.G.ToString("X2")}{color.B.ToString("X2")}";
        }

        public static Point GetScreenSpecs()
        {
            GetScreenSpecs(out int x, out int y);
            return new Point(x, y);
        }
    }

    [Flags]
    public enum Align
    {
        CENTER = 1,
        LEFT = 0
    }

    [Flags]
    public enum TypeFace
    {
        ITALIC = 1,
        BOLD = 2,
        NONE = 4
    }
}
