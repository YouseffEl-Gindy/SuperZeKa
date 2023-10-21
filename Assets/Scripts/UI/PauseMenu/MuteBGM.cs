using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteBGM : MonoBehaviour
{
    [SerializeField]Button button;

    private void Start()
    {
        button.onClick.AddListener(AudioManager.Instance.ToggleMusic);
    }
}
