using System;

namespace Source
{
    public class Image
    {
        private readonly ICameraInfo _cameraInfo;
        private readonly IShootParameters _parameters;
        private readonly IImageHandler _handler;

        public ICameraInfo CameraInfo
        {
            get { return _cameraInfo; }
        }

        public string DisplayString
        {
            get { return string.Format("{0}\t{1}\t{2}", CameraDisplayString, ParametersDisplayString, HandlerDisplayString);  }
        }

        public string CameraDisplayString
        {
            get { return string.Format("{0} - {1}", _cameraInfo.ProductName, _cameraInfo.OwnerName); }
        }

        public string ParametersDisplayString
        {
            get { return _parameters.DisplayString; }
        }

        public string HandlerDisplayString
        {
            get { return _handler.DisplayString; }
        }

        public Image(ICameraInfo aCameraInfo, IShootParameters aParameters, IImageHandler aHandler)
        {
            _cameraInfo = aCameraInfo;
            _parameters = aParameters;
            _handler = aHandler;
        }

        public void Make(ICameraPool aPool)
        {
            //aPool.GetCamera(_cameraInfo.Id).MakeAShoot(_parameters, _handler);
            aPool.TakeAPicture(_cameraInfo.Id, _parameters, _handler);
        }

        public void PressShutterButton(ICameraPool aPool)
        {
            //aPool.GetCamera(_cameraInfo.Id).Camera.PressShutterButton(_handler);
            aPool.PressShutterButton(_cameraInfo.Id, _handler);
        }
    }
}
