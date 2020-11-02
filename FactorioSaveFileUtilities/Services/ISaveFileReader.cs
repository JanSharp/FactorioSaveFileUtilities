using System.IO.Compression;
using FactorioSaveFileUtilities.Infrastructure;

namespace FactorioSaveFileUtilities.Services
{
    public interface ISaveFileReader
    {
        SaveFileData ReadSaveFile(ZipArchive save);
    }
}
