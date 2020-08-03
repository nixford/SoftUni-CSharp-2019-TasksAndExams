using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Hero hero;

    [SetUp]
    public void Initialize()
    {
        //this.hero = new Hero("Pesho");
    }

    [Test]
    public void LosesHealthIfAttack()
    {
        Dummy target = new Dummy(20, 20);

        target.TakeAttack(10);

        Assert.That(target.Health, Is.EqualTo(10));
    }

    [Test]
    public void DeadDummyAttacked()
    {
        Dummy target = new Dummy(-1, 5);

        Assert.That(() => target.TakeAttack(10),
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void CanGiveExp()
    {
        Dummy target = new Dummy(-1, 10);
        int experiance = 0;

        experiance = target.GiveExperience();

        Assert.That(experiance, Is.EqualTo(10));
    }

    [Test]
    public void CanNotGiveExp()
    {
        Dummy target = new Dummy(5, 10);

        Assert.That(() => target.GiveExperience(), 
            Throws
            .InvalidOperationException
            .With
            .Message
            .EqualTo("Target is not dead."));
    }
}
