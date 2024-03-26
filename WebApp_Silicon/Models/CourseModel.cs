namespace WebApp_Silicon.Models;

public class CourseModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? ImageName { get; set; }
    public string? Author { get; set; }
    public bool IsBestseller { get; set; }
    public int Hours { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal DiscountPrice { get; set; }
    public decimal LikesInProcent { get; set; }
    public decimal LikesInNumbers { get; set; }
}

