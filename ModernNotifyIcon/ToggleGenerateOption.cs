namespace ModernNotifyIcon
{
    public sealed class ToggleGenerateOption
    {
        public delegate void ToggleEventHandler(bool toggled);

        public string? Text { get; private set; }

        public event ToggleEventHandler? Toggled;

        public ToggleGenerateOption SetText(string text)
        {
            Text = text;
            return this;
        }

        public ToggleGenerateOption AddHandler(ToggleEventHandler handler)
        {
            Toggled += handler;
            return this;
        }

        internal void InvokeHandlers(bool check)
        {
            Toggled?.Invoke(check);
        }
    }
}
