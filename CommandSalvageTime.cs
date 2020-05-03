using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Tortellio.SalvageTimeChanger.Commands
{
    public class CommandSalvageTime : IRocketCommand
    {
        public string Name => "salvagetime";
        public string Help => "Change your salvage time";
        public string Syntax => "<seconds>";
        public List<string> Aliases => new List<string>() { "stime" };
        public List<string> Permissions => new List<string>() { "salvagetime" };
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (caller == null) return;
            UnturnedPlayer player = (UnturnedPlayer)caller;
            
            if (command.Length != 1)
            {
                UnturnedChat.Say(caller, SalvageTimeChanger.Instance.Translate("usage"), Color.green, "https://i.imgur.com/FeIvao9.png");
                return;
            }

            if (!byte.TryParse(command[0], out byte result))
            {
                UnturnedChat.Say(caller, SalvageTimeChanger.Instance.Translate("invalid_time"), Color.green, "https://i.imgur.com/FeIvao9.png");
                return;
            }

            if (result < 1) player.Player.interact.sendSalvageTimeOverride(1);
            else player.Player.interact.sendSalvageTimeOverride(result);
            UnturnedChat.Say(caller, SalvageTimeChanger.Instance.Translate("salvagetime_changed", result.ToString()), Color.green, "https://i.imgur.com/6EoLIWM.png");
            return;
        }
    }
}
