using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace AssemblyA
{
    internal class MyClass
    {
        internal MyClass()
        {
            Console.WriteLine("Internal constructor called.");
        }

        internal void MyMethod()
        {
            Console.WriteLine("Internal method called.");
        }
    }
}

namespace AssemblyB
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Assembly assemblyA = Assembly.LoadFile(@"Path\To\AssemblyA.dll");

            
            Type myClassType = assemblyA.GetType("AssemblyA.MyClass");

            if (myClassType != null)
            {
                
                object myClassInstance = Activator.CreateInstance(myClassType, nonPublic: true);

                
                MethodInfo myMethod = myClassType.GetMethod("MyMethod", BindingFlags.Instance | BindingFlags.NonPublic);
                if (myMethod != null)
                {
                    myMethod.Invoke(myClassInstance, null);
                }
            }
            else
            {
                Console.WriteLine("Type not found in Assembly A.");
            }
        }
    }
}
