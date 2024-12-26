using BP215API.DTOs.Words;
using BP215API.Entities;

namespace BP215API.DTOs.Games
{
    public class GameStatusDto
    {
        public byte Succes { get; set; }
        public byte Fail { get; set; }
        public byte Skip   { get; set; }
        public Stack<WordForGameDto> Words { get; set; }
        public IEnumerable<int> UsedWordIds { get; set; }
        public int MaxSkipCount { get; set; }
    }
}
