using UnityEngine;
using UnityEngine.Audio;
public class SoundControl : MonoBehaviour {
    public AudioMixer master;
	
    public void setSound(float val)
    {
        master.SetFloat("SoundVol", val);
        PlayerPrefs.SetFloat("SoundVol", val);
    }
    public void setEffect(float val)
    {
        master.SetFloat("EffectVol", val);
        PlayerPrefs.SetFloat("EffectVol", val);
    }
}
