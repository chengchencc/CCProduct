using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Media.Capture;

namespace App1.Api
{
    class Capture
    {

        MediaCapture capture = null;

        /// <summary>
        /// 通过该属性获得MediaCapture实例
        /// </summary>
        internal MediaCapture PhotoCaptureForCurrent
        {
            get { return capture; }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        internal async Task InitailizeCapture()
        {
            var devs = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            DeviceInformation bc = devs.FirstOrDefault(d => d.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Back);
            if (bc != null)
            {
                MediaCaptureInitializationSettings settings = new MediaCaptureInitializationSettings();
                settings.AudioDeviceId = "";
                settings.VideoDeviceId = bc.Id;
                capture = new MediaCapture();
                await capture.InitializeAsync(settings);
                //var photo = await capture.CapturePhotoToStreamAsync();
            }

        }

        /// <summary>
        /// 清理
        /// </summary>
        internal void ClearupCapture()
        {
            if (capture != null)
            {
                capture.Dispose();
                capture = null;
            }
        }

    }
}
