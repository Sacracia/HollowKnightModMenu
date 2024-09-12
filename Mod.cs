using HarmonyLib;
using HollowKnightModMenu.UI;
using UnityEngine;

namespace HollowKnightModMenu
{
    public class Mod
    {
        private static Harmony s_harmony = new Harmony("hollowkn.mod.sacracia");
        private static GameObject s_gameObject;

        public static void Load()
        {
            s_gameObject = new GameObject();
            s_gameObject.AddComponent<Menu>();
            s_gameObject.hideFlags = UnityEngine.HideFlags.HideAndDontSave;
            UnityEngine.Object.DontDestroyOnLoad(s_gameObject);
            s_harmony.PatchAll();
        }

        public static void Unload()
        {
            s_harmony.UnpatchAll();
            UnityEngine.Object.Destroy(s_gameObject);
        }
    }
}
