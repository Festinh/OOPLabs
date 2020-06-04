using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TermWorkLib
{
    public class Website
    {
        private static List<Author> accounts = new List<Author>();
        private static List<List<string>> subjects = new List<List<string>>();
        private static List<List<string>> headings = new List<List<string>>();
        private static List<Article> articles = new List<Article>();
        public delegate void LogsHandler(string message);
        public static event LogsHandler Notify = (string message) =>
        {
            Directory.CreateDirectory(@"D:\Programming\C# Projects\Course1WorkProject\TermWork\logs");
            Console.WriteLine(message);
            StreamWriter sw = new StreamWriter(@"D:\Programming\C# Projects\Course1WorkProject\TermWork\logs\logs" + DateTime.Now.Day + "_" + DateTime.Now.Month + ".txt", true, Encoding.Default);
            sw.WriteLine(message + "   " + DateTime.Now.TimeOfDay);
            sw.Close();
        };

        public Website()
        {
            for (int i = 0; i < 3; i++)
            {
                headings.Add(new List<string>());
                if (i == 0) headings[i].Add("Whats new in Python");
                else if (i == 1) headings[i].Add("Where is ++");
                else if (i == 2) headings[i].Add("Assembler's graveyard");
            }
        }



        public static void Run()
        {
            int id;
            string temp;
            while (true)
            {
                id = 0;
                Console.WriteLine("\nTo log in as a guest, enter 0. \nIf you have profile, enter 1. \nIf you want to register, enter 2. \nIf you want to quit, enter 3.");
                switch (Console.ReadLine())
                {
                    case "0":
                        bool breakerG = true;
                        while (breakerG)
                        {
                            Console.WriteLine("\nWhat do you want to do? \nTo see last news, enter 0. \nTo search some news, enter 1. \nTo check someone else's profile, enter 2. \nTo quit guest mode, enter 3.");
                            switch (Console.ReadLine())
                            {
                                case "0":
                                    try
                                    {
                                        articles[articles.Count - 1].ShowArticle();
                                        articles[articles.Count - 2].ShowArticle();
                                        articles[articles.Count - 3].ShowArticle();
                                        articles[articles.Count - 4].ShowArticle();
                                        articles[articles.Count - 5].ShowArticle();
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case "1":
                                    Console.WriteLine("How do you want to search for the article? \nEnter 1, if you want to search by name. \nEnter 2, if you want to search by subject. \nEnter 3, if you want to search by heading. \nEnter 4, if you want to search by author. \nEnter 5, if you want to search by date.");
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            Console.WriteLine("Enter article's full name");
                                            FindArticle(Console.ReadLine()).ShowArticle();
                                            break;
                                        case "2":
                                            Console.WriteLine("Enter subjects's full name");
                                            int point = FindSubject(Console.ReadLine());
                                            try
                                            {
                                                ShowArticlesForSubject(point);
                                            }
                                            catch
                                            {
                                                Console.WriteLine("There is no such subject");
                                            }
                                            break;
                                        case "3":
                                            Console.WriteLine("Enter 1, if you want to search by Whats new in Python. \nEnter 2, if you want to search by Where is ++. \nEnter 3, if you want to search by Assembler's graveyard.");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    for (int i = 1; i < headings[0].Count; i++)
                                                    {
                                                        Console.WriteLine("Title: " + headings[0][i]);
                                                    }
                                                    break;
                                                case "2":
                                                    for (int i = 1; i < headings[1].Count; i++)
                                                    {
                                                        Console.WriteLine("Title: " + headings[1][i]);
                                                    }
                                                    break;
                                                case "3":
                                                    for (int i = 1; i < headings[2].Count; i++)
                                                    {
                                                        Console.WriteLine("Title: " + headings[2][i]);
                                                    }
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        case "4":
                                            Console.WriteLine("Enter author's full name");
                                            try
                                            {
                                                FindAuthor(Console.ReadLine()).ShowArticles();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("There is no such author.");
                                            }
                                            break;
                                        case "5":
                                            Console.WriteLine("Enter first date");
                                            string[] date1 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                            bool errors = false;
                                            while (date1.Length != 6)
                                            {
                                                Console.WriteLine("Error! Wrong input.");
                                                date1 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                            }

                                            for (int i = 0; i < 6; i++)
                                            {
                                                if (!int.TryParse(date1[i], out _))
                                                {
                                                    Console.WriteLine("Error! Please enter your date as in example. ");
                                                    errors = true;
                                                    break;
                                                }
                                            }
                                            while (errors)
                                            {
                                                date1 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                                errors = false;
                                                while (date1.Length != 6)
                                                {
                                                    Console.WriteLine("Error! Wrong input.");
                                                    date1 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                                }

                                                for (int i = 0; i < 6; i++)
                                                {
                                                    if (!int.TryParse(date1[i], out _))
                                                    {
                                                        Console.WriteLine("Error! Please enter your date as in example. ");
                                                        errors = true;
                                                        break;
                                                    }
                                                }
                                            }
                                            DateTime trueDate1 = new DateTime(int.Parse(date1[2]), int.Parse(date1[1]), int.Parse(date1[0]), int.Parse(date1[3]), int.Parse(date1[4]), int.Parse(date1[5]));
                                            Console.WriteLine("Enter second date");
                                            string[] date2 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                            errors = false;
                                            while (date2.Length != 6)
                                            {
                                                Console.WriteLine("Error! Wrong input.");
                                                date2 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                            }

                                            for (int i = 0; i < 6; i++)
                                            {
                                                if (!int.TryParse(date2[i], out _))
                                                {
                                                    Console.WriteLine("Error! Please enter your date as in example. ");
                                                    errors = true;
                                                    break;
                                                }
                                            }
                                            while (errors)
                                            {
                                                date2 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                                errors = false;
                                                while (date2.Length != 6)
                                                {
                                                    Console.WriteLine("Error! Wrong input.");
                                                    date2 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                                }

                                                for (int i = 0; i < 6; i++)
                                                {
                                                    if (!int.TryParse(date2[i], out _))
                                                    {
                                                        Console.WriteLine("Error! Please enter your date as in example. ");
                                                        errors = true;
                                                        break;
                                                    }
                                                }
                                            }
                                            DateTime trueDate2 = new DateTime(int.Parse(date2[2]), int.Parse(date2[1]), int.Parse(date2[0]), int.Parse(date2[3]), int.Parse(date2[4]), int.Parse(date2[5]));
                                            for (int i = 0; i < articles.Count; i++)
                                            {
                                                if (articles[i].time > trueDate1 && articles[i].time < trueDate2) Console.WriteLine(articles[i].name);
                                            }
                                            break;
                                    }
                                    break;
                                case "2":
                                    Console.WriteLine("Enter user's full name");
                                    string tp = Console.ReadLine();
                                    try
                                    {
                                        Console.WriteLine("General user info");
                                        FindAuthor(tp).DisplayUser();
                                        Console.WriteLine("User's articles:");
                                        FindAuthor(tp).ShowArticles();
                                    }
                                    catch
                                    {
                                        Console.WriteLine("There is no such author");
                                    }
                                    break;
                                case "3":
                                    breakerG = false;
                                    break;
                            }
                        }
                        break;


                    case "1":

                        Console.WriteLine("Enter your login.");
                        temp = Console.ReadLine();
                        if (FindAuthor(temp) != null)
                        {
                            id = GetID(FindAuthor(temp));
                            Console.WriteLine("Enter your password");
                            if (accounts[id].password == Console.ReadLine())
                            {
                                bool breakerA = true;
                                Console.WriteLine("You are logged in.");
                                while (breakerA)
                                {
                                    Console.WriteLine("\nWhat do you want to do? \nTo see last news, enter 0. \nTo search some news, enter 1. \nTo check someone else's profile, enter 2. \nTo write your own article, enter 3. \nTo log out of your profile, enter 4.");
                                    switch (Console.ReadLine())
                                    {
                                        case "0":
                                            try
                                            {
                                                articles[articles.Count - 1].ShowArticle();
                                                articles[articles.Count - 2].ShowArticle();
                                                articles[articles.Count - 3].ShowArticle();
                                                articles[articles.Count - 4].ShowArticle();
                                                articles[articles.Count - 5].ShowArticle();
                                            }
                                            catch
                                            {
                                            }
                                            break;
                                        case "1":
                                            Console.WriteLine("How do you want to search for the article? \nEnter 1, if you want to search by name. \nEnter 2, if you want to search by subject. \nEnter 3, if you want to search by heading. \nEnter 4, if you want to search by author. \nEnter 5, if you want to search by date.");
                                            switch (Console.ReadLine())
                                            {
                                                case "1":
                                                    Console.WriteLine("Enter article's full name");
                                                    try
                                                    {
                                                        FindArticle(Console.ReadLine()).ShowArticle();
                                                    }
                                                    catch
                                                    {

                                                    }
                                                    break;
                                                case "2":
                                                    Console.WriteLine("Enter subjects's full name");
                                                    int point = FindSubject(Console.ReadLine());
                                                    try
                                                    {
                                                        ShowArticlesForSubject(point);
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("There is no such subject");
                                                    }
                                                    break;
                                                case "3":
                                                    Console.WriteLine("Enter 1, if you want to search by Whats new in Python. \nEnter 2, if you want to search by Where is ++. \nEnter 3, if you want to search by Assembler's graveyard.");
                                                    switch (Console.ReadLine())
                                                    {
                                                        case "1":
                                                            for (int i = 1; i < headings[0].Count; i++)
                                                            {
                                                                Console.WriteLine("Title: " + headings[0][i]);
                                                            }
                                                            break;
                                                        case "2":
                                                            for (int i = 1; i < headings[1].Count; i++)
                                                            {
                                                                Console.WriteLine("Title: " + headings[1][i]);
                                                            }
                                                            break;
                                                        case "3":
                                                            for (int i = 1; i < headings[2].Count; i++)
                                                            {
                                                                Console.WriteLine("Title: " + headings[2][i]);
                                                            }
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case "4":
                                                    Console.WriteLine("Enter author's full name");
                                                    try
                                                    {
                                                        FindAuthor(Console.ReadLine()).ShowArticles();
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("There is no such author.");
                                                    }

                                                    break;
                                                case "5":
                                                    Console.WriteLine("Enter first date");
                                                    string[] date1 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                                    bool errors = false;
                                                    while (date1.Length != 6)
                                                    {
                                                        Console.WriteLine("Error! Wrong input.");
                                                        date1 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                                    }

                                                    for (int i = 0; i < 6; i++)
                                                    {
                                                        if (!int.TryParse(date1[i], out _))
                                                        {
                                                            Console.WriteLine("Error! Please enter your date as in example. ");
                                                            errors = true;
                                                            break;
                                                        }
                                                    }
                                                    while (errors)
                                                    {
                                                        date1 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                                        errors = false;
                                                        while (date1.Length != 6)
                                                        {
                                                            Console.WriteLine("Error! Wrong input.");
                                                            date1 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                                        }

                                                        for (int i = 0; i < 6; i++)
                                                        {
                                                            if (!int.TryParse(date1[i], out _))
                                                            {
                                                                Console.WriteLine("Error! Please enter your date as in example. ");
                                                                errors = true;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                    DateTime trueDate1 = new DateTime(int.Parse(date1[2]), int.Parse(date1[1]), int.Parse(date1[0]), int.Parse(date1[3]), int.Parse(date1[4]), int.Parse(date1[5]));
                                                    Console.WriteLine("Enter second date");
                                                    string[] date2 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                                    errors = false;
                                                    while (date2.Length != 6)
                                                    {
                                                        Console.WriteLine("Error! Wrong input.");
                                                        date2 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                                    }

                                                    for (int i = 0; i < 6; i++)
                                                    {
                                                        if (!int.TryParse(date2[i], out _))
                                                        {
                                                            Console.WriteLine("Error! Please enter your date as in example. ");
                                                            errors = true;
                                                            break;
                                                        }
                                                    }
                                                    while (errors)
                                                    {
                                                        date2 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                                        errors = false;
                                                        while (date2.Length != 6)
                                                        {
                                                            Console.WriteLine("Error! Wrong input.");
                                                            date2 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                                        }

                                                        for (int i = 0; i < 6; i++)
                                                        {
                                                            if (!int.TryParse(date2[i], out _))
                                                            {
                                                                Console.WriteLine("Error! Please enter your date as in example. ");
                                                                errors = true;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                    DateTime trueDate2 = new DateTime(int.Parse(date2[2]), int.Parse(date2[1]), int.Parse(date2[0]), int.Parse(date2[3]), int.Parse(date2[4]), int.Parse(date2[5]));
                                                    for (int i = 0; i < articles.Count; i++)
                                                    {
                                                        if (articles[i].time > trueDate1 && articles[i].time < trueDate2) Console.WriteLine(articles[i].name);
                                                    }
                                                    break;
                                            }
                                            break;
                                        case "2":
                                            Console.WriteLine("Enter user's full name");
                                            string tp = Console.ReadLine();
                                            FindAuthor(tp).DisplayUser();
                                            FindAuthor(tp).ShowArticles();
                                            break;
                                        case "3":
                                            accounts[id].WriteArticle();
                                            articles.Add(accounts[id].posts[accounts[id].posts.Count - 1]);
                                            for (int i = 0; i < accounts[id].posts[accounts[id].posts.Count - 1].subjects.Count; i++)
                                            {
                                                if (FindSubject(accounts[id].posts[accounts[id].posts.Count - 1].subjects[i]) == -1)
                                                {
                                                    subjects.Add(new List<string>() { accounts[id].posts[accounts[id].posts.Count - 1].subjects[i] });
                                                }
                                                subjects[FindSubject(accounts[id].posts[accounts[id].posts.Count - 1].subjects[i])].Add(accounts[id].posts[accounts[id].posts.Count - 1].name);
                                            }
                                            switch (accounts[id].posts[accounts[id].posts.Count - 1].heading)
                                            {
                                                case "Whats new in Python":
                                                    headings[0].Add(accounts[id].posts[accounts[id].posts.Count - 1].name);
                                                    break;
                                                case "Where is ++":
                                                    headings[1].Add(accounts[id].posts[accounts[id].posts.Count - 1].name);
                                                    break;
                                                case "Assembler's graveyard":
                                                    headings[2].Add(accounts[id].posts[accounts[id].posts.Count - 1].name);
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        case "4":
                                            breakerA = false;
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        break;


                    case "2":
                        Console.WriteLine("Great! Then enter your login, that everyone will see.");
                        bool breakerLog = false;
                        string login = Console.ReadLine();
                        for (int i = 0; i < accounts.Count; i++)
                        {
                            if (accounts[i].name == login)
                            {
                                Console.WriteLine("There is already an user with that login");
                                breakerLog = true;
                                break;
                            }
                        }
                        if (breakerLog) break;
                        Console.WriteLine("Now enter your password");
                        string pass = Console.ReadLine();
                        accounts.Add(new Author(login, pass));
                        Notify?.Invoke("You have successfully registered.");
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Input data is incorrect. Try again.");
                        break;
                }
            }
        }

        public static Author FindAuthor(string name)
        {
            {
                for (int i = 0; i < accounts.Count; i++)
                {
                    if (accounts[i].name == name) return accounts[i];
                }
                return null;
            }
        }

        public static int GetID(Author a)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i] == a) return i;
            }
            Console.WriteLine("There is no such user.");
            return 0;
        }

        public static int FindSubject(string subject)
        {
            for (int i = 0; i < subjects.Count; i++)
            {
                if (subjects[i][0] == subject) return i;
            }
            return -1;
        }

        public static Article FindArticle(string a)
        {
            for (int i = 0; i < articles.Count; i++)
            {
                if (a == articles[i].name) return articles[i];
            }
            Console.WriteLine("There's no such article");
            return null;
        }

        public static void ShowArticlesForSubject(int sub)
        {
            for (int i = 1; i < subjects[sub].Count; i++)
            {
                Console.WriteLine("Title: " + subjects[sub][i]);
            }
        }
    }

    public class Article
    {
        public string name { get; }
        public List<string> subjects = new List<string>();
        public string author { get; }
        public string heading { get; }
        public string text { get; }
        public DateTime time { get; }

        public Article(string author, string name)
        {
            this.name = name;
            this.author = author;
            Console.WriteLine("Add a subject to your article");
            subjects.Add(Console.ReadLine());
            while (true)
            {
                Console.WriteLine("If the article has another one subject, write 1. If not, write 0");
                try
                {
                    int temp = int.Parse(Console.ReadLine());

                    if (temp == 1)
                    {
                        Console.WriteLine("Add a subject to your article");
                        subjects.Add(Console.ReadLine());
                    }
                    else if (temp == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Number input is incorrect. Please try again.");
                    }
                }
                catch
                {
                    Console.WriteLine("Number input is incorrect. Please try again.");
                }
            }
            Console.WriteLine("Does your article belong to a heading? Enter 1, if yes. Enter 0, if no");
            switch (Console.ReadLine())
            {
                case "1":
                    bool breaker = true;
                    while (breaker)
                    {
                        Console.WriteLine("Choose a heading to your article.\nEnter 1 to choose Whats new in Python.\nEnter 2 to choose Where is ++.\nEnter 3 to choose Assembler's graveyard.");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                heading = "Whats new in Python";
                                breaker = false;
                                break;
                            case "2":
                                heading = "Where is ++";
                                breaker = false;
                                break;
                            case "3":
                                heading = "Assembler's graveyard";
                                breaker = false;
                                break;
                            default:
                                Console.WriteLine("Heading is chosen wrongly. Please, try again");
                                break;
                        }
                    }
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Number input is incorrect. Please try again.");
                    break;
            }

            Console.WriteLine("Write your article");
            text = Console.ReadLine();
            time = DateTime.Now;
        }


        public void ShowArticle()
        {
            Console.WriteLine("Title: " + name);
            Console.WriteLine("Author: " + author);
            Console.WriteLine(text);
            Console.WriteLine("Date: " + time + "\n");
        }
    }

    public abstract class User
    {
        public string name { get; }
        public string password { get; }
        public DateTime registrationDate { get; }

        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
            registrationDate = DateTime.Now;
        }

        public void DisplayUser()
        {
            Console.WriteLine("Username: " + name + "\nRegistrarion date: " + registrationDate);
        }
    }

    public class Author : User
    {
        public List<Article> posts = new List<Article>();

        public Author(string name, string password) : base(name, password) { }

        public void ShowArticles()
        {
            for (int i = 0; i < posts.Count; i++)
            {
                Console.WriteLine("Title: " + posts[i].name, posts[i].time);
            }
        }

        public void WriteArticle()
        {
            Console.WriteLine("Enter your article's name");
            posts.Add(new Article(name, Console.ReadLine()));
        }
    }
}


