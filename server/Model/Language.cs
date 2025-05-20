using System;

namespace server.Model
{
    public class Language
    {
        public int Id { get; set; }
        public string LanguageName { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public int CvId { get; set; }
        public CV? Cv {get; set;}

    }
}
