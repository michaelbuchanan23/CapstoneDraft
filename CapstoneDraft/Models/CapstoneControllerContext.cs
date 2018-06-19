using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CapstoneDraft.Models
{
    public class CapstoneControllerContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CapstoneControllerContext() : base("name=CapstoneControllerContext") //if we change this to remove the name property will it 
																					//create the database for us like in PRSWithEFSolution
		{
        }

		public System.Data.Entity.DbSet<PrsEf.Product> Products { get; set; }

		public System.Data.Entity.DbSet<PrsEf.Vendor> Vendors { get; set; }

		public System.Data.Entity.DbSet<PrsEf.PurchaseRequest> PurchaseRequests { get; set; }

		public System.Data.Entity.DbSet<PrsEf.User> Users { get; set; }

		public System.Data.Entity.DbSet<PrsEf.PurchaseRequestLineitem> PurchaseRequestLineitems { get; set; }
	}
}
