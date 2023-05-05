public class Carrot : Plant, ICollecteble
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}