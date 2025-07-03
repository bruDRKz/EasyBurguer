using EasyBurguer.Models;

namespace EasyBurguer.Repositories.Interfaces
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos { get; }
        Lanche GetLancheByID (int lancheId);
    }
}
