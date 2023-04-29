using System.ComponentModel.DataAnnotations;

namespace SitioWeb_Razor_Helper.Models
{
    public class tipo_equipo
    {

        [Key]
        public int id_tipo_equipo { get; set; }
        public string? descripcion { get; set; }
        public string? estado { get; set; }

    }
}
