using System.ComponentModel.DataAnnotations;

namespace L01P022021AR601.Models
{
    public class materias
    {
        [Key]
       

        public string? materia { get; set; }


        public int? unidades_valorativas { get; set; }

        public string? estado { get; set; }



    }
}
