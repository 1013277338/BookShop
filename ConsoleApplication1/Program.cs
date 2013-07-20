using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   class A

     {

          public A()

           {

                PrintFields();
                test();
           }

          public virtual void PrintFields(){}
          public virtual void test() { }
      }
   class B : A
   {

       int x = 1;

       int y;

       public B()
       {

           y = -1;

       }

       public override void test()
       {
           Console.WriteLine("B Test");
       }
       public override void PrintFields()
       {

           Console.WriteLine("x={0},y={1}", x, y);

       }

       
   }

   public abstract class aa
   {
       public void testa() { Console.WriteLine("aa"); }
       public void testb() { }
   }

   public class aaa : aa
   { 
       
   }
     

    class Program
    {
        static void Main(string[] args)
        {
           
                B b = new B();

                a();
         

            Console.ReadKey();
        }

        public static int a()
        {
            try
            {
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
               
            }
        }
    }
}
