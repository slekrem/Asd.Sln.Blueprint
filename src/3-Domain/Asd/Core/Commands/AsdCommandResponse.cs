namespace Asd.Domain.Core.Commands
{
    public class AsdCommandResponse
    {
        public static AsdCommandResponse Ok => new AsdCommandResponse(true);

        public static AsdCommandResponse Fail => new AsdCommandResponse();

        public bool Success { get; private set; }

        private AsdCommandResponse(bool success = false)
        {
            Success = success;
        }
    }
}