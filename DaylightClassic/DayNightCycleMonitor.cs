using ColossalFramework;
using DaylightClassic.OptionsFramework;
using UnityEngine;

namespace DaylightClassic
{
    public class DayNightCycleMonitor : MonoBehaviour
    {
        private bool _previousFogColorState;
        private bool _initialized;
        private bool _cachedNight;
        private bool _cachedDisableOption;
        private bool _cachedDayNightCycleState;

        public void Update()
        {
            var dayNightEnabled = Singleton<SimulationManager>.instance.m_enableDayNight;
            var disableClassicFogEffectIfDayNightIsOn = !OptionsWrapper<Options>.Options.AllowClassicFogEffectIfDayNightIsOn;
            if (_initialized && disableClassicFogEffectIfDayNightIsOn == _cachedDisableOption && dayNightEnabled == _cachedDayNightCycleState &&
                _cachedNight == SimulationManager.instance.m_isNightTime && _previousFogColorState == OptionsWrapper<Options>.Options.FogColor)
            {
                return;
            }
            SetUpEffects(SimulationManager.instance.m_isNightTime || dayNightEnabled && disableClassicFogEffectIfDayNightIsOn);
            _initialized = true;
            _cachedDisableOption = disableClassicFogEffectIfDayNightIsOn;
            _cachedNight = SimulationManager.instance.m_isNightTime;
            _cachedDayNightCycleState = dayNightEnabled;
        }

        public void OnDestroy()
        {
            SetUpEffects(true);
        }

        private void SetUpEffects(bool isNight)
        {
            var behaviors = Camera.main?.GetComponents<MonoBehaviour>();
            if (behaviors == null)
            {
                return;
            }
            foreach (var behavior in behaviors)
            {
                switch (behavior)
                {
                    case FogEffect fe:
                    {
                        fe.enabled = !isNight;
                        if (fe.enabled)
                        {
                            DaylightClassic.ReplaceFogColorImpl(false);
                        }
                        break;
                    }
                    case DayNightFogEffect dnfe:
                    {
                        dnfe.enabled = isNight;
                        if (dnfe.enabled)
                        {
                            DaylightClassic.ReplaceFogColorImpl(OptionsWrapper<Options>.Options.FogColor);
                        }
                        break;
                    }
                }
            }
            _previousFogColorState = OptionsWrapper<Options>.Options.FogColor;
        }
    }
}