namespace Store2.Domain
{
    public class Slides
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int PageNumber { get; set; } // Добавлено свойство для номера страницы
    }
}
