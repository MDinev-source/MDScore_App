namespace MDScoreAPI.Helpers.PlayerTournamesDeserialize
{
    using System.Collections.Generic;

    public class PlayerIdsDTO
    {
        public ICollection<ListIdsDTO> players { get; set; }
    }

    public class ListIdsDTO
    {
        public string id { get; set; }
    }
}
