namespace GamesZone
{
    using DLToolkit.Forms.Controls;
    using FreshMvvm;
    using GamesZone.PageModels;
    using GamesZone.Services;
    using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            FlowListView.Init();

            FreshIOC.Container.Register<IGamesService, GamesService>();
            FreshIOC.Container.Register<IPlayersService, PlayersService>();

            var tabbedNavigation = new FreshTabbedNavigationContainer(); 
            tabbedNavigation.On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            tabbedNavigation.AddTab<GamesListPageModel>("Upcoming Games", null);
            tabbedNavigation.AddTab<PlayersListPageModel>("Players", null);
            tabbedNavigation.AddTab<PlayersCollectionPageModel>("Players Collection", null);
            tabbedNavigation.HeightRequest = 5;
            MainPage = tabbedNavigation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
