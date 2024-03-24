using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VPP.Application.Dto;
using VPP.Application.Services.Category;
using VPP.Application.Services.Post;

namespace VPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public IActionResult AddPost(PostDto postDto)
        {
            try
            {
                postDto.PostId = Guid.NewGuid();

                if (_postService.Add(postDto))
                {
                    return CreatedAtAction(nameof(GetPostById), new { id = postDto.PostId }, postDto);
                }
                else
                {
                    return BadRequest(new { Message = "Không thể thêm bài viết." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult GetAllPosts()
        {
            try
            {
                var posts = _postService.GetAll();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPostById(Guid id)
        {
            try
            {
                var post = _postService.Get(id);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePost(Guid id, PostDto postDto)
        {
            try
            {
                postDto.PostId = id;
                var isUpdated = _postService.Update(postDto);
                if (isUpdated)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(Guid id)
        {
            try
            {
                var isDeleted = _postService.Delete(id);
                if (isDeleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound("Không thể xóa vì bài viết này không tồn tại");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
