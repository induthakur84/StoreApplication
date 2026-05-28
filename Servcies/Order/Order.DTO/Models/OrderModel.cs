namespace Order.DTO.Models
{
    public class OrderModel
    {
        public int Id { get; set; } 
        public int Name  { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }

        //Navigation property to the User entity
        public User User { get; set; }
    }

}
