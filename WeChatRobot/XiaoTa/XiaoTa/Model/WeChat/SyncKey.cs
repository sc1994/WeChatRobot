using System.Collections.Generic;

namespace Model.WeChat
{
    public class SyncKey
    {
        public int Count { get; set; }

        public List<ListKey> List { get; set; } = new List<ListKey>();
    }
}
