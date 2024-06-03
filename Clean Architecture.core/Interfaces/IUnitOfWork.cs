
using charityPulse.core.Models;
using Clean_Architecture.Application.Interfaces;
using Clean_Architecture.Infrastructure.Repositories;


namespace Clean_Architecture.core.Interfaces
{
    public interface IUnitOfWork
    {

        public IRepository<Project> projects { get; }
        public IDonationReportRepository DonationReportRepository { get; }

        public IRepository<Corporate> corporations { get; }



        IReviewRepository ReviewRepository { get; }


        public int save();
        public void Dispose();
    }
}
