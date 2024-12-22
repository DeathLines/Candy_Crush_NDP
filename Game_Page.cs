using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDP_Proje
{



    public partial class Game_Page : Form
    {
        private PictureBox storagePicBox = new PictureBox();  // İlk seçilen şekerin bilgilerini tutmak için kullanıldı.
        private int select1, select2;                         // select1 : ilk seçilen şekerin kontrolü, select2: ikinci seçilen şekerin kontrolü
        private int per_count = 0;
        private int end_of_per = 0;
        private int start_of_per = 0;
        private bool done;
        private PictureBox[] pics;




        private int firstx;
        private int firsty;
        private int lastx;
        private int lasty;

        public Game_Page()
        {
            this.lastx = 0;
            this.lasty = 0;


            Random random = new Random();
            Seker1[] sekerler = new Seker1[36];
            string[] imgs = { "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_dikey_roket.png", "item_yatay_roket.png", "item_bomba.png", "item_gokkusagi.png", "item_helicopter.png" };


            InitializeComponent();

            pics = new PictureBox[]{
                //  __0__       __1__         __2__         __3__         __4__         __5__        __6__          __7__
                pictureBox37,pictureBox31, pictureBox32, pictureBox33, pictureBox34, pictureBox35,pictureBox36,pictureBox46,
                pictureBox38,pictureBox25, pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30,pictureBox47,
                pictureBox45,pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24,pictureBox48,
                pictureBox44,pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18,pictureBox39,
                pictureBox43,pictureBox7, pictureBox8, pictureBox9, pictureBox10,pictureBox11, pictureBox12,pictureBox40,
                pictureBox42,pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,pictureBox6,pictureBox41
                };
            int[] syntax = { 0, 7, 8, 15, 16, 23, 24, 31, 32, 39, 40, 47 };

            for (int i = 0; i < pics.Count() - 1; i++)
            {
                int randomNumber = random.Next(0, 44);

                if (syntax.Contains(i))
                {
                    continue;
                }
                pics[i].BackgroundImage = Image.FromFile($"D:\\Yazilim\\C#\\NDP_Proje\\imgs\\{imgs[randomNumber]}");
                pics[i].Tag = imgs[randomNumber];
                pics[i].AllowDrop = true;
                //sekerler[i] = new Seker1(0, 0, "a");
                //sekerler[i].

            }

            //Seker1 ab = new Seker1(10, 5, "a");
            //Console.WriteLine($"Seker1: x = {ab.x}, y = {ab.x}, type = {ab.type}");
            //pictureBox1.BackgroundImage 

        }



        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void SugarMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Console.WriteLine("Mouse Left Click");
                //SugarDragDrop(sender);
                //DoDragDrop(sender, DragDropEffects.Move);
                PictureBox picbox = (PictureBox)sender;
                Console.WriteLine(picbox.Name);

                if (select1 == 0)
                {
                    SaveSugarPictureBox(picbox.Name, picbox.BackgroundImage, picbox.Location, picbox.Size, picbox.Tag);
                    select1 = 1;
                }
                else if (select2 == 0)
                {
                    // Yer değiştirme işlmei başladı
                    foreach (var item in pics)
                    {
                        if (item.Name == storagePicBox.Name)
                        {
                            //item.Name = picbox.Name;
                            item.BackgroundImage = picbox.BackgroundImage;
                            item.Tag = picbox.Tag;
                            //item.Location = picbox.Location;
                            //item.Size = picbox.Size;
                        }
                    }
                    foreach (var item in pics)
                    {
                        if (item.Name == picbox.Name)
                        {
                            //item.Name = storagePicBox.Name;
                            item.BackgroundImage = storagePicBox.BackgroundImage;
                            item.Tag = storagePicBox.Tag;
                            //item.Location = storagePicBox.Location;
                            //item.Size = storagePicBox.Size;
                        }

                    }
                    select1 = 0;
                    select2 = 0;

                    // Yer değiştirme işlemi bitti 

                    DeleteSugars();



                }
            }
            Console.WriteLine("$$$$$MOUSE__DOWN$$$$");
        }


        private void DeleteSugars()
        {
            string[] jokers = { "item_dikey_roket.png", "item_yatay_roket.png", "item_bomba.png", "item_gokkusagi.png", "item_helicopter.png" };

            // YATAY YOK EDİŞ
            for (int i = 0; i < pics.Count() - 1; i++)  // Bütün satırları gez
            {
                //Console.WriteLine($"AccName: {pics[i].AccessibleName}");
                //Console.WriteLine($"########\npic[i]: {pics[i]}\npics[i].AccessibleName: {pics[i].AccessibleName}\npics[i].Tag: {pics[i].Tag}\n#########");

                // Eğer format picboxuna geldiyse geç
                if ((pics[i].AccessibleName == "Newline") || (pics[i].AccessibleName == "NewlineUp"))
                {
                    continue;
                }

                // Eğer son elemana geldiyse geç
                if (i + 1 > pics.Count() - 1)
                {
                    Console.WriteLine("i Aşımı");
                    continue;
                }

                else
                {
                    // Eğer iki şeker birbirine eşitse
                    if (pics[i].Tag == pics[i + 1].Tag)
                    {
                        per_count++;

                        // Eğer iki şeker birbirine eşitse ve bir sonraki şeker de eşitse
                        while ((pics[i].Tag == pics[i + 1].Tag))
                        {

                            per_count++;
                            i++;
                        }

                        // Eğer 3 lü per oluştuysa 
                        if (per_count >= 3)
                        {
                            // Eğer joker varsa
                            if (jokers.Contains(pics[i + 1].Tag))
                            {
                                switch (pics[i + 1].Tag)
                                {
                                    case "item_dikey_roket.png":
                                        Console.WriteLine("Dikey Roket");

                                        break;
                                    case "item_yatay_roket.png":
                                        var jok_result = yatay_roket(i);
                                        done = jok_result.Item1;
                                        i = jok_result.Item2;
                                        break;
                                    case "item_bomba.png":
                                        Console.WriteLine("Bomba");
                                        break;
                                    case "item_gokkusagi.png":
                                        Console.WriteLine("Gökkuşağı");
                                        break;
                                    case "item_helicopter.png":
                                        Console.WriteLine("Helicopter");
                                        break;

                                    default:
                                        break;
                                }
                            }

                            //Eğer silindiyse
                            if (done)
                            {
                                for (int j = i; j > i - per_count; j--)
                                {
                                    // Silinen şekerlerin yerine yeni şekerler ekleniyor
                                    var result_CreateImage = CreateSugarImage();
                                    Image _Image = result_CreateImage.Item1;
                                    String _Tag = result_CreateImage.Item2;
                                    pics[j].BackgroundImage = _Image;
                                    pics[j].Tag = _Tag;


                                }
                            }
                        }

                        done = true;
                    }
                    
                    //else

                    Console.WriteLine($"@@pics[i].Tag: {pics[i].Tag}");
                    Console.WriteLine($"@@pics[i+1].Tag: {pics[i + 1].Tag}");
                }
                Console.WriteLine(per_count);
                per_count = 0;
            }





            // Dikey yok ediş

            for (int i = 1; i < 7; i++)
            {
                per_count = 0;
                for (int j = i; j < pics.Count(); j += 8)
                {
                    if (j + 8 > pics.Count() - 1)
                    {
                        Console.WriteLine("i Aşımı");
                        continue;
                    }
                    //Console.WriteLine($"##pics[j].TAG: {pics[j].Tag}\npics[j+8].TAG: {pics[j + 8].Tag}");
                    if (pics[j].Tag == pics[j + 8].Tag)
                    {
                        start_of_per = j;
                        per_count += 8;
                        while (pics[j].Tag == pics[j + 8].Tag)
                        {
                            //Console.WriteLine($"##pics[j].TAG: {pics[j].Tag}\npics[j+8].TAG: {pics[j + 8].Tag}");
                            per_count += 8;
                            j += 8;
                            end_of_per = j;
                            if ((j + 8) > pics.Count()) break;
                        }
                        if (per_count >= 24)
                        {                       //NEGATİF OLUYOR PER COUNT J DEN HEP 5 DAHA BÜYÜK ÇIKIYOR
                            for (int k = end_of_per; k >= start_of_per; k -= 8)
                            {
                                // Silinen şekerlerin yerine yeni şekerler ekleniyor
                                var result_CreateImage = CreateSugarImage();
                                Image _Image = result_CreateImage.Item1;
                                String _Tag = result_CreateImage.Item2;
                                pics[k].BackgroundImage = _Image;
                                pics[k].Tag = _Tag;
                            }
                        }
                    }
                }
            }


        }

        private (bool,int) yatay_roket(int i)
        {
            int new_i = 0;
            Console.WriteLine("Yatay Roket");
            while ((pics[i - 1].AccessibleName != "NewLineUp") && (pics[i - 1].AccessibleName != "End"))
            {

                i--;
                if (i == 0) break;
            }

            for (int j = i; j < i + 6; j++)
            {
                var result_CreateImage = CreateSugarImage();
                Image _Image = result_CreateImage.Item1;
                String _Tag = result_CreateImage.Item2;
                pics[j].BackgroundImage = _Image;
                pics[j].Tag = _Tag;
                new_i = j;
            }

            return (false,new_i);

        }

        private void SaveSugarPictureBox(string name, Image image, Point location, Size size, object Tag)
        {

            storagePicBox.Name = name;
            storagePicBox.BackgroundImage = image;
            storagePicBox.Location = location;
            storagePicBox.Size = size;
            storagePicBox.Tag = Tag;

        }

        private (Image, string) CreateSugarImage()
        {
            Random random = new Random();
            string[] imgs = { "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_dikey_roket.png", "item_yatay_roket.png", "item_bomba.png", "item_gokkusagi.png", "item_helicopter.png" };
            int randomNumber = random.Next(0, 44);
            return (Image.FromFile($"D:\\Yazilim\\C#\\NDP_Proje\\imgs\\{imgs[randomNumber]}"), imgs[randomNumber]);

        }



        public class Seker1
        {
            public int x;
            public int y;
            public string type;


            public Seker1(int x, int y, string type)
            {
                this.x = x;
                this.y = y;
                this.type = type;
            }

        }
    }
}

