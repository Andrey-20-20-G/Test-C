using Test_C.Dto;
using Test_C.EFCore;

namespace Test_C.Services
{
    public class DrillBlockService
    {
        private EF_DataContext _context;
        public DrillBlockService(EF_DataContext context)
        {
            _context = context;
        }

        public List<DrillBlockDto> GetDrillBlocks()
        {
            List<DrillBlockDto> response = new List<DrillBlockDto>();
            var dataList = _context.DrillBlock.ToList();
            dataList.ForEach(row => response.Add(new DrillBlockDto()
            {
                DrillBlockId = row.DrillBlockId,
                DrillBlockName = row.DrillBlockName,
                UpdateDate = row.UpdateDate
            }));
            return response;
        }

        public DrillBlockDto GetDrillBlocksById(int id)
        {
            DrillBlockDto response = new DrillBlockDto();
            var row = _context.DrillBlock.Where(d => d.DrillBlockId.Equals(id)).FirstOrDefault();
            if (row == null) 
                return null;
            return new DrillBlockDto()
            {
                DrillBlockId = row.DrillBlockId,
                DrillBlockName = row.DrillBlockName,
                UpdateDate = row.UpdateDate
            };
            
        }
        /// <summary>
        /// It serves the POST/PUT/PATCH
        /// </summary>
        public void UpdateDrillBlocks(DrillBlockDto drillBlock)
        {
            DrillBlock dbTable = new DrillBlock();
                //PUT
                dbTable = _context.DrillBlock.Where(
                    d => d.DrillBlockId.Equals(drillBlock.DrillBlockId))
                    .FirstOrDefault();
            if (dbTable != null)
            {
                 dbTable.DrillBlockName = drillBlock.DrillBlockName;
                 dbTable.UpdateDate = drillBlock.UpdateDate;
                _context.SaveChanges();
            }  
        }

        public void CreateDrillBlocks(DrillBlockDto drillBlock)
        {
            DrillBlock dbTable = new DrillBlock();
            //POST
            dbTable = _context.DrillBlock.Where(
                d => d.DrillBlockId.Equals(drillBlock.DrillBlockId))
                .FirstOrDefault();
            if (dbTable == null)
            {
                dbTable = new DrillBlock()
                {
                    DrillBlockId = drillBlock.DrillBlockId,
                    UpdateDate = drillBlock.UpdateDate,
                    DrillBlockName = drillBlock.DrillBlockName,
                };
                _context.DrillBlock.Add(dbTable);
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void DeleteDrillBlock(int id)
        {
            var drillBlock = _context.DrillBlock.Where(d => d.DrillBlockId.Equals(id)).FirstOrDefault();
            if (drillBlock != null)
            {
                _context.DrillBlock.Remove(drillBlock);
                _context.SaveChanges();
            }
        }
    }
}
