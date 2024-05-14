namespace RedisExampleApp.API.Repositories
{
    public class ProductRepositoryWithLogDecorator : IProductRepository
    {
        private readonly ILogger<ProductRepositoryWithLogDecorator> _logger;
        private readonly IProductRepository _productRepository;

        public ProductRepositoryWithLogDecorator(
            ILogger<ProductRepositoryWithLogDecorator> logger,
            IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task CreateAsync(Product product)
        {
            await _productRepository.CreateAsync(product);
            _logger.LogInformation("{id} Se ha añadido un nuevo producto.", product.Id);
        }

        public async Task<List<Product>> GetAsync()
        {
            _logger.LogInformation("El producto está listado..");

            var products = await _productRepository.GetAsync();

            _logger.LogInformation("Producto listado..");

            return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            _logger.LogInformation("{id} El producto ID aparecerá en la lista...", id);

            var product = await _productRepository.GetByIdAsync(id);

            _logger.LogInformation("{id} Id del producto listado..", id);

            return product;
        }
    }
}
