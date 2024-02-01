using System;
using System.Collections.Generic;

namespace Login
{
    internal static class User
    {

        //Dichiarazione Variabili + metodi set e get
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string ConfirmPassword { get; set; }
        public static bool IsLoggedIn = false;

        public static List<DateTime> Access { get; set; } = new List<DateTime>();
        public static DateTime LastLogin { get; set; }


        //MENU delle operazioni

        public static void Menu()
        {
            Console.WriteLine("===============OPERAZIONI==============");
            Console.WriteLine("Scegli l'operazione da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Lista degli accessi");
            Console.WriteLine("5.: Esci");
            Console.WriteLine("========================================");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Logout();
                    break;
                case "3":
                    CheckAccess();
                    break;
                case "4":
                    AccessList();
                    break;
                case "5":
                    Console.WriteLine("Alla prossima!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Errore nella selezione, prego riporvare!");
                    Menu();
                    break;
            }
        }

        //METODO STATICO LOGIN 

        public static void Login()
        {
            //Controlla se non stai richiamando questo metodo una volta che sei gia loggato
            if (IsLoggedIn == true)
            {
                Console.WriteLine("Sei già loggato");
            }
            else
            {
                //Se non lo sei faccio inserire i dati 

                Console.WriteLine("Inserisci Username");
                Username = Console.ReadLine();
                Console.WriteLine("Inserisci Password");
                Password = Console.ReadLine();
                Console.WriteLine("Conferma Password");
                ConfirmPassword = Console.ReadLine();

                //controllo che username e password siano diversi da null e che password e confirm siiano identiche

                if (Username != null && Password == ConfirmPassword && Password != null && ConfirmPassword != null)
                {
                    IsLoggedIn = true;
                    LastLogin = DateTime.Now;
                    Access.Add(LastLogin);
                    Console.WriteLine("Login avvenuto con successo");

                }
                else
                {

                    //Altrimenti torna al login e lo faccio rirpovare

                    Console.WriteLine("Le password non corrispondo riprova!");
                    Login();
                }
            }
            Menu();
        }


        //METODO STATICO LOGIN 

        public static void Logout()
        {
            //controllo nuovamente che non sia loggato nel caso voglia fare il logout se non lo è lo avverto e lo rimando a LOGIN
            if (IsLoggedIn == false)
            {
                Console.WriteLine("Non sei loggato effettua il login prima di fare il logout");
                Login();
            }
            else
            {
                //altrimenti pulisco i campi e lo rimando al Menu e setto bool del login a false
                IsLoggedIn = false;
                Console.WriteLine($"A presto {Username}");
                Username = "";
                Password = "";
                Menu();
            }
        }


        //METODO STATICO CHE CONTROLLA ULTIMO ACCESSO

        public static void CheckAccess()
        {
            if (IsLoggedIn == false)
            {
                //Anche qui controllo che sia loggato prima se non lo è lo rimando al login
                Console.WriteLine("Effettuare il login prima");
                Login();
            }
            else { Console.WriteLine($"Ultimo accesso di {Username} alle {LastLogin}"); }
            Menu();
        }


        //METODO STATICO CHE CHECKA TUTTI GLI ACCESSI SALVATI NEL LOGIN

        public static void AccessList()
        {
            foreach (DateTime item in Access)
            {
                Console.WriteLine($"Accesso alle {item}");
            }
            Menu();
        }
    }
}
