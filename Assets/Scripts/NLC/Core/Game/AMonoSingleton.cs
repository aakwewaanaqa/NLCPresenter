using System;
using UnityEngine;

namespace NLC.Core.Game
{
    public abstract class AMonoSingleton<T> : MonoBehaviour where T : AMonoSingleton<T>
    {
        protected static T instance;

        public static T Instance
        {
            get
            {
                if (!instance.IsNull())
                    return instance;
                
                new GameObject(typeof(T).Name)
                   .Component(out instance);
                
                instance.OnCreated();

                return instance;
            }
        }

        protected virtual void OnCreated()
        {
            
        }

        protected virtual void Awake()
        {
            TryGetComponent(out instance);
        }
    }
}