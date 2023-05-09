using System.ComponentModel.DataAnnotations.Schema;

namespace HW_6.Models
{
    internal class Group
    {
        [Column("gr_id")]
        public int Id { get; set; }

        [Column("gr_name")]
        public string Name { get; set; }

        [Column("gr_temp")]
        public int Temp { get; set; }

        public override string? ToString()
        {
            return $"Group {Id}: {Name} \n" +
                $"temp: {Temp}";
        }
    }
}