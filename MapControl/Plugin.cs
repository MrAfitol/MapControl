using Exiled.API.Features;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerEvents = Exiled.Events.Handlers.Server;
using PlayerEvents = Exiled.Events.Handlers.Player;
using MapEvents = Exiled.Events.Handlers.Map;

namespace MapControl
{
    public class Plugin : Plugin<Config>
    {
        public override string Author { get; } = "Developed by TheVoidNebula";
        public override string Name { get; } = "MapControl";
        public override string Prefix { get; } = "MC";
        public override Version Version { get; } = new Version(1, 0, 0);

        public static Plugin Singleton;

        public static List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();

        internal EventHandlers EventHandlers { get; set; }
        public override void OnEnabled()
        {
            Singleton = this;
            Log.Info(Name + " " + Author + " Version: " + Version);
            EventHandlers = new EventHandlers();

            ServerEvents.RoundStarted += EventHandlers.OnRoundBegin;
            ServerEvents.RestartingRound += EventHandlers.OnRestartingRound;
            ServerEvents.RoundEnded += EventHandlers.onRoundEnd;
            PlayerEvents.TriggeringTesla += EventHandlers.onTriggerTesla;
        }


        public override void OnDisabled()
        {

            ServerEvents.RoundStarted -= EventHandlers.OnRoundBegin;
            ServerEvents.RestartingRound -= EventHandlers.OnRestartingRound;
            ServerEvents.RoundEnded -= EventHandlers.onRoundEnd;
            PlayerEvents.TriggeringTesla -= EventHandlers.onTriggerTesla;

            EventHandlers = null;
           
        }

        public override void OnReloaded() { }

    }
}
