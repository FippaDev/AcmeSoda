namespace BusinessLogic.Payments
{
    public class ItemDispensedNotificationEvent : EventArgs
    {
        public string Item { get; }

        public ItemDispensedNotificationEvent(string item)
        {
            Item = item;
        }
    }
}
