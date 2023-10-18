namespace NLC.Core.Game.Scenes
{
    public class AScene<T> : AClassSingleton<T> where T : AScene<T>, new()
    {
        public virtual void Switch(IDisplay display)
        {
            
        }
    }
}