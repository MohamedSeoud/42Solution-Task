namespace App.Contracts
{
    public class FinanceRequestDto
    {
        public int RequestNumber { set; get; }
        public int PaymentAmount { set; get; }
        public int PaymentPeriod { set; get; }
        public int TotalProfit { set; get; }
        public int RequestStatus { set; get; }
    }
}
