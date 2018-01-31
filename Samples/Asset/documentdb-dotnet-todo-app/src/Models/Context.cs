namespace todo.Models
{
    using System.Data.Entity;

    public class Context : DbContext
    {
        public Context() : base("name=Context")
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}
