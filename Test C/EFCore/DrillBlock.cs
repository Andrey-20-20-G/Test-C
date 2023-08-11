using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_C.EFCore
{
    [Table("drillBlock")]
    public class DrillBlock
    {
        [Key, Required]
        public int DrillBlockId { get; set; }
        public string DrillBlockName { get;set; } = string.Empty;
        public DateTime? UpdateDate { get; set; }
    }
}
