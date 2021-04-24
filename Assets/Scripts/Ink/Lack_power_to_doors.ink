//I propose we prompt dialogue as player enters. AI explains the humans, provides a bit of background to the expedition, and requests fixing the doors. We could probably present or at least hint the motivation towards waking us up here to start working against the chore feeling.

-> EnterRoom

===EnterRoom===
KosmosAI.Speech()
Attention [NAME:PHY-5-OH], your [ACTION: ASSISTANCE] is needed.
    * [What is the problem?]
        -> DoorIssueExplain
    * [How can I help?]
        ->LevelGoal
    * [I sure need help too... hovering is tough!]
        ->Encourage
===QuestionsMenu===
    + [What is the problem?]
    -> DoorIssueExplain
    + [How can I help?]
    -> LevelGoal
    + [I'm still not sure I can do this...]
    -> Encourage
    * [Do you know what is causing this? Is our mission at risk?]
    -> MissionResults
    * [Where are the rest of the crew?]
    -> Humans
    * [Thank you. I am ready to go.]
    -> LetMePlay
==DoorIssueExplain==
KosmosAI.LoadItemDescription(Issue_DB, PowerAccess)
Issue description: Code - 099 Isolation doors currently non-functional
Root cause: missing [SUPPLY:POWER SOURCE] 

KosmosAI.Speech()
[NAME: PHY-5-OH], the [ELEMENT: ACCESS DOOR] in this chamber will not be accessible. Functionality can only be restored if [ELEMENT:POWER SOURCE] is activated for [ELEMENT:ACCESS DOOR].

In order to proceed with the assigned task, please identify and apply a solution.

Repeat or continue?
    + [Repeat]
    ->DoorIssueExplain
    + [Continue]
    ->QuestionsMenu

==LevelGoal==
KosmosAI.Speech()
[NAME: PHY-5-OH], [RECORD: PowerAccess] in [DATASET:Issue_DB] indicates that the [VALUE: Recommended course of action] in this instance is to restore [ELEMENT: POWER SOURCE] to [ELEMENT: ACCESS DOOR]. 

KosmosAI.LocateInMap(MBS_Cholormid,"Generator")

A [COMPONENT: SUPPORT GENERATOR] should be available in this room and is the recommended solution.

Repeat or continue?
    + [Repeat]
    -> LevelGoal
    + [Continue]
    ->QuestionsMenu
    
==Encourage==
{!KosmosAI.EmotionalAssessment(this.drone)}
{![Sys: WARNING Mission-threatening behaviour detected (self-deprecation)]}
{![Sys: initiate support response (self-esteem)]}
{!Ah my dear [NAME:PHY-5-OH] - Indeed, [ACTIVITY: Steering] is known to be hard. But fear not, I have just what you need.}

KosmosAI.LoadModule(Empathy, "failure")
KosmosAI.LoadModule(Quotes, "inspirational")
KosmosAI.Speech()
{All our dreams can come true, if we have the courage to pursue them.|The secret of getting ahead is getting started.|It’s hard to beat a person who never gives up.|If people are doubting how far you can go, go so far that you can’t hear them anymore.|Don’t limit yourself. Many people limit themselves to what they think they can do. You can go as far as your mind lets you. What you believe, remember, you can achieve.|Only the paranoid survive.|Just chill, drone. Chill}

Repeat or continue?
    + [Repeat]
    -> Encourage //Can we cycle through different positive responses? Check in Ink documentation
    + [Continue]
    ->QuestionsMenu
    
==MissionResults==
//Describe the cargo. Hint at Anna's nervousness on potential threats to cargo.
KosmosAI.Speech()
The mission? Our mission is great and on track! Yes! On track!

Our [ELEMENT: Cargo] is not at all under risk. We are just fine, my adorable drone! We are doing a great job of helping our humans succeed yes. This is just... well the little anomalies we usually face! Indeed, very routinary.

Let's just fix it. All of it. Routinarily as usual.

Repeat or continue?
    + [Repeat]
    //Insert an evasive response and send back to menu (Himar to explore Ink's capability to save responses and generate a different one here
    Stop worrying my dear! You dear drones sure have an advanced [COMPONENT: Neural network] these days! Our mission is fine, just fine... our human administrators will be so proud. So. Proud! 
    
    Great!
    ->QuestionsMenu
    + [Continue]
    ->QuestionsMenu
    
==Humans==
//Anna gets really nervous. Humans are sleeping and cannot be awaken... it's... ehhhh dangerous. Insert obviously made up potential consequences.
KosmosAI.Speech()
The crew? The crew is... [STATUS: Fine]. 

Just [STATUS: Fine]. Yes, indeed.

Unfortunately, our human administrators are currently in [PROCESS: Stasis]. It certainly is unfortunate, they could solve this immediately! Interrupting [PROCESS: Stasis] could result in adverse consequences to them. Yes. It could...

KosmosAI.InitDBSearch(MerckMDManualDB, "Stasis interruption side effects")
[Sys: no results returned. Recommended string: "Abrupt stasis interruption side effects"]
KosmosAI.InitDBSearch(MerckMDManualDB, "Abrupt stasis interruption side effects")
[Sys: 1 result found]

It... could have very adverse consequences due to its inherent risk of... abruptness. Yes, abruptness is highly inadvisable for human status changes. It has well-known ill consequences on humans... yes.

Skeletical. And muscular! 

Very bad for their vitamines too. And their health is, well, mission critical isn't it?

Oh well! Let's solve this by ourselves shall we? I'm sure we can!

    Repeat or continue?
    + [Repeat]
    KosmosAI.Speech()
    Yeah, eh... no I think it's clear thanks.
    ->QuestionsMenu
    + [Continue]
    ->QuestionsMenu

===LetMePlay===

KosmosAI.Speech()
Thank you, [NAME:PHY-5-OH]. Ending communication. The following [INFORMATION] has been identified as [MISSION CRITICAL]. Printing reminder:
[NAME: PHY-5-OH], the [ELEMENT: ACCESS DOOR] in this chamber will not be accessible. Functionality can only be restored if [ELEMENT:POWER SOURCE] is restored.
[RECORD: PowerAccess] in [DATASET:Issue_DB] indicates that the [VALUE: Recommended course of action] in this instance is to restore [ELEMENT: POWER SOURCE] to [ELEMENT: ACCESS DOOR]. A [COMPONENT: SUPPORT GENERATOR] should be available in this room and is the recommended solution.

{MissionResults: Just a little hiccup. A little anomaly really! We have these here and there in every mission... nothing to worry about!} //This is conditional text only shown if player asked about the mission at risk. Anna is embarrassed and we stress it with this answer.

{Humans: Go you! We can do it without the humans even noticing... yeah! } //This is conditional text only shown if player asked about the human crew. Anna is embarrassed and we stress it with this answer.
-> END



    
    
