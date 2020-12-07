using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using MapControl;
using MEC;
using Respawning;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapControl.Commands.ToggleTeslaGates
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    class ToggleTeslaGates : ParentCommand
    {

        public static bool isActive = true;
        public ToggleTeslaGates() => LoadGeneratedCommands();

        public override string Command { get; } = "toggleteslagates";

        public override string[] Aliases { get; } = new string[] { "ttg"};

        public override string Description { get; } = "Activate/Deactivate the tesla gates";

        public override void LoadGeneratedCommands() { }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            if (!((CommandSender)sender).CheckPermission("mc.toggleteslagates"))
            {
                response = "You do not have the required permissions to run this command!";
                return false;
            }

            if (arguments.Count == 0)
            {
                if(isActive == true)
                {
                        isActive = false;
                    response = "All Tesla gates have been disabled!";
                    return true;
                } else
                {

                        isActive = true;
                    response = "All Tesla gates have been enabled!";
                    return true;
                }
            }
            
            else
            {
                response = "Usage: toggleteslagates";
                return false;
            }






        }

        public static IEnumerator<float> gateLockdownTime(float time, Boolean wannaBroadcast)
        {
            yield return Timing.WaitForSeconds(time);
            EventHandlers.inLockdown = false;
            foreach (Door door in Map.Doors)
            {
                if (door.DoorName.Contains("GATE_A") && door.doorType == Door.DoorTypes.HeavyGate)
                {
                    door.NetworkisOpen = true;
                    door.SetLock(false);
                }

                if (door.DoorName.Contains("GATE_B") && door.doorType == Door.DoorTypes.HeavyGate)
                {
                    door.NetworkisOpen = true;
                    door.SetLock(false);
                }
            }

            if (wannaBroadcast == true)
            {
                Map.ClearBroadcasts();
                Map.Broadcast(Plugin.Singleton.Config.GateLockdownBroadcastDuration, Plugin.Singleton.Config.GateLockdownUnlockBroadcast);
                Cassie.Message(Plugin.Singleton.Config.GateLockdownUnlockCassieAnnouncement, true);
            }

        }
    }
}
