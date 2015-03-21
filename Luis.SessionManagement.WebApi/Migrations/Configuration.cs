using Luis.SessionManagement.WebApi.Models;
using System;
using System.Data.Entity.Migrations;

namespace Luis.SessionManagement.WebApi.Migrations
{
    

    internal sealed class Configuration : DbMigrationsConfiguration<SessionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SessionContext context)
        {
            //  This method will be called after migrating to the latest version.

            context
               .SessionLevels
               .AddOrUpdate(x => x.Id,
                   new SessionLevel
                   {
                       Id = 1,
                       Name = "Beginner"
                   },
                   new SessionLevel
                   {
                       Id = 2,
                       Name = "Intermediate"
                   },
                   new SessionLevel
                   {
                       Id = 3,
                       Name = "Advanced"
                   }
               );

            context
                .Presenters
                .AddOrUpdate(x => x.Id,
                    new Presenter
                    {
                        Id = 1,
                        LastName = "Simpson",
                        FirstName = "Homer",
                        CreateDate = DateTime.UtcNow,
                        UpdateDate = DateTime.UtcNow,
                        IsProctor = false
                    },
                    new Presenter
                    {
                        Id = 2,
                        LastName = "Nahasapeemapetilon",
                        FirstName = "Apu",
                        CreateDate = DateTime.UtcNow,
                        UpdateDate = DateTime.UtcNow,
                        IsProctor = false
                    },
                    new Presenter
                    {
                        Id = 3,
                        LastName = "Gumble",
                        FirstName = "Barney",
                        CreateDate = DateTime.UtcNow,
                        UpdateDate = DateTime.UtcNow,
                        IsProctor = false
                    });

            context
                .SessionCategories
                .AddOrUpdate(x => x.Id,
                    new SessionCategory
                    {
                        Id = 1,
                        Name = "CategoryOne",
                        Description = "Category One"
                    },
                    new SessionCategory
                    {
                        Id = 2,
                        Name = "CategoryTwo",
                        Description = "Category Two"
                    },
                    new SessionCategory
                    {
                        Id = 3,
                        Name = "CategoryThree",
                        Description = "Category Three"
                    });

            //3, N'C++', 0, 1, N'C++ for nerds', NULL
            context
                .Sessions
                .AddOrUpdate(x => x.Id,
                    new Session
                    {
                        Approved = true,
                        SessionLevelId = 1,
                        SessionCategoryId = 1,
                        Title = "C++ for nerds",
                        CreateDate = DateTime.UtcNow,
                        UpdateDate = DateTime.UtcNow,
                        SessionDateTime = new DateTime(2015, 3, 24, 10, 00, 00),
                        HasProctors = false,
                        Description = "C++ for nerds"
                    }, new Session
                    {
                        Approved = true,
                        SessionLevelId = 3,
                        SessionCategoryId = 2,
                        Title = "C# for all",
                        CreateDate = DateTime.UtcNow,
                        UpdateDate = DateTime.UtcNow,
                        SessionDateTime = new DateTime(2015, 3, 24, 10, 00, 00),
                        HasProctors = false,
                        Description = "C# for all"
                    }
                    , new Session
                    {
                        Approved = true,
                        SessionLevelId = 2,
                        SessionCategoryId = 3,
                        Title = "Java for C# haters",
                        CreateDate = DateTime.UtcNow,
                        UpdateDate = DateTime.UtcNow,
                        SessionDateTime = new DateTime(2015, 3, 24, 10, 00, 00),
                        HasProctors = false,
                        Description = "C++ for nerds"
                    });

            context
                .SessionPresenters
                .AddOrUpdate(x => x.Id,
                new SessionPresenter
                {
                    Id = 1,
                    PresenterId = 1,
                    SessionId = 2,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                },
                 new SessionPresenter
                 {
                     Id = 2,
                     PresenterId = 3,
                     SessionId = 1,
                     CreateDate = DateTime.UtcNow,
                     UpdateDate = DateTime.UtcNow
                 });


            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
