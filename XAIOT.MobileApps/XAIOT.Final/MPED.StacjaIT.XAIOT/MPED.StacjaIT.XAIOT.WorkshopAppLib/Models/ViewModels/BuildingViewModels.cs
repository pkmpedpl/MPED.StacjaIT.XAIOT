using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPED.StacjaIT.XAIOT.Models.ViewModels
{
    public class BuildingViewModel
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public List<ZoneViewModel> Zones { get; set; }
    }

    public class ZoneViewModel
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public System.Guid BuildingId { get; set; }
        public List<ControlCircuitViewModel> ControlCircuits { get; set; }
    }

    public class UpdateSensorsDataViewModel
    {
        public System.Guid Id { get; set; }
        public Nullable<decimal> SensorTemperature { get; set; }
        public Nullable<decimal> SensorHumidity { get; set; }
        public Nullable<bool> SensorPIR { get; set; }
        public Nullable<int> SensorLux { get; set; }
    }

    public class ControlCircuitViewModel
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public System.Guid ZoneId { get; set; }
        public string I2CSlaveAddress { get; set; }
        public Nullable<decimal> SensorTemperature { get; set; }
        public Nullable<decimal> SensorHumidity { get; set; }
        public Nullable<bool> SensorPIR { get; set; }
        public Nullable<int> SensorLux { get; set; }
        public int I2CSlaveAddressId
        {
            get
            {
                return Convert.ToByte(I2CSlaveAddress, 16);
            }
        }
        public List<ControlCircuitDeviceViewModel> ControlCircuitDevices { get; set; }

        public struct SensorSturct
        {
            public Sensors.AmbientLight AmbientLight;
            public Sensors.PassiveIR PassiveIR;
            public Sensors.Temperature Temperature;
            public Sensors.Humidity Humidity;
            public Sensors.LoopIteration LoopIteration;
        }

        /// <summary>
        /// Provides access to the sensors of the room
        /// </summary>
        public SensorSturct Sensors = new SensorSturct();

        public ControlCircuitViewModel()
        {            
            Sensors.AmbientLight = new Sensors.AmbientLight();
            Sensors.PassiveIR = new Sensors.PassiveIR();
            Sensors.Temperature = new Sensors.Temperature();
            Sensors.Humidity = new Sensors.Humidity();
            Sensors.LoopIteration = new Sensors.LoopIteration();
        }
    }

    public class ControlCircuitDeviceViewModel
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public int Pin { get; set; }
        public int Status { get; set; }
        public System.Guid ControlCircuitId { get; set; }        
    }
}
