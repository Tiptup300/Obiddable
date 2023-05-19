using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Electing.Elections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ccd.Bidding.Manager.Library.Bidding.Electing
{
    public class ElectionsSetFactory
    {
        private readonly UnmarkedElectionsFactory _unmarkedElectionsFactory;

        public ElectionsSetFactory(UnmarkedElectionsFactory unmarkedElectionsFactory)
        {
            _unmarkedElectionsFactory = unmarkedElectionsFactory;
        }

        public ElectionSet Build(IEnumerable<Item> bidItems, IEnumerable<MarkedElection> markedElections)
        {
            ElectionSet output;
            IEnumerable<UnmarkedElection> unmarkedElections;

            unmarkedElections = _unmarkedElectionsFactory.BuildUnmarkedElectionsForItems(bidItems, markedElections);
            output = new ElectionSet(markedElections, unmarkedElections);

            return output;
        }
    }
}
