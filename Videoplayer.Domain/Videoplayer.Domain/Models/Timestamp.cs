using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VideoplayerProject.Domain.Exceptions;

namespace VideoplayerProject.Domain.Models {
    public class Timestamp {

        public Timestamp(string startTime, string endTime) {
            StartTime = startTime;
            EndTime = endTime;
        }

        private string _startTime;

		// Check for timestamp string (f.e. "01:15")
		public string StartTime {
			get { return _startTime; }
			set {
				char[] chars = value.Trim().ToCharArray();
				//Check if the first 2 and last 2 chars are numbers, and that the 3rd char is ":"
				if (int.TryParse(chars[0].ToString(), out _) && int.TryParse(chars[1].ToString(), out _) &&
                    int.TryParse(chars[3].ToString(), out _) && int.TryParse(chars[0].ToString(), out _)
					&& chars[2] == ':') {
					_startTime = value;
				} else {
					throw new TimestampException("Invalid starttime. Starttime needs to be in format \"00:00\"");
				}
			}
		}


		private string _endTime;
				
		public string EndTime {
			get { return _endTime; }
			set {
                char[] endTimechars = value.Trim().ToCharArray();
				//Same check as starttime
				if (int.TryParse(endTimechars[0].ToString(), out _) && int.TryParse(endTimechars[1].ToString(), out _) &&
					int.TryParse(endTimechars[3].ToString(), out _) && int.TryParse(endTimechars[0].ToString(), out _)
					&& endTimechars[2] == ':') {
					// Additional check to verify that EndTime is AFTER StartTime 
					char[] startTimeChars = StartTime.ToCharArray();

					// Get the first 2 numbers from the startTimestamp as an int
					int startMinutes = int.Parse((startTimeChars[0].ToString() + startTimeChars[1].ToString()));
					int startSeconds = int.Parse((startTimeChars[3].ToString() + startTimeChars[4].ToString()));

					int endMinutes = int.Parse((endTimechars[0].ToString() + endTimechars[1].ToString()));
					int endSeconds = int.Parse((endTimechars[3].ToString() + endTimechars[4].ToString()));

					// Check if startMinute is smaller than endMinute
					if (startMinutes < endMinutes) {
						_endTime = value;
					}
					// If equal, compare seconds
					else if (startMinutes == endMinutes && startSeconds < endSeconds) {
						_endTime = value;
					} else {
						throw new TimestampException("Invalid endtime. The endtime needs to be after the starttime.");
					}
				} else {
					throw new TimestampException("Invalid endtime. Endtime needs to be in format \"00:00\"");
				}
			}
		}
    }
}
