using System.Collections.Generic;

namespace ProductsApi.Models
{
    public class RepositoryResult <T>
    {
        public bool Success { get; set; }
        public T Results { get; set; }

        public T Result { get; set; }

        public List<string> Messages { get; set; } = new List<string>();
    }
}
