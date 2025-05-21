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
        
        private void Start()
        {
            _objectRenderer = GetComponent<Renderer>();
            _originalMaterial = _objectRenderer.material;

            _outlineMaterial.CopyPropertiesFromMaterial(_originalMaterial);
            _switchRotationStateIndex = 0;
        }

        private void OnMouseEnter()
        {
            _objectRenderer.material = _outlineMaterial;
        }

        private void OnMouseDown()
        {
            _switchRotationStateIndex++;
            
            if (_switchRotationStateIndex > _switchRotations.Count - 1)
            {
                _switchRotationStateIndex = 0;
            }
        
            SwitchRotation(_switchRotationStateIndex);
            _multimeterController.SetState((MultimeterState)_switchRotationStateIndex);
        }

        private void SwitchRotation(int stateIndex)
        {
            Vector3 currentRotation = transform.eulerAngles;

            currentRotation.z = _switchRotations[stateIndex];

            transform.eulerAngles = currentRotation;
        }

        private void OnMouseExit()
        {
            _objectRenderer.material = _originalMaterial;
        }
    }
}