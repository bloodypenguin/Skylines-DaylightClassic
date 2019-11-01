using DaylightClassic.OptionsFramework;
using UnityEngine;

namespace DaylightClassic
{
    public class FogColorReplacer : MonoBehaviour
    {
        private static readonly Color SkyTintClassic = new Color(0.4078431372549019607843137254902f,
            0.65098039215686274509803921568627f, 0.82745098039215686274509803921569f,
            1.0f); //(104f, 166f, 211f, 255f);;

        private static readonly Vector3 WaveLengthsClassic = new Vector3(680f, 680f, 680f);

        private DayNightFogEffect _newEffect;
        private bool _cachedReplaceFogColor;
        private bool _cachedEffectEnabled;
        private Color _skyTintAd = Color.clear;
        private Vector3 _waveLengthsAd = Vector3.zero;
        private DayNightProperties _dayNightProperties;
        private Color _cachedSkyTint;
        private Vector3 _cachedWaveLengths;

        public void Awake()
        {
            _newEffect = FindObjectOfType<DayNightFogEffect>();
            _dayNightProperties = FindObjectOfType<DayNightProperties>();
        }

        public void Update()
        {
            ReplaceFogColorIfNeeded();
        }

        public void OnDestroy()
        {
            ReplaceFogColorImpl(false);
        }

        private void ReplaceFogColorIfNeeded()
        {
            if (_newEffect == null ||
                _cachedReplaceFogColor == OptionsWrapper<Options>.Options.FogColor &&
                _cachedEffectEnabled == _newEffect.enabled &&
                _dayNightProperties.m_WaveLengths.Equals(_cachedWaveLengths) &&
                _dayNightProperties.m_SkyTint.Equals(_cachedSkyTint))
            {
                return;
            }

            ReplaceFogColorImpl(_newEffect.enabled && OptionsWrapper<Options>.Options.FogColor);
            _cachedReplaceFogColor = OptionsWrapper<Options>.Options.FogColor;
            _cachedEffectEnabled = _newEffect.enabled;
            _cachedWaveLengths = _dayNightProperties.m_WaveLengths;
            _cachedSkyTint = _dayNightProperties.m_SkyTint;
        }

        private void ReplaceFogColorImpl(bool toClassic)
        {
            _dayNightProperties.m_SkyTint = toClassic ? SkyTintClassic : SkyTintAd;
            _dayNightProperties.m_WaveLengths = toClassic ? WaveLengthsClassic : WaveLengthsAd;
        }

        private Color SkyTintAd
        {
            get
            {
                if (_skyTintAd == Color.clear)
                {
                    _skyTintAd = _dayNightProperties.m_SkyTint;
                }

                return _skyTintAd;
            }
        }

        private Vector3 WaveLengthsAd
        {
            get
            {
                if (_waveLengthsAd == Vector3.zero)
                {
                    _waveLengthsAd = _dayNightProperties.m_WaveLengths;
                }

                return _waveLengthsAd;
            }
        }
    }
}