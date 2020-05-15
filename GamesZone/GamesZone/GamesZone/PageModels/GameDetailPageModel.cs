namespace GamesZone.PageModels
{
    using FreshMvvm;
    using GamesZone.Models;
    using GamesZone.Services;
    using System;
    using Xamarin.Forms;

    public class GameDetailPageModel : FreshBasePageModel
    {
        IGamesService gamesService;

        public Game Game { get; set; }

        public GameDetailPageModel(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }
        public Command BuyTicketsCommand
        {
            get
            {
                return new Command(() =>
                {
                    GoToBrowser();

                });
            }
        }

        private void GoToBrowser()
        {
            Device.OpenUri(new Uri(this.Game.tickets_url));
        }
        public override void Init(object initData)
        {
            base.Init(initData);
            this.Game = initData as Game;
        }
    }
}
