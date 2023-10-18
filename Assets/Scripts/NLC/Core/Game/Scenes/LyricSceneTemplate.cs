using UnityEngine;

namespace NLC.Core.Game.Scenes
{
    [CreateAssetMenu(menuName = "NLC/Core/Game/Scenes/Lyric Scene Template")]
    public class LyricSceneTemplate : ScriptableObject
    {
        [SerializeField] private LyricScene scene;

        public LyricScene GetScene()
        {
            return (LyricScene)scene.Clone();
        }
    }
}