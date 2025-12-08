namespace randomNameGenerator.Models
{
    public class NameViewDto
    {
        public string Id { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public string Text { get; set; } = string.Empty;

        public int TextLength
        {
            get
            {
                return Text.Length;
            }
        }
    }
}
