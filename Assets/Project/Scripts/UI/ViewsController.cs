using UnityEngine;

namespace Project.Scripts.UI
{
    public class ViewsController : MonoBehaviour
    {
        [SerializeField] private TextView _displayView;
        
        [SerializeField] private TextView _soprotivlenieView;
        [SerializeField] private TextView _silaTokaView;
        [SerializeField] private TextView _napryajeniePostoyannogoTokaView;
        [SerializeField] private TextView _napryajeniePeremennogoTokaView;

        public void SetupViews(float soprotivlenie, float silaToka, 
            float napryajeniePostoyannogoToka, float napryajeniePeremennogoToka)
        {
            _displayView.SetupMeaning(0);
            
            _soprotivlenieView.SetupMeaning(soprotivlenie);
            _silaTokaView.SetupMeaning(silaToka);
            _napryajeniePostoyannogoTokaView.SetupMeaning(napryajeniePostoyannogoToka);
            _napryajeniePeremennogoTokaView.SetupMeaning(napryajeniePeremennogoToka);
        }

        public void UpdateDisplay(float meaning)
        {
            _displayView.UpdateMeaning(meaning);
        }
    }
}