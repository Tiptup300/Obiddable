using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Electing.Elections;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ccd.Bidding.Manager.Library.Bidding.Electing
{
   public class ElectionSet
   {
      private List<Election> _elections;
      private Dictionary<int, Election> _dirtyElectionsByItemId;

      public ElectionSet(IEnumerable<MarkedElection> markedElections, IEnumerable<UnmarkedElection> unmarkedElections)
      {
         IEnumerable<Election> elections;

         validateNoDuplicateRequestItems(markedElections);
         elections = markedElections.OfType<Election>().Union(unmarkedElections);
         validateNoDuplicateItems(elections);
         _elections = elections.ToList();
         _dirtyElectionsByItemId = new Dictionary<int, Election>();
      }
      private void validateNoDuplicateRequestItems(IEnumerable<MarkedElection> markedElections)
      {
         if (hasDuplicateRequestItems(markedElections))
         {
            throw new ArgumentException("Cannot Have Multiple Elections For One Request Item.");
         }
      }
      private static bool hasDuplicateRequestItems(IEnumerable<MarkedElection> markedElections)
          => markedElections.Any(x => markedElections.Count(y => x.ElectedResponseItem.Id == y.ElectedResponseItem.Id) > 1);
      private void validateNoDuplicateItems(IEnumerable<Election> elections)
      {
         if (hasDuplicateItems(elections))
         {
            throw new ArgumentException("Cannot Have Multiple Elections For one Item.");
         }
      }
      private bool hasDuplicateItems(IEnumerable<Election> elections)
          => elections.Any(x => elections.Count(y => x.Item.Id == y.Item.Id) > 1);


      public void ElectResponseItemForItem(ResponseItem electedResponseItem, string reason)
      {
         Item item;
         Election oldElection;
         MarkedElection newMarkedElection;

         try
         {
            item = electedResponseItem.Item;
            oldElection = getElectionForItem(item);
            newMarkedElection = oldElection.Elect(electedResponseItem, reason);
            replaceElectionAndAddToDirtyList(oldElection, newMarkedElection);
         }
         catch (Exception ex)
         {
            throw new Exception($"Cannot elect response item: {ex.Message}", ex);
         }
      }
      private void replaceElectionAndAddToDirtyList(Election oldElection, Election newElection)
      {
         _elections.Remove(oldElection);
         _elections.Add(newElection);
         addElectionToDirtyList(oldElection);
      }
      private void addElectionToDirtyList(Election election)
      {
         if (isElectionAlreadyDirty(election))
         {
            return;
         }
         _dirtyElectionsByItemId.Add(election.Item.Id, election);
      }

      private bool isElectionAlreadyDirty(Election election)
      {
         return _dirtyElectionsByItemId.ContainsKey(election.Item.Id);
      }

      public void UnelectItem(Item item)
      {
         Election oldElection;
         MarkedElection oldMarkedElection;
         Election newElection;

         try
         {
            oldElection = getElectionForItem(item);
            if (oldElection is MarkedElection)
            {
               oldMarkedElection = oldElection as MarkedElection;
               newElection = oldMarkedElection.Unelect();
            }
            else
            {
               newElection = oldElection;
            }
            replaceElectionAndAddToDirtyList(oldElection, newElection);
         }
         catch (Exception ex)
         {
            throw new Exception($"Cannot clear election for item: {ex.Message}", ex);
         }
      }

      private Election getElectionForItem(Item item)
      {
         Election output;

         try
         {
            output = _elections.First(x => x.Item.Id == item.Id);
         }
         catch
         {
            throw new Exception("Item is not found within the ElectionsSet.");
         }

         return output;
      }

      public IEnumerable<Election> GetElections()
          => _elections.ToList();

      internal void SaveChangesToRepo(ElectingService electingService)
      {
         IEnumerable<Election> dirtyElections;

         dirtyElections = getDirtyElections();
         electingService.SaveElections(dirtyElections);
         clearDirtyItemIds();
      }
      private IEnumerable<Election> getDirtyElections() =>
          _elections.Where(x => _dirtyElectionsByItemId.Any(dirtyItemId => dirtyItemId.Key == x.Item.Id));

      private void clearDirtyItemIds()
          => _dirtyElectionsByItemId.Clear();

   }
}
