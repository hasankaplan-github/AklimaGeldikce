﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            this.Posts = new List<Post>();
            this.AppLevelLogs = new List<AppLevelLog>();
            this.RoleUsers = new List<RoleUser>();
            this.Comments = new List<Comment>();
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IList<Post> Posts { get; set; }
        public IList<Comment> Comments { get; set; }
        public IList<AppLevelLog> AppLevelLogs { get; set; }
        public bool IsLoggedIn { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastLogoutDate { get; set; }
        public IList<RoleUser> RoleUsers { get; set; }
    }
}