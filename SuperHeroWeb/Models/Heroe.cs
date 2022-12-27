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

        [Display(Name = "Nombre de SuperHeroe")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar su Alias de Heroe")]
        public string Nombre { get; set; }

        [Display(Name = "Superpoder")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar su Nombre")]
        public string Superpoder { get; set; }

        [Display(Name = "Nivel de poder")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar su Edad")]
        public int Nivel { get; set; }

        [Display(Name = "Retirado?")]
        public bool Retirado { get; set; }

        [Display(Name = "Correo de contacto")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar su correo electronico")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)", ErrorMessage = "Correo inválido")]
        public string Correo { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNac { get; set; }

        [Display(Name = "Altura")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar su altura")]
        public float Altura { get; set; }

        [Display(Name = "Peso")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar su peso")]
        public float Peso { get; set; }

        public Heroe() { 
            
        }
        public Heroe( string nombre, string superpoder, int nivel, bool retirado, string correo, DateTime fechaNac, float altura, float peso) { 
            Nombre = nombre;
            Superpoder = superpoder;
            Nivel = nivel;
            Retirado = retirado;
            Correo = correo;
            FechaNac = fechaNac;
            Altura = altura;
            Peso = peso;
        }
    }
}