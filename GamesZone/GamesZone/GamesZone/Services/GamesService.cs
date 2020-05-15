namespace GamesZone.Services
{
    using GamesZone.Helpers;
    using GamesZone.Models;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public class GamesService : IGamesService
    {
        public async Task<ObservableCollection<Game>> GetGamesList()
        {
            try
            {
                var client = new RestClient(AppStrings.BaseURL + AppStrings.GamesURL);
                var request = new RestRequest();
                request.AddParameter("sort", "date_start");
                request.AddParameter("page[number]", 1);
                request.AddParameter("page[size]", 20);
                request.AddParameter("filter[season][eq]",DateTime.Today.Year);
                request.AddParameter(AppStrings.Key, AppStrings.KeyValue);
                IRestResponse<List<GamesInformation>> response = await client.ExecuteAsync<List<GamesInformation>>(request);
                var data = response.Data;
                if (data != null)
                {
                    var infoList = response.Data;
                    var allGames = new ObservableCollection<Game>(infoList[0].data);
                    DateTime today = DateTime.Today;
                    ObservableCollection<Game> result = new ObservableCollection<Game>();
                    foreach (Game game in allGames)
                    {
                        if(DateTime.Compare(today,game.date_start) < 0)
                        {
                            result.Add(game);
                        }
                    }

                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
