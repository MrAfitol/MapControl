using Exiled.API.Interfaces;
using Exiled.Loader;
using System.Collections.Generic;
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

        [Description("The Announcement CASSIE makes, when the gates are locked down.")]
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

        [Description("Should The Disable of the Tesla gates for MTF be announced?")]
        public bool TeslaMTFAnnouncementEnabled { get; set; } = true;

        [Description("Should The Disable of the Tesla gates for MTF be announced?")]
        public string TeslaMTFAnnouncement { get; set; } = "CONTROL TO NINETAILEDFOX . TESLA GATE DISABLED";

        [Description("The classes who do not trigger tesla gates")]
        public List<RoleType> TeslaBypassClasses { get; set; } = new List<RoleType>()

            {
                RoleType.FacilityGuard, RoleType.NtfCadet, RoleType.NtfCommander, RoleType.NtfLieutenant, RoleType.NtfScientist
            };

        [Description("Should The Disable of the Tesla gates for MTF be announced?")]
        public bool EnableRandomTeslaDisable { get; set; } = true;

        [Description("In what Intervall the server checks the chance for a random Tesla gates disable?")]
        public float RandomTeslaDisableIntervall { get; set; } = 180f;

        [Description("How long should a random Tesla Disable should be atleast?")]
        public int RandomTeslaDisableMinTime { get; set; } = 45;

        [Description("How long should a random Tesla Disable should be at maximum?")]
        public int RandomTeslaDisableMaxTime { get; set; } = 180;

    }

}
