using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyBurguer.Models
{
    
    public class Lanche
    {
        
        public int LancheID { get; set; }

   //---------------------------------------------------------------------------------------
        [StringLength(80, MinimumLength =10, ErrorMessage = "O tamanho do nome é de no minímo 10 e no máximo 80 caracteres.")]
        [Required(ErrorMessage = "O nome deve ser informado!")]
        [Display(Name = "Nome do lanche")]
        public string Nome { get; set; }
        //---------------------------------------------------------------------------------------
        [StringLength(200, MinimumLength = 20, ErrorMessage = "O tamanho do nome é de no minímo 20 e no máximo 200 caracteres.")]
        [Required(ErrorMessage = "A descrição do lanche deve ser informada!")]
        [Display(Name = "Descrição do lanche")]
        public string DescricaoCurta { get; set; }
        //---------------------------------------------------------------------------------------
        [StringLength(200, MinimumLength = 20, ErrorMessage = "O tamanho do nome é de no minímo 20 e no máximo 200 caracteres.")]
        [Required(ErrorMessage = "A descrição detalhada deve ser informada!")]
        [Display(Name = "Descrição detalhada do lanche")]
        public string DescricaoDetalhada { get; set; }

        //---------------------------------------------------------------------------------------
        [Required(ErrorMessage ="Informe o preço do lanche")]
        [Display(Name ="Preço")]
        [Column(TypeName ="decimal(10,2)")]
        [Range(1,999.99, ErrorMessage ="O preço deve estar entre R$1,00 e R$999,99")]
        public decimal Preco { get; set; }
    //--------------------------------------------------------------------------------------
        [Display(Name = "Caminho da imagem")]
        public string ImagemUrl { get; set; }
   //---------------------------------------------------------------------------------------
        [Display(Name = "Caminho da imagem miniatura")]
        public string ImagemThumbnailUrl { get; set; }

        //---------------------------------------------------------------------------------------
        [Display(Name ="Preferido?")]
        public bool IsLanchePreferido { get; set; }

        //---------------------------------------------------------------------------------------
        [Display(Name ="Estoque")]
        public bool EmEstoque { get; set; }
   //---------------------------------------------------------------------------------------
        public int CategoriaID { get; set; } //Cria a chave estrangeira
        public virtual Categoria Categoria { get; set; } //Define o relacionamento com a tabela de categoria
    }
}
