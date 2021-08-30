 
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestWithASPNETUdemy.Data.VO
{
    public class PersonVO 
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("nome")]
        public string FirstName { get; set; }

        [JsonPropertyName("sobrenome")]
        public string LastName { get; set; }

        [JsonPropertyName("endereco")]
        public string Address { get; set; }

        [JsonPropertyName("genero")]
        public string Gender { get; set; }

      

     }
}
