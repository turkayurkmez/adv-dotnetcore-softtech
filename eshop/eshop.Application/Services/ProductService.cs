using AutoMapper;
using eshop.Data.Repositories;
using eshop.DataTransferObjects.Response;

namespace eshop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepositoryGeneral _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepositoryGeneral productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
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
    }
}
