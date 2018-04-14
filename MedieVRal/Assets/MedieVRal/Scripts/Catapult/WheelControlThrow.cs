namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEventHelper;

    public class WheelControlThrow : MonoBehaviour
    {
        public GameObject lanzadera;
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
            lanzadera.transform.eulerAngles = new Vector3(lanzadera.transform.rotation.eulerAngles.x, lanzadera.transform.rotation.eulerAngles.y, (-125/125)* e.value);
        }
    }
}
