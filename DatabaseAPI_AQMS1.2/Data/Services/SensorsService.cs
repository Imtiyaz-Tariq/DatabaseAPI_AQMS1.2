using DatabaseAPI_AQMS1._2.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseAPI_AQMS1._2.Data.Services
{
    public class SensorsService : ISensorsService
    {
        // Creating database context variable
        private SensorDbContext _dbContext;

        //Constructor
        public SensorsService(SensorDbContext context)
        {
            _dbContext = context;
        }

        public List<Sensor> GetSensors() => _dbContext.Sensors.ToList();
        public List<Sensor> GetBySpan(int sec)
        {
            TimeSpan span = TimeSpan.FromSeconds(sec); //FromMinutes(sec);;
            DateTime now = DateTime.Now;
            DateTime spanPastNow = now.Subtract(span);
            // querying records between now and sec seconds pastnow
            var Sensors = _dbContext.Sensors.Where(a => a.StreamTime > spanPastNow && a.StreamTime < now).ToList();
            return Sensors;
        }
        public List<Sensor> GetByFlr(int flr)
        {
            try
            {
                //querying data for a particular floor
                var Sensors = _dbContext.Sensors.Where(a => a.mpd_Flr == flr).ToList();
                if (Sensors.Count() == 0)
                {
                    return null;
                }
                return Sensors;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void Post(Sensor sensor)
        {
            try
            {
                sensor.StreamTime = DateTime.Now;
                _dbContext.Sensors.Add(sensor);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
