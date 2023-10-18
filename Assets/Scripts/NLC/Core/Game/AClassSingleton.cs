namespace NLC.Core.Game
{
    public abstract class AClassSingleton<T> where T : AClassSingleton<T>, new()
    {
        protected static T instance;

        public static T Instance
        {
            get
            {
                if (instance is not null && !instance.Equals(null))
                    return instance;

                instance = new T();
                instance.OnCreated();

                return instance;
            }
        }
        
        protected virtual void OnCreated()
        {
            
        }
    }
}