﻿using CleanApiSample.Application.DTOs;
using CleanApiSample.Shared.Abstractions.Application.Queries;
using CleanApiSample.Application.Repositories;
using Mapster;
using CleanApiSample.Domain.Entities;

namespace CleanApiSample.Application.Queries.PostQueries.Handlers
{
    internal class GetAllPostsHandler : IQueryHandler<GetAllPostsQuery, List<PostDto>>
    {
        private readonly IPostRepository _posts;

        public GetAllPostsHandler(IPostRepository posts)
        {
            _posts = posts;
        }

        public async Task<List<PostDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _posts.GetAllAsync(cancellationToken);
            var  postsDTO = posts.Adapt<IEnumerable<Post>, IEnumerable<PostDto>>();
            return postsDTO.ToList();
        }
    }
}
