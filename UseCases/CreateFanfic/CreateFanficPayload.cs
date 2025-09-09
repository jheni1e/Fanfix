using System.ComponentModel.DataAnnotations;
using Fanfix.Validations;
using Newtonsoft.Json;

namespace Fanfix.UseCases.CreateFanfic;

public record CreateFanficPayload
{
    [Required]
    public string Title { get; init; }

    [Required]
    [TextLimits]
    [MaxLength(6000)]
    public string Text { get; init; }

    [Required]
    public int CreatorID { get; init; }
}