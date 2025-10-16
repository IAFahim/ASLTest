namespace Pool.Runtime
{
    public interface IPoolCallbackReceiver
    {
        void OnRequest();
        void OnReturn();
    }
}