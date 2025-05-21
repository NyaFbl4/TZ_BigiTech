using System.Collections;
using System.Collections.Generic;
using Project.Scripts;
using Project.Scripts.UI;
using UnityEngine;

public class MultimeterController : MonoBehaviour
{
    [SerializeField] private ViewsController _viewsController;
    [SerializeField] private PhysicsConfig _config;
    
    private PhysicsModel _physicsModel;
    private MultimeterState _currentMultimeterState;
    private void Start()
    {
        _physicsModel = new PhysicsModel(_config);
        _viewsController.SetupViews(_physicsModel.Soprotivlenie, _physicsModel.SilaToka,
            _physicsModel.NapryajeniePostoyannogoToka, _physicsModel.NapryajeniePeremennogoToka);
        
        _currentMultimeterState = MultimeterState.Neutral;
    }

    public void SetState(MultimeterState newState)
    {
        _currentMultimeterState = newState;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        float value = 0f;
        
        switch (_currentMultimeterState)
        {
            case MultimeterState.Neutral: 
                break;
            case MultimeterState.Soprotivlenie:
                value = _physicsModel.Soprotivlenie;
                break;
            case MultimeterState.SilaToka:
                value = _physicsModel.SilaToka;
                break;
            case MultimeterState.NapryajeniePeremennogoToka:
                value = _physicsModel.NapryajeniePeremennogoToka;
                break;
            case MultimeterState.NapryajeniePostoyannogoToka:
                value = _physicsModel.NapryajeniePostoyannogoToka;
                break;
        }
        
        _viewsController.UpdateDisplay(value);
    }
}
