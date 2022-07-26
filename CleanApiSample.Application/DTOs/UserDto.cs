namespace CleanApiSample.Application.DTOs
{
    public record UserDto(int Id, string Username, string Email, List<PostDto>? Posts);
}