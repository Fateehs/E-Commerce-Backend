namespace ETradeAPI.Application.Abstractions.Services
{
    public interface IQRCodeService
    {
        byte[] GenerateQrCode(string text);
    }
}
