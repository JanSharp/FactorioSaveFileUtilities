namespace FactorioSaveFileUtilities.Infrastructure
{
    public class ModInSaveData
    {
        public string Name { get; set; }

        public ushort Major { get; set; }
        public ushort Minor { get; set; }
        public ushort Patch { get; set; }

        public uint CRC { get; set; }
    }
}
