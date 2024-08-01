namespace RGame.Data
{
    public class LoadPar
    {
        public LoadType type;
        public string data;
    }
    public class UnLoadPar
    {
        public LoadType type;
        public int id;
        public string data;
    }
    public enum LoadType
    {
        None,
        Default,
        Package
        // ...
    }
    public class UIMessagePar
    {
        public string id;
        public string data;
    }
}