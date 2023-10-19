using System;
using NLC.Core.Game.Scenes;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NLC.Core.Game
{
    [AddComponentMenu("NLC/Core/Game/Game Manager")]
    public class GameManager : AMonoSingleton<GameManager>
    {
        [SerializeField] private LyricSceneTemplate lyricSceneTemplate;

        private EventSystem           eventSystem;
        private StandaloneInputModule standaloneInputModule;

        public static DisplayMain      DisplayMain      => Game.DisplayMain.Instance;
        public static DisplayPresenter DisplayPresenter => Game.DisplayPresenter.Instance;

        protected override void Awake()
        {
            base.Awake();
            
            new GameObject("Event System")
               .Component(out eventSystem)
               .Component(out standaloneInputModule);

            DisplayMain      main      = DisplayMain;
            DisplayPresenter presenter = DisplayPresenter;

            LyricScene scene = lyricSceneTemplate.GetScene();
            scene.Switch(presenter);
        }

        protected void Start()
        {
        }
    }
}