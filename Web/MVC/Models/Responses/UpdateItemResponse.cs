﻿namespace MVC.Models.Responses;

public class UpdateItemResponse<T>
{
    public T Id { get; set; } = default(T) !;
}