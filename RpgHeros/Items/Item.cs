using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgHeros.Items
{
    public abstract class Item
    {
        protected string name;
        protected byte requiredLevel;

        protected Item(string name, byte requiredLevel)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.requiredLevel = requiredLevel;
        }

        public string Name => name;
        public byte RequiredLevel => requiredLevel;

    }
}
