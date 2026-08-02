using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Models;
using Task=TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private IdentityUser TestUser { get; set; }
        private Board OpenBoard { get; set; }
        private Board InProgressBoard { get; set; }
        private Board DoneBoard { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Board> Boards { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Task>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);

            SeedUsers();
            builder.Entity<IdentityUser>()
                .HasData(TestUser);

            SeedBoards();
            builder
                .Entity<Board>()
                .HasData(OpenBoard, InProgressBoard, DoneBoard);

            builder
               .Entity<Task>()
               .HasData(new Task
               {
                   Id = 1,
                   Title = "Improve CSS styles",
                   Description = "Implement better styling for all public pages",
                   CreatedOn = DateTime.Now.AddDays(-200),
                   OwnerId = TestUser.Id,
                   BoardId = OpenBoard.Id
               },
               new Task
               {
                   Id = 2,
                   Title = "Add user authentication",
                   Description = "Implement user registration and login",
                   CreatedOn = DateTime.Now.AddDays(-5),
                   OwnerId = TestUser.Id,
                   BoardId = InProgressBoard.Id
               },
               new Task
               {
                   Id = 3,
                   Title = "Implement task management",
                   Description = "Add functionality to create, edit and delete tasks",
                   CreatedOn = DateTime.Now.AddDays(-1),
                   OwnerId = TestUser.Id,
                   BoardId = DoneBoard.Id
               },
               new Task
               {
                   Id = 4,
                   Title = "Add user roles",
                   Description = "Implement user roles and permissions",
                   CreatedOn = DateTime.Now.AddDays(-1),
                   OwnerId = TestUser.Id,
                   BoardId = DoneBoard.Id
               });
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            TestUser = new IdentityUser
            {
                UserName = "test@softuni.bg",
                NormalizedUserName = "TEST@SOFTUNI.BG"
            };

            TestUser.PasswordHash = hasher.HashPassword(TestUser, "softuni");
        }

        private void SeedBoards()
        {
            OpenBoard = new Board
            {
                Id = 1,
                Name = "Open"
            };

            InProgressBoard = new Board
            {
                Id = 2,
                Name = "In Progress"
            };

            DoneBoard = new Board
            {
                Id = 3,
                Name = "Done"
            };
        }

    }
}
