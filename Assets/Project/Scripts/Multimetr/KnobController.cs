using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts
{
    [RequireComponent(typeof(Renderer))]
    public class KnobController : MonoBehaviour
    {
        [SerializeField] private Material _outlineMaterial;
        private Material _originalMaterial;
        private Renderer _objectRenderer;

        [SerializeField] private MultimeterController _multimeterController;
        [SerializeField] private List<float> _switchRotations = new();
        private int _switchRotationStateIndex;
        private bool _isHovered;
        
        private void Start()
        {
            _objectRenderer = GetComponent<Renderer>();
            _originalMaterial = _objectRenderer.material;

            _isHovered = false;
            _outlineMaterial.CopyPropertiesFromMaterial(_originalMaterial);
            _switchRotationStateIndex = 0;
            SwitchRotation(_switchRotationStateIndex);
        }

        private void Update()
        {
            if (_isHovered)
            {
                float scroll = Input.GetAxis("Mouse ScrollWheel");

                if (scroll > 0f)
                {
                    RotateToNextState();
                }
                else if(scroll < 0f)
                {
                    RotateToPreviousState();
                }
            }
        }

        private void OnMouseEnter()
        {
            _objectRenderer.material = _outlineMaterial;
            _isHovered = true;
        }
        
        private void OnMouseExit()
        {
            _objectRenderer.material = _originalMaterial;
            _isHovered = false;
        }
        
        private void RotateToNextState()
        {
            _switchRotationStateIndex = (_switchRotationStateIndex + 1) % _switchRotations.Count;
            UpdateState();
        }

        private void RotateToPreviousState()
        {
            _switchRotationStateIndex = (_switchRotationStateIndex - 1 + _switchRotations.Count) % _switchRotations.Count;
            UpdateState();
        }

        private void UpdateState()
        {
            SwitchRotation(_switchRotationStateIndex);
            _multimeterController.SetState((MultimeterState)_switchRotationStateIndex);
        }

        private void SwitchRotation(int stateIndex)
        {
            Vector3 currentRotation = transform.eulerAngles;

            currentRotation.z = _switchRotations[stateIndex];

            transform.eulerAngles = currentRotation;
        }
    }
}