using Microsoft.AspNetCore.Mvc;
using ButtonBattle.Data;
using ButtonBattle.Models;

namespace ButtonBattle.Controllers;

public class GameController : Controller
{
    private readonly ButtonBattleDbContext _dbContext;
    private static int _count;
    private static List<QuestionViewModel> _tempQuestionList = new List<QuestionViewModel>();
    private static int _team1Points = 0;
    private static int _team2Points = 0;

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
        if(_count < 10)
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

        if (_count < 10)
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

    public IActionResult NextQuestion(string theme)
    {
        if(_count < 10)
        {
            List<QuestionViewModel> questions = _dbContext.Questions.Where(x => x.Theme == theme).ToList();
            QuestionViewModel actualQuestion = questions[_count];

            _count++;

            return RedirectToAction("Question", "Game", actualQuestion);
        }
        else
        {
            _count = 0;
            return RedirectToAction("Themes", "Game");
        }
    }

    public IActionResult Question(int selectedTeam, string answer, QuestionViewModel q)
    {
        ViewData["actualQuestion"] = _count;
        if(selectedTeam == 1)
        {
            if(answer == q.CorrectOption)
            {
                _team1Points++;
            }
            else
            {
                _team2Points++;
            }
        }
        else if(selectedTeam == 2)
        {
            if (answer == q.CorrectOption)
            {
                _team2Points++;
            }
            else
            {
                _team1Points++;
            }
        }

        ViewData["team1Points"] = _team1Points;
        ViewData["team2Points"] = _team2Points;

        return View(q);
    }
}