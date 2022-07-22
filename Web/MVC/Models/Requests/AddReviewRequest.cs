﻿namespace MVC.Models.Requests;

public class AddReviewRequest
{
    public int ProductId { get; set; }
    public string UserId { get; set; }
    public string Username { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}