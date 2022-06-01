using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PhotoUrl {get;set;}
        // Because in AppUser class we have a property "GetAge()", if the mapper sees a method that starts with "Get" it will run the code inside the method to populate the attribute with the name of the other side of the "Get" ("Age" in our case) --> "Get" executes the method and "Age" is the name of the attribute which will take the value from the method (We could do "GetUsername" and inside the method we could return a FirstName+LastName and the attribute "Username" would pe poipulated with the return)
        // The automapper will also populate all the attributes with the same name from the AppUser to the MemberDto
        public int Age {get; set;}
        public string KnownAs {get; set;}
        public DateTime Created {get; set;}
        public DateTime LastActive {get; set;}
        public string Gender {get; set;}
        public string Introduction {get; set;}
        public string LookingFor {get; set;}
        public string Interests {get; set;}
        public string City {get; set;}
        public string Country {get; set;}
        // One-to-many relationship for photos (One user can have many photos)
        public ICollection<PhotoDto> Photos {get; set;}
    }
}