using DatabaseAPI_AQMS1._2.Controllers;
using DatabaseAPI_AQMS1._2.Data;
using DatabaseAPI_AQMS1._2.Data.Services;
using DatabaseAPI_AQMS1._2.Models;
using EntityFrameworkCoreMock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AQMS_Test
{
    public class ServiceTest
    {
        private readonly ISensorsService _sensorsService;

        //constructor
        //[SetUp] //setup databse ony one time
        public ServiceTest()
        {
            var SensorsInitialData = new List<Sensor>() { };
            DbContextMock<SensorDbContext> dbContextMock = new DbContextMock<SensorDbContext>(
                new DbContextOptionsBuilder<SensorDbContext>().Options
                );
            SensorDbContext dbContext = dbContextMock.Object;
            dbContextMock.CreateDbSetMock(temp => temp.Sensors, SensorsInitialData);

            _sensorsService = new SensorsService( dbContext );
        }
        //private static DbContextOptions<SensorDbContext> dbContextOptions = new DbContextOptionsBuilder<SensorDbContext>()
        //   .UseInMemoryDatabase(databaseName: "AQMSDbTest")
        //   .Options;

        //SensorDbContext context;
        //SensorController SensorController;


        [Test, Order(1)]
        public void HttpGET_GetAllSensorsData()
        {
            var Result = _sensorsService.GetSensors();
            Assert.That(Result, Is.EqualTo(null));
            //var ResultData = (Result as OkObjectResult).Value as IEnumerable<Sensor>;
            ///*var Result = SensorController.Get();*/
            //Assert.That(ResultData.Count, Is.EqualTo(6));
            //Assert.That(ResultData.First().Id, Is.EqualTo(1));
        }
    }
}