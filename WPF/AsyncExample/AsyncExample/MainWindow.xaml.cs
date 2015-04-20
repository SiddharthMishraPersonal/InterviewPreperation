using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AsyncExample
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

    // You can run this code in Visual Studio 2013 as a WPF app or a Windows Store app.
    // You need a button (StartButton) and a textbox (ResultsTextBox).

    // To run the code as a WPF app:
    //    paste this code into the MainWindow class in MainWindow.xaml.cs,
    //    add a reference to System.Net.Http, and
    //    add a using directive for System.Net.Http.

    // To run the code as a Windows Store app:
    //    paste this code into the MainPage class in MainPage.xaml.cs, and
    //    add using directives for System.Net.Http and System.Threading.Tasks.

    private async void StartButton_Click(object sender, RoutedEventArgs e)
    {
      // ExampleMethodAsync returns a Task<int>, which means that the method
      // eventually produces an int result. However, ExampleMethodAsync returns
      // the Task<int> value as soon as it reaches an await.
      try
      {

        if (chkCountNumber.IsChecked != null && chkCountNumber.IsChecked == true)
          CountNumbers();

        Task<int> intTask = ExampleMethodAsync();
        // You can do other work here that doesn't require the result from
        // ExampleMethodAsync. . . .
        ResultsTextBox.Text += "Doing other work before awaiting intTask. . . . .\n";

        // Now wait for intTask to complete so that you can access the int result.
        int intResult = await intTask;

        // You can combine the previous steps:
        //int intResult = await ExampleMethodAsync();

        // Process the result (intResult) . . . .
        ResultsTextBox.Text += String.Format("Length: {0}\n\n", intResult);
      }
      catch (Exception)
      {
        // Process the exception if one occurs.
      }
    }

    public async Task<int> ExampleMethodAsync()
    {
      var httpClient = new HttpClient();

      // The following line activates GetStringAsync, an asynchronous method that
      // eventually returns a string.
      Task<string> contentsTask = httpClient.GetStringAsync("http://msdn.microsoft.com");

      // While the task is active, but before you await it, you can do other work.
      ResultsTextBox.Text += "Doing other work before awaiting contentsTask. . . . .\n";

      // When you await contentsTask, execution in ExampleMethodAsync is suspended
      // until contentsTask is complete. In the meantime, control returns to the 
      // caller, StartButton_Click.
      string contents = await contentsTask;

      // After contentTask completes, you can calculate the length of the string.
      int exampleInt = contents.Length;

      //// You can combine the previous sequence into a single statement.
      //int exampleInt = (await httpClient.GetStringAsync("http://msdn.microsoft.com")).Length;

      ResultsTextBox.Text += "Preparing to finish ExampleMethodAsync.\n";

      // After the following return statement, any method that's awaiting
      // ExampleMethodAsync (in this case, StartButton_Click) can get the 
      // integer result.
      return exampleInt;
    }

    DispatcherTimer timer = new DispatcherTimer();
    int count = 0;
    private async void CountNumbers()
    {
      timer.Interval = new TimeSpan(0, 0, 0, 1);

      timer.Tick += timer_Tick;
      timer.Start();
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      
      if (chkCountNumber.IsChecked != null && chkCountNumber.IsChecked == true)
      {
        ResultsTextBox.Text = count++.ToString();
      }
      else
      {
        timer.Stop();
      }
    }
  }
}
