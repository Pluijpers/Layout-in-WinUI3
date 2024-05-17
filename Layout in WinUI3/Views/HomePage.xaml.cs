using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Layout_in_WinUI3.Models;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Layout_in_WinUI3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public ObservableCollection<FileItem> Files { get; set; }

        public HomePage()
        {
            this.InitializeComponent();

            Files = new ObservableCollection<FileItem>
            {
                new FileItem { Path = "C:\\Temp\\Item 1.txt" },
                new FileItem { Path = "C:\\Temp\\Item 2.txt" },
                new FileItem { Path= "C:\\Temp\\Item 3.txt" },
                new FileItem { Path = "C:\\Temp\\Item 4.txt" }
            };

            FileListView.DataContext = Files;
        }


        private void FileListView_OnDragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
            e.DragUIOverride.IsCaptionVisible = false;
            e.DragUIOverride.IsGlyphVisible = false;
        }

        private async void FileListView_OnDrop(object sender, DragEventArgs e)
        {
            if (!e.DataView.Contains(StandardDataFormats.StorageItems)) return;

            var items = await e.DataView.GetStorageItemsAsync();
            foreach (var item in items)
            {
                if (item is not StorageFile file) continue;

                if (file.FileType.Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    // Process the dropped file (e.g., add it to your ListBox)
                    Files.Add(new FileItem { Path = file.Path });
                }
            }
        }

        private void FileListView_ContextFlyout_Opening(object sender, object e)
        {
            // Enable or disable the "Delete" menu item based on selection
            var context = sender as MenuFlyout;

            //context.Items. .IsEnabled = FileListView.SelectedItems.Count > 0;
        }

    private void FileListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Handle the selection change here
        // You can access the selected item(s) using e.AddedItems
        // For example:
        if (e.AddedItems.Count > 0)
        {
            // An item was selected
            if (e.AddedItems[0] is FileItem selectedItem)
            {
                // Do something with the selected item (e.g., show details, enable buttons, etc.)
            }
        }
        else
        {
            // No item is selected
            // You can disable buttons or perform other actions as needed
        }
    }


    private void FileListView_DeleteItem_Click(object sender, RoutedEventArgs e)
    {
        if (FileListView.SelectedItem == null) return;

        var selectedItem = FileListView.SelectedItem as FileItem;
        Files.Remove(selectedItem);
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var x = Files.Count;
    }
}
}
