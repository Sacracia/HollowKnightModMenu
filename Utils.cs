using UnityEngine;

namespace HollowKnightModMenu
{
    internal class Utils
    {
        public static char LeftArrow = '\u25C0';
        public static char RightArrow = '\u25B6';

        public static GUIStyle WarningLabelStyle
        {
            get
            {
                GUIStyle style = new GUIStyle(GUI.skin.label);
                style.alignment = TextAnchor.MiddleCenter;
                style.normal.textColor = new Color(1f, 0.6f, 0f);
                return style;
            }
        }

        public static GUIStyle WarningRawLabelStyle
        {
            get
            {
                GUIStyle style = new GUIStyle(GUI.skin.label);
                style.normal.textColor = new Color(1f, 0.6f, 0f);
                return style;
            }
        }

        public static GUIStyle CenteredLabelStyle
        {
            get
            {
                GUIStyle style = new GUIStyle(GUI.skin.label);
                style.alignment = TextAnchor.UpperCenter;
                return style;
            }
        }

        private static Texture2D MakeTex(int width, int height, Color color)
        {
            Color[] array = new Color[width * height];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = color;
            }
            Texture2D texture2D = new Texture2D(width, height);
            texture2D.SetPixels(array);
            texture2D.Apply();
            return texture2D;
        }

        public static GUIStyle WindowStyle
        {
            get
            {
                GUIStyle style = new GUIStyle(GUI.skin.window);
                style.normal.background = MakeTex(1, 1, new Color(0.1f, 0.1f, 0.1f, 1f));
                style.focused.background = MakeTex(1, 1, new Color(0.1f, 0.1f, 0.1f, 1f));
                style.onNormal.background = MakeTex(1, 1, new Color(0.1f, 0.1f, 0.1f, 1f));
                style.hover.background = MakeTex(1, 1, new Color(0.1f, 0.1f, 0.1f, 1f));
                style.normal.textColor = Color.white;
                style.focused.textColor = Color.white;
                style.onNormal.textColor = Color.white;
                style.hover.textColor = Color.white;
                return style;
            }
        }

        public static float ArrowSliderFloat(float v, float v_min, float v_max, float step, string content)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(content);
            if (v >= v_min + step && GUILayout.Button(LeftArrow.ToString()))
            {
                v -= step;
            }
            GUILayout.Label(v.ToString("f2"), CenteredLabelStyle);
            if (v <= v_max - step && GUILayout.Button(RightArrow.ToString()))
            {
                v += step;
            }
            GUILayout.EndHorizontal();
            return v;
        }
    }
}
