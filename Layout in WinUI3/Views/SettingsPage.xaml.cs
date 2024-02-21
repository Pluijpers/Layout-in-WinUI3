using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Layout_in_WinUI3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        private void ThemeModeComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedTheme = ((ComboBoxItem)ThemeModeComboBox.SelectedItem)?.Tag?.ToString();

            if (selectedTheme != null)
            {

                if (selectedTheme == "Dark")
                {
                    RequestedTheme = ElementTheme.Dark;
                }
                else if (selectedTheme == "Light")
                {
                    RequestedTheme = ElementTheme.Light;
                }
                else
                {
                    RequestedTheme = ElementTheme.Default;
                }
            }
        }
    }
}
