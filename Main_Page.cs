using System.Diagnostics;

namespace NDP_Proje
{
    public partial class Main_Page : Form
    {

        public Main_Page()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Labele bas�ld�");
            Debug.WriteLine("Label");
        }

        private void Main_Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("pencere y�klendi");
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }




}




