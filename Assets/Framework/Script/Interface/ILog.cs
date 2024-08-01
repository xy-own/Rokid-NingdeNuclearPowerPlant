
using RGame.Define;

namespace RGame.Interface
{
    public interface ILog
    {
        void Log(string log, LogColor logColor = LogColor.None);
    }
}