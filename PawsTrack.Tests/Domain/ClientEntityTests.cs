using FluentAssertions;
using PawsTrack.Domain.Entities;

namespace PawsTrack.Tests.Domain;

public class ClientEntityTests
{
    [Fact]
    public void Create_WithValidData_SetsProperties()
    {
        var client = Client.Create("Jane Owner", "555-1234", "123 Main St");

        client.FullName.Should().Be("Jane Owner");
        client.Phone.Should().Be("555-1234");
        client.Address.Should().Be("123 Main St");
        client.Dogs.Should().BeEmpty();
        client.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void Create_TrimsWhitespace()
    {
        var client = Client.Create("  Jane  ", "  555  ", "  Street  ");

        client.FullName.Should().Be("Jane");
        client.Phone.Should().Be("555");
        client.Address.Should().Be("Street");
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Create_WithEmptyFullName_ThrowsArgumentException(string? name)
    {
        var act = () => Client.Create(name!, "555", "Addr");
        act.Should().Throw<ArgumentException>().WithParameterName("fullName");
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Create_WithEmptyPhone_ThrowsArgumentException(string? phone)
    {
        var act = () => Client.Create("Name", phone!, "Addr");
        act.Should().Throw<ArgumentException>().WithParameterName("phone");
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Create_WithEmptyAddress_ThrowsArgumentException(string? address)
    {
        var act = () => Client.Create("Name", "555", address!);
        act.Should().Throw<ArgumentException>().WithParameterName("address");
    }
}
