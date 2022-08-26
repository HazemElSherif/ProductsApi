using System.Collections.Generic;

namespace ProductsApi.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public IEnumerable<object> Results { get; set; }

        public object Result { get; set; }

        public List<string> Messages { get; set; } = new List<string>();
    }
}
