﻿using System.Collections.Generic;
using RuleBasedEngine.Models.Interfaces;
using RuleBasedEngine.Models;
using System;

namespace RuleBasedEngine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var rule = RuleEngine.CreateRule<Person, Club>()
                        .If<Person>(p => p.Age).GreaterThan(18)
                        .AndIf<Club>(c => c.IsOpen).IsTrue()
                        .Then<Person, Club>(p => p.GoToClub);

            Console.WriteLine("--[rules]-------------------------------");
            Console.WriteLine(rule);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();

            var people = new List<Person>
            {
                new Person{ Name = "Anas", Age = 15 },
                new Person{ Name = "Ahmed", Age = 31 },
                new Person{ Name = "Sameh", Age = 54 },
                new Person{ Name = "Janna", Age = 9 }
            };

            var club = new Club
            {
                Name = "The Club",
                IsOpen = true
            };

            people.ForEach(person =>
            {
                Console.WriteLine($"--[person {people.IndexOf(person) + 1}]----------------------------");
                Console.WriteLine(person);
                Console.WriteLine(club);
                //Console.WriteLine($"--[rule {rules.IndexOf(rule) + 1}]------------------------------");
                var match = rule.Match(person, club);
                Console.WriteLine(match);
                match.Execute();
                //Console.WriteLine("----------------------------------------");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine();
            });
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsAdult { get { return Age > 18; } }
        public void GoToClub()
        {
            Console.WriteLine($"{Name} went to the club");
        }

        public override string ToString()
        {
            return $"Person whose name is {Name}, age is {Age}, and is {(IsAdult ? string.Empty : "not ")}adult";
        }
    }
    public class Club
    {
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public void OpenClub()
        {
            IsOpen = true;
        }
        public void CloseClub()
        {
            IsOpen = false;
        }

        public override string ToString()
        {
            return $"Club whose name is {Name}, is {(IsOpen ? string.Empty : "not ")}open";
        }
    }
}
