using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;
using VPP.Domain.Repositories;

namespace VPP.Application.Services.Post
{
    public class PostService : IPostService
    {
        private readonly IPostRepo _postRepo;
        private readonly IMapper _mapper;
        public PostService(IPostRepo postRepo, IMapper mapper)
        {
            _postRepo = postRepo;
            _mapper = mapper;
        }
        public List<PostDto> GetAll()
        {
            return _mapper.Map<List<PostDto>>(_postRepo.GetAll());
        }

        public PostDto Get(Guid id)
        {
            return _mapper.Map<PostDto>(_postRepo.Get(id));
        }

        public bool Add(PostDto postDto)
        {
            return _postRepo.Add(_mapper.Map<VPP.Domain.Entities.Post>(postDto));
        }

        public bool Update(PostDto postDto)
        {
            return _postRepo.Update(_mapper.Map<VPP.Domain.Entities.Post>(postDto));
        }

        public bool Delete(Guid id)
        {
            return _postRepo.Delete(id);
        }
    }
}
