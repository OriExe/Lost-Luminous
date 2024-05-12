using UnityEngine;

public class BatteryItem : MonoBehaviour
{
    [SerializeField] private int numberOfBatteries;
    [SerializeField] private TorchItem torch;
    // Start is called before the first frame update


    private void OnEnable()
    {
        torch.chargeTorch(numberOfBatteries);
        enabled = false;
    }
}
