namespace GamesZone.Services
{
    using GamesZone.Models;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public interface IGamesService
    {
        Task<ObservableCollection<Game>> GetGamesList();
    }
}
