namespace Store.Settings
{
    public interface IDbSettings
    {
        string Server { get; }

        string Database { get; }

        string ConnectionString { get; }
    }
}
