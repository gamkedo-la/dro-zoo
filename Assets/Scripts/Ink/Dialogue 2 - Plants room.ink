//Suggested to trigger as player traverses corridor to plant room after recovering power.
->StartRoom
===StartRoom===
KosmosAI.Speech()
Great job, [NAME: PHY-5-OH]! Good drone. And no disturbance to our administrators!
You are now approaching the end of your assignment in [LOCATION: MBS Cholormid Botanic Cargo Bay].
* [Understood]
    [Sys: updated diagnosis available]
    [Sys: updated instructions available]
    [Sys: restricted records released on mission-critical basis]
** [Access information]
->QuestionsMenu

===QuestionsMenu===
KosmosAI.Speech()
[NAME: PHY-5-OH], please indicate [DATA] to surface.

+ [What cargo are we transporting?]
->PlantsInfo
+ [Have you found out what is affecting the ship?]
->FungalInvasion
+ [How can I help?]
->RoomGoal
* [Are you sure that the crew is not in danger?]
->ItsOkayReally
* [Thanks. I am ready to go.]
->LetMePlay

==PlantsInfo==
KosmosAI.Print(MBS_Cholormid_Cargo_EXPD110045)
[Sys: CONFIDENTIAL RECORDS TO FOLLOW. SHARING IS RESTRICTED TO MISSION CRITICAL BASIS ONLY]
* [Proceed]
CARGO LOCATION: MBS Cholormid
CATEGORY: Unknonw (inferred vegetal)
ORIGIN: Beta CVn 3
STATUS: Inferred OK. Monitoring in place.
**[Proceed]
[Sys: Observation notes available. Read?]
    *** [Yes]
    Notes - Chief Botanist Zabassin: the specimens obtained in Beta CVn 3 appear to behave similarly to Earth vegetal species. When observe in habitat, the could be found in groups in areas of limited lightning. 
    **** [Next page]
    Surprisingly, however, they continued to emit a bright, fluorescent-like type of light, in some cases fully illuminatic small caves. This has led us to suspect that the plants generate some form of energy yet to be determined, which is supported by the readings in our Xeno-WaveLenght Emmission Tests. 
    *****[Next page]
    After continued testing for hostile effects returning negative results, we have decided to carry them back to Earth for further analysis.
    -> QuestionsMenu
    *** [No]
    -> QuestionsMenu
    
==FungalInvasion==
KosmosAI.Print(Sys_report)
ANOMALY DETECTED: Performance deviation [STEERING_RULESET]
ANOMALY DESCRIPTION: Unidentified maneuver requested [RETURN TO ORIGIN]
*[See updated information]
    ANOMALY CAUSE [!UPDATED]: Alien substance detected in [COMPONENT:MBS Cholormid Neural Unit]. Believed [CATEGORY]: [ORGANISM: FUNGUS]. [DIAGNOSIS] Interference: 40%. Trend: increase.
    NOTES/COMMENTS: Interaction detected with [SAMPLES.CARGO]. Nature: oppositional. Potential [REMEDIATION].

    PROPOSED REMEDIATION[!UPDATED]: Explore [SAMPLES.CARGO] solution.
**[See next steps guidance]
NEXT STEPS: [NAME:PHY-5-OH] supply [POWER_SUPPORT] into [SAMPLES.CARGO] - Notes available under cargo records.
***[Noted]
->QuestionsMenu

==RoomGoal==
KosmosAI.Speech()
[NAME: PHY-5-OH], [CARGO.RECORDS] can provide more details.
*[Noted]
Our [SAMPLE.CARGO] is believed to be energy generating, and interact with the [ANOMALY CAUSE] detected [inferred ORGANISM:FUNGUS].
**[Any recommendations?]
[RECOMMENDED REMEDIATION] is currently to supply [POWER_SUPPORT] into [SAMPLES.CARGO]. No linear path found - exploration encouraged.
***[Understood]
->QuestionsMenu

==ItsOkayReally==
KosmosAI.Speech()
[NAME: PHY-5-OH], really calm down! They are okay. 
*[Are they?]
Yes! This is just a good way for us to spend some time practicing and proving ourselves useful...nothing else!
**[Okay...]
It's all fine, we don't need to bother them or tell them. Ever. 
***[Understood]
We have it under control. I have it under control.
****[Ok...]
Yep.
*****[Fine...]
-> QuestionsMenu

==LetMePlay==
KosmosAI.Speech()
Thank you, [NAME:PHY-5-OH]. Closing communication link. The following [DATA] has been identified as [MISSION CRITICAL]. Printing reminder:
*[Print information]
Our [SAMPLE.CARGO] is believed to be energy generating, and interact with the [ANOMALY CAUSE] detected [inferred ORGANISM:FUNGUS].
**[See recommendations]
[RECOMMENDED REMEDIATION] is currently to supply [POWER_SUPPORT] into [SAMPLES.CARGO]. No linear path found - exploration encouraged.
***[Understood]
{ItsOkayReally: Our humans will be so happy that they did not have to worry or EVER know about this! We are great!}

You can do this!
*****[Let's go]
#canvasoff
->END