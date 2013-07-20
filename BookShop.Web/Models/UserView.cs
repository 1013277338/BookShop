using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Web.Models
{
    public class UserView
    {
        public string id { get; set; }
        public string loginId { get; set; }
        public string loginPwd { get; set; }
        public bool rememberMe { get; set; }
    }
    public class RegisterUser
    {
        [Display(Name="账号")]
        public string loginId { get; set; }
        [Display(Name="密码")]
        public string loginPwd { get; set; }
        [Display(Name="姓名")]
        public string name { get; set; }
        [Display(Name="地址")]
        public string address { get; set; }
        [Display(Name="电话号码")]
        public string phone { get; set; }
        [Display(Name="邮箱")]
        public string mail { get; set; }
        [Display(Name="余额")]
        public decimal money { get; set; }

        public string userStatename { get; set; }
        public string userRolename { get; set; }
    }

    public class UserState
    {
        public int id{get;set;}
        public string userState{get;set;}
    }
    public class UserRole
    {
        public int id { get; set; }
        public string roleName { get; set; }
    }
}