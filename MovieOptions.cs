public static class MovieOptions
{
    private static MoviesRepo mv = new MoviesRepo();
    public static void Add()
    {
        Console.WriteLine("Enter the movie name");
        string movieName = Console.ReadLine()!;
        Console.WriteLine("Enter the movie genre");
        string mgenre = Console.ReadLine()!;
        Console.WriteLine("Enter the movie Year");
        if (!int.TryParse(Console.ReadLine(), out int myear))
        {
            Console.WriteLine("Invalid input!");
        }
        Console.WriteLine("Enter the movie Score");
        if (!double.TryParse(Console.ReadLine(), out double mscore))
        {
            Console.WriteLine("Invalid input!");
        }
        Movies movie = new Movies
        {
            Movie_Name = movieName,
            Movie_Genre = mgenre,
            Movie_Year = myear,
            Movie_Score = mscore
        };
        mv.AddRepo(movie);
        Console.WriteLine("Movie added Succesfully!");
    }
    public static void Update()
    {
        Console.WriteLine("Enter the movie Id to Update...");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID!");
        }
        var movie = mv.GetMovieRepo(id);
        Console.WriteLine($"Updating Id. {movie.Id} Name: {movie.Movie_Name}.");

        Console.WriteLine("Enter the movie Name");
        string movieName = Console.ReadLine()!;
        Console.WriteLine("Enter the movie Genre");
        string mgenre = Console.ReadLine()!;
        Console.WriteLine("Enter the movie Year");
        if (!int.TryParse(Console.ReadLine(), out int myear))
        {
            Console.WriteLine("Invalid input!");
        }
        Console.WriteLine("Enter the movie Score");
        if (!double.TryParse(Console.ReadLine(), out double mscore))
        {
            Console.WriteLine("Invalid input!");
        }
        Movies newmovie = new Movies
        {
            Movie_Name = movieName,
            Movie_Genre = mgenre,
            Movie_Year = myear,
            Movie_Score = mscore
        };
        mv.UpdateRepo(newmovie);
        Console.WriteLine("Movie updated Succesfully!");
    }
    public static void Delete()
    {
        Console.WriteLine("Enter the movie Id to Delete...");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID!");
        }
        var movie = mv.GetMovieRepo(id);
        Console.WriteLine($"Deleting Id. {movie.Id} Name: {movie.Movie_Name}.");
        mv.DeleteRepo(id);
    }
    public static void ListAll()
    {
        List<Movies> movies = (List<Movies>)mv.ListAllRepo(); 
        foreach (var movie in movies)
        {
            Console.WriteLine($"ID: {movie.Id} Title: {movie.Movie_Name} Genre: {movie.Movie_Genre} Year: {movie.Movie_Year} Score: {movie.Movie_Score}");
        }
    }
    public static void GetMovie()
    {
        Console.WriteLine("Enter the movie Id...");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID!");
        }
        var movie = mv.GetMovieRepo(id);
        Console.WriteLine($"Movie Id. {movie.Id} Title: {movie.Movie_Name} Genre: {movie.Movie_Genre} Year: {movie.Movie_Year} Score: {movie.Movie_Score}.");

    }
}