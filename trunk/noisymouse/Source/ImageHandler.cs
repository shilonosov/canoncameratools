using System;
using System.IO;
using Source.Utils;

namespace Source
{
    public interface IImageHandler
    {
        string DisplayString { get;  }
        void Handle(ImageFile anImageFile);
    }

    public class SaveToFolderImageFileHandler : IImageHandler
    {
        private readonly Folder _folder;

        public string DisplayString
        {
            get { return string.Format("Save to [{0}]", _folder.FolderPath); }
        }

        public SaveToFolderImageFileHandler(Folder aFolder)
        {
            _folder = aFolder;
        }

        public void SetPath(string aFolderPath)
        {
            _folder.FolderPath = aFolderPath;
        }

        public void Handle(ImageFile anImageFile)
        {
            using (FileStream fileStream = File.Create(_folder.ComposeFilename(anImageFile.Filename)))
            {
                fileStream.Write(anImageFile.Bytes, 0, anImageFile.Bytes.Length);
            }
        }

        public override string ToString()
        {
            return DisplayString;
        }
    }

    public class StubHandler: IImageHandler
    {
        public string DisplayString
        {
            get { return "No Action"; }
        }

        public void Handle(ImageFile anImageFile)
        {
        }
    }
}
