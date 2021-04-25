//Ver 26/02/2021 - Himar (refactored from initial, verbose draft)
//Current opportunity: text pacing for ease of reading. Validate if this can be done in Unity - otherwise manually add a "Next page" type button (e.g. Continue, Proceed - to follow theme)
//Extra goal to insert a comical interaction for variety and color

//Agreed path to follow (see PDF PPT in Trello): a fungus/some sort of airborne alien organism has adhered to the ship and is affecting its functioning, player has to remove it with AI guidance and support. AI to be  “machinal” in its speech mixed in with more human like speech.
//Player wakes up - drone in charge room
//Set the scene introducing AI and player role, get player to move around

//Warmup Dialogue to get the player to buy into game environment. However we don't want to make it a cutscene/forced dialogue. Past Wakeup, all the content should be optional. The player should be able to get to play when they want.
//To still pass information to player about story, flavor text may help (items, etc).
-> WakeUp
===WakeUp===
[Sys: Boot sequence completed]
[Sys: PHY-5-OH charge status: 70%]
DroneInstructSet.CommsTest(PHY-5-OH)
KosmosAI.LoadModule(Speech, "english")
[Sys:AN-1-NA natural language module loaded]
[NAME: PHY-5-OH], please respond. Attempting to validate function [COMMUNICATIONS].
AN-1-NA HASHxINPUT sent: drone [PHY-5-OH] - return HASHxKEY for 484f4d455445414d2047414d45444556 [Sys: awaiting response] //Hex from "HOMETEAM GAMEDEV". Initially thought of SHA1 but user would not be able to convert. Could be a cool easter egg :)
    * [???]
        KosmosAI.Speech()
        Apologies dear [NAME:PHY-5-OH]. I missed [INPUTMETHOD: humanspeech] required for drone instruction. Requesting confirmation: is message readable?
        
            **[DroneResponse.Positive()]
                KosmosAI.Speech()
                Return assessment: confused. Requesting [NAME: PHY-5-OH] operational efficiency. Shared goals pending. Unavailable [RESOURCE: TIME] for [ACTIVITY: COMEDY].
                KosmosAI.Speech()
                Initiating test [RESPONSE_MODULE] at [NAME:PHY-5-OH].
                DroneInstructSet.ModuleTest(DroneResponse)
                [Sys: DroneResponse module active, command mode only. Initiate voice recognition?]
                KosmosAI.InputKey(Y)
                *** [Proceed]
                -> HumanSpeechInstall
                
            **[?????]
                KosmosAI.Speech()
                Return assessment: concern. Initiating test [RESPONSE_MODULE] at [NAME:PHY-5-OH].
                DroneInstructSet.ModuleTest(DroneResponse)
                [Sys: DroneResponse module active, command mode only. Initiate voice recognition?]
                KosmosAI.InputKey(Y)
                *** [Proceed]
                    -> HumanSpeechInstall
    * [ERROR]
        KosmosAI.InitSound(sigh)
        KosmosAI.ModuleMemAssign(patience)
        [Sys: AN-1-NA has overriden error response]
        DroneInstructSet.AbortTest(CommsTest)
        [Sys: CommsTest cancelled]
        KosmosAI.Speech()
        Fear not, dear [NAME:PHY-5-OH]. Please stand by.
        ->HumanSpeechInstall
            
===HumanSpeechInstall===
KosmosAI.Speech()
[NAME: PHY-5-OH] please stand by. Your [MODULE: humanspeech response] will now be activated.
DroneInstructSet.LoadModule(PHY-5-OH, Speech, "english")
[Sys: PHY5OH natural language module activation in progress]
TIP: You may feel a tingling in your frontal subprocessor modules during the installation. One or several minipropellers may also self-activate in the process. This is documented, expected behavior. Avoid drone panic.
[Sys: PHY5OH natural language module now active]

KosmosAI.Speech()
[NAME: PHY-5-OH], please confirm human speech is now active.
    * [I confirm I can now speak using human patterns.]
        KosmosAI.InitSound(fanfare)
        KosmosAI.Speech()
        Return assessment: optimal. Unavailable [RESOURCE: TIME] for [ACTIVITY: VICTORY DANCE]. Shared goals pending. Support required.
        ->ReadOrPlay
        
    * [I am unsure this has worked.]
        KosmosAI.InitSound(giggle)
        KosmosAI.Speech()
        Return assessment: funny. [NAME: PHY-5-OH] TAG ADDED: Comedian. Current rate:2/5.
        Pity. Unavailable [RESOURCE: TIME] for [ACTIVITY: COMEDY]. Shared goals pending. Support required.
        ->ReadOrPlay

