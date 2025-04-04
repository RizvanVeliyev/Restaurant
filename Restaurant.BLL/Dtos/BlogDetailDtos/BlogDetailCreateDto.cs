﻿using Restaurant.BLL.Abstractions.Dtos;

namespace Restaurant.BLL.Dtos.BlogDetailDtos
{
    public class BlogDetailCreateDto:IDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int LanguageId { get; set; }
    }
}
