namespace CleanApiSample.Application.DTOs
{
    public record PostDto(int Id, string Title, string Description, DateTime PostedTime, UserDto User, List<TagDto> Tags);
}
