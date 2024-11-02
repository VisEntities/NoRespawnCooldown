/*
 * Copyright (C) 2024 Game4Freak.io
 * This mod is provided under the Game4Freak EULA.
 * Full legal terms can be found at https://game4freak.io/eula/
 */

using HarmonyLib;

namespace Oxide.Plugins
{
    [Info("No Respawn Cooldown", "VisEntities", "1.0.0")]
    [Description("Lets players use the respawn command without any cooldown.")]
    public class NoRespawnCooldown : RustPlugin
    {
        #region Fields

        private static NoRespawnCooldown _plugin;
        private Harmony _harmony;

        #endregion Fields

        #region Oxide Hooks

        private void Init()
        {
            _plugin = this;
            _harmony = new Harmony(Name + "PATCH");
            _harmony.PatchAll();
        }

        private void Unload()
        {
            _harmony.UnpatchAll(Name + "PATCH");
            _plugin = null;
        }

        #endregion Oxide Hooks

        #region Harmony Patches

        [HarmonyPatch(typeof(BasePlayer), "MarkRespawn")]
        public static class BasePlayer_MarkRespawn_Patch
        {
            public static bool Prefix(BasePlayer __instance, ref float nextSpawnDelay)
            {
                nextSpawnDelay = 0f;
                return true;
            }
        }

        #endregion Harmony Patches
    }
}