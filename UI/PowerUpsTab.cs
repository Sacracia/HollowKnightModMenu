using UnityEngine;

namespace HollowKnightModMenu.UI
{
    internal class PowerUpsTab : BaseTab
    {
        private static PowerUpsTab s_instance;
        private string[] _spell1Levels = { "Locked", "Vengeful Spirit", "Shade Soul" };
        private string[] _spell2Levels = { "Locked", "Desolate Dive", "Descending Dark" };
        private string[] _spell3Levels = { "Locked", "Howling Wraiths", "Abyss Shriek" };

        public static new PowerUpsTab Instance
        {
            get
            {
                if (s_instance == null) { s_instance = new PowerUpsTab(); }
                return s_instance;
            }
        }
        public override string Name { get; set; } = "PowerUps";
        public int Spell1
        {
            get => PlayerData.instance.hasSpell ? PlayerData.instance.fireballLevel : 0;
            set
            {
                if (value > 0) { PlayerData.instance.hasSpell = true; }
                PlayerData.instance.fireballLevel = value;
            }
        }
        public int Spell2
        {
            get => PlayerData.instance.hasSpell ? PlayerData.instance.quakeLevel : 0;
            set
            {
                if (value > 0) { PlayerData.instance.hasSpell = true; }
                PlayerData.instance.quakeLevel = value;
            }
        }
        public int Spell3
        {
            get => PlayerData.instance.hasSpell ? PlayerData.instance.screamLevel : 0;
            set
            {
                if (value > 0) { PlayerData.instance.hasSpell = true; }
                PlayerData.instance.screamLevel = value;
            }
        }
        public bool HasDashSlash
        {
            get => HeroController.instance.playerData.hasNailArt && HeroController.instance.playerData.hasDashSlash;
            set
            {
                HeroController.instance.playerData.hasDashSlash = value;
                if (value) { HeroController.instance.playerData.hasNailArt = true; }
            }
        }
        public bool HasCyclone
        {
            get => HeroController.instance.playerData.hasNailArt && HeroController.instance.playerData.hasCyclone;
            set
            {
                HeroController.instance.playerData.hasCyclone = value;
                if (value) { HeroController.instance.playerData.hasNailArt = true; }
            }
        }
        public bool HasUpwardSlash
        {
            get => HeroController.instance.playerData.hasNailArt && HeroController.instance.playerData.hasUpwardSlash;
            set
            {
                HeroController.instance.playerData.hasUpwardSlash = value;
                if (value) { HeroController.instance.playerData.hasNailArt = true; }
            }
        }

        private PowerUpsTab() { }

        private void GetAllCharms(PlayerData playerData)
        {
            playerData.hasCharm = true;
            playerData.gotCharm_1 = true;
            playerData.gotCharm_2 = true;
            playerData.gotCharm_3 = true;
            playerData.gotCharm_4 = true;
            playerData.gotCharm_5 = true;
            playerData.gotCharm_6 = true;
            playerData.gotCharm_7 = true;
            playerData.gotCharm_8 = true;
            playerData.gotCharm_9 = true;
            playerData.gotCharm_10 = true;
            playerData.gotCharm_11 = true;
            playerData.gotCharm_12 = true;
            playerData.gotCharm_13 = true;
            playerData.gotCharm_14 = true;
            playerData.gotCharm_15 = true;
            playerData.gotCharm_16 = true;
            playerData.gotCharm_17 = true;
            playerData.gotCharm_18 = true;
            playerData.gotCharm_19 = true;
            playerData.gotCharm_20 = true;
            playerData.gotCharm_21 = true;
            playerData.gotCharm_22 = true;
            playerData.gotCharm_23 = true;
            playerData.gotCharm_24 = true;
            playerData.gotCharm_25 = true;
            playerData.gotCharm_26 = true;
            playerData.gotCharm_27 = true;
            playerData.gotCharm_28 = true;
            playerData.gotCharm_29 = true;
            playerData.gotCharm_30 = true;
            playerData.gotCharm_31 = true;
            playerData.gotCharm_32 = true;
            playerData.gotCharm_33 = true;
            playerData.gotCharm_34 = true;
            playerData.gotCharm_35 = true;
            playerData.gotCharm_37 = true;
            playerData.gotCharm_38 = true;
            playerData.gotCharm_39 = true;
            playerData.charmSlots = 11;
        }

