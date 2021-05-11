public class AsteroidLarge : Asteroid
{
    protected override void OnHit()
    {
        asteroidFactory.CreateMediumAsteroidsAtPosition(2, transform.position);
        base.OnHit();
    }
}
