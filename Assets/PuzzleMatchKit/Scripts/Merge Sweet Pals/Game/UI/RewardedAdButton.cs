using UnityEngine;

using MergeSweetPals.Core;
using MergeSweetPals.Game.Common;
using MergeSweetPals.Game.Popups;
using MergeSweetPals.Game.Scenes;

namespace MergeSweetPals.Game.UI
{
	/// <summary>
	/// The rewarded advertisement button that is present in the level scene.
	/// </summary>
	public class RewardedAdButton : MonoBehaviour
	{
        private AnimatedButton button;
        private string adUnitId;

        private const string iOSAdUnitId = "Rewarded_iOS";
        private const string androidAdUnitId = "Rewarded_Android";

        private void Awake()
        {
            button = GetComponent<AnimatedButton>();
        }

        private void Start()
        {
            gameObject.SetActive(false);

            adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? iOSAdUnitId
                : androidAdUnitId;

            LoadAd();
        }

        private void OnDestroy()
        {
            if (button != null)
            {
                button.onClick.RemoveAllListeners();
            }
        }

        public void ShowAd()
        {
            Debug.Log($"Showing rewarded ad: {adUnitId}");
            // LevelPlay will handle showing the ad and tracking completion
            // Coins will ONLY be awarded if the user watches the full ad
            // This will be properly implemented once LevelPlay API is fully integrated
        }

        public void LoadAd()
        {
            try
            {
                Debug.Log($"Loading rewarded ad: {adUnitId}");
                // Ad loading through LevelPlay dashboard configuration
                gameObject.SetActive(true);
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Error loading rewarded ad: {ex.Message}");
            }
        }

        private void RewardUser()
        {
            Debug.Log("User rewarded for watching ad");

            // Reward the user
            var gameManager = PuzzleMatchManager.instance;
            var rewardCoins = gameManager.gameConfig.rewardedAdCoins;
            gameManager.coinsSystem.BuyCoins(rewardCoins);

            var levelScene = GameObject.Find("LevelScene");
            if (levelScene != null)
            {
                levelScene.GetComponent<LevelScene>().OpenPopup<AlertPopup>("Popups/AlertPopup", popup =>
                {
                    popup.SetTitle("Reward");
                    popup.SetText(string.Format("You earned {0} coins!", rewardCoins));
                }, false);
            }
        }
	}
}
