namespace HW_5.Models
{
    internal class Group
    {
        public int gr_id { get; set; }
        public string gr_name { get; set; }
        public int gr_temp { get; set; }

        public override string? ToString()
        {
            return $"Group {gr_id}: {gr_name} \n" +
                $"temp: {gr_temp}";
        }
    }
}
