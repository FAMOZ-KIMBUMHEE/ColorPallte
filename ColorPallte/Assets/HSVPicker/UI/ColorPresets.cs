using UnityEngine;
using UnityEngine.UI;

public class ColorPresets : MonoBehaviour
{
    public ColorPicker picker;
    public GameObject[] presets;
    public Image createPresetImage;

    public void CreatePresetButton()
    {
        if(createPresetImage.GetComponent<Image>().color != presets[0].GetComponent<Image>().color)
        {
            for (int i = presets.Length - 1; i > -1; i--)
            {
                if (i == 0)
                {
                    presets[i].GetComponent<Image>().color = createPresetImage.GetComponent<Image>().color;
                }
                else
                    presets[i].GetComponent<Image>().color = presets[i - 1].GetComponent<Image>().color;
            }

        }
            
    }

    public void SetColor(Color _color)
    {
        picker.CurrentColor = _color;
    }

    public void PresetSelectPresetSelect(Image sender)
    {
        picker.CurrentColor = sender.color;
    }
}
