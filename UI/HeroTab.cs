using UnityEngine;

namespace HollowKnightModMenu.UI
{
    internal class HeroTab : BaseTab
    {
        private static HeroTab s_instance;
        private bool _invincible = false;

        public static new HeroTab Instance
        {
            get
            {
                if (s_instance == null) { s_instance = new HeroTab(); }
                return s_instance;
            }
        }
        public override string Name { get; set; } = "Hero";
        public static bool InfiniteJumps { get; private set; } = false;
        public static bool FastAttacks { get; private set; } = false;
        public static bool InfiniteDashes { get; private set; } = false;
        public static int GeoMultiplier { get; private set; } = 1;
        public static bool InstaKill { get; private set; } = false;
        public static int SpeedMultiplier { get; private set; } = 1;
        public static bool InfiniteSoul { get; private set; } = false;
        public bool HasDash
        {
            get => PlayerData.instance.hasDash && PlayerData.instance.canDash;
            set
            {
                PlayerData.instance.hasDash = value;
                PlayerData.instance.canDash = value;
            }
        }
        public bool HasShadowDash
        {
            get => PlayerData.instance.hasShadowDash && PlayerData.instance.canShadowDash 
                && PlayerData.instance.canDash && PlayerData.instance.hasDash;
            set
            {
                PlayerData playerData = PlayerData.instance;
                playerData.hasShadowDash = value;
                playerData.canShadowDash = value;
                if (value)
                {
                    playerData.hasDash = true;
                    playerData.canDash = true;
                }
            }
        }

        private HeroTab() { }

        public override void DrawElements()
        {
            HeroController hero = HeroController.SilentInstance;
            PlayerData playerData = PlayerData.instance;
            if (hero != null && playerData != null)
            {
                GUILayout.BeginVertical("Health", GUI.skin.box);
                GUILayout.Space(20f);
                _invincible = GUILayout.Toggle(_invincible, "Invincible");
                if (GUILayout.Button("Restore health")) { hero.AddHealth(playerData.maxHealth - playerData.health); }
                GUILayout.EndVertical();

                GUILayout.Space(10f);

                GUILayout.BeginVertical("Damage", GUI.skin.box);
                GUILayout.Space(20f);
                InstaKill = GUILayout.Toggle(InstaKill, "Insta kill");
                FastAttacks = GUILayout.Toggle(FastAttacks, "Fast attacks");
                GUILayout.EndVertical();

                GUILayout.Space(10f);

                GUILayout.BeginVertical("Movement", GUI.skin.box);
                GUILayout.Space(20f);
                GUILayout.Label($"Speed multiplier: {SpeedMultiplier}");
                SpeedMultiplier = Mathf.RoundToInt(GUILayout.HorizontalSlider(SpeedMultiplier, 1f, 5f));
                GUILayout.Space(5f);
                playerData.infiniteAirJump = GUILayout.Toggle(playerData.infiniteAirJump, "Infinite jumps");
                InfiniteDashes = GUILayout.Toggle(InfiniteDashes, "Dashes no cooldown");
                HasDash = GUILayout.Toggle(HasDash, "Dash unlocked");
                HasShadowDash = GUILayout.Toggle(HasShadowDash, "Shadow dash unlocked");
                GUILayout.Label($"Dash distance: {hero.DASH_SPEED:f1}");
                hero.DASH_SPEED = GUILayout.HorizontalSlider(hero.DASH_SPEED, 0f, 80f);
                GUILayout.EndVertical();

                GUILayout.Space(10f);

                GUILayout.BeginVertical("Geo", GUI.skin.box);
                GUILayout.Space(20f);
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("+100 geo")) { hero.AddGeo(100); }
                if (GUILayout.Button("+1000 geo")) { hero.AddGeo(1000); }
                if (GUILayout.Button("+10000 geo")) { hero.AddGeo(10000); }
                GUILayout.EndHorizontal();
                GUILayout.Label($"Geo multiplier: {GeoMultiplier:f0}");
                GeoMultiplier = Mathf.RoundToInt(GUILayout.HorizontalSlider(GeoMultiplier, 1f, 10f));
                GUILayout.EndVertical();

                GUILayout.Space(10f);

                GUILayout.BeginVertical("Misc", GUI.skin.box);
                GUILayout.Space(20f);
                InfiniteSoul = GUILayout.Toggle(InfiniteSoul, "Infinite soul");
                GUILayout.Label($"Time scale: {Time.timeScale:f1}");
                Time.timeScale = GUILayout.HorizontalSlider(Time.timeScale, 1f, 4f);
                if (GUILayout.Button("Unlock all achievements")) { GameManager.instance.achievementHandler.AwardAllAchievements(); }
                GUILayout.EndVertical();
            }
            else
            {
                GUILayout.BeginVertical(GUI.skin.box);
                GUILayout.Label("Load a game to see options", Utils.WarningLabelStyle);
                GUILayout.EndVertical();
            }
        }

        public void Update()
        {
            if (PlayerData.instance != null)
            {
                PlayerData.instance.isInvincible = _invincible;
            }
        }
    }
}
