using UnityEngine;

using GameVanilla.Game.Common;
using UnityEngine.UI;

namespace GameVanilla.Game.UI
{
    /// <summary>
    /// Utility class to set the canvas scaler's match to the one defined in the editor.
    /// </summary>
    public class AdjustCanvasToResolution : MonoBehaviour
    {
        /// <summary>
        /// The associated canvas scaler.
        /// </summary>
        private CanvasScaler canvasScaler;

        /// <summary>
        /// Unity's Start method.
        /// </summary>
        private void Start()
        {
            canvasScaler = GetComponent<CanvasScaler>();

            var gameConfig = PuzzleMatchManager.instance.gameConfig;
            canvasScaler.matchWidthOrHeight = gameConfig.defaultCanvasScalingMatch;
            foreach (var resolution in gameConfig.resolutionOverrides)
            {
                if (resolution.width == Screen.width && resolution.height == Screen.height)
                {
                    canvasScaler.matchWidthOrHeight = resolution.canvasScalingMatch;
                    break;
                }
            }
        }
    }
}
