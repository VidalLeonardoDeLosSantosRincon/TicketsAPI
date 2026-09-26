using Microsoft.AspNetCore.Mvc;
using TicketsAPI.Application.DTOs.Access;
using TicketsAPI.Application.Interfaces.Services.Auth;
using TicketsAPI.Controllers;

namespace TicketsAPI.UnitTests.API.Controllers;

[TestFixture]
public class AuthControllerTests
{
    private readonly Mock<IJwtService> _jwtServiceMock;
    private readonly AuthController _controller;

    public AuthControllerTests()
    {
        _jwtServiceMock = new Mock<IJwtService>();
        _controller = new(_jwtServiceMock.Object);
    }

    [SetUp]
    public void SetUp()
    {
      
    }

    [Test]
    public async Task Token_WithValidCredentials_ReturnsOkWithToken()
    {
        // Arrange
        var loginDto = new LoginDto()
        {
            Email = "ana.garcia@empresa.com",
            Password = "user123*"
        };

        var loginResponseDto = new LoginResponseDto()
        {
            Email = loginDto.Email,
            Role = "Solicitante",
            AccessToken = "fake-jwt-token"
        };
        _jwtServiceMock
            .Setup(s => s.GenerateTokenAsync(loginDto, CancellationToken.None))
            .ReturnsAsync(loginResponseDto);

        // Act
        var result = await _controller.Token(loginDto, CancellationToken.None);

        // Assert
        Assert.Multiple(() =>
        {
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult!.StatusCode, Is.EqualTo(200));

            var value = okResult.Value as LoginResponseDto;

            Assert.That(value?.Email, Is.EqualTo(loginResponseDto.Email));
            Assert.That(value?.Role, Is.EqualTo(loginResponseDto.Role));
            Assert.That(value?.AccessToken, Is.EqualTo(loginResponseDto.AccessToken));
        });
    }

    [Test]
    public async Task Token_WhenUnauthorizedAccessExceptionThrown_ReturnsUnauthorizedWithMessage()
    {
        // Arrange
        var loginDto = new LoginDto { Email = "user", Password = "wrong-password" };
        var exceptionMessage = "Credenciales inválidas";

        _jwtServiceMock
            .Setup(s => s.GenerateTokenAsync(loginDto, CancellationToken.None))
            .ThrowsAsync(new UnauthorizedAccessException(exceptionMessage));

        // Act
        var result = await _controller.Token(loginDto, CancellationToken.None);

        // Assert
        Assert.Multiple(() =>
        {
            var unauthorizedResult = result as UnauthorizedObjectResult;
            Assert.That(unauthorizedResult, Is.Not.Null);
            Assert.That(unauthorizedResult!.StatusCode, Is.EqualTo(401));
            Assert.That(unauthorizedResult.Value, Is.EqualTo(exceptionMessage));
        });
    }

    [Test]
    public async Task Token_WhenInvalidDataExceptionThrown_ReturnsBadRequestWithMessage()
    {
        // Arrange
        var loginDto = new LoginDto { Email = "", Password = "" };
        var exceptionMessage = "Datos incompletos";

        _jwtServiceMock
            .Setup(s => s.GenerateTokenAsync(loginDto, CancellationToken.None))
            .ThrowsAsync(new InvalidDataException(exceptionMessage));

        // Act
        var result = await _controller.Token(loginDto, CancellationToken.None);

        // Assert
        Assert.Multiple(() =>
        {
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult, Is.Not.Null);
            Assert.That(badRequestResult!.StatusCode, Is.EqualTo(400));
            Assert.That(badRequestResult.Value, Is.EqualTo(exceptionMessage));
        });
    }

    [Test]
    public async Task Token_WhenUnexpectedExceptionThrown_ReturnsStatusCode500()
    {
        // Arrange
        var loginDto = new LoginDto { Email = "user", Password = "123" };

        _jwtServiceMock
            .Setup(s => s.GenerateTokenAsync(loginDto, CancellationToken.None))
            .ThrowsAsync(new Exception("Error de base de datos"));

        // Act
        var result = await _controller.Token(loginDto, CancellationToken.None);

        // Assert
        Assert.Multiple(() =>
        {
            var objectResult = result as ObjectResult;
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult!.StatusCode, Is.EqualTo(500));
        });
    }
}
