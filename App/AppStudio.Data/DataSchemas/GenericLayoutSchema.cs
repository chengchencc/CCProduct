using System;
using System.Collections;
using Newtonsoft.Json;

namespace AppStudio.Data
{
    /// <summary>
    /// Implementation of the GenericLayoutSchema class.
    /// </summary>
    public class GenericLayoutSchema : BindableSchemaBase, IEquatable<GenericLayoutSchema>, ISyncItem<GenericLayoutSchema>
    {
        private string _name;
        private string _surname;
        private string _personalSummary;
        private string _image;
        private string _other;
        private string _phone;
        private string _mail;
        private string _thumbnail;
        [JsonProperty("_id")]
        public string Id { get; set; }

 
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
 
        public string Surname
        {
            get { return _surname; }
            set { SetProperty(ref _surname, value); }
        }
 
        public string PersonalSummary
        {
            get { return _personalSummary; }
            set { SetProperty(ref _personalSummary, value); }
        }
 
        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }
 
        public string Other
        {
            get { return _other; }
            set { SetProperty(ref _other, value); }
        }
 
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }
 
        public string Mail
        {
            get { return _mail; }
            set { SetProperty(ref _mail, value); }
        }
 
        public string Thumbnail
        {
            get { return _thumbnail; }
            set { SetProperty(ref _thumbnail, value); }
        }

        public override string DefaultTitle
        {
            get { return Name; }
        }

        public override string DefaultSummary
        {
            get { return Surname; }
        }

        public override string DefaultImageUrl
        {
            get { return Image; }
        }

        public override string DefaultContent
        {
            get { return Surname; }
        }

        override public string GetValue(string fieldName)
        {
            if (!String.IsNullOrEmpty(fieldName))
            {
                switch (fieldName.ToLowerInvariant())
                {
                    case "name":
                        return String.Format("{0}", Name); 
                    case "surname":
                        return String.Format("{0}", Surname); 
                    case "personalsummary":
                        return String.Format("{0}", PersonalSummary); 
                    case "image":
                        return String.Format("{0}", Image); 
                    case "other":
                        return String.Format("{0}", Other); 
                    case "phone":
                        return String.Format("{0}", Phone); 
                    case "mail":
                        return String.Format("{0}", Mail); 
                    case "thumbnail":
                        return String.Format("{0}", Thumbnail); 
                    case "defaulttitle":
                        return DefaultTitle;
                    case "defaultsummary":
                        return DefaultSummary;
                    case "defaultimageurl":
                        return DefaultImageUrl;
                    default:
                        break;
                }
            }
            return String.Empty;
        }

        public bool Equals(GenericLayoutSchema other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return this.Id == other.Id;
        }

        public bool NeedSync(GenericLayoutSchema other)
        {

            return this.Id == other.Id && (this.Name != other.Name || this.Surname != other.Surname || this.PersonalSummary != other.PersonalSummary || this.Image != other.Image || this.Other != other.Other || this.Phone != other.Phone || this.Mail != other.Mail || this.Thumbnail != other.Thumbnail);
        }

        public void Sync(GenericLayoutSchema other)
        {
            this.Name = other.Name;
            this.Surname = other.Surname;
            this.PersonalSummary = other.PersonalSummary;
            this.Image = other.Image;
            this.Other = other.Other;
            this.Phone = other.Phone;
            this.Mail = other.Mail;
            this.Thumbnail = other.Thumbnail;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GenericLayoutSchema);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
