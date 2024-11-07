namespace DomainModel.ResultsRequest.Canvas
{
    public class CanvasAddResult
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public VersionProjectForCanvasResult VersionProject { get; set; }
    }
}
