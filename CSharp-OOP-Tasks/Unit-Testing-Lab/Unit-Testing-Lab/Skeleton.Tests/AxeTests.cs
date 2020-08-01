using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Dummy target;

    [SetUp]
    public void Initialize()
    {
        target = new Dummy(5, 5);
    }

    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        Axe axe = new Axe(2, 2);

        axe.Attack(target);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(1), "Axe does not loose durability");
    }

    [Test]
    public void AttackWithBrokenWeapon()
    {
        Axe axe = new Axe(2, 0);

        Assert.That(() => axe.Attack(target),
            Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}