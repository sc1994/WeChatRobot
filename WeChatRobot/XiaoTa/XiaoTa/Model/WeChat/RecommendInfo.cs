namespace Model.WeChat
{
    public class RecommendInfo
    {
         public  string UserName { get; set; } = string.Empty;
         public  string NickName { get; set; } = string.Empty;
        // ReSharper disable once InconsistentNaming
         public  int QQNum{ get; set; }
         public  string Province { get; set; } = string.Empty;
         public  string City { get; set; } = string.Empty;
         public  string Content { get; set; } = string.Empty;
         public  string Signature { get; set; } = string.Empty;
         public  string Alias { get; set; } = string.Empty;
         public  int Scene{ get; set; }
         public  int VerifyFlag{ get; set; }
         public  int AttrStatus{ get; set; }
         public  int Sex{ get; set; }
         public  string Ticket { get; set; } = string.Empty;
         public  int OpCode{ get; set; }

    }
}
