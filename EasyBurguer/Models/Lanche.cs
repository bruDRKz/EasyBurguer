using System.ComponentModel.DataAnnotations.Schema;

namespace EasyBurguer.Models
{
    
    public class Lanche
    {
        
        public int LancheID { get; set; }
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool EmEstoque { get; set; }

        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
