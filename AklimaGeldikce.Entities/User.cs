using System;
using System.Collections.Generic;
using System.Text;

namespace AklimaGeldikce.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            this.Articles = new List<Article>();
            this.AppLevelLogs = new List<AppLevelLog>();
            this.RoleUsers = new List<RoleUser>();
            this.Comments = new List<Comment>();
            this.ArticleOperations = new List<ArticleOperation>();
            this.Notifications = new List<Notification>();
            this.SentMessages = new List<Message>();
            this.ReceivedMessages = new List<Message>();
            this.ForgotPasswords = new List<ForgotPassword>();
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IList<Article> Articles { get; set; }
        public IList<Comment> Comments { get; set; }
        public IList<AppLevelLog> AppLevelLogs { get; set; }
        public bool IsLoggedIn { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastLogoutDate { get; set; }
        public IList<RoleUser> RoleUsers { get; set; }
        public IList<ArticleOperation> ArticleOperations { get; set; }
        public IList<Notification> Notifications { get; set; }
        public IList<Message> SentMessages { get; set; }
        public IList<Message> ReceivedMessages { get; set; }
        public IList<ForgotPassword> ForgotPasswords { get; set; }
    }
}
