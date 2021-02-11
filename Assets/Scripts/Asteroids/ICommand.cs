
namespace Shipov_Asteroids
{
    public interface ICommand<T>
    {
        bool IsSucceed { get; }
        bool Execute(T item);
        void RevertAction(T item);
    }
}
