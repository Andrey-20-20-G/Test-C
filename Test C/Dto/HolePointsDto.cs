using Test_C.EFCore;

namespace Test_C.Dto
{
    public class HolePointsDto
    {
        public int Id { get; set; }
        public int HoleId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
