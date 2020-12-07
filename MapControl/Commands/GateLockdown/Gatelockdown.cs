using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using MapControl;
using MEC;
using Respawning;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapControl.Commands.GateLockdown
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    class GateLockdown : ParentCommand
    {
        public GateLockdown() => LoadGeneratedCommands();

        public override string Command { get; } = "gatelockdown";

        public override string[] Aliases { get; } = new string[] { "gl"};

        public override string Description { get; } = "Lock the surface gates";

        public override void LoadGeneratedCommands() { }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            if (!((CommandSender)sender).CheckPermission("mc.gatelockdown"))
            {
                response = "You do not have the required permissions to run this command!";
                return false;
            }

            if (arguments.Count == 1)
            {
                if (!Warhead.IsDetonated)
                {
                    if (EventHandlers.inLockdown == false)
                    {
                        switch (arguments.At(0).ToLower())
                        {
                            case "true":
                                Map.ClearBroadcasts();
                                Map.Broadcast(Plugin.Singleton.Config.GateLockdownBroadcastDuration, Plugin.Singleton.Config.GateLockdownBroadcast);
                                Cassie.Message(Plugin.Singleton.Config.GateLockdownCassieAnnouncement, true);
                                foreach (Door door in Map.Doors)
                                {
                                    if (door.DoorName.Contains("GATE_A") && door.doorType == Door.DoorTypes.HeavyGate)
                                    {
                                        door.NetworkisOpen = false;
                                        door.SetLock(true);
                                    }

                                    if (door.DoorName.Contains("GATE_B") && door.doorType == Door.DoorTypes.HeavyGate)
                                    {
                                        door.NetworkisOpen = false;
                                        door.SetLock(true);
                                    }
                                }
                                EventHandlers.inLockdown = true;
                                response = "Gate A and B have been locked down!";
                                return true;

                            case "false":
                                foreach (Door door in Map.Doors)
                                {
                                    if (door.DoorName.Contains("GATE_A") && door.doorType == Door.DoorTypes.HeavyGate)
                                    {
                                        door.NetworkisOpen = false;
                                        door.SetLock(true);
                                    }

                                    if (door.DoorName.Contains("GATE_B") && door.doorType == Door.DoorTypes.HeavyGate)
                                    {
                                        door.NetworkisOpen = false;
                                        door.SetLock(true);
                                    }
                                }
                                EventHandlers.inLockdown = true;
                                response = "Gate A and B have been locked down!";
                                return true;

                            default:
                                response = "Usage: gatelockdown <true/false> <Seconds>";
                                return false;
                        }
                    }
                    else
                    {
                        switch (arguments.At(0).ToLower())
                        {
                            case "true":
                                Map.ClearBroadcasts();
                                Map.Broadcast(Plugin.Singleton.Config.GateLockdownBroadcastDuration, Plugin.Singleton.Config.GateLockdownUnlockBroadcast);
                                Cassie.Message(Plugin.Singleton.Config.GateLockdownUnlockCassieAnnouncement, true);
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
                                EventHandlers.inLockdown = false;
                                response = "The gates to surface are now open!";
                                return true;

                            case "false":
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
                                EventHandlers.inLockdown = false;
                                response = "The gates to surface are now open!";
                                return true;

                            default:
                                response = "Usage: gatelockdown <true/false> <Seconds>";
                                return false;
                        }
                    }

                }
                else
                {
                    response = "The nuke has already been detonated. There are no gates you could lock lol";
                    return false;
                }
            }
            else if (arguments.Count == 2)
            {
                if (!Warhead.IsDetonated)
                {
                    var isNumeric = int.TryParse(arguments.At(1), out int n);
                    if (isNumeric == true)
                    {
                        if (EventHandlers.inLockdown == false)
                        {
                            switch (arguments.At(0).ToLower())
                            {
                                case "true":
                                    Map.ClearBroadcasts();
                                    Map.Broadcast(Plugin.Singleton.Config.GateLockdownBroadcastDuration, Plugin.Singleton.Config.GateLockdownBroadcastwithTimer.Replace("%time%", n.ToString()));
                                    Cassie.Message(Plugin.Singleton.Config.GateLockdownCassieAnnouncement, true);
                                    foreach (Door door in Map.Doors)
                                    {
                                        if (door.DoorName.Contains("GATE_A") && door.doorType == Door.DoorTypes.HeavyGate)
                                        {
                                            door.NetworkisOpen = false;
                                            door.SetLock(true);
                                        }

                                        if (door.DoorName.Contains("GATE_B") && door.doorType == Door.DoorTypes.HeavyGate)
                                        {
                                            door.NetworkisOpen = false;
                                            door.SetLock(true);
                                        }
                                    }
                                    EventHandlers.inLockdown = true;
                                    Timing.RunCoroutine(gateLockdownTime(n, true));
                                    response = "The gates to surface are now locked down!";
                                    return true;

                                case "false":
                                    foreach (Door door in Map.Doors)
                                    {
                                        if (door.DoorName.Contains("GATE_A") && door.doorType == Door.DoorTypes.HeavyGate)
                                        {
                                            door.NetworkisOpen = false;
                                            door.SetLock(true);
                                        }

                                        if (door.DoorName.Contains("GATE_B") && door.doorType == Door.DoorTypes.HeavyGate)
                                        {
                                            door.NetworkisOpen = false;
                                            door.SetLock(true);
                                        }
                                    }
                                    EventHandlers.inLockdown = true;
                                    Timing.RunCoroutine(gateLockdownTime(n, false));
                                    response = "The gates to surface are now locked down!";
                                    return true;

                                default:
                                    response = "Usage: gatelockdown <true/false> <Seconds>";
                                    return false;
                            }
                        }
                        else
                        {
                            response = "stop messing arround pal";
                            return false;
                        }
                    }
                    else
                    {
                        response = "a number is something like this: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9. shall we try again?";
                        return false;
                    }

                }
                else
                {
                    response = "The nuke has already been detonated. There are no gates you could lock lol";
                    return false;
                }
            }
            else
            {
                response = "Usage: gatelockdown <true/false> <Seconds>";
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
