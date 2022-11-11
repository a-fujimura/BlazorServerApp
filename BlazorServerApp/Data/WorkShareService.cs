namespace BlazorServerApp.Data
{
    public class WorkShareService
    {
        readonly IWebHostEnvironment environment;

        public WorkShareService(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public Task<bool> SetWorkShareAsync(WorkShare workShare)
        {
            return Task.FromResult(SetWorkShare(workShare));
        }

        public Task<WorkShare> GetWorkShareAsync(int id)
        {
            return Task.FromResult(GetWorkShare(id));
        }

        bool SetWorkShare(WorkShare workShare)
        {
            // ここでDBと通信しデータの保存
            // 今回はファイルで扱う
            File.WriteAllText(Path.Combine(environment.WebRootPath + @"\workshares", $"{workShare.Id}.txt"), workShare.Content);
            return true;
        }

        WorkShare GetWorkShare(int id)
        {
            // ここでDBと通信しデータの取得
            // 今回はファイルで扱う
            var content = string.Empty;
            if (File.Exists(Path.Combine(environment.WebRootPath + @"\workshares", $"{id}.txt")))
            {
                content = File.ReadAllText(Path.Combine(environment.WebRootPath + @"\workshares", $"{id}.txt"));
            }
            return new WorkShare() { Id = id, Content = content };
        }
    }
}
