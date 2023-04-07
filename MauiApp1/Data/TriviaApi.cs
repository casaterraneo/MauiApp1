using System.Net.Http.Json;

namespace MauiApp1.Data;

public class TriviaApi
{
    private readonly HttpClient _client;
    public TriviaApi(HttpClient client)
    {
        _client = client;
    }

    public async Task<TriviaQuestionDto[]> GetQuestionsAsync(int numberOfQuestions)
    {
        var results = new List<TriviaQuestionDto>();

        while (results.Count < numberOfQuestions)
        {
            // Get 10 trivia questions that match a certain criteria
            var triviaQuestions = await _client.GetFromJsonAsync<TriviaQuestion[]>("?limit=10");

            foreach (var q in triviaQuestions!)
            {
                if (q.Type == "Multiple Choice" && !q.IsNiche)
                {
                    results.Add(new TriviaQuestionDto
                    {
                        Question = q.Question,
                        Answers = q.IncorrectAnswers
                                .Select(a => new TriviaAnswerDto { Answer = a, IsCorrectAnswer = false })
                                .Union(new[] { new TriviaAnswerDto { Answer = q.CorrectAnswer, IsCorrectAnswer = true } })
                                .ToArray()
                    });

                    if (results.Count == numberOfQuestions)
                    {
                        break;
                    }
                }
            }
        }

        return results.ToArray();
    }
}

