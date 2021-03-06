﻿using System;

namespace ConsoleApp1
{
    class CaesarCipher
    {
        public static char[] alfabe = { 'a','b','c','ç', 'd','e','f', 'g', 'ğ', 'h', 'ı', 'i', 'j', 'k', 'l', 'm', 'n',
                'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z'};

        static void Main(string[] args)
        {


            Console.WriteLine("1- Sifreleme \n2- Sifre Cozme \n Secim : ");
            int secim = Int32.Parse(Console.ReadLine());

            if(secim == 1){
                encryption();
            }
            else if(secim == 2){
                decryption();
            }
            else{
                Console.WriteLine("Gecersiz Secim !");
            }
          
            
        }

        static void encryption()
        {
            Console.Write("Sifrenlenmek istenen metin : ");
            string acikMetin = Console.ReadLine();

            Console.Write("Sifreli Metin : ");
            char temp;
            foreach(char c in acikMetin.ToLower())
            {
                temp = c;
                for(int i = 0; i < 28; i++)
                {
                    if(c == alfabe[i])
                    {
                        temp = alfabe[(i + 3) % 28];
                    }
                }
                Console.Write(temp);

            }
            Console.ReadLine();

        }
        static void decryption()
        {
            Console.Write("Cozulmek istenen metin : ");
            string sifreliMetin = Console.ReadLine();

            Console.Write("Acık Metin : ");
            char temp;
            foreach (char c in sifreliMetin.ToLower())
            {
                temp = c;
                for (int i = 0; i < 28; i++)
                {
                    if (c == alfabe[i])
                    {
                        temp =  alfabe[((i - 3) + 28  ) % 28];
                    }
                }
                Console.Write(temp);
            }
            Console.ReadLine();
        }

    }
}
