using System;

namespace server.Dtos.Language
{
    public class RequestLanguageDto
    {
        public string LanguageName { get; set; } = string.Empty;
        public string Writing { get; set; } = string.Empty;
        public string Speaking { get; set; } = string.Empty;
        public string Reading { get; set; } = string.Empty;
        public string Listening { get; set; } = string.Empty;
    }
}
