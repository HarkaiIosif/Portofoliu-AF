using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AF_26._05
{
        
    internal class Program
    {
        public static bool[,] B;
        public  static int[,] A;
        public static int n;
        public static int m;
        public static bool ok;
        public static int l;
        public static int nr;
        public static bool is1;
        public static bool is2;
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"..\..\TextFile1.txt");
            string[] t=load.ReadLine().Split(' ');
            n = int.Parse(t[0]);
            m = int.Parse(t[1]);
            A = new int[n, m];
            B=new bool[n, m];
            for(int i = 0; i < n; i++)
            {
                t=load.ReadLine().Split(' ');
                for(int j = 0; j < m; j++) A[i,j]= int.Parse(t[j]);
            }
            int nr1=0,nr2=0;
            for(int i=0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    is1 = false; is2=false;nr = 0;
                    if (A[i,j] == 0 && !B[i,j]) 
                    {
                        PA3(i, j);
                        if (is1 && !is2) nr1 += nr;
                        if(is2 && !is1) nr2 += nr;
                    }

                }
            }
            /*
             int max=0;
             for(int i=0;i<n;i++)
            {
              for(int j=0,i<m;j++)
            { 
              if(!B[i,j]){  nr=0;
            PA2(i,j)
               if(nr>max) max=nr;}
            
             */
            Console.WriteLine($"1:{nr1} , 2:{nr2}");
            Console.ReadKey();
        }
        //drum de 0
        private static void PA1(int i,int j)
        {
            if (i >= 0 && j >= 0 && i < n && j < m && !B[i, j] && A[i, j] == 0)
            {
                B[i, j] = true;
                if (i == n - 1 && j == m - 1) ok = true;
                PA1(i - 1, j);
                PA1(i + 1, j);
                PA1(i, j + 1);
                PA1(i, j - 1);
            }
        }
        //platouri
        private static void PA2(int i,int j)
        {
            if(i >= 0 && j >= 0 && i<n && j<m && !B[i, j])
            {
                if (A[i, j] == l)
                {
                    B[i, j] = true;
                    nr++;
                    PA2(i - 1, j);
                    PA2(i + 1, j);
                    PA2(i, j + 1);
                    PA2(i, j - 1);
                }
            }
        }
        //teritorii
        private static void PA3(int i,int j)
        {
            if(i>=0 && j >= 0 &&i<n&&j<m && !B[i, j])
            {
                if (A[i, j] == 0)
                {
                    B[i, j] = true;
                    nr++;
                    PA3(i - 1, j);
                    PA3(i, j + 1);
                    PA3(i,j - 1);
                    PA3(i + 1, j);
                }
                else
                {
                    if (A[i, j] == 1) is1= true;
                    if (A[i,j]==2) is2= true;
                }
            }
        }
    }
}
