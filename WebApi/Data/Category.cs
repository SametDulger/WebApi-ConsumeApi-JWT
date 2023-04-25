using System.Collections.Generic;

namespace WebApi.Data
{
    public class Category
    {

        public int Id { get; set; }

        public string Name { get; set; }


        public List<Product> Products { get; set; }

    }

}
