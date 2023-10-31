namespace ExamenORM.Models
{
    public class UserHabits
    {
        public string creatorName { get; set; }
        public List<Habit> Habits { get; set; }
    }
}
