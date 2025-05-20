using System;
using Microsoft.AspNetCore.WebUtilities;
using server.Dtos.Language;
using server.Model;

namespace server.Mappers
{
    public static class LanguageMapper
    {
        public static LanguageDto ToLanguageDto(this Language language)
        {
            return new LanguageDto
            {
                Id = language.Id,
                LanguageName = language.LanguageName
            };
        }
        public static Language FromRequesteToLangauge(this LanguageDto languageDto,int id)
        {
            return new Language
            {
                LanguageName = languageDto.LanguageName,
                Level = languageDto.Level,
                CvId = id 
            };
        }
    }
}
