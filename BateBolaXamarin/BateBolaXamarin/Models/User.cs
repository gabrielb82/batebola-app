using System;
namespace BateBolaXamarin.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string facebook_id { get; set; }
        public string username { get; set; }
        public string avatar { get; set; }
        public string phone { get; set; }
        public string cell { get; set; }
        public string img { get; set; }
        public int paid { get; set; }
        public int approved { get; set; }

        public string paidImage { get {
                if(paid == 1) {
                    return "icon_paid.png";
                }
                else {
                    return "";
                }
            } 
        }

        public string approvalIcon
        {
            get
            {
                if (approved == 1)
                {
                    return "icon_ok.png";
                }
                else
                {
                    return "icon_alert.png";
                }
            }
        }

        public string GetUserAvatar {
            get{
                if (facebook_id != "" && facebook_id != null)
                {
                    return "https://graph.facebook.com/" + facebook_id + "/picture?type=normal";
                }
                else
                {
                    if(avatar == null) {
                        return "no_photo.jpg";
                    }
                    return img;
                }
            }
        }
    }
}
