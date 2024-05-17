using System.ComponentModel;
using System.IO;

namespace Layout_in_WinUI3.Models;

public class FileItem : INotifyPropertyChanged
{
    private string _path;

    public string Name
    {
        get
        {
            var fileInfo = new FileInfo(_path);
            return fileInfo.Name;
        }
    }


    public string Path
    {
        get => _path;
        set
        {
            _path = value;
            OnPropertyChanged(nameof(Path));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}