using FluentAssertions;
using PawsTrack.Domain.Entities;

namespace PawsTrack.Tests.Domain;

public class DogEntityTests
{
    [Fact]
    public void Create_WithValidData_SetsProperties()
    {
        var dog = Dog.Create("Buddy", 3, "Golden Retriever", "None", 1);

        dog.Name.Should().Be("Buddy");
        dog.AgeYears.Should().Be(3);
        dog.Breed.Should().Be("Golden Retriever");
        dog.MedicalNotes.Should().Be("None");
        dog.ClientId.Should().Be(1);
        dog.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void Create_ZeroAge_Succeeds()
    {
        var act = () => Dog.Create("Pup", 0, "Mixed Breed", null, 1);
        act.Should().NotThrow();
    }

    [Fact]
    public void Create_Age30_Succeeds()
    {
        var act = () => Dog.Create("Old", 30, "Mixed Breed", null, 1);
        act.Should().NotThrow();
    }

    [Fact]
    public void Create_NegativeAge_ThrowsArgumentException()
    {
        var act = () => Dog.Create("Dog", -1, "Poodle", null, 1);
        act.Should().Throw<ArgumentException>().WithParameterName("ageYears");
    }

    [Fact]
    public void Create_AgeOver30_ThrowsArgumentException()
    {
        var act = () => Dog.Create("Dog", 31, "Poodle", null, 1);
        act.Should().Throw<ArgumentException>().WithParameterName("ageYears");
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Create_WithEmptyName_ThrowsArgumentException(string? name)
    {
        var act = () => Dog.Create(name!, 2, "Poodle", null, 1);
        act.Should().Throw<ArgumentException>().WithParameterName("name");
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Create_WithEmptyBreed_ThrowsArgumentException(string? breed)
    {
        var act = () => Dog.Create("Buddy", 2, breed!, null, 1);
        act.Should().Throw<ArgumentException>().WithParameterName("breed");
    }

    [Fact]
    public void Create_WithClientIdZero_ThrowsArgumentException()
    {
        var act = () => Dog.Create("Buddy", 2, "Poodle", null, 0);
        act.Should().Throw<ArgumentException>().WithParameterName("clientId");
    }

    [Fact]
    public void Create_WithNullMedicalNotes_Succeeds()
    {
        var dog = Dog.Create("Buddy", 2, "Poodle", null, 1);
        dog.MedicalNotes.Should().BeNull();
    }

    [Fact]
    public void Create_TrimsNameAndBreed()
    {
        var dog = Dog.Create("  Max  ", 1, "  Labrador  ", null, 1);
        dog.Name.Should().Be("Max");
        dog.Breed.Should().Be("Labrador");
    }
}
