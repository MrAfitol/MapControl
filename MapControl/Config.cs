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

        [Description("Do you want the MapControl Server Broadcasts enabled? You can configure them.")]
        public bool EnableServerBroadcasts { get; set; } = false;

        [Description("Welp here you can set and add Server Broadcasts.")]
        public List<string> ServerBroadcasts { get; set; } = new List<string>()

            {
                "test1", "test2"
            };

        [Description("In which intervall you want Server Broadcasts happen.")]
        public float ServerBroadcastsIntervall { get; set; } = 45f;

        [Description("How long should a Server Broadcast be?")]
        public ushort ServerBroadcastsDuration { get; set; } = 5;

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

        [Description("This allows you to set the duration of the broadcast of the Broadcast.")]
        public ushort GateLockdownBroadcastDuration { get; set; } = 10;

        [Description("This is the broadcast that shows up when you force a gatelockdown with a given time.")]
        public string GateLockdownBroadcastwithTimer { get; set; } = "<b>The gates to surface have been locked down!</b>\n<i>Atleast for %time% seconds...</i>";

        [Description("Are Tesla Gates enabled? (079 can always use them)")]
        public bool TeslaGatesEnabled { get; set; } = true;

        [Description("Should The Disable of the Tesla gates for MTF be announced?")]
        public bool TeslaMTFAnnouncementEnabled { get; set; } = true;

        [Description("The Announcement that takes place when MTF get close to a disabled tesla (only the first time)?")]
        public string TeslaMTFAnnouncement { get; set; } = "CONTROL TO NINETAILEDFOX . TESLA GATE. DISABLED";

        [Description("The classes who do not trigger tesla gates")]
        public List<RoleType> TeslaBypassClasses { get; set; } = new List<RoleType>()

            {
                RoleType.FacilityGuard, RoleType.NtfCadet, RoleType.NtfCommander, RoleType.NtfLieutenant, RoleType.NtfScientist
            };

        [Description("Should The Disable of the Tesla gates for MTF be announced?")]
        public bool EnableRandomTeslaDisable { get; set; } = true;

        [Description("What should the chance be for a random Tesla Disable to happen?")]
        public int RandomTeslaDisableChance { get; set; } = 35;

        [Description("In what Intervall the server checks the chance for a random Tesla gates disable?")]
        public float RandomTeslaDisableIntervall { get; set; } = 180f;

        [Description("How long should a random Tesla Disable should be atleast?")]
        public int RandomTeslaDisableMinTime { get; set; } = 45;

        [Description("How long should a random Tesla Disable should be at maximum?")]
        public int RandomTeslaDisableMaxTime { get; set; } = 180;

        [Description("With this setting you can decide if you want to see a broadcast when the Tesla gates are enabled/disabled.")]
        public bool EnableTeslaBroadcasts { get; set; } = true;

        [Description("With this setting you can decide if you want to hear a CASSIE announcement when the Tesla gates are enabled/disabled.")]
        public bool EnableTeslaCassie { get; set; } = true;

        [Description("The Announcement CASSIE makes, when the Tesla gates are disabled.")]
        public string TeslaDisableAnnouncement { get; set; } = "Attention . tesla gate. disabled";

        [Description("The Broadcast when the Tesla gates are disabled")]
        public string TeslaDisableBroadcast { get; set; } = "<b>The Tesla gates are disabled!</b>";

        [Description("You can customize the announcement when the Gates are unlocked.")]
        public string TeslaEnableBroadcast { get; set; } = "<b>The Tesla gates are no longer disabled!</b>";

        [Description("The CASSIE announcement when the Tesla gates are enabled again.")]
        public string TeslaEnableCassieAnnouncement { get; set; } = "Attention . Telsa gates. enabled";

        [Description("This allows you to set the duration of the broadcast of the Broadcast.")]
        public ushort TeslaBroadcastDuration { get; set; } = 10;

    }

}
