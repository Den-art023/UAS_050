using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_050
{
    class Node
    {
        public string JudulBk;
        public string Nama;
        public int NoBk;
        public int Tahun;
        public Node next;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void add()
        {
            int no, th;
            string nm, jd;
            Console.WriteLine("\nNomer Buku: ");
            no = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nJudul Buku: ");
            jd = Console.ReadLine();
            Console.WriteLine("\nNama Pengarang: ");
            nm = Console.ReadLine();
            Console.WriteLine("\nTahun Terbit: ");
            th = Convert.ToInt32(Console.ReadLine());
            Node newNode = new Node();
            newNode.JudulBk = jd;
            newNode.Nama = nm;
            newNode.NoBk = no;
            newNode.Tahun = th;

            if(START == null || no <= START.NoBk)
            {
                if((START != null) && (no <= START.NoBk))
                {
                    Console.WriteLine("\nNomer buku tidak boleh sama.\n");
                    return;
                }
                newNode.next = START;
                START = newNode;
                return;
            }

            Node previous, current;
            previous = START;
            current = START;

            while((current != null) && (no >= current.NoBk))
            {
                if(no == current.NoBk)
                {
                    Console.WriteLine("\nNomer buku tidak boleh sama.\n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newNode.next = current;
            previous.next = newNode;
        }
        public bool search(int th, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while((current != null) && (th != current.Tahun))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return(false);
            else
                return(true);
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nKosong.\n");
            else
            {
                Console.WriteLine("\nData Buku: \n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.NoBk + "   " + currentNode.JudulBk + "   " +
                                  currentNode.Nama + "   " + currentNode.Tahun + "\n");
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if(START == null)
                return(true);
            else
                return(false);
        }
        class Program
        {
            static void Main(string[] args)
            {
                List obj = new List();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nMenu\n");
                        Console.WriteLine("1. Masukkan data buku");
                        Console.WriteLine("2. Tampilkan semua buku");
                        Console.WriteLine("3. Mencari buku");
                        Console.WriteLine("4. Keluar");
                        Console.WriteLine("\nMasukkan pilihan(1-4): ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.add();
                                }
                                break;
                            case '2':
                                {
                                    obj.traverse();
                                }
                                break;
                            case '3':
                                {
                                    if(obj.listEmpty() == true)
                                    {
                                        Console.WriteLine("\nKosong.");
                                        break;
                                    }
                                    Node previous, current;
                                    previous = current = null;
                                    Console.Write("\nMasukkan tahun terbit: ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.search(num, ref previous, ref current) == false)
                                        Console.WriteLine("\nBuku tidak ditemukan.");
                                    else
                                    {
                                        Console.WriteLine("\nBUKU DITEMUKAN");
                                        Console.WriteLine("\nNomor Buku: " + current.NoBk);
                                        Console.WriteLine("\nJudul Buku: " + current.JudulBk);
                                        Console.WriteLine("\nNama Pengarang: " + current.Nama);
                                        Console.WriteLine("\nTahun Terbit: " + current.Tahun);
                                    }
                                }
                                break;
                            case '4':
                                return;
                            default:
                                {
                                    Console.WriteLine("\nPilihan tidak ada.");
                                    break;
                                }
                        }
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("\nCheck");
                    }
                }
            }
        }
    }
}

/*2. Saya menggunakan algoritma single linked list dikarenakan Udin ingin
 mengurutkan buku dengan waktu yang efisien sehingga mempermudah dalam mencari buku*/
/*3. operation yang ada di dalam algoritma stack adalah push and pop*/
/*4. depan, belakang*/
/*5. a. 5 tingkat
     b. 1, 5,8,10,12,15,20,22,25,28,30,36,38,40,45,48,50*/