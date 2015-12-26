using DaylightClassic.Options;
using UnityEngine;

namespace DaylightClassic
{
    public class DaylightClassicProperties : MonoBehaviour
    {
        public Color SkyTintClassic;
        public Vector3 WaveLengthsClassic;
        private Color _previousSkyTint;
        private Vector3 _previousWaveLengths;

        public void Awake()
        {
            WaveLengthsClassic = new Vector3(680f, 680f, 680f);
            _previousWaveLengths = WaveLengthsClassic;
            SkyTintClassic = new Color(0.4078431372549019607843137254902f, 0.65098039215686274509803921568627f, 0.82745098039215686274509803921569f, 1.0f); //(104f, 166f, 211f, 255f);
            _previousSkyTint = SkyTintClassic;
        }

        public void Update()
        {
            if (!_previousWaveLengths.Equals(WaveLengthsClassic) || !_previousSkyTint.Equals(SkyTintClassic))
            {
                if (DaylightClassic.ReplaceFogColor(OptionsHolder.Options.fogColor))
                {
                    _previousWaveLengths = WaveLengthsClassic;
                    _previousSkyTint = SkyTintClassic;
                }
            }
            #if DEBUG
            if ((!Input.GetKey(KeyCode.RightShift) && !Input.GetKey(KeyCode.LeftShift)) || !Input.GetKeyDown(KeyCode.E))
            {
                return;
            }
            var previousState = OptionsHolder.Options.fogEffect;
            var newState = !previousState;
            DaylightClassic.ReplaceFogEffect(newState);
            OptionsHolder.Options.fogEffect = newState;
            #endif
        }
    }
}