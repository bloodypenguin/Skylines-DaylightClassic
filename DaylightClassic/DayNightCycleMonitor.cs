using ColossalFramework;
using DaylightClassic.Options;
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
            var dayNightEnabled = !OptionsHolder.Options.fogEffect;//Singleton<SimulationManager>.instance.m_enableDayNight;
//            if (dayNightEnabled == _previousEffectState && _previousFogColorState == OptionsHolder.Options.fogColor && _initialized)
//            {
//                return;
//            }
            SetUpEffects(dayNightEnabled);
            _initialized = true;
        }

        public void OnDestroy()
        {
            SetUpEffects(true);
        }

        private void SetUpEffects(bool dayNightEnabled)
        {
            var behaviors = Camera.main.GetComponents<MonoBehaviour>();
            foreach (var behavior in behaviors)
            {
                if (behavior is FogEffect)
                {
                    behavior.enabled = !dayNightEnabled;
                    if (behavior.enabled)
                    {
                        DaylightClassic.ReplaceFogColorImpl(false);
                    }
                }
                if (behavior is DayNightFogEffect)
                {
                    behavior.enabled = dayNightEnabled;
                    if (behavior.enabled)
                    {
                        DaylightClassic.ReplaceFogColorImpl(OptionsHolder.Options.fogColor);                        
                    }
                }
            }
            _previousEffectState = dayNightEnabled;
            _previousFogColorState = OptionsHolder.Options.fogColor;
        }
    }
}