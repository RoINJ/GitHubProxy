using AutoFixture.Xunit2;
using Core.ContentReplacement;
using Core.PageDownload;
using FluentAssertions;
using Moq;

namespace Core.Tests.Unit;

public class ModifyContentCommandHandlerTests
{
    [Theory, AutoMoqData]
    public async Task HandleShouldModifyDownloadedPage(
        ModifyContentCommand command,
        HttpContent content,
        string expectedResult,
        [Frozen] Mock<IPageDownloader> pageDownloaderMock,
        [Frozen] Mock<IContentModifier> contentModifierMock,
        ModifyContentCommandHandler sut)
    {
        var downloadedContent = await content.ReadAsStringAsync();
        pageDownloaderMock
            .Setup(m => m.GetPage(command.Url))
            .ReturnsAsync(content);
        contentModifierMock
            .Setup(m => m.ModifyContent(downloadedContent))
            .Returns(expectedResult);

        var actualResult = await sut.Handle(command, CancellationToken.None);

        actualResult.Should().Be(expectedResult);
    }
}