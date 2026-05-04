using UnityEngine;
using UnityEngine.Assertions;

namespace GameVanilla.Game.UI
{
    /// <summary>
    /// This class identifies the particles emitted when a tile entity is destroyed.
    /// </summary>
    public class TileParticles : MonoBehaviour
    {
        public ParticleSystem fragmentParticles;

        /// <summary>
        /// Unity's Awake method.
        /// </summary>
        private void Awake()
        {
            Assert.IsNotNull(fragmentParticles);
        }
    }
}
