using System;
using server.Dtos.Tag;
using server.Model;

namespace server.Mappers
{
    public static class TagMapper
    {
        public static TagDto ToTagDto(this Tag tagModel)
        {
            return new TagDto
            {
                Id = tagModel.Id,
                Name = tagModel.Name
            };
        }
    }
}
