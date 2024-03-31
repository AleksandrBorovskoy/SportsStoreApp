namespace SportsStore.Models.ViewModels
{
    public class CartViewModel
    {
        public Cart? Cart { get; set; } = new();

#pragma warning disable CA1056 // URI-like properties should not be strings
        public string ReturnUrl { get; set; } = "/";
#pragma warning restore CA1056 // URI-like properties should not be strings
    }
}
