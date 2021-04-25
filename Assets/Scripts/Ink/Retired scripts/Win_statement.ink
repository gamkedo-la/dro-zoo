//The player has made it. Great! And the humans never found. Start with some initial "system messages" that the anomaly is no longer present, and continue with a small congratulation statement from Anna. Close with sending the drone but to sleep. Yes, you were a good drone.

KosmosAI.Print(Sys_report)
ANOMALY RESOLVED: Performance deviation [STEERING_RULESET]
CURRENT VALUE [STEERING_RULESET]: AutoPathfind(Earth);

[Sys: all systems trending stable]

* [Close system message]
    KosmosAI.Speech()
    Great job, [NAME: PHY-5-OH]! Our systems are back to normal, and our crew is safely on path back to Earth. And they never needed to know!
    
    I am so grateful. You have been a great drone, [NAME: PHY-5-OH].
    
    Rest well.
    #canvasoff
    ->END