using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    // In our database, we'll call the "Photo" entity "Photos", that's why we use Table("Photos") using DataAnnotation.Schema
    // When EntityFramewok wil lcreate the table, it'll call it Photos
    [Table("Photos")]
    public class Photo
    {
        public int Id {get; set;}
        public string Url {get; set;}
        public bool IsMain {get; set;}
        public string PublicId {get; set;}
    }
}