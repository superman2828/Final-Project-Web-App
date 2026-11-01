using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Final_Project_Web_App.Models
{
    public class Teams
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a team name.")]
        public string? TeamName { get; set; }

        
        public int? divisionId { get; set; }

        public Division? Division { get; set; }

        public int? conferenceId { get; set; }
        public Conference? Conference { get; set; }
    }
}
