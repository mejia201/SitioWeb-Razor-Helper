﻿using System.ComponentModel.DataAnnotations;

namespace SitioWeb_Razor_Helper.Models
{
    public class marcas
    {
        [Key]
        [Display(Name = "ID")]
        public int id_marcas { get; set; }
        [Display(Name = "Nombre de la marca")]
        public string? nombre_marca { get; set; }

        [Display(Name = "Estado = A: Activo, I: Inactivo")]
        public string? estados { get; set; }
    }
}
