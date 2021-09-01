using System.Windows.Forms;
using Microsoft.Win32;

namespace ModernNotifyIcon.Theme
{
    public class ThemeReferencedContextMenuStrip : ContextMenuStrip
    {
        public ThemeReferencedRenderer ThemeReferencedRenderer { get; }

        public int Spacing 
        { 
            get => ThemeReferencedRenderer.VerticalPadding;
            set => ThemeReferencedRenderer.VerticalPadding = value; 
        }

        public ThemeReferencedContextMenuStrip()
        {
            Renderer = ThemeReferencedRenderer = new ThemeReferencedRenderer();
            ForeColor = ThemeDictionary.TextFillColorPrimary;
            SystemEvents.UserPreferenceChanged += (_, _) => ForeColor = ThemeDictionary.TextFillColorPrimary;
        }
    }
}
