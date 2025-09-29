namespace MyMovieList
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to My Movies List!!");
            Console.WriteLine("The personal App where you can save your favorite movies and set your own personal scores.\n");
            Console.WriteLine("1.Add a new movie.\n2.Update a movie.\n3.Show all your movies.\n4.Find movie by ID.\n5.Delete movie :'(\n6.Exit...");
            int op;
            while (!int.TryParse(Console.ReadLine(), out op))
            {
                Console.WriteLine("Invalid option!");
            }

            switch (op)
            {
                case(1):MovieOptions.Add();break;
                case(2):MovieOptions.Update();break;
                case(3):MovieOptions.ListAll();break;
                case(4):MovieOptions.GetMovie();break;
                case(5):MovieOptions.Delete();break;
                case(6):Environment.Exit(0);break;
                
                default:Console.WriteLine("INVALID OPTION!");break;
            }
        }
    }
}
