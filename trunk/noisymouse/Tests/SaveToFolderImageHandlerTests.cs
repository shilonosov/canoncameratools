using System.IO;
using NUnit.Framework;
using Source;
using Source.Utils;

namespace Tests
{
    [TestFixture]
    public class SaveToFolderImageFileHandlerTests
    {
        [Test]
        public void TestSaveFile()
        {
            using(TemporaryFolder folder = new TemporaryFolder())
            {
                const string filename = "filename";
                byte[] bytes = new byte[] {1, 2, 4, 54};

                ImageFile imageFile = new ImageFile(bytes, filename);

                SaveToFolderImageFileHandler handler = new SaveToFolderImageFileHandler(folder);
                handler.Handle(imageFile);

                Assert.That(File.Exists(folder.ComposeFilename(filename)));
                Assert.AreEqual(bytes, File.ReadAllBytes(folder.ComposeFilename(filename)));
            }
        }

        [Test]
        public void ToStringTest()
        {
            const string folder = "folder";

            SaveToFolderImageFileHandler handler = new SaveToFolderImageFileHandler(new Folder(folder));

            Assert.AreEqual(string.Format("Save to [{0}]", folder), handler.ToString());
            Assert.AreEqual(string.Format("Save to [{0}]", folder), handler.DisplayString);
        }
    }
}