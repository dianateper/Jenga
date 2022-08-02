using UnityEngine;
using UnityEngine.Advertisements;

namespace Jenga.Services.Ads
{
    public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
    {
        [SerializeField] string _androidGameId;
        [SerializeField] string _iOSGameId;
        [SerializeField] bool _testMode = true;
        [SerializeField] private InterstitialAd _interstitialAd;
        private string _gameId;

        private void Awake()
        {
            InitializeAds();
            var adsInitializer = FindObjectOfType<AdsInitializer>();
            if (adsInitializer != null && adsInitializer.gameObject != gameObject)
            {
                Destroy(adsInitializer.gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        public void InitializeAds()
        {
            _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? _iOSGameId
                : _androidGameId;
            Advertisement.Initialize(_gameId, _testMode, this);
        }

        public void OnInitializationComplete()
        {
            Debug.Log("Unity Ads initialization complete.");
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
        }
    }
}