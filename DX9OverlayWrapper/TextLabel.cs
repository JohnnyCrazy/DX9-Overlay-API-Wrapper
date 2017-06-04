using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DX9OverlayAPIWrapper
{
    public class TextLabel : Overlay
    {
        public override bool Visible
        {
            get
            {
                return base.Visible;
            }
            set 
            {
                DX9Overlay.TextSetShown(Id, value);
                base.Visible = value;
            }
        }

        private string _text;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                DX9Overlay.TextSetString(Id, value);
                _text = value;
            }
        }

        private bool _shadow;
        public bool Shadow
        {
            get
            {
                return _shadow;
            }
            set
            {
                DX9Overlay.TextSetShadow(Id, value);
                _shadow = value;
            }
        }

        private Color _color;
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                DX9Overlay.TextSetColor(Id, (uint)value.ToArgb());
                _color = value;
            }
        }

        private Point _position;
        public Point Position
        {
            get
            {
                return _position;
            }
            set
            {
                DX9Overlay.TextSetPos(Id, value.X, value.Y);
                _position = value;
            }
        }

        public TextLabel(string font, int size, TypeFace type, Point position, Color color, string text, bool shadow, bool show)
        {
            Id = DX9Overlay.TextCreate(font, size, type.HasFlag(TypeFace.BOLD), type.HasFlag(TypeFace.ITALIC), position.X, position.Y, (uint)color.ToArgb(), text, shadow, show);
            _text = text;
            _shadow = shadow;
            base.Visible = show;
            _color = color;
            _position = position;
        }

        public override void Destroy()
        {
            DX9Overlay.TextDestroy(Id);
            base.Destroy();
        }

        public void TextUpdate(String font, int size, Boolean bold, Boolean italic)
        {
            DX9Overlay.TextUpdate(Id, font, size, bold, italic);
        }
    }
}
