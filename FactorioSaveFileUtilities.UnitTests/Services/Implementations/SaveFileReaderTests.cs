using System.IO;
using System.IO.Compression;
using System.Text;
using FactorioSaveFileUtilities.Services.Implementations;
using NUnit.Framework;

namespace FactorioSaveFileUtilities.UnitTests.Services.Implementations
{
    [TestFixture]
    public class SaveFileReaderTests
    {
        [Test]
        public void ReadSaveFile_Scenario_Behavior()
        {
            // Arrange
            var reader = new SaveFileReader();
            using var stream = new FileStream(@"E:\ProgramsManual\Factorio\Modding\saves\temp1.zip", FileMode.Open, FileAccess.Read);
            var zipArchive = new ZipArchive(stream, ZipArchiveMode.Read, true, Encoding.UTF8);

            // Act
            var saveFileData = reader.ReadSaveFile(zipArchive);

            // Assert
        }
    }
}
