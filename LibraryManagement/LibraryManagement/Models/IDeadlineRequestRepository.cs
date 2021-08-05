using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public interface IDeadlineRequestRepository
    {
        IEnumerable<DeadlineRequest> GetPendingRequest();
        bool IsBookOfUserRequested(int borrowedId);
        void RemovePendingRequestOfUserReturnedBook(int BorrowedId);
        DeadlineRequest Add(DeadlineRequest request);
        public DeadlineRequest Delete(int id);
        DeadlineRequest Update(DeadlineRequest requestCahge);
    }
}
