﻿
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Bonsai.Designer
{
    public static partial class BonsaiResources
    {
        public const string kStandardAssetPath = "Assets/Plugins/BonsaiBT/Designer/Textures/";
        public enum TexType { PNG, JPEG };

        private static Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();

        static BonsaiResources()
        {
            LoadStandardTextures();
        }

        public static void LoadStandardTextures()
        {
            _textures.Clear();

            LoadTexture("Arrow");
            LoadTexture("Question");
            LoadTexture("ParallelArrows");
            LoadTexture("Priority");
            LoadTexture("ParallelQuestion");
            LoadTexture("Reactive");
            LoadTexture("Shuffle");
            LoadTexture("ShuffleQuestion");

            LoadTexture("Exclamation");
            LoadTexture("RepeatArrow");
            LoadTexture("Condition");

            LoadTexture("Interruptor");
            LoadTexture("Interruptable");
            LoadTexture("Shield");
            LoadTexture("RepeatCheckmark");
            LoadTexture("RepeatCross");
            LoadTexture("SmallCheckmark");
            LoadTexture("SmallCross");

            LoadTexture("Play");
            LoadTexture("Timer");
            LoadTexture("Log");
            LoadTexture("Hourglass");

            LoadTexture("Mouse");
            LoadTexture("Keyboard");

            LoadTexture("GrayGradient");
            LoadTexture("DarkGray");
            LoadTexture("LightGray");
            LoadTexture("Grid");
            LoadTexture("AbortHighlightGradient");
            LoadTexture("ReferenceHighlightGradient");
            LoadTexture("GrayGradientFresnel");
            LoadTexture("GreenGradient");
            LoadTexture("ReevaluateHighlightGradient");

            LoadTexture("RootSymbol");
            LoadTexture("Cross");
            LoadTexture("Checkmark");

            LoadTexture("RightChevron");
            LoadTexture("BottomChevron");
            LoadTexture("DoubleChevron");

            LoadTexture("TreeIcon");
        }

        public static void LoadTexture(string name, TexType type = TexType.PNG)
        {
            string path = kStandardAssetPath + name + GetTexTypeExtension(type);
            var tex = AssetDatabase.LoadAssetAtPath<Texture2D>(path);

            if (tex != null) {
                _textures.Add(name, tex);
            }

            else {
                Debug.LogError("The texture: " + path + " could not be found.");
            }
        }

        public static string GetTexTypeExtension(TexType type)
        {
            switch (type) {
                case TexType.PNG: return ".png";
                case TexType.JPEG: return ".jpg";
            }

            return "";
        }

        public static Texture2D GetTexture(string name)
        {
            if (name == null) {
                Debug.LogError("The texture: " + name + " is not loaded in the Bonsai Resources texture library.");
                return null;
            }

            if (_textures.ContainsKey(name)) {
                return _textures[name];
            }

            return null;
        }
    }
}