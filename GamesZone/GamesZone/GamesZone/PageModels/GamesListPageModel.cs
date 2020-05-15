namespace GamesZone.PageModels
{
    using FreshMvvm;
    using GamesZone.Models;
    using GamesZone.Services;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class GamesListPageModel : FreshBasePageModel
    {
        IGamesService gamesService;

        private string filter;
        public GamesListPageModel(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public ObservableCollection<Game> gamesList;
        public ObservableCollection<Game> GamesList
        {
            get { return gamesList; }
            set
            {
                gamesList = value;
                RaisePropertyChanged(nameof(GamesList));
            }
        }

        /// <summary>
        /// The is busy
        /// </summary>
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
            }
        }

        private Game selectedGame;
        public Game SelectedGame
        {
            get
            {
                return selectedGame;
            }
            set
            {
                selectedGame = value;
                RaisePropertyChanged(nameof(this.SelectedGame));
                
                    this.SelectedGameCommand.Execute(value);
            }
        }

        public Command SelectedGameCommand
        {
            get
            {
                return new Command((game) =>
                {
                    NavigateToGameDetails(game);

                });
            }
        }

        public string Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                //SetProperty(ref filter, value);
                Search();
            }
        }

        public ICommand SearchCommand => new Command(Search);
        public async void Search()
        {
            var fullList = await GenerateGames();
            if (string.IsNullOrWhiteSpace(filter))
            {
                GamesList = fullList;
            }
            else
            {
                GamesList = new ObservableCollection<Game>( fullList.Where(x => x.event_type.name.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase))
                        .ToList<Game>());
            }
        }

        private void NavigateToGameDetails(object game)
        {
            if (game != null)
            {
                CoreMethods.PushPageModelWithNewNavigation<GameDetailPageModel>(game);
            }
        }

        /// <summary>
        /// Initializes the specified initialize data.
        /// </summary>
        /// <param name="initData">The initialize data.</param>
        public override async void Init(object initData)
        {
            base.Init(initData);
            await GenerateGames();
        }

        private async Task<ObservableCollection<Game>> GenerateGames()
        {
            IsBusy = true;
            var list = await gamesService.GetGamesList();
            GamesList = new ObservableCollection<Game>();
            if (list != null)
            {
                GamesList = list;
            }

            IsBusy = false;
            return list;
        }

        /// <summary>
        /// Reverses the initialize.
        /// </summary>
        /// <param name="returnedData">The returned data.</param>
        public override async void ReverseInit(object returnedData)
        {
            base.ReverseInit(returnedData);
            await GenerateGames();
        }

    }
}
