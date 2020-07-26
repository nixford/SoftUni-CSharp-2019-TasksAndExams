using P01._FileStream_After.Contracts;

namespace P01._FileStream_After
{
    public class File : IResult
    {
        public string Name { get; set; }

        public int Length { get; set; }

        public int Sent { get; set; }
    }
}
