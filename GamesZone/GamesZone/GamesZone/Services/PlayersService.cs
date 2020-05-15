namespace GamesZone.Services
{
    using GamesZone.Helpers;
    using GamesZone.Models;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    public class PlayersService : IPlayersService
    {
        public async Task<ObservableCollection<Player>> GetPlayersList()
        {
            try
            {
                var client = new RestClient(AppStrings.BaseURL + AppStrings.PlayersURL);
                var request = new RestRequest();
                request.AddParameter(AppStrings.Key, AppStrings.KeyValue);

                IRestResponse<List<Example>> response = await client.ExecuteAsync<List<Example>>(request);
                var data = response.Data;
                if (data != null)
                {
                    var infoList = response.Data;
                    var result = new ObservableCollection<Player>(infoList[0].data);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
