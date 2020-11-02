using System.IO;
using System.Text;

namespace FactorioSaveFileUtilities.Infrastructure
{
    public class SaveFileData
    {
        public ushort FactorioVersionMajor { get; set; }
        public ushort FactorioVersionMinor { get; set; }
        public ushort FactorioVersionPatch { get; set; }
        public ushort FactorioVersionBuild { get; set; }

        public string ScenarioName { get; set; }

        public ModInSaveData[] ModsInSave { get; set; }

        public static SaveFileData Deserialize(Stream input)
        {
            using BinaryReader binaryReader = new BinaryReader(input, Encoding.UTF8, true);

            SaveFileData result = new SaveFileData();

            result.FactorioVersionMajor = binaryReader.ReadUInt16();
            result.FactorioVersionMinor = binaryReader.ReadUInt16();
            result.FactorioVersionPatch = binaryReader.ReadUInt16();
            result.FactorioVersionBuild = binaryReader.ReadUInt16();

            binaryReader.ReadBytes(2); // unknown

            result.ScenarioName = binaryReader.ReadString();

            binaryReader.ReadString(); // always "base"
            CustomReadUInt16(binaryReader); // major
            CustomReadUInt16(binaryReader); // minor
            CustomReadUInt16(binaryReader); // patch
            binaryReader.ReadBytes(4 + 7); // 4 for crc, 7 for unknown

            byte modsCount = binaryReader.ReadByte();
            result.ModsInSave = new ModInSaveData[modsCount];

            for (int i = 0; i < modsCount; i++)
            {
                ModInSaveData mod = new ModInSaveData();
                result.ModsInSave[i] = mod;

                mod.Name = binaryReader.ReadString();
                mod.Major = CustomReadUInt16(binaryReader);
                mod.Minor = CustomReadUInt16(binaryReader);
                mod.Patch = CustomReadUInt16(binaryReader);
                mod.CRC = binaryReader.ReadUInt32();
            }

            return result;
        }

        public static ushort CustomReadUInt16(BinaryReader reader)
        {
            byte first = reader.ReadByte();
            if (first == 0xFF)
            {
                return reader.ReadUInt16();
            }
            return first;
        }
    }
}