=ReadOrPlay
KosmosAI.Speech()
[NAME: PHY-5-OH], your [CURRENT_STATUS] displays incomplete [CHARGE]. Database records may appear missing or non responsive. Request confirmation: proceed to task OR consult help?

* [I have some questions, please.]
->QuestionsMenu

* [I am fine. Let's start working.]
->LetMePlay

===QuestionsMenu===
* [Where are we?]
->MissionIntro

* [Who are you?]
->CharactersIntro

* [What do we have to do?]
->RoomGoal

* [How do I move?]
->ControlsExplanation

* [Thank you. Let's start working.]
->StartPlaying

=MissionIntro
KosmosAI.Print(Env_status)
LOCATION: MBS Cholormid
CATEGORY: Mobile Botany Station
FLIGHT PLAN: Earth - Beta CVn 3 - Earth
GOAL: Confirm Coronagraph, Spectograph evaluation (HabitScore: 8/10). Retrieve samples.
FLIGHT PLAN STAGE: Homebound routine initiated. On track to Earth.

KosmosAI.Print (DroneInstructSet.Location(PHY-5-OH))
PHY-5-OH LOCATION: Drone Maintenance Bay (MBS CholorMid)

Repeat or continue?
    * [Repeat]
    -> MissionIntro
    * [Continue]
    ->QuestionsMenu

=ControlsExplanation
KosmosAI.Speech()
[NAME: PHY-5-OH] your remote control has been overriden. I have now granted you self steering. Surfacing instruction manual. Please stand by.

KosmosAI.Print(PHY5OH User Manual)
[Phy-5-Oh remote control operations manual. Ver: 5.5. Chief Engineer Bluzen)
To propel the PHY-5-OH unit horizontally in any direction, please use the left rotating stick in your remote operation station. 
To propel the PHY-5-OH unit vertically, or rotate its facing direction, please use the right rotating stick in your remote operation station.
Self-operation of support drones can be intimidating: we recommend their Maintenance Bay for practice. A few turns have proven more than enough for most of our new joiners in the past.

I trust you will succeed.
[Document ends.]

Repeat or continue?
    * [Repeat]
    -> ControlsExplanation
    * [Continue]
    -> QuestionsMenu

=CharactersIntro

KosmosAI.Print(AN1NA_about)
NAME: AN-1-NA
CATEGORY: Class 3 Management Artificial Intelligence
BLUEPRINT: Kosmos Neural Network (ver 2.5)
ASSIGNMENT: MBS Cholormid - Support crew - Drone management
CURRENT LINKS: Vessels [MBS Cholormid], Research Assistant Drone [PHY-5-OH]

Repeat or continue?
    * [Repeat]
    -> CharactersIntro
    * [Continue]
    ->QuestionsMenu

=RoomGoal
KosmosAI.Print(Sys_report)
ANOMALY DETECTED: Performance deviation [STEERING_RULESET]
ANOMALY DESCRIPTION: Unidentified maneuver requested [RETURN TO ORIGIN]
ANOMALY CAUSE: Currently unknown

PROPOSED REMEDIATION: Manually restore supply [POWER_SUPPORT.GENERAL], identify origin [SAMPLES.CARGO]

NEXT STEPS: [NAME:PHY-5-OH] exit Drone Maintenance Bay

Repeat or continue?
    * [Repeat]
    -> RoomGoal
    * [Continue]
    ->QuestionsMenu

=StartPlaying
DroneInstructSet.Decouple(PHY-5-OH)
[Sys: initiating drone decoupling sequence]
KosmosAI.Speech()
Thank you, [NAME:PHY-5-OH]. Releasing you from bay. The following [DOCUMENT] has been identified as [MISSION CRITICAL]. Printing reminder:
To propel the PHY-5-OH unit horizontally in any direction, please use the left rotating stick in your remote operation station. 
To propel the PHY-5-OH unit vertically, or rotate its facing direction, please use the right rotating stick in your remote operation station.
NEXT STEPS: [NAME:PHY-5-OH] exit Drone Maintenance Bay
[Sys: drone decoupling sequence completed]

Good luck.
#canvasoff
-> END

===LetMePlay===
DroneInstructSet.Decouple(PHY-5-OH)
[Sys: initiating drone decoupling sequence]
KosmosAI.Speech()
Thank you, [NAME:PHY-5-OH]. Releasing you from bay. The following [DOCUMENT] has been identified as [MISSION CRITICAL]. Printing reminder:
To propel the PHY-5-OH unit horizontally in any direction, please use the left rotating stick in your remote operation station. 
To propel the PHY-5-OH unit vertically, or rotate its facing direction, please use the right rotating stick in your remote operation station.
NEXT STEPS: [NAME:PHY-5-OH] exit Drone Maintenance Bay
[Sys: drone decoupling sequence completed]

Good luck.
#canvasoff
-> END