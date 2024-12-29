using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace NDP_Proje
{



    public partial class Game_Page : Form
    {
        private Main_Page.player player;
        private string username = "";
        private int point = 0;
        private PictureBox storagePicBox = new PictureBox();  // İlk seçilen şekerin bilgilerini tutmak için kullanıldı.
        private int select1, select2;                         // select1 : ilk seçilen şekerin kontrolü, select2: ikinci seçilen şekerin kontrolü
        private int per_count = 0;
        private int end_of_per = 0;
        private int start_of_per = 0;
        public int[] syntax = { 0, 7, 8, 15, 16, 23, 24, 31, 32, 39, 40, 47 };
        private int time = 60;
        private bool first_start = true;
        private string[] colors = { "item_mavi.png", "item_kirmizi.png", "item_sari.png", "item_yesil.png" };
        //private bool changed = true;
        private PictureBox[] pics;
        string[] imgs = { "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_dikey_roket.png", "item_yatay_roket.png", "item_bomba.png", "item_gokkusagi.png", "item_helicopter.png" };

        public Game_Page(Main_Page.player player)
        {


            Random random = new Random();
            this.player = player;


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


            for (int i = 0; i < pics.Count() - 1; i++)
            {
                int randomNumber = random.Next(0, 85);

                if (syntax.Contains(i))
                {
                    continue;
                }
                pics[i].BackgroundImage = Image.FromFile($"D:\\Yazilim\\C#\\NDP_Proje\\imgs\\{imgs[randomNumber]}");
                pics[i].Tag = imgs[randomNumber];
                pics[i].AllowDrop = true;


            }

            DeleteSugars();
            player.Point = 0;
            Console.WriteLine("Point: " + player.Point);
            Console.WriteLine("\n\n\n##$$½½\n");

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            //Thread.Sleep(100);
        }


        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Timer animationTimer1;
        private PictureBox firstPic, secondPic;
        private int animationStep = 0;
        private void SugarMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                PictureBox picbox = (PictureBox)sender;

                if (select1 == 0)
                {
                    if (first_start)
                    {
                        player.Point = 0;
                        first_start = false;
                    }
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
                            item.BackgroundImage = picbox.BackgroundImage;
                            item.Tag = picbox.Tag;
                        }
                    }
                    foreach (var item in pics)
                    {
                        if (item.Name == picbox.Name)
                        {
                            item.BackgroundImage = storagePicBox.BackgroundImage;
                            item.Tag = storagePicBox.Tag;
                        }

                    }
                    select1 = 0;
                    select2 = 0;

                    // Yer değiştirme işlemi bitti 

                    StartDeleteAnimation();
                    Console.WriteLine("Point: " + player.Point);
                    //label1.Text = player.Point.ToString();
                    Console.WriteLine("____________________________________________\n");
                    //check_changes();
                    //Thread.Sleep(500);



                }
            }
            //Console.WriteLine("$$$$$MOUSE__DOWN$$$$");

        }


        System.Windows.Forms.Timer deleteTimer;

        private void StartDeleteAnimation()
        {
            deleteTimer = new System.Windows.Forms.Timer();
            deleteTimer.Interval = 1; // Her adım için 300ms
            deleteTimer.Tick += DeleteAnimationStep;
            deleteTimer.Start();
        }

        private void DeleteAnimationStep(object sender, EventArgs e)
        {


            if (first_start)
            {
                player.Point = 0;
                first_start = false;
            }
            label1.Text = player.Point.ToString();
            DeleteSugars();
            deleteTimer.Stop();
            deleteTimer.Dispose();
        }




        private bool DeleteSugars()
        {

            //Console.WriteLine("DeleteSugars");
            bool basechanged = false;
            string[] jokers = { "item_dikey_roket.png", "item_yatay_roket.png", "item_bomba.png", "item_gokkusagi.png", "item_helicopter.png" };

            // YATAY YOK EDİŞ
            for (int i = 0; i < pics.Count() - 1; i++)  // Bütün satırları gez
            {

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
                                        player.Point += 30;
                                        break;
                                    case "item_yatay_roket.png":
                                        Console.WriteLine("\nYattart?????");
                                        var jok_result = yatay_roket(i);
                                        player.Point += 30;
                                        i = jok_result.Item2;
                                        break;
                                    case "item_bomba.png":
                                        bomba(i + 1);
                                        player.Point += 40;
                                        //Console.WriteLine("Bomba");
                                        break;
                                    case "item_gokkusagi.png":
                                        player.Point += 5 * gokkusagi(i + 1);
                                        break;
                                    case "item_helicopter.png":
                                        //Console.WriteLine("Helicopter");
                                        kopter(i + 1);
                                        player.Point += 5;
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
                                            dikey_roket(i - per_count);
                                            player.Point += 30;
                                            break;
                                        case "item_yatay_roket.png":
                                            var jok_result = yatay_roket(i);
                                            player.Point += 30;
                                            i = jok_result.Item2;
                                            break;
                                        case "item_bomba.png":
                                            bomba(i - per_count);
                                            player.Point += 40;
                                            //Console.WriteLine("Bomba");
                                            break;
                                        case "item_gokkusagi.png":
                                            player.Point += 5 * gokkusagi(i - per_count);
                                            break;
                                        case "item_helicopter.png":
                                            //Console.WriteLine("Helicopter");
                                            kopter(i - per_count);
                                            player.Point += 5;
                                            break;

                                        default:
                                            break;
                                    }
                                }
                            }

                            player.Point += per_count * 5;
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
                    }
                }
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
                                    if (jokers.Contains((pics[k + 8].Tag)))
                                    {
                                        Console.WriteLine("|||Dikey Kontrol|||");
                                        switch (pics[k + 8].Tag)
                                        {
                                            case "item_dikey_roket.png":
                                                dikey_roket(k + 8);
                                                player.Point += 30;
                                                break;
                                            case "item_yatay_roket.png":
                                                var jok_result = yatay_roket(k + 8);
                                                player.Point += 30;
                                                k = jok_result.Item2;
                                                break;
                                            case "item_bomba.png":
                                                bomba(k + 8);
                                                player.Point += 40;
                                                break;
                                            case "item_gokkusagi.png":
                                                player.Point += 5 * gokkusagi(k + 8);
                                                break;
                                            case "item_helicopter.png":
                                                kopter(k + 8);
                                                player.Point += 5;
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
                                                player.Point += 30;
                                                break;
                                            case "item_yatay_roket.png":
                                                var jok_result = yatay_roket(k - 8);
                                                player.Point += 30;
                                                k = jok_result.Item2;
                                                break;
                                            case "item_bomba.png":
                                                bomba(k - 8);
                                                player.Point += 40;
                                                break;
                                            case "item_gokkusagi.png":
                                                player.Point += 5 * gokkusagi(k - 8);
                                                break;
                                            case "item_helicopter.png":
                                                kopter(k - 8);
                                                player.Point += 5;
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
                                                player.Point += 30;
                                                break;
                                            case "item_yatay_roket.png":
                                                var jok_result = yatay_roket(k + 1);
                                                player.Point += 30;
                                                k = jok_result.Item2;
                                                break;
                                            case "item_bomba.png":
                                                bomba(k + 1);
                                                player.Point += 40;
                                                break;
                                            case "item_gokkusagi.png":
                                                player.Point += 5 * gokkusagi(k + 1);
                                                break;
                                            case "item_helicopter.png":
                                                kopter(k + 1);
                                                player.Point += 5;
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
                                                player.Point += 30;
                                                break;
                                            case "item_yatay_roket.png":
                                                var jok_result = yatay_roket(k - 1);
                                                player.Point += 30;
                                                k = jok_result.Item2;
                                                break;
                                            case "item_bomba.png":
                                                bomba(k - 1);
                                                player.Point += 40;
                                                break;
                                            case "item_gokkusagi.png":
                                                player.Point += 5 * gokkusagi(k - 1);
                                                break;
                                            case "item_helicopter.png":
                                                kopter(k - 1);
                                                player.Point += 5;
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

                            player.Point += (per_count / 8) * 5;



                        }
                    }
                }
                per_count = 0;
            }


            if (basechanged)
            {
                Console.WriteLine("BaseChanged");
                StartDeleteAnimation();
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


            Thread.Sleep(1000);
            StartDeleteAnimation();
            return (false, new_i);

        }

        private void dikey_roket(int i)
        {       // pics.Count() = 48;
            int start_of_dikey_rocket = (i % 8) + 1; // 4
            Console.WriteLine("Dikey Roket");
            for (int j = (i % 8); j < pics.Count(); j += 8)
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
            Thread.Sleep(1000);
            StartDeleteAnimation();
        }


        private void bomba(int i)
        {

            Console.WriteLine("Bomba");
            if (syntax.Contains(i - 1) && i - 8 < 0)
            {
                var result_CreateImage = CreateSugarImage();

                Image _Image = result_CreateImage.Item1;
                String _Tag = result_CreateImage.Item2;
                pics[i].BackgroundImage = _Image;
                pics[i].Tag = _Tag;


                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 8].BackgroundImage = _Image;
                pics[i + 8].Tag = _Tag;


                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 1].BackgroundImage = _Image;
                pics[i + 1].Tag = _Tag;


                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 9].BackgroundImage = _Image;
                pics[i + 9].Tag = _Tag;

            }
            else if (syntax.Contains(i - 1) && i + 8 < 47)
            {
                var result_CreateImage = CreateSugarImage();

                Image _Image = result_CreateImage.Item1;
                String _Tag = result_CreateImage.Item2;
                pics[i].BackgroundImage = _Image;
                pics[i].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 8].BackgroundImage = _Image;
                pics[i + 8].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 8].BackgroundImage = _Image;
                pics[i - 8].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 7].BackgroundImage = _Image;
                pics[i - 7].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 1].BackgroundImage = _Image;
                pics[i + 1].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 9].BackgroundImage = _Image;
                pics[i + 9].Tag = _Tag;
            }
            else if (syntax.Contains(i + 1) && i - 8 < 0)
            {
                var result_CreateImage = CreateSugarImage();

                Image _Image = result_CreateImage.Item1;
                String _Tag = result_CreateImage.Item2;
                pics[i].BackgroundImage = _Image;
                pics[i].Tag = _Tag;

                result_CreateImage = CreateSugarImage();

                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 1].BackgroundImage = _Image;
                pics[i - 1].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 7].BackgroundImage = _Image;
                pics[i + 7].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 8].BackgroundImage = _Image;
                pics[i + 8].Tag = _Tag;
            }
            else if (syntax.Contains(i + 1))
            {
                var result_CreateImage = CreateSugarImage();

                Image _Image = result_CreateImage.Item1;
                String _Tag = result_CreateImage.Item2;
                pics[i].BackgroundImage = _Image;
                pics[i].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 8].BackgroundImage = _Image;
                pics[i - 8].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 9].BackgroundImage = _Image;
                pics[i - 9].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 1].BackgroundImage = _Image;
                pics[i - 1].Tag = _Tag;

            }
            else if (syntax.Contains(i - 1) && i + 8 > 47)
            {
                var result_CreateImage = CreateSugarImage();
                Image _Image = result_CreateImage.Item1;
                String _Tag = result_CreateImage.Item2;
                pics[i].BackgroundImage = _Image;
                pics[i].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 8].BackgroundImage = _Image;
                pics[i - 8].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 7].BackgroundImage = _Image;
                pics[i - 7].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 1].BackgroundImage = _Image;
                pics[i + 1].Tag = _Tag;
            }
            else if (syntax.Contains(i + 1) && i + 8 > 47)
            {
                var result_CreateImage = CreateSugarImage();

                Image _Image = result_CreateImage.Item1;
                String _Tag = result_CreateImage.Item2;
                pics[i].BackgroundImage = _Image;
                pics[i].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 8].BackgroundImage = _Image;
                pics[i - 8].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 9].BackgroundImage = _Image;
                pics[i - 9].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 1].BackgroundImage = _Image;
                pics[i - 1].Tag = _Tag;
            }
            else if (i + 8 > 47)
            {
                var result_CreateImage = CreateSugarImage();

                Image _Image = result_CreateImage.Item1;
                String _Tag = result_CreateImage.Item2;
                pics[i].BackgroundImage = _Image;
                pics[i].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 8].BackgroundImage = _Image;
                pics[i - 8].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 9].BackgroundImage = _Image;
                pics[i - 9].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 1].BackgroundImage = _Image;
                pics[i - 1].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 7].BackgroundImage = _Image;
                pics[i - 7].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 1].BackgroundImage = _Image;
                pics[i + 1].Tag = _Tag;
            }
            else if (i - 8 < 0)
            {
                var result_CreateImage = CreateSugarImage();

                Image _Image = result_CreateImage.Item1;
                String _Tag = result_CreateImage.Item2;
                pics[i].BackgroundImage = _Image;
                pics[i].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 1].BackgroundImage = _Image;
                pics[i - 1].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 1].BackgroundImage = _Image;
                pics[i + 1].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 7].BackgroundImage = _Image;
                pics[i + 7].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 8].BackgroundImage = _Image;
                pics[i + 8].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 9].BackgroundImage = _Image;
                pics[i + 9].Tag = _Tag;
            }
            else
            {
                var result_CreateImage = CreateSugarImage();

                Image _Image = result_CreateImage.Item1;
                String _Tag = result_CreateImage.Item2;
                pics[i].BackgroundImage = _Image;
                pics[i].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 8].BackgroundImage = _Image;
                pics[i - 8].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 9].BackgroundImage = _Image;
                pics[i - 9].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 1].BackgroundImage = _Image;
                pics[i - 1].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i - 7].BackgroundImage = _Image;
                pics[i - 7].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 1].BackgroundImage = _Image;
                pics[i + 1].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 7].BackgroundImage = _Image;
                pics[i + 7].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 8].BackgroundImage = _Image;
                pics[i + 8].Tag = _Tag;

                result_CreateImage = CreateSugarImage();
                _Image = result_CreateImage.Item1;
                _Tag = result_CreateImage.Item2;
                pics[i + 9].BackgroundImage = _Image;
                pics[i + 9].Tag = _Tag;

            }
            Thread.Sleep(1000);
            StartDeleteAnimation();

        }


        private int gokkusagi(int i)
        {
            Console.WriteLine("Gökkuşağı");
            Random random = new Random();

            var result_CreateImage = CreateSugarImage();
            Image _Image = result_CreateImage.Item1;  /* Image.FromFile("D:\\Yazilim\\C#\\NDP_Proje\\imgs\\deleted.png")*/
            String _Tag = result_CreateImage.Item2;
            pics[i].BackgroundImage = _Image;
            pics[i].Tag = _Tag;

            int num = 0;
            int _random = random.Next(0, 4);
            Console.WriteLine("\n\nSilinen RENK:" + _random);

            for (int j = 0; j < pics.Count(); j++)
            {
                if (pics[j].Tag == colors[_random])
                {
                    num++;
                    result_CreateImage = CreateSugarImage();
                    _Image = result_CreateImage.Item1;  /* Image.FromFile("D:\\Yazilim\\C#\\NDP_Proje\\imgs\\deleted.png")*/
                    _Tag = result_CreateImage.Item2;
                    pics[j].BackgroundImage = _Image;
                    pics[j].Tag = _Tag;
                }
            }
            Thread.Sleep(1000);
            StartDeleteAnimation();
            return num;

        }



        private void kopter(int i)
        {
            Console.WriteLine("Kopter");
            Random random = new Random();
            int _random = random.Next(0, 47);
            if (syntax.Contains(_random))
            {
                kopter(i);


            }
            else
            {
                var result_CreateImage = CreateSugarImage();
                Image _Image = result_CreateImage.Item1;  /*Image.FromFile("D:\\Yazilim\\C#\\NDP_Proje\\imgs\\deleted.png");*/
                String _Tag = result_CreateImage.Item2;
                pics[_random].BackgroundImage = _Image;
                pics[_random].Tag = _Tag;
                pics[i].BackgroundImage = _Image;
                pics[i].Tag = _Tag;
            }
            Thread.Sleep(1000);
            StartDeleteAnimation();
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

            int randomNumber = random.Next(0, 85);
            return (Image.FromFile($"D:\\Yazilim\\C#\\NDP_Proje\\imgs\\{imgs[randomNumber]}"), imgs[randomNumber]);

        }

        private List<string> users = new List<string>();
        private List<int> user_points = new List<int>();
        private List<string> ordered_user = new List<string>();
        private List<int> ordered_points = new List<int>();

        private void update_Data()
        {
            Console.WriteLine("\n\n### Update_data");
            Console.WriteLine("Username: " + player.Username + "  Point: " + player.Point);
            int a = 0;
            int satir_sayisi = 0;
            string dosyaYolu = "D:\\Yazilim\\C#\\NDP_Proje\\Data.txt";

            // Dosyayı satır satır okuma
            using (StreamReader sr = new StreamReader(dosyaYolu))
            {
                string satir;
                bool placed  = false;

                //player.Point = 10000;
                while ((satir = sr.ReadLine()) != null)
                {
                    Console.WriteLine("\nWhile İçi");
                    satir_sayisi++;
                    Console.WriteLine("satir.lenght:" + satir.Length);

                    // Satırda veri kontrolü
                    if (satir.Length > 2)
                    {
                        string[] data = satir.Split('.');
                        string username = data[1];
                        int point = Convert.ToInt32(data[2]);
                        users.Add(username);
                        user_points.Add(point);
                        Console.WriteLine(data);
                    }
                }

                // Sıralama işlemi
                for (int i = 0; i < users.Count(); i++)
                {
                    Console.WriteLine("\n@@@@ Sıralama İşlemi");
                    // Eski user puanı şuanki puandan küçükse
                    if (user_points[i] < player.Point)
                    {
                        ordered_user.Add(player.Username);
                        ordered_points.Add(player.Point);

                        // Listenin geri kalanını yükle
                        for (int j = i + 1; j < users.Count() +1; j++)
                        {
                            Console.WriteLine("\n Geri Kalanı yükleme İşlemi");
                            ordered_user.Add(users[i]);
                            ordered_points.Add(user_points[i]);
                            i++;
                        }

                        placed = true;
                    }

                    else
                    {
                        ordered_user.Add(users[i]);
                        ordered_points.Add(user_points[i]);
                    }


                }

                if (!placed && satir_sayisi < 5)
                {
                    ordered_user.Add(player.Username);
                    ordered_points.Add(player.Point);
                }

            }


            using (StreamWriter sr = new StreamWriter(dosyaYolu))
            {
                for (int i = 0; i < ordered_user.Count(); i++)
                {
                    sr.WriteLine($"{i + 1}.{ordered_user[i]}.{ordered_points[i]}");
                }

            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = time.ToString();
            if (time == 0)
            {
                update_Data();
                timer1.Stop();
                MessageBox.Show("Süreniz doldu. Oyun bitti.");
                this.Close();
            }
            time--;
        }


    }


}
