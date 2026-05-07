namespace _27_FrontToBackSqlConnection.Models
{
    public class Catagory : BaseEntity
    {
        public string Name { get; set; }

        public List<Product> Products { get; set; }

    }
}
