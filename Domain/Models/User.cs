namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int ID { get; set; }

        [StringLength(70)]
        public string Email { get; set; }

        [StringLength(70)]
        public string Password { get; set; }

        [StringLength(20)]
        public string Role { get; set; }
    }
}
