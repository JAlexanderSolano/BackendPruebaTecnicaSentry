namespace PruebaTecnicaSentry.Response
{
    public class ResultResponse
    {
        public string result { get; set; }

        public ResultResponse() { }

        public ResultResponse(string result) 
        {
            this.result = result;
        }
    }
}
