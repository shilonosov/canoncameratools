using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Source
{
    public class ImageFile
    {
        private readonly byte[] _bytes;
        private readonly string _filename;

        public string Filename
        {
            get { return _filename; }
        }

        public byte[] Bytes
        {
            get { return _bytes; }
        }

        public ImageFile()
        {
        }

        public ImageFile(byte[] aBytes, string aFilename)
        {
            _bytes = aBytes;
            _filename = aFilename;
        }
    }
}
