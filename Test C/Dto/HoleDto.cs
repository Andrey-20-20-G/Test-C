using Test_C.EFCore;

namespace Test_C.Dto
{
    public class HoleDto
    {
        public int HoleId { get; set; }
        public int DrillBlockId { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Depth { get; set; }
    }
}
