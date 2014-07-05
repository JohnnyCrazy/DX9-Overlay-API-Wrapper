using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX9OverlayAPIWrapper
{
    public abstract class Overlay
    {
        private int id = -1;
        public int Id
        {
            get
            {
                return id;
            }
            protected set
            {
                this.id = value;
            }
        }

        private Boolean visible;
        public Boolean Visible
        {
            get
            {
                return visible;
            }
            set
            {
                DX9Overlay.BoxSetShown(id, value);
                this.visible = value;
            }
        }

        public virtual void Destroy()
        {
            id = -1;
        }

        public override string ToString()
        {
            return this.GetType().Name + " " + Id;
        }
    }
}
