namespace WebApplication1.Models
{
    public class Team
    {
        public int Id { get; set; }

        public DateTime CreatDate { get; set; }
        public string FullName { get; set; }

        public string Description { get; set; }

        public string ImgPath { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }


    }
}
