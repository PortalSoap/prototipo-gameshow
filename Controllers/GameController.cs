using Microsoft.AspNetCore.Mvc;
using ButtonBattle.Data;
using ButtonBattle.Models;
using System.Reflection.Metadata;

namespace ButtonBattle.Controllers;

public class GameController : Controller
{
    private readonly ButtonBattleDbContext _dbContext;
    private static int _count;
    private static List<QuestionViewModel> _tempQuestionList = new List<QuestionViewModel>();

    public GameController(ButtonBattleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult MainMenu()
    {
        return View();
    }

    public IActionResult Themes()
    {
        List<String> themes = _dbContext.Questions.Select(x => x.Theme).Distinct().ToList();
        _count = 0;
        return View(themes);
    }

    public IActionResult NewTheme()
    {
        return View();
    }

    public IActionResult NewQuestion(string theme)
    {
        if(_count <= 2)
        {
            return View("NewQuestion", theme);
        }
        else
        {
            return RedirectToAction("AddQuestions", "Game");
        }
        
    }

    public async Task<IActionResult> AddQuestions(string theme, string question, 
    string optionA, string optionB, string optionC, string optionD, string optionE, 
    string selected)
    {
        QuestionViewModel newQuestion = new QuestionViewModel
        {
            Theme = "Tema",
            Question = "Pergunta",
            OptionA = "123",
            OptionB = "123",
            OptionC = "123",
            OptionD = "123",
            OptionE = "123",
            CorrectOption = "c"
        };

        if (_count <= 2)
        {
            newQuestion = new QuestionViewModel
            {
                Theme = theme,
                Question = question,
                OptionA = optionA,
                OptionB = optionB,
                OptionC = optionC,
                OptionD = optionD,
                OptionE = optionE,
                CorrectOption = selected
            };

            _count++;
            _tempQuestionList.Add(newQuestion);
            return RedirectToAction("NewQuestion", "Game", new {theme = theme});
        }
        else
        {
            foreach(QuestionViewModel q in _tempQuestionList)
            {
                await _dbContext.Questions.AddAsync(q);
            }
            await _dbContext.SaveChangesAsync();
            
            _count = 0;
            _tempQuestionList.Clear();

            return RedirectToAction("Themes", "Game");
        }
    }

    public IActionResult Question()
    {
        return View();
    }
}