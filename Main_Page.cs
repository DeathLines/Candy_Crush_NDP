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
            Console.WriteLine("Labele basýldý");
            Debug.WriteLine("Label");
        }

        private void Main_Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("pencere yüklendi");
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }




}




