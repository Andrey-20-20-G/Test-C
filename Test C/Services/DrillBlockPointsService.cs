using Test_C.Dto;
using Test_C.EFCore;

namespace Test_C.Services
{
    public class DrillBlockPointsService
    {
        private EF_DataContext _context;
        public DrillBlockPointsService(EF_DataContext context)
        {
            _context = context;
        }

        public List<DrillBlockPointsDto> GetDrillBlockPoints()
        {
            List<DrillBlockPointsDto> response = new List<DrillBlockPointsDto>();
            var dataList = _context.DrillBlockPoints.ToList();
            dataList.ForEach(row => response.Add(new DrillBlockPointsDto()
            {
                Id = row.Id,
                Sequence = row.Sequence,
                X = row.X,
                Y = row.Y,
                Z= row.Z,
            }));
            return response;
        }

        public DrillBlockPointsDto GetDrillBlockPointsById(int id)
        {
            DrillBlockPointsDto response = new DrillBlockPointsDto();
            var row = _context.DrillBlockPoints.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (row == null)
                return null;
            return new DrillBlockPointsDto()
            {
                Id = row.Id,
                Sequence = row.Sequence,
                X = row.X,
                Y = row.Y,
                Z = row.Z,
            };

        }
        /// <summary>
        /// It serves the POST/PUT/PATCH
        /// </summary>
        public void UpdateDrillBlockPoints(DrillBlockPointsDto drillBlockPoints)
        {
            DrillBlockPoints dbTable = new DrillBlockPoints();
            //PUT
            dbTable = _context.DrillBlockPoints.Where(
                d => d.Id.Equals(drillBlockPoints.Id))
                .FirstOrDefault();
            if (dbTable != null)
            {
                dbTable.Sequence = drillBlockPoints.Sequence;
                dbTable.X = drillBlockPoints.X;
                dbTable.Y = drillBlockPoints.Y;
                dbTable.Z = drillBlockPoints.Z;
                dbTable.DrillBlock = _context.DrillBlock
                    .Where(f => f.DrillBlockId
                    .Equals(drillBlockPoints.DrillBlockId))
                    .FirstOrDefault();
                _context.SaveChanges();
            }
        }

        public void CreateDrillBlockPoint(DrillBlockPointsDto drillBlockPoints)
        {
            DrillBlockPoints dbTable = new DrillBlockPoints();
            //POST
            dbTable = _context.DrillBlockPoints.Where(
                d => d.Id.Equals(drillBlockPoints.Id))
                .FirstOrDefault();
            if (dbTable == null)
            {
                dbTable = new DrillBlockPoints()
                {
                    Sequence = drillBlockPoints.Sequence,
                    X = drillBlockPoints.X,
                    Y = drillBlockPoints.Y,
                    Z = drillBlockPoints.Z,
                    DrillBlock = _context.DrillBlock
                    .Where(f => f.DrillBlockId
                    .Equals(drillBlockPoints.DrillBlockId))
                    .FirstOrDefault(),
                };
                _context.DrillBlockPoints.Add(dbTable);
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void DeleteDrillBlockPoint(int id)
        {
            var drillBlockPoint = _context.DrillBlockPoints.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (drillBlockPoint != null)
            {
                _context.DrillBlockPoints.Remove(drillBlockPoint);
                _context.SaveChanges();
            }
        }
    }
}
