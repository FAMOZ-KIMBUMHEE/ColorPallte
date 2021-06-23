using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorPickerTester : MonoBehaviour 
{

    //public new Renderer renderer;
    public ColorPicker picker;

    public Image image_;

    public 

	// Use this for initialization
	void Start () 
    {
        //picker.onValueChanged.AddListener(color => { renderer.material.color = color;});

        picker.onValueChanged.AddListener(color => { image_.color = color; });

        image_.color = picker.CurrentColor;
        //renderer.material.color = picker.CurrentColor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
