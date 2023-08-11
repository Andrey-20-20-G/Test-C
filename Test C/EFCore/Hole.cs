using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_C.EFCore
{
    [Table("hole")]
    public class Hole
    {
        [Key, Required]
        public int HoleId { get; set; }
        public virtual DrillBlock DrillBlock { get; set; }
        public string Name { get; set; } = string.Empty;

        public float Depth { get; set; }
    }
}
