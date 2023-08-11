using Test_C.Dto;
using Test_C.EFCore;

namespace Test_C.Services
{
    public class HolePointsService
    {
        private EF_DataContext _context;
        public HolePointsService(EF_DataContext context)
        {
            _context = context;
        }

        public List<HolePointsDto> GetHolePoints()
        {
            List<HolePointsDto> response = new List<HolePointsDto>();
            var dataList = _context.HolePoints.ToList();
            dataList.ForEach(row => response.Add(new HolePointsDto()
            {
                Id= row.Id,
                HoleId= row.Id,
                X = row.X,
                Y = row.Y,
                Z = row.Z,
            }));
            return response;
        }

        public HolePointsDto GetHolePointsById(int id)
        {
            HolePointsDto response = new HolePointsDto();
            var row = _context.HolePoints.Where(d => d.Id.Equals(id)).FirstOrDefault();
            return new HolePointsDto()
            {
                Id = row.Id,
                HoleId = row.Id,
                X = row.X,
                Y = row.Y,
                Z = row.Z,
            };
        }

        public void UpdateHolePoints(HolePointsDto holePoint)
        {
            HolePoints dbTable = new HolePoints();
            //PUT
            dbTable = _context.HolePoints.Where(
                d => d.Id.Equals(holePoint.HoleId))
                .FirstOrDefault();
            if (dbTable != null)
            {
                 dbTable.Hole = _context.Hole
                    .Where(f => f.HoleId
                    .Equals(holePoint.HoleId))
                    .FirstOrDefault();
                dbTable.X = holePoint.X;
                dbTable.Y = holePoint.Y;
                dbTable.Z = holePoint.Z;
                _context.SaveChanges();
            }
        }

        public void CreateHolePoints(HolePointsDto holePoint)
        {
            HolePoints dbTable = new HolePoints();
            //POST
            dbTable = _context.HolePoints.Where(
                d => d.Id.Equals(holePoint.Id))
                .FirstOrDefault();
            if (dbTable == null)
            {
                dbTable = new HolePoints()
                {
                    Id = holePoint.Id,
                    Hole = _context.Hole
                    .Where(f => f.HoleId
                    .Equals(holePoint.HoleId))
                    .FirstOrDefault(),
                    /*Hole = new Hole()
                    {
                        HoleId = holePoint.HoleId
                    },*/
                    X = holePoint.X,
                    Y = holePoint.Y,
                    Z = holePoint.Z,
                };
                _context.HolePoints.Add(dbTable);
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void DeleteHolePoints(int id)
        {
            var holePoint = _context.HolePoints.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (holePoint != null)
            {
                _context.HolePoints.Remove(holePoint);
                _context.SaveChanges();
            }
        }
    }
}
