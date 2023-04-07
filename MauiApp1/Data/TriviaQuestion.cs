namespace MauiApp1.Data;

public class TriviaQuestion
{
    public string? Category { get; set; }
    public required string Id { get; set; }
    public required string CorrectAnswer { get; set; }
    public required string[] IncorrectAnswers { get; set; }
    public required string Question { get; set; }
    public string[]? Tags { get; set; }
    public string? Type { get; set; }
    public string? Difficulty { get; set; }
    public object[]? Regions { get; set; }
    public required bool IsNiche { get; set; }
}

public class TriviaQuestionDto
{
    public required TriviaAnswerDto[] Answers { get; set; }
    public required string Question { get; set; }
}

public class TriviaAnswerDto
{    
    public required string Answer { get; set; }
    public bool MyAnswer { get; set; }
    public required bool IsCorrectAnswer { get; set; }
}