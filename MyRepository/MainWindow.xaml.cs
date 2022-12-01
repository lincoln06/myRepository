using MyRepository.Classes;
using MyRepository.Classes.Model;
using System;
using System.Collections.Generic;
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

namespace MyRepository
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Book book = new("a", "b", "c", "d", 1221);
            book.Validate();
            //book.IsValid = true;
        }
    }
}