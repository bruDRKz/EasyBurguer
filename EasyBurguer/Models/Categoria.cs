﻿using Microsoft.Extensions.WebEncoders.Testing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EasyBurguer.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }
        //-------------------------------------------------------------------------------------
        [StringLength(100, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [Display(Name = "Nome")]
        public string CategoriaNome { get; set; }
        //--------------------------------------------------------------------------------
        [StringLength(200, ErrorMessage = "O tamanho máximo é 200 caracteres")]
        [Required(ErrorMessage = "Informe a Descrição da Categoria!")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public List<Lanche> Lanches { get; set; }

    }
}
