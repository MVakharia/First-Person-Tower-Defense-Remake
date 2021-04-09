using UnityEngine;

public enum MachineState
{
    Off, On
}

public abstract class Machine : MonoBehaviour
{
    [SerializeField]
    protected MachineState powerState;

    [SerializeField]
    protected float temperature;

    [SerializeField]
    protected CoolingSystem connectedCoolingSystem;

    public const float epoTemperature = 85;

    protected void TurnOnMachine() => powerState = MachineState.On;

    protected void TurnOffMachine() => powerState = MachineState.Off;

    protected bool MachineAboveSafeTemperature => temperature >= epoTemperature;

    protected void SetTemperatureToAmbient ()
    {
        temperature = WeatherController.Singleton.Temperature;
    }

    protected void IncreaseTemperaturePerSecond (float amount)
    {
        temperature += amount * Time.deltaTime;
    }

    protected void HeatUp ()
    {
        IncreaseTemperaturePerSecond(2);        
    }

    protected void EPO ()
    {
        if(MachineAboveSafeTemperature)
        {
            TurnOffMachine();
        }
    }

    protected void CoolDown ()
    {
        DecreaseTemperaturePerSecond(1);
    }

    protected void DecreaseTemperaturePerSecond (float amount)
    {
        temperature -= amount * Time.deltaTime;
    }

    protected void ThisStart ()
    {
        SetTemperatureToAmbient();

        TurnOnMachine();
    }

    protected void ThisUpdate ()
    {
        if (powerState == MachineState.On)
        {
            HeatUp();
        }

        if(powerState == MachineState.Off)
        {
            CoolDown();
        }

        EPO();
    }
}