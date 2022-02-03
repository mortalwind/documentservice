namespace DocumentMono.Business.Dto;

public class PagingModel<TModel> where TModel : BaseDto
{
    public long TotalCount { get; private set; }
    public int PageIndex { get; private set; }
    public int Count { get; private set; }
    public List<TModel> Data { get; private set; }

    public PagingModel(long totalCount, int pageIndex, int count, List<TModel> data)
    {
        TotalCount = totalCount;
        PageIndex = pageIndex;
        Count = count;
        Data = data;
    }
}
