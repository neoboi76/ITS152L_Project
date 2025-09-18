namespace ITS152L_Project.Models
{
    public class Item
    {
        public int Id { get; set; }
        public String Name { get; set; } = null!;

        public int Code { get; set; }

        public String Brand { get; set; } = null!;

        public double UnitPrice { get; set; }

    }
}
