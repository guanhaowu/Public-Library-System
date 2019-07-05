using Newtonsoft.Json;

namespace PLS.model
{
    public class LoanItem
    {
        [JsonProperty(PropertyName = "loanID")]
        public int LoanId { get; set; }
        [JsonProperty(PropertyName = "bookID")]
        public int bookID { get; set; }
        [JsonProperty(PropertyName = "customerID")]
        public int CustomerID { get; set; }
        public static int Count = 0;

        public LoanItem(BookItem bookid, Customer customerID)
        {
            this.bookID = bookid.Id;
            this.CustomerID = customerID.Number;
            this.LoanId = Count++;
        }

    }
}
