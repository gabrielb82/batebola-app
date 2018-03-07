using System;
using BateBolaXamarin;
using BateBolaXamarin.Connection;
namespace BateBolaXamarin.Models
{
    public class AuthenticationModel
    {
        public string access_token
        {
            get
            {
                return access_token;
            }

            set
            {
                Settings.Access_Token = value;
            }
        }
    }
}