using UnityEngine;
using UnityEngine.UI;
public class ClickExtra : MonoBehaviour {
    public ControllerExtra currentText;
	//change view
    public void changer()
    {
        string text = GetComponentInChildren<Text>().text;
        currentText.changeUI(text);
    }
}
