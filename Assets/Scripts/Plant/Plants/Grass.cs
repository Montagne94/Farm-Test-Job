public class Grass : Plant, ICollecteble
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}