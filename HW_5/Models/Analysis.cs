namespace HW_5.Models
{
    internal class Analysis
    {
        public int an_id { get; set; }
        public string an_name { get; set; }
        public int an_cost { get; set; }
        public int an_price { get; set; }
        public Group an_group { get; set; }

        public override string? ToString()
        {
            return $"Analysis {an_id}: {an_name} \n" +
                $"price = {an_price} \n" +
                $"{an_group}";
        }
    }
}
