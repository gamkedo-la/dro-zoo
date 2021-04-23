//I propose we prompt dialogue as player enters. AI explains the humans, provides a bit of background to the expedition, and requests fixing the doors. We could probably present or at least hint the motivation towards waking us up here to start working against the chore feeling.

-> EnterRoom

===EnterRoom===
KosmosAI.Speech()
Attention [NAME:PHY-5-OH], your [ACTION: ASSISTANCE] is needed.
    * What is the problem?
        -> DoorIssueExplain
    * How can I help?
        ->LevelGoal
    * I sure need help too... hovering is tough!
        ->Encourage
===QuestionsMenu===
    * What is the problem?
    -> DoorIssueExplain
    * How can I help?
    -> LevelGoal
    * Do you know what is causing this?
    -> MissionResults
    * Where are the rest of the crew?
    -> Humans
    * Thank you. I am ready to go.
    -> LetMePlay
==DoorIssueExplain==
KosmosAI.LoadItemDescription(Issue_DB, PowerAccess)
Issue description: Code - 099 Isolation doors currently non-functional
Root cause: missing [SUPPLY:POWER SOURCE] 

KosmosAI.Speech()
[NAME: PHY-5-OH], the [ELEMENT: ACCESS DOOR] in this chamber will not be accessible. Functionality can only be restored if [ELEMENT:POWER SOURCE] is restored.

Repeat or continue?
    * Repeat
    -> DoorIssueExplain
    * Continue
    ->QuestionsMenu

==LevelGoal==
KosmosAI.Speech()
[NAME: PHY-5-OH], [RECORD: PowerAccess] in [DATASET:Issue_DB] indicates that the [VALUE: Recommended course of action] in this instance is to restore [ELEMENT: POWER SOURCE] to [ELEMENT: ACCESS DOOR]. A [COMPONENT: SUPPORT GENERATOR] should be available in this room and is the recommended solution.

Repeat or continue?
    * Repeat
    -> LevelGoal
    * Continue
    ->QuestionsMenu
    
==Encourage==
[WARNING] Mission-threatening behaviour detected: self-deprecation
[Sys: initiate support response (self-esteem)]

KosmosAI.LoadModule(Behaviour, "good vibes")
//Add some positive talking in a clearly different speech.

Repeat or continue?
    * Repeat
    -> Encourage //Can we cycle through different positive responses? Check in Ink documentation
    * Continue
    ->QuestionsMenu
    
==MissionResults==
//Describe the cargo. Hint at Anna's nervousness on potential threats to cargo.

Repeat or continue?
    * Repeat
    //Insert an evasive response and send back to menu (Himar to explore Ink's capability to save responses and generate a different one here
    ->QuestionsMenu
    * Continue
    ->QuestionsMenu
    
==Humans==
//Anna gets really nervous. Humans are sleeping and cannot be awaken... it's... ehhhh dangerous. Insert obviously made up potential consequences.
    Repeat or continue?
    * Repeat
    KosmosAI.Speech()
    Yeah, eh... no I think it's clear thanks. //Explore potential to save response and erase this option
    ->QuestionsMenu
    * Continue
    ->QuestionsMenu

===LetMePlay===
Thank you, [NAME:PHY-5-OH]. Ending communication. The following [INFORMATION] has been identified as [MISSION CRITICAL]. Printing reminder:
KosmosAI.Speech()
[NAME: PHY-5-OH], the [ELEMENT: ACCESS DOOR] in this chamber will not be accessible. Functionality can only be restored if [ELEMENT:POWER SOURCE] is restored.
[RECORD: PowerAccess] in [DATASET:Issue_DB] indicates that the [VALUE: Recommended course of action] in this instance is to restore [ELEMENT: POWER SOURCE] to [ELEMENT: ACCESS DOOR]. A [COMPONENT: SUPPORT GENERATOR] should be available in this room and is the recommended solution.
-> END



    
    
