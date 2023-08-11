using Test_C.Dto;
using Test_C.EFCore;

namespace Test_C.Services
{
    public class HoleService
    {
        private EF_DataContext _context;
        public HoleService(EF_DataContext context)
        {
            _context = context;
        }

        public List<HoleDto> GetHoles()
        {
            List<HoleDto> response = new List<HoleDto>();
            var dataList = _context.Hole.ToList();
            dataList.ForEach(row => response.Add(new HoleDto()
            {
                HoleId = row.HoleId,
                Name = row.Name,
                Depth = row.Depth
            }));
            return response;
        }

        public HoleDto GetHoleById(int id)
        {
            HoleDto response = new HoleDto();
            var row = _context.Hole.Where(d => d.HoleId.Equals(id)).FirstOrDefault();
            return new HoleDto()
            {
                HoleId = row.HoleId,
                Name = row.Name,
                Depth = row.Depth
            };
        }

        public void UpdateHole(HoleDto hole)
        {
            Hole dbTable = new Hole();
            //PUT
            dbTable = _context.Hole.Where(
                d => d.HoleId.Equals(hole.HoleId))
                .FirstOrDefault();
            if (dbTable != null)
            {
                dbTable.Name = hole.Name;
                dbTable.DrillBlock = _context.DrillBlock
                    .Where(f => f.DrillBlockId
                    .Equals(hole.DrillBlockId))
                    .FirstOrDefault();
                dbTable.Depth = hole.Depth;
                _context.SaveChanges();
            }
        }

        public void CreateHole(HoleDto hole)
        {
            Hole dbTable = new Hole();
            //POST
            dbTable = _context.Hole.Where(
                d => d.HoleId.Equals(hole.HoleId))
                .FirstOrDefault();
            if (dbTable == null)
            {
                dbTable = new Hole()
                {
                    HoleId = hole.HoleId,
                    DrillBlock = _context.DrillBlock
                    .Where(f => f.DrillBlockId
                    .Equals(hole.DrillBlockId))
                    .FirstOrDefault(),
                    Name = hole.Name,
                    Depth = hole.Depth,
                };
                _context.Hole.Add(dbTable);
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void DeleteHole(int id)
        {
            var hole = _context.Hole.Where(d => d.HoleId.Equals(id)).FirstOrDefault();
            if (hole != null)
            {
                _context.Hole.Remove(hole);
                _context.SaveChanges();
            }
        }
    }
}
