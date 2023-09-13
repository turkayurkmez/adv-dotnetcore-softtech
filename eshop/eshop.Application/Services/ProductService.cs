using AutoMapper;
using eshop.Data.Repositories;
using eshop.DataTransferObjects.Request;
using eshop.DataTransferObjects.Response;
using eshop.Entities;

namespace eshop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task CreateNewProductAsync(CreateNewProductRequest createNewProductRequest)
        {
            var product = _mapper.Map<Product>(createNewProductRequest);
            await _productRepository.CreateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public ProductCardResponse GetProduct(int id)
        {
            var product = _productRepository.GetById(id);
            return _mapper.Map<ProductCardResponse>(product);
        }

        public async Task<ProductCardResponse> GetProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductCardResponse>(product);
        }

        public IEnumerable<ProductCardResponse> GetProducts()
        {
            //var response = _productRepository.GetAll().Select(p => new ProductCardResponse
            //{
            //    Description = p.Description,
            //    Id = p.Id,
            //    ImageUrl = p.ImageUrl,
            //    Name = p.Name,
            //    Price = p.Price
            //});

            var products = _productRepository.GetAll();
            var response = _mapper.Map<IEnumerable<ProductCardResponse>>(products);

            return response;
        }

        public async Task<IEnumerable<ProductCardResponse>> GetProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            var response = _mapper.Map<IEnumerable<ProductCardResponse>>(products);

            return response;
        }

        public async Task<IEnumerable<ProductCardResponse>> SearchProductsByNameAsync(string name)
        {
            var products = await _productRepository.SearchProductsByNameAsync(name);
            return _mapper.Map<IEnumerable<ProductCardResponse>>(products);
        }

        public async Task UpdateAsync(UpdateExistingProductRequest updateExistingProductRequest)
        {
            var product = _mapper.Map<Product>(updateExistingProductRequest);
            await _productRepository.UpdateAsync(product);
        }
    }
}
