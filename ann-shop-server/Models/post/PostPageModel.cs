using System.Collections.Generic;

namespace ann_shop_server.Models
{
    public class PostPageModel
    {
        public PaginationMetadataModel paginationMetadata { get; set; }
        public List<PostModel> data { get; set; }
    }
}