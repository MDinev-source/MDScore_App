namespace MDScoreAPI.Helpers.PlayerTournamesDeserialize
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public static class PlayerTournamentsDeserializer
    {
        public static ICollection<int> Desrizalizer(string data)
        {


            var idsImport = JsonConvert.DeserializeObject<PlayerIdsDTO>(data);
            var playersId = idsImport.players;

            var deserializedIds = new HashSet<int>();
            foreach (var el in playersId)
            {
                deserializedIds.Add(int.Parse(el.id));
            }

            return deserializedIds;
        }
    }
}
