using UnityEngine;

public class ToDo : MonoBehaviour
{
    /* Player Movement + Physics:
     * Basic Player Movement - DONE
     * Fix: Player Spawns in ground - DONE
     * Fix: Player tips over - DONE
     * Fix: Player moves too fast - DONE
     * Camera follows Player POV - DONE
     * Player can turn using the Mouse - Working On
     * ToDo: Significantly improve camera sensitivity - DONE
     * Fix: Camera's Y rotation is inverted - Working On
     */

    /* NPC Interaction:
     * Placholder NPC Model - DONE
     * Player Interaction (Box Collider + GetKeyDown?) - DONE
     * NPC Textbox - DONE
     * ToDo: Tweak Dialogue Wrapping - DONE
     * ToDo: NPC's react differently to the timeline's state
     * (TL State will probably be it's own var in a diff script, but we'll save that for ltr)
     * ToDo: Player can move through an NPCs dialogue one line at a time - Working On
     * Fix: Dialogue Window not appearing - DONE
     * Fix: Only first line of dialogue appears - Working On
     */

    /* Trading Quest:
     * Player can pick up first item in trading sequence - DONE
     * Player can interact with trader npcs who ask for certain items - Need to work on dialogue
     * Interacting with traders in the correct sequence trades one item for another - DONE
     * ToDo: Refactor TradingQuest into TraderNPCController?
     */

    /* Other Checklists:
     * Puzzle Elements + Logic
    /* Sound Tone Puzzle Logic:
     * Button which plays a short sequence of sound tones - Logic Done
     * Buttons which play individual sound tones - Logic Done
     * Pressing the buttons in the same order as the sequence marks the puzzle as solved - DONE
     * ToDo: Separate scripts and assign them to the individual components - DONE
     * Fix: Solved is not being set to true - DONE
     * Fix: New Sequence Index is being reset one click too late - DONE
     * Fix: Elements 2 and 3 are not being reset - DONE
     * ToDo: Puzzle cannot be interacted with after completion - DONE
     * ToDo: Turn Puzzle into reuseable prefab - DONE
     * ToDo: Clean up and comment scripts - DONE
     * ToDo: Add unique sound tones and tile textures
     */

    /* Puzzle Prefab Logic:
     * Separate ObstacleController and Obstacle into seperate scripts - DONE
     * Obstacle Logic should be on the Obstacle, no Controller needed - DONE
     * Fix: Base Obstacle Method being called infinetly - DONE
     * Turn Puzzles into reusable prefabs - DONE
     * Fix: Tile Prefabs do not switch - DONE
     * Test Obstacle Prefab Finished
     */

    /* Puzzle Logic:
     * Solved Bool Variable - DONE
     * Puzzle ID is logged when Solved (according to its own method) - DONE
     * ToDo: Test Puzzle has its own GO in the Scene already - DONE
     * Related Obstacle GO is removed (according to its own method) when Solved - DONE
     * Fix: "Obstacle Removed" log repeats endlessly - DONE
     * ToDo: Make Obstacles their own inheritable class - DONE
     * Fix: Obstacles are not being removed - DONE
     * Fix: NullReferenceException at ObstacleController line 86 - DONE
     * ToDo: Test to ensure multiple puzzles + obstacles don't conflict or intersect w/ each other - DONE
     * Idea: Give Puzzle + Obstacle types their own tags to help w/ sorting + avoiding conflicts - DONE
     * Idea: Refactor so setting up puzzles is handled in the editor, scripts do not need to handle anything other than logic - DONE
     */

    /* Basic Puzzle Types:
     * Tile Matching - DONE
     * Trading Quest - DONE
     * Sound Tones - DONE
     */

    /* Story Flags:
     * Game tracks how many levels have been completed - DONE
     * Game tracks "karma" descisions across all levels - DONE
     * Game decides which of the two endings the player recieves after completing all levels - DONE
     * Ending is decided by whether the player made more "good" or "bad" karma descisions - DONE
     * Descision script chooses whether to add good karma or bad karma - DONE
     * ToDo: Test that GM persits between scenes and the proper ending is decided - DONE
     * ToDo: Prevent TriggerEnding() from running infitely - DONE
     * ToDo: Allow test levels to properly be loaded - DONE
     * Fix: Camera disconnects between scenes - DONE
     * ToDo: Add Moral Choice
     * ToDo: Add Level Select
     */

    /* Other Checklists:
     * NPCs + NPC/Player Interaction - Working on in npc-interaction
     * Co-Op Mode
     * Menus
     * Game Options
     * Game Saving
     */
}
