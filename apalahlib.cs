using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stop; //Ini merupakan implementasi library class

namespace apalahlib // Implementasi namespace
{
    // Class Kendaraan yang akan digunakan untuk membuat objek kendaraan.
    public class Kendaraan : UnexpectedStop
    {
        public string Nama { get; set; }
        public int Kecepatan { get; set; }
        public string Jenis { get; set; }

        // Constructor untuk menginisialisasi atribut Nama, Kecepatan, dan Jenis.
        public Kendaraan(string nama, int kecepatan, string jenis)
        {
            Nama = nama;
            Kecepatan = kecepatan;
            Jenis = jenis;
        }

        // Method Bergerak untuk menampilkan informasi pergerakan kendaraan.
        public void Bergerak()
        {
            if (Kecepatan <= 0)
            {
                Console.WriteLine($"{Jenis} {Nama} berhenti.");
            }
            else if(Kecepatan >= 999)
            {
                Stop();
            }
            else
            {
                Console.WriteLine($"{Jenis} {Nama} bergerak dengan kecepatan {Kecepatan} km/jam.");
            }
        }
        // Method SuaraKlakson untuk menampilkan suara klakson kendaraan (ditandai sebagai virtual).
        public virtual void SuaraKlakson()
        {
            Console.WriteLine($"{Jenis} {Nama} bersuara klakson standar.");
        }

        // Method Rem untuk mengurangi kecepatan kendaraan.
        public void Rem()
        {
            Kecepatan -= 20;
            if (Kecepatan <= 0)
            {
                Kecepatan = 0;
                Console.WriteLine($"\n{Jenis} {Nama} berhenti.");
            }
            else
            {
                Console.WriteLine($"\n{Jenis} {Nama} melakukan rem. Kecepatan sekarang: {Kecepatan} km/jam.");
            }
        }

        // Method Gas untuk menambah kecepatan kendaraan.
        public void Gas()
        {
            if (Kecepatan >= 999)
            {
                Stop ();
            }
            else if (Kecepatan < 999)
            {
                Kecepatan += 10;
                if(Kecepatan >= 999)
                {
                    Stop();
                }
                else
                {
                    Console.WriteLine($"\n{Jenis} {Nama} menambah gas. Kecepatan sekarang: {Kecepatan} km/jam.");
                }
            }
        }
        // Override untuk abstract class UnexpectedStop
        public override void Stop()
        {
            Console.WriteLine($"\nWARNING!: Kecepatan Anda melebihi 999 km/jam! Mesin terbakar, {Jenis} {Nama} Anda meledak!");
            Environment.Exit(0);
        }
    }

    // Subclass Mobil yang mewarisi dari Kendaraan.
    public class Mobil : Kendaraan, IBelok
    {
        public Mobil(string nama, int kecepatan) : base(nama, kecepatan, "Mobil")
        {
        }

        // Override method SuaraKlakson untuk mobil.
        public override void SuaraKlakson()
        {
            Console.WriteLine($"\nMobil {Nama} bersuara klakson: Tuin tuin!");
        }
        // Implementasi Interface IBelok
        public void Belok()
        {
            Console.WriteLine($"\nMobil {Nama} mau belok ke arah mana? (Masukkan kiri/kanan)");
            string arahBelok = Console.ReadLine();

            if (arahBelok.Equals("kiri", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\nMobil {Nama} belok ke kiri.");
            }
            else if (arahBelok.Equals("kanan", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\nMobil {Nama} belok ke kanan.");
            }
            else
            {
                Console.WriteLine($"\nMobil {Nama} tidak belok.");
            }
        }
    }

    // Subclass Motor yang mewarisi dari Kendaraan.
    public class Motor : Kendaraan, IBelok
    {
        private string warna;

        public Motor(string nama, int kecepatan, string warna) : base(nama, kecepatan, "Motor")
        {
            this.warna = warna;
        }

        // Method InfoMotor untuk menampilkan informasi tentang motor.
        public void InfoMotor()
        {
            Console.WriteLine($"\nMotor {Nama} dengan warna {warna} bergerak dengan kecepatan {Kecepatan} km/jam.");
        }
        // Override method SuaraKlakson untuk motor.
        public override void SuaraKlakson()
        {
            Console.WriteLine($"\nMotor {Nama} bersuara klakson: Tin tin!");
        }

        // Implementasi Interface IBelok
        public void Belok()
        {
            Console.WriteLine($"\nMotor {Nama} mau belok ke arah mana? (Masukkan kiri/kanan)");
            string arahBelok = Console.ReadLine();

            if (arahBelok.Equals("kiri", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\nMotor {Nama} belok ke kiri.");
            }
            else if (arahBelok.Equals("kanan", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\nMotor {Nama} belok ke kanan.");
            }
            else
            {
                Console.WriteLine($"\nMotor {Nama} tidak belok.");
            }
        }
    }

    // Subclass Bus yang mewarisi dari Kendaraan.
    public class Bus : Kendaraan
    {
        public Bus(string nama, int kecepatan) : base(nama, kecepatan, "Bus")
        {
        }

        // Override SuaraKlakson untuk bus.
        public override void SuaraKlakson()
        {
            Console.WriteLine($"\nBus {Nama} bersuara klakson: Ton ton!");
        }

        // Overloading SuaraKlakson dengan parameter suaraKlakson.
        public void SuaraKlakson(string suaraKlakson)
        {
            Console.WriteLine($"\nBus {Nama} bersuara klakson: {suaraKlakson}");
        }

        // Implementasi Interface IBelok
        public void Belok()
        {
            Console.WriteLine($"\nBus {Nama} mau belok ke arah mana? (Masukkan kiri/kanan)");
            string arahBelok = Console.ReadLine();

            if (arahBelok.Equals("kiri", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\nBus {Nama} belok ke kiri.");
            }
            else if (arahBelok.Equals("kanan", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\nBus {Nama} belok ke kanan.");
            }
            else
            {
                Console.WriteLine($"\nBus {Nama} tidak belok.");
            }
        }
    }
}