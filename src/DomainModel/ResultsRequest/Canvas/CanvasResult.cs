namespace DomainModel.ResultsRequest.Canvas
{
    public class CanvasResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int VersionId { get; set; }
        public CanvasResult() { }
        public CanvasResult(DomainModel.Model.Canvas canvas)
        {
            Id = canvas.Id;
            Name = canvas.Name;
            Description = canvas.Description;
            UserId = canvas.AuthorId;
            VersionId = canvas.MainVersionId;
           

        }
    }
}
