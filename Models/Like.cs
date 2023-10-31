using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenORM.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Habit")]
        public int HabitId { get; set; }
        public Habit? Habit { get; set; }

        [ForeignKey("Creator")]
        public int CreatorId { get; set; }
        public User? Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
