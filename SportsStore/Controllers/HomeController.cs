using Microsoft.AspNetCore.Mvc;
using SportsStore.Models.Repository;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreRepository repository;
        private readonly int pageSize = 4;

        public HomeController(IStoreRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index(int productPage = 1)
        {
            return this.View(new ProductsListViewModel
            {
                Products = this.repository.Products
                               .OrderBy(p => p.ProductId)
                               .Skip((productPage - 1) * this.pageSize)
                               .Take(this.pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = this.pageSize,
                    TotalItems = this.repository.Products.Count(),
                },
            });
        }
    }
}
