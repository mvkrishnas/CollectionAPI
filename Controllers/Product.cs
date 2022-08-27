using Microsoft.AspNetCore.Mvc;

namespace CollectionAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Product : ControllerBase
    {
        private static readonly List<string> productItems = new();
        private readonly ILogger<Product> logger;
        public Product(ILogger<Product> _logger)
        {
            logger = _logger;
        }
        [HttpGet]
        public IEnumerable<string> GetProdcut()
        {
            return productItems;
        }
        [HttpPost]
        public string AddProdcut(string productName)
        {
            string result = $"{productName} added into prodcut list";
            if (!productItems.Contains(productName))
                productItems.Add(productName);
            else
                result = $"{productName} already in prodcut list";
            return result;
        }
        [HttpDelete]
        public string DeleteProdcut(string productName)
        {
            string result = $"{productName} deleted from prodcut list";
            if (productItems.Contains(productName))
                productItems.Remove(productName);
            else
                result = $"{productName} not avaliable in prodcut list";
            return result;
        }
    }
}
