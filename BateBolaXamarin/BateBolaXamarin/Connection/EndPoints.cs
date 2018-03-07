using System;
namespace BateBolaXamarin.Connection
{
    public static class EndPoints
    {
        public static string GroupDetails
        {
            get { return "api/group/"; }
        }

        public static string GroupsJoined
        {
            get { return "api/groups-joined"; }
        }

        public static string AllGroupsExceptJoined
        {
            get { return "api/all-groups-except-joined"; }
        }

        public static string CreateGroup
        {
            get { return "api/create-group"; }
        }

        public static string JoinGroup
        {
            get { return "api/group/join"; }
        }

        public static string EventParticipants(int eventId)
        {
            return "api/event/" + eventId.ToString();
        }

        public static string EventCheckIn
        {
            get { return "api/event-check-in"; }
        }

        public static string CreateEvent
        {
            get { return "api/create-event"; }
        }

        public static string ChangeEventPaymentStatus
        {
            get { return "api/change-event-payment-status"; }
        }

        public static string AllMyEvents
        {
            get { return "api/all-my-events"; }
        }
    }
}
