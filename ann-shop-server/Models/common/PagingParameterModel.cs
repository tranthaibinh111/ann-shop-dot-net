namespace ann_shop_server.Models
{
    public class PagingParameterModel
    {
        const int maxPageSize = 20;
        int _pageSize { get; set; } = 10;
        public int pageNumber { get; set; } = 1;
        public int pageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}