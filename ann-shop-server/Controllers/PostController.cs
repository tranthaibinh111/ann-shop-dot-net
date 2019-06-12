using ann_shop_server.Models;
using ann_shop_server.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace ann_shop_server.Controllers
{
    public class PostController : ApiController
    {
        private PostService _service;

        public PostController()
        {
            _service = PostService.Instance;
        }

        // GET api/post/postID:int
        [Route("api/v1/post/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var post = _service.getPostDetail(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok<PostModel>(post);
        }

    }
}
