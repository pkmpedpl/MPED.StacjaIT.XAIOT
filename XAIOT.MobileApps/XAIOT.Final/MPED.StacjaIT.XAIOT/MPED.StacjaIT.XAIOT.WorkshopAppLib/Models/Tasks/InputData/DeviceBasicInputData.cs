using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPED.StacjaIT.XAIOT.Models.Tasks.InputData
{
    public class DeviceBasicInputData
    {
        public Guid ZoneId { get; set; }
        public int DevicePin { get; set; }
        public string ControlCircuit { get; set; }
        public int ControlCircuitId
        {
            get
            {
                return Convert.ToByte(ControlCircuit, 16);
            }
        }
    }
}
