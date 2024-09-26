using System;
using System.Collections.Generic;

namespace praktikum_polymorphism
{
    // Kelas Hewan
    public class Hewan
    {
        public string Nama { get; set; }
        public int Umur { get; set; }

        public Hewan(string nama, int umur)
        {
            Nama = nama;
            Umur = umur;
        }

        public virtual string Suara()
        {
            return "Hewan ini bersuara";
        }

        public virtual string InfoHewan()
        {
            return $"Nama: {Nama}, Umur: {Umur} tahun";
        }

        public virtual void Info()
        {
            Console.WriteLine(InfoHewan());
            Console.WriteLine(Suara());
        }
    }

    // Kelas Mamalia yang mewarisi Hewan
    public class Mamalia : Hewan
    {
        public int JumlahKaki { get; set; }

        public Mamalia(string nama, int umur, int jumlahKaki) : base(nama, umur)
        {
            JumlahKaki = jumlahKaki;
        }

        public override string InfoHewan()
        {
            return base.InfoHewan() + $", Jumlah Kaki: {JumlahKaki}";
        }
    }

    // Kelas Reptil yang mewarisi Hewan
    public class Reptil : Hewan
    {
        public double PanjangTubuh { get; set; }

        public Reptil(string nama, int umur, double panjangTubuh) : base(nama, umur)
        {
            PanjangTubuh = panjangTubuh;
        }

        public override string InfoHewan()
        {
            return base.InfoHewan() + $", Panjang Tubuh: {PanjangTubuh} meter";
        }
    }

    // Kelas Singa yang mewarisi Mamalia
    public class Singa : Mamalia
    {
        public Singa(string nama, int umur) : base(nama, umur, 4) { }

        public override string Suara()
        {
            return "Singa mengaum";
        }

        public void Mengaum()
        {
            Console.WriteLine("Singa sedang mengaum: ROARRR!!");
        }

        public override void Info()
        {
            Console.WriteLine("Singa:");
            base.Info();
        }
    }

    // Kelas Gajah yang mewarisi Mamalia
    public class Gajah : Mamalia
    {
        public Gajah(string nama, int umur) : base(nama, umur, 4) { }

        public override string Suara()
        {
            return "Gajah mengeluarkan suara terompet";
        }

        public override void Info()
        {
            Console.WriteLine("Gajah:");
            base.Info();
        }
    }

    // Kelas Ular yang mewarisi Reptil
    public class Ular : Reptil
    {
        public Ular(string nama, int umur, double panjangTubuh) : base(nama, umur, panjangTubuh) { }

        public override string Suara()
        {
            return "Ular mendesis";
        }

        public void Merayap()
        {
            Console.WriteLine("Ular sedang merayap...");
        }

        public override void Info()
        {
            Console.WriteLine("Ular:");
            base.Info();
        }
    }

    // Kelas Buaya yang mewarisi Reptil
    public class Buaya : Reptil
    {
        public Buaya(string nama, int umur, double panjangTubuh) : base(nama, umur, panjangTubuh) { }

        public override string Suara()
        {
            return "Buaya menggeram";
        }

        public override void Info()
        {
            Console.WriteLine("Buaya:");
            base.Info();
        }
    }

    // Kelas KebunBinatang
    public class KebunBinatang
    {
        private List<Hewan> KoleksiHewan;

        public KebunBinatang()
        {
            KoleksiHewan = new List<Hewan>();
        }

        public void TambahHewan(Hewan hewan)
        {
            KoleksiHewan.Add(hewan);
        }

        public void DaftarHewan()
        {
            foreach (var hewan in KoleksiHewan)
            {
                hewan.Info();
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Membuat objek KebunBinatang
            KebunBinatang kebunBinatang = new KebunBinatang();

            // Membuat beberapa objek dari berbagai jenis hewan
            Singa singa = new Singa("Aurora", 5);
            Gajah gajah = new Gajah("Elle", 10);
            Ular ular = new Ular("Garaga", 3, 4.5);
            Buaya buaya = new Buaya("Crocodylus", 7, 5.0);

            // Menambahkan hewan-hewan ke kebun binatang
            kebunBinatang.TambahHewan(singa);
            kebunBinatang.TambahHewan(gajah);
            kebunBinatang.TambahHewan(ular);
            kebunBinatang.TambahHewan(buaya);

            Console.WriteLine("Daftar Hewan di Kebun Binatang:");
            Console.WriteLine();
            kebunBinatang.DaftarHewan();

            // Penggunaan polymorphism dengan memanggil method Suara()
            Console.WriteLine("Implementasi Polymorphism :");
            Hewan[] beberapaHewan = { singa, gajah, ular, buaya };
            foreach (var hewan in beberapaHewan)
            {
                Console.WriteLine($"{hewan.Nama}: {hewan.Suara()}");
            }

            Console.WriteLine("\nPrint Method Khusus :");
            singa.Mengaum();
            ular.Merayap();
        }
    }
}

