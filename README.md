# MapControl
Map Control is a Plugin that allows you to use a lot of elements of the map itself. 

## Gatelockdown System
* Gate A and B can randomly be locked for a random amount of time
* Broadcasts and CASSIE announcements go with the locks/unlocks
* The gatelockdown command can also be used to force a GateLockdown

## TeslaDisable System
* All Tesla gates can be randomly disabled with a random ammount of time
* Broadcast and CASSIE announcements
* The classes which are able to bypass are configurable
* You can set a custom CASSIE Announcement for the first time NTF bypass a disabled Tesla gate (like in Containment Breach)

## Control the Map
* Enable/Disable all Tesla gates (via Config)
* Use the toggleteslagates (or ttg) command to enable/disable them yourself
* Set and add custom Server Broadcasts
* Start the Decontamination early (via command)

# Permissions:
* toggleteslagates (ttg) `mc.toggleteslagates`
* gatelockdown (gl) `mc.gatelockdown`
* startdecontamination (sd) `mc.startdecontamination`

# Default config:
Config Values | Default Value | Description
------------ | ------------- | -------------
IsEnabled | true | Enables the MapControl Plugin.
EnableServerBroadcasts | false | Enable the custom Server Broadcasts System.
ServerBroadcasts | "test1", "test2" | Add and set the Server Broadcasts `EnableServerBroadcasts` needs to be enabled in order to work.
ServerBroadcastsIntervall | 45f | Sets the intervall in which Server Broadcasts are send.
ServerBroadcastsDuration | 5 | The Duration how long a Server Broadcasts shows up.
EnableRandomGatelockdowns | true | This allows you to have a chance that randomly in the round the gates get locked.
RandomGateLockdownChance | 15 | This allows you to set the chance of a random gatelockdown.
RandomGateLockdownIntervall | 180f | The intervall in which the plugin checks the random chance to do a gatelockdown.
RandomGateLockdownMinTime | 45 | The minimum time a random gatelockdown will stop.
RandomGateLockdownMaxTime | 240 | The maximum time a random gatelockdown will stop.
EnableRandomGateLockdownBroadcasts | true | With this setting you can decide if you want to see a broadcast when gates get locked/unlocked.
EnableRandomGateLockdownCassie | true | With this setting you can decide if you want to hear a CASSIE announcement when gates get locked/unlocked.
GateLockdownCassieAnnouncement | Attention . The gate. to surface are now in lockdown | The Announcement CASSIE makes, when the gates are locked down.
GateLockdownBroadcast | The gates to surface have been locked down! | The Broadcast when the gates are locked down.
GateLockdownUnlockBroadcast | The gates to surface are no longer locked! | You can customize the announcement when the Gates are unlocked.
GateLockdownUnlockCassieAnnouncement | Attention . The gate. to surface are open | The CASSIE announcement when the gates to surface get unlocked.
GateLockdownBroadcastDuration | 10 | This allows you to set the duration of the broadcast of the Broadcast.
GateLockdownBroadcastwithTimer | The gates to surface have been locked down!\n<i>Atleast for %time% seconds... | This is the broadcast that shows up when you force a gatelockdown with a given time.
TeslaGatesEnabled | true | Are Tesla Gates enabled? (079 can always use them)
TeslaMTFAnnouncementEnabled | true | Should The Disable of the Tesla gates for MTF be announced?
TeslaMTFAnnouncement | CONTROL TO NINETAILEDFOX . TESLA GATE. DISABLED | The Announcement that takes place when MTF get close to a disabled tesla (only the first time)?
TeslaBypassClasses | FacilityGuard, NtfCadet, NtfCommander, NtfLieutenant, NtfScientist | The classes who do not trigger tesla gates
EnableRandomTeslaDisable | true | Should The Disable of the Tesla gates for MTF be announced?
RandomTeslaDisableChance | 35 | What should the chance be for a random Tesla Disable to happen?
RandomTeslaDisableIntervall | 180f | In what Intervall the server checks the chance for a random Tesla gates disable?
RandomTeslaDisableMinTime | 45 | How long should a random Tesla Disable should be atleast?
RandomTeslaDisableMaxTime | 180 | How long should a random Tesla Disable should be at maximum?
EnableTeslaBroadcasts | true | With this setting you can decide if you want to see a broadcast when the Tesla gates are enabled/disabled.
EnableTeslaCassie | true | With this setting you can decide if you want to hear a CASSIE announcement when the Tesla gates are enabled/disabled.
TeslaDisableAnnouncement | Attention . tesla gate. disabled | The Announcement CASSIE makes, when the Tesla gates are disabled.
TeslaDisableBroadcast | The Tesla gates are disabled! | The Broadcast when the Tesla gates are disabled
TeslaEnableBroadcast | The Tesla gates are no longer disabled! | You can customize the announcement when the Gates are unlocked.
TeslaEnableCassieAnnouncement | Attention . Telsa gates. enabled | The CASSIE announcement when the Tesla gates are enabled again.
TeslaBroadcastDuration | 10 | This allows you to set the duration of the broadcast of the Broadcast.







