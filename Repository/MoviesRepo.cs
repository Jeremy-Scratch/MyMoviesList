using Npgsql;
using Dapper;
public class MoviesRepo
{
    private static readonly string ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION", EnvironmentVariableTarget.User)!;
    public void AddRepo(Movies movie)
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        connection.Open();
        var sql = "INSERT INTO movies(movie_name,movie_genre,movie_year,movie_score) VALUES (@MovieName,@Mgenre,@Myear,@Mscore)";
        connection.Execute(sql, movie);
    }
    public  void UpdateRepo(Movies movie)
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        var sql = "UPDATE movies SET movie_name = @MovieName, movie_genre = @Mgenre, movie_year = @Myear, movie_score = @Mscore WHERE id = @Id";
        connection.Execute(sql, movie);
    }
    public  void DeleteRepo(int id)
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        connection.Execute("DELETE FROM movies Where id = @Id", new { Id = id });
    }
    public  IEnumerable<Movies> ListAllRepo()
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        return connection.Query<Movies>("SELECT id, movie_name, movie_genre, movie_year, movie_score FROM movies ORDER BY id");
    }
    public  Movies GetMovieRepo(int id)
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        return connection.QueryFirstOrDefault<Movies>("SELECT id, movie_name, movie_genre, movie_year, movie_score FROM movies WHERE id = @Id", new { Id = id })!;
    }
}