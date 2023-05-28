using Microsoft.AspNetCore.Mvc;
using Webapp.Helpers.Repositories;
using WebApp.Helpers.Repositories;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace Webapp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly TagRepository _tagRepository;
        private readonly ProductRepository _productRepository;

        public ProductsController(TagRepository tagRepository, ProductRepository productRepository)
        {
            _tagRepository = tagRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index(string tag)
        {
            var tags = await _tagRepository.GetAsync();
            var products = await _productRepository.GetAsync(tag);
            
            if (string.IsNullOrEmpty(tag))
            {
                tag = tags.FirstOrDefault()?.TagName;
            }

            var viewModel = new ProductsViewModel
            {
                Products = new GridCollectionViewModel
                {
                    Title = "Products",
                    Categories = tags.Select(tagEntity => GetTagName(tagEntity.TagName)),
                    GridItems = products.Select(CreateProductGridItem)
                }
            };

            return View(viewModel);
        }

        public IActionResult Details(int id) 
        {
            return View(id);
        }

        private string GetTagName(string id)
        {
            if (string.Equals(id, "new", StringComparison.OrdinalIgnoreCase))
            {
                return "New";
            }

            if (string.Equals(id, "featured", StringComparison.OrdinalIgnoreCase))
            {
                return "Featured";
            }

            if (string.Equals(id, "popular", StringComparison.OrdinalIgnoreCase))
            {
                return "Popular";
            }

            return id;
        }

        private GridCollectionItemViewModel CreateProductGridItem(ProductEntity productEntity)
        {
            return new GridCollectionItemViewModel
            {
                Id = productEntity.Id.ToString(),
                Title = productEntity.Title,
                Price = productEntity.Price,
                ImageUrl = productEntity.ImageUrl
            };
        }
    }
}