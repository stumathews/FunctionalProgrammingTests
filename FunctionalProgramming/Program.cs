using System;
using System.Collections.Immutable;
using System.Runtime.Remoting.Messaging;
using LanguageExt;
using LanguageExt.DataTypes.Serialisation;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Stuart", "Maathews")
                .Rename("PETER")
                .Rename("Chris");
            Console.WriteLine($"name: {person.FirstName} surname: {person.LastName}" );
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

    /// <summary>
    /// This is an immutable object because:
    /// a) Has private setters and that means its state cannot be changed after creation
    /// b) All properties are immutable - either strings or native types or System.Collections.Immutable types
    /// c) Any change that needs to take place must result in a newly create object of this type
    /// </summary>
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// Change a property of an object. Create a new version of that object  with the modification applied at object creation
        /// Rename a Person results in a change which has to create a new object of this type
        /// </summary>
        /// <remarks>A) This is a pure function: it does not call any non-pure functions or use any other data than the arguments passed to it.
        /// B) functions should be declared separately from the data they act upon, like it is</remarks>
        /// <param name="person"></param>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public static Person Rename(Person person, string firstName)
        {
            return person.With(firstName: firstName);
        }

        // Instance method allows this function to be chained.
        // With Helper to make object creation easier as properties of the object change
        public Person With(string firstName = null, string lastName = null)
        {
            return new Person(firstName ?? this.FirstName, lastName ?? this.LastName);
        }
    }

    // Extension methods allow us to chain non-instance method calls,
    public static class PersonExtensions
    {
        /// <summary>
        /// Functional because 
        /// A) it does not call any non-pure functions or use any other data than the arguments(with are immutable) passed to it.
        /// B) functions should be declared separately from the data they act upon, like it is
        /// C) Creates a new Object 
        /// </summary>
        /// <param name="person"></param>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public static Person Rename(this Person person, string firstName)
        {
            return person.With(firstName: firstName);
        }
    }

}
