using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public SoundManager soundManager;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public GameObject playObj;
        public GameObject introUI;
        public GameObject playUI;

        void Awake()
        {
            playObj.SetActive(false);
            introUI.SetActive(true);
            playUI.SetActive(false);
        }

        public void OnStartButton()
        {
            if(inputField.text.Length < 1)
            {
                return;
            }
            
            playObj.SetActive(true);
            playUI.SetActive(true);
            GameManager.instance.isPlay = true;
            soundManager.SetBGMSound(SoundManager.SoundType.BGM);

            introUI.SetActive(false);

            nameTextUI.text = inputField.text;
        }
    }
}
