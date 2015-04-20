using System.Windows;

namespace WPFTutorial
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void XamlTutorialButton_OnClick(object sender, RoutedEventArgs e)
    {
      var xamlTutorialWindow = new XAMLTutorial();
      xamlTutorialWindow.ShowDialog();
    }
  }
}
