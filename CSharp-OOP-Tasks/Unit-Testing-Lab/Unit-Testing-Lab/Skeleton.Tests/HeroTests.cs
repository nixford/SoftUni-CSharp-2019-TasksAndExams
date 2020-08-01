using NUnit.Framework;
using Skeleton.Tests;

[TestFixture]
public class HeroTests
{
    
    private const string HeroName = "Pesho";

    [Test]
    public void HeroGainsExperienceAfterAttackIfTargetDies()
    {
        ITarget fakeTarget = new FakeTarget();
        IWeapon fakeWeapon = new FakeWeapon();

        Hero hero = new Hero(HeroName, fakeWeapon);
        hero.Attack(fakeTarget);

        Assert.That(hero.Experience, Is.EqualTo(10), "Hero does not gaining XP when target dies");

    }
}