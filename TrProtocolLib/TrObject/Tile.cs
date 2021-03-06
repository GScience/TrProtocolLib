using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.TrObject
{
    /// <summary>
    /// 
    /// </summary>
    public class Tile
    {
        public struct Position
        {
            public int x;
            public int y;
            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public ushort type;
        public ushort wall;
        public byte liquid;
        public short sTileHeader;
        public byte bTileHeader;
        public byte bTileHeader2;
        public byte bTileHeader3;
        public short frameX;
        public short frameY;
        public const int Type_Solid = 0;
        public const int Type_Halfbrick = 1;
        public const int Type_SlopeDownRight = 2;
        public const int Type_SlopeDownLeft = 3;
        public const int Type_SlopeUpRight = 4;
        public const int Type_SlopeUpLeft = 5;
        public const int Liquid_Water = 0;
        public const int Liquid_Lava = 1;
        public const int Liquid_Honey = 2;

        public Tile()
        {
            this.type = (ushort)0;
            this.wall = (ushort)0;
            this.liquid = (byte)0;
            this.sTileHeader = (short)0;
            this.bTileHeader = (byte)0;
            this.bTileHeader2 = (byte)0;
            this.bTileHeader3 = (byte)0;
            this.frameX = (short)0;
            this.frameY = (short)0;
        }

        public Tile(Tile copy)
        {
            if (copy == null)
            {
                this.type = (ushort)0;
                this.wall = (ushort)0;
                this.liquid = (byte)0;
                this.sTileHeader = (short)0;
                this.bTileHeader = (byte)0;
                this.bTileHeader2 = (byte)0;
                this.bTileHeader3 = (byte)0;
                this.frameX = (short)0;
                this.frameY = (short)0;
            }
            else
            {
                this.type = copy.type;
                this.wall = copy.wall;
                this.liquid = copy.liquid;
                this.sTileHeader = copy.sTileHeader;
                this.bTileHeader = copy.bTileHeader;
                this.bTileHeader2 = copy.bTileHeader2;
                this.bTileHeader3 = copy.bTileHeader3;
                this.frameX = copy.frameX;
                this.frameY = copy.frameY;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void ClearEverything()
        {
            this.type = (ushort)0;
            this.wall = (ushort)0;
            this.liquid = (byte)0;
            this.sTileHeader = (short)0;
            this.bTileHeader = (byte)0;
            this.bTileHeader2 = (byte)0;
            this.bTileHeader3 = (byte)0;
            this.frameX = (short)0;
            this.frameY = (short)0;
        }

        public void ClearTile()
        {
            this.slope((byte)0);
            this.halfBrick(false);
            this.active(false);
            this.inActive(false);
        }

        public void CopyFrom(Tile from)
        {
            this.type = from.type;
            this.wall = from.wall;
            this.liquid = from.liquid;
            this.sTileHeader = from.sTileHeader;
            this.bTileHeader = from.bTileHeader;
            this.bTileHeader2 = from.bTileHeader2;
            this.bTileHeader3 = from.bTileHeader3;
            this.frameX = from.frameX;
            this.frameY = from.frameY;
        }

        public int blockType()
        {
            if (this.halfBrick())
                return 1;
            int num = (int)this.slope();
            if (num > 0)
                ++num;
            return num;
        }

        public void liquidType(int liquidType)
        {
            switch (liquidType)
            {
                case 0:
                    this.bTileHeader &= (byte)159;
                    break;
                case 1:
                    this.lava(true);
                    break;
                case 2:
                    this.honey(true);
                    break;
            }
        }

        public byte liquidType()
        {
            return (byte)(((int)this.bTileHeader & 96) >> 5);
        }

        public bool nactive()
        {
            return ((int)this.sTileHeader & 96) == 32;
        }

        public void ResetToType(ushort type)
        {
            this.liquid = (byte)0;
            this.sTileHeader = (short)32;
            this.bTileHeader = (byte)0;
            this.bTileHeader2 = (byte)0;
            this.bTileHeader3 = (byte)0;
            this.frameX = (short)0;
            this.frameY = (short)0;
            this.type = type;
        }

        internal void ClearMetadata()
        {
            this.liquid = (byte)0;
            this.sTileHeader = (short)0;
            this.bTileHeader = (byte)0;
            this.bTileHeader2 = (byte)0;
            this.bTileHeader3 = (byte)0;
            this.frameX = (short)0;
            this.frameY = (short)0;
        }

        public Color actColor(Color oldColor)
        {
            if (!this.inActive())
                return oldColor;
            double num = 0.4;
            return new Color((byte)(num * oldColor.r), (byte)(num * oldColor.g), (byte)(num * oldColor.b));
        }

        public bool topSlope()
        {
            byte num = this.slope();
            if (num != (byte)1)
                return num == (byte)2;
            return true;
        }

        public bool bottomSlope()
        {
            byte num = this.slope();
            if (num != (byte)3)
                return num == (byte)4;
            return true;
        }

        public bool leftSlope()
        {
            byte num = this.slope();
            if (num != (byte)2)
                return num == (byte)4;
            return true;
        }

        public bool rightSlope()
        {
            byte num = this.slope();
            if (num != (byte)1)
                return num == (byte)3;
            return true;
        }

        public bool HasSameSlope(Tile tile)
        {
            return ((int)this.sTileHeader & 29696) == ((int)tile.sTileHeader & 29696);
        }

        public byte wallColor()
        {
            return (byte)((uint)this.bTileHeader & 31U);
        }

        public void wallColor(byte wallColor)
        {
            this.bTileHeader = (byte)((uint)this.bTileHeader & 224U | (uint)wallColor);
        }

        public bool lava()
        {
            return ((int)this.bTileHeader & 32) == 32;
        }

        public void lava(bool lava)
        {
            if (lava)
                this.bTileHeader = (byte)((int)this.bTileHeader & 159 | 32);
            else
                this.bTileHeader &= (byte)223;
        }

        public bool honey()
        {
            return ((int)this.bTileHeader & 64) == 64;
        }

        public void honey(bool honey)
        {
            if (honey)
                this.bTileHeader = (byte)((int)this.bTileHeader & 159 | 64);
            else
                this.bTileHeader &= (byte)191;
        }

        public bool wire4()
        {
            return ((int)this.bTileHeader & 128) == 128;
        }

        public void wire4(bool wire4)
        {
            if (wire4)
                this.bTileHeader |= (byte)128;
            else
                this.bTileHeader &= (byte)127;
        }

        public int wallFrameX()
        {
            return ((int)this.bTileHeader2 & 15) * 36;
        }

        public void wallFrameX(int wallFrameX)
        {
            this.bTileHeader2 = (byte)((int)this.bTileHeader2 & 240 | wallFrameX / 36 & 15);
        }

        public byte frameNumber()
        {
            return (byte)(((int)this.bTileHeader2 & 48) >> 4);
        }

        public void frameNumber(byte frameNumber)
        {
            this.bTileHeader2 = (byte)((int)this.bTileHeader2 & 207 | ((int)frameNumber & 3) << 4);
        }

        public byte wallFrameNumber()
        {
            return (byte)(((int)this.bTileHeader2 & 192) >> 6);
        }

        public void wallFrameNumber(byte wallFrameNumber)
        {
            this.bTileHeader2 = (byte)((int)this.bTileHeader2 & 63 | ((int)wallFrameNumber & 3) << 6);
        }

        public int wallFrameY()
        {
            return ((int)this.bTileHeader3 & 7) * 36;
        }

        public void wallFrameY(int wallFrameY)
        {
            this.bTileHeader3 = (byte)((int)this.bTileHeader3 & 248 | wallFrameY / 36 & 7);
        }

        public bool checkingLiquid()
        {
            return ((int)this.bTileHeader3 & 8) == 8;
        }

        public void checkingLiquid(bool checkingLiquid)
        {
            if (checkingLiquid)
                this.bTileHeader3 |= (byte)8;
            else
                this.bTileHeader3 &= (byte)247;
        }

        public bool skipLiquid()
        {
            return ((int)this.bTileHeader3 & 16) == 16;
        }

        public void skipLiquid(bool skipLiquid)
        {
            if (skipLiquid)
                this.bTileHeader3 |= (byte)16;
            else
                this.bTileHeader3 &= (byte)239;
        }

        public byte color()
        {
            return (byte)((uint)this.sTileHeader & 31U);
        }

        public void color(byte color)
        {
            this.sTileHeader = (short)((int)this.sTileHeader & 65504 | (int)color);
        }

        public bool active()
        {
            return ((int)this.sTileHeader & 32) == 32;
        }

        public void active(bool active)
        {
            if (active)
                this.sTileHeader |= (short)32;
            else
                this.sTileHeader &= (short)-33;
        }

        public bool inActive()
        {
            return ((int)this.sTileHeader & 64) == 64;
        }

        public void inActive(bool inActive)
        {
            if (inActive)
                this.sTileHeader |= (short)64;
            else
                this.sTileHeader &= (short)-65;
        }

        public bool wire()
        {
            return ((int)this.sTileHeader & 128) == 128;
        }

        public void wire(bool wire)
        {
            if (wire)
                this.sTileHeader |= (short)128;
            else
                this.sTileHeader &= (short)-129;
        }

        public bool wire2()
        {
            return ((int)this.sTileHeader & 256) == 256;
        }

        public void wire2(bool wire2)
        {
            if (wire2)
                this.sTileHeader |= (short)256;
            else
                this.sTileHeader &= (short)-257;
        }

        public bool wire3()
        {
            return ((int)this.sTileHeader & 512) == 512;
        }

        public void wire3(bool wire3)
        {
            if (wire3)
                this.sTileHeader |= (short)512;
            else
                this.sTileHeader &= (short)-513;
        }

        public bool halfBrick()
        {
            return ((int)this.sTileHeader & 1024) == 1024;
        }

        public void halfBrick(bool halfBrick)
        {
            if (halfBrick)
                this.sTileHeader |= (short)1024;
            else
                this.sTileHeader &= (short)-1025;
        }

        public bool actuator()
        {
            return ((int)this.sTileHeader & 2048) == 2048;
        }

        public void actuator(bool actuator)
        {
            if (actuator)
                this.sTileHeader |= (short)2048;
            else
                this.sTileHeader &= (short)-2049;
        }

        public byte slope()
        {
            return (byte)(((int)this.sTileHeader & 28672) >> 12);
        }

        public void slope(byte slope)
        {
            this.sTileHeader = (short)((int)this.sTileHeader & 36863 | ((int)slope & 7) << 12);
        }

        public bool isTheSameAs(Tile compTile)
        {
            if (compTile == null || sTileHeader != compTile.sTileHeader || active() && (type != compTile.type || Database.tileFrameImportant[type] && (frameX != compTile.frameX || frameY != compTile.frameY)) || (wall != compTile.wall || liquid != compTile.liquid))
                return false;
            if (compTile.liquid == 0)
            {
                if (wallColor() != compTile.wallColor() || wire4() != compTile.wire4())
                    return false;
            }
            else if (bTileHeader != compTile.bTileHeader)
                return false;
            return true;
        }

        public override string ToString()
        {
            return "Tile Type:" + type + " Active:" + active().ToString() + " Wall:" + wall + " Slope:" + slope() + " fX:" + frameX + " fY:" + frameY;
        }
    }
}

//Json file changed at 2020/6/9 20:32:06