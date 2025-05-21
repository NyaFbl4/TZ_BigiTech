using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SwitchController : MonoBehaviour
{
    [SerializeField] private Material _outlineMaterial;
    private Material _originalMaterial;
    private Renderer _objectRenderer;

    [SerializeField] private List<float> _switchRotations = new();
    private int _switchRotationStateIndex;

    private void Start()
    {
        _objectRenderer = GetComponent<Renderer>();
        _originalMaterial = _objectRenderer.material;

        _switchRotationStateIndex = 0;
        SwitchRotation(_switchRotationStateIndex);
        
        _outlineMaterial.CopyPropertiesFromMaterial(_originalMaterial);
    }

    private void OnMouseEnter()
    {
        _objectRenderer.material = _outlineMaterial;
    }

    private void OnMouseDown()
    {
        _switchRotationStateIndex++;

        Debug.Log(_switchRotationStateIndex);
        if (_switchRotationStateIndex > _switchRotations.Count - 1)
        {
            _switchRotationStateIndex = 0;
        }
        
        SwitchRotation(_switchRotationStateIndex);
    }

    private void OnMouseExit()
    {
        _objectRenderer.material = _originalMaterial;
    }

    private void SwitchRotation(int stateIndex)
    {
        Vector3 currentRotation = transform.eulerAngles;

        currentRotation.z = _switchRotations[stateIndex];

        transform.eulerAngles = currentRotation;
    }
}
