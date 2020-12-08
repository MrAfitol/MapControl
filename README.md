# MapControl
Map Control is a Plugin that allows you to use a lot of elements of the map itself. 

## Gatelockdown System
* Gate A and B can randomly be locked for a random amount of time
* Broadcasts and CASSIE announcements go with the locks/unlocks
* The Gates can also be locked at the beginning of the round (with a extra chance)
* The gatelockdown command can also be used to force a GateLockdown

## Control the Map
* Enable/Disable all Tesla gates (via Config)
* Use the toggleteslagates (or ttg) command to enable/disable them yourself

# Permissions:
* toggleteslagates (ttg) `mc.toggleteslagates`
* gatelockdown (gl) `mc.gatelockdown`

# Default config:
```yml
MC:
 # Enable or Disable the MapControl Plugin.
 isEnabled: true
 
 # This allows you to have a chance that randomly in the round the gates get locked.
 EnableRandomGatelockdowns: true
 
 # This allows you to set the chance of a random gatelockdown.
 RandomGateLockdownChance: 15
 
 # The intervall in which the plugin checks the random chance to do a gatelockdown.
 RandomGateLockdownIntervall: 180f
 
 # The minimum time a random gatelockdown will stop.
 RandomGateLockdownMinTime: 45
 
 # The maximum time a random gatelockdown will stop.
 RandomGateLockdownMaxTime: 240
 
 # With this setting you can decide if you want to see a broadcast when gates get locked/unlocked.
 EnableRandomGateLockdownBroadcasts: true
 
 # With this setting you can decide if you want to hear a CASSIE announcement when gates get locked/unlocked.
 EnableRandomGateLockdownCassie: true
 
 # The Announcement CASSIE makes, when the gates are locked down.
 GateLockdownCassieAnnouncement: "Attention . The gate. to surface are now in lockdown"
 
 # The Broadcast when the gates are locked down.
 GateLockdownBroadcast: "<b>The gates to surface have been locked down!</b>"
 
 # You can customize the announcement when the Gates are unlocked.
 GateLockdownUnlockBroadcast: "<b>The gates to surface are no longer locked!</b>"
 
 # The CASSIE announcement when the gates to surface get unlocked.
 GateLockdownUnlockCassieAnnouncement: "Attention . The gate. to surface are open"
 
 # The Duration of a Broadcast.
 GateLockdownBroadcastDuration: 10
 
 # This is the broadcast that shows up when you force a gatelockdown with a given time (%time% is the time in seconds you enter in the cmd).
 GateLockdownBroadcastwithTimer: "<b>The gates to surface have been locked down!</b>\n<i>Atleast for %time% seconds...</i>"
 
 # Are Tesla Gates enabled? (079 can always use them)
 TeslaGatesEnabled: true
