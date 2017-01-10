using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SensorExam
{
    [DataContract]
    public class SensorModel
    {
        [DataMember]
        public int Temp { get; set; }
        [DataMember]
        public int Room { get; set; }
        [DataMember]
        public int Smoke { get; set; }


    }
}