using System.Windows.Forms;

namespace ModernNotifyIcon.Theme
{
    public class ThemeReferencedContextMenuStrip : ContextMenuStrip
    {
        public ThemeReferencedRenderer ThemeReferencedRenderer { get; }

        public ThemeReferencedContextMenuStrip()
        {
            Renderer = ThemeReferencedRenderer = new ThemeReferencedRenderer();
        }
    }
}
