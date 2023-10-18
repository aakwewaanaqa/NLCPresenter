using UnityEngine;

namespace NLC.Core.Game
{
    public static class Extensions
    {
        public static bool IsNull(this Object o)
        {
            return o is null || o.Equals(null);
        }

        public static bool IsObject(this Object o)
        {
            return !o.IsNull();
        }

        public static GameObject Component<T>(this GameObject g, out T component) where T : Component
        {
            if (!g.TryGetComponent(out component))
                component = g.AddComponent<T>();
            return g;
        }

        public static Transform ClearChildren(this Transform t)
        {
            for (int i = 0; i < t.childCount; i++)
            {
                if (Application.isPlaying)
                {
                    Object.Destroy(t.GetChild(i).gameObject);
                }
                else
                {
                    Object.DestroyImmediate(t.GetChild(0).gameObject);
                }
            }
            return t;
        }
    }
}