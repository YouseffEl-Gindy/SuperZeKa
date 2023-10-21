using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSFX : MonoBehaviour
{
    [SerializeField]Button button;

    private void Start()
    {
        button.onClick.AddListener(AudioManager.Instance.ToggleSFX);
    }
}
