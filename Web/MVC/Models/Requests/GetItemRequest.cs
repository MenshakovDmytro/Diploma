﻿namespace MVC.Models.Requests;

public class GetItemRequest<T>
{
    public T Id { get; set; } = default(T) !;
}