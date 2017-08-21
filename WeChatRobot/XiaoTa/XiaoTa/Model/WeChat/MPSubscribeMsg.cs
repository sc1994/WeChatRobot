using System.Collections.Generic;

namespace Model.WeChat
{
    // ReSharper disable once InconsistentNaming
    public class MPSubscribeMsg
    {
        public string UserName { get; set; } = string.Empty;

        // ReSharper disable once InconsistentNaming
        public int MPArticleCount { get; set; }
        public long Time { get; set; }
        public string NickName { get; set; } = string.Empty;

        // ReSharper disable once InconsistentNaming
        public List<MPArticle> MPArticleList { get; set; } = new List<MPArticle>();
    }
}
