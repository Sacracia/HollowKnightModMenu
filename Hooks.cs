using HarmonyLib;
using HollowKnightModMenu.UI;

namespace HollowKnightModMenu
{
    internal class Hooks
    {
        [HarmonyPatch(typeof(InputHandler), "SetCursorEnabled")]
        public class Hook_SetCursorEnabled
        {
            [HarmonyPrefix]
            public static void SetCursorEnabled(ref bool isEnabled)
            {
                if (Menu.Show) { isEnabled = true; }
            }
        }

        [HarmonyPatch(typeof(HeroController), "CanAttack")]
        public class Hook_CanAttack
        {
            [HarmonyPrefix]
            public static bool CanAttack(ref bool __result)
            {
                if (HeroTab.FastAttacks) { __result = true; }
                return !HeroTab.FastAttacks;
            }
        }

        [HarmonyPatch(typeof(HeroController), "CanDash")]
        public class Hook_CanDash
        {
            [HarmonyPrefix]
            public static bool CanDash(ref bool __result)
            {
                if (HeroTab.InfiniteDashes) { __result = true; }
                return !HeroTab.InfiniteDashes;
            }
        }

        [HarmonyPatch(typeof(HeroController), "AddGeo")]
        public class Hook_AddGeo
        {
            [HarmonyPrefix]
            public static void AddGeo(ref int amount)
            {
                amount *= HeroTab.GeoMultiplier;
            }
        }

        [HarmonyPatch(typeof(CheatManager), "IsInstaKillEnabled", MethodType.Getter)]
        public class Hook_get_IsInstaKillEnabled
        {
            [HarmonyPrefix]
            public static bool IsInstaKillEnabled(ref bool __result)
            {
                if (HeroTab.InstaKill) { __result = true; }
                return !HeroTab.InstaKill;
            }
        }

        [HarmonyPatch(typeof(HeroController), "Move")]
        public class Hook_Move
        {
            [HarmonyPrefix]
            public static void Move(ref float move_direction)
            {
                move_direction *= HeroTab.SpeedMultiplier;
            }
        }

        [HarmonyPatch(typeof(HeroController), "Update")]
        public class Hook_Update
        {
            [HarmonyPrefix]
            public static void Update(HeroController __instance)
            {
                int curMp = __instance.playerData.MPCharge;
                int maxMp = __instance.playerData.maxMP;
                if (curMp < maxMp && HeroTab.InfiniteSoul)
                {
                    __instance.AddMPCharge(__instance.playerData.maxMP - __instance.playerData.MPCharge);
                }
            }
        }
    }
}
