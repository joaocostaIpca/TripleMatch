using UnityEngine;

using MergeSweetPals.Game.Common;

namespace MergeSweetPals.Core
{
    /// <summary>
    /// This system is responsible for initializing LevelPlay Ads Mediation at startup time.
    /// </summary>
    public class AdsSystem : MonoBehaviour
    {
        private void Start()
        {
            InitializeAds();
        }

        public void InitializeAds()
        {
            try
            {
                // LevelPlay is automatically initialized by the package
                // This is a placeholder for any custom initialization logic
                Debug.Log("Ads System initialized. LevelPlay ready for ads.");
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Ads System Initialization Failed: {ex.Message}");
            }
        }
    }
}