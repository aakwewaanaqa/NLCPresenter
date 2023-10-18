using System;
using System.IO;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;
using UnityEngine.Video;

namespace NLC.Core.Game.Scenes
{
    [Serializable]
    public class LyricScene : AScene<LyricScene>, ICloneable
    {
        public enum BGType
        {
            Image,
            Video,
        }

        [Serializable]
        public sealed class Param
        {
            public string bgPath;
            public BGType bgType;
        }

        [SerializeField] public Param param;

        public override void Switch(IDisplay display)
        {
            base.Switch(display);

            Transform root = display.GetCanvas().transform;
            root.ClearChildren();

            new GameObject("BG")
               .Component(out RectTransform rectTransform)
               .Component(out RawImage rawImage)
               .Component(out VideoPlayer player);

            rectTransform.SetParent(root);
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.sizeDelta        = Vector2.zero;
            rectTransform.anchorMin        = Vector2.zero;
            rectTransform.anchorMax        = Vector2.one;

            RenderTexture texture = new RenderTexture(1920, 1080, 0);
            texture.name         = $"{Path.GetFileName(param.bgPath)}";
            rawImage.texture     = texture;
            player.targetTexture = texture;
            player.isLooping     = true;
            player.url           = param.bgPath;
        }

        public object Clone()
        {
            LyricScene clone = new LyricScene()
            {
                param = param,
            };
            return clone;
        }
    }
}