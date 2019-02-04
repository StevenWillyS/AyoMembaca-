using UnityEngine;
using UnityEngine.UI;
public class Click : MonoBehaviour {
    public Controller currentText;
	//change view
    public void changer()
    {
        string text = GetComponentInChildren<Text>().text;
        currentText.changeUI(text);
    }
}
