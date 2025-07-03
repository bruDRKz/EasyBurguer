using EasyBurguer.Context;
using EasyBurguer.Models;
using EasyBurguer.Repositories.Interfaces;

namespace EasyBurguer.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context; // Aqui eu tenho uma instancia do contexto de acesso ao baanco de dados, para que meu repository consiga acessar o banco
        public CategoriaRepository(AppDbContext context) //Aqui esta o construtor do contexto, eu injeto uma instancia do contexto no repository
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
