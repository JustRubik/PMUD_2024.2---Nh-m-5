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
using Microsoft.Data.SqlClient;

namespace LoginDemo
{
    /// <summary>
    /// Interaction logic for CapNhatDiem.xaml
    /// </summary>
    public partial class CapNhatDiem : UserControl
    {
        public CapNhatDiem()
        {
            InitializeComponent();
        }

        public class DiemModel
        {
            public required string MSSV { get; set; }
            public required string MaHocPhan { get; set; }
            public int DiemGK { get; set; }
            public double KiHoc { get; set; }
            public double MaLopHocPhan { get; set; }
            public double DiemCK { get; set; }
        }

    }
}
