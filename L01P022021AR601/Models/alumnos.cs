using System.ComponentModel.DataAnnotations;

namespace L01P022021AR601.Models
{
    public class alumnos
    {
        [Key]       
        public int codigo { get; set; }

       
        public string? nombre { get; set; }

        
        public string? apellidos { get; set; }

       
        public int? dui { get; set; }

       
       
        public int? estado { get; set; }

    }
}
