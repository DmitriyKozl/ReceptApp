using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VideoplayerProject.Domain.Exceptions;

namespace VideoplayerProject.Domain.Models {
    public class Timestamp {

        public Timestamp(TimeSpan startTime, TimeSpan endTime) {
            StartTime = startTime;
            EndTime = endTime;
        }

        private TimeSpan _startTime;

        public TimeSpan StartTime {
            get { return _startTime; }
            set { if(value > TimeSpan.Zero) {
                    _startTime = value;
                } else {
                    throw new TimestampException("Invalid starttime. Starttime has to be bigger than 0.");
                }
            }
        }


        private TimeSpan _endTime;
				
        public TimeSpan EndTime {
            get { return _endTime; }
            set { if (value > _startTime) {
                    _endTime = value;
                } else {
                    throw new TimestampException("Invalid endtime. The endtime needs to be after the starttime.");
                }
            }
        }
    }
}