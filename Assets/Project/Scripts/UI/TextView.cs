using TMPro;
using UnityEngine;

namespace Project.Scripts.UI
{
    public class TextView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeaning;

        public void SetupMeaning(float meaning)
        {
            Setter(meaning);
        }

        public void UpdateMeaning(float meaning)
        {
            Setter(meaning);
        }

        private void Setter(float meaning)
        {
            _textMeaning.text = meaning.ToString("F2");
        }
    }
}