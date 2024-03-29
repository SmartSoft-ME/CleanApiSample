﻿using CleanApiSample.Application.DTOs;
using CleanApiSample.Application.Repositories;
using CleanApiSample.Domain.Entities;
using CleanApiSample.Shared.Abstractions.Application.Queries;

using Mapster;

namespace CleanApiSample.Application.Queries.PostQueries.Handlers
{
    internal class GetPostByIdHandler : IQueryHandler<GetPostByIdQuery, PostDto>
    {
        private readonly IPostRepository _posts;

        public GetPostByIdHandler(IPostRepository posts)
        {
            _posts = posts;
        }

        public async Task<PostDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _posts.GetWholeByIdAsync(request.Id, cancellationToken);
            var setter = TypeAdapterConfig<Post, PostDto>.NewConfig()
                .Map(dest => dest.TagIds, src => src.Tags.Select(t => t.Id)).MaxDepth(2);
            return post.Adapt<Post, PostDto>(setter.Config);
        }
    }
}
