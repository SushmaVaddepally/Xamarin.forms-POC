using FreshMvvm;
using GamesZone.Models;
using GamesZone.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GamesZone.PageModels
{
    public class PlayersCollectionPageModel : FreshBasePageModel
    {
        IPlayersService playersService;

        private string filter;
        public PlayersCollectionPageModel(IPlayersService playersService)
        {
            this.playersService = playersService;
        }

        public ObservableCollection<Player> playersList;
        public ObservableCollection<Player> PlayersList
        {
            get { return playersList; }
            set
            {
                playersList = value;
                RaisePropertyChanged(nameof(PlayersList));
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

        public string Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                Search();
            }
        }

        public ICommand SearchCommand => new Command(Search);
        public async void Search()
        {
            var fullList = await GeneratePlayers();
            if (string.IsNullOrWhiteSpace(filter))
            {
                PlayersList = fullList;
            }
            else
            {
                PlayersList = new ObservableCollection<Player>(fullList.Where(x => x.last_name.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase) ||
                x.first_name.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase) ||
                x.middle_name.StartsWith(filter, StringComparison.InvariantCultureIgnoreCase))
                        .ToList<Player>());
            }
        }

        /// <summary>
        /// Initializes the specified initialize data.
        /// </summary>
        /// <param name="initData">The initialize data.</param>
        public override async void Init(object initData)
        {
            base.Init(initData);
            await GeneratePlayers();
        }

        private async Task<ObservableCollection<Player>> GeneratePlayers()
        {
            IsBusy = true;
            var list = await playersService.GetPlayersList();
            PlayersList = new ObservableCollection<Player>();
            if (list != null)
            {
                PlayersList = list;
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
            await GeneratePlayers();
        }

    }
}
