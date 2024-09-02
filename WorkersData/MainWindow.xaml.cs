using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;


namespace WorkersData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> dataList;

        public MainWindow()
        {
            InitializeComponent();
          dataList = new ObservableCollection<Person>();
          Listdata.DataContext = dataList;
          Person person = new Person();
          this.DataContext = person;
          File.WriteAllText("workersTemp.txt", "");
        }

        private void Add_Click(object sender, RoutedEventArgs e)
       {
            if (TextBox1.Text == String.Empty || Convert.ToInt32(TextBox2.Text) == 0 || Convert.ToInt32(TextBox3.Text) == 0)
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                try
                {
                    Person person = new Person
                    {
                        Name = TextBox1.Text,
                        Salary = Convert.ToInt32(TextBox2.Text),
                        Job_Title = ComboBox1.Text,
                        City = ComboBox2.Text,
                        Street = ComboBox3.Text,
                        NumberOfHouse = Convert.ToInt32(TextBox3.Text),
                    };
                    this.DataContext = person;

                    dataList.Add(person);

                    string path = "workersTemp.txt";

                    File.AppendAllLinesAsync(path, new[] {
                        "\n name: " + TextBox1.Text +
                        "\n salary: "  + TextBox2.Text +
                        "\n jobTitle: " + ComboBox1.Text +
                        "\n city: " + ComboBox2.Text +
                        "\n street: " + ComboBox3.Text +
                        "\n house: " + TextBox3.Text
                      });


                }
                catch
                {
                    new Exception();
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            ComboBox1.Text = string.Empty;
            ComboBox2.Text = string.Empty;
            ComboBox3.Text = string.Empty;
            TextBox3.Text = string.Empty;
        }

        private  void OpenFile(object sender, RoutedEventArgs e)
        { 
            try
            {
                string path = "workers.txt";
               Open.Text = File.Exists(path) ? File.ReadAllText(path) : "Файл не найден";

            }
            catch { new Exception(); }
          
        }

        private  void SaveFile(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = "workersTemp.txt";
                string path1 = "workers.txt";
                StreamReader reader = new StreamReader(path);
                if (File.Exists(path1))
                {
                    string text = File.ReadAllText(path);

                    File.AppendAllText(path1, text);
                }
                else { MessageBox.Show("Файл не найден"); }
            }
            catch { new Exception(); }
           
        }
    }
}