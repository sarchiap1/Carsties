namespace Contracts
{
    public class BidPlaced
    {
        public string Id { get; set; }
        public string AuctionId { get; set; }
        public string Bidder { get; }

        public DateTime BidTime { get; set;}
        public int Amount { get; }

        public string BidStatus { get; set; }
    }
}