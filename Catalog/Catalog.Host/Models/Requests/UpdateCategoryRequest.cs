﻿namespace Catalog.Host.Models.Requests;

public class UpdateCategoryRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}