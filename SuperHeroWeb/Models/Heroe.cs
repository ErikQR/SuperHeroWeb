using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace SuperHeroWeb.Models
{
    public class Heroe
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar su numero de Heroe")]
        [Display(Name = "Numero de Heroe")]
        public int NumerodeHeroe { get; set; }
        [Display(Name = "Nombre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar su Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Nombre de Alias")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar su Alias de Heroe")]
        public string Alias { get; set; }
        [Display(Name = "Correo Electronico")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar su correo electronico")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)", ErrorMessage = "Correo inválido")]
        public string Correo { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNac { get; set; }
        [Display(Name = "Edad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar su Edad")]
        public int Edad { get; set; }
        [Display(Name = "Contratado?")]
        public bool Contratado { get; set; }
        [Display(Name = "Altura")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar su altura")]
        public float Altura { get; set; }
        [Display(Name = "Peso")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar su peso")]
        public float Peso { get; set; }

        public Heroe() { 
        
        }

        //public Heroe(int numerodeHeroe, string nombre, string alias, string correo, DateTime fechaNac, int edad, bool contratado, float altura, float peso)
        //{
        //    NumerodeHeroe = numerodeHeroe;
        //    Nombre = nombre;
        //    Alias = alias;
        //    Correo = correo;
        //    FechaNac = fechaNac;
        //    Edad = edad;
        //    Contratado = contratado;
        //    Altura = altura;
        //    Peso = peso;
        //}
    }
}