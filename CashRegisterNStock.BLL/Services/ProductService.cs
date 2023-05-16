using AutoMapper;
using CashRegisterNStock.BLL.Models;
using CashRegisterNStock.DAL.Entities;
using CashRegisterNStock.DAL.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace CashRegisterNStock.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly ProductRepository _productRepository;

        public ProductService(IMapper mapper, ProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public void CheckIfProductExists(ProductModel model)
        {
            List<ProductModel> products = _productRepository.GetAllProducts().Select(_mapper.Map<ProductModel>).ToList();
            if (products.Any(p => p.Name == model.Name && p.Description == model.Description))
            {
                throw new ArgumentException("A Product with the same name and description already exists.");
            }
        }

        public string ConvertAndStoreImage(ProductModel model)
        {
            string base64String = model.ImageUrl.Split(",")[1];
            byte[] ImageBytes = Convert.FromBase64String(base64String);
            string name = model.Name.Replace(" ", "-");
            string desc = model.Description.Replace(" ", "-");
            string fileName = $"{name}-{desc}-{Guid.NewGuid()}.jpg";
            string filePath = $"assets/products/{fileName}";
            File.WriteAllBytes("wwwroot/" + filePath, ImageBytes);
            return filePath;
        }

        public ProductModel CreateProduct(ProductModel model)
        {
            CheckIfProductExists(model);
            if (!model.ImageUrl.IsNullOrEmpty())
            {
                model.ImageUrl = ConvertAndStoreImage(model);
            }
            Product product = _productRepository.CreateProduct(_mapper.Map<Product>(model));
            return _mapper.Map<ProductModel>(product);
        }

        public ProductModel DeleteProduct(int id)
        {
            Product product = _productRepository.GetProductById(id);
            product.ImageUrl = "wwwroot/" + product.ImageUrl;
            File.Delete(product?.ImageUrl);
            _productRepository.DeleteProduct(id);
            return _mapper.Map<ProductModel>(product);
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            return _productRepository.GetAllProducts().Select(_mapper.Map<ProductModel>);
        }

        public ProductModel GetProductById(int id)
        {
            Product product = _productRepository.GetProductById(id);
            return _mapper.Map<ProductModel>(product);
        }

        public ProductModel UpdateProduct(int id, ProductModel model)
        {
            ProductModel productModel = GetProductById(id);
            if (model.ImageUrl.Length > 300)
            {
                File.Delete("wwwroot/" + productModel.ImageUrl);
                model.ImageUrl = ConvertAndStoreImage(model);
            }
            Product product = _productRepository.UpdateProduct(id, _mapper.Map<Product>(model));
            return _mapper.Map<ProductModel>(product);
        }
    }
}
