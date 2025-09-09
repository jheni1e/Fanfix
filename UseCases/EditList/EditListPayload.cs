namespace Fanfix.UseCases.EditList;

public record EditListPayload (
    int ReadingListID,
    int FanficID,
    int CreatorID
);