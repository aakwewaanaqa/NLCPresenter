using System.Collections;
using System.Collections.Generic;
using NLC.Core.Game.Scenes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NLC.Core.Game
{
    public abstract class ADisplay<T> : AMonoSingleton<T>, IDisplay
        where T : ADisplay<T>
    {
        public abstract int targetDisplay { get; set; }

        protected new Camera           camera;
        protected new Canvas           canvas;
        protected     CanvasScaler     canvasScaler;
        protected     GraphicRaycaster graphicRaycaster;

        public Canvas GetCanvas() => canvas;

        protected override void OnCreated()
        {
            base.OnCreated();

            gameObject
               .Component(out camera)
               .Component(out canvas)
               .Component(out canvasScaler)
               .Component(out graphicRaycaster);

            camera.orthographic  = true;
            camera.targetDisplay = targetDisplay;

            canvas.renderMode                  = RenderMode.ScreenSpaceOverlay;
            canvas.targetDisplay               = targetDisplay;
            canvas.vertexColorAlwaysGammaSpace = true;
        }
    }
}