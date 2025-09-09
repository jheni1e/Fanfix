namespace Fanfix.UseCases.CreateFanfic;

public record CreateFanficPayload (
    string Title,
    string Text,
    int CreatorID
);