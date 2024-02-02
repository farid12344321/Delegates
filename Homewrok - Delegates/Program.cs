

using Homewrok___Delegates;
using System.Security.Cryptography.X509Certificates;

//Exam exam1 = new Exam("Az dili", new DateTime(2024, 1, 1));
//Exam exam2 = new Exam("Riyaziyyat", new DateTime(2023, 3, 4));
//Exam exam3 = new Exam("Kimya", new DateTime(2024, 2, 16));
//Exam exam4 = new Exam("Biologiya", new DateTime(2022, 10, 1));
//Exam exam5 = new Exam("Az tarix", new DateTime(2024, 12, 27));

Exam exam = new Exam();
string opt;
do
{
    Console.WriteLine("1- Add exam");
    Console.WriteLine("2- A ile baslayanlar");
    Console.WriteLine("3- Kecmis imtahanlar");
    Console.WriteLine("4- 1 ay-dan daha az vaxt sonra bas tutacaq imtahanları gosterin");
    Console.WriteLine("5- Saat 08:00-də olan imtahanları göstərin");
    Console.WriteLine("6- Kecmis tarixli imtahanları listdən silsin");
    Console.WriteLine("7- Subjecti riyaziyyat olan bir imtahanın listde olub olmadıgını yoxlayın");
    Console.WriteLine("8- Subjecti riyazzıyyat olan imtahanı gösterin");
    Console.WriteLine("0- cix");
    opt = Console.ReadLine();


    switch (opt)
    {
        case "1":
            Console.WriteLine("Subject: ");
            string subject = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(subject))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tSubject bos ola bilmez !\n");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            }

            Console.WriteLine("DateTime :");
            string datetimeStr = Console.ReadLine();
            DateTime dateTime; ;
            if (!DateTime.TryParse(datetimeStr,out dateTime))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tDuzgun date daxil edin !\n");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            }
            Exam exam1 = new Exam()
            {
                Subject = subject,
                DateTime = dateTime
            };
            exam.Exams.Add(exam1);
            break;
        case "2":
            foreach (var item in exam.Search(x => x.Subject.StartsWith('A')))
            {
                Console.WriteLine($"\t{item}\n");
            }
            break;
        case "3":
            foreach (var item in exam.Search(x => x.DateTime < DateTime.Now.Date))
            {
                Console.WriteLine($"\t{item}\n");
            }
            break;
        case "4":
            foreach (var item in exam.Search(x => x.DateTime.Date < DateTime.Now.AddMonths(1).Date))
            {
                Console.WriteLine($"\t{item}\n");
            }
            break;
        case "5":
            break;
        case "6":
            foreach (var item in exam.Search(x => x.DateTime.Date < DateTime.Now.Date))
            {
                Console.WriteLine(exam.Exams.Remove(item)); ;
            }
            break;
        case "7":
            if (exam.Find(x => x.Subject == "Riyaziyyat"))
            {
                Console.WriteLine("var");
                break;
            }
            Console.WriteLine("Yoxdur");
            break;
        case "8":
            foreach (var item in exam.Search(x=> x.Subject == "Riyaziyyat"))
            {
                Console.WriteLine($"\t{item}\n");
            }
            break;
        default:
            if (opt != "0")
            {
                Console.WriteLine("duzgun opt secin");
            }
            break;
    }

} while (opt != "0");


    


