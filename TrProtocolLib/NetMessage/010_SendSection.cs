using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;
using TrProtocol.TrObject;
using Ionic.Zlib;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg10SendSection : INetMessage
    {
        public const int ID = 10;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int xStart = default(int);
        /// <summary>
        /// 
        /// </summary>
        public int yStart = default(int);
        /// <summary>
        /// 
        /// </summary>
        public short width = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short height = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short chestCount = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short signCount = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short tileEntityCount = default(short);

        public Dictionary<Tile.Position, Tile> tiles = new Dictionary<Tile.Position, Tile>();
        public Dictionary<int, Chest> chests = new Dictionary<int, Chest>();
        public Dictionary<int, Sign> signs = new Dictionary<int, Sign>();
        public Dictionary<int, TileEntity> tileEntities = new Dictionary<int, TileEntity>();

        public void OnSerialize(BinaryWriter writer)
        {
            using (MemoryStream memoryStream1 = new MemoryStream())
            {
                using (BinaryWriter blockWriter = new BinaryWriter(memoryStream1))
                {
                    blockWriter.Write(xStart);
                    blockWriter.Write(yStart);
                    blockWriter.Write(width);
                    blockWriter.Write(height);
                    WriteTileBlock(blockWriter, xStart, yStart, width, height);
                    memoryStream1.Position = 0L;
                    MemoryStream memoryStream2 = new MemoryStream();
                    using (DeflateStream deflateStream = new DeflateStream(memoryStream2, CompressionMode.Compress, true))
                    {
                        memoryStream1.CopyTo(deflateStream);
                        deflateStream.Flush();
                    }
                    if (memoryStream1.Length <= memoryStream2.Length)
                    {
                        writer.Write((byte)0);
                        writer.BaseStream.Write(memoryStream1.GetBuffer(), 0, (int)memoryStream2.Length);
                    }
                    else
                    {
                        writer.Write((byte)1);
                        writer.BaseStream.Write(memoryStream2.GetBuffer(), 0, (int)memoryStream2.Length);
                    }
                }
            }
        }

        public void OnDeserialize(BinaryReader reader)
        {
            using (var memoryStream1 = new MemoryStream())
            {
                var bufferLength = reader.BaseStream.Length;
                memoryStream1.Write(reader.ReadBytes((int)bufferLength), 0, (int)bufferLength);
                memoryStream1.Position = 0L;
                MemoryStream memoryStream2;
                if ((uint)memoryStream1.ReadByte() > 0U)
                {
                    MemoryStream memoryStream3 = new MemoryStream();
                    using (var deflateStream = new DeflateStream(memoryStream1, CompressionMode.Decompress, true))
                    {
                        deflateStream.CopyTo(memoryStream3);
                        deflateStream.Close();
                    }
                    memoryStream2 = memoryStream3;
                    memoryStream2.Position = 0L;
                }
                else
                {
                    memoryStream2 = memoryStream1;
                    memoryStream2.Position = 1L;
                }
                using (BinaryReader blockReader = new BinaryReader(memoryStream2))
                {
                    xStart = blockReader.ReadInt32();
                    yStart = blockReader.ReadInt32();
                    width = blockReader.ReadInt16();
                    height = blockReader.ReadInt16();
                    ReadTileBlock(blockReader, xStart, yStart, width, height);
                }
            }
        }
        private void ReadTileBlock(
            BinaryReader reader,
            int xStart,
            int yStart,
            int width,
            int height)
        {
            Tile tile = null;
            int num1 = 0;
            for (int y = yStart; y < yStart + height; ++y)
            {
                for (int x = xStart; x < xStart + width; ++x)
                {
                    if (num1 != 0)
                    {
                        --num1;
                        if (!tiles.TryGetValue(new Tile.Position(x, y), out var _tile))
                            tiles[new Tile.Position(x, y)] = new Tile(tile);
                        else
                            _tile.CopyFrom(tile);
                    }
                    else
                    {
                        byte data2;
                        byte data1 = data2 = 0;
                        if (tiles.TryGetValue(new Tile.Position(x, y), out var _tile))
                        {
                            tile = _tile;
                            tile.ClearEverything();
                        }
                        else
                        {
                            tile = new Tile();
                            tiles[new Tile.Position(x, y)] = tile;
                        }
                        byte tileByteData = reader.ReadByte();
                        if (((int)tileByteData & 1) == 1)
                        {
                            data1 = reader.ReadByte();
                            if (((int)data1 & 1) == 1)
                                data2 = reader.ReadByte();
                        }
                        bool flag = tile.active();
                        if (((int)tileByteData & 2) == 2)
                        {
                            tile.active(true);
                            ushort type = tile.type;
                            int index3;
                            if (((int)tileByteData & 32) == 32)
                            {
                                byte num5 = reader.ReadByte();
                                index3 = (int)reader.ReadByte() << 8 | (int)num5;
                            }
                            else
                                index3 = (int)reader.ReadByte();
                            tile.type = (ushort)index3;
                            if (Database.tileFrameImportant[index3])
                            {
                                tile.frameX = reader.ReadInt16();
                                tile.frameY = reader.ReadInt16();
                            }
                            else if (!flag || (int)tile.type != (int)type)
                            {
                                tile.frameX = (short)-1;
                                tile.frameY = (short)-1;
                            }
                            if (((int)data2 & 8) == 8)
                                tile.color(reader.ReadByte());
                        }
                        if (((int)tileByteData & 4) == 4)
                        {
                            tile.wall = (ushort)reader.ReadByte();
                            if (((int)data2 & 16) == 16)
                                tile.wallColor(reader.ReadByte());
                        }
                        byte num6 = (byte)(((int)tileByteData & 24) >> 3);
                        if (num6 != (byte)0)
                        {
                            tile.liquid = reader.ReadByte();
                            if (num6 > 1)
                            {
                                if (num6 == (byte)2)
                                    tile.lava(true);
                                else
                                    tile.honey(true);
                            }
                        }
                        if (data1 > 1)
                        {
                            if ((data1 & 2) == 2)
                                tile.wire(true);
                            if ((data1 & 4) == 4)
                                tile.wire2(true);
                            if ((data1 & 8) == 8)
                                tile.wire3(true);
                            byte num5 = (byte)((data1 & 112) >> 4);
                            if (num5 != 0 && Database.tileSolid[tile.type])
                            {
                                if (num5 == (byte)1)
                                    tile.halfBrick(true);
                                else
                                    tile.slope((byte)((uint)num5 - 1U));
                            }
                        }
                        if (data2 > 0)
                        {
                            if (((int)data2 & 2) == 2)
                                tile.actuator(true);
                            if (((int)data2 & 4) == 4)
                                tile.inActive(true);
                            if (((int)data2 & 32) == 32)
                                tile.wire4(true);
                            if (((int)data2 & 64) == 64)
                            {
                                byte num5 = reader.ReadByte();
                                tile.wall = (ushort)((uint)num5 << 8 | (uint)tile.wall);
                            }
                        }
                        switch ((byte)((tileByteData & 192) >> 6))
                        {
                            case 0:
                                num1 = 0;
                                continue;
                            case 1:
                                num1 = reader.ReadByte();
                                continue;
                            default:
                                num1 = reader.ReadInt16();
                                continue;
                        }
                    }
                }
            }
            short num7 = reader.ReadInt16();
            for (int index = 0; index < (int)num7; ++index)
            {
                short num2 = reader.ReadInt16();
                short num3 = reader.ReadInt16();
                short num4 = reader.ReadInt16();
                string str = reader.ReadString();
                if (num2 >= (short)0 && num2 < (short)8000)
                {
                    if (!chests.TryGetValue(num2, out var chest))
                    {
                        chest = new Chest();
                        chests[num2] = chest;
                    }
                    chest.name = str;
                    chest.x = (int)num3;
                    chest.y = (int)num4;
                }
            }
            short num8 = reader.ReadInt16();
            for (int index = 0; index < (int)num8; ++index)
            {
                short num2 = reader.ReadInt16();
                short num3 = reader.ReadInt16();
                short num4 = reader.ReadInt16();
                string str = reader.ReadString();
                if (num2 >= (short)0 && num2 < (short)1000)
                {
                    if (!signs.TryGetValue(num2, out var sign))
                    {
                        sign = new Sign();
                        signs[num2] = sign;
                    }
                    sign.text = str;
                    sign.x = (int)num3;
                    sign.y = (int)num4;
                }
            }
            short num9 = reader.ReadInt16();
            for (int index = 0; index < (int)num9; ++index)
                ReadTileEntity(reader);
        }
        public void WriteTileBlock(
            BinaryWriter writer,
            int xStart,
            int yStart,
            int width,
            int height)
        {
            short num4 = 0;
            int index1 = 0;
            int index2 = 0;
            byte num5 = 0;
            byte[] buffer = new byte[15];
            Tile compTile = (Tile)null;
            for (int index3 = yStart; index3 < yStart + height; ++index3)
            {
                for (int index4 = xStart; index4 < xStart + width; ++index4)
                {
                    Tile tile = tiles[new Tile.Position(index4, index3)];
                    if (tile.isTheSameAs(compTile))
                    {
                        ++num4;
                    }
                    else
                    {
                        if (compTile != null)
                        {
                            if (num4 > (short)0)
                            {
                                buffer[index1] = (byte)((uint)num4 & (uint)byte.MaxValue);
                                ++index1;
                                if (num4 > (short)byte.MaxValue)
                                {
                                    num5 |= (byte)128;
                                    buffer[index1] = (byte)(((int)num4 & 65280) >> 8);
                                    ++index1;
                                }
                                else
                                    num5 |= (byte)64;
                            }
                            buffer[index2] = num5;
                            writer.Write(buffer, index2, index1 - index2);
                            num4 = (short)0;
                        }
                        index1 = 3;
                        int num6;
                        byte num7 = (byte)(num6 = 0);
                        byte num8 = (byte)num6;
                        num5 = (byte)num6;
                        if (tile.active())
                        {
                            num5 |= (byte)2;
                            buffer[index1] = (byte)tile.type;
                            ++index1;
                            if (tile.type > (ushort)byte.MaxValue)
                            {
                                buffer[index1] = (byte)((uint)tile.type >> 8);
                                ++index1;
                                num5 |= (byte)32;
                            }
                            if (Database.tileFrameImportant[(int)tile.type])
                            {
                                buffer[index1] = (byte)((uint)tile.frameX & (uint)byte.MaxValue);
                                int index5 = index1 + 1;
                                buffer[index5] = (byte)(((int)tile.frameX & 65280) >> 8);
                                int index6 = index5 + 1;
                                buffer[index6] = (byte)((uint)tile.frameY & (uint)byte.MaxValue);
                                int index7 = index6 + 1;
                                buffer[index7] = (byte)(((int)tile.frameY & 65280) >> 8);
                                index1 = index7 + 1;
                            }
                            if (tile.color() != (byte)0)
                            {
                                num7 |= (byte)8;
                                buffer[index1] = tile.color();
                                ++index1;
                            }
                        }
                        if (tile.wall != (ushort)0)
                        {
                            num5 |= (byte)4;
                            buffer[index1] = (byte)tile.wall;
                            ++index1;
                            if (tile.wallColor() != (byte)0)
                            {
                                num7 |= (byte)16;
                                buffer[index1] = tile.wallColor();
                                ++index1;
                            }
                        }
                        if (tile.liquid != (byte)0)
                        {
                            if (tile.lava())
                                num5 |= (byte)16;
                            else if (tile.honey())
                                num5 |= (byte)24;
                            else
                                num5 |= (byte)8;
                            buffer[index1] = tile.liquid;
                            ++index1;
                        }
                        if (tile.wire())
                            num8 |= (byte)2;
                        if (tile.wire2())
                            num8 |= (byte)4;
                        if (tile.wire3())
                            num8 |= (byte)8;
                        int num10 = !tile.halfBrick() ? (tile.slope() == (byte)0 ? 0 : (int)tile.slope() + 1 << 4) : 16;
                        byte num11 = (byte)((uint)num8 | (uint)(byte)num10);
                        if (tile.actuator())
                            num7 |= (byte)2;
                        if (tile.inActive())
                            num7 |= (byte)4;
                        if (tile.wire4())
                            num7 |= (byte)32;
                        if (tile.wall > (ushort)byte.MaxValue)
                        {
                            buffer[index1] = (byte)((uint)tile.wall >> 8);
                            ++index1;
                            num7 |= (byte)64;
                        }
                        index2 = 2;
                        if (num7 != (byte)0)
                        {
                            num11 |= (byte)1;
                            buffer[index2] = num7;
                            --index2;
                        }
                        if (num11 != (byte)0)
                        {
                            num5 |= (byte)1;
                            buffer[index2] = num11;
                            --index2;
                        }
                        compTile = tile;
                    }
                }
            }
            if (num4 > 0)
            {
                buffer[index1] = (byte)((uint)num4 & (uint)byte.MaxValue);
                ++index1;
                if (num4 > byte.MaxValue)
                {
                    num5 |= 128;
                    buffer[index1] = (byte)(((int)num4 & 65280) >> 8);
                    ++index1;
                }
                else
                    num5 |= 64;
            }
            buffer[index2] = num5;
            writer.Write(buffer, index2, index1 - index2);
            writer.Write((short)chests.Count);
            foreach (var chestPair in chests)
            {
                Chest chest = chestPair.Value;
                writer.Write((short)chestPair.Key);
                writer.Write((short)chest.x);
                writer.Write((short)chest.y);
                writer.Write(chest.name);
            }
            writer.Write((short)signs.Count);
            foreach (var signPair in signs)
            {
                Sign sign = signPair.Value;
                writer.Write((short)signPair.Key);
                writer.Write((short)sign.x);
                writer.Write((short)sign.y);
                writer.Write(sign.text);
            }
            writer.Write((short)tileEntities.Count);
            foreach (var entityPair in tileEntities)
                WriteTileEntity(writer, entityPair.Value, false);
        }

        public void ReadTileEntity(BinaryReader reader, bool networkSend = false)
        {
            byte type = reader.ReadByte();
            var instance = new TileEntity();
            instance.Type = type;
            if (!networkSend)
                instance.ID = reader.ReadInt32();
            instance.x = reader.ReadInt16();
            instance.y = reader.ReadInt16();
            instance.entityData.OnDeserialize(reader);

            tileEntities[instance.ID] = instance;
        }

        public void WriteTileEntity(BinaryWriter writer, TileEntity ent, bool networkSend = false)
        {
            writer.Write(ent.Type);
            if (!networkSend)
                writer.Write(ent.ID);
            writer.Write(ent.x);
            writer.Write(ent.y);
            ent.entityData.OnSerialize(writer);
        }
    }
}

//Json file changed at 2020/6/9 23:47:05