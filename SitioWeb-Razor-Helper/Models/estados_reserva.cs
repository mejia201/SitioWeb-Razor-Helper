using System.ComponentModel.DataAnnotations;

namespace SitioWeb_Razor_Helper.Models
{
    public class estados_reserva
    {
        [Key]
        public int estado_res_id { get; set; }
        public string? estado { get; set; }
    }
}
