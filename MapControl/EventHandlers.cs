using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MapControl.Commands.GateLockdown;
using MapControl.Commands.ToggleTeslaGates;
using MEC;

namespace MapControl
{
    class EventHandlers
    {

        public static Boolean inLockdown = false;
        public static Boolean hasfirstTeslaMTFAnnouncement = false;

        public void OnRoundBegin()
        {
            if (Plugin.Singleton.Config.EnableRandomGatelockdowns == true)
            {
                Plugin.Coroutines.Add(Timing.RunCoroutine(AutomaticGateLockdown()));
            }

            if(Plugin.Singleton.Config.TeslaGatesEnabled == false)
            {
                ToggleTeslaGates.isActive = false;
            }
        }

        public void OnRestartingRound()
        {
            foreach (CoroutineHandle coroutine in Plugin.Coroutines)
                Timing.KillCoroutines(coroutine);

            hasfirstTeslaMTFAnnouncement = false;
        }

        public void onRoundEnd(RoundEndedEventArgs ev)
        {
            foreach (CoroutineHandle coroutine in Plugin.Coroutines)
                Timing.KillCoroutines(coroutine);

            hasfirstTeslaMTFAnnouncement = false;
        }



        public void onTriggerTesla(TriggeringTeslaEventArgs ev)
        {
            if(ToggleTeslaGates.isActive == false)
                ev.IsTriggerable = false;

            if (Plugin.Singleton.Config.TeslaBypassClasses.Contains(ev.Player.Role))
            {
                if(Plugin.Singleton.Config.TeslaMTFAnnouncementEnabled == true && hasfirstTeslaMTFAnnouncement == false)
                {
                    Cassie.Message(Plugin.Singleton.Config.TeslaMTFAnnouncement);
                    hasfirstTeslaMTFAnnouncement = true;
                }

                ev.IsTriggerable = false;
            }
                


        }



        public IEnumerator<float> AutomaticGateLockdown()
        {
            Random r = new Random();
            int chance = r.Next(1, 101);
            int time = r.Next(Plugin.Singleton.Config.RandomGateLockdownMinTime, Plugin.Singleton.Config.RandomGateLockdownMaxTime);
            while (true)
            {
                yield return Timing.WaitForSeconds(Plugin.Singleton.Config.RandomGateLockdownIntervall);
                if (chance <= Plugin.Singleton.Config.RandomGateLockdownChance)
                {
                    if(Plugin.Singleton.Config.EnableRandomGateLockdownBroadcasts)
                        Map.Broadcast(Plugin.Singleton.Config.GateLockdownBroadcastDuration, Plugin.Singleton.Config.GateLockdownBroadcast);

                    if (Plugin.Singleton.Config.EnableRandomGateLockdownCassie)
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
                    Plugin.Coroutines.Add(Timing.RunCoroutine(GateLockdown.gateLockdownTime(time, true)));
                    inLockdown = true;
                }

                yield return Timing.WaitForOneFrame;
            }
        }

        public IEnumerator<float> UnlockGateLockdown(float time)
        {
            yield return Timing.WaitForSeconds(time);
            inLockdown = false;
        }

    }
}
