using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VideoplayerProject.Domain.Exceptions;

namespace VideoplayerProject.Domain.Models {
    public class Timestamp {

        public Timestamp(TimeSpan startTime, TimeSpan endTime, int ingredientId)
        {
            StartTime = startTime;
            EndTime = endTime;
            IngredientId = ingredientId;
        }

        private int _ingredientId;

        public int IngredientId
        {
            get { return _ingredientId; }
            set
            {
                if (value >= 0)
                {
                    _ingredientId = value;
                }
                else { throw new TimestampException("Invalid ID!"); }
            }
        }

        private TimeSpan _startTime;

        public TimeSpan StartTime {
            get { return _startTime; }
            set { if(value >= TimeSpan.Zero) {
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