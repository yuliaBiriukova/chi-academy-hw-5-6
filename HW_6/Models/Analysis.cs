using System.ComponentModel.DataAnnotations.Schema;

namespace HW_6.Models
{
    internal class Analysis
    {
        [Column("an_id")]
        public int Id { get; set; }

        [Column("an_name")]
        public string Name { get; set; }

        [Column("an_cost")]
        public int Cost { get; set; }

        [Column("an_price")]
        public int Price { get; set; }

        [ForeignKey("an_group")]
        public Group AnGroup { get; set; }

        public ICollection<Order> Orders { get; set; }

        public override string? ToString()
        {
            return $"Analysis {Id}: {Name} \n" +
                $"price = {Price} \n" +
                $"{AnGroup}";
        }
    }
}