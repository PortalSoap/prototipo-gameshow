namespace ButtonBattle.Models;

public class QuestionViewModel
{
    public int Id { get; set; }
    public string Theme { get; set; }
    public string Question { get; set; }
    public string OptionA { get; set; }
    public string OptionB { get; set; }
    public string OptionC { get; set; }
    public string OptionD { get; set; }
    public string OptionE { get; set; }
    public string CorrectOption { get; set; }
}