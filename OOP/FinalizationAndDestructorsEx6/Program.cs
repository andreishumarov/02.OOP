﻿using System.Security.Cryptography;
using System.Threading;
using System.Text;
class Program
{
    private static void Main()
    {
        Console.WriteLine("Order of Destructor and Constructor execution: ");
        var common = new CommonClass();
        common.Destroyer();
        Console.WriteLine("\nCalling GC explicitly...");
        GC.Collect();

        Thread.Sleep(5000);

        Console.WriteLine("\n\nDestructor and an object with SuppressFinalize: ");
        var commonClass = new CommonClass();
        commonClass.PreventDestroyer();
        Console.WriteLine("\nCalling GC explicity...");
        GC.Collect();

        Console.ReadKey();
    }
}
public class CommonClass
{
    public CommonClass() 
    {
        Console.WriteLine("CommonClass constructor is called");
    }
    ~CommonClass() => Console.WriteLine("CommonClass destructor is called");
    public void Destroyer()
    {
        Console.WriteLine("Destroyer() method of Common class is called");
        var _object = new DerivedClass();
    }
    public void PreventDestroyer()
    {
        Console.WriteLine("PreventDestroyer() method of Commo class is called");
         var _object = new DerivedClass();
    }
}
public abstract class BaseClass
{
    public BaseClass() 
    {
        Console.WriteLine("BaseClass constructor is called");
    }
    ~BaseClass()
        {
        Console.WriteLine("BaseClass destructor is called");
    }
}
public class ParentClass : BaseClass
{
    public ParentClass()
    {
        Console.WriteLine("ParentClass constructor is called");
    }
    ~ParentClass()
    {
        Console.WriteLine("ParentClass destructor is called");
    }
}
public sealed class DerivedClass : ParentClass
{
    public DerivedClass()
    {
        Console.WriteLine("DerivedClass constructor is called");
    }
    ~DerivedClass()
    {
        Console.WriteLine("DerivedClass destructor is called");
    }
}