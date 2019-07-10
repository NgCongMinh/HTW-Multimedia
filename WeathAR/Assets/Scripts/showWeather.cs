using System;
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

            string temperatureComponentName = null;
            string phenomenaComponentName = null;
            switch (dayTime)
            {
                case DayTime.MORNING:
                    temperatureComponentName = "MorningTemperature";
                    phenomenaComponentName = "MorningPhenomena";
                    break;
                case DayTime.NOON:
                    temperatureComponentName = "NoonTemperature";
                    phenomenaComponentName = "NoonPhenomena";
                    break;
                case DayTime.EVENING:
                    temperatureComponentName = "EveningTemperature";
                    phenomenaComponentName = "EveningPhenomena";
                    break;
                case DayTime.NIGHT:
                    temperatureComponentName = "NightTemperature";
                    phenomenaComponentName = "NightPhenomena";
                    break;
                default:
                    // TODO
                    break;
            }

            // temperature
            SetText(String.Format("{0:0.00}", weatherData.temperature), temperatureComponentName);

            // weather phenomena
            Material material = WeatherPhenomenaMapper.GetWeatherMaterial(weatherData.phenomena);

            Transform phenomenaComponent = weatherDataContainer.transform.Find(phenomenaComponentName);
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