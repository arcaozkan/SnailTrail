using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class Options : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    void Start()
    {
        //Resolution Settings
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentresolutionindex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentresolutionindex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentresolutionindex;
        resolutionDropdown.RefreshShownValue();
    }
    public AudioMixer audiomixer;
    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("Volume",volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void setresolution(int resindex)
    {
        Resolution resolution = resolutions[resindex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
