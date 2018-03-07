using System;
using System.Net;
using RestSharp;
using BateBolaXamarin.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BateBolaXamarin.Connection
{
    public static class CappriolaConnect
    {
        public static RestClient GetRestClient()
        {
            #if __ANDROID__
                RestClient client = new RestClient("http://10.0.2.2:8000/");
            #else
                RestClient client = new RestClient("http://localhost:8000/");
            #endif

            return client;
        }

        public static bool RetrieveAccessToken(string username, string password) {
            RestRequest request = new RestRequest("oauth/token", Method.POST);

            request.AddParameter("grant_type", Settings.GrantType);
            request.AddParameter("client_id", Settings.ClientID);
            request.AddParameter("client_secret", Settings.ClientSecret);
            request.AddParameter("username", username);
            request.AddParameter("password", password);

            IRestResponse<AuthenticationModel> response = CappriolaConnect.GetRestClient().Execute<AuthenticationModel>(request);

            AuthenticationModel auth = response.Data;

            if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                return true;
            }
            else {
                return false;
            }
        }

        public static bool RetrieveAccessTokenFromFacebookLogin()
        {
            RestRequest request = new RestRequest("oauth/token", Method.POST);

            request.AddParameter("grant_type", Settings.FacebookGrantType);
            request.AddParameter("client_id", Settings.FacebookClientID);
            request.AddParameter("client_secret", Settings.FacebookClientSecret);
            request.AddParameter("fb_token", Settings.Facebook_Token);

            IRestResponse<AuthenticationModel> response = CappriolaConnect.GetRestClient().Execute<AuthenticationModel>(request);

            Console.WriteLine(response.StatusCode);

            AuthenticationModel auth = response.Data;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Grupo GetGroupDetails(int groupId)
        {
            RestRequest request = new RestRequest(EndPoints.GroupDetails+groupId.ToString(), Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + Settings.Access_Token);

            IRestResponse<Grupo> response = CappriolaConnect.GetRestClient().Execute<Grupo>(request);

            Grupo group = response.Data;

            return group;
        }

        public static List<Grupo> GetMyGroups()
        {
            RestRequest request = new RestRequest(EndPoints.GroupsJoined, Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + Settings.Access_Token);

            IRestResponse<List<Grupo>> response = CappriolaConnect.GetRestClient().Execute<List<Grupo>>(request);

            List<Grupo> groups = response.Data;

            return groups;
        }

        public static List<Grupo> GetPublicGroups(string search = null)
        {
            if(search != null) {
                search = "/" + search;
            }
            RestRequest request = new RestRequest(EndPoints.AllGroupsExceptJoined+search, Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + Settings.Access_Token);

            IRestResponse<List<Grupo>> response = CappriolaConnect.GetRestClient().Execute<List<Grupo>>(request);

            List<Grupo> groups = response.Data;

            return groups;
        }

        public static HttpStatusCode CreateGroupService(string groupName)
        {
            RestRequest request = new RestRequest(EndPoints.CreateGroup, Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + Settings.Access_Token);

            request.AddParameter("name", groupName);

            IRestResponse<AuthenticationModel> response = CappriolaConnect.GetRestClient().Execute<AuthenticationModel>(request);

            AuthenticationModel auth = response.Data;

            return response.StatusCode;
        }

        public static HttpStatusCode JoinGroupService(int groupId)
        {
            RestRequest request = new RestRequest(EndPoints.JoinGroup, Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + Settings.Access_Token);

            request.AddParameter("group_id", groupId);

            IRestResponse<AuthenticationModel> response = CappriolaConnect.GetRestClient().Execute<AuthenticationModel>(request);

            AuthenticationModel auth = response.Data;

            return response.StatusCode;
        }

        public static Events getEventParticipants(int eventId)
        {
            RestRequest request = new RestRequest(EndPoints.EventParticipants(eventId), Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + Settings.Access_Token);

            IRestResponse<Events> response = CappriolaConnect.GetRestClient().Execute<Events>(request);

            Events evento = response.Data;

            return evento;
        }

        public static HttpStatusCode EventCheckInService(int eventId)
        {
            RestRequest request = new RestRequest(EndPoints.EventCheckIn, Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + Settings.Access_Token);

            request.AddParameter("event_id", eventId);

            IRestResponse<AuthenticationModel> response = CappriolaConnect.GetRestClient().Execute<AuthenticationModel>(request);

            AuthenticationModel auth = response.Data;

            return response.StatusCode;
        }

        public static HttpStatusCode CreateEventService(int groupId, string eventPlace, string eventDate)
        {
            RestRequest request = new RestRequest(EndPoints.CreateEvent, Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + Settings.Access_Token);

            request.AddParameter("group_id", groupId);
            request.AddParameter("name", "");
            request.AddParameter("date", eventDate);
            request.AddParameter("local", eventPlace);

            IRestResponse<AuthenticationModel> response = CappriolaConnect.GetRestClient().Execute<AuthenticationModel>(request);

            AuthenticationModel auth = response.Data;

            return response.StatusCode;
        }

        public static HttpStatusCode ChanteEventPaymentStatusService(int eventId, int userId)
        {
            RestRequest request = new RestRequest(EndPoints.ChangeEventPaymentStatus, Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + Settings.Access_Token);

            request.AddParameter("event_id", eventId);
            request.AddParameter("user_id", userId);

            IRestResponse<AuthenticationModel> response = CappriolaConnect.GetRestClient().Execute<AuthenticationModel>(request);

            AuthenticationModel auth = response.Data;

            return response.StatusCode;
        }

        public static List<Events> getAllMyEvents()
        {
            RestRequest request = new RestRequest(EndPoints.AllMyEvents, Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + Settings.Access_Token);

            IRestResponse<List<Events>> response = CappriolaConnect.GetRestClient().Execute<List<Events>>(request);

            List<Events> events = response.Data;

            return events;
        }

    }
}
