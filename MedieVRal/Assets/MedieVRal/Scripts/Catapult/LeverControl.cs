namespace VRTK
{
    using UnityEngine;
    using UnityEventHelper;

    public class LeverControl : MonoBehaviour
    {
        public TextMesh text;
        public Lanzadera lanzadera;

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
            if(e.value >= 50)
            {
                lanzadera.Activate();
            }
            text.text = e.value.ToString() + "(" + e.normalizedValue.ToString() + "%)";
        }
    }
}