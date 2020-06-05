using System;
using System.Threading.Tasks;
using System.Windows;

namespace Crystal_Report
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += async (o, e) =>
            {
                try
                {
                    CrystalReport report = new CrystalReport();
                    report.SetParameterValue("Report", "<table  border='1' cellpadding='2' cellspacing='0'><tr><th>First Name</th><th>Last Name</th></tr><tr><td>Jill</td><td>XXX</td></tr><tr><td>Jill</td><td>XXX</td></tr><tr><td>Jill</td><td>XXX</td></tr><tr><td>Jill</td><td>XXX</td></tr><tr><td>Jill</td><td>XXX</td></tr></table>");
                    crystalReportsViewer.ViewerCore.ReportSource = report;
                    await Task.Run(async () =>
                    {
                        await Task.Delay(1000);
                        report.PrintToPrinter(1, false, 0, 0);
                    });
                       
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            };
        }
    }
}
