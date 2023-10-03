using System;
using System.Collections.Generic;
using apalahlib; //Ini merupakan implementasi library class

namespace TugasPBO_TM_ // Implementasi namespace
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Masukkan nama kendaraan:");
            string namaKendaraan = Console.ReadLine();

            Console.WriteLine("Masukkan jenis kendaraan (mobil/motor/bus):");
            string jenisKendaraan = Console.ReadLine();

            Console.WriteLine("Masukkan kecepatan kendaraan (km/jam):");
            int kecepatanKendaraan = Convert.ToInt32(Console.ReadLine());

            Kendaraan kendaraan;

            if (jenisKendaraan.ToLower() == "mobil")
            {
                kendaraan = new Mobil(namaKendaraan, kecepatanKendaraan);
            }
            else if (jenisKendaraan.ToLower() == "motor")
            {
                Console.WriteLine("Masukkan jenis motor:");
                string jenisMotor = Console.ReadLine();
                kendaraan = new Motor(namaKendaraan, kecepatanKendaraan, jenisMotor);
            }
            else if (jenisKendaraan.ToLower() == "bus")
            {
                kendaraan = new Bus(namaKendaraan, kecepatanKendaraan);
            }
            else
            {
                kendaraan = new Kendaraan(namaKendaraan, kecepatanKendaraan, $"{jenisKendaraan}");
            }

            Console.WriteLine("\nStatus kendaraan saat ini:");
            kendaraan.Bergerak();

            while (true)
            {
                Console.WriteLine("\nApa yang ingin Anda lakukan?");
                Console.WriteLine("1. Klakson");
                Console.WriteLine("2. Rem");
                Console.WriteLine("3. Gas");
                Console.WriteLine("4. Belok");
                Console.WriteLine("5. Keluar");

                int pilihan = Convert.ToInt32(Console.ReadLine());

                switch (pilihan)
                {
                    case 1:
                        if (kendaraan is Bus)
                        {
                            Console.WriteLine("\nPilih jenis klakson:");
                            Console.WriteLine("1. Klakson Standar");
                            Console.WriteLine("2. Klakson Telolet");
                            int jenisKlakson = Convert.ToInt32(Console.ReadLine());
                            if (jenisKlakson == 1)
                            {
                                ((Bus)kendaraan).SuaraKlakson();
                            }
                            else if (jenisKlakson == 2)
                            {
                                ((Bus)kendaraan).SuaraKlakson("Telolet telolet telolet");
                            }
                            else
                            {
                                Console.WriteLine("Pilihan tidak valid.");
                            }
                        }
                        else
                        {
                            kendaraan.SuaraKlakson();
                        }
                        break;
                    case 2:
                        kendaraan.Rem();
                        break;
                    case 3:
                        kendaraan.Gas();
                        break;
                    case 4:
                        if (kendaraan is Mobil)
                        {
                            ((Mobil)kendaraan).Belok();
                        }
                        else if(kendaraan is Motor)
                        {
                            ((Motor)kendaraan).Belok();
                        }
                        else if (kendaraan is Bus)
                        {
                            ((Bus)kendaraan).Belok();
                        }
                        else
                        {
                        }
                        break;
                    case 5:
                        Console.WriteLine("Terima kasih telah menjalankan program ini!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan pilih lagi.");
                        break;
                }
            }
        }
    }
}
