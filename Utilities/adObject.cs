using System.ComponentModel.DataAnnotations;

namespace Utilities
{
    public class adObject : ICloneable
    {
        object ICloneable.Clone() { return Clone(); }
        public adObject Clone()
        {
            return (adObject)this.MemberwiseClone();
        }

        [Required(ErrorMessage = "ID field is required.")]
        public int adId{ get; set; }

        [Required(ErrorMessage = "Description field is required.")]
        public string adDescription { get; set; }

        [Required(ErrorMessage = "Creation Date field is required.")]
        public DateTime adCreationDate { get; set; }

        [Required(ErrorMessage = "Status field is required.")]
        public adStatus adStatus { get; set; }
        public decimal? adBalance { get; set; }

        public string? adExternalId { get; set; }
        public int? adTotalLeads { get; set; }
    }

    public enum adStatus
    {
        Active = 1, Paused = 2
    }
}
