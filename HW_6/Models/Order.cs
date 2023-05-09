using System.ComponentModel.DataAnnotations.Schema;

namespace HW_6.Models
{
    internal class Order
    {
        [Column("ord_id")]
        public int Id { get; set; }

        [Column("ord_datetime")]
        public DateTime OrdDatetime { get; set; }

        [ForeignKey("ord_an")]
        public Analysis OrdAnalysis { get; set; }

        public override string? ToString()
        {
            return $"Order {Id} \n" +
                $"Date = {OrdDatetime} \n" +
                $"{OrdAnalysis}";
        }
    }
}