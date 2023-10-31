using System.ComponentModel.DataAnnotations;

namespace ExamenORM.Models
{
    public class Category{
        [Key]
        public int Id{get;set;}

        public string Name{get;set;}

        public List<Habit> Habits{get;set;}
    }
}