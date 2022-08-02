using Jenga.Block;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ActivationButton : MonoBehaviour
{
    [FormerlySerializedAs("_blocks")] [SerializeField] private Jenga.Jenga jenga;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        jenga.SceneInitialized += ActivateButton;
        DeactivateButton();
    }

    private void ActivateButton()
    {
        _button.interactable = true;
    }
    
    private void DeactivateButton()
    {
        _button.interactable = false;
    }
}





