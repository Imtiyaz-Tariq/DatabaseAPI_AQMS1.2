using DatabaseAPI_AQMS1._2.Models;

namespace DatabaseAPI_AQMS1._2.Data.Services
{
    public interface ISensorsService
    {
        List<Sensor> GetSensors();
        List<Sensor> GetBySpan(int min);
        List<Sensor> GetByFlr(int flr);
        void Post(Sensor sensor);
    }
}
