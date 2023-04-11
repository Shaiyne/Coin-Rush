using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingLevelSlider : UIBase
{
    [SerializeField] Slider slider;
    [SerializeField] GameObject _clickScreenImage;

    private void Update()
    {
        if(slider.value >= 0.2f)
        {
            CoreSignals.Instance.onLevelStart?.Invoke();
            _clickScreenImage.SetActive(false);
            ClickSound();
            this.gameObject.SetActive(false);
        }
    }

}
