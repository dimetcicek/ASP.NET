namespace WebApp.ViewModels
{
    public class ProductsViewModel
    {
        public string Title { get; set; } = "Products";

        public GridCollectionViewModel Products { get; set; } = null!;
    }
}
