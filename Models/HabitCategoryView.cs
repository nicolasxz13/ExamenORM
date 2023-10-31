namespace ExamenORM.Models
{
    public class HabitCategoryView
    {
        public Habit Habit { get; set; } = new Habit();
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
