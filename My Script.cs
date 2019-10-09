using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FirstCSharp
{
    //class Person
    //{
    //    private string name;
    //    private string address;

    //    // Auto-Implement Properties
    //    public string Name
    //    {
    //        get { return this.name; }
    //        set { this.name = value; }
    //    }

    //    public string Address
    //    {
    //        get { return this.address; }
    //        set { this.address = value; }
    //    }

    //    public void Walk()
    //    {
    //        Console.WriteLine("Walk . . .");
    //    }

    //    public void Eat(string food)
    //    {
    //        Console.WriteLine("Eating {0}", food);
    //    }
    //}

    class Calculator
    {
        private int result;

        public void Add(int num1, int num2)
        {
            this.result = num1 + num2;
        }

        public void Sub(int num1, int num2)
        {
            this.result = num1 - num2;
        }

        public void Times(int num1, int num2)
        {
            this.result = num1 * num2;
        }

        public void Divide(int num1, int num2)
        {
            this.result = num1 / num2;
        }

        public void Mod(int num1, int num2)
        {
            this.result = num1 % num2;
        }

        public void PrintResult() {
            Console.WriteLine(this.result);
        }

    }

    class PrintBox
    {
        private int CountPadding(string text)
        {
            int count = text.Length / 2;
            return count;
        }

        public void Print(string name)
        {
            int padding = CountPadding(name)*2;
            for(int i = 0, x = 0; x < name.Length+padding+1; x++)
            {
                if(x == 0 || x == name.Length + padding)
                {
                    Console.Write("|");
                }
                if(x > (padding / 2) && x < (padding/2)+name.Length) {
                    Console.Write(name[i++]);
                }
                else
                {
                    Console.Write(" ");
                }
            }
        }
    }

    class Vowel
    {
        private string text;

        public string GetVowel(string name)
        {
            string vowels = "";
            for(int i = 0; i < name.Length; i++)
            {
                switch(name[i])
                {
                    case 'a':
                    case 'i':
                    case 'u':
                    case 'e':
                    case 'o':
                        vowels = vowels + name[i];
                        break;
                }
            }
            this.text = vowels;
            return vowels;
        }

        public int Count()
        {
            return this.text.Length;
        }
    }

    class Player
    {
        private int x;
        private int y;
        private int bulletX;
        private int bulletY;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Player()
        {
            x = 0;
            y = 0;
            bulletX = x;
            bulletX = y;
        }

        public void Draw()
        {
            this.x = (x < 0 ? 0 : x);
            this.y = (y < 0 ? 0 : y);
            Console.SetCursorPosition(x, y);
            Console.Write("O");
        }

        public void DrawProps()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("X: {0} Y: {1}", x, y);
        }

        private void StartShot()
        {
            bulletX = x;
            bulletY = y;
            for(int i = 0; i < 20; i++) {
                Thread.Sleep(50);
                Console.SetCursorPosition(bulletX++, bulletY);
                Console.Write("*");
            }
        }

        public void Shot() {
            Thread t = new Thread(StartShot);
            t.Start();
        }

        private void _input()
        {
            ConsoleKey key = ConsoleKey.Escape;
            while(key != ConsoleKey.Q)
            {
                key = Console.ReadKey().Key;
                switch(key)
                {
                    case ConsoleKey.LeftArrow:
                        x--;
                        break;
                    case ConsoleKey.RightArrow:
                        x++;
                        break;
                    case ConsoleKey.UpArrow:
                        y--;
                        break;
                    case ConsoleKey.DownArrow:
                        y++;
                        break;
                    case ConsoleKey.Enter:
                        Shot();
                        break;
                }
            }
        }

        public void Input()
        {
            Thread t = new Thread(this._input);
            t.Start();
        }
    }

    class Persegi
    {
        private double sisi;

        public double Sisi { get => sisi; set => sisi = value; }

        public double Keliling()
        {
            double keliling = sisi * 4;
            return keliling;
        }

        public double Luas()
        {
            double luas = sisi * sisi;
            return luas;
        }
    }

    class Converter
    {
        public static int Count = 0;

        public static string ToString(char chr)
        {
            return chr + "";
        }

        public int GetCount()
        {
            return Count;
        }
    }

    class Car
    {
        private double fuel;
        private int gear;
        private int speed;

        public double Fuel { get => fuel; set => fuel = value; }
        public int Gear { get => gear; set => gear = value; }
        public int Speed { get => speed; set => speed = value; }

        public Car()
        {
            fuel = 100.0;
            gear = 0; // 0 = N
            speed = 0;
        }

        public Car(double fuel, int gear, int speed)
        {
            this.fuel = fuel;
            this.gear = gear;
            this.speed = speed;
        }
    }

    class Cart 
    {
        private List<Car> items;

        public Cart()
        {
            items = new List<Car>();
        }

        public void AddItem(Car item)
        {
            items.Add(item);
        }

        public void Print()
        {
            foreach(Car item in items) Console.Write(item.Gear + " ");
        }
    }

    class Game
    {
        private Player player;

        public Game()
        {
            player = new Player();
            
        }

        private void _render()
        {
            player.Input();
            while(true)
            {
                player.Draw();
                //Console.Clear();
            }
        }
        public void Render()
        {
            Thread t = new Thread(this._render);
            t.Start();
        }
    }

    class PC
    {
        private bool on;
        private double clockSpeed;
        private int cache;
        private double memory;
        private double cpuUsage;
        private double memoryUsage;
        private double diskUsage;

        public bool On { get => on; set => on = value; }
        public double ClockSpeed { get => clockSpeed; set => clockSpeed = value; }
        public int Cache { get => cache; set => cache = value; }
        public double CpuUsage { get => cpuUsage; set => cpuUsage = value; }
        public double MemoryUsage { get => memoryUsage; set => memoryUsage = value; }
        public double DiskUsage { get => diskUsage; set => diskUsage = value; }
        public double Memory { get => memory; set => memory = value; }

        public PC()
        {
            this.on = false;
            clockSpeed = 2.5;
            cache = 2;
            Memory = 512;
            cpuUsage = 0;
            memoryUsage = 0;
            diskUsage = 0;
        }

        public PC(double clock, int cache, int memory)
        {
            this.on = false;
            this.clockSpeed = clock;
            this.cache = cache;
            this.memory = memory;
            cpuUsage = 0;
            memoryUsage = 0;
            diskUsage = 0;
        }

        public void Boot()
        {
            this.on = true;
            Console.WriteLine("Initializing Kernel . . .");
            Thread.Sleep(1000);
            Console.WriteLine("Booting . . .");
            Thread.Sleep(2000);
            cpuUsage = 20.0;
            memoryUsage = this.memory/10.0;
            diskUsage = 5.0;
            Console.WriteLine("Ready.");
        }

        private int getByteSize(string data)
        {
            return data.Length;
        }

        public void WriteData(string data)
        {
            int dataSize = getByteSize(data);
            if(dataSize < this.memory)
            {
                Console.WriteLine("Writing Data . . .");
                Thread.Sleep(dataSize * 1000 / 2);
                this.memoryUsage += (memory/dataSize);
                this.cpuUsage += dataSize / 2;
                this.diskUsage += dataSize*2;
                PrintResource();
                Console.WriteLine("Success Writing {0} bytes of data", dataSize);
                Console.WriteLine("Releasing . . .");
                this.memoryUsage -= (memory / dataSize);
                this.cpuUsage -= dataSize / 2;
                this.diskUsage -= dataSize * 2;
            }
            else
            {
                Console.WriteLine("Memory Not Enough");
            }
        }

        public void ReadData(string data)
        {
            int dataSize = getByteSize(data);
            if(dataSize < this.memory)
            {
                Console.WriteLine("Reading Data . . .");
                Thread.Sleep(dataSize * 1000 / 2);
                this.memoryUsage += (memory / dataSize);
                this.cpuUsage += dataSize / 2;
                this.diskUsage += dataSize * 2;
                PrintResource();
                Console.WriteLine("Success Reading {0} bytes of data stored in RAM", dataSize);
                this.cpuUsage -= dataSize / 2;
                this.diskUsage -= dataSize * 2;
            }
            else
            {
                Console.WriteLine("Memory Not Enough");
            }
        }

        public void PrintResource()
        {
            Console.WriteLine("Resource\nMemory : {0}\nMemory Usage : {1}\nCPU Usage : {2}\nDisk Usage : {3}", this.memory, this.memoryUsage, this.cpuUsage, this.diskUsage);
        }

        public void Shutdown()
        {
            Console.WriteLine("Shutting Down . . .");
            Console.WriteLine("Releasing Resource . . .");
            this.memoryUsage = 0;
            this.cpuUsage = 0;
            this.diskUsage = 0;
            this.on = false;
        }
    }


    // Extends
    class Person
    {
        private string name;
        private string address;

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }

        public Person()
        {

        }

        public void Eat()
        {
            Console.WriteLine("Eating Food");
        }
    }

    class Mahasiswa : Person
    {
        private string nim;
        private int semester;

        public string Nim { get => nim; set => nim = value; }
        public int Semester { get => semester; set => semester = value; }

        public void Belajar()
        {
            Console.WriteLine("Belajar Belajar Belajar");
        }
    }

    class Pegawai : Person
    {
        private string nip;
        private string jabatan;

        public string Nip { get => nip; set => nip = value; }
        public string Jabatan { get => jabatan; set => jabatan = value; }

        public void Bekerja()
        {
            Console.WriteLine("Kerja Kerja Kerja");
        }
    }

    class Mobil
    {
        private Ban ban;

        public Mobil(Ban ban)
        {
            this.ban = ban;
        }
    }

    class Ban
    {

    }

    class Bridgestone : Ban
    {

    }

    class Michellin : Ban
    {

    }

    //class Enemy
    //{
    //    private int health;
    //    private int damage;

    //    public int Health { get => health; set => health = value; }
    //    public int Damage { get => damage; set => damage = value; }

    //    public void Attack()
    //    {
    //        Console.WriteLine("Serang");
    //    }
    //}

    //class Zombie : Enemy
    //{
    //    private int walkSpeed;

    //    public Zombie()
    //    {
    //        this.Health = 100;
    //        this.Damage = 50;
    //    }

    //    public void Walk()
    //    {

    //    }
    //}

    //class Ghost : Enemy
    //{
    //    private int flySpeed;

    //    public Ghost()
    //    {
    //        this.Health = 120;
    //        this.Damage = 80;
    //    }

    //    public void Fly()
    //    {

    //    }
    //}

    interface IEnemy
    {
        void Attack();
    }

    abstract class Enemy : IEnemy
    {
        private int health;
        private int damage;

        public int Health { get => health; set => health = value; }
        public int Damage { get => damage; set => damage = value; }

        public abstract void Guard();
        public abstract void Attack();
    }

    class Zombie : Enemy
    {
        public override void Attack()
        {
            Console.WriteLine("Zombie Attaks");
        }

        public override void Guard()
        {
            Console.WriteLine("Zombie Guards");
        }
    }

    class Ghost : IEnemy
    {
        public void Attack()
        {
            Console.WriteLine("Ghost Attaks");
        }
    }

    interface IKelas
    {
        void Fasilitas();
        string GetName();
    }

    class Ekonomi : IKelas
    {
        public void Fasilitas()
        {
            Console.WriteLine("Kamar Mandi Jongkok, Bangku 4");
        }

        public string GetName()
        {
            return "Ekonomi";
        }
    }

    class Eksekutif : IKelas
    {
        public void Fasilitas()
        {
            Console.WriteLine("Meja, Bangku 2 bisa diatur");
        }

        public string GetName()
        {
            return "Eksekutif";
        }
    }

    class Bisnis : IKelas
    {
        public void Fasilitas()
        {
            Console.WriteLine("Bantal, Meja, Bangku 2 tidak bisa diatur");
        }
        public string GetName()
        {
            return "Bisnis";
        }
    }


    class Tiket
    {
        private string noTiket;
        private string nama;
        private string keberangkatan;
        private string tujuan;
        private IKelas kelas;

        public string NoTiket { get => noTiket; set => noTiket = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Keberangkatan { get => keberangkatan; set => keberangkatan = value; }
        public string Tujuan { get => tujuan; set => tujuan = value; }
        public IKelas Kelas { get => kelas; set => kelas = value; }
    }

    class SistemTiket
    {
        private List<Tiket> tikets;

        public List<Tiket> TransactionHistory { get => tikets; set => tikets = value; }

        public SistemTiket()
        {
            tikets = new List<Tiket>();
        }

        public void Transaction(Tiket tiket)
        {
            this.tikets.Add(tiket);
        } 
    }

    class Program
    {
        static void Main(string[] args)
        {
            {
                //Person person = new Person(); // Create instance
                //person.Name = "Galih";
                //person.Address = "Tangerang";
                //Console.WriteLine("{0} {1}", person.Name, person.Address);
                //person.Walk();
                //person.Eat("Beef");

                //Calculator calc = new Calculator();
                //int num1 = int.Parse(args[0]);
                //int num2 = int.Parse(args[2]);
                //switch(args[1]) {
                //    case "+":
                //        calc.Add(num1, num2);
                //        break;
                //    case "-":
                //        calc.Sub(num1, num2);
                //        break;
                //    case "*":
                //        calc.Times(num1, num2);
                //        break;
                //    case "/":
                //        calc.Divide(num1, num2);
                //        break;
                //    case "%":
                //        calc.Mod(num1, num2);
                //        break;
                //}

                //calc.PrintResult();
            }
            {
            //    Player p = new Player();
            //    ConsoleKey key = ConsoleKey.Escape;
            //    while(key != ConsoleKey.Q)
            //    {
            //        key = Console.ReadKey().Key;
            //        Console.Clear();
            //        switch(key)
            //        {
            //            case ConsoleKey.LeftArrow:
            //                p.X--;
            //                break;
            //            case ConsoleKey.RightArrow:
            //                p.X++;
            //                break;
            //            case ConsoleKey.UpArrow:
            //                p.Y--;
            //                break;
            //            case ConsoleKey.DownArrow:
            //                p.Y++;
            //                break;
            //            case ConsoleKey.Enter:
            //                p.Shot();
            //                break;
            //        }
            //        p.Draw();
            //        p.DrawProps();
            //    }
            }

            SistemTiket st = new SistemTiket();
            int ch;
            do
            {
                Console.Write("\n===Menu===\n1> Beli Tiket\n2> Daftar Riwayat\n3> Keluar\n>> ");
                ch = int.Parse(Console.ReadLine());
                switch(ch)
                {
                    case 1:
                        Tiket tiket = new Tiket();
                        tiket.NoTiket = "T00" + (st.TransactionHistory.Count + 1);
                        Console.Write("Nama : ");
                        tiket.Nama = Console.ReadLine();
                        Console.Write("Keberangkatan : ");
                        tiket.Keberangkatan = Console.ReadLine();
                        Console.Write("Tujuan : ");
                        tiket.Tujuan = Console.ReadLine();
                        Console.Write("Kelas (1. Ekonomi, 2. Eksekutif, 3. Bisnis): ");
                        int kelas = int.Parse(Console.ReadLine()); // 1. Ekonomi 2. Eksekutif 3. Bisnis
                        if(kelas == 1)
                        {
                            tiket.Kelas = new Ekonomi();
                        }else if(kelas == 2)
                        {
                            tiket.Kelas = new Eksekutif();
                        }
                        else if(kelas == 3)
                        {
                            tiket.Kelas = new Bisnis();
                        }
                        else
                        {
                            tiket.Kelas = new Ekonomi();
                        }
                        st.Transaction(tiket);
                        break;
                    case 2:
                        Console.WriteLine("No. Tiket\t|\tNama\t|\tKeberangkatan\t|\tTujuan\t|\tKelas");
                        foreach(Tiket history in st.TransactionHistory)
                        {
                            Console.WriteLine("{0}\t\t|\t{1}\t|\t{2}\t|\t{3}\t|\t{4}", history.NoTiket, history.Nama, history.Keberangkatan, history.Tujuan, history.Kelas.GetName());   
                        }
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            } while(ch != 3);


            Console.ReadKey();
        }
    }
}