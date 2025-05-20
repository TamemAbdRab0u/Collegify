using Collegify.Models;

namespace Collegify.Repository
{
    public class FeeRepo : Repo<Fee>, IFeeRepo
    {
        AppDbContext context;
        public FeeRepo(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Fee fee)
        {
            context.Fees.Update(fee);
        }
    }
}
