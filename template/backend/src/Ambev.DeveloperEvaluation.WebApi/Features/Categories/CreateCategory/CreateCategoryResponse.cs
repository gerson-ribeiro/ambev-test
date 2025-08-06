namespace Ambev.DeveloperEvaluation.WebApi.Features.Categories.CreateCategory;

public class CreateCategoryResponse
{
    public CreateCategoryResponse(Guid id, string identification, string displayName)
    {
        Id = id;
        Identification = identification;
        DisplayName = displayName;
    }

    public Guid Id { get; set; }
    public string Identification { get; set; }
    public string DisplayName { get; set; }
}
