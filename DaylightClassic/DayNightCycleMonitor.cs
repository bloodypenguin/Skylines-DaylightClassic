using ColossalFramework;
using DaylightClassic.OptionsFramework;
using UnityEngine;

namespace DaylightClassic
{
    public class DayNightCycleMonitor : MonoBehaviour
    {
        private bool _previousEffectState;
        private bool _previousFogColorState;
        private bool _initialized;

        public void Awake()
        {
            var dayNightEnabled = Singleton<SimulationManager>.instance.m_enableDayNight;
            SetUpEffects(dayNightEnabled);
        }

        public void Update()
        {
            var dayNightEnabled = Singleton<SimulationManager>.instance.m_enableDayNight;
            if (dayNightEnabled == _previousEffectState && _previousFogColorState ==
                OptionsWrapper<Options>.Options.FogColor && _initialized)
            {
                return;
            }
            SetUpEffects(dayNightEnabled);
            _initialized = true;
        }

        public void OnDestroy()
        {
            SetUpEffects(true);
        }

        private void SetUpEffects(bool dayNightEnabled)
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
                        fe.enabled = !dayNightEnabled;
                        if (fe.enabled)
                        {
                            DaylightClassic.ReplaceFogColorImpl(false);
                        }
                        break;
                    }
                    case DayNightFogEffect dnfe:
                    {
                        dnfe.enabled = dayNightEnabled;
                        if (dnfe.enabled)
                        {
                            DaylightClassic.ReplaceFogColorImpl(OptionsWrapper<Options>.Options.FogColor);
                        }
                        break;
                    }
                }
            }
            _previousEffectState = dayNightEnabled;
            _previousFogColorState = OptionsWrapper<Options>.Options.FogColor;
        }
    }
}