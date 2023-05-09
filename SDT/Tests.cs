namespace SDT;

public class Tests
{
    [Test]
    public void Task1_Test1()
    {
        List<object> payload = new List<object>() { 1, 2, "a", "b" };
        List<int> expected = new List<int>{ 1, 2 };

        List<int> actual = Task1.GetIntegersFromList(payload);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Task1_Test2()
    {
        List<object> payload = new List<object>() { 1, 2, "a", "b", 0, 15};
        List<int> expected = new List<int>{ 1, 2, 0, 15 };

        List<int> actual = Task1.GetIntegersFromList(payload);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Task2_Test1()
    {
        string payload = "stress";
        char expected = 't';

        char actual = Task2.FirstNonRepeatingLetter(payload);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Task2_Test2()
    {
        string payload = "sTreSS";
        char expected = 'T';

        char actual = Task2.FirstNonRepeatingLetter(payload);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Task3_Test1()
    {
        int payload = 16; 
        int expected = 7; // 1 + 6 = 7

        int actual = Task3.DigitalRoot(payload);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Task3_Test2()
    {
        int payload = 132189; 
        int expected = 6; // 1 + 3 + 2 + 1 + 8 + 9 = 24 --> 2 + 4 = 6

        int actual = Task3.DigitalRoot(payload);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Task4_Test1()
    {
        Tuple<int[], int> payload = Tuple.Create(new int[]{1, 3, 4}, 4);
        int expected = 2; // (1, 3), (3, 1)

        int actual = Task4.CountPairsSumEqualsTarget(payload.Item1, payload.Item2);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Task4_Test2()
    {
        Tuple<int[], int> payload = Tuple.Create(new int[]{1, 3, 6, 2, 2, 0, 4, 5}, 5);
        int expected = 7; // (1, 4), (3, 2), (2, 3), (2, 3), (0, 5), (4, 1), (5, 0), 

        int actual = Task4.CountPairsSumEqualsTarget(payload.Item1, payload.Item2);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Task5_Test1()
    {
        string payload = "Fired:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
        string expected = "(CORWILL, ALFRED) (CORWILL, FIRED) (CORWILL, RAPHAEL) (CORWILL, WILFRED) (TORNBULL, BARNEY) (TORNBULL, BETTY) (TORNBULL, BJON)";

        string actual = Task5.UpperFriendsWithSort(payload);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Task5_Test2()
    {
        string payload = "";

        Assert.That(
            () => Task5.UpperFriendsWithSort(payload),
            Throws.ArgumentException.With.Message.EqualTo(Task5.InputStringCannotBeNullOrEmpty)
        );
    }

    [Test]
    public void Task5_Test3()
    {
        string? payload = null;

        Assert.That(
            () => Task5.UpperFriendsWithSort(payload),
            Throws.ArgumentException.With.Message.EqualTo(Task5.InputStringCannotBeNullOrEmpty)
        );
    }

    [Test]
    public void Task6_Test1()
    {
        int payload = 513; 
        int expected = 531;

        int actual = Task6.NextBigger(payload);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Task6_Test2()
    {
        int payload = 9; 
        int expected = -1;

        int actual = Task6.NextBigger(payload);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Task7_Test1()
    {
        uint payload = 0; 
        string expected = "0.0.0.0";

        string actual = Task7.UintToIPv4(payload);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Task7_Test2()
    {
        uint payload = 2149583361; 
        string expected = "128.32.10.1";

        string actual = Task7.UintToIPv4(payload);

        Assert.That(actual, Is.EqualTo(expected));
    }
}
