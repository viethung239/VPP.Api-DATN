using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;

namespace VPP.Application.Services.Post
{
    public interface IPostService
    {
        List<PostDto> GetAll();
        PostDto Get(Guid id);
        bool Add(PostDto postDto);
        bool Update(PostDto postDto);
        bool Delete(Guid id);
    }
}
