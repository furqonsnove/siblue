namespace HR_Service.Config
{
    public class RedisOptions
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public string? Password { get; set; }

        public override string ToString()
        {
            return $"{Host}:{Port},password={Password}";
        }
    }
}


