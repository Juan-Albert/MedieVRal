namespace VRTK
{
    using UnityEngine;
    using UnityEventHelper;

    public class WheelControlRotator : MonoBehaviour
    {
        public GameObject catapult;
        public TextMesh text;
        private VRTK_Control_UnityEvents controlEvents;

        private void Start()
        {
            
            controlEvents = GetComponent<VRTK_Control_UnityEvents>();
            if (controlEvents == null)
            {
                controlEvents = gameObject.AddComponent<VRTK_Control_UnityEvents>();
            }
            
            controlEvents.OnValueChanged.AddListener(HandleChange);
            
        }

        private void HandleChange(object sender, Control3DEventArgs e)
        {
            text.text = e.value.ToString() + "(" + e.normalizedValue.ToString() + "%)";
            catapult.transform.eulerAngles = new Vector3(catapult.transform.rotation.eulerAngles.x,60 +  ((100 / 100) * e.value), catapult.transform.rotation.eulerAngles.z);
        }
    }
}
