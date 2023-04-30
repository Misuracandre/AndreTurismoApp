using AndreTurismoApp.Models;
using AndreTurismoApp.Models.DTO;

namespace AndreTurismoApp.Models
{
    public class Address
    {
        //public readonly static string POST = "INSERT INTO Address (Street, Number, Neighborhood, ZipCode, Extension, IdCity) VALUES (@Street, @Number, @Neighborhood, @ZipCode, @Extension, @IdCity); SELECT CAST(scope_identity() AS INT)";
        //public readonly static string PUT = "UPDATE Address SET Nome = @Nome, Number = @Number, @Neighborhood = @Neighborhood, ZipCode = @ZipCode, Extension = @Extension, IdCity = @IdCity WHERE Id = @Id";
        //public readonly static string DELETE = "DELETE FROM Address where Id = @Id";
        //public readonly static string GET = "SELECT a.Id, a.Street, a.Number, a.Neighborhood, a.ZipCode, a.Extension, a.IdCity, c.Description FROM Address a INNER JOIN City c on a.IdCity = c.Id";
        //public readonly static string GETBYID = "SELECT a.Id, a.Street, a.Number, a.Neighborhood, a.ZipCode, a.Extension, a.IdCity, c.Description FROM Address a INNER JOIN City c ON a.IdCity = c.Id WHERE Id = @Id";
        public int Id { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public City IdCity { get; set; }


        public Address() { }

        public Address(ViaCepAddressDto viaCepAddressDto)
        {
            this.Street = viaCepAddressDto.Logradouro;
            this.Neighborhood = viaCepAddressDto.Bairro;
            this.ZipCode = viaCepAddressDto.Cep;
            this.IdCity = new City() { Description = viaCepAddressDto.Localidade };
        }
    }
}