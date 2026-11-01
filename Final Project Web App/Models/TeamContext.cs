using Microsoft.EntityFrameworkCore;
namespace Final_Project_Web_App.Models
{
    public class TeamContext : DbContext
    {

        public TeamContext(DbContextOptions<TeamContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Division> Divisions { get; set; }

        public DbSet<Conference> Conferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>().HasData(
                new Division { divisionId = 1, divisionName = "North" },
                new Division { divisionId = 2, divisionName = "East" },
                new Division { divisionId = 3, divisionName = "South" },
                new Division { divisionId = 4, divisionName = "West" }
            );
            modelBuilder.Entity<Conference>().HasData(
                new Conference { conferenceId = 1, ConferenceName = "AFC" },
                new Conference { conferenceId = 2, ConferenceName = "NFC" }
            );

            modelBuilder.Entity<Teams>().HasData(
                new Teams { Id = 1, TeamName = "Baltimore Ravens", divisionId = 1, conferenceId = 1 },
                new Teams { Id = 2, TeamName = "Cincinnati Bengals", divisionId = 1, conferenceId = 1 },
                new Teams { Id = 3, TeamName = "Cleveland Browns", divisionId = 1, conferenceId = 1 },
                new Teams { Id = 4, TeamName = "Pittsburgh Steelers", divisionId = 1, conferenceId = 1 },

                new Teams { Id = 5, TeamName = "Buffalo Bills", divisionId = 2, conferenceId = 1 },
                new Teams { Id = 6, TeamName = "New England Patriots", divisionId = 2, conferenceId = 1 },
                new Teams { Id = 7, TeamName = "New York Jets", divisionId = 2, conferenceId = 1 },
                new Teams { Id = 8, TeamName = "Miami Dolphins", divisionId = 2, conferenceId = 1 },

                new Teams { Id = 9, TeamName = "Houston Texans", divisionId = 3, conferenceId = 1 },
                new Teams { Id = 10, TeamName = "Jacksonville Jaguars", divisionId = 3, conferenceId = 1 },
                new Teams { Id = 11, TeamName = "Tennessee Titans", divisionId = 3, conferenceId = 1 },
                new Teams { Id = 12, TeamName = "Indianapolis Colts", divisionId = 3, conferenceId = 1 },

                new Teams { Id = 13, TeamName = "Denver Broncos", divisionId = 4, conferenceId = 1 },
                new Teams { Id = 14, TeamName = "Kansas City Chiefs", divisionId = 4, conferenceId = 1 },
                new Teams { Id = 15, TeamName = "LA Chargers", divisionId = 4, conferenceId = 1 },
                new Teams { Id = 16, TeamName = "Las Vegas Raiders", divisionId = 4, conferenceId = 1 },

                new Teams { Id = 17, TeamName = "Chicago Bears", divisionId = 1, conferenceId = 2 },
                new Teams { Id = 18, TeamName = "Detroit Lions", divisionId = 1, conferenceId = 2 },
                new Teams { Id = 19, TeamName = "Green Bay Packers", divisionId = 1, conferenceId = 2 },
                new Teams { Id = 20, TeamName = "Minnesota Vikings", divisionId = 1, conferenceId = 2 },

                new Teams { Id = 21, TeamName = "New York Giants", divisionId = 2, conferenceId = 2 },
                new Teams { Id = 22, TeamName = "Philadelphia Eagles", divisionId = 2, conferenceId = 2 },
                new Teams { Id = 23, TeamName = "Washington Commanders", divisionId = 2, conferenceId = 2 },
                new Teams { Id = 24, TeamName = "Dallas Cowboys", divisionId = 2, conferenceId = 2 },

                new Teams { Id = 25, TeamName = "Atlanta Falcons", divisionId = 3, conferenceId = 2 },
                new Teams { Id = 26, TeamName = "Carolina Panthers", divisionId = 3, conferenceId = 2 },
                new Teams { Id = 27, TeamName = "New Orleans Saints", divisionId = 3, conferenceId = 2 },
                new Teams { Id = 28, TeamName = "Tampa Bay Buccaneers", divisionId = 3, conferenceId = 2 },

                new Teams { Id = 29, TeamName = "Arizona Cardinals", divisionId = 4, conferenceId = 2 },
                new Teams { Id = 30, TeamName = "Los Angeles Rams", divisionId = 4, conferenceId = 2 },
                new Teams { Id = 31, TeamName = "San Francisco 49ers", divisionId = 4, conferenceId = 2 },
                new Teams { Id = 32, TeamName = "Seattle Seahawks", divisionId = 4, conferenceId = 2 }
                
            );
        }
    }
}
