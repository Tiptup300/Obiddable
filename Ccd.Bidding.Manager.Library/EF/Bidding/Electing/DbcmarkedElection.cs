using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ccd.Bidding.Manager.Library.EF.Bidding.Electing
{
    public class DbcMarkedElection
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Item Item { get; set; }

        [Required]
        public ResponseItem ElectedResponseItem { get; set; }

        [Required, MaxLength(255)]
        public string Reason { get; set; }

        protected DbcMarkedElection() { }

        public DbcMarkedElection(int? id, ResponseItem electedResponseItem, string reason)
        {
            Id = id.GetValueOrDefault(0);
            Item = electedResponseItem.Item ?? throw new ArgumentNullException(nameof(electedResponseItem.Item));
            ElectedResponseItem = electedResponseItem ?? throw new ArgumentNullException(nameof(electedResponseItem));
            Reason = reason ?? throw new ArgumentNullException(nameof(reason));
        }

    }
}
