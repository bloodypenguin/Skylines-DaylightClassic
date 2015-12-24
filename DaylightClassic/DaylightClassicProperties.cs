using DaylightClassic.Options;
using UnityEngine;

namespace DaylightClassic
{
    public class DaylightClassicProperties : MonoBehaviour
    {
        public Color SkyTintClassic;
        public Vector3 WaveLengthsClassic;

        public void Awake()
        {
            SkyTintClassic = new Color(96.0f, 124.0f, 127.0f, 0.0f);
            WaveLengthsClassic = new Vector3(630.0f, 550.4f, 455.4f);
        }

        public void Update()
        {
            if ((!Input.GetKey(KeyCode.RightShift) && !Input.GetKey(KeyCode.LeftShift)) || !Input.GetKeyDown(KeyCode.E))
            {
                return;
            }
            var previousState = OptionsHolder.Options.fogEffect;
            var newState = !previousState;
            DaylightClassic.ReplaceFogEffect(newState);
            OptionsHolder.Options.fogEffect = newState;
            Options.OptionsLoader.SaveOptions();
        }
    }
}