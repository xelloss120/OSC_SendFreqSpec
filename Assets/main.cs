using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using uOSC;

public class main : MonoBehaviour
{
    [SerializeField] TMP_Dropdown Device;
    [SerializeField] TMP_InputField LengthSec;
    [SerializeField] TMP_InputField Frequency;

    [SerializeField] TMP_InputField Samples;
    [SerializeField] TMP_InputField Section;

    [SerializeField] TMP_InputField Host;
    [SerializeField] TMP_InputField Port;
    [SerializeField] TMP_InputField Address;

    [SerializeField] AudioSource AudioSource;
    [SerializeField] LineRenderer LineRenderer;
    [SerializeField] uOscClient OscClient;

    int Length;
    float[] Spectrum;

    List<float> Values = new List<float>();

    string OSC_Address;

    void Start()
    {
        foreach (var device in Microphone.devices)
        {
            var option = new TMP_Dropdown.OptionData();
            option.text = device;
            Device.options.Add(option);
        }

        Apply();
    }

    void Update()
    {
        AudioSource.GetSpectrumData(Spectrum, 0, FFTWindow.Rectangular);

        var p = 1;
        var f = Mathf.Pow(Length, 1.0f / Values.Count);

        Values[0] = 0;

        for (int i = 0; i < Length; i++)
        {
            var vec3 = LineRenderer.GetPosition(i);
            vec3.y = Spectrum[i] == 0 ? 0 : Mathf.Log(Spectrum[i], Mathf.Pow(10, 30));
            LineRenderer.SetPosition(i, vec3);

            Values[p - 1] += Spectrum[i];
            if (i > Mathf.Pow(f, p))
            {
                p++;
                Values[p - 1] = 0;
            }
        }

        var osc = "";
        for (int i = 0; i < Values.Count; i++)
        {
            osc += Values[i].ToString() + ",";
        }
        OscClient.Send(OSC_Address, osc);
    }

    void Apply()
    {
        string device;
        int lengthSec;
        int frequency;

        int samples;
        int section;

        string host;
        int port;
        string address;

        device = Device.options[Device.value].text;
        int.TryParse(LengthSec.text, out lengthSec);
        int.TryParse(Frequency.text, out frequency);

        int.TryParse(Samples.text, out samples);
        int.TryParse(Section.text, out section);

        host = Host.text;
        int.TryParse(Port.text, out port);
        address = Address.text;

        AudioSource.clip = Microphone.Start(device, true, lengthSec, frequency);
        while (Microphone.GetPosition(null) <= 0) { }
        AudioSource.Play();

        Length = samples;
        Array.Resize(ref Spectrum, samples);

        Values.Clear();
        for (int i = 0; i < section; i++)
        {
            Values.Add(0);
        }

        var max = Mathf.Log(Length);
        LineRenderer.positionCount = Length;
        for (int i = 0; i < Length; i++)
        {
            var vec3 = new Vector3(Mathf.Log(i + 1) / max, 0, 0);
            LineRenderer.SetPosition(i, vec3);
        }

        OscClient.address = host;
        OscClient.port = port;
        OSC_Address = address;
    }

    public void OnClick()
    {
        Apply();
    }
}
