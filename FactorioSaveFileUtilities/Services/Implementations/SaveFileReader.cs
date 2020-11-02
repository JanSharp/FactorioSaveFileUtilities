using System.IO;
using System.IO.Compression;
using System.Linq;
using FactorioSaveFileUtilities.Infrastructure;

namespace FactorioSaveFileUtilities.Services.Implementations
{
    public class SaveFileReader : ISaveFileReader
    {
        public SaveFileData ReadSaveFile(ZipArchive save)
        {
            var levelDatEntry = save.Entries.Single(e => Path.GetFileName(e.Name) == "level.dat");
            using var stream = levelDatEntry.Open();
            return SaveFileData.Deserialize(stream);
        }

        public SaveFileData ReadSaveFile(Stream save)
        {
            return ReadSaveFile(new ZipArchive(save));
        }
    }
}
