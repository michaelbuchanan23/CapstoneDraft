using PrsEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneDraft.ViewModels {
	public class LineitemsForPurchaseRequest {

		public PurchaseRequest PurchaseRequest { get; set; }
		public IEnumerable<PurchaseRequestLineitem> PurchaseRequestLineitems { get; set; }

		public LineitemsForPurchaseRequest() { }
	}
}