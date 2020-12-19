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
    class StartDecontamination : ParentCommand
    {
       
        public StartDecontamination() => LoadGeneratedCommands();

        public override string Command { get; } = "startdecontamination";

        public override string[] Aliases { get; } = new string[] { "sd"};

        public override string Description { get; } = "Start the Decontamination";

        public override void LoadGeneratedCommands() { }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            if (!((CommandSender)sender).CheckPermission("mc.startdecontamination"))
            {
                response = "You do not have the required permissions to run this command!";
                return false;

            }
            
            if (arguments.Count == 0)
            {
                Map.StartDecontamination();
                response = "Decontamination started";
                return true;
            }
            
            else
            {
                response = "Usage: startdecontamination";
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
