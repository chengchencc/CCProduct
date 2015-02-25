using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Media.Capture;

namespace App1.Api
{
     class ElectricTorch
    {
        #region 私有字段
         MediaCapture m_capture = null;
         bool m_istorchOpened = false;
         bool m_iscaptureCreated = false;
        #endregion

        #region 属性
        /// <summary>
        /// 指示摄像是否已打开
        /// </summary>
        public  bool IsTorchOpened
        {
            get { return m_istorchOpened; }
        }
        /// <summary>
        /// 指示MediaCapture是否已初始化
        /// </summary>
        public  bool IsCaptureCreated
        {
            get { return m_iscaptureCreated; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 初始化捕捉对象
        /// </summary>
        public async  Task CreateCaptureAsync()
        {
            // 找出后置摄像头，一般闪光灯在后置摄像头上
            DeviceInformation backCapture = (from d in await GetCaptureDeviceseAsync() where d.EnclosureLocation.Panel == Panel.Back select d).FirstOrDefault();

            if (backCapture != null)
            {
                MediaCaptureInitializationSettings settings = new MediaCaptureInitializationSettings();
                settings.VideoDeviceId = backCapture.Id; //设备ID
                settings.StreamingCaptureMode = StreamingCaptureMode.Video;
                settings.PhotoCaptureSource = PhotoCaptureSource.Auto;
                // 初始化
                m_capture = new MediaCapture();
                await m_capture.InitializeAsync(settings);
                m_iscaptureCreated = true;
            }
        }

        /// <summary>
        /// 获取摄像头设备列表（前置，后置摄像头）
        /// </summary>
        /// <returns></returns>
        private async  Task<DeviceInformation[]> GetCaptureDeviceseAsync()
        {
            var dvs = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            return dvs.ToArray();
        }

        /// <summary>
        /// 清理捕捉对象
        /// </summary>
        /// <returns></returns>
        public  void CleanupCaptureAsync()
        {
            if (m_capture != null)
            {
                m_capture.Dispose();
                m_capture = null;
                m_iscaptureCreated = false;
            }
        }

        public  void OpenTorch()
        {
            // 开闪光灯
            var vdcontrol = m_capture.VideoDeviceController.TorchControl;
            if (vdcontrol.Supported)
            {
                vdcontrol.Enabled = true;
                m_istorchOpened = true;
            }
        }

        public  void CloseTorch()
        {
            // 关闭闪光灯
            var torch = m_capture.VideoDeviceController.TorchControl;
            if (torch.Supported)
            {
                torch.Enabled = false;
                m_istorchOpened = false;
            }
        }


        #endregion


        void App_UnhandledException ( )
        {

            this.CleanupCaptureAsync();
        }

        private async void OnResuming() //( object sender, object e )
        {
            await this.CreateCaptureAsync();
        }
        private void OnSuspending()//(object sender, SuspendingEventArgs e)
        {
            //var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: 保存应用程序状态并停止任何后台活动
            this.CleanupCaptureAsync();
            //deferral.Complete();
        }

    }

    
}
