using DaylightClassic.Options;
using UnityEngine;

namespace DaylightClassic
{
    public class DaylightClassicProperties : MonoBehaviour
    {
        public Color SkyTintClassic;
        public Vector3 WaveLengthsClassic;
        public Color GroundColorClassic;

        public void Awake()
        {
            WaveLengthsClassic = new Vector3(680f, 680f, 680f);
            SkyTintClassic = new Color(0.4078431372549019607843137254902f, 0.65098039215686274509803921568627f, 0.82745098039215686274509803921569f, 1.0f); //(104f, 166f, 211f, 255f);
            //(41,111,163)"
            GroundColorClassic = new Color(0.369f, 0.349f, 0.341f, 1f);
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