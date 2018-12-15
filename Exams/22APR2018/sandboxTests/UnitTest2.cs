using System;
using System.Diagnostics.CodeAnalysis;
using FestivalManager.Entities.Contracts;
using FestivalManager.Entities.Factories;
using NUnit.Framework;

[TestFixture]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Reflection_000_002
{
    [Test]
    public void TryToCreateInstrument()
    {
        var instrumentFactory = new InstrumentFactory();

        var instrument = instrumentFactory.CreateInstrument("TestGuitar");

        Assert.That(instrument, Is.Not.Null, "Instrument wasn't created correctly!");
        Assert.That(instrument, Is.TypeOf<TestGuitar>(), "Created instrument isn't of the correct type!");
    }
}

public class TestGuitar : IInstrument
{
    public double Wear { get; set; }

    public void Repair() => throw new NotImplementedException();

    public void WearDown() => throw new NotImplementedException();

    public bool IsBroken { get; set; }
}