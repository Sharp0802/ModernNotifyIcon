using System;

namespace ModernNotifyIcon
{
    public sealed class ButtonGenerateOption
    {
        public string? Text { get; private set; }

        public event Action? Toggled;

        public ButtonGenerateOption SetText(string text)
        {
            Text = text;
            return this;
        }

        public ButtonGenerateOption AddHandler(Action handler)
        {
            Toggled += handler;
            return this;
        }

        internal void InvokeHandlers()
        {
            Toggled?.Invoke();
        }
    }
}
