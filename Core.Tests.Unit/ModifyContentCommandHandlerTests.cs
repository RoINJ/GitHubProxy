using Core.PageDownload;
using FluentAssertions;
using Moq;

namespace Core.Tests.Unit;

public class ModifyContentCommandHandlerTests
{
    [Theory, AutoMoqData]
    public async Task HandleShouldCallPageDownloader(
        ModifyContentCommand command,
        HttpContent content,
        Mock<IPageDownloader> pageDownloaderMock,
        ModifyContentCommandHandler sut)
    {
        pageDownloaderMock
            .Setup(m => m.GetPage(command.Url))
            .ReturnsAsync(content);
        var expectedResult = await content.ReadAsStringAsync();

        var actualResult = await sut.Handle(command, CancellationToken.None);

        actualResult.Should().Be(expectedResult);
    }
}