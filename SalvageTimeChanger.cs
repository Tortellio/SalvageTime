using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using System;
using Steamworks;
using SDG.Unturned;
using Logger = Rocket.Core.Logging.Logger;
using System.Collections.Generic;
using System.Linq;

namespace Tortellio.SalvageTimeChanger
{
    public class SalvageTimeChanger : RocketPlugin
    {
        public static SalvageTimeChanger Instance;
        public static string PluginName = "SalvageTimeChanger";
        public static string PluginVersion = " 1.0.0";

        protected override void Load()
        {
            Instance = this;
            Logger.Log("SalvageTimeChanger has been loaded!");
            Logger.Log(PluginName + PluginVersion, ConsoleColor.Yellow);
            Logger.Log("Made by Tortellio", ConsoleColor.Yellow);
        }

        protected override void Unload()
        {
            Instance = null;
            Logger.Log("SalvageTimeChanger has been unloaded!");
            Logger.Log("Visit Tortellio Discord for more! https://discord.gg/pzQwsew", ConsoleColor.Yellow);
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "invalid_time", "Invalid amount of time! Usage: /salvagetime <seconds>" },
            { "usage", "Usage: /salvagetime <seconds>" },
            { "salvagetime_changed", "Your salvage time has changed to {0} seconds!" },
        };
    }
}
