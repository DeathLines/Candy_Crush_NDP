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
        public string[] jokers = { "item_dikey_roket.png", "item_yatay_roket.png", "item_bomba.png", "item_gokkusagi.png", "item_helicopter.png" };
        private int per_count = 0;
        private int end_of_per = 0;
        private int start_of_per = 0;
        private bool done;
        //private bool changed = true;
        public PictureBox[] pics;
        public List<Joker> joker_list = new List<Joker>();
        public List<Joker> old_joker_list = new List<Joker>();




        private int firstx;
        private int firsty;
        private int lastx;
        private int lasty;

        public Game_Page()
        {
            this.lastx = 0;
            this.lasty = 0;


            Random random = new Random();
            //Seker1[] sekerler = new Seker1[36];                                                                           "item_bomba.png", "item_gokkusagi.png", "item_helicopter.png","item_dikey_roket.png"
            string[] imgs = { "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yatay_roket.png", "item_yatay_roket.png", "item_yatay_roket.png", "item_yatay_roket.png", "item_yatay_roket.png" };


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

            //@@ Şeker ve jokerlerin atanması
            for (int i = 0; i < pics.Count() - 1; i++)
            {
                int randomNumber = random.Next(0, 44);

                if (syntax.Contains(i))
                {
                    continue;
                }
                pics[i].BackgroundImage = Image.FromFile($"D:\\Yazilim\\C#\\NDP_Proje\\imgs\\{imgs[randomNumber]}");
                pics[i].Tag = imgs[randomNumber];
                pics[i].AccessibleDescription = create_key();
                pics[i].AllowDrop = true;
                //sekerler[i] = new Seker1(0, 0, "a");
                //sekerler[i].

            }

            //Seker1 ab = new Seker1(10, 5, "a");
            ////Console.WriteLine($"Seker1: x = {ab.x}, y = {ab.x}, type = {ab.type}");
            //pictureBox1.BackgroundImage 

            //@@ Başlangıçta oluşan şeker perlerinin yok edilmesi için.
            //DeleteSugars();

            //@@ Başlangıçta oluşan jokerlerin ilk değerlerinin atanması için.
            check_jokers("create");
            jokers_infos();



            //@@ Jokerlerin değerlerinin yazılması için. Silinebilir
            for (int i = 0; i < joker_list.Count(); i++)
            {
                if (joker_list[i] == null)
                {
                    break;
                }
                Console.WriteLine($"Key: {joker_list[i].key}\nUp: {joker_list[i].up}\nDown: {joker_list[i].down}\nRight: {joker_list[i].right}\nLeft: {joker_list[i].left}");
            }



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

        //@@ Jokerin çevre kontrol fonksiyonları
        private string check_up(int i)
        {
            if (i - 8 < 0)
            {
                return "End";
            }
            else
            {
                return pics[i - 8].AccessibleDescription.ToString();
            }
        }
        private string check_down(int i)
        {
            if (i + 8 > pics.Count())
            {
                return "End";
            }
            else
            {
                return pics[i + 8].AccessibleDescription.ToString();
            }
        }
        private string check_right(int i)
        {
            if (pics[i + 1].AccessibleName != null)
            {
                return "End";
            }
            else
            {
                return pics[i + 1].AccessibleDescription.ToString();
            }
        }

        private string check_left(int i)
        {
            if (pics[i - 1].AccessibleName != null)
            {
                return "End";
            }
            else

            {
                return pics[i - 1].AccessibleDescription.ToString();
            }
        }




        private void jokers_infos()
        {
            Console.WriteLine("\n\n_________________________________________\n Joker Infos\n\n\n");

            for (int j = 0; j < pics.Count(); j++)
            {
                for (int i = 0; i < joker_list.Count(); i++)
                {
                    if (joker_list[i] == null)
                    {
                        break;
                    }
                    if ((joker_list[i].key == pics[j].AccessibleDescription))
                    {
                        Console.WriteLine($"Joker İsmi: {pics[i].Tag}, Joker Key:{joker_list[i].key}, PictureBox_ID(i): {j}");
                        if (j - 8! < 0)
                            Console.WriteLine($"picbox.accdec: {pics[j].AccessibleDescription}\nJoker.Up: {joker_list[i].up}, picbox.upAccdec:{pics[j - 8].AccessibleDescription}, picbox.upTag: {pics[j - 8].Tag}\n");

                        if (j + 8! > 47) ;
                        Console.WriteLine($"picbox.accdec: {pics[j].AccessibleDescription}\nJoker.Down: {joker_list[i].down}, picbox.upAccdec:{pics[j + 8].AccessibleDescription}, picbox.upTag: {pics[j + 8].Tag}\n");
                        Console.WriteLine($"picbox.accdec: {pics[j].AccessibleDescription}\nJoker.Right: {joker_list[i].right}, picbox.upAccdec:{pics[j + 1].AccessibleDescription}, picbox.upTag: {pics[j + 1].Tag}\n");
                        Console.WriteLine($"picbox.accdec: {pics[j].AccessibleDescription}\nJoker.Left: {joker_list[i].left}, picbox.upAccdec:{pics[j - 1].AccessibleDescription}, picbox.upTag: {pics[j - 1].Tag}\n");
                    }
                }

            }
            Console.WriteLine("\n\n Joker Infos  @@@@@@@@@@@@@@@@@@@@@\n\n\n");
        }



        //@@ Joker kontrolü
        private (bool, int) check_jokers(string mode)
        {
            //joker_list.Clear();




            Console.WriteLine("Check_Jokers");


            //@@ Yeni oluşturulan jokerlerin ilk değerlerinin atanması
            if (mode == "create")
            {
                int joker_list_count = joker_list.Count();

                Console.WriteLine("Check_Jokers Mode: Create\n");
                for (int i = 0; i < pics.Count(); i++)
                {
                    // Liste boş ise hata almamak için
                    if (joker_list.Count() != 0)
                    {

                        for (int j = 0; j < joker_list_count; j++)
                        {
                            Console.WriteLine(jokers.Count());
                            if (jokers.Contains(pics[i].Tag) && joker_list[j].key != pics[i].AccessibleDescription)
                            {
                                Console.WriteLine("Check_Jokers if");
                                Console.WriteLine("jokers.Contains(pics[i].Tag): " + jokers.Contains(pics[i].Tag));
                                Console.WriteLine("joker_list[j].key: " + joker_list[j].key);
                                Console.WriteLine("pics[i].AccessibleDescription: " + pics[i].AccessibleDescription);
                                Console.WriteLine("joker_list[j].key != pics[i].AccessibleDescription: " + joker_list[j].key != pics[i].AccessibleDescription);
                                Joker joker = new Joker();
                                joker.up = check_up(i);
                                joker.down = check_down(i);
                                joker.right = check_right(i);
                                joker.left = check_left(i);
                                joker.key = pics[i].AccessibleDescription;
                                joker_list.Add(joker);

                            }
                        }
                    }
                    else
                    {
                        if (jokers.Contains(pics[i].Tag))
                        {
                            Console.WriteLine("Check_Jokers Else");
                            Console.WriteLine("jokers.Contains(pics[i].Tag): " + jokers.Contains(pics[i].Tag));
                            Console.WriteLine("pics[i].AccessibleDescription: " + pics[i].AccessibleDescription);
                            Joker joker = new Joker();
                            joker.up = check_up(i);
                            joker.down = check_down(i);
                            joker.right = check_right(i);
                            joker.left = check_left(i);
                            joker.key = pics[i].AccessibleDescription;
                            joker_list.Add(joker);

                        }
                    }
                }
            }
            //@@ Bir event olduktan sonra jokerlerin etrafındaki şekerlerin kontrolü
            else if (mode == "check")
            {
                Console.WriteLine("Check_Jokers Mode: check\n");
                for (int i = 0; i < pics.Count(); i++)
                {
                    if (i + 1 < pics.Count())
                    {
                        if (jokers.Contains(pics[i + 1].Tag))
                        {
                            Console.WriteLine("\n_SAĞDA TETİKLENDİ: " + pics[i + 1].Tag);
                            for (int l = 0; l < joker_list.Count(); l++)
                            {
                                if (pics[i + 1].AccessibleDescription == joker_list[l].key)
                                {
                                    if (pics[i + 1].AccessibleDescription != joker_list[l].right)
                                    {
                                        joker_list.RemoveAt(l);
                                        return activate_jokers(i + 1);

                                        //i = value.Item2;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    else if (i - 1 > 0)
                    {
                        if (jokers.Contains(pics[i - 1].Tag))
                        {
                            Console.WriteLine("\nSOLDA TETİKLENDİ: " + pics[i - 1].Tag);
                            for (int l = 0; l < joker_list.Count(); l++)
                            {
                                if (pics[i - 1].AccessibleDescription == joker_list[l].key)
                                {
                                    if (pics[i - 1].AccessibleDescription != joker_list[l].left)
                                    {
                                        joker_list.RemoveAt(l);
                                        return activate_jokers(i - 1);

                                        //i = value.Item2;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    if (i - 8 > 0)
                    {
                        if (jokers.Contains(pics[i - 8].Tag))
                        {
                            Console.WriteLine("\n@@@YUKARIDA TETİKLENDİ: " + pics[i - 8].Tag);
                            for (int l = 0; l < joker_list.Count(); l++)
                            {
                                if (pics[i - 8].AccessibleDescription == joker_list[l].key)
                                {
                                    if (pics[i - 8].AccessibleDescription != joker_list[l].up)
                                    {
                                        joker_list.RemoveAt(l);
                                        return activate_jokers(i - 8);

                                        //i = value.Item2;
                                        break;
                                    }
                                }
                            }

                        }
                    }
                    else if (i + 8 < 47)
                    {
                        if (jokers.Contains(pics[i + 8].Tag))
                        {
                            Console.WriteLine("\n@@@AŞAĞIDA TETİKLENDİ: " + pics[i + 8].Tag);
                            for (int l = 0; l < joker_list.Count(); l++)
                            {
                                if (pics[i + 8].AccessibleDescription == joker_list[l].key)
                                {
                                    if (pics[i + 8].AccessibleDescription != joker_list[l].down)
                                    {
                                        joker_list.RemoveAt(l);
                                        return activate_jokers(i + 8);

                                        //i = value.Item2;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return (false, 0);
        }

        //@@ İlgili Jokeri Aktif Eder
        private (bool, int) activate_jokers(int i)
        {

            switch (pics[i].Tag)
            {
                case "item_bomba.png":
                    break;
                case "item_dikey_roket.png":
                    break;
                case "item_yatay_roket.png":
                    Console.WriteLine("\n##Yatay Roket else ##\n");
                    var value = yatay_roket(i);
                    return (value.Item1, value.Item2);
                    break;
                case "item_gokkusagi.png":
                    break;
                case "item_helicopter.png":
                    break;
            }

            //Console.WriteLine("Activate_Jokers\n");
            //for (int i = 0; i < pics.Count(); i++)
            //{
            //    if (jokers.Contains(pics[i].Tag))
            //    {
            //        for (int j = 0; j < joker_list.Count(); j++)
            //        {
            //            if (pics[i].AccessibleDescription == joker_list[j].key)
            //            {
            //                Console.WriteLine("Joker Key: " + joker_list[j].key+ "          pics[i].AccessibleDescription: "+ pics[i].AccessibleDescription);
            //                if (i > 40)
            //                {
            //                    if ((pics[i-1].AccessibleDescription != joker_list[j].left) || (pics[i+1].AccessibleDescription != joker_list[j].right) || (pics[i-8].AccessibleDescription != joker_list[j].up))
            //                    {
            //                        switch (pics[i].Tag){
            //                            case "item_bomba.png":
            //                                break;
            //                            case "item_dikey_roket.png":
            //                                break;
            //                            case "item_yatay_roket.png":
            //                                Console.WriteLine("\n##Yatay Roket >40 ##\n");
            //                                var value = yatay_roket(i);
            //                                return (value.Item1, value.Item2);
            //                                break;
            //                            case "item_gokkusagi.png":
            //                                break;
            //                            case "item_helicopter.png":
            //                                break;
            //                        }
            //                    }
            //                }
            //                else if (i < 8)
            //                {
            //                    if ((pics[i - 1].AccessibleDescription != joker_list[j].left) || (pics[i + 1].AccessibleDescription != joker_list[j].right) || (pics[i + 8].AccessibleDescription != joker_list[j].down))
            //                    {
            //                        switch (pics[i].Tag)
            //                        {
            //                            case "item_bomba.png":
            //                                break;
            //                            case "item_dikey_roket.png":
            //                                break;
            //                            case "item_yatay_roket.png":
            //                                Console.WriteLine("\n##Yatay Roket <8 ##\n");
            //                                var value = yatay_roket(i);
            //                                return (value.Item1,value.Item2);
            //                                break;
            //                            case "item_gokkusagi.png":
            //                                break;
            //                            case "item_helicopter.png":
            //                                break;
            //                        }

            //                    }

            //                }
            //                else
            //                {
            //                    Console.WriteLine("3. SORGU ELSE");
            //                    if ((pics[i - 1].AccessibleDescription != joker_list[j].left) || (pics[i + 1].AccessibleDescription != joker_list[j].right) || (pics[i + 8].AccessibleDescription != joker_list[j].down) || (pics[i-8].AccessibleDescription != joker_list[j].up))
            //                    {
            //                        Console.WriteLine("SORGU İÇİ");
            //                        switch (pics[i].Tag)
            //                        {
            //                            case "item_bomba.png":
            //                                break;
            //                            case "item_dikey_roket.png":
            //                                break;
            //                            case "item_yatay_roket.png":
            //                                Console.WriteLine("\n##Yatay Roket else ##\n");
            //                                var value = yatay_roket(i);
            //                                return (value.Item1,value.Item2);
            //                                break;
            //                            case "item_gokkusagi.png":
            //                                break;
            //                            case "item_helicopter.png":
            //                                break;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        //Joker joker = new Joker();
            //        //joker.up = check_up(i);
            //        //joker.down = check_down(i);
            //        //joker.right = check_right(i);
            //        //joker.left = check_left(i);
            //        //joker.key = pics[i].AccessibleDescription;
            //        //joker_list.Add(joker);

            //    }
            //}
            Console.WriteLine("return: false,5");
            return (false, 5);
        }
        //active_jokers
        private string create_key()
        {
            Random random = new Random();
            string key = "";
            for (int i = 0; i < 10; i++)
            {
                key += random.Next(0, 9).ToString();
            }
            return key;
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
                            item.AccessibleDescription = picbox.AccessibleDescription;
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
                            item.AccessibleDescription = storagePicBox.AccessibleDescription;
                            //item.Location = storagePicBox.Location;
                            //item.Size = storagePicBox.Size;
                        }

                    }
                    select1 = 0;
                    select2 = 0;

                    // Yer değiştirme işlemi bitti 

                    DeleteSugars();
                    jokers_infos();
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
            jokers_infos();

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
                        //Console.WriteLine("\npercount: " + per_count);
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
                            //if (jokers.Contains(pics[i + 1].Tag) || jokers.Contains(pics[i - per_count].Tag))
                            //{
                            //    switch (pics[i + 1].Tag)
                            //    {
                            //        case "item_dikey_roket.png":
                            //            //Console.WriteLine("Dikey Roket");
                            //            dikey_roket(i);
                            //            break;
                            //        case "item_yatay_roket.png":
                            //            var jok_result = yatay_roket(i);
                            //            done = jok_result.Item1;
                            //            i = jok_result.Item2;
                            //            break;
                            //        case "item_bomba.png":
                            //            //Console.WriteLine("Bomba");
                            //            break;
                            //        case "item_gokkusagi.png":
                            //            //Console.WriteLine("Gökkuşağı");
                            //            break;
                            //        case "item_helicopter.png":
                            //            //Console.WriteLine("Helicopter");
                            //            break;

                            //        default:
                            //            break;
                            //    }
                            //    if ((i - per_count) > 0)
                            //    {
                            //        switch (pics[i - per_count].Tag)
                            //        {
                            //            case "item_dikey_roket.png":
                            //                //Console.WriteLine("Dikey Roket");
                            //                dikey_roket(i - per_count - 1);
                            //                break;
                            //            case "item_yatay_roket.png":
                            //                var jok_result = yatay_roket(i);
                            //                done = jok_result.Item1;
                            //                i = jok_result.Item2;
                            //                break;
                            //            case "item_bomba.png":
                            //                //Console.WriteLine("Bomba");
                            //                break;
                            //            case "item_gokkusagi.png":
                            //                //Console.WriteLine("Gökkuşağı");
                            //                break;
                            //            case "item_helicopter.png":
                            //                //Console.WriteLine("Helicopter");
                            //                break;

                            //            default:
                            //                break;
                            //        }
                            //    }
                            //}


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
                                pics[j].AccessibleDescription = create_key();
                                pics[j].BackgroundImage = _Image;
                                pics[j].Tag = _Tag;


                            }



                            if (jokers.Contains(pics[i + 1].Tag))
                            {
                                var value = check_jokers("check");
                                basechanged = value.Item1;

                                //Console.WriteLine("\n_SAĞDA TETİKLENDİ: " + pics[i + 1].Tag);
                                //for (int l = 0; l < joker_list.Count(); l++)
                                //{
                                //    if (pics[i + 1].AccessibleDescription == joker_list[l].key)
                                //    {
                                //        if (pics[i + 1].AccessibleDescription != joker_list[l].right)
                                //        {
                                //            joker_list.RemoveAt(l);
                                //            var value = activate_jokers(i + 1);
                                //            basechanged = value.Item1;
                                //            //i = value.Item2;
                                //            break;
                                //        }
                                //    }
                                //}
                            }
                            else if (jokers.Contains(pics[i - per_count].Tag))
                            {
                                var value = check_jokers("check");
                                basechanged = value.Item1;
                                //Console.WriteLine("\nSOLDA TETİKLENDİ: " + pics[i - per_count].Tag);
                                //for (int l = 0; l < joker_list.Count(); l++)
                                //{
                                //    if (pics[i - per_count].AccessibleDescription == joker_list[l].key)
                                //    {
                                //        if (pics[i - per_count].AccessibleDescription != joker_list[l].left)
                                //        {
                                //            joker_list.RemoveAt(l);
                                //            var value = activate_jokers(i - per_count);
                                //            basechanged = value.Item1;
                                //            //i = value.Item2;
                                //            break;
                                //        }
                                //    }
                                //}
                            }
                            else
                            if (i - 8 > 0)
                            {
                                if (jokers.Contains(pics[i - 8].Tag))
                                {

                                    var value = check_jokers("check");
                                    basechanged = value.Item1;
                                    //Console.WriteLine("\nAŞAĞIDA TETİKLENDİ: " + pics[i - 8].Tag);
                                    //for (int l = 0; l < joker_list.Count(); l++)
                                    //{
                                    //    if (pics[i - 8].AccessibleDescription == joker_list[l].key)
                                    //    {
                                    //        if (pics[i - 8].AccessibleDescription != joker_list[l].up)
                                    //        {
                                    //            joker_list.RemoveAt(l);
                                    //            var value = activate_jokers(i - 8);
                                    //            basechanged = value.Item1;
                                    //            //i = value.Item2;
                                    //            break;
                                    //        }
                                    //    }
                                    //}

                                }
                            }
                            else if (i + 8 < 47)
                            {
                                if (jokers.Contains(pics[i + 8].Tag))
                                {
                                    var value = check_jokers("check");
                                    basechanged = value.Item1;
                                    //Console.WriteLine("\nYUKARIDA TETİKLENDİ: " + pics[i + 8].Tag);
                                    //for (int l = 0; l < joker_list.Count(); l++)
                                    //{
                                    //    if (pics[i + 8].AccessibleDescription == joker_list[l].key)
                                    //    {
                                    //        if (pics[i + 8].AccessibleDescription != joker_list[l].down)
                                    //        {
                                    //            joker_list.RemoveAt(l);
                                    //            var value = activate_jokers(i + 8);
                                    //            basechanged = value.Item1;
                                    //            //i = value.Item2;
                                    //            break;
                                    //        }
                                    //    }
                                    //}
                                }
                            }

                            //if (jokers.Contains(pics[i + 1].Tag) || jokers.Contains(pics[i - per_count].Tag) || jokers.Contains(pics[i + 8].Tag) || jokers.Contains(pics[i - 8].Tag))
                            //{
                            //    var value = activate_jokers(i);
                            //    done = value.Item1; // false
                            //    //i = value.Item2;
                            //    basechanged = true;
                            //}

                            //Eğer silindiyse

                        }

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
                                pics[k].AccessibleDescription = create_key();
                                pics[k].BackgroundImage = _Image;
                                pics[k].Tag = _Tag;
                            }
                        }
                    }
                    //else
                    //{
                    //    changed = false;
                    //}
                }
            }
            jokers_infos();
            //if (basechanged)
            //{
            //    Console.WriteLine("\nbasechanged\n");
            //    check_jokers("check");
            //    DeleteSugars();
            //}
            return basechanged;
        }

        private (bool, int) yatay_roket(int i)
        {
            int new_i = 0;
            //Console.WriteLine("Yatay Roket");
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
                pics[j].AccessibleDescription = create_key();
                pics[j].BackgroundImage = _Image;
                pics[j].Tag = _Tag;
                new_i = j;
            }

            return (true, new_i);

        }

        private void dikey_roket(int i)
        {       // pics.Count() = 48;
            int start_of_dikey_rocket = (i % 8) + 1; // 4
            //Console.WriteLine("Dikey Roket");
            for (int j = (i % 8) + 1; j < pics.Count(); j += 8)
            {
                if ((pics[j].AccessibleName == "NewLineUp") || (pics[j].AccessibleName == "End"))
                {
                    continue;
                }
                var result_CreateImage = CreateSugarImage();
                Image _Image = result_CreateImage.Item1;
                String _Tag = result_CreateImage.Item2;
                pics[j].AccessibleDescription = create_key();
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
            Random random = new Random();
            string[] imgs = { "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_mavi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_kirmizi.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_sari.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_yesil.png", "item_dikey_roket.png", "item_yatay_roket.png", "item_bomba.png", "item_gokkusagi.png", "item_helicopter.png" };
            int randomNumber = random.Next(0, 44);
            return (Image.FromFile($"D:\\Yazilim\\C#\\NDP_Proje\\imgs\\{imgs[randomNumber]}"), imgs[randomNumber]);

        }




        public class Joker
        {
            public string key
            {
                set; get;

            }
            public string up { set; get; }
            public string down { set; get; }
            public string right { set; get; }
            public string left { set; get; }


            public Joker(string key = "defaultKey", string up = "defaultUp", string down = "defaultDown", string right = "defaultRight", string left = "defaultLeft")
            {
                this.key = key;
                this.up = up;
                this.down = down;
                this.right = right;
                this.left = left;
            }

        }






        //public class Seker1
        //{
        //    public int x;
        //    public int y;
        //    public string type;


        //    public Seker1(int x, int y, string type)
        //    {
        //        this.x = x;
        //        this.y = y;
        //        this.type = type;
        //    }

        //}





        //public class CustomPictureBox : PictureBox
        //{




        
        //    // Yukarı, aşağı, sağ ve sol hareket özellikleri
        //    protected int Up { get; set; }
        //    protected int Down { get; set; }
        //    protected int Right { get; set; }
        //    protected int Left { get; set; }

        //    // Key özelliği, tuşları yakalamak için
        //    protected bool Key { get; set; }

        //    // Constructor
        //    public CustomPictureBox()
        //    {
        //        // Başlangıçta her bir hareket özelliğini sıfırlıyoruz
        //        Up = 0;
        //        Down = 0;
        //        Right = 0;
        //        Left = 0;
        //        Key = false;

        //    }



        //}




    }
}


