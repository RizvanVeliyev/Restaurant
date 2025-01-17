﻿using Restaurant.BLL.Abstractions.Dtos;
using Restaurant.BLL.Dtos.BlogCategoryDtos;
using Restaurant.BLL.Dtos.CategoryDtos;

namespace Restaurant.BLL.Dtos.BlogDtos
{
    public class BlogGetDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string Description { get; set; } = null!;
        public string Author { get; set; } = null!;
        public List<BlogCategoryGetDto> BlogCategories { get; set; } = null!;
        public int BlogCategoryId { get; set; } 

        public string ImagePath { get; set; } = null!;
        public List<string> ImagePaths { get; set; } = [];

        //comment niye saxlamirig?


    }
}
