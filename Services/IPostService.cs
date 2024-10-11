using System;
using TodoApi.DTO;

namespace TodoApi.Services;

public interface IPostService
{
    public Task<IEnumerable<PostDTO>> Get();
}
