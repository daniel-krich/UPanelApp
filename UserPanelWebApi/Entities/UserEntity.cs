using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserPanelWebApi.Entities
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class UserEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonIgnore]
        public string Password { get; set; }

        [Required]
        [MaxLength(80)]
        public string Email { get; set; }

        [Required]
        [MaxLength(128)]
        public string Description { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
