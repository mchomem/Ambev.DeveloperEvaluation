﻿namespace Ambev.DeveloperEvaluation.Domain.Entities;

public sealed class CartItem
{
    public Guid Id { get; set; }
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    #region Navigation

    public Cart Cart { get; set; }
    public Product Product { get; set; }

    #endregion
}
