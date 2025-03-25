using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Bidding
{
    public class Entity
    {
        public int? Id { get; private set; }
        public Entity(int? id)
        {
            Id = id;
        }

        public bool IsNew()
            => Id.HasValue == false;

        public bool IsOld()
            => Id.HasValue;
    }
}
