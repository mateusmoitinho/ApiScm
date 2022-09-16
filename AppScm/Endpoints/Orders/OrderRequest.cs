namespace AppScm.Endpoints.Clients;

public record OrderRequest(List<Guid> ProductsIds, string DeliveryAddress);

