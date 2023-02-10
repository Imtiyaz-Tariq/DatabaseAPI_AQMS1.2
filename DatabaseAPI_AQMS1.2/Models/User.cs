using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DatabaseAPI_AQMS1._2.Models
{
    public class User
    {
       
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Password { get; set; }
        
    }
}
