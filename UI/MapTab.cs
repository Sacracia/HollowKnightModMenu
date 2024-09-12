using UnityEngine;

namespace HollowKnightModMenu.UI
{
    internal class MapTab : BaseTab
    {
        private static MapTab s_instance;

        public static new MapTab Instance
        {
            get
            {
                if (s_instance == null) { s_instance = new MapTab(); }
                return s_instance;
            }
        }
        public override string Name { get; set; } = "Map";

        private MapTab() { }

        public override void DrawElements()
        {
            PlayerData playerData = PlayerData.instance;
            if (playerData != null)
            {
                GUILayout.BeginVertical("Unlockable", GUI.skin.box);
                GUILayout.Space(20f);
                playerData.hasMap = GUILayout.Toggle(playerData.hasMap, "Has map");
                playerData.openedMapperShop = GUILayout.Toggle(playerData.openedMapperShop, "Mapper shop");
                playerData.hasQuill = GUILayout.Toggle(playerData.hasQuill, "Has quill");
                playerData.gotCharm_2 = GUILayout.Toggle(playerData.gotCharm_2, "Has compass");
                GUILayout.EndVertical();

                GUILayout.Space(10);

                GUILayout.BeginVertical("Unlocked regions", GUI.skin.box);
                GUILayout.Space(20f);
                GUILayout.BeginHorizontal();
                playerData.mapDirtmouth = GUILayout.Toggle(playerData.mapDirtmouth, "Dirtmouth");
                playerData.mapCrossroads = GUILayout.Toggle(playerData.mapCrossroads, "Crossroads");
                playerData.mapGreenpath = GUILayout.Toggle(playerData.mapGreenpath, "Greenpath");
                playerData.mapFogCanyon = GUILayout.Toggle(playerData.mapFogCanyon, "FogCanyon");
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                playerData.mapRoyalGardens = GUILayout.Toggle(playerData.mapRoyalGardens, "Royal Gardens");
                playerData.mapFungalWastes = GUILayout.Toggle(playerData.mapFungalWastes, "Fungal Wastes");
                playerData.mapCity = GUILayout.Toggle(playerData.mapCity, "City");
                playerData.mapWaterways = GUILayout.Toggle(playerData.mapWaterways, "Waterways");
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                playerData.mapMines = GUILayout.Toggle(playerData.mapMines, "Mines");
                playerData.mapDeepnest = GUILayout.Toggle(playerData.mapDeepnest, "Deepnest");
                playerData.mapCliffs = GUILayout.Toggle(playerData.mapCliffs, "Cliffs");
                playerData.mapOutskirts = GUILayout.Toggle(playerData.mapOutskirts, "Outskirts");
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                playerData.mapRestingGrounds = GUILayout.Toggle(playerData.mapRestingGrounds, "Resting Grounds");
                playerData.mapAbyss = GUILayout.Toggle(playerData.mapAbyss, "Abyss");
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();

                GUILayout.Space(10f);

                GUILayout.BeginVertical("Pins", GUI.skin.box);
                GUILayout.Space(20f);
                GUILayout.BeginHorizontal();
                playerData.hasPin = GUILayout.Toggle(playerData.hasPin, "Has pin");
                playerData.hasPinBench = GUILayout.Toggle(playerData.hasPinBench, "Bench");
                playerData.hasPinCocoon = GUILayout.Toggle(playerData.hasPinCocoon, "Cocoon");
                playerData.hasPinDreamPlant = GUILayout.Toggle(playerData.hasPinDreamPlant, "Dream plant");
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                playerData.hasPinGuardian = GUILayout.Toggle(playerData.hasPinGuardian, "Guardian");
                playerData.hasPinBlackEgg = GUILayout.Toggle(playerData.hasPinBlackEgg, "Black egg");
                playerData.hasPinShop = GUILayout.Toggle(playerData.hasPinShop, "Shop");
                playerData.hasPinSpa = GUILayout.Toggle(playerData.hasPinSpa, "Spa");
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                playerData.hasPinStag = GUILayout.Toggle(playerData.hasPinStag, "Stag");
                playerData.hasPinTram = GUILayout.Toggle(playerData.hasPinTram, "Tram");
                playerData.hasPinGhost = GUILayout.Toggle(playerData.hasPinGhost, "Ghost");
                playerData.hasPinGrub = GUILayout.Toggle(playerData.hasPinGrub, "Grub");
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
            }
            else
            {
                GUILayout.BeginVertical(GUI.skin.box);
                GUILayout.Label("Load a game to see options", Utils.WarningLabelStyle);
                GUILayout.EndVertical();
            }
        }
    }
}
