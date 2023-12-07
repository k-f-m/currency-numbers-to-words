using System.ComponentModel.DataAnnotations;

namespace CurrencyNumbersToWords.Server.Data.Models
{
    /// <summary>
    /// This class represents a conversion request, specifying characteristics and requirements for the type.
    /// </summary>
    public class ConversionRequest
    {
        [Required]
        [MaxLength(14)]
        public required string Text { get; set; }
    }
}