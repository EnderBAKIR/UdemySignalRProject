namespace SignalRWebUI.Services.Category.Dtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }

        public bool CategoryStatus { get; set; } = true;
    }
}
