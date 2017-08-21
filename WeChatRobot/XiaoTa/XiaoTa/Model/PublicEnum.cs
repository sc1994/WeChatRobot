namespace Model
{
    /// <summary>
    /// 扫描QR 状态
    /// </summary>
    public enum ScanQrState
    {
        /// <summary>
        /// 未扫描
        /// </summary>
        NotScan = 0,
        /// <summary>
        /// 未登陆（已扫描）
        /// </summary>
        NotLogIn = 1,
        /// <summary>
        /// 登陆成功
        /// </summary>
        LogInWin = 2
    }
}
