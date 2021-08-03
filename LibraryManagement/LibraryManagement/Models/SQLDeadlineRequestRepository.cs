using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;

namespace EmployeeManagement.Models
{
    public class SQLDeadlineRequestRepository : IDeadlineRequestRepository
    {
        private readonly AppDbContext context;
        public SQLDeadlineRequestRepository(AppDbContext context)
        {
            this.context = context;
        }
        public DeadlineRequest Add(DeadlineRequest request)
        {
            context.DeadlineRequests.Add(request);
            context.SaveChanges();
            return request;
        }

        public DeadlineRequest Delete(int id)
        {
            DeadlineRequest request = context.DeadlineRequests.Find(id);
            if(request != null)
            {
                context.DeadlineRequests.Remove(request);
                context.Entry(request).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
            return request;
        }

        public IEnumerable<DeadlineRequest> GetPendingRequest()
        {
            return context.DeadlineRequests.ToList().Where(request => request.RequestStatus.ToString() == "Pending");
        }

        public bool IsBookOfUserRequested(int borrowedId)
        {
            return context.DeadlineRequests.ToList().Where(request => request.BorrowedId == borrowedId && request.RequestStatus.ToString() == "Pending").Count() > 0;
        }

        public DeadlineRequest Update(DeadlineRequest requestCahge)
        {
            var request = context.DeadlineRequests.Attach(requestCahge);
            request.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return requestCahge;
        }
    }
}
