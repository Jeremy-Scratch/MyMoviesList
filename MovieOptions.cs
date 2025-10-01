public static class MovieOptions
{
    private static MoviesRepo mv = new MoviesRepo();
    public static void Add()
    {
        int year;
        double score;
        Console.WriteLine("Enter the movie name");
        string name = Console.ReadLine()!;
        Console.WriteLine("Enter the movie genre");
        string genre = Console.ReadLine()!;
        Console.WriteLine("Enter the movie Year");
        while (!int.TryParse(Console.ReadLine(), out year))
        {
            Console.WriteLine("Invalid input!");
        }
        Console.WriteLine("Enter the movie Score");
        while (!double.TryParse(Console.ReadLine(), out score) && !(score <= 10 ))
        {
            Console.WriteLine("Invalid input!");
        }
        Movies movie = new Movies
        {
            Name = name,
            Genre = genre,
            Year = year,
            Score = score
        };
        mv.AddMovie(movie);
        Console.WriteLine("Movie added Succesfully!\n");
    }
    public static void Update()
    {
        int id;
        Console.WriteLine("Enter the movie Id to Update...");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid ID!");
        }
        var movie = mv.GetMovieById(id);
        Console.WriteLine($"Updating Id. {movie.Id} Name: {movie.Name}.");

        Console.WriteLine("Enter the movie Name");
        string name = Console.ReadLine()!;
        Console.WriteLine("Enter the movie Genre");
        string genre = Console.ReadLine()!;
        Console.WriteLine("Enter the movie Year");
        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Invalid input!");
        }
        Console.WriteLine("Enter the movie Score");
        if (!double.TryParse(Console.ReadLine(), out double score))
        {
            Console.WriteLine("Invalid input!");
        }
        Movies updatedMovie = new Movies
        {
            Id = id,
            Name = name,
            Genre = genre,
            Year = year,
            Score = score
        };
        mv.UpdateMovie(updatedMovie);
        Console.WriteLine("Movie updated Succesfully!\n");    
    }
    public static void Delete()
    {
        Console.WriteLine("Enter the movie Id to Delete...");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID!");
        }
        var movie = mv.GetMovieById(id);
        Console.WriteLine($"Deleting Id. {movie.Id} Name: {movie.Name}.");
        mv.DeleteMovie(id);        
    }
    public static void ListAll()
    {
        List<Movies> movies = (List<Movies>)mv.ListAllMovies();
        foreach (var movie in movies)
        {
            Console.WriteLine($"ID: {movie.Id} Title: {movie.Name} Genre: {movie.Genre} Year: {movie.Year} Score: {movie.Score}");
        }
    }
    public static void GetMovie()
    {
        int id;
        Console.WriteLine("Enter the movie Id...");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid ID!");
        }
        var movie = mv.GetMovieById(id);
        Console.WriteLine($"Movie Id. {movie.Id} Title: {movie.Name} Genre: {movie.Genre} Year: {movie.Year} Score: {movie.Score}.");
    }
}