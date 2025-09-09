using System.ComponentModel.DataAnnotations;

namespace Fanfix.Validations;

public class TextLimitsAttribute : ValidationAttribute
{
    public int MaxLines { get; set; } = 100;
    public int MaxWords { get; set; } = 1000;
    
    public override bool IsValid(object value)
    {
        if (value is not string text)
            return true;
            
        var lines = text.Count(c => c == '\n') + 1;
        var words = text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        return lines <= MaxLines && words <= MaxWords;
    }
    public override string FormatErrorMessage(string name)
        => $"The field '{name}' must not exceed {MaxLines} lines or {MaxWords} words.";

}