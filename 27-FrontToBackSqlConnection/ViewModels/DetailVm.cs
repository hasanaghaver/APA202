using _27_FrontToBackSqlConnection.Models;

namespace _27_FrontToBackSqlConnection.ViewModels
{
    public class DetailVm
    {
        public Product Product { get; set; }
        public List<Product> ReleatedProducts { get; set; }
    }
}
