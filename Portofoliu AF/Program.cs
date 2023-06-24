using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portofoliu_AF
{
    internal class Program
    {
        public static int[] T = new int[5];
        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            //S2_2();
            //S10();
            //S30();
            S29();
            Console.ReadKey();
        }
        private static void S2_1()
        {

            for (int i = 0; i < 5; i++)
            {
                T[i] = rnd.Next(5, 14);
                Console.Write(T[i] + " ");
            }
                Console.WriteLine(IDToFormation(Calculus()));
            Console.ReadKey();
        }
        public static int Calculus()
        {
            int[] nr = new int[15];
            for (int i = 0; i < 5; i++) nr[T[i]]++;
            int max = 0;
            int contor2 = 0;
            for (int i = 0; i < nr.Length; i++)
            {
                if (nr[i] > max) max = nr[i];
                if (nr[i] == 2) contor2++;
            }
            if (max == 5) return 9;
            else if (max == 4) return 7;
            else if (max == 3 && contor2 == 2) return 6;
            else if (max == 3 && contor2 != 2) return 3;
            else if (max == 2 && contor2 == 2) return 2;
            else if (max == 2 && contor2 != 2) return 1;
            else if (max == 1) return 0;
            return -1;
        }
        public static string IDToFormation(int x)
        {
            switch (x)
            {
                case 0: return "No Pairs";
                case 1: return "One Pair";
                case 2: return "Two Pairs";
                case 3: return "Three of a kind";
                case 6: return "Full House";
                case 7: return "Four of a kind";
                case 9: return "Five of a kind";
                default: return "No pairs";
            }
        }
        private static void S2_2()
        {
            int n=int.Parse(Console.ReadLine());
            string[] t = Console.ReadLine().Split(' ');
            int[] v= new int[n];
            for(int i = 0; i < n;i++) v[i] = int.Parse(t[i]);
            bool ok = true;
            for(int i=0; i < v.Length; i++)
            {
                for(int j=i+1;j<v.Length; j++) { if (v[i] > v[j]) (v[i], v[j]) = (v[j], v[i]);}
            }
            for(int i=1;i<v.Length;i++)  if (!(v[i] == v[i-1]+1)) ok= false;
            if (ok) Console.WriteLine("Elementele vectorului pot fi elemente ale unei progresii geometrice cu ratia 1");
        }
        private static void S3()
        {
            int n = int.Parse(Console.ReadLine());
            bool prim = isprim(n);
            if (prim) Console.WriteLine("Nr prim");
            else Console.WriteLine("Nu este nr prim");
            
        }
        public static bool isprim(int n)
        {
            
            if (n < 2) return false;
            if (n == 2) return true;
            if(n%2==0) return false;
            for (int i = 3; i <= Math.Sqrt(n); i += 2) if (n % i == 0) return false;
            return true;
        }
        private static void S4()
        {
            int n=int.Parse(Console.ReadLine());
            int[] cifre = new int[10];
            if (n == 0)
            {
                cifre[0]++;
                Console.WriteLine("0"); 
            }
            else while (n > 0)
                {
                    int c = n % 10;
                    cifre[c]++;
                    Console.Write(c + " ");
                    n /= 10;
                }
        }
        private static void S5() 
        {
            List<int> cifre = new List<int>();
            int n;
            do
            {
                 n = int.Parse(Console.ReadLine());
                if (n != -1) cifre.Add(n);
            } while (n != -1);
            int[] cifre2 = cifre.ToArray();
            int min = cifre2[0];
            int nr = 1;
            for(int i=1; i < cifre2.Length; i++)
            {
                if (cifre2[i] < min)
                {
                    min = cifre2[i];
                    nr = 1;
                }
                else if (cifre2[i] == min) nr++;
            }
            Console.WriteLine($"Minimul este {min} si apare de {nr} ori");
        }
        private static void S6()
        {
            int n=int.Parse(Console.ReadLine());
            int r = n;
            int o = 0;
            while (r > 0)
            {
                int c=r % 10;
                o = o * 10 + c;
                r /= 10;
            }
            if (o == n) Console.WriteLine("Palindrom");
            else Console.WriteLine("Nu e palindrom");
        }
        private static void S7()
        {
            string[] t = Console.ReadLine().Split(' ');
            int n = int.Parse(t[0]);
            int m = int.Parse(t[1]);
            while (m != 0)
            {
                int p = n % m;
                n = m;
                m = p;
            }
            Console.WriteLine(n);
        }
        private static void S8()
        {
            string[] t = Console.ReadLine().Split(' ');
            int[] v = new int[t.Length];
            for (int i = 0; i < v.Length; i++) v[i] = int.Parse(t[i]);
            int Sum = 0;
            int Prod = 1;
            for(int i = 0; i < v.Length; i++)
            {
                Sum += v[i];
                Prod *= v[i];
            }
            Console.WriteLine(Sum + " " + Prod);
        }
        private static void S9()
        {
            string[] t = Console.ReadLine().Split(' ');
            int[] v = new int[t.Length];
            for (int i = 0; i < v.Length; i++) v[i] = int.Parse(t[i]);
            int min = v[0];
            int max = v[0];
            for(int i=1;i<v.Length;i++)
            {
                if (v[i]<min) min= v[i];
                if (v[i]>max) max= v[i];
            }
            Console.WriteLine(min + " " + max); 
        }
        private static void S10()
        {
            string[] t = Console.ReadLine().Split(' ');
            int[] v = new int[t.Length];
            for (int i = 0; i < v.Length; i++) v[i] = int.Parse(t[i]);
            int[] temp = new int[v.Length];
            int ids = 0, ide = v.Length - 1;
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] > 0) { temp[ide] = v[i]; ide--; }
                if (v[i] < 0) { temp[ids]= v[i]; ids++; }
            }
            v = temp;
            Console.WriteLine();
            for(int i=0; i<v.Length; i++) Console.Write(v[i]+" ");
            
        }
        private static void S11()//
        {
            int n=int.Parse(Console.ReadLine());
            int[] v = new int[n];
            string[] t=Console.ReadLine().Split(' ');
            for(int i=0;i<n;i++) v[i] = int.Parse(t[i]);
            bool ok;
            do
            {
                ok = true;
                for (int i = 0; i < n - 1; i++)
                {
                    if (v[i] > v[i + 1])
                    {
                        (v[i], v[i + 1]) = (v[i + 1], v[i]);
                        ok = false;
                    }
                }
            } while (!ok);
            for(int i=0;i<v.Length;i++) Console.Write(v[i]+" ");
        }
        private static void S12()//
        {
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++) v[i] = int.Parse(t[i]);
            for (int i = 0; i < n - 1; i++)
            {
                int Poz = i;
                int min = v[i];
                for (int j = i + 1; j < n; j++)
                {
                    if (v[j] < min)
                    {
                        Poz = j;
                        min = v[j];
                    }
                }
                (v[i], v[Poz]) = (v[Poz], v[i]);
            }
            for (int i = 0; i < v.Length; i++) Console.Write(v[i] + " ");
        }
        private static void S13()//
        {
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++) v[i] = int.Parse(t[i]);
            for (int i = 0; i < n - 1; i++)
            {
                int Poz = i;
                int min = v[i];
                for (int j = i + 1; j < n; j++)
                {
                    if (v[j] < min)
                    {
                        Poz = j;
                        min = v[j];
                    }
                }
                (v[i], v[Poz]) = (v[Poz], v[i]);
            }
            for (int i = 0; i < v.Length; i++) Console.Write(v[i] + " ");
        }
        private static void S14()//
        {
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++) v[i] = int.Parse(t[i]);
            for (int i = 1; i < n; i++)
            {
                int V = v[i];
                int j = i - 1;
                while (j > 0 && v[j] > V)
                {
                    v[j + 1] = v[j];
                    j--;
                }
                v[j + 1] = V;
            }
            for (int i = 0; i < v.Length; i++) Console.Write(v[i] + " ");
        }
        private static void S15()//
        {
            int n=int.Parse(Console.ReadLine());
            int[] v1 = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            for(int i = 0; i < n;i++) v1[i] = int.Parse(t[i]);
            int m = int.Parse(Console.ReadLine());
            int[] v2= new int[m];
            t = Console.ReadLine().Split(' ');
            for(int i=0;i< m;i++) v2[i] = int.Parse(t[i]);
            int[] v3= new int[n+m];
            int index = 0;
            for(int i=0; i < n;i++)
            {
                v3[index++] = v1[i];
            }
            for(int i = 0; i < m; i++)
            {
                v3[index++] = v2[i];
            }
            for(int i=0;i < v3.Length;i++) Console.Write(v3[i]+" ");
           
        }
        private static void S16()//
        {
            int n = int.Parse(Console.ReadLine());
            int[] v1 = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++) v1[i] = int.Parse(t[i]);
            int m = int.Parse(Console.ReadLine());
            int[] v2 = new int[m];
            t = Console.ReadLine().Split(' ');
            for (int i = 0; i < m; i++) v2[i] = int.Parse(t[i]);
            List<int> l = new List<int>();
            for(int i = 0; i < n; i++)
            {
                if (!l.Contains(v1[i])) l.Add(v1[i]);
            }
            for(int i=0; i <m ; i++)
            {
                if (!l.Contains(v2[i])) l.Add(v2[i]);  
            }
            int[] v3=l.ToArray();
            for(int i=0;i<v3.Length;i++) Console.WriteLine(v3[i]+" ");
        }
        private static void S17()//
        {
            int n = int.Parse(Console.ReadLine());
            int[] v1 = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++) v1[i] = int.Parse(t[i]);
            int m = int.Parse(Console.ReadLine());
            int[] v2 = new int[m];
            t = Console.ReadLine().Split(' ');
            for (int i = 0; i < m; i++) v2[i] = int.Parse(t[i]);
            List<int> l = new List<int>();
            for(int i=0; i < v1.Length; i++)
            {
                for(int j=0; j<v2.Length; j++)
                {
                    if (v1[i] == v2[j]) { l.Add(v2[j]); break; }
                }
            }
            int[] v3 = l.ToArray();
            for (int i = 0; i < v3.Length; i++) Console.Write(v3[i] + " ");

        }
        private static void S18()//
        {
            int n = int.Parse(Console.ReadLine());
            int[] v1 = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++) v1[i] = int.Parse(t[i]);
            int m = int.Parse(Console.ReadLine());
            int[] v2 = new int[m];
            t = Console.ReadLine().Split(' ');
            for (int i = 0; i < m; i++) v2[i] = int.Parse(t[i]);
            List<int> l = new List<int>();
            bool ok = true;
            for(int i=0;i < v1.Length;i++)
            {
                for(int j=0; j < v2.Length; j++)
                {
                    if (v1[i] == v2[j])
                    {
                        ok=false; break;
                    }
                }
                if(ok) l.Add(v1[i]);
            }
            int[] v3 = l.ToArray();
            for (int i = 0; i < v3.Length; i++) Console.WriteLine(v3[i] + " ");
        }
        private static void S19()//
        {
            int n = int.Parse(Console.ReadLine());
            int[] v1 = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++) v1[i] = int.Parse(t[i]);
            int m = int.Parse(Console.ReadLine());
            int[] v2 = new int[m];
            t = Console.ReadLine().Split(' ');
            for (int i = 0; i < m; i++) v2[i] = int.Parse(t[i]);
            bool ok = true;
            int id = -1;
            do
            {
                ok = true;
                for(int i=id+1; i<v1.Length; i++)
                {
                    if (v1[i] == v2[0]) { id = i;break;}
                    
                }
                for(int i = 0,j=id; i < v2.Length; i++,j++)
                {
                    if (!(v2[i] == v1[j])) { ok = false;break; }
                }
            } while (!ok);
            if (ok) Console.WriteLine("Se contine");
            else Console.WriteLine("Nu se contine");
        }
        private static void S20()//
        {
            int n = int.Parse(Console.ReadLine());
            int[] v1 = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++) v1[i] = int.Parse(t[i]);
            int m = int.Parse(Console.ReadLine());
            int[] v2 = new int[m];
            t = Console.ReadLine().Split(' ');
            for (int i = 0; i < m; i++) v2[i] = int.Parse(t[i]);
            List<int> l = new List<int>();
            int o1, o2;
            int carry = 0;
            for(int i = 0, j = 0; i < n || j < m || carry == 1; i++, j++)
            {
                o1=i<v1.Length ? v1[i] : 0;
                o2=i<v2.Length ? v2[i] : 0;
                int res = (o1 + o2 + carry) % 10;
                carry=(o1 + o2+carry) /10;
                l.Add(res);
            }
            int[] result=l.ToArray();
            for(int i=0; i<result.Length; i++)
            {
                Console.Write(result[i]);
            }
        }
        private static void S21()//
        {
            int n = int.Parse(Console.ReadLine());
            int[] v1 = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++) v1[i] = int.Parse(t[i]);
            int m = int.Parse(Console.ReadLine());
            int[] v2 = new int[m];
            t = Console.ReadLine().Split(' ');
            for (int i = 0; i < m; i++) v2[i] = int.Parse(t[i]);
            int o1, o2;
            int carry = 0;
            List<int> l = new List<int>();
            for (int i = 0; i < n+m;i++) l.Add(0);
            for(int i=0; i < m; i++)
            {
                o1 = i < m ? v2[i] : 0;
                for(int j=0,k=1; j < n&&k<n+m||carry!=0; j++,k++) 
                {
                    o2 = j < n? v1[j] : 0;
                    int aux = l[k];
                    l.RemoveAt(k);
                    l.Insert(k, ((o1 * o2) % 10 + aux + carry));
                    carry = o1 * o2 / 10;
                    if (l[k] > 9)
                    {
                        aux = l[k];
                        l.RemoveAt(k);
                        l.Insert(k, aux % 10);
                        int aux1 = l[k + 1];
                        l.RemoveAt(k + 1);
                        l.Insert(k+1,aux1+aux%10);  
                    }
                }
            }
            for (int i = 0; i < l.Count; i++) if (l[i] == 0)
                {
                    l.RemoveAt(i);

                }
                else break;
            int[] result = l.ToArray();
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i]);
            }
        }
        private static void S22()//
        {
            string[] t=Console.ReadLine().Split(' ');
            int n = int.Parse(t[0]);
            int m= int.Parse(t[1]);
            int[,] A = new int[n, m];
            int idx = 2;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    while (A[i, j] == 0)
                    {
                        if (isprim(idx)) A[i, j] = idx;
                        idx++;
                    }
                }
            }
            for(int i = 0; i < n;i++)
            {
                for(int j=0; j < m; j++)
                {
                    Console.Write(A[i, j]+" ");
                }
                Console.WriteLine();
            }


        }
        private static void S23()//
        {
            string[] t = Console.ReadLine().Split(' ');
            int n = int.Parse(t[0]);
            int m = int.Parse(t[1]);
            int[,] A = new int[n, m];
            int[,] B=new int[n, m];
            for(int i=0;i < n; i++)
            {
                for(int j=0; j < m; j++)
                {
                    if (i < n / 2 && j < m / 2) A[i, j] = 1;
                    if(i<n / 2 &&j>m/2) A[i, j] = 2;
                    if (i > n / 2 && j < m / 2) A[i, j] = 3;
                    if (i > n / 2 && j > m / 2) A[i, j] = 4;
                    if (i < j && i + j < n - 1) B[i, j] = 1;
                    if(i<j && i + j > n -1) B[i, j] = 2;
                    if(i>j&& i + j < n - 1) B[i, j] = 4;
                    if(i>j&& i + j > n - 1) B[i,j] = 3;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(B[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
        private static void S24()//
        {
            string[] t=Console.ReadLine().Split(' ');   
            int n = int.Parse(t[0]);
            int m = int.Parse(t[1]);
            int[,] A = new int[n, m];
            int i, j;
            for(i=0; i < n; i++)
            {
                t=Console.ReadLine().Split(' ');
                for( j=0; j < m; j++)
                {
                    A[i, j] = int.Parse(t[j]);
                }
            }
            int k = 0, l = 0;
            while (k <= m && l <= n)
            {
                for (j = l; j < n; j++)
                {
                    Console.Write(A[k, j] + " ");
                }
                k++;
                for (j = k; j < m; j++)
                {
                    Console.Write(A[j, n - 1] + " ");
                }
                n--;
                if (k < m)
                {
                    for (j = n - 1; j >= l; j--)
                    {
                        Console.Write(A[m - 1, j] + " ");
                    }
                    m--;
                }
                if (l < n)
                {
                    for (j = m - 1; j >= k; j--)
                    {
                        Console.Write(A[j, l] + " ");
                    }
                    l++;
                }
            }
        }
        private static void S25()//
        {
            string[] t = Console.ReadLine().Split(' ');
            int n = int.Parse(t[0]);
            int m = int.Parse(t[1]);
            int[,] A = new int[n, m];
            int[,] B = new int[n, m];
            int i, j;
            for (i = 0; i < n; i++)
            {
                t = Console.ReadLine().Split(' ');
                for (j = 0; j < m; j++)
                {
                    A[i, j] = int.Parse(t[j]);
                }
            }
            for (i = 0; i < n; i++)
            {
                t = Console.ReadLine().Split(' ');
                for (j = 0; j < m; j++)
                {
                    B[i, j] = int.Parse(t[j]);
                }
            }
            int[,] Sum= new int[n, m];
            for( i=0; i < n; i++)
            {
                for(j=0; j < m; j++)
                {
                    Sum[i, j] = A[i, j] + B[i,j];
                }
            }
            Console.WriteLine();
            for ( i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Console.Write(Sum[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        private static void S26()//
        {
            int i, j;
            string[] t = Console.ReadLine().Split(' ');
            int n = int.Parse(t[0]);
            int m = int.Parse(t[1]);
            int[,] A = new int[n, m];
            for (i = 0; i < n; i++)
            {
                t = Console.ReadLine().Split(' ');
                for (j = 0; j < m; j++)
                {
                    A[i, j] = int.Parse(t[j]);
                }
            }
            t = Console.ReadLine().Split(' ');
            int o = int.Parse(t[0]);
            int p = int.Parse(t[1]);
            int[,] B = new int[o,p];
            for (i = 0; i <o ; i++)
            {
                t = Console.ReadLine().Split(' ');
                for (j = 0; j < p; j++)
                {
                    B[i, j] = int.Parse(t[j]);
                }
            }
            if (m != o) Console.WriteLine("Nu se poate face inmultirea");
            else
            {
                int[,] Result=new int[n, p];
                for(i=0;i<n; i++)
                {
                    for(j=0;j<p; j++)
                    {
                        Result[i, j] = 0;
                        for(int k = 0; k < m; k++)
                        {
                            Result[i, j] += A[i, k] * B[k, j];
                        }
                    }
                }
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < p; j++)
                    {
                        Console.Write(Result[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
        private static void S27()
        {

        }
        private static void S28()//
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
        }
        private static long Factorial(int number) 
        {
            long toRet;
            if (number == 0) toRet = 1;
            else
            {
                toRet = number*Factorial(number-1);
            }
            return toRet;
        }
        private static void S29()
        {
            int n=0, second=0, last = 1,counter=int.Parse(Console.ReadLine());
            Fibonaci(ref n,ref second,ref last,ref counter);
            Console.WriteLine(n) ;
        }
        private static void Fibonaci(ref int n, ref int second,ref int last,ref int counter)
        {
            if (counter > 0)
            {
                n = second + last;
                second = last;
                last = n;
                counter--;
                Fibonaci(ref n,ref second,ref last,ref counter);
            }
           
        }
        private static void S30() 
        {
            int n=int.Parse(Console.ReadLine());
            n = n * 3;
            for (int i = 0; i < n; i++) Console.Write("*");
            Console.WriteLine();
            Cantor(n,n);

        }
        private static void Cantor(int n,int length)
        {   n /= 3;
            if (n == 0) return;
            for(int i=0; i<n; i++)
            {
                Console.Write("*");
            }
            for(int i=0; i<n;i++)
            {
                Console.Write(" ");
            }
            for(int i=0; i < n; i++)
            {
                Console.Write("*");
            }
            for(int i = 0; i < length; i++)
            {
                Console.Write(" ");
            }
            for(int i = 0; i < n; i++)
            {
                Console.Write("*");
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            Cantor(n,n);
            
            
        }
        private static void S31()
        {

        }
        private static void S35()
        {
            int n=int.Parse(Console.ReadLine());
            int[] v = new int[n];
            string[] t = Console.ReadLine().Split(' ');
            for(int i=0;i<n ; i++)
            {
                v[i] = int.Parse(t[i]);
            }
            MergeSort(v);
            for (int i = 0; i < v.Length; i++) Console.Write(v[i] +' ');
        }
        public static int[] MergeSort(int[] arr)
        {
            if (arr.Length == 1) return arr;
            int[] half1 = new int[arr.Length / 2];
            int[] half2 = new int[arr.Length / 2 + arr.Length % 2];
            int i, j;
            for( i=0;i<half1.Length;i++)
            {
                half1[i]= arr[i];
            }
            for (i = half1.Length, j = 0; i < arr.Length; j++, i++)
            {
                half2[j]= arr[i];
            }
            half1=MergeSort(half1);
            half2= MergeSort(half2);
            int[] toRet= new int[half1.Length+half2.Length];
            int k = 0;
            i = 0; j=0;
            while( i<half1.Length && j<half2.Length )
            {
                if (half1[i] < half2[j]) 
                {
                    toRet[k++] = half1[i];
                    i++;
                }
                else
                {
                    toRet[k++]= half2[j];
                    j++;
                }
            }
            while (i < half1.Length)
            {
                toRet[k++]= half1[i];
                i++;
            }
            while (j < half2.Length)
            {
                toRet[k++] = half2[j];
                j++;
            }
            return toRet;
        }
        private static void S36()
        {
            //alt fisier
        }
        
        private static void S37() 
        {
            //alt fisier
        }
    }
}
