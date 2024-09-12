using UnityEngine;

namespace HollowKnightModMenu.UI
{
    internal class Menu : MonoBehaviour
    {
        private Rect _window = new Rect(10f, 10f, 400f, 600f);
        private BaseTab _currentTab = HeroTab.Instance;
        private Vector2 _scrollPos;

        public static bool Show { get; private set; } = true;

        private void OnWindow(int id)
        {
            GUI.skin.box.fontStyle = FontStyle.Bold;
            GUI.skin.verticalScrollbar.fixedWidth = 10;
            GUI.skin.verticalScrollbarThumb.fixedWidth = 10;
            GUILayout.Space(5);

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Hero") && !(_currentTab is HeroTab)) { _currentTab = HeroTab.Instance; _scrollPos = new Vector2(0, 0); }
            if (GUILayout.Button("Map") && !(_currentTab is MapTab)) { _currentTab = MapTab.Instance; _scrollPos = new Vector2(0, 0); }
            if (GUILayout.Button("PowerUps")) { _currentTab = PowerUpsTab.Instance; _scrollPos = new Vector2(0, 0); }
            GUILayout.EndHorizontal();

            GUILayout.Space(5f);

            _scrollPos = GUILayout.BeginScrollView(_scrollPos);
            _currentTab.DrawElements();
            GUILayout.EndScrollView();

            GUILayout.BeginVertical(GUI.skin.box);
            GUILayout.Label("Press <b><color=#ff8e00>Backquote(`)</color></b> to show/hide menu", Utils.WarningLabelStyle);
            GUILayout.EndVertical();

            GUI.DragWindow();
        }

        private void OnGUI()
        {
            if (Show)
            {
                _window = GUILayout.Window(0, _window, OnWindow, _currentTab.Name, Utils.WindowStyle);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.BackQuote)) { Show = !Show; }
            HeroTab.Instance.Update();
        }
    }
}
