using System.Windows.Forms;

namespace ModernNotifyIcon.Theme
{
    public class ThemeReferencedContextMenuStrip : ContextMenuStrip
    {
        public ThemeReferencedContextMenuStrip()
        {
            Renderer = new ThemeReferencedRenderer();
        }
    }
}
