namespace AndreTurismoApp.Models
{
    public class City
    {
        //public readonly static string POST = "INSERT INTO City (Description) VALUES (@Description); SELECT CAST(scope_identity() AS INT)";
        //public readonly static string PUT = "UPDATE City SET Description = @Description WHERE Id = @Id";
        //public readonly static string DELETE = "DELETE FROM City where Id = @Id";
        //public readonly static string GET = "SELECT c.Id, c.Description FROM City c";
        //public readonly static string GETBYID = "SELECT c.Id, c.Description FROM City c WHERE Id = @Id";
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
