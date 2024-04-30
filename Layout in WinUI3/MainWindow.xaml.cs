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

namespace Layout_in_WinUI3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);

            AppNavigationControl.SelectedItem = AppNavigationControl.MenuItems.OfType<NavigationViewItem>().First();
            ContentFrame.Navigate(
                typeof(Views.HomePage),
                null,
                new Microsoft.UI.Xaml.Media.Animation.EntranceNavigationTransitionInfo()
            );
        }


        private void AppNavigationControl_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {
                ContentFrame.Navigate(typeof(Views.SettingsPage), null, args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null && (args.InvokedItemContainer.Tag != null))
            {
                var newPage = Type.GetType(args.InvokedItemContainer.Tag.ToString() ?? string.Empty);
                ContentFrame.Navigate(newPage, null, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void AppNavigationControl_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (ContentFrame.CanGoBack) ContentFrame.GoBack();
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            AppNavigationControl.IsBackEnabled = ContentFrame.CanGoBack;

            if (ContentFrame.SourcePageType == typeof(Views.SettingsPage))
            {
                // SettingsItem is not part of NavView.MenuItems, and doesn't have a Tag.
                AppNavigationControl.SelectedItem = (NavigationViewItem)AppNavigationControl.SettingsItem;
            }
            else if (ContentFrame.SourcePageType != null)
            {
                AppNavigationControl.SelectedItem = AppNavigationControl.MenuItems
                    .OfType<NavigationViewItem>()
                    .First(n => n.Tag.Equals(ContentFrame.SourcePageType.FullName.ToString()));
            }

            AppNavigationControl.Header = ((NavigationViewItem)AppNavigationControl.SelectedItem)?.Content?.ToString();
        }

    }
}
