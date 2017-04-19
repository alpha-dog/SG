using Microsoft.AspNet.Identity;
using SUKTIE.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUKTIE.Models
{
    public class CreatePostViewModel : BaseViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
        public Post Post { get; set; }
        public string HashtagString { get; set; }
    }

}
