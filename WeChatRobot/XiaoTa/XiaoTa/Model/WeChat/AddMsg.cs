namespace Model.WeChat
{
    public class AddMsg
    {
        public string MsgId { get; set; } = string.Empty;
        public string FromUserName { get; set; } = string.Empty;
        public string ToUserName { get; set; } = string.Empty;
        public int MsgType { get; set; }
        public string Content { get; set; } = string.Empty;
        public int Status { get; set; }
        public int ImgStatus { get; set; }
        public long CreateTime { get; set; }
        public int VoiceLength { get; set; }
        public int PlayLength { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileSize { get; set; } = string.Empty;
        public string MediaId { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public int AppMsgType { get; set; }
        public int StatusNotifyCode { get; set; }
        public string StatusNotifyUserName { get; set; } = string.Empty;
        public RecommendInfo RecommendInfo { get; set; } = new RecommendInfo();
        public int ForwardFlag { get; set; }
        public AppInfo AppInfo { get; set; } = new AppInfo();
        public int HasProductId { get; set; }
        public string Ticket { get; set; } = string.Empty;
        public int ImgHeight { get; set; }
        public int ImgWidth { get; set; }
        public int SubMsgType { get; set; }
        public long NewMsgId { get; set; }
        public string OriContent { get; set; } = string.Empty;


    }
}
