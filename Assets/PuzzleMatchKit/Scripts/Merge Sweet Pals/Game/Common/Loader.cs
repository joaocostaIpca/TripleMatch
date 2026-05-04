using UnityEngine;

using MergeSweetPals.Core;

namespace MergeSweetPals.Game.Common
{
    /// <summary>
    /// Utility class to initialize the game manager.
    /// </summary>
    public class Loader : MonoBehaviour
    {
        public PuzzleMatchManager gameManager;
        public SoundManager soundManager;

        /// <summary>
        /// Unity's Awake method.
        /// </summary>
        private void Awake()
        {
            if (PuzzleMatchManager.instance == null)
            {
                Instantiate(gameManager);
            }
            if (SoundManager.instance == null)
            {
                Instantiate(soundManager);
            }
        }
    }
}
