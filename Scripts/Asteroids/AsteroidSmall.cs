public class AsteroidSmall : Asteroid
{
    protected override void OnHit()
    {
        if (!gameController.isWaveMode())
        {
            //Create a large asteroid to keep the game going
            asteroidFactory.CreateLargeAsteroid(1);
        }
        
        base.OnHit();
    }

}
