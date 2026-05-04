using UnityEngine;
using UnityEngine.UI;

using GameVanilla.Game.Common;

namespace GameVanilla.Game.UI
{
    /// <summary>
    /// This class manages the in-game user interface for the level goals.
    /// </summary>
    public class GoalUi : MonoBehaviour
    {
        [SerializeField]
        public HorizontalLayoutGroup group;

        /// <summary>
        /// Updates the state of the goals of the current level.
        /// </summary>
        /// <param name="state">The current game state.</param>
        public void UpdateGoals(GameState state)
        {
            foreach (var element in group.GetComponentsInChildren<GoalUiElement>())
            {
                element.UpdateGoal(state);
            }
        }
    }
}
