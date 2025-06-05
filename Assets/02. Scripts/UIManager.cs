using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public GameObject playObj;
        public GameObject introUI;
        public void OnStartButton()
        {
            if(inputField.text.Length < 1)
            {
                return;
            }
            playObj.SetActive(true);
            introUI.SetActive(false);

            nameTextUI.text = inputField.text;
        }
    }
}
