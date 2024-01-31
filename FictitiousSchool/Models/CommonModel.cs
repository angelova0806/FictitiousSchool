namespace FictitiousSchool.Models
{
    public class CommonModel
    {
        public class TransactionStatus
        {
            //public int id { get; set; }
            public bool IsSuccess { get; set; }
            public string? message { get; set; }
            public dynamic? data { get; set; }
            public int Code { get; set; }
        }
    }
}
