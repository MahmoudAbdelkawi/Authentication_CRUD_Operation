﻿using Authentication_CRUD_Operation.enums;

namespace Authentication_CRUD_Operation.Dtos
{
    public class UserDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