        public override void DrawElements()
        {
            PlayerData playerData = PlayerData.instance;
            if (playerData != null)
            {
                GUILayout.BeginVertical("Spells", GUI.skin.box);
                GUILayout.Space(20f);
                GUILayout.Label($"Skill1: {_spell1Levels[Spell1]}");
                Spell1 = Mathf.RoundToInt(GUILayout.HorizontalSlider(Spell1, 0f, 2f));
                GUILayout.Space(5f);
                GUILayout.Label($"Skill2: {_spell2Levels[Spell2]}");
                Spell2 = Mathf.RoundToInt(GUILayout.HorizontalSlider(Spell2, 0f, 2f));
                GUILayout.Space(5f);
                GUILayout.Label($"Skill3: {_spell3Levels[Spell3]}");
                Spell3 = Mathf.RoundToInt(GUILayout.HorizontalSlider(Spell3, 0f, 2f));
                GUILayout.EndVertical();

                GUILayout.Space(10f);

                GUILayout.BeginVertical("Abilities", GUI.skin.box);
                GUILayout.Space(20f);
                playerData.hasAcidArmour = GUILayout.Toggle(playerData.hasAcidArmour, "Isma\'s tear");

                GUILayout.Space(5f);
                playerData.hasDreamNail = GUILayout.Toggle(playerData.hasDreamNail, "Dream nail");
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("+1 dream orb")) { playerData.dreamOrbs += 1; }
                if (GUILayout.Button("+10 dream orbs")) { playerData.dreamOrbs += 10; }
                if (GUILayout.Button("+100 dream orbs")) { playerData.dreamOrbs += 100; }
                GUILayout.EndHorizontal();

                GUILayout.Space(5f);
                playerData.dreamNailUpgraded = GUILayout.Toggle(playerData.dreamNailUpgraded, "Awoken dream nail");
                playerData.hasDreamGate = GUILayout.Toggle(playerData.hasDreamGate, "Dreamgate");
                GUILayout.EndVertical();

                GUILayout.Space(10f);

                GUILayout.BeginVertical("Keys", GUI.skin.box);
                GUILayout.Space(20f);
                playerData.hasCityKey = GUILayout.Toggle(playerData.hasCityKey, "City crest");
                playerData.hasWhiteKey = GUILayout.Toggle(playerData.hasWhiteKey, "Elegant key");
                playerData.hasKingsBrand = GUILayout.Toggle(playerData.hasKingsBrand, "Kings brand");
                playerData.hasLoveKey = GUILayout.Toggle(playerData.hasLoveKey, "Love key");
                playerData.hasSlykey = GUILayout.Toggle(playerData.hasSlykey, "Shopkeeper\'s Key");
                if (GUILayout.Button("Add simple key")) { playerData.simpleKeys += 1; }
                GUILayout.EndVertical();

                GUILayout.Space(10f);

                GUILayout.BeginVertical("Exprolation and Quests", GUI.skin.box);
                GUILayout.Space(20f);
                playerData.hasTramPass = GUILayout.Toggle(playerData.hasTramPass, "Tram pass");
                playerData.hasLantern = GUILayout.Toggle(playerData.hasLantern, "Lumafly lantern");
                playerData.hasJournal = GUILayout.Toggle(playerData.hasJournal, "Hunter\'s journal");
                playerData.hasHuntersMark = GUILayout.Toggle(playerData.hasHuntersMark, "Hunter\'s mask");
                playerData.hasXunFlower = GUILayout.Toggle(playerData.hasSlykey, "Delicate flower");
                playerData.hasGodfinder = GUILayout.Toggle(playerData.hasGodfinder, "Godtuner");
                GUILayout.EndVertical();

                if (GUILayout.Button("Get all charms")) { GetAllCharms(playerData); }
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
