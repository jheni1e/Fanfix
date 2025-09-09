using Fanfix.Models;
using Microsoft.EntityFrameworkCore;

namespace Fanfix.UseCases.SearchList;

public class SearchListUseCase
(
    FanfixDbContext ctx
)
{
    public async Task<Result<SearchListResponse>> Do(SearchListPayload payload)
    {
        var list = await ctx.ReadingLists
        .Include(l => l.Fanfics)
            .ThenInclude(f => f.Creator)
        .FirstOrDefaultAsync(l => l.Title == payload.Title);
        
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