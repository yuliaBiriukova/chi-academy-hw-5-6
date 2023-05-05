namespace HW_5.Models
{
    internal class Order
    {
        public int ord_id { get; set; }
        public DateTime ord_datetime { get; set; }
        public Analysis ord_an { get; set; }

        public override string? ToString()
        {
            return $"Order {ord_id} \n" +
                $"Date = {ord_datetime} \n" +
                $"{ord_an}";
        }
    }
}
