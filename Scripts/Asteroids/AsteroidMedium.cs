public class AsteroidMedium : Asteroid
{
    protected override void OnHit()
    {
        asteroidFactory.CreateSmallAsteroidAtPosition(2, transform.position);
        base.OnHit();
    }
}
