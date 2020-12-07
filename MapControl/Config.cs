using Exiled.API.Interfaces;
using Exiled.Loader;
using System.ComponentModel;

namespace MapControl
{
    public class Config : IConfig
    {
        [Description("Enable or Disable the MapControl Plugin.")]
        public bool IsEnabled { get; set; } = true;

        [Description("This allows you to have a chance that randomly in the round the gates get locked.")]
        public bool EnableRandomGatelockdowns { get; set; } = true;

        [Description("This allows you to set the chance of a random gatelockdown.")]
        public int RandomGateLockdownChance { get; set; } = 15;

        [Description("The intervall in which the plugin checks the random chance to do a gatelockdown.")]
        public float RandomGateLockdownIntervall { get; set; } = 180f;

        [Description("The minimum time a random gatelockdown will stop.")]
        public int RandomGateLockdownMinTime { get; set; } = 45;

        [Description("The maximum time a random gatelockdown will stop.")]
        public int RandomGateLockdownMaxTime { get; set; } = 240;

        [Description("With this setting you can decide if you want to see a broadcast when gates get locked/unlocked.")]
        public bool EnableRandomGateLockdownBroadcasts { get; set; } = true;

        [Description("With this setting you can decide if you want to hear a CASSIE announcement when gates get locked/unlocked.")]
        public bool EnableRandomGateLockdownCassie { get; set; } = true;

        [Description("The Announcement CASSIE makes, when the gates are locked down")]
        public string GateLockdownCassieAnnouncement { get; set; } = "Attention . The gate. to surface are now in lockdown";

        [Description("The Broadcast when the gates are locked down.")]
        public string GateLockdownBroadcast { get; set; } = "<b>The gates to surface have been locked down!</b>";

        [Description("You can customize the announcement when the Gates are unlocked.")]
        public string GateLockdownUnlockBroadcast { get; set; } = "<b>The gates to surface are no longer locked!</b>";

        [Description("The CASSIE announcement when the gates to surface get unlocked.")]
        public string GateLockdownUnlockCassieAnnouncement { get; set; } = "Attention . The gate. to surface are open";

        [Description("This allows you to have a chance that randomly in the round the gates get locked.")]
        public ushort GateLockdownBroadcastDuration { get; set; } = 10;

        [Description("This is the broadcast that shows up when you force a gatelockdown with a given time.")]
        public string GateLockdownBroadcastwithTimer { get; set; } = "<b>The gates to surface have been locked down!</b>\n<i>Atleast for %time% seconds...</i>";

        [Description("Are Tesla Gates enabled? (079 can always use them)")]
        public bool TeslaGatesEnabled { get; set; } = true;
    }
}
