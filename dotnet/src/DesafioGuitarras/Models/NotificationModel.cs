namespace DesafioGuitarras.Models
{
    public class NotificationModel
    {
        public NotificationModel()
        {

        }

        public NotificationModel(string m, Types t)
        {
            this.Message = m;
            this.Type = t;
        }

        public bool Show { get { return !string.IsNullOrEmpty(this.Message); } }
        public string Message { get; set; }
        public Types Type { get; set; }
        public string ModalClass
        {
            get
            {
                switch (this.Type)
                {
                    case Types.SUCCESS: return "alert-success";
                    case Types.DANGER: return "alert-danger";
                    case Types.WARNING: return "alert-warning";
                    case Types.INFORMATIVE:
                    default: return "alert-info";
                }
            }
        }

        public enum Types
        {
            INFORMATIVE,
            SUCCESS,
            WARNING,
            DANGER
        }
    }
}