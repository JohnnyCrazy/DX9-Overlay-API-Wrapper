using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX9OverlayAPIWrapper
{
    public abstract class Overlay
    {
        private int _id = -1;
        public int Id
        {
            get
            {
                return _id;
            }
            protected set
            {
                _id = value;
            }
        }

        private bool _visible;
        public virtual bool Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                _visible = value;
            }
        }

        public virtual void Destroy()
        {
            _id = -1;
        }

        public override string ToString()
        {
            return $"{GetType().Name} {Id}";
        }
    }
}
