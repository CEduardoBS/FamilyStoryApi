namespace FamilyStoryApi.Core.Entities
{
    public abstract class Notifiable
    {
        private readonly List<string> _notifications = [];

        public IReadOnlyCollection<string> Notifications => _notifications;

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
            if (string.IsNullOrWhiteSpace(message) || !Notifications.Contains(message))
                _notifications.Add(message);
        }

        public void AddNotifications(IEnumerable<string> messages)
        {
            foreach (var message in messages)
            {
                this.AddNotification(message);
            }
        }

        public void AddNotifications(params Notifiable[] notifiables)
        {
            foreach (var notifiable in notifiables)
            {
                if(notifiable is null)
                    continue;

                foreach (var notification in notifiable.Notifications)
                {
                    this.AddNotification(notification);
                }
            }
        }

        public void Reset()
        {
            _notifications.Clear();
        }

    }
}
