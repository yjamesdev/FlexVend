    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    namespace Backend.Models
    {

        public class Companies
        {
            public enum CompanyStatus
            {
                Active = 1,
                NoActive = 2
            }

            [Key]
            [JsonIgnore]
            public int Id { get; set; }
            public byte[] Photo { get; set; } = new byte[0];
            [MaxLength(50)]
            public string CodCompanies { get; set; } = string.Empty;
            [MaxLength(255)]
            public string Name { get; set; } = string.Empty;
            [MaxLength(255)]
            public string Rnc { get; set; } = string.Empty;
            [MaxLength(255)]
            public string Addres { get; set; } = string.Empty;
            [MaxLength(255)]
            public string PhoneNumber { get; set; } = string.Empty;
            [MaxLength(255)]
            public string Email { get; set; } = string.Empty;
            [EnumDataType(typeof(CompanyStatus))]
            [NotMapped]
            public CompanyStatus status { get; set; } = CompanyStatus.Active;
            [MaxLength(255)]
            public string Web { get; set; } = string.Empty;
            [MaxLength(255)]
            public string zipcode { get; set; } = string.Empty;
            public int CityId { get; set; }
            public int CountryId { get; set; }
            public int StateId { get; set; }
            public DateTime DateUpdate { get; set; } = DateTime.UtcNow;
            public DateTime DateCreation { get; set; } = DateTime.UtcNow;
        }
    }
