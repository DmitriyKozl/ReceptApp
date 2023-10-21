using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoplayerProject.Domain.Interfaces;

namespace VideoplayerProject.Domain.Managers
{
    public class TimestampManager : ITimestampRepository
    {
        private ITimestampRepository _timestampPepository;
        public TimestampManager(ITimestampRepository repo) 
        {
            _timestampPepository = repo;
        }
    }
}
