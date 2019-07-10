using Model;
using Network;
using TMPro;
using UnityEngine;
using Object = System.Object;

public class ShowWeather : MonoBehaviour
{
    public WeatherApiClient weatherClient;

    private GameObject collided;

    // Prefab
    private GameObject weatherDataContainer;

    private GameObject b1;

    private SwitchDay skript;

    public void Start()
    {
        weatherClient = GameObject.Find("WeatherApiClient").GetComponent<WeatherApiClient>();

        collided = null;
        weatherDataContainer = null;
        b1 = null;
        skript = null;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Marker"))
        {
            if (weatherDataContainer != null)
            {
                skript = (SwitchDay) collided.GetComponent(typeof(SwitchDay));
                skript.Reset();
                weatherDataContainer.SetActive(false);
            }

            collided = col.transform.gameObject;
            weatherDataContainer = col.transform.Find("Wetterdaten").gameObject;
            b1 = col.transform.Find("switch_button_forward").gameObject;

            weatherDataContainer.SetActive(true);
            InsertWeatherData();
            b1.SetActive(true);
            return;
        }

        return;
    }

    private void InsertWeatherData()
    {
        weatherClient.GetWeather("berlin", HandleResponse);
    }

    private void HandleResponse(WeatherForecast weatherForecast)
    {
        WeatherReport today = weatherForecast.today;
        foreach (DayTime dayTime in today.data.Keys)
        {
            WeatherData weatherData = today.data[dayTime];

            string componentName = null;
            switch (dayTime)
            {
                case DayTime.MORNING:
                    componentName = "MorningTemperature";
                    break;
                case DayTime.NOON:
                    componentName = "NoonTemperature";
                    break;
                case DayTime.NIGHT:
                    componentName = "EveningTemperature";
                    break;
                case DayTime.EVENING:
                    componentName = "NightTemperature";
                    break;
                default:
                    // TODO
                    break;
            }

            SetText(weatherData.temperature, componentName);
            
            Material material = Resources.Load("Materials/schnee.mat", typeof(Material)) as Material;
            Transform phenomenaComponent = weatherDataContainer.transform.Find("MorningPhenomena");
            phenomenaComponent.GetComponent<MeshRenderer>().material = material;
        }
    }

    private void SetText(Object text, string componentName)
    {
        Transform textComponent = weatherDataContainer.transform.Find(componentName);
        TextMeshPro txt = textComponent.GetComponent<TextMeshPro>();
        txt.text = text.ToString();
    } 

    void OnTriggerExit(Collider col)
    {
    }
}