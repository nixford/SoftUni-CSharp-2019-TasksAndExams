using P01Logger.Enums;


namespace P01Logger.Models.Contracts
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}
