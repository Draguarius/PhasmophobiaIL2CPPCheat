using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TestMod
{
    // Credit to Zat from UC: https://www.unknowncheats.me/forum/unity/285864-beginners-guide-hacking-unity-games.html
    public static class UIHelper
    {
        private static float
            x, y,
            width, height,
            margin,
            controlHeight,
            controlDist,
            nextControlY;

        public static void Begin(string text, float _x, float _y, float _width, float _height, float _margin, float _controlHeight, float _controlDist)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            margin = _margin;
            controlHeight = _controlHeight;
            controlDist = _controlDist;
            nextControlY = 30f;

            GUI.Box(new Rect(x, y, width, height), text);
        }

        private static Rect NextControlRect()
        {
            Rect r = new Rect(x + margin, nextControlY, width - margin * 2, controlHeight);
            nextControlY += controlHeight + controlDist;
            return r;
        }

        public static string MakeEnable(string text, bool state)
        {
            return string.Format("{0}{1}", text, state ? "<color=#7CFC00>ON</color>" : "<color=#EB2E2E>OFF</color>");
        }

        public static bool Button(string text, bool state)
        {
            return Button(MakeEnable(text, state));
        }

        public static string TextField(string name, float customY = -1, float width = -1f)
        {
            var r = NextControlRect();

            if (width > 0f)
                r.width = width;

            if (customY > -1f)
                r.y = customY;

            return GUI.TextField(NextControlRect(), name);
        }

        public static bool Button(string text)
        {
            return GUI.Button(NextControlRect(), text);
        }

        public static void Label(string text, float value, int decimals = 2)
        {
            Label(string.Format("{0}{1}", text, Math.Round(value, 2).ToString()));
        }

        public static void Label(string text)
        {
            GUI.Label(NextControlRect(), text);
        }

        public static float Slider(float val, float min, float max)
        {
            return GUI.HorizontalSlider(NextControlRect(), val, min, max);
        }

        public static bool Checkbox(bool toggle, string text)
        {
            return GUI.Toggle(NextControlRect(), toggle, text);
        }
    }
}
