using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        //Here dependency injecction is used because we registered the DbContext in Programs.cs
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;

        //Using construction injection
        public PieRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
        {
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
        }


        //Implement the methods of IPieRepository interface
        public IEnumerable<Pie> AllPies {

            get
            {
                return _bethanysPieShopDbContext.Pies.Include(c => c.Category);
            }
        }   

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _bethanysPieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
            return _bethanysPieShopDbContext.Pies.FirstOrDefault( p => p.PieId == pieId);
        }
    }
}
