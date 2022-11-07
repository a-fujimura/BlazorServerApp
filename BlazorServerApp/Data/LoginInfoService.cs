namespace BlazorServerApp.Data
{
    public class LoginInfoService
    {
        public Task<LoginInfo[]> GetLoginInfoAsync()
        {
            return Task.FromResult(GetLoginInfo());
        }

        LoginInfo[] GetLoginInfo()
        {
            // ここでDBと通信しユーザー情報を取得
            // 今回は構造体で適当にユーザーを返す
            return new LoginInfo[3] {
                new LoginInfo() {Id = 1, UserName = "saitou", Password = "password" },
                new LoginInfo() {Id = 2, UserName = "yamada", Password = "password" },
                new LoginInfo() {Id = 3, UserName = "tanaka", Password = "password" }
            };
        }
    }
}