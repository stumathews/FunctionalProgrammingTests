using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LanguageExt;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestMethod1()
        {
           

            Console.ReadKey();

            Option<int> option = new Option<int>();
            option = Option<int>.Some(23);
            
            Either<int, double> either = new Either<int, double>();
            either = 23.9;
            either.Match(d =>
            {
                Console.WriteLine("Double");
            }, i =>
            {
                Console.WriteLine("Int");
            });

            var test = either.Map(d => 'c');
            
            Console.ReadKey();
        }
    }
}
