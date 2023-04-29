﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SitioWeb_Razor_Helper.Models;
using System.Text.RegularExpressions;

namespace SitioWeb_Razor_Helper.Controllers
{
    public class EquiposController : Controller
    {

        private readonly equiposDbContext _equiposContext;

        public EquiposController(equiposDbContext equiposContext)
        {
            _equiposContext = equiposContext;
        }

        public IActionResult Index()
        {
            ViewData["listaMarcas"] = new SelectList(listarMarcas(), "id_marcas", "nombre_marca");
            ViewData["listaTipoEquipos"] = new SelectList(ListarTipoEquipos(), "id_tipo_equipo", "descripcion");
            ViewData["listadoEstadosEquipos"] = new SelectList(ListarEstadosEquipos(), "id_estados_equipo", "descripcion");
            ViewData["listadoEquipos"] = listarEquipos();

            return View();
        }

        public IActionResult CrearEquipo(equipos nuevoEquipo)
        {
            _equiposContext.Add(nuevoEquipo);
            _equiposContext.SaveChanges();
            return RedirectToAction("Index");
        }



        // Utils 
        public List<marcas> listarMarcas()
        {
            var listaMarcas = (from marcas in _equiposContext.marcas select marcas).ToList();

            return listaMarcas;
        }

        public List<tipo_equipo> ListarTipoEquipos()
        {

            var listaTiposEquipos = (from tipo in _equiposContext.tipo_equipo select tipo).ToList();

            return listaTiposEquipos;

        }

        public List<estados_equipo> ListarEstadosEquipos()
        {

            var listadoEstadoEquipos = (from estado in _equiposContext.estados_equipo select estado).ToList();

            return listadoEstadoEquipos;

        }

        public List<EquipoConMarca> listarEquipos()
        {
            List<EquipoConMarca> listadoEquipos = (from e in _equiposContext.equipos
                                                   join m in _equiposContext.marcas on e.marca_id equals m.id_marcas
                                                   select new EquipoConMarca
                                                   {
                                                       nombre = e.nombre,
                                                       descripcion = e.descripcion,
                                                       marca_id = (int)e.marca_id,
                                                       marca_nombre = m.nombre_marca
                                                   }).ToList();

            return listadoEquipos;
        }

        public class EquipoConMarca
        {
            public string? nombre { get; set; }
            public string? descripcion { get; set; }
            public int marca_id { get; set; }
            public string? marca_nombre { get; set; }
        }
    }
}

