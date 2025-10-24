
/*

Developed by: 

    Ken Aliling
    Carl Norbi Felonia
    Cedrick Miguel Kaneko
    Amar Jacob Pajarito
    Dino Alfred Timbol


*/

//Item Model entity (has a table in the database for items)

namespace ItemDataLibrary.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public String Name { get; set; } = null!;

        public int Code { get; set; }

        public String Brand { get; set; } = null!;

        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

    }
}
