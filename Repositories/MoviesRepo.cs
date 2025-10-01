using Npgsql;
using Dapper;
public class MoviesRepo
{
    private static readonly string ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION", EnvironmentVariableTarget.User)!;
    public void AddMovie(Movies movie)
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        connection.Open();
        var sql = "INSERT INTO movies(title,genre,year,score) VALUES (@Title, @Genre, @Year, @Score)";
        connection.Execute(sql, movie);
    }
    public  void UpdateMovie(Movies movie)
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        var sql = "UPDATE movies SET title = @Title, genre = @Genre, year = @Year, score = @Score WHERE id = @Id";
        connection.Execute(sql, movie);
    }
    public  void DeleteMovie(int id)
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        connection.Execute("DELETE FROM movies Where id = @Id", new { Id = id });
    }
    public  IEnumerable<Movies> ListAllMovies()
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        return connection.Query<Movies>("SELECT * FROM movies ORDER BY id");
    }
    public  Movies GetMovieById(int id)
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        return connection.QueryFirstOrDefault<Movies>("SELECT * FROM movies WHERE id = @Id", new { Id = id })!;
    }
}