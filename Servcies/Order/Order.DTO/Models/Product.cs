namespace Order.DTO.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        //Many-to-Many Relationship:
  


        public ICollection<Category> Categories { get; set; } = new List<Category>();

    }
    }


//many to many relationships between categories and products,
//where a product can belong to multiple categories
//and a category can have multiple products.