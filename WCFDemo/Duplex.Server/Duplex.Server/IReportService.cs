﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Duplex.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract =typeof(IReportServiceCallback))]
    public interface IReportService
    {
        [OperationContract(IsOneWay =true)]
        void ProcessReport();

    }

    public interface IReportServiceCallback
    {
        [OperationContract(IsOneWay =true)]
        void Progress(int  percentageCompleted);

    }


}
