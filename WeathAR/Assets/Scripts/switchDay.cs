using Model;
using TMPro;
using UnityEngine;

public class SwitchDay : MonoBehaviour
{
    public TextMeshPro tag;

    private ShowWeather showWeather;

    public void Start()
    {
        showWeather = GameObject.Find("Pointer").GetComponent<ShowWeather>();
    }

    public void SwitchForward()
    {
        if (tag.text == "Heute")
        {
            tag.text = "Morgen";
            this.transform.Find("switch_button_backward").gameObject.SetActive(true);
            Notify(DayType.Tomorrow);
            return;
        }

        if (tag.text == "Morgen")
        {
            tag.text = "Übermorgen";
            this.transform.Find("switch_button_forward").gameObject.SetActive(false);
            Notify(DayType.DayAfterTomorrow);
            return;
        }
    }

    public void SwitchBackward()
    {
        if (tag.text == "Übermorgen")
        {
            tag.text = "Morgen";
            this.transform.Find("switch_button_forward").gameObject.SetActive(true);
            Notify(DayType.Tomorrow);
            return;
        }

        if (tag.text == "Morgen")
        {
            tag.text = "Heute";
            this.transform.Find("switch_button_backward").gameObject.SetActive(false);
            Notify(DayType.Today);
            return;
        }
    }

    public void Reset()
    {
        tag.text = "Heute";
        this.transform.Find("switch_button_forward").gameObject.SetActive(false);
        this.transform.Find("switch_button_backward").gameObject.SetActive(false);
        Notify(DayType.Today);
    }

    private void Notify(DayType dayType)
    {
        showWeather.UpdateView(dayType);
    }
}