
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAsp.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
