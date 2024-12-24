using BP215API.Entities;

namespace BP215API.DTOs.Games
{
    public class GameStatusDto
    {
        public byte Succes { get; set; }
        public byte Fail { get; set; }
        public byte Skip   { get; set; }
        public Stack<Word> Words { get; set; }
        public int[] UsedWordIds { get; set; }
    }
}
