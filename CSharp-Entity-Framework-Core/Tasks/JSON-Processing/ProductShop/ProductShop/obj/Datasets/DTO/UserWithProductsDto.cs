namespace ProductShop
{
    internal class UserWithProductsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public object SoldProducts { get; set; }
    }
}