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
        private float _cachedTimeOfDay;

        public void Awake()
        {
            _newEffect = FindObjectOfType<DayNightFogEffect>();
            _dayNightProperties = FindObjectOfType<DayNightProperties>();
            _waveLengthsAd = _dayNightProperties.m_WaveLengths;
            _skyTintAd = _dayNightProperties.m_SkyTint;
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
                _dayNightProperties.m_SkyTint.Equals(_cachedSkyTint) &&
                _dayNightProperties.m_TimeOfDay.Equals(_cachedTimeOfDay))
            {
                return;
            }

            ReplaceFogColorImpl(_newEffect.enabled && OptionsWrapper<Options>.Options.FogColor);
            _cachedReplaceFogColor = OptionsWrapper<Options>.Options.FogColor;
            _cachedEffectEnabled = _newEffect.enabled;
            _cachedWaveLengths = _dayNightProperties.m_WaveLengths;
            _cachedSkyTint = _dayNightProperties.m_SkyTint;
            _cachedTimeOfDay = _dayNightProperties.m_TimeOfDay;
        }

        private void ReplaceFogColorImpl(bool toClassic)
        {
            _dayNightProperties.m_SkyTint = toClassic
                ? SkyTintClassicGradient.Evaluate(_dayNightProperties.normalizedTimeOfDay)
                : _skyTintAd;
            _dayNightProperties.m_WaveLengths = toClassic
                ? FromColor(WaveLengthsClassicGradient.Evaluate(_dayNightProperties.normalizedTimeOfDay))
                : _waveLengthsAd;
        }

        private Gradient SkyTintClassicGradient => new Gradient()
        {
            colorKeys = new GradientColorKey[6]
            {
                new GradientColorKey(_skyTintAd, 0f),
                new GradientColorKey(_skyTintAd, 0.29f),
                new GradientColorKey(SkyTintClassic, 0.35f),
                new GradientColorKey(SkyTintClassic, 0.65f),
                new GradientColorKey(_skyTintAd, 0.71f),
                new GradientColorKey(_skyTintAd, 1f)
            },
            alphaKeys = new GradientAlphaKey[2]
            {
                new GradientAlphaKey(1f, 0.0f),
                new GradientAlphaKey(1f, 1f)
            }
        };

        private Gradient WaveLengthsClassicGradient => new Gradient()
        {
            colorKeys = new GradientColorKey[6]
            {
                new GradientColorKey(FromVector3(_waveLengthsAd), 0f),
                new GradientColorKey(FromVector3(_waveLengthsAd), 0.29f),
                new GradientColorKey(FromVector3(WaveLengthsClassic), 0.35f),
                new GradientColorKey(FromVector3(WaveLengthsClassic), 0.65f),
                new GradientColorKey(FromVector3(_waveLengthsAd), 0.71f),
                new GradientColorKey(FromVector3(_waveLengthsAd), 1f)
            },
            alphaKeys = new GradientAlphaKey[2]
            {
                new GradientAlphaKey(1f, 0.0f),
                new GradientAlphaKey(1f, 1f)
            }
        };

        private Color FromVector3(Vector3 vector3)
        {
            return new Color(vector3.x / 1000f, vector3.y / 1000f, vector3.z / 1000f);
        }

        private Vector3 FromColor(Color color)
        {
            return new Vector3(color.r * 1000f, color.g * 1000f, color.b * 1000f);
        }
    }
}