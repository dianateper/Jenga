using Jenga.Services.Ads;
using Jenga.Services.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Jenga.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        [SerializeField] private string _sceneName;
        [SerializeField] private Button playButton;
        [SerializeField] private bool _useAd;

        private ISceneLoader _sceneLoader;
        private InterstitialAd _interstitialAd;
        private const int AdsFrequency = 2;

        private void Start()
        {
            _interstitialAd = FindObjectOfType<InterstitialAd>();
            _sceneLoader = new SceneLoader();
            playButton.onClick.AddListener(() => LoadScene());
        }

        private void LoadScene()
        {
            if (_useAd && Random.Range(0, AdsFrequency) == 0)
                LoadAd();
            else
                _sceneLoader.LoadScene(_sceneName);
        }
        
        private void LoadAd()
        {
            _interstitialAd.LoadOnComplete = _sceneName;
            _interstitialAd.LoadAd();
            _interstitialAd.ShowAd();
        }
    }
}
