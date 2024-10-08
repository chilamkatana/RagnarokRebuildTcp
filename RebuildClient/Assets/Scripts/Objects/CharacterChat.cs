using TMPro;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class CharacterChat : MonoBehaviour
    {
        public TextMeshProUGUI TextObject;
        //public string Text;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        public void SetText(string text)
        {
            TextObject.text = text;
            TextObject.ForceMeshUpdate();
            

            var rect = TextObject.transform as RectTransform;
            rect.anchoredPosition = new Vector3(0, 5f, 0f);

            RefreshBorder();
        }

        public void RefreshBorder()
        {
            var rect = transform as RectTransform;
            
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, TextObject.textBounds.size.x + 18);
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, TextObject.textBounds.size.y + 13);
        }

        // Update is called once per frame
        void Update()
        {
            //SetText(Text);
        }
    }
}
