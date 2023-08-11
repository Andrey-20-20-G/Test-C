using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_C.EFCore
{
    [Table("holePoints")]
    public class HolePoints
    {
        [Key, Required]
        public int Id { get; set; }
        public virtual Hole Hole { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
