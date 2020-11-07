using System;

namespace bài_1
{
    abstract class Nhanvien
    {
        private string Hoten, Diachi;
        private DateTime NgaySinh;
        public Nhanvien()
        {
            Hoten = Diachi = " ";
            NgaySinh = DateTime.Now;
        }
        public Nhanvien(String Hoten,string Diachi,DateTime NgaySinh)
        {
            this.Hoten = Hoten;
            this.Diachi = Diachi;
            this.NgaySinh = NgaySinh;
        }
        public virtual void nhap()
        {
            Console.Write("nhap ho ten :"); Hoten = Console.ReadLine();
            Console.Write("nhap Dia chi :"); Diachi = Console.ReadLine();
            Console.Write("nhap ngay sinh:");NgaySinh = DateTime.Parse(Console.ReadLine());
        }
        public virtual void hien()
        {
            Console.WriteLine("thong tin nhan vien .........<<<<>>>>");
            Console.WriteLine("{0}\t{1}\t{2}",Hoten, Diachi, NgaySinh);
        }
        public abstract double Tinhluong();
    }
    class NVSX : Nhanvien
    {
        private int ssp;
        public NVSX() : base() { ssp = 0; }
        public NVSX(string Hoten, string Diachi, DateTime NgaySinh, int ssp) : base(Hoten, Diachi, NgaySinh) { this.ssp = ssp; }
        public override void nhap()
        {
            base.nhap();
            Console.Write("nhap so san pham :");ssp = int.Parse(Console.ReadLine());
        }
        public override void hien()
        {
            base.hien();
            Console.WriteLine("so san pham : {0}", ssp);
            Console.WriteLine("luong :", Tinhluong());
        }
        public override double Tinhluong()
        {
            return ssp * 20000;
        }
    }
    class NVCN : Nhanvien
    {
        private int songaycong;
        public NVCN() : base() { songaycong = 0; }
        public NVCN(string Hoten, string Diachi, DateTime NgaySinh, int songaycong) : base(Hoten, Diachi, NgaySinh) { this.songaycong = songaycong; }
        public override void nhap()
        {
            base.nhap();
            Console.Write("nhap so ngay cong :"); songaycong = int.Parse(Console.ReadLine());
        }
        public override void hien()
        {
            base.hien();
            Console.WriteLine("so ngay cong " + songaycong);
            Console.WriteLine("luong :" + Tinhluong());
        }
        public override double Tinhluong()
        {
            return songaycong * 50000;
        }
    }
    class NVQL : Nhanvien
    {
        private double hesoluong;
        public static int luongcoban = 1080;
        public NVQL() : base() { hesoluong = 2.34; }
        public NVQL(string Hoten, string Diachi, DateTime NgaySinh, double hesoluong) : base(Hoten, Diachi, NgaySinh) { this.hesoluong = hesoluong; }
        public static int Luongcoban
        {
            get { return luongcoban; }
            set
            {
                if (value > 1050) luongcoban = value;
            }
        }
        public override void nhap()
        {
            base.nhap();
            Console.Write("nhap he so luong :");hesoluong = double.Parse(Console.ReadLine());
        }
        public override void hien()
        {
            base.hien();
            Console.WriteLine("he so luong " + hesoluong);
            Console.WriteLine("luong :" + Tinhluong());
        }
        public override double Tinhluong()
        {
            return hesoluong + luongcoban;
        }
        class QuanLy
        {
            private Nhanvien[] ds;
            private int snv;
            public void Nhap()
            {
                Console.Write("Nhap so nhan vien:");
                snv = int.Parse(Console.ReadLine());
                ds = new Nhanvien[snv];
                for (int i = 0; i < snv; ++i)
                {
                    Console.Write("Ban muon nhap thong tin cho nhan vien quan ly(1), cong nhat(2), san xuat(3)");
                    char ch = char.Parse(Console.ReadLine());
                    switch (char.ToUpper(ch))
                    {
                        case '1': ds[i] = new NVQL(); ds[i].nhap(); break;
                        case '2': ds[i] = new NVCN(); ds[i].nhap(); break;
                        case '3': ds[i] = new NVSX(); ds[i].nhap(); break;
                    }
                }
            }
            public void Hien()
            {
                for (int i = 0; i < snv; ++i)
                    ds[i].hien();
            }
        }
        class App
        {
            static void Main()
            {
                QuanLy t = new QuanLy();
                t.Nhap();
                t.Hien();
                Console.ReadKey();
            }
        }
    }    
}
