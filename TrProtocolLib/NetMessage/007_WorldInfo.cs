using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// World info
    /// </summary>
    public class Msg7WorldInfo : INetMessage
    {
        public const int ID = 7;

        public Side Side { get; set; }

        /// <summary>
        /// Time
        /// </summary>
        public int time = default(int);
        /// <summary>
        /// Day time, blood moon and eclipse
        /// </summary>
        public BitsByte worldTime = new BitsByte();
        /// <summary>
        /// Moon Phase
        /// </summary>
        public byte moonPhase = default(byte);
        /// <summary>
        /// Max tiles x
        /// </summary>
        public short maxTilesX = default(short);
        /// <summary>
        /// Max tiles y
        /// </summary>
        public short maxTilesY = default(short);
        /// <summary>
        /// Spawn tiles x
        /// </summary>
        public short spawnTilesX = default(short);
        /// <summary>
        /// Spawn tiles y
        /// </summary>
        public short spawnTilesY = default(short);
        /// <summary>
        /// World surface
        /// </summary>
        public short worldSurface = default(short);
        /// <summary>
        /// Rock Layer
        /// </summary>
        public short rockLayer = default(short);
        /// <summary>
        /// World ID
        /// </summary>
        public int worldId = default(int);
        /// <summary>
        /// World Name
        /// </summary>
        public string worldName = default(string);
        /// <summary>
        /// Game Mode
        /// </summary>
        public byte gameMode = default(byte);
        /// <summary>
        /// UUID
        /// </summary>
        public byte[] uuid = new byte[16];
        /// <summary>
        /// World Generator Version
        /// </summary>
        public ulong worldGeneratorVersion = default(ulong);
        /// <summary>
        /// Moon Type
        /// </summary>
        public byte moonType = default(byte);
        /// <summary>
        /// Tree BG1
        /// </summary>
        public byte treeBG1 = default(byte);
        /// <summary>
        /// Tree BG2
        /// </summary>
        public byte treeBG2 = default(byte);
        /// <summary>
        /// Tree BG3
        /// </summary>
        public byte treeBG3 = default(byte);
        /// <summary>
        /// Tree BG4
        /// </summary>
        public byte treeBG4 = default(byte);
        /// <summary>
        /// Corrupt BG
        /// </summary>
        public byte corruptBG = default(byte);
        /// <summary>
        /// Jungle BG
        /// </summary>
        public byte jungleBG = default(byte);
        /// <summary>
        /// Snow BG
        /// </summary>
        public byte snowBG = default(byte);
        /// <summary>
        /// Hallow BG
        /// </summary>
        public byte hallowBG = default(byte);
        /// <summary>
        /// Crimson BG
        /// </summary>
        public byte crimsonBG = default(byte);
        /// <summary>
        /// Desert BG
        /// </summary>
        public byte desertBG = default(byte);
        /// <summary>
        /// Ocean BG
        /// </summary>
        public byte oceanBG = default(byte);
        /// <summary>
        /// Mushroom BG
        /// </summary>
        public byte mushroomBG = default(byte);
        /// <summary>
        /// Underworld BG
        /// </summary>
        public byte underworldBG = default(byte);
        /// <summary>
        /// Ice back style
        /// </summary>
        public byte iceBackStyle = default(byte);
        /// <summary>
        /// Jungle back style
        /// </summary>
        public byte jungleBackStyle = default(byte);
        /// <summary>
        /// Hell back style
        /// </summary>
        public byte hellBackStyle = default(byte);
        /// <summary>
        /// Wind speed target
        /// </summary>
        public float windSpeedTarget = default(float);
        /// <summary>
        /// Clouds amount
        /// </summary>
        public byte numClouds = default(byte);
        /// <summary>
        /// Tree x
        /// </summary>
        public int[] treeX = new int[3];
        /// <summary>
        /// Tree style
        /// </summary>
        public byte[] treeStyle = new byte[4];
        /// <summary>
        /// Cave back x
        /// </summary>
        public int[] caveBackX = new int[3];
        /// <summary>
        /// Cave back style
        /// </summary>
        public byte[] caveBackStyle = new byte[4];
        /// <summary>
        /// Tree tops variations
        /// </summary>
        public byte[] treeTopsVariations = new byte[13];
        /// <summary>
        /// Max Raining
        /// </summary>
        public float maxRaining = default(float);
        /// <summary>
        /// World state part 1
        /// </summary>
        public BitsByte worldState1 = new BitsByte();
        /// <summary>
        /// World state part 2
        /// </summary>
        public BitsByte worldState2 = new BitsByte();
        /// <summary>
        /// World state part 3
        /// </summary>
        public BitsByte worldState3 = new BitsByte();
        /// <summary>
        /// World state part 4
        /// </summary>
        public BitsByte worldState4 = new BitsByte();
        /// <summary>
        /// World state part 5
        /// </summary>
        public BitsByte worldState5 = new BitsByte();
        /// <summary>
        /// World state part 6
        /// </summary>
        public BitsByte worldState6 = new BitsByte();
        /// <summary>
        /// World state part 7
        /// </summary>
        public BitsByte worldState7 = new BitsByte();
        /// <summary>
        /// Saved ore tiers copper
        /// </summary>
        public short savedOreTiersCopper = default(short);
        /// <summary>
        /// Saved ore tiers Iron
        /// </summary>
        public short savedOreTiersIron = default(short);
        /// <summary>
        /// Saved ore tiers silver
        /// </summary>
        public short savedOreTiersSilver = default(short);
        /// <summary>
        /// Saved ore tiers gold
        /// </summary>
        public short savedOreTiersGold = default(short);
        /// <summary>
        /// Saved ore tiers cobalt
        /// </summary>
        public short savedOreTiersCobalt = default(short);
        /// <summary>
        /// Saved ore tiers mythril
        /// </summary>
        public short savedOreTiersMythril = default(short);
        /// <summary>
        /// Saved ore tiers adamantite
        /// </summary>
        public short savedOreTiersAdamantite = default(short);
        /// <summary>
        /// Invasion Type
        /// </summary>
        public sbyte invasionType = default(sbyte);
        /// <summary>
        /// Lobby ID
        /// </summary>
        public ulong lobbyId = default(ulong);
        /// <summary>
        /// Sandstorm Intended Severity
        /// </summary>
        public float sandstormIntendedSeverity = default(float);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(time);
            worldTime.OnSerialize(writer);
            writer.Write(moonPhase);
            writer.Write(maxTilesX);
            writer.Write(maxTilesY);
            writer.Write(spawnTilesX);
            writer.Write(spawnTilesY);
            writer.Write(worldSurface);
            writer.Write(rockLayer);
            writer.Write(worldId);
            writer.Write(worldName);
            writer.Write(gameMode);
            for (var i = 0; i < 16; ++i) writer.Write(uuid[i]);
            writer.Write(worldGeneratorVersion);
            writer.Write(moonType);
            writer.Write(treeBG1);
            writer.Write(treeBG2);
            writer.Write(treeBG3);
            writer.Write(treeBG4);
            writer.Write(corruptBG);
            writer.Write(jungleBG);
            writer.Write(snowBG);
            writer.Write(hallowBG);
            writer.Write(crimsonBG);
            writer.Write(desertBG);
            writer.Write(oceanBG);
            writer.Write(mushroomBG);
            writer.Write(underworldBG);
            writer.Write(iceBackStyle);
            writer.Write(jungleBackStyle);
            writer.Write(hellBackStyle);
            writer.Write(windSpeedTarget);
            writer.Write(numClouds);
            for (var i = 0; i < 3; ++i) writer.Write(treeX[i]);
            for (var i = 0; i < 4; ++i) writer.Write(treeStyle[i]);
            for (var i = 0; i < 3; ++i) writer.Write(caveBackX[i]);
            for (var i = 0; i < 4; ++i) writer.Write(caveBackStyle[i]);
            for (var i = 0; i < 13; ++i) writer.Write(treeTopsVariations[i]);
            writer.Write(maxRaining);
            worldState1.OnSerialize(writer);
            worldState2.OnSerialize(writer);
            worldState3.OnSerialize(writer);
            worldState4.OnSerialize(writer);
            worldState5.OnSerialize(writer);
            worldState6.OnSerialize(writer);
            worldState7.OnSerialize(writer);
            writer.Write(savedOreTiersCopper);
            writer.Write(savedOreTiersIron);
            writer.Write(savedOreTiersSilver);
            writer.Write(savedOreTiersGold);
            writer.Write(savedOreTiersCobalt);
            writer.Write(savedOreTiersMythril);
            writer.Write(savedOreTiersAdamantite);
            writer.Write(invasionType);
            writer.Write(lobbyId);
            writer.Write(sandstormIntendedSeverity);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            time = reader.ReadInt32();
            worldTime.OnDeserialize(reader);
            moonPhase = reader.ReadByte();
            maxTilesX = reader.ReadInt16();
            maxTilesY = reader.ReadInt16();
            spawnTilesX = reader.ReadInt16();
            spawnTilesY = reader.ReadInt16();
            worldSurface = reader.ReadInt16();
            rockLayer = reader.ReadInt16();
            worldId = reader.ReadInt32();
            worldName = reader.ReadString();
            gameMode = reader.ReadByte();
            for (var i = 0; i < 16; ++i) uuid[i] = reader.ReadByte();
            worldGeneratorVersion = reader.ReadUInt64();
            moonType = reader.ReadByte();
            treeBG1 = reader.ReadByte();
            treeBG2 = reader.ReadByte();
            treeBG3 = reader.ReadByte();
            treeBG4 = reader.ReadByte();
            corruptBG = reader.ReadByte();
            jungleBG = reader.ReadByte();
            snowBG = reader.ReadByte();
            hallowBG = reader.ReadByte();
            crimsonBG = reader.ReadByte();
            desertBG = reader.ReadByte();
            oceanBG = reader.ReadByte();
            mushroomBG = reader.ReadByte();
            underworldBG = reader.ReadByte();
            iceBackStyle = reader.ReadByte();
            jungleBackStyle = reader.ReadByte();
            hellBackStyle = reader.ReadByte();
            windSpeedTarget = reader.ReadSingle();
            numClouds = reader.ReadByte();
            for (var i = 0; i < 3; ++i) treeX[i] = reader.ReadInt32();
            for (var i = 0; i < 4; ++i) treeStyle[i] = reader.ReadByte();
            for (var i = 0; i < 3; ++i) caveBackX[i] = reader.ReadInt32();
            for (var i = 0; i < 4; ++i) caveBackStyle[i] = reader.ReadByte();
            for (var i = 0; i < 13; ++i) treeTopsVariations[i] = reader.ReadByte();
            maxRaining = reader.ReadSingle();
            worldState1.OnDeserialize(reader);
            worldState2.OnDeserialize(reader);
            worldState3.OnDeserialize(reader);
            worldState4.OnDeserialize(reader);
            worldState5.OnDeserialize(reader);
            worldState6.OnDeserialize(reader);
            worldState7.OnDeserialize(reader);
            savedOreTiersCopper = reader.ReadInt16();
            savedOreTiersIron = reader.ReadInt16();
            savedOreTiersSilver = reader.ReadInt16();
            savedOreTiersGold = reader.ReadInt16();
            savedOreTiersCobalt = reader.ReadInt16();
            savedOreTiersMythril = reader.ReadInt16();
            savedOreTiersAdamantite = reader.ReadInt16();
            invasionType = reader.ReadSByte();
            lobbyId = reader.ReadUInt64();
            sandstormIntendedSeverity = reader.ReadSingle();
        }
    }
}

//Json file changed at 2020/6/10 1:05:09