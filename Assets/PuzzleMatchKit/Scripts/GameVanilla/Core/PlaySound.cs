using UnityEngine;

namespace GameVanilla.Core
{
    /// <summary>
    /// Utility class to play a sound via the SoundManager.
    /// </summary>
    public class PlaySound : MonoBehaviour
    {
        /// <summary>
        /// Plays the specified sound.
        /// </summary>
        /// <param name="soundName">The name of the sound to play.</param>
        public void Play(string soundName)
        {
            SoundManager.instance.PlaySound(soundName);
        }
    }
}
