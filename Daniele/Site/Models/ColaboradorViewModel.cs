using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class ColaboradorViewModel
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage ="Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Telefone é obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage ="Tipo de telefone é obrigatório")]
        public string TipoTelefone { get; set; }
    }
}