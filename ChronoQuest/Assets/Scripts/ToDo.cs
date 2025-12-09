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

    /* Sound Tone Puzzle Logic:
     * Button which plays a short sequence of sound tones - Working On
     * Buttons which play individual sound tones - Working On
     * Pressing the buttons in the same order as the sequence marks the puzzle as solved
     * ToDo: Separate scripts and assign them to the individual components - Working On
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
     * Sound Tones - Working On
     */

    /* Other Checklists:
     * NPCs + NPC/Player Interaction
     * Story Flags
     * Co-Op Mode
     * Menus
     * Game Saving
     */
}
