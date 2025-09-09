using Fanfix.Models;

namespace Fanfix.UseCases.SearchList;

public class SearchListUseCase
(
    FanfixDbContext ctx
)
{
    public async Task<Result<SearchListResponse>> Do(SearchListPayload payload)
    {
        var list = await ctx.ReadingLists.FindAsync(payload.Title);
        if (list is null)
            return Result<SearchListResponse>.Fail("Reading List not found.");
        
        var response = new SearchListResponse(
            list.Title,
            list.LastUpdated,
            from m in list.Fanfics
            select new FanficData
            {
                Title = m.Title,
                CreatorName = m.Creator.Username
            }
        );

        return Result<SearchListResponse>.Success(response);
    }
}