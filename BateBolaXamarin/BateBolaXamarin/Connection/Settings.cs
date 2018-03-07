using System;
using Plugin.Settings;

namespace BateBolaXamarin.Connection
{
    public static class Settings
    {
        const string TokenKey = "token";
        const string FacebookTokenKey = "fb_token";

        public static string Access_Token
        {
            get { return CrossSettings.Current.GetValueOrDefault(TokenKey, ""); }
            set { CrossSettings.Current.AddOrUpdateValue(TokenKey, value); }
        }

        public static string URL_API
        {
            get { return "http://localhost:8000/"; }
        }

        public static string GrantType
        {
            get { return "password"; }
        }

        public static string ClientID
        {
            get { return "2"; }
        }

        public static string ClientSecret
        {
            get { return "UqBqxYgCwBtJotEwMyj8zrEOkSvT6tLAFEDvwQuB"; }
        }

        //Facebook Login
        public static string Facebook_Token
        {
            get { return CrossSettings.Current.GetValueOrDefault(FacebookTokenKey, ""); }
            set { CrossSettings.Current.AddOrUpdateValue(FacebookTokenKey, value); }
        }

        public static string FacebookAuthorizeUrl
        {
            get { return "https://m.facebook.com/dialog/oauth/"; }
        }

        public static string FacebookClientID
        {
            get { return "3"; }
        }

        public static string FacebookGrantType
        {
            get { return "facebook_login"; }
        }

        public static string FacebookID
        {
            get { return "1638662706240782"; }
        }

        public static string FacebookClientSecret
        {
            get { return "kqhVfXLHMDyGvwaGma3zjWo2QpZ7pS5rAufDxISH"; }
        }
    }
}
