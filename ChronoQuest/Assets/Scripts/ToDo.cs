using UnityEngine;

public class ToDo : MonoBehaviour
{
    /*
     * Player Movement + Physics:
     * Basic Player Movement - DONE
     * Fix: Player Spawns in ground - DONE
     * Fix: Player tips over - DONE
     * Fix: Player moves too fast - DONE
     * Camera follows Player POV - DONE
     * Player can turn using the Mouse - Working On
     * ToDo: Significantly improve camera sensitivity - DONE
     * Fix: Camera's Y rotation is inverted - Working On
     */

    /*
     * Puzzle Logic:
     * Solved Bool Variable - DONE
     * Puzzle ID is logged when Solved (according to its own method) - DONE
     * ToDo: Test Puzzle has its own GO in the Scene already - DONE
     * Fix: Variables still can't be seen in the editor - Working On (Make the Puzzle classes the main component?)
     * Related Obstacle GO is removed (according to its own method) when Solved - DONE
     * Fix: "Obstacle Removed" log repeats endlessly - DONE
     * ToDo: Make Obstacles their own inheritable class - DONE
     * Fix: Obstacles are not being removed - DONE
     * Fix: NullReferenceException at ObstacleController line 86 - DONE
     * ToDo: Test to ensure multiple puzzles + obstacles don't conflict or intersect w/ each other - DONE
     * Idea: Give Puzzle + Obstacle types their own tags to help w/ sorting + avoiding conflicts - DONE
     * Idea: Refactor so setting up puzzles is handled in the editor, scripts do not need to handle anything other than logic
     * ToDo: Turn Puzzles + Obstacles into reusable Prefabs
     */

    /*
     * Basic Puzzle Types:
     * Tile Matching - DONE
     * Slider Tiles?
     * Chess-like Guard Evading?
     */

    /*
     * Other Checklists:
     * NPCs + NPC/Player Interaction
     * Story Flags
     * Co-Op Mode
     * Menus
     * Game Saving
     */
}
