namespace Application.Common.Dto.Auction
{
    public class ListAuctionDto
    {
        public string AutionTitle { get; set; }
        public string AutionDescription { get; set; }
        public float StartingBid { get; set; }
        public float MaxBid { get; set; }
        public string DateOpened { get; set; }
        public string DateClosed { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
    }
}
