using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.DataContexts
{
    public static class SeedDataService
    {
        public static void AddSeedData(this ModelBuilder builder)
        {
            builder.AddStatuses();
        }


        private static void AddStatuses(this ModelBuilder builder)
        {

            Status status1 = new() { Id = 1 };
            Status status2 = new() { Id = 2 };
            Status status3 = new() { Id = 3 };
            Status status4 = new() { Id = 4 };

            List<Status> statuses = new List<Status> { status1, status2, status3, status4 };


            List<StatusDetail> statusDetails = new()
        {
            new() { Id = 1, Name = "Sifariş edilib", LanguageId = 1, StatusId = 1 },
            new() { Id = 2, Name = "Ordered", LanguageId = 2, StatusId = 1 },
            new() { Id = 3, Name = "Заказал", LanguageId = 3, StatusId = 1 },

            new() { Id = 4, Name = "Yolda", LanguageId = 1, StatusId = 2 },
            new() { Id = 5, Name = "On the Way", LanguageId = 2, StatusId = 2 },
            new() { Id = 6, Name = "В пути", LanguageId = 3, StatusId = 2 },

            new() { Id = 7, Name = "Sifariş tamamlandı", LanguageId = 1, StatusId = 3 },
            new() { Id = 8, Name = "Order Is Done", LanguageId = 2, StatusId = 3 },
            new() { Id = 9, Name = "Заказ выполнен", LanguageId = 3, StatusId = 3 },

            new() { Id = 10, Name = "Ləğv edildi", LanguageId = 1, StatusId = 4 },
            new() { Id = 11, Name = "Cancelled", LanguageId = 2, StatusId = 4 },
            new() { Id = 12, Name = "Отменено", LanguageId = 3, StatusId = 4 }
        };


            builder.Entity<Status>().HasData(statuses);
            builder.Entity<StatusDetail>().HasData(statusDetails);
        }
    }
}
