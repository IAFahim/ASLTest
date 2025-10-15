namespace Customization.Runtime
{
    public interface ISaveLoadAble
    {
        public string SaveLoadKey { get; set; }
        void Save();
        void Load();
    }
}