using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        //private bool changed = true;
        private PictureBox[] pics;


        public Game_Page()
        {



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
            ////Console.WriteLine($"Seker1: x = {ab.x}, y = {ab.x}, type = {ab.type}");
            //pictureBox1.BackgroundImage 

            DeleteSugars();


        }



        //private void check_changes()
        //{
        //    while (changed)
        //    {
        //        Console.WriteLine("Değişiklik var");
        //        changed = DeleteSugars();
        //    }
        //}

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void SugarMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Console.WriteLine("Mouse Left Click");
                //SugarDragDrop(sender);
                //DoDragDrop(sender, DragDropEffects.Move);
                PictureBox picbox = (PictureBox)sender;
                //Console.WriteLine(picbox.Name);

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
                    Console.WriteLine("____________________________________________\n");
                    //check_changes();



                }
            }
            //Console.WriteLine("$$$$$MOUSE__DOWN$$$$");
        }


        private bool DeleteSugars()
        {
            Thread.Sleep(100);
            Console.WriteLine("DeleteSugars");
            bool basechanged = false;
            string[] jokers = { "item_dikey_roket.png", "item_yatay_roket.png", "item_bomba.png", "item_gokkusagi.png", "item_helicopter.png" };

            // YATAY YOK EDİŞ
            for (int i = 0; i < pics.Count() - 1; i++)  // Bütün satırları gez
            {
                ////Console.WriteLine($"AccName: {pics[i].AccessibleName}");
                ////Console.WriteLine($"########\npic[i]: {pics[i]}\npics[i].AccessibleName: {pics[i].AccessibleName}\npics[i].Tag: {pics[i].Tag}\n#########");

                // Eğer format picboxuna geldiyse geç
                if ((pics[i].AccessibleName == "Newline") || (pics[i].AccessibleName == "NewlineUp"))
                {
                    continue;
                }

                // Eğer son elemana geldiyse geç
                if (i + 1 > pics.Count() - 1)
                {
                    //Console.WriteLine("i Aşımı");
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
                            if (jokers.Contains(pics[i + 1].Tag) || jokers.Contains(pics[i - per_count].Tag))
                            {
                                switch (pics[i + 1].Tag)
                                {
                                    case "item_dikey_roket.png":
                                        //Console.WriteLine("Dikey Roket");
                                        dikey_roket(i);
                                        break;
                                    case "item_yatay_roket.png":
                                        var jok_result = yatay_roket(i);
                                        done = jok_result.Item1;
                                        i = jok_result.Item2;
                                        break;
                                    case "item_bomba.png":
                                        //Console.WriteLine("Bomba");
                                        break;
                                    case "item_gokkusagi.png":
                                        //Console.WriteLine("Gökkuşağı");
                                        break;
                                    case "item_helicopter.png":
                                        //Console.WriteLine("Helicopter");
                                        break;

                                    default:
                                        break;
                                }
                                if ((i - per_count) > 0)
                                {
                                    switch (pics[i - per_count].Tag)
                                    {
                                        case "item_dikey_roket.png":
                                            //Console.WriteLine("Dikey Roket");
                                            dikey_roket(i - per_count - 1);
                                            break;
                                        case "item_yatay_roket.png":
                                            var jok_result = yatay_roket(i);
                                            done = jok_result.Item1;
                                            i = jok_result.Item2;
                                            break;
                                        case "item_bomba.png":
                                            //Console.WriteLine("Bomba");
                                            break;
                                        case "item_gokkusagi.png":
                                            //Console.WriteLine("Gökkuşağı");
                                            break;
                                        case "item_helicopter.png":
                                            //Console.WriteLine("Helicopter");
                                            break;

                                        default:
                                            break;
                                    }
                                }
                            }

                            //Eğer silindiyse
                            //if (done)
                            //{
                            for (int j = i; j > i - per_count; j--)
                            {
                                //changed = true;
                                basechanged = true;
                                if ((pics[j].AccessibleName == "NewLineUp") || (pics[j].AccessibleName == "End"))
                                {
                                    continue;
                                }
                                // Silinen şekerlerin yerine yeni şekerler ekleniyor
                                var result_CreateImage = CreateSugarImage();
                                Image _Image = result_CreateImage.Item1;
                                String _Tag = result_CreateImage.Item2;
                                pics[j].BackgroundImage = _Image;
                                pics[j].Tag = _Tag;


                            }
                        }
                        //}

                        //else
                        //{
                        //    changed = false;
                        //}

                        done = true;
                    }
                    else
                    {
                        //changed = false;
                    }

                    //else

                    //Console.WriteLine($"@@pics[i].Tag: {pics[i].Tag}");
                    //Console.WriteLine($"@@pics[i+1].Tag: {pics[i + 1].Tag}");
                }
                //Console.WriteLine(per_count);
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
                        //Console.WriteLine("i Aşımı");
                        continue;
                    }
                    ////Console.WriteLine($"##pics[j].TAG: {pics[j].Tag}\npics[j+8].TAG: {pics[j + 8].Tag}");
                    if (pics[j].Tag == pics[j + 8].Tag)
                    {
                        start_of_per = j;
                        per_count += 8;
                        while (pics[j].Tag == pics[j + 8].Tag)
                        {
                            ////Console.WriteLine($"##pics[j].TAG: {pics[j].Tag}\npics[j+8].TAG: {pics[j + 8].Tag}");
                            per_count += 8;
                            j += 8;
                            end_of_per = j;
                            if ((j + 8) > pics.Count()) break;
                        }
                        if (per_count >= 24)
                        {                       //NEGATİF OLUYOR PER COUNT J DEN HEP 5 DAHA BÜYÜK ÇIKIYOR
                            for (int k = end_of_per; k >= start_of_per; k -= 8)
                            {
                                //changed = true;
                                basechanged = true;
                                if ((pics[k].AccessibleName == "NewLineUp") || (pics[k].AccessibleName == "End"))
                                {
                                    continue;
                                }
                                // Silinen şekerlerin yerine yeni şekerler ekleniyor
                                var result_CreateImage = CreateSugarImage();
                                Image _Image = result_CreateImage.Item1;
                                String _Tag = result_CreateImage.Item2;
                                pics[k].BackgroundImage = _Image;
                                pics[k].Tag = _Tag;

                                if (k + 8 > pics.Count())
                                {
                                    Console.WriteLine("k+8");
                                }
                                else if (k - 8 < 0)
                                {
                                    Console.WriteLine("k-8");
                                }
                                else
                                {
                                    Console.WriteLine("|||Dikey Kontrol|||");
                                    if (jokers.Contains((pics[k + 8].Tag)))
                                    {
                                        switch (pics[k + 8].Tag)
                                        {
                                            case "item_dikey_roket.png":
                                                dikey_roket(k + 8);
                                                break;
                                            case "item_yatay_roket.png":
                                                var jok_result = yatay_roket(k + 8);
                                                done = jok_result.Item1;
                                                k = jok_result.Item2;
                                                break;
                                            case "item_bomba.png":
                                                break;
                                            case "item_gokkusagi.png":
                                                break;
                                            case "item_helicopter.png":
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else if (jokers.Contains((pics[k - 8].Tag)))
                                    {
                                        switch (pics[k - 8].Tag)
                                        {

                                            case "item_dikey_roket.png":
                                                dikey_roket(k - 8);
                                                break;
                                            case "item_yatay_roket.png":
                                                var jok_result = yatay_roket(k - 8);
                                                done = jok_result.Item1;
                                                k = jok_result.Item2;
                                                break;
                                            case "item_bomba.png":
                                                break;
                                            case "item_gokkusagi.png":
                                                break;
                                            case "item_helicopter.png":
                                                break;
                                            default:
                                                break;

                                        }
                                    }
                                    else if (jokers.Contains((pics[k + 1].Tag)))
                                    {
                                        switch (pics[k + 1].Tag)
                                        {

                                            case "item_dikey_roket.png":
                                                dikey_roket(k + 1);
                                                break;
                                            case "item_yatay_roket.png":
                                                var jok_result = yatay_roket(k + 1);
                                                done = jok_result.Item1;
                                                k = jok_result.Item2;
                                                break;
                                            case "item_bomba.png":
                                                break;
                                            case "item_gokkusagi.png":
                                                break;
                                            case "item_helicopter.png":
                                                break;
                                            default:
                                                break;

                                        }
                                    }
                                    else if (jokers.Contains((pics[k - 1].Tag)))
                                    {
                                        switch (pics[k - 1].Tag)
                                        {

                                            case "item_dikey_roket.png":
                                                dikey_roket(k - 1);
                                                break;
                                            case "item_yatay_roket.png":
                                                var jok_result = yatay_roket(k - 1);
                                                done = jok_result.Item1;
                                                k = jok_result.Item2;
                                                break;
                                            case "item_bomba.png":
                                                break;
                                            case "item_gokkusagi.png":
                                                break;
                                            case "item_helicopter.png":
                                                break;
                                            default:
                                                break;

                                        }


                                    }
                                    else
                                    {
                                        Console.WriteLine("Dikey Kontrol Yok");
                                    }
                                }
                            }
                        }
                    }

                    //else
                    //{
                    //    changed = false;
                    //}
                }
                per_count = 0;
            }


            if (basechanged)
            {
                Console.WriteLine("BaseChanged");
                DeleteSugars();
            }
            return basechanged;
        }

        private (bool, int) yatay_roket(int i)
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
                if ((pics[j].AccessibleName == "NewLineUp") || (pics[j].AccessibleName == "End"))
                {
                    continue;
                }
                var result_CreateImage = CreateSugarImage();
                Image _Image = result_CreateImage.Item1;
                String _Tag = result_CreateImage.Item2;
                pics[j].BackgroundImage = _Image;
                pics[j].Tag = _Tag;
                new_i = j;
            }


            DeleteSugars();
            return (false, new_i);

        }

        private void dikey_roket(int i)
        {       // pics.Count() = 48;
            int start_of_dikey_rocket = (i % 8) + 1; // 4
            Console.WriteLine("Dikey Roket");
            for (int j = (i % 8) + 1; j < pics.Count(); j += 8)
            {
                if ((pics[j].AccessibleName == "NewLineUp") || (pics[j].AccessibleName == "End"))
                {
                    continue;
                }
                var result_CreateImage = CreateSugarImage();
                Image _Image = result_CreateImage.Item1;
                String _Tag = result_CreateImage.Item2;
                pics[j].BackgroundImage = _Image;
                pics[j].Tag = _Tag;

            }
            DeleteSugars();
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
            Console.WriteLine("CreateSugarImage");
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
