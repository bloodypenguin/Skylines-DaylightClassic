using ColossalFramework;
using UnityEngine;

namespace DaylightClassic
{
    public class DayNightCycleMonitor : MonoBehaviour
    {
        private static bool _previousState;

        public void Awake()
        {
            _previousState = false;
            var dayNightEnabled = Singleton<SimulationManager>.instance.m_enableDayNight;
            SetUpEffects(dayNightEnabled);
        }

        public void Update()
        {
            var dayNightEnabled = Singleton<SimulationManager>.instance.m_enableDayNight;
            if (dayNightEnabled == _previousState)
            {
                return;
            }
            SetUpEffects(dayNightEnabled);
        }

        public void OnDestroy()
        {
            SetUpEffects(true);
            _previousState = false;
        }

        private static void SetUpEffects(bool dayNightEnabled)
        {
            var behaviors = Camera.main.GetComponents<MonoBehaviour>();
            foreach (var behavior in behaviors)
            {
                if (behavior is FogEffect)
                {
                    behavior.enabled = !dayNightEnabled;
                }
                if (behavior is DayNightFogEffect)
                {
                    behavior.enabled = dayNightEnabled;
                }
            }
            _previousState = dayNightEnabled;
        }
    }
}