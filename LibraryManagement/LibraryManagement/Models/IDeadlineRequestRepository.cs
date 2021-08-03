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
        DeadlineRequest Add(DeadlineRequest request);
        DeadlineRequest Update(DeadlineRequest requestCahge);
    }
}
