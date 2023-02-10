namespace DatabaseAPI_AQMS1._2.Models
{
    public class Sensor
    {
        public string SensorId { get; set; }
        public int mpd_Flr { get; set; } //Floor to which the sensor is mapped to
        public DateTime StreamTime { get; set; }
        public double pm25 { get; set; } //Dust prticles in air to be changed to pm25
        public double o3 { get; set; } // Carbon dioxide to be changed to o3
        public double co { get; set; }  //Carbon Monoxide
        public double no2 { get; set; } // Nitrogen Dioxide
        public double so2 { get; set; } // Sulphur Dioxide
    }
}
