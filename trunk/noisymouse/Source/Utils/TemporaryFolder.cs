using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Source.Utils
{
    public class Folder
    {
        protected string _folderPath;

        public string FolderPath
        {
            get { return _folderPath; }
            set { _folderPath = value; }
        }

        public Folder(string aFolderFilename)
        {
            _folderPath = aFolderFilename;
        }

        public Folder(FolderBrowserDialog aDialog): this(aDialog.SelectedPath)
        {
        }

        public string ComposeFilename(string aFilename)
        {
            return Path.Combine(_folderPath, aFilename);
        }
    }

    public class TemporaryFolder : Folder, IDisposable
    {
        public static string CurrentDirectory
        {
            get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); }
        }

        public TemporaryFolder()
            : base(Path.Combine(CurrentDirectory, Guid.NewGuid().ToString()))
        {
            Directory.CreateDirectory(_folderPath);
        }

        public void Dispose()
        {
            Directory.Delete(_folderPath, true);
        }
    }
}