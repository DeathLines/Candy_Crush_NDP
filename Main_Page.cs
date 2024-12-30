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
        private void Login_Button(object sender, EventArgs e)
        {
            player player = new player(username_input.Text, 0);
            Game_Page gamePage = new Game_Page(player);


            //username_input.Text;




            // Main_Page formunu kapatýyoruz.
            this.Hide();

            // Game_Page'i gösteriyoruz.
            gamePage.Show();
        }

        private void Main_Page_Load(object sender, EventArgs e)
        {
            int satir_sayisi = 0;
            string satir;
            string dosyaYolu = "D:\\Yazilim\\C#\\NDP_Proje\\Data.txt";
            Label[] leaderboard = [label2, label3, label4, label5, label6];


            // Dosyayý okuyup ekrana yazdýrýyoruz.
            using (StreamReader sr = new StreamReader(dosyaYolu))
            {
                while ((satir = sr.ReadLine()) != null)
                {
                   
                    if (satir.Length > 2)
                    {
                        string[] data = satir.Split('.');
                        leaderboard[satir_sayisi].Text = satir_sayisi+1 + "."+ "  " + data[1] + "  Puan: " + data[2];

                    }
                    satir_sayisi++;
                }
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        public class player
        {
            private string username;
            private int point;
            public string Username
            {
                get
                {
                    return username;
                }
                set
                {

                    username = value;
                }
            }

            public int Point
            {
                get { return point; }
                set { point = value; }
            }

            public player(string username, int point)
            {
                this.Username = username;
                this.point = point;

            }


        }

    }




}




