using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Source;
using System.Windows.Forms;
using Source.Utils;

namespace ExternalStorage
{
    public partial class MainWindow : Window, ICameraNotifications
    {
        private ICameraPool _cameraPool;
        private IImageHandler _imageHandler;
        private FolderBrowserDialog _folderBrowser;

        public ICameraInfo[] CameraList
        {
            get
            {
                return _cameraPool.CameraList;
            }
        }

        private IImageHandler ImageHandler
        {
            get
            {
                if (_imageHandler == null)
                {
                    _imageHandler = ConstructImageHandler();
                }
                return _imageHandler;
            }
        }

        private Folder Folder {
            get
            {
                _folderBrowser.ShowDialog();
                return new Folder(_folderBrowser);
            }
        }

        public MainWindow()
        {
            _cameraPool = new CameraPool(this, Dispatcher);
            _folderBrowser = new FolderBrowserDialog();
            InitializeComponent();
        }

        private IImageHandler ConstructImageHandler()
        {
            return new SaveToFolderImageFileHandler(Folder);
        }

        public void ShuttedDown()
        {
        }

        public void WillSoonShutDown(ICamera aCamera)
        {
        }

        public void CameraDone()
        {
        }

        public void Log(string message)
        {
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Array.ForEach<ICameraInfo>(CameraList, (cameraInfo) => { _cameraPool.StartListenTakeImage(cameraInfo, ImageHandler); });
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Array.ForEach<ICameraInfo>(CameraList, (cameraInfo) => { _cameraPool.StopListenTakeImage(cameraInfo); });
        }

        public string DisplayString
        {
            get { return "External storage"; }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (_folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
        }
    }
}
