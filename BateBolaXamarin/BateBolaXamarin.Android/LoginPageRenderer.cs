﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.App;
using Xamarin.Auth;
using Newtonsoft.Json.Linq;
using BateBolaXamarin;
using BateBolaXamarin.Droid;
using BateBolaXamarin.Connection;

[assembly: ExportRenderer(typeof(Login), typeof(LoginPageRenderer))]
namespace BateBolaXamarin.Droid
{
    public class LoginPageRenderer : PageRenderer
    {
        bool done = false;
        public LoginPageRenderer()
        {
            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: Settings.FacebookID, // your OAuth2 client id
                scope: "public_profile+email", // the scopes for the particular API you're accessing, delimited by "+" symbols
                authorizeUrl: new Uri(Settings.FacebookAuthorizeUrl),
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));

            auth.Completed += async (sender, eventArgs) => {

                //App.HideLoginView();

                if (eventArgs.IsAuthenticated)
                {
                    var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                    Settings.Facebook_Token = accessToken;
                    var expiresIn = Convert.ToDouble(eventArgs.Account.Properties["expires_in"]);
                    var expiryDate = DateTime.Now + TimeSpan.FromSeconds(expiresIn);

                    var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, eventArgs.Account);
                    var response = await request.GetResponseAsync();
                    var obj = JObject.Parse(response.GetResponseText());

                    var id = obj["id"].ToString().Replace("\"", "");
                    var name = obj["name"].ToString().Replace("\"", "");

                    if (CappriolaConnect.RetrieveAccessTokenFromFacebookLogin())
                    {
                        await App.NavigateToProfile(string.Format("Olá {0}", name));
                    }
                    else
                    {
                        App.HideLoginView();
                    }

                }
                else
                {
                    await App.NavigateToProfile("Usuário Cancelou o login");
                }
            };

            activity.StartActivity(auth.GetUI(activity));
        }
    }
}