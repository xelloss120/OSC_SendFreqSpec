using System.Collections.Generic;
using UnityEngine;
using TMPro;
using uOSC;

public class main : MonoBehaviour
{
    [SerializeField] TMP_Dropdown Device;
    [SerializeField] TMP_InputField LengthSec;
    [SerializeField] TMP_InputField Frequency;
    [SerializeField] TMP_InputField Section;
    [SerializeField] AudioSource AudioSource;
    [SerializeField] LineRenderer LineRenderer;
    [SerializeField] uOscClient OscClient;

    const int LEN = 4096;
    float[] Spectrum = new float[LEN];

    //List<float> Values = new List<float>();
    public List<float> Values = new List<float>();

    void Start()
    {
        foreach (var device in Microphone.devices)
        {
            var option = new TMP_Dropdown.OptionData();
            option.text = device;
            Device.options.Add(option);
        }

        for (int i = 0; i < LEN; i++)
        {
            var vec3 = new Vector3(Mathf.Log(i + 1), 0, 0);
            LineRenderer.SetPosition(i, vec3);
        }

        Apply();
    }

    void Update()
    {
        AudioSource.GetSpectrumData(Spectrum, 0, FFTWindow.Rectangular);

        var p = 1;
        var f = Mathf.Pow(LEN, 1.0f / Values.Count);

        Values[0] = 0;

        var log = "";
        for (int i = 0; i < LEN; i++)
        {
            var vec3 = LineRenderer.GetPosition(i);
            vec3.y = Spectrum[i] == 0 ? 0 : Mathf.Log(Spectrum[i], 10000);
            LineRenderer.SetPosition(i, vec3);

            Values[p - 1] += Spectrum[i];
            if (i > Mathf.Pow(f, p))
            {
                p++;
                Values[p - 1] = 0;
            }
        }

        //OscClient.Send("/uOSC/test");
    }

    void Apply()
    {
        string device;
        int lengthSec;
        int frequency;
        int section;

        device = Device.options[Device.value].text;
        int.TryParse(LengthSec.text, out lengthSec);
        int.TryParse(Frequency.text, out frequency);
        int.TryParse(Section.text, out section);

        AudioSource.clip = Microphone.Start(device, true, lengthSec, frequency);
        while (Microphone.GetPosition(null) <= 0) { }
        AudioSource.Play();

        Values.Clear();
        for (int i = 0; i < section; i++)
        {
            Values.Add(0);
        }
    }

    public void OnClick()
    {
        Apply();
    }
}
