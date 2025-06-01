using Ccd.Bidding.Manager.Library.Bidding;
using Ccd.Bidding.Manager.Library.Bidding.Cataloging;
using Ccd.Bidding.Manager.Library.Bidding.Purchasing;
using Ccd.Bidding.Manager.Library.Bidding.Requesting;
using Ccd.Bidding.Manager.Library.Bidding.Responding;
using Ccd.Bidding.Manager.Library.EF.Bidding.Electing;
using Microsoft.EntityFrameworkCore;

namespace Ccd.Bidding.Manager.Library.EF;
public class Dbc : DbContext
{
   public static string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

   public Dbc(DbContextOptions options) : base(options) { }

   public Dbc() : base() { }

   protected override void OnConfiguring(DbContextOptionsBuilder options)
   {
      if (ConnectionString is null)
         throw new Exception($"{nameof(ConnectionString)} not set");
      options.UseSqlServer(ConnectionString);
   }

   // These properties must be accessible for entity framework to work correctly.
   public DbSet<Bid> Bids { get; set; }
   public DbSet<Item> Items { get; set; }
   public DbSet<Requestor> Requestors { get; set; }
   public DbSet<Request> Requests { get; set; }
   public DbSet<RequestItem> RequestItems { get; set; }
   public DbSet<VendorResponse> VendorResponses { get; set; }
   public DbSet<ResponseItem> ResponseItems { get; set; }
   public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
   public DbSet<LineItem> LineItems { get; set; }
   public DbSet<DbcMarkedElection> MarkedElections { get; set; }
}
