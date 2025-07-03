using System.Runtime.CompilerServices;
using Microsoft.Extensions.WebEncoders.Testing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EasyBurguer.Models
{
    public class CarrinhoCompraItem
    {
        public int CarrinhoCompraItemID { get; set; }
        public Lanche Lanche { get; set; }  
        public int Quantidade { get; set; }
        [StringLength(200)]
        public string CarrinhoCompraID { get; set; }
        
    }
}
