﻿using KnowledgeBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.ViewModels
{
    public class KbUserViewModel
    {
        public KbUserViewModel()
        {
        }

        public KbUserViewModel(AppUser usr)
        {
            this.Id = usr.Id;
            this.UserName = usr.UserName;
            //this.Name = usr.Name;
            //this.LastName = usr.LastName;
            this.Email = usr.Email;
            //this.Role = usr.Role;
        }

        public string UserName { get; set; }
        public string Id { get; set; }
        //public string Name { get; set; }
        //public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        //2707
        //[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "EmailIsRequired")]
        public string Email { get; set; }
        //[Required(ErrorMessageResourceType = typeof(UIResources), ErrorMessageResourceName = "UserListUserOldPasswordRequired")]
        public string OldPassword { get; set; }
        //[Compare("NewPasswordAgain", ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "PasswordsDoNotMatch")]
        public string NewPassword { get; set; }
        public string NewPasswordAgain { get; set; }
        //public string Role { get; set; }
    }
}