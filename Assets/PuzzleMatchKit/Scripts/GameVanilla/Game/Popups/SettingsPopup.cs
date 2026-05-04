using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

using GameVanilla.Core;
using GameVanilla.Game.Common;
using GameVanilla.Game.Scenes;

namespace GameVanilla.Game.Popups
{
    /// <summary>
    /// This class contains the logic associated to the settings popup.
    /// </summary>
    public class SettingsPopup : Popup
    {
#pragma warning disable 649
        [SerializeField]
        private Slider soundSlider;

        [SerializeField]
        private Slider musicSlider;

        [SerializeField]
        private Toggle notificationsToggle;

        [SerializeField]
        private AnimatedButton resetProgressButton;

        [SerializeField]
        private Image resetProgressImage;

        [SerializeField]
        private Sprite resetProgressDisabledSprite;
#pragma warning restore 649

        private int currentSound;
        private int currentMusic;
        private int currentNotifications;

        /// <summary>
        /// Unity's Awake method.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            Assert.IsNotNull(soundSlider);
            Assert.IsNotNull(musicSlider);
            Assert.IsNotNull(notificationsToggle);
            Assert.IsNotNull(resetProgressButton);
            Assert.IsNotNull(resetProgressImage);
            Assert.IsNotNull(resetProgressDisabledSprite);
        }

        /// <summary>
        /// Unity's Start method.
        /// </summary>
        protected override void Start()
        {
            base.Start();
            soundSlider.value = PlayerPrefs.GetInt("sound_enabled");
            musicSlider.value = PlayerPrefs.GetInt("music_enabled");
            notificationsToggle.isOn = PlayerPrefs.GetInt("notifications_enabled") == 1;
        }

        /// <summary>
        /// Called when the close button is pressed.
        /// </summary>
        public void OnCloseButtonPressed()
        {
            Close();
        }

        /// <summary>
        /// Called when the save button is pressed.
        /// </summary>
        public void OnSaveButtonPressed()
        {
            PlayerPrefs.SetInt("notifications_enabled", currentNotifications);
            SoundManager.instance.SetSoundEnabled(currentSound == 1);
            SoundManager.instance.SetMusicEnabled(currentMusic == 1);
            var homeScene = parentScene as HomeScene;
            if (homeScene != null)
            {
                homeScene.UpdateButtons();
            }
            Close();
        }

        /// <summary>
        /// Called when the reset progress button is pressed.
        /// </summary>
        public void OnResetProgressButtonPressed()
        {
            PuzzleMatchManager.instance.lastSelectedLevel = 0;
            PlayerPrefs.SetInt("next_level", 0);
            for (var i = 1; i <= 30; i++)
            {
                PlayerPrefs.DeleteKey(string.Format("level_stars_{0}", i));
            }
            resetProgressImage.sprite = resetProgressDisabledSprite;
            resetProgressButton.interactable = false;
        }

        /// <summary>
        /// Called when the help button is pressed.
        /// </summary>
        public void OnHelpButtonPressed()
        {
            parentScene.OpenPopup<AlertPopup>("Popups/AlertPopup", popup =>
            {
                popup.SetTitle("Help");
                popup.SetText("Do you need help?");
            }, false);
        }

        /// <summary>
        /// Called when the info button is pressed.
        /// </summary>
        public void OnInfoButtonPressed()
        {
            parentScene.OpenPopup<AlertPopup>("Popups/AlertPopup", popup =>
            {
                popup.SetTitle("About");
                popup.SetText("Created by Teletab.\n Copyright (C) 2026.");
            }, false);
        }

        /// <summary>
        /// Called when the sound slider value is changed.
        /// </summary>
        public void OnSoundSliderValueChanged()
        {
            currentSound = (int) soundSlider.value;
        }

        /// <summary>
        /// Called when the music slider value is changed.
        /// </summary>
        public void OnMusicSliderValueChanged()
        {
            currentMusic = (int) musicSlider.value;
        }

        /// <summary>
        /// Called when the notifications toggle is changed.
        /// </summary>
        public void OnNotificationsToggleChanged()
        {
            currentNotifications = notificationsToggle.isOn ? 1 : 0;
        }
    }
}
