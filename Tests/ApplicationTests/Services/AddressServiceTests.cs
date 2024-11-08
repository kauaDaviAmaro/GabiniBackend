using Moq;
using Core.Models;
using Core.Repositories;

namespace Test.Application.Services
{
    public class AddressServiceTests
    {
        // [Fact]
        // public async Task SaveAddress_ShouldCallRepositoryAndReturnAddress()
        // {
        //     // Arrange
        //     Mock<IAddressRepository> mockRepository = new Mock<IAddressRepository>();
        //     Address address = new Address("Rua Teste", 123, "Bbairro Teste", "Cidade Teste", "SP", "12345-678", null);
        //     mockRepository.Setup(r => r.SaveAddress(It.IsAny<Address>())).ReturnsAsync(address);

        //     var service = new AddressService(mockRepository.Object);
        //     var addressDTO = new AddressDTO
        //     {
        //         street = "Rua Teste",
        //         number = 123,
        //         neighborhood = "Bairro Teste",
        //         city = "Cidade Teste",
        //         state = "SP",
        //         zipCode = "12345-678"
        //     };

        //     // Act
        //     var result = await service.SaveAddress(addressDTO);

        //     // Assert
        //     mockRepository.Verify(r => r.SaveAddress(It.IsAny<Address>()), Times.Once);
        //     Assert.NotNull(result);
        //     Assert.Equal(address, result);
        // }
    }
}