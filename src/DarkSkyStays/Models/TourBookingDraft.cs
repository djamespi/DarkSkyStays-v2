using System.ComponentModel.DataAnnotations;

namespace DarkSkyStays.Models;

public sealed class TourBookingDraft
{
    [Required(ErrorMessage = "Choose a tour date.")]
    public DateTime? Date { get; set; }

    [Range(1, 8, ErrorMessage = "Choose between 1 and 8 guests.")]
    public int Guests { get; set; } = 1;
}
