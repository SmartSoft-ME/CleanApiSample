namespace CleanApiSample.Application.DTOs
{
    public record PostDto(int Id, string Title, string Description, DateTime PostedDate, UserDto User, List<TagDto> Tags);
}
