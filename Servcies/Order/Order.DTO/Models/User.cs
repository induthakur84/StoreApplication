namespace Order.DTO.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }


        //Navigation property to the UserProfile entity
        public UserProfile UserProfile { get; set; }
    }
}


///one to one relationship between User and UserProfile,
///where each User has one UserProfile and each UserProfile is associated with one User. 
///The User entity contains basic information about the user,
///while the UserProfile entity can contain additional details such as address, phone number, etc.
////1:1: