using System;

namespace server.Dtos.Language
{
    public class LanguageDto
    {
        public int Id { get; set; }
        public string LanguageName { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
    }
}
