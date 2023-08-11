using Test_C.EFCore;

namespace Test_C.Dto
{
    public class DrillBlockPointsDto
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public int DrillBlockId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
