namespace Lesson24.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public List<Token> Tokens { get; set; }
    }
}
