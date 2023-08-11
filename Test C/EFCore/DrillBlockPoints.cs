using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_C.EFCore
{
    [Table("drillBlockPoints")]
    public class DrillBlockPoints
    {
        [Key, Required]
        public int Id { get; set; }
        public virtual DrillBlock DrillBlock { get; set; }
        public int Sequence { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
