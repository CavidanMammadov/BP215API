﻿namespace BP215API.Entities
{
    public class BannedWord
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int  WordId { get; set; }
        public WordForGame Word { get; set; }
    }
}
