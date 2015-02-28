using System;
using Newtonsoft.Json;

namespace AppStudio.Data
{
    public class TouchDevelopSchema : BindableSchemaBase, IEquatable<TouchDevelopSchema>
    {
        public TouchDevelopSchema()
        {
        }

        public TouchDevelopSchema(TouchDevelopItem item)
        {
            this.Id = item.id;
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            this.Time = epoch.AddSeconds(item.time);
            this.Url = item.url;
            this.Name = Utility.DecodeHtml(item.name);
            this.Description = Utility.DecodeHtml(item.description);
            this.IconUrl = item.iconurl;
            this.IconBackground = item.iconbackground;
            this.UserId = item.userid;
            this.UserName = Utility.DecodeHtml(item.username);
            this.UserHasPicture = item.userhaspicture;
            this.UserScore = item.userscore;
            this.ScreenshotThumbUrl = item.screenshotthumburl;
            this.CumulativePositiveReviews = item.cumulativepositivereviews;
        }

        public string Id { get; set; }

        public DateTime Time { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string IconUrl { get; set; }

        public string IconBackground { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public bool UserHasPicture { get; set; }

        public int UserScore { get; set; }

        public string ScreenshotThumbUrl { get; set; }

        public int CumulativePositiveReviews { get; set; }

        [JsonIgnore]
        public string UserPictureUrl
        {
            get { return this.UserHasPicture ? string.Format("http://www.touchdevelop.com/api/{0}/picture?type=large", this.UserId) : string.Empty; }
        }

        [JsonIgnore]
        public string ScreenshotUrl
        {
            get { return string.IsNullOrEmpty(ScreenshotThumbUrl) ? string.Empty : ScreenshotThumbUrl.Replace("/thumb/", "/pub/"); }
        }

        [JsonIgnore]
        public bool HasScreenshot
        {
            get { return !string.IsNullOrEmpty(this.ScreenshotThumbUrl); }
        }

        [JsonIgnore]
        public override string DefaultContent
        {
            get { return this.Description; }
        }

        [JsonIgnore]
        public override string DefaultImageUrl
        {
            get { return this.IconUrl; }
        }

        [JsonIgnore]
        public override string DefaultSummary
        {
            get { return this.Description; }
        }

        [JsonIgnore]
        public override string DefaultTitle
        {
            get { return this.Name; }
        }

        public override string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLower())
                {
                    case "id":
                        return string.Format("{0}", Id);
                    case "time":
                        return string.Format("{0}", Time);
                    case "url":
                        return string.Format("{0}", Url);
                    case "name":
                        return string.Format("{0}", Name);
                    case "description":
                        return string.Format("{0}", Description);
                    case "userid":
                        return string.Format("{0}", UserId);
                    case "username":
                        return string.Format("{0}", UserName);
                    case "userscore":
                        return string.Format("{0}", UserScore);
                    case "userhaspicture":
                        return string.Format("{0}", UserHasPicture);
                    case "iconurl":
                        return string.Format("{0}", IconUrl);
                    case "iconbackground":
                        return string.Format("{0}", IconBackground);
                    case "cumulativepositivereviews":
                        return string.Format("{0}", CumulativePositiveReviews);
                    case "screenshotthumburl":
                        return string.Format("{0}", ScreenshotThumbUrl);
                    case "screenshoturl":
                        return string.Format("{0}", ScreenshotUrl);
                    case "defaulttitle":
                        return string.Format("{0}", DefaultTitle);
                    case "defaultsummary":
                        return string.Format("{0}", DefaultSummary);
                    case "defaultimageurl":
                        return string.Format("{0}", DefaultImageUrl);
                    default:
                        break;
                }
            }
            return string.Empty;
        }

        public bool Equals(TouchDevelopSchema other)
        {
            return this.Id == other.Id;
        }
    }
}