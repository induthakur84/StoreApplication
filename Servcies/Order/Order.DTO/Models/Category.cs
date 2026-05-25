namespace Order.DTO.Models
{
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }



        //Many-to-Many Relationship:

        //Navigation property to the collection of products in this category
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
