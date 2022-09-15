namespace AppScm.Endpoints.Products;

public record ProductRequest(string Name, string Description, Guid CategoryId, bool HasStock, decimal Price, bool Active);