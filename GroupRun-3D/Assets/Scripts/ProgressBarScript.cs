using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBarScript : MonoBehaviour
{

    public Slider slider;

    private TextMeshProUGUI child_tmpro;
    private string text_tmpro;
    // Start is called before the first frame update
    void Start()
    {
        child_tmpro = transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
        setTextValueTo(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            increaseNumber();
        }
    }

    private void setTextValueTo(int value)
    {
        text_tmpro = value.ToString() + "/15";
        child_tmpro.text = text_tmpro;
    }

    public void increaseNumber()
    {

        if (slider.value < slider.maxValue)
        {
            slider.value += 1;
            setTextValueTo((int)slider.value);
        }

    }

}
