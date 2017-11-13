using System.ComponentModel.DataAnnotations;

namespace Learning_Path.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}