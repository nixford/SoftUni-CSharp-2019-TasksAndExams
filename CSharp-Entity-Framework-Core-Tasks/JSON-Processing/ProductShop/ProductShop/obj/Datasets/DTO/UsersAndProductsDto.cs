using System.Collections.Generic;

namespace ProductShop
{
    internal class UsersAndProductsDto
    {
        public int UsersCount { get; set; }
        public List<UserWithProductsDto> Users { get; set; }
    }
}