using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
using Projekat_SIMS_IN_TIM3.Controller;
using Projekat_SIMS_IN_TIM3.Model;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using Projekat_SIMS_IN_TIM3.View.ManagerView;

namespace Projekat_SIMS_IN_TIM3.ManagerWindows
{
    /// <summary>
    /// Interaction logic for MedicinePage.xaml
    /// </summary>
    public partial class MedicinePage : Page
    {
        public ObservableCollection<Medicine> unapproved { get; set; } = new ObservableCollection<Medicine>();
        public ObservableCollection<Medicine> approved { get; set; } = new ObservableCollection<Medicine>();
        public Dictionary<Medicine, int> availableMeds { get; set; }
        public MedicineController medicineController;
        public MedicinePage()
        {
            InitializeComponent();
            var app = Application.Current as App;
            this.medicineController = app.medicineController;
            this.unapproved = new ObservableCollection<Medicine>(this.medicineController.GetUnverified());
            MedicineFrame.Content = new UnapprovedMedicineView(unapproved);
            UnapprovedButton.Background = Brushes.Aqua;
            RejectedButton.Background = (Brush)ManagerMainWindow.brushConverter.ConvertFrom("#FFDDDDDD");
            this.AddMedicine.Visibility = Visibility.Visible;
            List<Medicine> all = this.medicineController.GetVerified();
            this.availableMeds = GenerateData(all);
            this.DataContext = this;
        }

        private static Dictionary<Medicine, int> GenerateData(List<Medicine> all)
        {
            Dictionary<Medicine, int> availableMeds = new Dictionary<Medicine, int>();
            Random rnd = new Random();
            foreach (Medicine m in all)
            {
                availableMeds.Add(m, rnd.Next(1, 100));
            }

            return availableMeds;
        }

        private void Unapproved_Click(object sender, RoutedEventArgs e)
        {
            this.unapproved = new ObservableCollection<Medicine>(this.medicineController.GetUnverified());
            this.AddMedicine.Visibility = Visibility.Visible;
            MedicineFrame.Content = new UnapprovedMedicineView(unapproved);
            UnapprovedButton.Background = Brushes.Aqua;
            RejectedButton.Background = (Brush)ManagerMainWindow.brushConverter.ConvertFrom("#FFDDDDDD");
        }

        private void Rejected_Click(object sender, RoutedEventArgs e)
        {
            this.AddMedicine.Visibility = Visibility.Hidden;
            MedicineFrame.Content = new RejectedMedicineView();
            UnapprovedButton.Background = (Brush)ManagerMainWindow.brushConverter.ConvertFrom("#FFDDDDDD");
            RejectedButton.Background = Brushes.Aqua;
        }

        private void Add_Med_Click(object sender, RoutedEventArgs e)
        {
            var add = new AddMedicineWindow(unapproved);
            add.ShowDialog();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.Background(QuestPDF.Helpers.Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(16));

                    page.Header()
                        .Text("Medicine review!")
                        .SemiBold().FontSize(36).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(25)
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                            });
                            table.Header(header =>
                            {
                                header.Cell().Text("#");
                                header.Cell().Text("Name");
                                header.Cell().Text("Quantity");
                                header.Cell().Text("Replacement");
                            });
                            foreach (var med in availableMeds)
                            {
                                table.Cell().Text(med.Key.Id);
                                table.Cell().Text(med.Key.Name);
                                table.Cell().Text(med.Value);
                                table.Cell().Text(String.IsNullOrWhiteSpace(med.Key.Replacement)
                                    ? "None"
                                    : med.Key.Replacement);
                            }
                        });


                    page.Footer().AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            }).GeneratePdf("out.pdf");
        }
    }
}