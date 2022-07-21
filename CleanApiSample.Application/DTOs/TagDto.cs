namespace CleanApiSample.Application.DTOs
{
    public record TagDto(int Id, string Name, List<PostDto> Posts);
}