using UnityEngine;

public class BatteryItem : MonoBehaviour
{
    [SerializeField] private TorchItem torch;
    // Start is called before the first frame update

    private void Start()
    {
        
    }
    public void setAmount(int amount)
    {
        torch.chargeTorch(amount);
    }
}
