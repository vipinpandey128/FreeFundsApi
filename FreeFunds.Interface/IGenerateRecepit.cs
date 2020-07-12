using FreeFundsApi.ViewModels;

namespace FreeFundsApi.Interface
{
    public interface IGenerateRecepit
    {
        GenerateRecepitViewModel Generate(int paymentId);
    }
}