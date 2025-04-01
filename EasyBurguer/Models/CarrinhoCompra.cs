using EasyBurguer.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyBurguer.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //Defino uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;  //Uso um operador de navegação segura (?.) para verificar se é null e evitar erros de null exception, caso ele não seja nulo, ele retorna o HttpContext.Session

            //Obtem um serviço do tipo do contexto de banco
            var context = services.GetService<AppDbContext>(); 


            //Obtem ou gera o ID do carrinho de compras
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //Atribui o id do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            //Retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId  
            };
        }

        public void AdicionarAoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(
                s => s.Lanche.LancheID == lanche.LancheID &&
                s.CarrinhoCompraID == CarrinhoCompraId); //Verifico nessa consulta LINQ se o carrinho ja possui o item que eu quero incluir, ao inves de uma query SQL eu procuro os itens com LINQ

            if (carrinhoCompraItem == null) //Se ele não existir na minha tabela de Carrinho de compras eu incluo um objeto e gravo o registro dos campos em uma linha na tabela
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraID = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };

                _context.CarrinhoCompraItems.Add(carrinhoCompraItem); //Adiciona no banco o registro
            }
            else
            { 
                carrinhoCompraItem.Quantidade ++; //Incrementa a quantidade caso ja exista
            }

            _context.SaveChanges(); //Commita as alteração do banco de dados
        }

        public int RemoverDoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItems.SingleOrDefault(
                s => s.Lanche.LancheID == lanche.LancheID && 
                s.CarrinhoCompraID == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _context.CarrinhoCompraItems.Remove(carrinhoCompraItem);
                }
            }
            _context.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
        {
            return CarrinhoCompraItems ??
                (CarrinhoCompraItems =
                    _context.CarrinhoCompraItems
                    .Where(c => c.CarrinhoCompraID == CarrinhoCompraId)
                    .Include(s => s.Lanche)
                    .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompraItems
                                    .Where(carrinho =>
                                    carrinho.CarrinhoCompraID == CarrinhoCompraId);

            _context.CarrinhoCompraItems.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompraItems
                        .Where(c => c.CarrinhoCompraID == CarrinhoCompraId)
                        .Select(c => c.Lanche.Preco * c.Quantidade).Sum();

            return total;   
        }
    }
}
