namespace AndreTurismoApp.Models
{
    public class Client
    {

        //public readonly static string POST = "INSERT INTO Client (Name, Phone, IdAddress) VALUES (@Name, @Phone, @IdAddress); SELECT CAST(scope_identity() AS INT)";
        //public readonly static string PUT = "UPDATE Client SET Name = @Name, Phone = @Phone, @IdAddress = @IdAddress WHERE Id = @Id";
        //public readonly static string DELETE = "DELETE FROM Client where Id = @Id";
        //public readonly static string GET = "SELECT c.Id, c.Name, c.Phone, c.IdAddress, a.Id, a.Street, a.Number, a.Neighborhood, a.ZipCode, a.Extension, a.IdCity, s.Description FROM Client c INNER JOIN Address a ON c.IdAddress = a.Id INNER JOIN City s ON a.IdCity = c.Id";
        //public readonly static string GETBYID = "SELECT c.Id, c.Name, c.Phone, c.IdAddress, a.Id, a.Street, a.Number, a.Neighborhood, a.ZipCode, a.Extension, a.IdCity, s.Description FROM Client c INNER JOIN Address a ON c.IdAddress = a.Id INNER JOIN City s ON a.IdCity = s.Id WHERE Id = @Id";
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Address IdAddress { get; set; }
    }
}
