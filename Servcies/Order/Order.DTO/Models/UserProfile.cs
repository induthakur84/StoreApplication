namespace Order.DTO.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int UserId { get; set; }

        //Navigation property to the User entity
        public User User { get; set; }
    }
}
