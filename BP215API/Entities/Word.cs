﻿namespace BP215API.Entities
{
    public class WordForGame
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string LanguageCode { get; set; }
        public Language Language { get; set; }
        public ICollection<BannedWord> BannedWords { get; set; }
    }
}
