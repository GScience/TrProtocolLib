using System.IO;
using System;
using System.Collections.Generic;

namespace TrProtocol.TrObject
{
    /// <summary>
    /// 
    /// </summary>
    public class TileEntity
    {
        public int ID;
        public short x;
        public short y;
        private byte _type;
        public byte Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                entityData = Activator.CreateInstance(Database.tileEntityTypes[_type]) as INetObject;
            }
        }
        public INetObject entityData;
    }
}

//Json file changed at 2020/6/9 23:46:43