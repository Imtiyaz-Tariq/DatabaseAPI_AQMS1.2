using DatabaseAPI_AQMS1._2.Controllers;
using DatabaseAPI_AQMS1._2.Data;
using DatabaseAPI_AQMS1._2.Data.Services;
using DatabaseAPI_AQMS1._2.Models;
using EntityFrameworkCoreMock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestProject1
{
    public class SensorsServiceTest
    {
        private readonly ISensorsService _sensorsService;

        //constructor
        public SensorsServiceTest()
        {
            DateTime now = DateTime.Now;
            var SensorsInitialData = new List<Sensor>() { new Sensor() {
                        SensorId = "1",
                        mpd_Flr = 1,
                        StreamTime = now.Subtract(TimeSpan.FromSeconds(15)),
                        pm25 = 200,
                        o3 = 300,
                        co = 400,
                        no2= 400,
                        so2 = 100
                    },
                     new Sensor() {
                        SensorId = "2",
                        mpd_Flr = 1,
                        StreamTime = now.Subtract(TimeSpan.FromSeconds(15)),
                        pm25 = 200,
                        o3 = 300,
                        co = 400,
                        no2= 400,
                        so2 = 100
                    },
                     new Sensor() {
                        SensorId = "3",
                        mpd_Flr = 2,
                        StreamTime = now.Subtract(TimeSpan.FromSeconds(30)),
                        pm25 = 200,
                        o3 = 300,
                        co = 400,
                        no2= 400,
                        so2 = 100
                    },
                     new Sensor() {
                        SensorId = "4",
                        mpd_Flr = 2,
                        StreamTime = now.Subtract(TimeSpan.FromSeconds(30)),
                        pm25 = 200,
                        o3 = 300,
                        co = 400,
                        no2= 400,
                        so2 = 100
                    },
                     new Sensor() {
                        SensorId = "5",
                        mpd_Flr = 3,
                        StreamTime = now.Subtract(TimeSpan.FromSeconds(45)),
                        pm25 = 200,
                        o3 = 300,
                        co = 400,
                        no2= 400,
                        so2 = 100
                    },
                     new Sensor() {
                        SensorId = "6",
                        mpd_Flr = 3,
                        StreamTime = now.Subtract(TimeSpan.FromSeconds(45)),
                        pm25 = 200,
                        o3 = 300,
                        co = 400,
                        no2= 400,
                        so2 = 100
                    }, };
            DbContextMock<SensorDbContext> dbContextMock = new DbContextMock<SensorDbContext>(
                new DbContextOptionsBuilder<SensorDbContext>().Options
                );
            SensorDbContext dbContext = dbContextMock.Object;
            dbContextMock.CreateDbSetMock(temp => temp.Sensors, SensorsInitialData);

            _sensorsService = new SensorsService(dbContext);
        }
        [Fact]
        
            public void HttpGET_GetAllSensorsData()
            {
                var Result = _sensorsService.GetSensors();
                Assert.Equal(6,Result.Count);
            }
        [Fact]
        public void HttpGET_GetByFlrId_ValidFlr()
        {
            var Result = _sensorsService.GetByFlr(3);
            Assert.Equal(2, Result.Count);
            Assert.Equal(3, Result[0].mpd_Flr);
            Assert.Equal(3, Result[1].mpd_Flr);
        }
        [Fact]
        public void HttpGET_GetByFlrId_InvalidFlr()
        {
            var Result = _sensorsService.GetByFlr(4);
            Assert.Null(Result);
        }
        [Fact]
        public void HttpGET_GetBySpan_ReturnSensor1And2()
        {
            var Result = _sensorsService.GetBySpan(16);
            Assert.Equal(2,Result.Count);
            Assert.Equal("1", Result[0].SensorId);
            Assert.Equal("2",Result[1].SensorId);
        }

        [Fact]
        public void HttpGET_GetBySpan_ReturnSensor123And4()
        {
            var Result = _sensorsService.GetBySpan(31);
            Assert.Equal(4, Result.Count);
            Assert.Equal("1", Result[0].SensorId);
            Assert.Equal("2", Result[1].SensorId);
            Assert.Equal("3", Result[2].SensorId);
            Assert.Equal("4", Result[3].SensorId);
        }

        [Fact]
        public void HttpGET_GetBySpan_ReturnSensor12345And6()
        {
            var Result = _sensorsService.GetBySpan(46);
            Assert.Equal(6, Result.Count);
            Assert.Equal("1", Result[0].SensorId);
            Assert.Equal("2", Result[1].SensorId);
            Assert.Equal("3", Result[2].SensorId);
            Assert.Equal("4", Result[3].SensorId);
            Assert.Equal("5", Result[4].SensorId);
            Assert.Equal("6", Result[5].SensorId);
        }

        [Fact]
        public void HttpPost_AddSensordata()
        {
            var Sensors = new Sensor()
            {
                SensorId = "7",
                mpd_Flr = 1,
                pm25 = 200,
                co = 300,
                no2 = 400,
                o3 = 400,
                so2 = 100
            };
            _sensorsService.Post(Sensors);
            var GetAll = _sensorsService.GetSensors();

            Assert.Equal(Sensors,GetAll.Last());
        }

    }
}