using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FamilyStoryApi.Core.Entities
{
    public abstract class Notifiable
    {
        public IList<string> Notifications { get; private set; } = new List<string>();

        public bool IsValid
        {
            get
            {
                bool _isValid = Notifications.Count == 0;
                return _isValid;
            }
        }

        public bool IsInvalid
        {
            get
            {
                bool _isInValid = Notifications.Count != 0;
                return _isInValid;
            }
        }

        public Notifiable() { }

        public void AddNotification(string message)
        {
            Notifications.Add(message);
        }

        public void AddNotifications(List<string> messages)
        {
            messages.ForEach(message => Notifications.Add(message));
        }

        public void AddNotifications(params Notifiable[] notifiables)
        {
            foreach (var item in notifiables)
            {
                if (item.Notifications.Count > 0)
                {
                    foreach (var news in item.Notifications)
                    {
                        Notifications.Add(news);
                    }
                }                
            }
        }

        public void Reset()
        {
            Notifications.Clear();
        }

    }
}
